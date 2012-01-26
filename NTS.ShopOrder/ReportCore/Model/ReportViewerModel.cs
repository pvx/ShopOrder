using System.ComponentModel;
using DevExpress.XtraReports.UI;
using ReportCore.UI;

namespace ReportCore.Model
{
    public class ReportViewerModel
    {
        private readonly XtraReport _report;
        private readonly ReportViewer _reportViewer = new ReportViewer();

        public ReportViewerModel(XtraReport report)
        {
            _report = report;
        }

        public void ShowReport()
        {
            SetReport(_report);
            _reportViewer.ShowDialog();
        }

        private void SetReport(XtraReport report)
        {
            _reportViewer.Report = report;
        } 
    }
}