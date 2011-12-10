using System.Data.SqlClient;
using Microsoft.Practices.Unity;

namespace Common
{
    /// <summary>
    /// Класс соединения с БД
    /// </summary>
    public class OrderConnection : IOrderConnection
    {
        #region Local Variables
        
        readonly string _server;
        readonly string _dataBase;
        readonly string _userName;
        readonly string _userPassword;
        private const string Constr = @"Data Source={0};Initial Catalog={1};User ID={2};Password={3}";

        private readonly SqlConnection _sqlConnection;

        #endregion

        public string Server
        {
            get{ return _server;}
        }

        public string DataBase
        {
            get { return _dataBase; }
        }

        public string UserName
        {
            get { return _userName; }
        }

        public string UserPassword
        {
            get { return _userPassword; }
        }

        //public OrderConnection(string server, string dataBase, string userName, string userPassword)

        [InjectionConstructor]
        public OrderConnection(IOrderUserInfo userInfo)
        {
            _server = userInfo.Server;
            _userPassword = userInfo.UserPassword;
            _userName = userInfo.UserName;
            _dataBase = userInfo.DataBase;
            _sqlConnection = new SqlConnection(GetConnectionStringProperty());
        }

        private string GetConnectionStringProperty()
        {
            return string.Format(Constr, _server, _dataBase, _userName, _userPassword);
        }

        public SqlConnection GetSqlConnection()
        {
            return _sqlConnection;
        }
    }
}