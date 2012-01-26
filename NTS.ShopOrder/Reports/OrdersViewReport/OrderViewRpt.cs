using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.Parameters;
using DevExpress.XtraReports.UI;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using OrdersViewReport.Data;
using ReportCore;


namespace OrdersViewReport
{
    public partial class OrderViewRpt : DevExpress.XtraReports.UI.XtraReport
    {
        public OrderViewRpt()
        {
            InitializeComponent();
        }

        private SqlConnection _reportDataDataContext;
        public SqlConnection ReportDataConnection
        {
            get
            {
                if(_reportDataDataContext == null)
                    throw new Exception("ReportDataConnection is null");

                return _reportDataDataContext;
            }
            set { _reportDataDataContext = value; }
        }

        private void OrderViewRptParametersRequestBeforeShow(object sender, ParametersRequestEventArgs e)
        {
            foreach (ParameterInfo info in e.ParametersInformation)
            {
                if (info.Parameter.Name == "prGroup")
                {             
                    var lookUpEdit = new LookUpEdit();
                    var ds  = new CatDs();
                    ds.Load(ReportDataConnection);
                    lookUpEdit.Properties.DataSource = ds;
                    lookUpEdit.Properties.DisplayMember = "CategoryName";
                    lookUpEdit.Properties.ValueMember = "CategoryName";
                    lookUpEdit.Properties.Columns.Add(new LookUpColumnInfo("CategoryName", 200, "Группа товара"));
                    info.Editor = lookUpEdit;
                }

                if (info.Parameter.Name == "prShop")
                {
                    var lookUpEdit = new LookUpEdit(){Width = 300};
                    var ds = new ShopDs();
                    ds.Load(ReportDataConnection);
                    lookUpEdit.Properties.DataSource = ds;
                    lookUpEdit.Properties.DisplayMember = "ShopName";
                    lookUpEdit.Properties.ValueMember = "ShopCode";
                    lookUpEdit.Properties.Columns.Add(new LookUpColumnInfo("ShopCode", 50, "Код магазина"));
                    lookUpEdit.Properties.Columns.Add(new LookUpColumnInfo("ShopName", 100, "Название магазина"));
                    lookUpEdit.Properties.Columns.Add(new LookUpColumnInfo("ShopAddress", 150, "Адрес магазина"));
                    info.Editor = lookUpEdit;
                }

                if (info.Parameter.Name == "prSupplier")
                {
                    var lookUpEdit = new LookUpEdit();
                    var ds = new SupplierDs();
                    ds.Load(ReportDataConnection);
                    lookUpEdit.Properties.DataSource = ds;
                    lookUpEdit.Properties.DisplayMember = "SupplierName";
                    lookUpEdit.Properties.ValueMember = "SupplierName";
                    lookUpEdit.Properties.Columns.Add(new LookUpColumnInfo("SupplierName", 200, "Поставщик"));
                    info.Editor = lookUpEdit;
                }
            }
        }

        private void OrderViewRptParametersRequestValueChanged(object sender, ParametersRequestValueChangedEventArgs e)
        {

        }

        private void OrderViewRptParametersRequestSubmit(object sender, ParametersRequestEventArgs e)
        {
            if (DataSource is IOrderReportDataSource)
            {
                var ds = (IOrderReportDataSource) DataSource;
                foreach (ParameterInfo info in e.ParametersInformation)
                {
                    if (info.Parameter.Name == "prDataBegin")
                        ds.DateBegin = (DateTime)info.Parameter.Value;

                    if (info.Parameter.Name == "prDataEnd")
                        ds.DateEnd = (DateTime)info.Parameter.Value;

                    if (info.Parameter.Name == "prShop")
                        ds.ShopCode = (string)info.Parameter.Value;

                    if (info.Parameter.Name == "prGroup")
                        ds.Group = (string)info.Parameter.Value;

                    if (info.Parameter.Name == "prSupplier")
                        ds.Supplier = (string)info.Parameter.Value;

                    if (info.Parameter.Name == "prBarcode")
                        ds.Barcode = (string)info.Parameter.Value;
                }
                ds.Load(ReportDataConnection);
            }
        }
    }
}