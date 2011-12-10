using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Linq;
using System.Linq;
using System.Windows.Forms;
using Common;
using Common.Logger;
using DataBase;
using DataBase.DataObject;
using DataBase.Log;
using DevExpress.XtraEditors;
using Microsoft.Practices.Unity;
using ShopOrderCustom.UI;

namespace ShopOrderCustom.Models
{
    /// <summary>
    /// Модель данных UI создания заказов
    /// </summary>
    public class OrderModel : ModelLayout
    {
        public event ChangeDateFilter ChangeDateFilter;

        public IUnityContainer unityContainer { get; set; }

        [Dependency]
        public IOrderUserInfo OrderUserInfo { get; set; }

        [Dependency]
        public Logger Log { get; set; }

        public bool AllowEdit { get { return _allowEdit; } }

        public Guid IdOrderHeader { get; set; }

        private XtraForm _view;

        public DateTime ServerDate
        {
            get { return _serverDate; }
        }

        private BindingList<GoodsBalanceObj> BalanceList { get;set; }

        private bool _autoFill = false;

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

        private DateTime _filterDate;
        private DateTime _serverDate;
        private bool _allowEdit;

        public DateTime FilterDate
        {
            get
            {
                return _filterDate;
            }
            set
            {
                if ((_filterDate != value))
                {
                    _filterDate = value;
                    SendChangeDataFilter(_filterDate);
                }
            }
        }

        protected virtual void SendChangeDataFilter(DateTime date)
        {
            if ((ChangeDateFilter != null))
            {
                ChangeDateFilter(this, new EventChangeDateFilter() { Date = date });
            }
        }

        public OrderHeaderObj CurrentOrderHeader
        {
            get { return _currentOrderHeader; }
            set { _currentOrderHeader = value; }
        }
        public Orders GetOrdersHeader()
        {
            using (var oc = unityContainer.Resolve<OrderDataContext>())
            {
                Guid shopId = new Guid(unityContainer.Resolve<IOrderUserInfo>().Property["USER_SHOP"]);
                Orders orders = unityContainer.Resolve<Orders>();
                
                var ord = (from or in oc.DataBaseContext.sp_sel_OrderHeaderOnDateOrder(shopId, _filterDate)
                          select new OrderHeaderObj()
                          {
                            CreateDate = or.CreateDate,
                            IdOrderHeader = or.id_OrderHeader,
                            IdOrderState = or.id_OrderState.GetValueOrDefault(1),
                            IdShop = or.id_Shop,
                            IdUser = or.id_User,
                            Name = or.Note,
                            ProcesDate = or.ProcesDate.GetValueOrDefault(),
                            CommitDate = or.CommitDate.GetValueOrDefault()
                          }).OrderBy(or => or.CreateDate);

                var sdic = (from sd in oc.DataBaseContext.OrderState select sd);
        
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

        public void CopyForOrder(bool isReqAssort)
        {
            _autoFill = true;
            try
            {
                int cnt = 0;
                foreach (GoodsBalanceObj goodsBalanceObj in BalanceList)
                {
                    if (isReqAssort)
                    {
                        if (goodsBalanceObj.RreqAssort)
                            if (goodsBalanceObj.ForOrder > 0)
                            {
                                goodsBalanceObj.ReqQuantity = Convert.ToDouble(goodsBalanceObj.ForOrder);
                                cnt++;
                            }
                    }
                    else
                    {
                        if (goodsBalanceObj.ForOrder > 0)
                        {
                            goodsBalanceObj.ReqQuantity = Convert.ToDouble(goodsBalanceObj.ForOrder);
                            cnt++;
                        }
                    }
                }
                unityContainer.Resolve<IDBLogger>().InsertLog(string.Format("Присвоение рекомендованного заказа. {0} позиций", cnt), CurrentOrderHeader.IdOrderHeader.ToString().ToUpper());
            }
            finally
            {
                _autoFill = false;
            }
        }

        public BindingList<GoodsBalanceObj> GetOrderList()
        {
            if (_currentOrderHeader != null)
            {
                Cursor.Current = Cursors.WaitCursor;
                try
                {
                    using (var oc = unityContainer.Resolve<OrderDataContext>())
                    {                  
                        var balance = new BindingList<GoodsBalanceObj>();

                        _allowEdit = ((_currentOrderHeader.IdOrderState == 1) && (ServerDate.Date == _currentOrderHeader.CreateDate.Date));
                        balance.AllowEdit = _allowEdit;

                        var orders = from vo in oc.DataBaseContext.sp_sel_OrderBalance(_currentOrderHeader.IdOrderHeader,
                                                                   Convert.ToInt32(StoreHouseType),
                                                                   _currentOrderHeader.IdOrderState)
                                     select new GoodsBalanceObj
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
                                         Ordered = vo.Ordered,
                                         Quantity = vo.Balance.GetValueOrDefault(),
                                         QuantityInPack = vo.QuantityInPack.GetValueOrDefault(),
                                         Reserved = vo.Reserved.GetValueOrDefault(),
                                         Supplier = vo.Supplier,
                                         RreqAssort = vo.IsReqAssort.GetValueOrDefault(false),
                                         ReqQuantity = vo.ReqQuantity,
                                         ForOrder = vo.ForOrder.GetValueOrDefault(0),
                                         AvgSell = vo.AvgSell,
                                         ShopBalance = vo.ShopBalance,
                                         Quota = vo.Quota,
                                         IsQuoted = vo.IsQuoted,IsLoaded = true
                                     };
                        foreach (var bl in orders)
                        {
                            bl.ChangeReqQuantity += BlChangeReqQuantity;
                            balance.Add(bl);
                        }
                        BalanceList = balance;
                        return BalanceList;
                    }
                }
                finally
                {
                    Cursor.Current = Cursors.Default;
                }
            }
            return null;
        }


        public bool StoreHouseType { get; set;}

        void SaveOrder(GoodsBalanceObj goodsObj)
        {
            {
                using (var oc = unityContainer.Resolve<OrderDataContext>())
                {
                    oc.DataBaseContext.spCreateOrderNew(goodsObj.id, IdOrderHeader, goodsObj.ReqQuantity);
                    unityContainer.Resolve<IDBLogger>().InsertLog(string.Format("Позиция заказа. товар = '{0}' колво = {1}", goodsObj.id, goodsObj.ReqQuantity), IdOrderHeader.ToString().ToUpper());
                    var gods = oc.DataBaseContext.sp_sel_OrderBalanceRefresh(IdOrderHeader, goodsObj.id).Single();

                    goodsObj.Ordered = gods.Ordered;
                    goodsObj.Quantity = gods.Balance.GetValueOrDefault(0);
                    goodsObj.Quota = gods.Quota;
                }
            }
        }
        
        void BlChangeReqQuantity(object sender, EventChangeReqQuantity e)
        {
            GoodsBalanceObj gb = e.GoodsObj;
            try
            {
                gb.ChangeReqQuantity -= BlChangeReqQuantity;

                if ((!_autoFill) && ((gb.Ordered + gb.Quantity) < gb.ReqQuantity))
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
                gb.ChangeReqQuantity += BlChangeReqQuantity;
            }
        }

        public bool CheckCreateOrder()
        {
            bool ret;
            using (var oc = unityContainer.Resolve<OrderDataContext>())
            {
                ret = oc.DataBaseContext.IsCanOrder().GetValueOrDefault(false);}
            return ret;
        }

        public bool CheckSaveOrder()
        {
            using (var oc = unityContainer.Resolve<OrderDataContext>())
            {
                ISingleResult<sp_sel_CheckOrderSaveResult> res = oc.DataBaseContext.sp_sel_CheckOrderSave(CurrentOrderHeader.IdOrderHeader);
                foreach (sp_sel_CheckOrderSaveResult spSelCheckOrderSaveResult in res)
                {
                    return spSelCheckOrderSaveResult.Column1 == 1;
                }
            }
            return false;
        }

        public bool CheckSaveOrder(Guid idOrderHeader)
        {
            using (var oc = unityContainer.Resolve<OrderDataContext>())
            {
                ISingleResult<sp_sel_CheckOrderSaveResult> res = oc.DataBaseContext.sp_sel_CheckOrderSave(idOrderHeader);
                foreach (sp_sel_CheckOrderSaveResult spSelCheckOrderSaveResult in res)
                {
                    return spSelCheckOrderSaveResult.Column1 == 1;
                }
            }
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="unityContainer"></param>
        [InjectionConstructor]
        public OrderModel(IUnityContainer unityContainer)
            : base(unityContainer)
        {
            ViewCode = ViewConst.CR_ORDER;
            this.unityContainer = unityContainer;
            StoreHouseType = true;
            _serverDate = DateTime.Parse(unityContainer.Resolve<IOrderUserInfo>().Property["SERVER_DATE"]);
        }
    }
}
