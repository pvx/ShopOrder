using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraReports.UI;
using OrdersViewReport.Data;
using ReportCore;
using ReportCore.UI;

namespace OrdersViewReport.UI
{
    public partial class ParamUI : ParamUIBase
    {
        public ParamUI(IReportCallParameter parameter)
        {
            Parameter = parameter;
            InitializeComponent();
            InitData();
        }

        private void InitData()
        {
            dateBeg.EditValue = DateTime.Now.Date;
            dateEnd.EditValue = DateTime.Now.Date;

            var dss = new ShopDs();
            dss.Load(Parameter.Connection);
            cbShop.Properties.DataSource = dss;
            cbShop.Properties.DisplayMember = "ShopName";
            cbShop.Properties.ValueMember = "ShopCode";

            var dsp = new SupplierDs();
            dsp.Load(Parameter.Connection);cbSupplier.Properties.DataSource = dsp;
            cbSupplier.Properties.DisplayMember = "SupplierName";
            cbSupplier.Properties.ValueMember = "SupplierName";


            var dsg = new CatDs();
            dsg.Load(Parameter.Connection);
            cbGroup.Properties.DataSource = dsg;
            cbGroup.Properties.DisplayMember = "CategoryName";
            cbGroup.Properties.ValueMember = "CategoryName"; 
        }

        public override void ExecuteReport()
        {
            base.ExecuteReport();

            var sh = cbShop.Properties.Items.GetCheckedValues();
            var tbShop = new DataTable();
            tbShop.Columns.Add("Id", typeof(string));
            sh.ForEach(x => tbShop.Rows.Add(x));

            var sp = cbSupplier.Properties.Items.GetCheckedValues();
            var tbSuppl = new DataTable();
            tbSuppl.Columns.Add("Id", typeof(string));
            sp.ForEach(x => tbSuppl.Rows.Add(x));

            var sg = cbGroup.Properties.Items.GetCheckedValues();
            var tbGp = new DataTable();
            tbGp.Columns.Add("Id", typeof(string));
            sg.ForEach(x => tbGp.Rows.Add(x));


            string suppl = string.Join(", ", sp);
            string group = string.Join(", ", sg);

            try
            {
                Parameter.Connection.Open();
                using (
                    var command = new SqlCommand("rep_sel_OrederByShop", Parameter.Connection)
                                      {CommandType = CommandType.StoredProcedure, CommandTimeout = 60000})
                {
                    command.Parameters.AddWithValue("@dateBeg", dateBeg.DateTime.Date);
                    command.Parameters.AddWithValue("@dateEnd", dateEnd.DateTime.Date);
                    command.Parameters.AddWithValue("@ShopCodes", tbShop);

                    command.Parameters.AddWithValue("@Suppliers", tbSuppl);
                    command.Parameters.AddWithValue("@GoodGroups", tbGp);

                    var rep = new XtraReport1() {DataAdapter = new SqlDataAdapter(command)};
                    rep.Parameters["pDate"].Value = string.Format("Период: {0} по {1}", dateBeg.DateTime.Date.ToShortDateString(), dateEnd.DateTime.Date.ToShortDateString());

                    rep.Parameters["pGroup"].Value = string.Format("Товарная группа: {0}", string.IsNullOrEmpty(group) ? "Все" : group);
                    rep.Parameters["pSuppl"].Value = string.Format("Поставщик: {0}", string.IsNullOrEmpty(suppl) ? "Все" : suppl);

                    var reportPrintTool = new ReportPrintTool(rep) {AutoShowParametersPanel = false};
                    reportPrintTool.ShowPreviewDialog();
                }
            }
            finally
            {
                Parameter.Connection.Close();
            }

            //MessageBox.Show("ExecuteReport " + table.Rows.Count.ToString());
        }

        public override void ResetParamsReport()
        {
            base.ResetParamsReport();
            dateBeg.DateTime = DateTime.Now.Date;
            dateEnd.DateTime = DateTime.Now.Date;

            foreach (CheckedListBoxItem item in cbGroup.Properties.Items.Cast<CheckedListBoxItem>().Where(item => item.CheckState == CheckState.Checked))
            {
                item.CheckState = CheckState.Unchecked;
            }

            foreach (CheckedListBoxItem item in cbShop.Properties.Items.Cast<CheckedListBoxItem>().Where(item => item.CheckState == CheckState.Checked))
            {
                item.CheckState = CheckState.Unchecked;
            }

            foreach (CheckedListBoxItem item in cbSupplier.Properties.Items.Cast<CheckedListBoxItem>().Where(item => item.CheckState == CheckState.Checked))
            {
                item.CheckState = CheckState.Unchecked;
            }
        }
    }
}
