using System;
using System.ComponentModel;

namespace DataBase.DataObject
{
    public class NotifyDataObjectBase : INotifyPropertyChanging, INotifyPropertyChanged
    {
        public event PropertyChangingEventHandler PropertyChanging;
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void SendPropertyChanged(String propertyName)
        {
            if ((PropertyChanged != null))
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        protected virtual void SendPropertyChanging(String propertyName)
        {
            if ((PropertyChanging != null))
            {
                PropertyChanging(this, new PropertyChangingEventArgs(propertyName));
            }
        }
    }
}