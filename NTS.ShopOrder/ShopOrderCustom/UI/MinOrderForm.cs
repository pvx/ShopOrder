using System;
using System.Windows.Forms;
using DataBase.DataObject;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;

namespace ShopOrderCustom
{
    public partial class MinOrderForm : XtraForm
    {
        private MinOrderModel Model { get; set; }
        private ShopCategoryObj CategoryObj { get; set; }
        
        public MinOrderForm(MinOrderModel model)
        {
            Model = model;
            InitializeComponent();
            Model.LoadUserViewLayout(gridView);
            LoadData();
        }

        void LoadData()
        {
            foreach (ShopCategoryObj obj in Model.Categorys)
            {
                cbRepCategory.Items.Add(obj);
            }
        }

        private void RefreshData()
        {
            if (CategoryObj != null)
            {
                grid.DataSource = null;
                grid.DataSource = Model.GetMinOrderData(CategoryObj);
                if (grid.DataSource != null)
                {
                    btClear.Enabled = true;
                }
            }
        }

        private void CbCategoryEditValueChanged(object sender, EventArgs e)
        {
            CategoryObj = ((ShopCategoryObj) ((BarEditItem) (sender)).EditValue);
            RefreshData();
        }

        private void MinOrderFormFormClosed(object sender, FormClosedEventArgs e)
        {
            Model.SaveUserViewLayout(gridView);
        }

        private void BtRefreshItemClick(object sender, ItemClickEventArgs e)
        {
            RefreshData();
        }
    }
}