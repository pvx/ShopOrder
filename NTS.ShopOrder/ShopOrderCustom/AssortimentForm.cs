using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace ShopOrderCustom
{
    public partial class AssortimentForm : DevExpress.XtraEditors.XtraForm
    {
        private AssortmentModel Model { get; set; }

        public AssortimentForm(AssortmentModel assortmentModel)
        {
            Model = assortmentModel;
            InitializeComponent();
        }
    }
}