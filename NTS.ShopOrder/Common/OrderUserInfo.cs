using System;
using System.Collections.Generic;
using Common.Enum;

namespace Common
{
    /// <summary>
    /// Класс описания пользователя системы
    /// </summary>
    public class OrderUserInfo : IOrderUserInfo
    {
        private string _server;
        private string _dataBase;
        private string _userName;
        private string _userPassword;
        private Dictionary<string, string> _property;

        public int Permission
        {
            get { return GetPermission(); }
        }

        /// <exception cref="ArgumentNullException">Argument is null.</exception>
        private int GetPermission()
        {
            if(Equals(_property, null))
                throw new ArgumentNullException("GetPermission", "Не определены свойства пользователя");
            
            return int.Parse(_property["USER_PERMISSION"]);
        }
        /*
        static Permission DecodePermission(int prm)
        {
            switch (prm)
            {
                case 1:
                    return Permission.PrmMinorder;
                case 2:
                    return Permission.PrmCreater;
                case 4:
                    return Permission.PrmManager;
                case 8:
                    return Permission.PrmFull;
                default:
                    return Permission.PrmCreater;
            }
        }
        */
        public OrderUserInfo( string server, string dataBase, string userName, string userPassword )
        {
            _server = server;
            _dataBase = dataBase;
            _userName = userName;
            _userPassword = userPassword;
        }

        public string Server
        {
            get { return _server; }
            set { _server = value; }
        }

        public string DataBase
        {
            get { return _dataBase; }
            set { _dataBase = value; }
        }

        public string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }

        public string UserPassword
        {
            get { return _userPassword; }
            set { _userPassword = value; }
        }

        public string Info
        {
            get { return string.Format("Сервер: {0} БД: {1}", _server, _dataBase);}
        }

        public Dictionary<string, string> Property
        {
            get { return _property; }
            set
            {
                if(_property == null)
                    _property = value;
            }
        }
    }
}