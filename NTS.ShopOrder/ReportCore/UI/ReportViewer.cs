using System;
using System.ComponentModel;
using System.Timers;
using System.Windows.Forms;
using DevExpress.XtraPrinting.Control;
using DevExpress.XtraReports.UI;


namespace ReportCore.UI
{
    public partial class ReportViewer : DevExpress.XtraEditors.XtraForm
    {
        
        public ReportViewer()
        {
            InitializeComponent();
        }

        private void DoWork()
        {
            printControl.PrintingSystem = _report.PrintingSystem;
            //_report.ParametersRequestSubmit += _report_ParametersRequestSubmit;
            
            _report.CreateDocument(true);
            printControl.UpdatePageView();


            //ReportPrintTool reportPrintTool = new ReportPrintTool(_report);
            //reportPrintTool.AutoShowParametersPanel = false;
            //reportPrintTool.ShowPreviewDialog();
        }

        private XtraReport _report;
        public XtraReport Report
        {
            get { return _report; }
            set {
                if (value != null)
                {
                    _report = value;
                    DoWork();
                }
            }

        }

        private void ReportViewerLoad(object sender, EventArgs e)
        {
            
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _report.ShowDesignerDialog();
        }
    }
}