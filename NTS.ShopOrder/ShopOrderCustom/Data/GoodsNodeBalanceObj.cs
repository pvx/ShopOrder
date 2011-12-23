using DataBase.DataObject;

namespace ShopOrderCustom.Data
{
    /// <summary>
    /// Класс товарной позиции 
    /// </summary>
    public class GoodsNodeBalanceObj : GoodsNodeObjBase
    {
        private string _barcode;
        private string _code;
        private string _measure;
        private double _minOrder;
        private decimal _price;
        private double _quantityInPack;
        private string _supplier;
        private bool _selfImport;
        private short _idAutoOrderMode;

        public bool SelfImport
        {
            get
            {
                return _selfImport;
            }
            set
            {
                if (_selfImport != value)
                {
                    SendPropertyChanging();
                    _selfImport = value;
                    SendPropertyChanged("SelfImport");
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
                    SendPropertyChanging();
                    _price = value;
                    SendPropertyChanged("Price");
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
                    SendPropertyChanging();
                    _quantityInPack = value;
                    SendPropertyChanged("QuantityInPack");
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
                    SendPropertyChanging();
                    _measure = value;
                    SendPropertyChanged("Measure");
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
                    SendPropertyChanging();
                    _supplier = value;
                    SendPropertyChanged("Supplier");
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
                    SendPropertyChanging();
                    _code = value;
                    SendPropertyChanged("Code");
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

        public double MinOrder
        {
            get { return _minOrder; }
            set
            {
                if ((_minOrder != value))
                {
                    SendPropertyChanging();
                    _minOrder = value;
                    SendPropertyChanged("MinOrder");
                }
            }
        }

        public short AutoOrderModeId
        {
            get { return _idAutoOrderMode; }
            set
            {
                if (_idAutoOrderMode != value)
                {
                    SendPropertyChanging();
                    _idAutoOrderMode = value;
                    SendPropertyChanged("AutoOrderModeId");
                }
            }
        }
    }
}