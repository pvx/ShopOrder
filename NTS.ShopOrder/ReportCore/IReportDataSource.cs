using System.Data.SqlClient;

namespace ReportCore
{
    public interface IReportDataSource
    {
        void Load(SqlConnection connection);
    }
}