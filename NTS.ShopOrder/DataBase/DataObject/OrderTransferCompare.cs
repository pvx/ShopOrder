using System;

namespace DataBase.DataObject
{
    /// <summary>
    /// Класс записи сравнения перенесенных остатков
    /// </summary>
    public class OrderTransferCompare : GoodsNodeObjBase
    {
        private string _barcode;
        private string _code;
        private DateTime _dateDest;
        private DateTime _dateSrc;
        private string _measure;
        private decimal _price;
        private double _quantityDest;
        private double _quantityInPack;
        private double _quantitySrc;
        private string _supplier;
        private string _group;
        private bool _isEqual;


        public bool IsEqual
        {
            get { return _isEqual; }
            set
            {
                if ((_isEqual != value))
                {
                    SendPropertyChanging();
                    _isEqual = value;
                    SendPropertyChanged("IsEqual");
                }
            }
        }

        public override string ToString()
        {
            return GetType().FullName;}

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

        public string Group
        {
            get { return _group; }
            set
            {
                if ((_group != value))
                {
                    SendPropertyChanging();
                    _group = value;
                    SendPropertyChanged("Group");
                }
            }
        }

        public DateTime DateDest
        {
            get { return _dateDest; }
            set
            {
                if ((_dateDest != value))
                {
                    SendPropertyChanging();
                    _dateDest = value;
                    SendPropertyChanged("DateDest");
                }
            }
        }

        public DateTime DateSrc
        {
            get { return _dateSrc; }
            set
            {
                if ((_dateSrc != value))
                {
                    SendPropertyChanging();
                    _dateSrc = value;
                    SendPropertyChanged("DateSrc");
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
        public double QuantityDest 
        {
            get { return _quantityDest; }
            set
            {
                if ((_quantityDest != value))
                {
                    SendPropertyChanging();
                    _quantityDest = value;
                    SendPropertyChanged("QuantityDest");
                }
            }
        }
        public double QuantitySrc 
        {
            get { return _quantitySrc; }
            set
            {
                if ((_quantitySrc != value))
                {
                    SendPropertyChanging();
                    _quantitySrc = value;
                    SendPropertyChanged("QuantitySrc");
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
    }
}