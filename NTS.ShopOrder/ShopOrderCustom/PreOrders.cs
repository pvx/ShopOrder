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
    public class PreOrders : BindingList<PreOrderHeaderObj>, TreeList.IVirtualTreeListData
    {
        private IUnityContainer unityContainer { get; set; }

        private Guid _userId;

        [InjectionConstructor]
        public PreOrders(IUnityContainer container)
        {
            unityContainer = container;
            _userId = new Guid(unityContainer.Resolve<IOrderUserInfo>().Property["USER_ID"]);
        }

        public bool IsExistInState(int state)
        {
            return Items.Any(item => item.IdOrderState == state);
        }

        public void LoadAll(Guid idShop, DateTime filterDate, DateTime filterDateEnd)//изменено
        {
            using (var oc = unityContainer.Resolve<OrderDataContext>())
            {
                var ord = from or in oc.DataBaseContext.sp_sel_PreOrderHeaderOnDatePeriodAll(idShop, filterDate, filterDateEnd)
                          select new PreOrderHeaderObj()
                          {
                              CreateDate = or.CreateDate,
                              IdOrderHeader = or.id_PreOrderHeader,
                              IdOrderState = or.id_PreOrderState.GetValueOrDefault(1),
                              IdShop = or.id_Shop,
                              IdUser = or.id_User,
                              Name = or.Note,
                              Locked = or.LockDate.HasValue,
                              LockUser = or.LockUser,
                              ProcesDate = or.ProcesDate.GetValueOrDefault(),
                              CommitDate = or.CommitDate.GetValueOrDefault()
                          };

                var sdic = (from sd in oc.DataBaseContext.PreOrderStates
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

        public void LoadAll(Guid idShop, DateTime filterDate)//изменено
        {
            using (var oc = unityContainer.Resolve<OrderDataContext>())
            {
                var ord = from or in oc.DataBaseContext.sp_sel_PreOrderHeaderOnDateAll(idShop, filterDate)
                          select new PreOrderHeaderObj()
                          {
                              CreateDate = or.CreateDate,
                              IdOrderHeader = or.id_PreOrderHeader,
                              IdOrderState = or.id_PreOrderState.GetValueOrDefault(1),
                              IdShop = or.id_Shop,
                              IdUser = or.id_User,
                              Name = or.Note,
                              Locked = or.LockDate.HasValue,
                              LockUser = or.LockUser,
                              ProcesDate = or.ProcesDate.GetValueOrDefault(),
                              CommitDate = or.CommitDate.GetValueOrDefault()
                          };

                var sdic = (from sd in oc.DataBaseContext.PreOrderStates
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

        public void Load(Guid idShop, DateTime filterDate)//изменено
        {
            using (var oc = unityContainer.Resolve<OrderDataContext>())
            {
                var ord = from or in oc.DataBaseContext.sp_sel_PreOrderHeaderOnDate(idShop, filterDate)
                          select new PreOrderHeaderObj()
                          {
                              CreateDate = or.CreateDate,
                              IdOrderHeader = or.id_PreOrderHeader,
                              IdOrderState = or.id_PreOrderState.GetValueOrDefault(1),
                              IdShop = or.id_Shop,
                              IdUser = or.id_User,
                              Name = or.Note,
                              Locked = or.LockDate.HasValue,
                              LockUser = or.LockUser,
                              ProcesDate = or.ProcesDate.GetValueOrDefault(),
                              CommitDate = or.CommitDate.GetValueOrDefault()
                          };

                var sdic = (from sd in oc.DataBaseContext.PreOrderStates
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

        public void CommitOrderHeader(Guid idOrderHeader)//изменено
        {
            using (var oc = unityContainer.Resolve<OrderDataContext>())
            {
                oc.DataBaseContext.sp_upd_PreOrdersHeaderState(idOrderHeader, 2);
                unityContainer.Resolve<IDBLogger>().InsertLog("Подтверждение заказа", idOrderHeader.ToString().ToUpper());
            }
        }

        public void AddOrderHeader()//изменено
        {
            using (var oc = unityContainer.Resolve<OrderDataContext>())
            {
                var headerObj = new PreOrderHeaderObj();

                var sdic = (from sd in oc.DataBaseContext.PreOrderStates
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
                        oc.DataBaseContext.sp_upd_PreOrdersHeaderState(item.IdOrderHeader, item.IdOrderState);
                    }
                }
                WindowsIdentity wi = WindowsIdentity.GetCurrent();
                oc.DataBaseContext.sp_ins_PreOrdersHeader(headerObj.IdOrderHeader, headerObj.IdOrderState,
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

        protected override void InsertItem(int index, PreOrderHeaderObj item)//изменено
        {
            //item.id_OrderHeader = Guid.NewGuid();
            base.InsertItem(index, item);
        }

        void TreeList.IVirtualTreeListData.VirtualTreeGetCellValue(VirtualTreeGetCellValueInfo info)
        {
            var obj = info.Node as PreOrderHeaderObj;
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
