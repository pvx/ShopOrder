using DevExpress.XtraReports.UI;

namespace ReportCore
{
    public interface IReport
    {
        XtraReport GetReport(IReportCallParameter parameter);
    }
}