using System;
using System.ComponentModel;

namespace DataBase.DataObject
{
    [Obsolete]
    public class GoodsObject : BaseDataObject, INotifyPropertyChanging, INotifyPropertyChanged
    {
        private static readonly PropertyChangingEventArgs emptyChangingEventArgs =
            new PropertyChangingEventArgs(String.Empty);

        private double _requeryQuantity;

        public string Group { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public double QuantityInPack { get; set; }

        public string Measure { get; set; }

        public double Quantity { get; set; }

        public string Supplier { get; set; }

        public string Code { get; set; }

        public DateTime Date { get; set; }

        public string Barcode { get; set; }

        public double Reserved { get; set; }

        public double FreeBalance { get; set; }

        public double MinOrder { get; set; }

        public double RequeryQuantity
        {
            get { return _requeryQuantity; }
            set
            {
                if ((_requeryQuantity != value))
                {
                    OnRequeryQuantityChanging(value);
                    SendPropertyChanging();
                    _requeryQuantity = value;
                    SendPropertyChanged("RequeryQuantity");
                    OnRequeryQuantityChanged();
                }
            }
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region INotifyPropertyChanging Members

        public event PropertyChangingEventHandler PropertyChanging;

        #endregion

        private void OnRequeryQuantityChanging(double value)
        {
        }

        private void OnRequeryQuantityChanged()
        {
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