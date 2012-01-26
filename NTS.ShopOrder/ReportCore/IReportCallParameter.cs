using System.Data.SqlClient;

namespace ReportCore
{
    public interface IReportCallParameter
    {
        SqlConnection Connection { get; set; }
    }
}