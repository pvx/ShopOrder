using System;
using System.ComponentModel;
using System.Linq;
using System.Security.Principal;
using Common;
using DataBase;
using DataBase.DataObject;
using DataBase.Log;
using DevExpress.XtraTreeList;
using Microsoft.Practices.Unity;

namespace ShopOrderCustom
{
    /// <summary>
    /// Класс списка заказов
    /// </summary>
    public class Orders : BindingList<OrderHeaderObj>, TreeList.IVirtualTreeListData
    {
        private IUnityContainer unityContainer { get; set; }

        private Guid _userId;

        [InjectionConstructor]
        public Orders(IUnityContainer container)
        {
            unityContainer = container;
            _userId = new Guid(unityContainer.Resolve<IOrderUserInfo>().Property["USER_ID"]);
        }

        public bool IsExistInState(int state)
        {
            return Items.Any(item => item.IdOrderState == state);
        }

        public void LoadAll(Guid idShop, DateTime filterDate, DateTime filterDateEnd)
        {
            using (var oc = unityContainer.Resolve<OrderDataContext>())
            {
                var ord = from or in oc.DataBaseContext.sp_sel_OrderHeaderOnDatePeriodAll(idShop, filterDate, filterDateEnd)
                          select new OrderHeaderObj()
                          {
                              CreateDate = or.CreateDate,
                              IdOrderHeader = or.id_OrderHeader,
                              IdOrderState = or.id_OrderState.GetValueOrDefault(1),
                              IdShop = or.id_Shop,
                              IdUser = or.id_User,
                              Name = or.Note,
                              Locked = or.LockDate.HasValue,
                              LockUser = or.LockUser,
                              ProcesDate = or.ProcesDate.GetValueOrDefault(),
                              CommitDate = or.CommitDate.GetValueOrDefault()
                          };

                var sdic = (from sd in oc.DataBaseContext.OrderState
                            select sd);

                foreach (var orderHeader in ord)
                {
                    foreach (var orderState in sdic)
                    {
                        orderHeader.OrderStateDict.Add(orderState.id, orderState.Name);
                    }
                    orderHeader.IdOrderState = orderHeader.IdOrderState;
                    Add(orderHeader);
                }
            }
        }

        public void LoadAll(Guid idShop, DateTime filterDate)
        {
            using (var oc = unityContainer.Resolve<OrderDataContext>())
            {
                var ord = from or in oc.DataBaseContext.sp_sel_OrderHeaderOnDateAll(idShop, filterDate)
                          select new OrderHeaderObj()
                          {
                              CreateDate = or.CreateDate,
                              IdOrderHeader = or.id_OrderHeader,
                              IdOrderState = or.id_OrderState.GetValueOrDefault(1),
                              IdShop = or.id_Shop,
                              IdUser = or.id_User,
                              Name = or.Note,
                              Locked = or.LockDate.HasValue,
                              LockUser = or.LockUser,
                              ProcesDate = or.ProcesDate.GetValueOrDefault(),
                              CommitDate = or.CommitDate.GetValueOrDefault()
                          };

                var sdic = (from sd in oc.DataBaseContext.OrderState
                            select sd);

                foreach (var orderHeader in ord)
                {
                    foreach (var orderState in sdic)
                    {
                        orderHeader.OrderStateDict.Add(orderState.id, orderState.Name);
                    }
                    orderHeader.IdOrderState = orderHeader.IdOrderState;
                    Add(orderHeader);
                }
            }
        }

        public void Load(Guid idShop, DateTime filterDate)
        {
            using (var oc = unityContainer.Resolve<OrderDataContext>())
            {
                var ord = from or in oc.DataBaseContext.sp_sel_OrderHeaderOnDate(idShop, filterDate) 
                          select new OrderHeaderObj()
                          {
                                         CreateDate = or.CreateDate,
                                         IdOrderHeader = or.id_OrderHeader,
                                         IdOrderState = or.id_OrderState.GetValueOrDefault(1),
                                         IdShop = or.id_Shop,
                                         IdUser = or.id_User,
                                         Name = or.Note,
                                         Locked = or.LockDate.HasValue,
                                         LockUser = or.LockUser,
                                         ProcesDate = or.ProcesDate.GetValueOrDefault(),
                                         CommitDate = or.CommitDate.GetValueOrDefault()
                                     };

                var sdic = (from sd in oc.DataBaseContext.OrderState
                            select sd);

                foreach (var orderHeader in ord)
                {
                    foreach (var orderState in sdic)
                    {
                        orderHeader.OrderStateDict.Add(orderState.id, orderState.Name);
                    }
                    orderHeader.IdOrderState = orderHeader.IdOrderState;
                    Add(orderHeader);
                }   
            }
        }
        
        public void CommitOrderHeader(Guid idOrderHeader)
        {
            using (var oc = unityContainer.Resolve<OrderDataContext>())
            {
                oc.DataBaseContext.sp_upd_OrdersHeaderState(idOrderHeader, 2);
                unityContainer.Resolve<IDBLogger>().InsertLog("Подтверждение заказа", idOrderHeader.ToString().ToUpper());
            }
        }

        public void AddOrderHeader()
        {
            using (var oc = unityContainer.Resolve<OrderDataContext>())
            {
                var headerObj = new OrderHeaderObj(); 
                
                var sdic = (from sd in oc.DataBaseContext.OrderState
                         select sd);
                foreach (var orderState in sdic)
                {
                    headerObj.OrderStateDict.Add(orderState.id, orderState.Name);    
                }
                headerObj.IdOrderHeader = Guid.NewGuid();
                headerObj.IdUser = _userId;
                headerObj.CreateDate = DateTime.Now;
                headerObj.IdOrderState = 1;

                foreach (var item in Items)
                {
                    if (item.IdOrderState == 1)
                    {

                        item.IdOrderState = 2;
                        oc.DataBaseContext.sp_upd_OrdersHeaderState(item.IdOrderHeader, item.IdOrderState);
                    }
                }
                WindowsIdentity wi = WindowsIdentity.GetCurrent();
                oc.DataBaseContext.sp_ins_OrdersHeader(headerObj.IdOrderHeader, headerObj.IdOrderState,
                                                        headerObj.IdUser,
                                                        DateTime.Now, wi.Name);
                Add(headerObj);
                unityContainer.Resolve<IDBLogger>().InsertLog("Создание нового заказа", headerObj.IdOrderHeader.ToString().ToUpper());
            }
        }

        public void SetAllOrderState()
        {
            
        }

        void TreeList.IVirtualTreeListData.VirtualTreeGetChildNodes(VirtualTreeGetChildNodesInfo info)
        {
            //Project obj = info.Node as Project;
            //info.Children = obj.Projects;
        }

        protected override void InsertItem(int index, OrderHeaderObj item)
        {
            //item.id_OrderHeader = Guid.NewGuid();
            base.InsertItem(index, item);
        }

        void TreeList.IVirtualTreeListData.VirtualTreeGetCellValue(VirtualTreeGetCellValueInfo info)
        {
            var obj = info.Node as OrderHeaderObj;
            switch (info.Column.FieldName)
            {
                case "Name":
                    if (obj != null) 
                        info.CellData = obj;
                    break;
                case "User":
                    if (obj != null)
                        info.CellData = obj.LockUser;
                    break;
            }
        }

        void TreeList.IVirtualTreeListData.VirtualTreeSetCellValue(VirtualTreeSetCellValueInfo info)
        {
            info.Cancel = true;
        }
    }
    
}