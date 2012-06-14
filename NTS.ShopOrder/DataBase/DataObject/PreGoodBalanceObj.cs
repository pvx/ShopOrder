using System;
using System.ComponentModel;
using Common.Calculations;
using Common.Enum;

namespace DataBase.DataObject
{
    public delegate void ChangePreReqQuantity(object sender, EventChangePreReqQuantity e);
    public delegate void PreAutoOrdered(object sender, EventChangePreReqQuantity e);

    public class PreGoodsBalanceObj : INotifyPropertyChanging, INotifyPropertyChanged
    {
        private static readonly PropertyChangingEventArgs emptyChangingEventArgs = 
            new PropertyChangingEventArgs(String.Empty);

        private string _Barcode;
        private string _Code;
        private DateTime _Date;
        private double _FreeBalance;private string _Group;
        private string _Measure;
        private double _MinOrder;
        private string _Name;
        private decimal _Price;
        private double _Quantity;
        private double _QuantityInPack;
        private double _Reserved;
        private string _Supplier;
        private Guid _id;
        private double _ReqQuantity;
        private double _Ordered;
        private bool _reqAssort;
        private decimal _forOrder;
        private decimal _avgSell;
        private decimal _shopBalance;
        private double _quota;
        private bool _isQuoted;
        private bool _selfImport;
        public bool IsLoaded { get; set; }
        
        public double Quota
        {
            get { return _quota; }
            set
            {
                if (_quota != value)
                {
                    SendPropertyChanging();
                    _quota = value;
                    SendPropertyChanged("Quota");
                }
            }
        }

        public bool IsShopBalance { get; set; }

        public bool RreqAssort
        {
            get
            {
                return _reqAssort;
            }
            set
            {
                if ((_reqAssort != value))
                {
                    SendPropertyChanging();
                    _reqAssort = value;
                    SendPropertyChanged("RreqAssort");
                }
            }
        }

        private AutoOrderModeEnum _orderMode;
        public AutoOrderModeEnum OrderMode
        {
            get { return _orderMode; }
            set
            {
                SendPropertyChanging();
                _orderMode = value;
                SendPropertyChanged("OrderMode");
            }
        }

        public bool SelfImport
        {
            get
            {
                return _selfImport;
            }
            set
            {
                if ((_selfImport != value))
                {
                    SendPropertyChanging();
                    _selfImport = value;
                    SendPropertyChanged("SelfImport");
                }
            }
        }

        public bool IsQuoted
        {
            get
            {
                return _isQuoted;
            }
            set
            {
                if ((_isQuoted != value))
                {
                    SendPropertyChanging();
                    _isQuoted = value;
                    SendPropertyChanged("IsQuoted");
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inval"></param>
        /// <returns></returns>
        public static AutoOrderModeEnum ConvertToMode(short inval)
        {
            switch (inval)
            {
                case 1:
                    return AutoOrderModeEnum.MinOrderMode;
                case 2:
                    return AutoOrderModeEnum.RecommendMode;
                case 3:
                    return AutoOrderModeEnum.AllRecommendMode;
                default:
                    return AutoOrderModeEnum.NothingMode;
            }
        }

        private void IfNotShopBalance(double value)
        {
            if (!IsShopBalance) 
                return;
            if (ShopBalance <= 0)
            {
                ReqQuantity = value;
                SendOnPreAutoOrder();
            }
        }

        public void CalcAutoOrder(DateTime now)
        {
            if (RreqAssort)
            {
                switch (OrderMode)
                {
                    case AutoOrderModeEnum.MinOrderMode:
                        if (LastOrderDate <= now.Date)
                        {
                            IfNotShopBalance(MinOrder);
                           // SendOnAutoOrder();
                        }
                        break;

                    case AutoOrderModeEnum.RecommendMode:
                        if (LastOrderDate <= now.Date)
                        {
                            IfNotShopBalance(double.Parse(ForOrder.ToString()));
                            //SendOnAutoOrder();
                        }
                        break;

                    case AutoOrderModeEnum.AllRecommendMode:
                        if (LastOrderDate <= now.Date)
                        {
                            if (IsShopBalance)
                            {
                                ReqQuantity = (double.Parse(ForOrder.ToString()));
                                SendOnPreAutoOrder();
                            }
                        }
                        break;

                    default:
                        ReqQuantity = (double.Parse(ForOrder.ToString()));
                        break;
                }
            }
        }

        private DateTime _lastOrderDate;
        public DateTime LastOrderDate
        {
            get { return _lastOrderDate.AddDays(3).Date; }
            set { _lastOrderDate = value; }
        }

        private void CalcOrder(ref double reqQuantity)
        {
            if(reqQuantity != 0)
            {
                if ((reqQuantity < QuantityInPack) || (QuantityInPack <= 0))
                {
                    reqQuantity = _Quantity <= _MinOrder ? _Quantity : GetMinOrderQuantity(reqQuantity, _MinOrder);
                    if (Math.Abs(_Quantity - reqQuantity) < _MinOrder)
                        reqQuantity = _Quantity;
                }
                else
                {
                    reqQuantity = GetMultiplesQuantityInPack(reqQuantity, QuantityInPack);
                }

                if ((IsQuoted) && (reqQuantity > Quota))
                    reqQuantity = Quota;
            }
        }

        private static double GetMultiplesQuantityInPack(double reqQuantity, double minOrderQuantity)
        {
            double result = reqQuantity;
            double mod = reqQuantity % minOrderQuantity;

            if ((reqQuantity != 0) && (minOrderQuantity != 0) && (!double.IsNaN(mod)))
            {
                if (reqQuantity < minOrderQuantity)
                    result = minOrderQuantity;
                else if (reqQuantity > minOrderQuantity)
                {
                    result = mod == 0 ? reqQuantity : reqQuantity - mod + ((mod / minOrderQuantity) >= 0.5 ? minOrderQuantity : 0);
                }

                result = ((reqQuantity / result) >= 0.5) ? result : reqQuantity - mod;
            }

            return result;
        }

        private static double GetMinOrderQuantity(double reqQuantity, double minOrderQuantity)
        {
            double result = reqQuantity;
            double mod = reqQuantity % minOrderQuantity;

            if ((reqQuantity != 0) && (minOrderQuantity != 0) && (!double.IsNaN(mod)))
            {
                if (reqQuantity < minOrderQuantity)
                    result = minOrderQuantity;
                else if (reqQuantity > minOrderQuantity)
                {
                    result = mod == 0 ? reqQuantity : reqQuantity - mod + ((mod / minOrderQuantity) >= 0.4 ? minOrderQuantity : 0);
                }

                result = ((reqQuantity / result) >= 0.4) ? result : reqQuantity - mod;
            }

            return result;
        }

        private void SetValue(ref double reqQuantity, double value)
        {
            if (reqQuantity < value)
                reqQuantity = value;
        }

        void BeforeReqQuantityChange(ref double reqQuantity)
        {
            //Изменено
            if((MinOrder == QuantityInPack) /*&& (!RoundOrderHelper.Check(Quantity, QuantityInPack))*/)
            {
                reqQuantity = RoundOrderHelper.Calc(reqQuantity, Quantity, QuantityInPack, MinOrder);
                if ((IsQuoted) && (reqQuantity > Quota))
                    reqQuantity = Quota;
            }
            else
            {
                if ((!IsShopBalance) || (OrderMode == AutoOrderModeEnum.NothingMode))
                    CalcOrder(ref reqQuantity);
                else
                {
                    switch (OrderMode)
                    {
                        case AutoOrderModeEnum.MinOrderMode:
                            if ((IsShopBalance) && (ShopBalance == 0))
                                SetValue(ref reqQuantity, MinOrder);
                            break;

                        case AutoOrderModeEnum.RecommendMode:
                            if ((IsShopBalance) && (ShopBalance == 0))
                                SetValue(ref reqQuantity, double.Parse(ForOrder.ToString()));
                            break;

                        case AutoOrderModeEnum.AllRecommendMode:
                            if (IsShopBalance)
                                SetValue(ref reqQuantity, double.Parse(ForOrder.ToString()));
                            break;
                    }
                    CalcOrder(ref reqQuantity);
                }
            }
        }

        void AfterReqQuantityChange(double reqQuantity) 
        {
            
        }
        
        public double ReqQuantity
        {
            get
            {
                return _ReqQuantity;
            }
            set
            {
                if (_ReqQuantity != value)
                {
                    if (IsLoaded)
                        BeforeReqQuantityChange(ref value);
                    SendPropertyChanging();
                    _ReqQuantity = value;
                    SendPropertyChanged("ReqQuantity");
                    if (IsLoaded)
                    {
                        AfterReqQuantityChange(value);
                        SendChangePreReqQuantity();
                    }
                }
            }
        }

        public Guid id
        {
            get { return _id; }
            set
            {
                if ((_id != value))
                {
                    //this.OnidChanging(value);
                    SendPropertyChanging();
                    _id = value;
                    SendPropertyChanged("id");
                    //this.OnidChanged();
                }
            }
        }

        public string Group
        {
            get { return _Group; }
            set
            {
                if ((_Group != value))
                {
                    //this.OnGroupChanging(value);
                    SendPropertyChanging();
                    _Group = value;
                    SendPropertyChanged("Group");
                    //this.OnGroupChanged();
                }
            }
        }
        
        public decimal ShopBalance
        {
            get { return _shopBalance; }
            set
            {
                if ((_shopBalance != value))
                {
                    SendPropertyChanging();
                    _shopBalance = value;
                    SendPropertyChanged("ShopBalance");
                }
            }
        }

        public string Name
        {
            get { return _Name; }
            set
            {
                if ((_Name != value))
                {
                    //this.OnNameChanging(value);
                    SendPropertyChanging();
                    _Name = value;
                    SendPropertyChanged("Name");
                    //this.OnNameChanged();
                }
            }
        }

        public decimal ForOrder
        {
            get { return _forOrder; }
            set
            {
                if ((_forOrder != value))
                {
                    SendPropertyChanging();
                    _forOrder = value;
                    SendPropertyChanged("ForOrder");
                }
            }
        }

        public decimal Price
        {
            get { return _Price; }
            set
            {
                if ((_Price != value))
                {
                    //this.OnPriceChanging(value);
                    SendPropertyChanging();
                    _Price = value;
                    SendPropertyChanged("Price");
                    //this.OnPriceChanged();
                }
            }
        }

        public double QuantityInPack
        {
            get { return _QuantityInPack; }
            set
            {
                if ((_QuantityInPack != value))
                {
                    //this.OnQuantityInPackChanging(value);
                    SendPropertyChanging();
                    _QuantityInPack = value;
                    SendPropertyChanged("QuantityInPack");
                    //this.OnQuantityInPackChanged();
                }
            }
        }

        public double Ordered
        {
            get { return _Ordered; }
            set
            {
                if ((_Ordered!= value))
                {
                    //this.OnQuantityInPackChanging(value);
                    SendPropertyChanging();
                    _Ordered = value;
                    SendPropertyChanged("Ordered");
                    //this.OnQuantityInPackChanged();
                }
            }
        }

        public decimal AvgSell
        {
            get { return _avgSell; }
            set
            {
                if ((_avgSell != value))
                {
                    SendPropertyChanging();
                    _avgSell = value;
                    SendPropertyChanged("AvgSell");
                }
            }
        }

        public string Measure
        {
            get { return _Measure; }
            set
            {
                if ((_Measure != value))
                {
                   // this.OnMeasureChanging(value);
                    SendPropertyChanging();
                    _Measure = value;
                    SendPropertyChanged("Measure");
                    //this.OnMeasureChanged();
                }
            }
        }

        public double Quantity
        {
            get { return _Quantity; }
            set
            {
                if ((_Quantity != value))
                {
                    //this.OnQuantityChanging(value);
                    SendPropertyChanging();
                    _Quantity = value;
                    SendPropertyChanged("Quantity");
                    //this.OnQuantityChanged();
                }
            }
        }

        public string Supplier
        {
            get { return _Supplier; }
            set
            {
                if ((_Supplier != value))
                {
                    //this.OnSupplierChanging(value);
                    SendPropertyChanging();
                    _Supplier = value;
                    SendPropertyChanged("Supplier");
                    //this.OnSupplierChanged();
                }
            }
        }

        public string Code
        {
            get { return _Code; }
            set
            {
                if ((_Code != value))
                {
                    //this.OnCodeChanging(value);
                    SendPropertyChanging();
                    _Code = value;
                    SendPropertyChanged("Code");
                    //this.OnCodeChanged();
                }
            }
        }

        public DateTime Date
        {
            get { return _Date; }
            set
            {
                if ((_Date != value))
                {
                    //this.OnDateChanging(value);
                    SendPropertyChanging();
                    _Date = value;
                    SendPropertyChanged("Date");
                    //this.OnDateChanged();
                }
            }
        }

        public string Barcode
        {
            get { return _Barcode; }
            set
            {
                if ((_Barcode != value))
                {
                   // this.OnBarcodeChanging(value);
                    SendPropertyChanging();
                    _Barcode = value;
                    SendPropertyChanged("Barcode");
                    //this.OnBarcodeChanged();
                }
            }
        }

        public double Reserved
        {
            get { return _Reserved; }
            set
            {
                if ((_Reserved != value))
                {
                    //this.OnReservedChanging(value);
                    SendPropertyChanging();
                    _Reserved = value;
                    SendPropertyChanged("Reserved");
                    //this.OnReservedChanged();
                }
            }
        }

        public double FreeBalance
        {
            get { return _FreeBalance; }
            set
            {
                if ((_FreeBalance != value))
                {
                    //this.OnFreeBalanceChanging(value);
                    SendPropertyChanging();
                    _FreeBalance = value;
                    SendPropertyChanged("FreeBalance");
                    //this.OnFreeBalanceChanged();
                }
            }
        }

        public double MinOrder
        {
            get { return _MinOrder; }
            set
            {
                if ((_MinOrder != value))
                {
                    //this.OnMinOrderChanging(value);
                    SendPropertyChanging();
                    _MinOrder = value;
                    SendPropertyChanged("MinOrder");
                    //this.OnMinOrderChanged();
                }
            }
        }


        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region INotifyPropertyChanging Members

        public event PropertyChangingEventHandler PropertyChanging;

        #endregion

        protected virtual void SendPropertyChanging()
        {
            if ((PropertyChanging != null))
            {
                PropertyChanging(this, emptyChangingEventArgs);
            }
        }

        protected virtual void SendPropertyChanged(String propertyName)
        {
            if ((PropertyChanged != null))
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        private double _factQuantity;
        private string _status;

        public double FactQuantity
        {
            get { return _factQuantity; }
            set
            {
                if (_factQuantity != value)
                {
                    SendPropertyChanging();
                    _factQuantity = value;
                    SendPropertyChanged("FactQuantity");
                }
            }
        }

        public string Status
        {
            get { return _status; }
            set
            {
                if (_status != value)
                {
                    SendPropertyChanging();
                    _status = value;
                    SendPropertyChanged("FactQuantity");
                }
            }
        }

        public event ChangePreReqQuantity ChangePreReqQuantity;
        public event PreAutoOrdered OnPreAutoOrdeer;

        protected virtual void SendChangePreReqQuantity()
        {
            if ((ChangePreReqQuantity != null))
            {
                ChangePreReqQuantity(this, new EventChangePreReqQuantity() { GoodsObj = this });
            }
        }

        protected virtual void SendOnPreAutoOrder()
        {
            if ((OnPreAutoOrdeer != null))
            {
                OnPreAutoOrdeer(this, new EventChangePreReqQuantity() { GoodsObj = this });
            }
        }

        public PreGoodsBalanceObj()
        {
            FactQuantity = 0;
            Status = string.Empty;
            _reqAssort = false;
            IsLoaded = false;
            _lastOrderDate = DateTime.MinValue;
        }
    }
}
