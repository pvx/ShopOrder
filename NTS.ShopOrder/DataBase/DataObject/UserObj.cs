using System;
using System.ComponentModel;

namespace DataBase.DataObject
{
    /// <summary>
    /// Класс данные пользователя
    /// </summary>
    public class UserObj:  INotifyPropertyChanging, INotifyPropertyChanged
    {
        private static readonly PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
        private string _userLogin;
        public string UserLogin
        {
            get { return _userLogin; }
            set
            {
                if (_userLogin != value)
                {
                    SendPropertyChanging();
                    _userLogin = value;
                    SendPropertyChanged("UserLogin");
                }
            }
        }

        private string _userPassword;
        public string UserPassword
        {
            get { return _userPassword; }
            set
            {
                if (_userPassword != value)
                {
                    SendPropertyChanging();
                    _userPassword = value;
                    SendPropertyChanged("UserPassword");
                } 
            }
        }

        private string _userName;
        public string UserName
        {
            get { return _userName; }
            set
            {
                if (_userName != value)
                {
                    SendPropertyChanging();
                    _userName = value;
                    SendPropertyChanged("UserName");
                } 
            }
        }

        public Guid IdUser { get; set; }
        public Guid IdShop { get; set; }
        public Guid IdUserType { get; set; }

        private bool _active;
        public bool Active
        {
            get { return _active; }
            set
            {
                if (_active != value)
                {
                    SendPropertyChanging();
                    _active = value;
                    SendPropertyChanged("Active");
                }   
            }
        }

        private int _permissions;
        public int Permissions
        {
            get { return _permissions; }
            set
            {
                if (_permissions != value)
                {
                    SendPropertyChanging();
                    _permissions = value;
                    SendPropertyChanged("Permissions");
                }
            }
        }

        public int DefaultPermissions { get; set;}

        public bool IsChanged { get; set; }

        public override string ToString()
        {
            return string.IsNullOrEmpty(UserName) ? UserLogin : string.Format("{0} - {1}", UserLogin, UserName);
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

        public event PropertyChangingEventHandler PropertyChanging;
        public event PropertyChangedEventHandler PropertyChanged;
    }
}