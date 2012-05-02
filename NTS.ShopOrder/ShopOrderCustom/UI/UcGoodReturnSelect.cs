using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DataBase.DataObject;
using DevExpress.XtraEditors;

namespace ShopOrderCustom.UI
{
    public partial class UcGoodReturnSelect : DevExpress.XtraEditors.XtraUserControl
    {
        public UcGoodReturnSelect(InvoiceData invoiceData)
        {
            InitializeComponent();
            cbGoods.Properties.DataSource = invoiceData;
        }

        private void btOk_Click(object sender, EventArgs e)
        {
            MessageBox.Show("r32r230");}
    }
}