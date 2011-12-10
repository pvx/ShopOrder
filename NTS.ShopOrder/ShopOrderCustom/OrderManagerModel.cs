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
    public class OrderManagerModel : ModelBase
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
                    return _view = new OrderManagerForm(this);

                return _view;
            }
            set
            {
                if (_view == null)
                    _view = value;}
        }

        public OrderHeaderObj CurrentOrderHeader
        {
            get { return _currentOrderHeader; }
            set { _currentOrderHeader = value; }
        }
 
        public OrderShops GetOrdersHeader()
        {
            return UnityContainer.Resolve<OrderShops>();           
        }

        public BindingList<GoodsBalanceObj> GetOrderList()
        {
            if (_currentOrderHeader != null)
            {
                using (OrderDataContext oc = UnityContainer.Resolve<OrderDataContext>())
                {
                    List<vOrderDayAll> orders = oc.DataBaseContext.vOrderDayAll.Where(
                                or => (((or.id_OrderHeader == _currentOrderHeader.IdOrderHeader)
                                        ))).ToList();


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
                            Ordered = vo.Ordered,
                            Quantity = vo.Balance,
                            QuantityInPack = vo.QuantityInPack.GetValueOrDefault(),
                            Reserved = vo.Reserved.GetValueOrDefault(),
                            Supplier = vo.Supplier
                        };
                        balance.Add(bl);
                    }
                    return balance;
                }
            }
            return null;
        }
  /*
        public BindingList<GoodsBalanceObj> GetOrderList()
        {
            if (_currentOrderHeader != null)
            {
                using (OrderDataContext oc = UnityContainer.Resolve<OrderDataContext>())
                {
                    List<vGoodsBalanceOrder> orders = oc.DataBaseContext.vGoodsBalanceOrder.Where(
                                or => (((or.id_OrderHeader == _currentOrderHeader.IdOrderHeader)
                                        ))).ToList();
                    
                    
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
                        balance.Add(bl);
                    }
                    return balance;
                }
            }
            return null;
        }
        */
        [InjectionConstructor]
        public OrderManagerModel(IUnityContainer unityContainer)
        {
            UnityContainer = unityContainer;
        }
    }
}