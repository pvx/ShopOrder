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

        private string _reportFolder;

        public string ReportFolder
        {
            get { return _reportFolder; }
            set { _reportFolder = value; }
        }

        /// <exception cref="ArgumentNullException">Argument is null.</exception>
        private int GetPermission()
        {
            if(Equals(_property, null))
                throw new ArgumentNullException("GetPermission", "Не определены свойства пользователя");
            
            return int.Parse(_property["USER_PERMISSION"]);
        }

        public OrderUserInfo( string server, string dataBase, string userName, string userPassword, string reportFolder )
        {
            _server = server;
            _dataBase = dataBase;
            _userName = userName;
            _userPassword = userPassword;
            _reportFolder = reportFolder;
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