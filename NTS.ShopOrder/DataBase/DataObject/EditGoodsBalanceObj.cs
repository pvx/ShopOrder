using System;
using System.ComponentModel;

namespace DataBase.DataObject
{
    public delegate void ChangeBalance(object sender, EventChangeBalance e);
    public delegate void ChangeQuota(object sender, EventChangeBalance e);

    public delegate void BeforeChangeBalance(object sender, ref bool allow, double quantity, EventChangeBalance e);

    /// <summary>
    /// Класс записи остатков товара
    /// </summary>
    public class EditGoodsBalanceObj : INotifyPropertyChanging, INotifyPropertyChanged
    {
        private static readonly PropertyChangingEventArgs emptyChangingEventArgs =
            new PropertyChangingEventArgs(String.Empty);

        private string _barcode;
        private string _code;
        private string _group;
        private string _measure;
        private string _name;
        private decimal _price;
        private double _quantity;
        private double _quantityInPack;
        private string _supplier;
        private Guid _id;
        private double _quota;
        private bool allow;
        private double _minQuantity;

        /// <summary>
        /// 
        /// </summary>
        public EditGoodsBalanceObj()
        {
            IsLoaded = false;
        }

        public bool IsLoaded { get; set; }

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
            get { return _group; }
            set
            {
                if ((_group != value))
                {
                    //this.OnGroupChanging(value);
                    SendPropertyChanging();
                    _group = value;
                    SendPropertyChanged("Group");
                    //this.OnGroupChanged();
                }
            }
        }

        public string Name
        {
            get { return _name; }
            set
            {
                if ((_name != value))
                {
                    //this.OnNameChanging(value);
                    SendPropertyChanging();
                    _name = value;
                    SendPropertyChanged("Name");
                    //this.OnNameChanged();
                }
            }
        }

        public decimal Price
        {
            get { return _price; }
            set
            {
                if ((_price != value))
                {
                    //this.OnPriceChanging(value);
                    SendPropertyChanging();
                    _price = value;
                    SendPropertyChanged("Price");
                    //this.OnPriceChanged();
                }
            }
        }

        public double QuantityInPack
        {
            get { return _quantityInPack; }
            set
            {
                if ((_quantityInPack != value))
                {
                    //this.OnQuantityInPackChanging(value);
                    SendPropertyChanging();
                    _quantityInPack = value;
                    SendPropertyChanged("QuantityInPack");
                    //this.OnQuantityInPackChanged();
                }
            }
        }

        public string Measure
        {
            get { return _measure; }
            set
            {
                if ((_measure != value))
                {
                    // this.OnMeasureChanging(value);
                    SendPropertyChanging();
                    _measure = value;
                    SendPropertyChanged("Measure");
                    //this.OnMeasureChanged();
                }
            }
        }

        public string Supplier
        {
            get { return _supplier; }
            set
            {
                if ((_supplier != value))
                {
                    //this.OnSupplierChanging(value);
                    SendPropertyChanging();
                    _supplier = value;
                    SendPropertyChanged("Supplier");
                    //this.OnSupplierChanged();
                }
            }
        }

        public string Code
        {
            get { return _code; }
            set
            {
                if ((_code != value))
                {
                    //this.OnCodeChanging(value);
                    SendPropertyChanging();
                    _code = value;
                    SendPropertyChanged("Code");
                    //this.OnCodeChanged();
                }
            }
        }

        public string Barcode
        {
            get { return _barcode; }
            set
            {
                if ((_barcode != value))
                {
                    // this.OnBarcodeChanging(value);
                    SendPropertyChanging();
                    _barcode = value;
                    SendPropertyChanged("Barcode");
                    //this.OnBarcodeChanged();
                }
            }
        }

        public double MinQuantity
        {
            get { return _minQuantity; }
            set
            {
                if ((_minQuantity != value))
                {
                    SendPropertyChanging();
                    _minQuantity = value;
                    SendPropertyChanged("MinQuantity");
                }
            }
        }

        public double Quantity
        {
            get { return _quantity; }
            set
            {
                if ((_quantity != value))
                {
                    if (IsLoaded)
                    {
                        BeforeQuantityChange(ref value);
                        OnBeforeChangeQuantity(ref allow, value);
                        if(allow)
                        {
                            try
                            {
                                SendPropertyChanging();
                                _quantity = value;
                                SendPropertyChanged("Quantity");
                                AfterQuantityChange(value);
                                OnChangeQuantity();
                            }
                            finally
                            {
                                allow = false;
                            }
                        }
                    }
                    else
                    {
                        SendPropertyChanging();
                        _quantity = value;
                        SendPropertyChanged("Quantity");
                    }
                }
            }
        }

        private void AfterQuantityChange(double value)
        {

        }

        private void BeforeQuantityChange(ref double value)
        {

        }

        public double Quota
        {
            get { return _quota; }
            set
            {
                if (_quota != value)
                {
                    if (IsLoaded)
                        BeforeQuotaChange(ref value);
                    SendPropertyChanging();
                    _quota = value;
                    SendPropertyChanged("Quota");

                    if (IsLoaded)
                    {
                        AfterQuotaChange(value);
                        OnChangeQuota();
                    }
                }
            }
        }

        private void BeforeQuotaChange(ref double value)
        {
            
        }

        private void AfterQuotaChange(double value)
        {
            }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region INotifyPropertyChanging Members

        public event PropertyChangingEventHandler PropertyChanging;

        #endregion


        public event ChangeBalance ChangeQuantity;
        public event ChangeQuota ChangeQuota;
        public event BeforeChangeBalance BeforeChangeBalance;

        protected virtual void OnBeforeChangeQuantity( ref bool allow, double quantity)
        {
            if ((BeforeChangeBalance != null))
            {
                BeforeChangeBalance(this, ref allow, quantity, new EventChangeBalance() { GoodsObj = this });
            }
        }

        protected virtual void OnChangeQuantity()
        {
            if ((ChangeQuantity != null))
            {
                ChangeQuantity(this, new EventChangeBalance() { GoodsObj = this });
            }
        }

        protected virtual void OnChangeQuota()
        {
            if ((ChangeQuota != null))
            {
                ChangeQuota(this, new EventChangeBalance() { GoodsObj = this });
            }
        }

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
    }
}