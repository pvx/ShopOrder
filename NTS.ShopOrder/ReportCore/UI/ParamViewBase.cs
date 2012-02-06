using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace ReportCore.UI
{
    public partial class ParamViewBase : XtraForm
    {
        public ParamViewBase()
        {
            InitializeComponent();
        }

        public ParamViewBase(ParamUIBase viewControl)
        {
            InitializeComponent();
            viewControl.Dock = DockStyle.Fill;
            paramsHolder.Controls.Add(viewControl);
            btExecute.Click += delegate { viewControl.ExecuteReport(); };
            btClear.Click += delegate { viewControl.ResetParamsReport(); };
        }

        private void btClear_Click(object sender, EventArgs e)
        {

        }
    }
}