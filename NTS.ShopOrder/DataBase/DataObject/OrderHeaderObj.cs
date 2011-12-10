using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace DataBase.DataObject
{
    /// <summary>
    /// Класс записи сведений о заказе магазина
    /// </summary>
    public partial class OrderHeaderObj : INotifyPropertyChanging, INotifyPropertyChanged
    {
        private static readonly PropertyChangingEventArgs emptyChangingEventArgs =
            new PropertyChangingEventArgs(String.Empty);

        private DateTime _createDate;
        private string _name;
        private DateTime _procesDate;
        private Guid _idOrderHeader;
        private int _idOrderState;
        private Guid _idShop;
        private Guid _idUser;
        private bool _checked;
        private bool _locked;
        private string _lockUser;

        private Dictionary<int, string> _orderStateDict = new Dictionary<int, string>();
        private DateTime _commiteDate;


        public override string ToString()
        {
            DateTime dt;
            switch (_idOrderState)
            {
                case 1:
                    dt = _createDate; break;
                case 2:
                    dt = _commiteDate; break;
                case 3:
                    dt = _procesDate; break;
                default:
                    dt = _createDate; break;
            }

            return string.Format("{0:MM.dd HH:mm:ss} [{1}]", dt, StateName); 
        }

        public string LockUser
        {
            get { return _lockUser; }
            set
            {
                if ((_lockUser != value))
                {
                    SendPropertyChanging();
                    _lockUser = value;
                    SendPropertyChanged("LockUser");
                }
            }
        }

        public bool Locked
        {
            get { return _locked; }
            set
            {
                if (_locked != value)
                {
                    SendPropertyChanging();
                    _locked = value;
                    SendPropertyChanged("Locked");
                }
            }
        }

        public bool Checked
        {
            get { return _checked; }
            set
            {
                if (_checked != value)
                {
                    SendPropertyChanging();
                    _checked = value;
                    SendPropertyChanged("Checked");
                }
            }
        }

        public Dictionary<int, string> OrderStateDict
        {
            get { return _orderStateDict; }
        }

        public Guid IdOrderHeader
        {
            get { return _idOrderHeader; }
            set
            {
                if ((_idOrderHeader != value))
                {
                    SendPropertyChanging();
                    _idOrderHeader = value;
                    SendPropertyChanged("IdOrderHeader");
                }
            }
        }

        public Guid IdUser
        {
            get { return _idUser; }
            set
            {
                if ((_idUser != value))
                {
                    SendPropertyChanging();
                    _idUser = value;
                    SendPropertyChanged("IdUser");
                }
            }
        }


        public int IdOrderState
        {
            get { return _idOrderState; }
            set
            {
                if ((_idOrderState != value))
                {
                    SendPropertyChanging();
                    _idOrderState = value;
                    SendPropertyChanged("IdOrderState");
                    SetOrderShateName(_idOrderState);
                }
                else
                {
                    SetOrderShateName(_idOrderState);}
            }
        }

        private void SetOrderShateName(int idOrderState)
        {
            if (_orderStateDict.Count > 0)
            {
                _name = _orderStateDict[idOrderState];
                SendPropertyChanged("StateName");
            }
        }

        public DateTime CreateDate
        {
            get { return _createDate; }
            set
            {
                if ((_createDate != value))
                {
                    SendPropertyChanging();
                    _createDate = value;
                    SendPropertyChanged("CreateDate");
                }
            }
        }

        public DateTime CommitDate
        {
            get { return _commiteDate; }
            set
            {
                if ((_commiteDate != value))
                {
                    SendPropertyChanging();
                    _commiteDate = value;
                    SendPropertyChanged("CommitDate");
                }
            }
        }

        public DateTime ProcesDate
        {
            get { return _procesDate; }
            set
            {
                if ((_procesDate != value))
                {
                    SendPropertyChanging();
                    _procesDate = value;
                    SendPropertyChanged("ProcesDate");
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
                    SendPropertyChanging();
                    _name = value;
                    SendPropertyChanged("Name");
                }
            }
        }

        public Guid IdShop
        {
            get { return _idShop; }
            set
            {
                if ((_idShop != value))
                {
                    SendPropertyChanging();
                    _idShop = value;
                    SendPropertyChanged("id_Shop");
                }
            }
        }

        public string StateName
        {
            get { return _name; }
        }

        #region INotifyPropertyChanged Memberspublic event PropertyChangedEventHandler PropertyChanged;

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

        public event PropertyChangedEventHandler PropertyChanged;
    }
}