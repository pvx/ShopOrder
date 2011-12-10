using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Common;
using Common.Logger;
using DataBase;
using DataBase.DataObject;
using DevExpress.XtraEditors;
using Microsoft.Practices.Unity;

namespace ShopOrderCustom
{
    public class OrderModel : ModelBase
    {
        public IUnityContainer UnityContainer { get; set; }

        [Dependency]
        public IOrderUserInfo OrderUserInfo { get; set; }

        [Dependency]
        public Logger Log { get; set; }

        public Guid IdOrderHeader { get; set; }

        private XtraForm _view;

        private OrderHeaderObj _currentOrderHeader;

        public XtraForm View
        {
            get
            {
                if (_view == null)
                    return _view = new OrderForm(this);

                return _view;
            }
            set
            {
                if (_view == null)
                    _view = value;
            }
        }

        public OrderHeaderObj CurrentOrderHeader
        {
            get { return _currentOrderHeader; }
            set { _currentOrderHeader = value; }
        }

        public Orders GetOrdersHeader()
        {
            using (OrderDataContext oc = UnityContainer.Resolve<OrderDataContext>())
            {
                string userId = UnityContainer.Resolve<IOrderUserInfo>().Property["USER_ID"];
                Orders orders = UnityContainer.Resolve<Orders>();

                var ord = (from or in oc.DataBaseContext.vOrderHeaderAll
                          where or.id_User == new Guid(userId)
                          select new OrderHeaderObj(){
                            CreateDate = or.CreateDate,
                            IdOrderHeader = or.id_OrderHeader,
                            IdOrderState = or.id_OrderState.GetValueOrDefault(1),
                            IdShop = or.id_Shop,
                            IdUser = or.id_User,
                            Name = or.Note
                          }).OrderBy(or => or.CreateDate);
                
                var sdic = (from sd in oc.DataBaseContext.OrderState
                                select sd);
        
                foreach (var orderHeader in ord)
                {
                    foreach (var orderState in sdic)
                    {
                        orderHeader.OrderStateDict.Add(orderState.id, orderState.Name);
                    }
                    orderHeader.IdOrderState = orderHeader.IdOrderState;
                    orders.Add(orderHeader); 
                }
                return orders;
            }
        }

        public BindingList<GoodsBalanceObj> GetOrderList()
        {
            if (_currentOrderHeader != null)
            {
                using (OrderDataContext oc = UnityContainer.Resolve<OrderDataContext>())
                {
                    List<vGoodsBalanceOrder> orders;
                    if(StoreHouseType)
                    {
                        orders = oc.DataBaseContext.vGoodsBalanceOrder.Where(
                                or => (((or.id_OrderHeader == _currentOrderHeader.IdOrderHeader)
                                        || (or.id_OrderHeader == null)) && (or.GoodsGroup != @"АЛКОГОЛЬНЫЕ НАПИТКИ"))).ToList();    
                    }
                    else
                    {
                        orders = oc.DataBaseContext.vGoodsBalanceOrder.Where(
                                or => (((or.id_OrderHeader == _currentOrderHeader.IdOrderHeader)
                                        || (or.id_OrderHeader == null)) && (or.GoodsGroup == @"АЛКОГОЛЬНЫЕ НАПИТКИ"))).ToList();   
                    }
                    
                    BindingList<GoodsBalanceObj> balance = new BindingList<GoodsBalanceObj>();

                    balance.AllowEdit = _currentOrderHeader.IdOrderState == 1;

                    foreach (var vo in orders)
                    {
                        GoodsBalanceObj bl = new GoodsBalanceObj()
                                                {
                                                    Barcode = vo.Barcode,
                                                    Code = vo.Code,
                                                    Date = vo.Date,
                                                    FreeBalance = vo.FreeBalance.GetValueOrDefault(),
                                                    Group = vo.GoodsGroup,
                                                    id = vo.id_GoodsBalance,
                                                    Measure = vo.Measure,
                                                    MinOrder = vo.MinOrder.GetValueOrDefault(),
                                                    Name = vo.Name,
                                                    Price = vo.Price.GetValueOrDefault(),
                                                    ReqQuantity = vo.ReqQuantity,
                                                    Ordered = vo.Ordered.GetValueOrDefault(),
                                                    Quantity = vo.Balance.GetValueOrDefault(),
                                                    QuantityInPack = vo.QuantityInPack.GetValueOrDefault(),
                                                    Reserved = vo.Reserved.GetValueOrDefault(),
                                                    Supplier = vo.Supplier
                                                };
                        bl.ChangeReqQuantity += new ChangeReqQuantity(bl_ChangeReqQuantity);
                        balance.Add(bl);
                    }
                    return balance;
                }
            }
            return null;
        }

        public bool StoreHouseType { get; set;}

        void SaveOrder(GoodsBalanceObj goodsObj)
        {
            {
                using (OrderDataContext oc = UnityContainer.Resolve<OrderDataContext>())
                {
                    oc.DataBaseContext.spCreateOrderNew(goodsObj.id, IdOrderHeader, goodsObj.ReqQuantity);
                    IQueryable<vGoodsBalanceOrder> gods = from gd in oc.DataBaseContext.vGoodsBalanceOrder
                                                          where (gd.id_OrderHeader == IdOrderHeader &&
                                                                 gd.id_GoodsBalance == goodsObj.id)
                                                          select gd;
                    foreach (var gd in gods)
                    {
                        goodsObj.Ordered = gd.Ordered.GetValueOrDefault(0);
                        goodsObj.Quantity = gd.Balance.GetValueOrDefault(0);
                    }
                }
            }
        }

        void bl_ChangeReqQuantity(object sender, EventChangeReqQuantity e)
        {
            GoodsBalanceObj gb = e.GoodsObj;
            try
            {
                
                gb.ChangeReqQuantity -= new ChangeReqQuantity(bl_ChangeReqQuantity);

                

                if ((gb.Ordered + gb.Quantity) < gb.ReqQuantity)
                {
                    if(XtraMessageBox.Show("Остатки меньше чем заказываемое количество. Заказать?", "Внимание!",
                                        MessageBoxButtons.YesNo) == DialogResult.Yes)
                    SaveOrder(gb);
                    else
                        gb.ReqQuantity = 0;
                }
                else
                {
                    SaveOrder(gb);
                }
            }
            finally
            {
                gb.ChangeReqQuantity += new ChangeReqQuantity(bl_ChangeReqQuantity);
            }
        }

        [InjectionConstructor]
        public OrderModel(IUnityContainer unityContainer)
        {
            UnityContainer = unityContainer;
            StoreHouseType = true;}
    }
}
