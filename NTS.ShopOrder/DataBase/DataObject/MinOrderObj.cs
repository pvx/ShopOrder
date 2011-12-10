using System;
using System.ComponentModel;

namespace DataBase.DataObject
{
    public delegate void ChangeMinOrder(object sender, EventChangeMinOrder e);

    /// <summary>
    /// Класс записи минимального заказа товара
    /// </summary>
    public class MinOrderObj : INotifyPropertyChanging, INotifyPropertyChanged
    {
        private static readonly PropertyChangingEventArgs EmptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private string _barcode;
        private string _code;
        private string _group;
        private string _measure;
        private double _minOrder;
        private string _name;
        private decimal _price;
        private double _quantityInPack;
        private string _supplier;
        private bool _active;

        static void BeforeMinOrderChange(ref double reqQuantity)
        {
            
        }

        static void AfterMinOrderChange(double reqQuantity)
        {

        }

        public double MinOrder
        {
            get { return _minOrder; }
            set
            {
                if ((_minOrder != value))
                {
                    BeforeMinOrderChange(ref value);
                    SendPropertyChanging();
                    _minOrder = value;
                    SendPropertyChanged("MinOrder");
                    AfterMinOrderChange(value);
                    SendChangeMinOrder();
                }
            }
        }

        public bool Active
        {
            get { return _active; }
            set
            {
                if ((_active != value))
                {
                    //this.OnGroupChanging(value);
                    SendPropertyChanging();
                    _active = value;
                    SendPropertyChanged("Active");
                    //this.OnGroupChanged();
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
                    SendPropertyChanging();
                    _barcode = value;
                    SendPropertyChanged("Barcode");
                }
            }
        }

        private decimal _sapMinOrder;
        public decimal SAPMinOrder
        {
            get { return _sapMinOrder; }
            set
            {
                if ((_sapMinOrder != value))
                {
                    SendPropertyChanging();
                    _sapMinOrder = value;
                    SendPropertyChanged("SAPMinOrder");
                }            
            }
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region INotifyPropertyChanging Members

        public event PropertyChangingEventHandler PropertyChanging;

        #endregion

        public event ChangeMinOrder ChangeMinOrder;

        protected virtual void SendChangeMinOrder()
        {
            if ((ChangeMinOrder != null))
            {
                ChangeMinOrder(this, new EventChangeMinOrder { MinOrdObj = this });
            }
        }

        protected virtual void SendPropertyChanging()
        {
            if ((PropertyChanging != null))
            {
                PropertyChanging(this, EmptyChangingEventArgs);
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