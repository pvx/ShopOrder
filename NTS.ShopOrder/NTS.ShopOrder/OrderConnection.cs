using System.Data.SqlClient;

namespace NTS.ShopOrder
{
    public class OrderConnection
    {
        #region Local Variables
        
        readonly string _server;
        readonly string _dataBase;
        readonly string _userName;
        readonly string _userPassword;
        private const string Constr = @"Data Source={0};Initial Catalog={1};User ID={2};Password={3}";

        private readonly SqlConnection _sqlConnection;

        #endregion 

        string Server
        {
            get{ return _server;}
        }

        string DataBase
        {
            get { return _dataBase; }
        }

        string UserName
        {
            get { return _userName; }
        }

        string UserPassword
        {
            get { return _userPassword; }
        }

        public OrderConnection(string server, string dataBase, string userName, string userPassword)
        {
            _server = server;
            _userPassword = userPassword;
            _userName = userName;
            _dataBase = dataBase;
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