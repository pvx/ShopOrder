using System;
using DevExpress.XtraEditors;

namespace ReportCore.UI
{
    public partial class ParamUIBase : XtraUserControl
    {
        protected IReportCallParameter Parameter;

        public ParamUIBase()
        {
            InitializeComponent();
        }
        
        public delegate void ButtonClick(object sender, EventArgs e);

        public event ButtonClick OnExecuteReport;
        public event ButtonClick OnResetParams;
        

        public virtual void ExecuteReport() {}
        public virtual void ResetParamsReport() {}
    }
}
