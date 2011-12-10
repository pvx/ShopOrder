using System.Data.SqlClient;

namespace Common
{
    /// <summary>
    /// Интерфейс соединения с БД
    /// </summary>
    public interface IOrderConnection
    {
        string Server { get; }
        string DataBase { get; }
        string UserName { get; }
        string UserPassword { get; }
        SqlConnection GetSqlConnection();
    }
}