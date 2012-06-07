using DataBase.DataObject;

namespace ShopOrderCustom.Data
{
    public class GoodsDistributionObj : GoodsNodeObjBase
    {
        private string _barcode;
        private string _code;
        private string _measure;
        private decimal _price;
        private string _supplier;


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

        private double _norm;
        public double Norm
        {
            get { return _norm; }
            set
            {
                SendPropertyChanging();
                _norm = value;
                SendPropertyChanged("Norm");
            }
        }
    }
}