using System.Data.SqlClient;

namespace ReportCore
{
    internal class ReportCallParameter : IReportCallParameter
    {
        public SqlConnection Connection { get; set; }
    }
}