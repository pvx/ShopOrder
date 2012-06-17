using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Linq;
using System.Linq;
using System.Windows.Forms;
using Common;
using Common.Enum;
using Common.Logger;
using DataBase;
using DataBase.DataObject;
using DataBase.Log;
using DevExpress.XtraEditors;
using Microsoft.Practices.Unity;
using ShopOrderCustom.UI;

namespace ShopOrderCustom.Models
{
    public class PreOrderModel : ModelLayout
    {
        public event ChangeDateFilter ChangeDateFilter;
        private XtraForm _view;
        private bool _autoFill;
        private bool _allowEdit;
        private PreOrderHeaderObj _currentOrderHeader;
        private DateTime _filterDate;
        private DateTime _serverDate;
        private Guid _shopId;

        public IUnityContainer unityContainer { get; set; }
        [Dependency]
        public IOrderUserInfo OrderUserInfo { get; set; }
        [Dependency]
        public Logger Log { get; set; }
        public bool AllowEdit { get { return _allowEdit; } }
        public Guid IdOrderHeader { get; set; }
        public DateTime ServerDate
        {
            get { return _serverDate; }
        }
        private BindingList<PreGoodsBalanceData> BalanceList { get; set; }
        public XtraForm View
        {
            get
            {
                if (_view == null)
                    return _view = new PreOrderForm(this);

                return _view;
            }
            set
            {
                if (_view == null)
                    _view = value;
            }
        }
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
        public PreOrderHeaderObj CurrentOrderHeader
        {
            get { return _currentOrderHeader; }
            set { _currentOrderHeader = value; }
        }
        public Storehouse StoreHouseType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="unityContainer"></param>
        [InjectionConstructor]
        public PreOrderModel(IUnityContainer unityContainer)
            : base(unityContainer)
        {
            ViewCode = ViewConst.CR_PRE_ORDER;
            this.unityContainer = unityContainer;
            StoreHouseType = Storehouse.Cold;
            _serverDate = DateTime.Parse(unityContainer.Resolve<IOrderUserInfo>().Property["SERVER_DATE"]);
            _shopId = Guid.Parse(unityContainer.Resolve<IOrderUserInfo>().Property["USER_SHOP"]);
        }

        protected virtual void SendChangeDataFilter(DateTime date)
        {
            if ((ChangeDateFilter != null))
            {
                ChangeDateFilter(this, new EventChangeDateFilter() { Date = date });
            }
        }

        public PreOrders GetOrdersHeader()//изменено
        {
            using (var oc = unityContainer.Resolve<OrderDataContext>())
            {
                var shopId = new Guid(unityContainer.Resolve<IOrderUserInfo>().Property["USER_SHOP"]);
                var orders = unityContainer.Resolve<PreOrders>();

                var ord = (from or in oc.DataBaseContext.sp_sel_PreOrderHeaderOnDateOrder(shopId, _filterDate)
                           select new PreOrderHeaderObj
                                      {
                                          CreateDate = or.CreateDate,
                                          IdOrderHeader = or.id_PreOrderHeader,
                                          IdOrderState = or.id_PreOrderState.GetValueOrDefault(1),
                                          IdShop = or.id_Shop,
                                          IdUser = or.id_User,
                                          Name = or.Note,
                                          ProcesDate = or.ProcesDate.GetValueOrDefault(),
                                          CommitDate = or.CommitDate.GetValueOrDefault()
                                      }).OrderBy(or => or.CreateDate);

                var sdic = (from sd in oc.DataBaseContext.PreOrderStates select sd);
        
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

        public void SetAutoOrder()
        {
            _autoFill = true;
            try
            {
                int cnt = 0;
                foreach (var goodsBalanceObj in BalanceList)
                {
                    if (goodsBalanceObj.OrderMode != AutoOrderModeEnum.NothingMode)
                    {
                        if (goodsBalanceObj.ForOrder > 0)
                        {
                            goodsBalanceObj.CalcAutoOrder(_serverDate);
                            cnt++;
                        }
                    }
                }
                unityContainer.Resolve<IDBLogger>().InsertLog(string.Format("Присвоение рекомендованного количества для автоматического заказа. {0} позиций", cnt), CurrentOrderHeader.IdOrderHeader.ToString().ToUpper());
            }
            finally
            {
                _autoFill = false;
            }    
        }

        public void CopyForOrder(bool isReqAssort){
            _autoFill = true;
            try
            {
                int cnt = 0;
                foreach (var goodsBalanceObj in BalanceList)
                {
                    if (isReqAssort)
                    {
                        if (goodsBalanceObj.RreqAssort)
                            if (goodsBalanceObj.ForOrder > 0)
                            {
                                goodsBalanceObj.CalcAutoOrder(_serverDate);
                                cnt++;
                            }
                    }
                    else
                    {
                        if (goodsBalanceObj.ForOrder > 0)
                        {
                            goodsBalanceObj.CalcAutoOrder(_serverDate);
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

        public BindingList<PreGoodsBalanceData> GetOrderList()
        {
            if (_currentOrderHeader != null)
            {
                Cursor.Current = Cursors.WaitCursor;
                try
                {
                    using (var oc = unityContainer.Resolve<OrderDataContext>())
                    {
                        var balance = new BindingList<PreGoodsBalanceData>();

                        _allowEdit = ((_currentOrderHeader.IdOrderState == 1) && (ServerDate.Date == _currentOrderHeader.CreateDate.Date));
                        balance.AllowEdit = _allowEdit;

                        var isBalance = unityContainer.Resolve<IOrderUserInfo>().Property.ContainsKey("SHOP_BALANCE") && !(double.Parse(unityContainer.Resolve<IOrderUserInfo>().Property["SHOP_BALANCE"]) == 0);
                        
                        var commitOrders = oc.DataBaseContext.sp_sel_PreOrderCommitGoodsByHeader(_currentOrderHeader.IdOrderHeader).ToList();

                        var orders = from vo in oc.DataBaseContext.sp_sel_PreOrderBalance(_currentOrderHeader.IdOrderHeader,
                                                                   Convert.ToInt32(StoreHouseType),
                                                                   _currentOrderHeader.IdOrderState)
                            
                            select new PreGoodsBalanceData
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
                                IsQuoted = vo.IsQuoted,
                                SelfImport = vo.SelfImport.GetValueOrDefault(false),
                                OrderMode = PreGoodsBalanceObj.ConvertToMode(vo.AutoOrderModeId),
                                IsLoaded = true,
                                IsShopBalance = isBalance,
                                LastOrderDate = vo.LastAutoOrderDate.GetValueOrDefault(DateTime.MinValue.Date),
                                CommitList = GetCommitList(commitOrders, vo.id_PreOrder.GetValueOrDefault())
                            };

                        foreach (var bl in orders)
                        {
                            bl.ChangePreReqQuantity += BlChangeReqQuantity;
                            bl.OnPreAutoOrdeer += bl_OnAutoOrdeer;
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

        private BindingList<GoodsBalanceObj> GetCommitList(IEnumerable<sp_sel_PreOrderCommitGoodsByHeaderResult> commitOrders, Guid idPreOrder)
        {
            var list = commitOrders.Where(x => x.id_PreOrder == idPreOrder).ToList();
            if ((list.Count > 0))
            {
                var ret = new BindingList<GoodsBalanceObj>() { AllowEdit = false, AllowNew = false, AllowRemove = false };
                foreach (var i in list)
                {
                    var gb = new GoodsBalanceObj()
                    {
                        Barcode = i.Barcode,
                        Code = i.Code,
                        Date = i.Date,
                        Group = i.GoodsGroup,
                        Measure = i.Measure,
                        Supplier = i.Supplier,
                        SelfImport = i.SelfImport.GetValueOrDefault(false),
                        Quantity = i.Ordered.GetValueOrDefault(0),
                        Price = i.Price.GetValueOrDefault(0),
                        QuantityInPack = i.QuantityInPack.GetValueOrDefault(0),
                        Name = i.Name,
                        MinOrder = i.MinOrder.GetValueOrDefault(0),

                    };
                    ret.Add(gb);
                }
                return ret;
            }
            return null;
        }


        void bl_OnAutoOrdeer(object sender, EventChangePreReqQuantity e)//изменено
        {
            //_shopId
            using (var oc = unityContainer.Resolve<OrderDataContext>())
            {
                oc.DataBaseContext.sp_ins_AutoOrdered(_shopId, e.GoodsObj.Code);
                e.GoodsObj.LastOrderDate = DateTime.Now.Date;
            }

        }

        void SaveOrder(PreGoodsBalanceObj goodsObj)//изменено
        {
            {
                using (var oc = unityContainer.Resolve<OrderDataContext>())
                {
                    oc.DataBaseContext.spCreatePreOrderNew(goodsObj.id, IdOrderHeader, goodsObj.ReqQuantity);
                    unityContainer.Resolve<IDBLogger>().InsertLog(string.Format("Позиция заказа. товар = '{0}' колво = {1}", goodsObj.id, goodsObj.ReqQuantity), IdOrderHeader.ToString().ToUpper());
                    var gods = oc.DataBaseContext.sp_sel_PreOrderBalanceRefresh(IdOrderHeader, goodsObj.id).Single();

                    goodsObj.Ordered = gods.Ordered;
                    goodsObj.Quantity = gods.Balance.GetValueOrDefault(0);
                    goodsObj.Quota = gods.Quota;
                }
            }
        }

        void BlChangeReqQuantity(object sender, EventChangePreReqQuantity e)//изменено
        {
            PreGoodsBalanceObj gb = e.GoodsObj;
            try
            {
                gb.ChangePreReqQuantity -= BlChangeReqQuantity;
                SaveOrder(gb);
            }
            finally
            {
                gb.ChangePreReqQuantity += BlChangeReqQuantity;
            }
        }

        //Проверка остатков не нужна?
        public bool CheckCreateOrder()
        {
            bool ret;
            using (var oc = unityContainer.Resolve<OrderDataContext>())
            {
                ret = oc.DataBaseContext.IsCanOrder().GetValueOrDefault(false);}
            return ret;
        }

        public bool CheckSaveOrder()//изменено
        {
            using (var oc = unityContainer.Resolve<OrderDataContext>())
            {
                ISingleResult<sp_sel_CheckPreOrderSaveResult> res = oc.DataBaseContext.sp_sel_CheckPreOrderSave(CurrentOrderHeader.IdOrderHeader);
                foreach (var spSelCheckPreOrderSaveResult in res)
                {
                    return spSelCheckPreOrderSaveResult.Column1 == 1;
                }
            }
            return false;
        }

        public bool CheckSaveOrder(Guid idOrderHeader)//изменено
        {
            using (var oc = unityContainer.Resolve<OrderDataContext>())
            {
                ISingleResult<sp_sel_CheckPreOrderSaveResult> res = oc.DataBaseContext.sp_sel_CheckPreOrderSave(idOrderHeader);
                foreach (var spSelCheckPreOrderSaveResult in res)
                {
                    return spSelCheckPreOrderSaveResult.Column1 == 1;
                }
            }
            return false;
        }
    }
}