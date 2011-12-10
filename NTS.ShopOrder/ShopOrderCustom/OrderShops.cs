using System;
using System.ComponentModel;
using System.Linq;
using Common;
using DataBase;
using DataBase.DataObject;
using DataBase.Log;
using DevExpress.XtraTreeList;
using Microsoft.Practices.Unity;

namespace ShopOrderCustom
{
    public class OrderShops : BindingList<OrderShopObj>, TreeList.IVirtualTreeListData
    {
        private IUnityContainer unityContainer { get; set; }

        [InjectionConstructor]
        public OrderShops(IUnityContainer container)
        {
            unityContainer = container;
        }

        public void LoadAllShops()
        {
            using (var oc = unityContainer.Resolve<OrderDataContext>())
            {
                var orderShop = from sh in oc.DataBaseContext.sp_sel_Shops()
                                select new OrderShopObj()
                                {
                                    IdShop = sh.id_shop,
                                    IdShopCategory = sh.id_ShopCategory,
                                    IdShopOwner = sh.id_ShopOwner,
                                    ShopAddress = sh.ShopAddress,
                                    ShopCode = sh.ShopCode,
                                    ShopName = sh.ShopName,
                                    IdUser = sh.id_user,
                                    UserLogin = sh.UserLogin
                                };

                foreach (var orderShopObj in orderShop)
                {
                    Add(orderShopObj);
                }
            }
        }

        public void LoadAll(DateTime filterDate, DateTime filterDateEnd)
        {
            using (var oc = unityContainer.Resolve<OrderDataContext>())
            {
                var orderShop = from sh in oc.DataBaseContext.sp_sel_ShopOnDateAll(filterDate, filterDateEnd)
                                select new OrderShopObj()
                                {
                                    IdShop = sh.id_shop,
                                    IdShopCategory = sh.id_ShopCategory,
                                    IdShopOwner = sh.id_ShopOwner,
                                    ShopAddress = sh.ShopAddress,
                                    ShopCode = sh.ShopCode,
                                    ShopName = sh.ShopName
                                };
                foreach (var orderShopObj in orderShop)
                {
                    Add(orderShopObj);
                    var orders = unityContainer.Resolve<Orders>();
                    orders.LoadAll(orderShopObj.IdShop, filterDate, filterDateEnd);
                    orderShopObj.Orders = orders;
                }
            }
        }
        
        public void Load(DateTime filterDate)
        {
            using (var oc = unityContainer.Resolve<OrderDataContext>())
            {
                var orderShop = from sh in oc.DataBaseContext.sp_sel_ShopOnDate(filterDate)
                                select new OrderShopObj()
                                           {
                                               IdShop = sh.id_shop,
                                               IdShopCategory = sh.id_ShopCategory,
                                               IdShopOwner = sh.id_ShopOwner,
                                               //IdUser = sh.id_user.GetValueOrDefault(0),
                                               ShopAddress = sh.ShopAddress,
                                               ShopCode = sh.ShopCode,
                                               ShopName = sh.ShopName//UserLogin = sh.UserLogin
                                           };

                foreach (var orderShopObj in orderShop)
                {
                    Add(orderShopObj);
                    var orders = unityContainer.Resolve<Orders>();
                    orders.Load(orderShopObj.IdShop, filterDate);
                    orderShopObj.Orders = orders;
                }
            }
        }

        public void ChangeSelectedOrderState()
        {
            using (var oc = unityContainer.Resolve<OrderDataContext>())
            {
                foreach (OrderShopObj obj in Items)
                {
                    if (obj.Orders != null)
                    {
                        foreach (OrderHeaderObj ord in ((Orders) obj.Orders))
                        {
                            if ((ord.Checked) && (ord.IdOrderState == 2))
                            {
                                oc.DataBaseContext.sp_upd_OrdersHeaderState(ord.IdOrderHeader, 1);
                                ord.IdOrderState = 1;
                                unityContainer.Resolve<IDBLogger>().InsertLog(string.Format("Откат статуса заказа с Подтвержден на Введен."), ord.IdOrderHeader.ToString().ToUpper());
                            }
                        }
                    }
                }
            }   
        }

        public bool SaveSelectedOrder()
        {
            bool ret = false;

            using (var oc = unityContainer.Resolve<OrderDataContext>())
            {
                foreach (OrderShopObj obj in Items)
                {
                    if (obj.Orders != null)
                    {
                        foreach (OrderHeaderObj ord in ((Orders) obj.Orders))
                        {
                            if ((ord.Checked) && (ord.IdOrderState == 2))
                            {
                                oc.DataBaseContext.sp_ins_OrderForProcess(ord.IdOrderHeader);
                                ord.IdOrderState = 3;
                                ord.ProcesDate = DateTime.Now;
                                unityContainer.Resolve<IDBLogger>().InsertLog(string.Format("Смена статуса заказа с Подтвержден на Обработан."), ord.IdOrderHeader.ToString().ToUpper());
                                ret = true;
                            }
                        }                       
                    }
                }
            }
            return ret;
        }

        void TreeList.IVirtualTreeListData.VirtualTreeGetChildNodes(VirtualTreeGetChildNodesInfo info)
        {
            var obj = info.Node as OrderShopObj;
            info.Children = (Orders) obj.Orders;
        }

        protected override void InsertItem(int index, OrderShopObj item)
        {
            //item.id_OrderHeader = Guid.NewGuid();
            base.InsertItem(index, item);
        }

        void TreeList.IVirtualTreeListData.VirtualTreeGetCellValue(VirtualTreeGetCellValueInfo info)
        {
            OrderShopObj obj = info.Node as OrderShopObj;
            switch (info.Column.FieldName)
            {
                case "Name":if (obj != null)
                        info.CellData = obj;
                    break;
            }
        }

        void TreeList.IVirtualTreeListData.VirtualTreeSetCellValue(VirtualTreeSetCellValueInfo info)
        {
            info.Cancel = true;
            /*
            Project obj = info.Node as Project;
            switch (info.Column.Caption)
            {
                case "Name":
                    obj.Name = (string)info.NewCellData;
                    break;
            }
            */
        }
    }
}