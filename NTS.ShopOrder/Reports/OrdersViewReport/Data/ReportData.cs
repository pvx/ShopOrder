using System.Data;
using System.Data.SqlClient;


namespace OrdersViewReport.Data
{
    public static class ReportData
    {
        public static ReportDataDataContext GetContext(SqlConnection connection)
        {
            return new ReportDataDataContext(connection);
        }
    }
}