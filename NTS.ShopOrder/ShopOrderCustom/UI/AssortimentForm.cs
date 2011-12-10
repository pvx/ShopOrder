using System;
using System.Windows.Forms;
using DataBase.DataObject;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using ShopOrderCustom.Models;

namespace ShopOrderCustom.UI
{
    public partial class AssortimentForm : XtraForm
    {
        private AssortmentModel Model { get; set; }

        public AssortimentForm(AssortmentModel assortmentModel)
        {
            Model = assortmentModel;
            InitializeComponent();
            Model.LoadUserViewLayout(gridView);
            LoadData();
        }

        void LoadData()
        {
            foreach ( ShopCategoryObj obj in Model.Categorys)
            {
               cbRepCategory.Items.Add(obj); 
            }
        }

        private void CbCategoryEditValueChanged(object sender, EventArgs e)
        {
            var obj = ((ShopCategoryObj) ((BarEditItem) (sender)).EditValue);
            grid.DataSource = Model.GetReqAssortData(obj);
            if(grid.DataSource != null)
            {
                btClear.Enabled = true;
                btImport.Enabled = true;
            }
        }

        private void BarButtonItem1ItemClick(object sender, ItemClickEventArgs e)
        {
            gridView.CloseEditor();
            Model.Save();
        }

        private void BarButtonItem2ItemClick(object sender, ItemClickEventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    int rec = Model.LoadFromExcel(openFileDialog.FileName);
                    XtraMessageBox.Show(string.Format("Загруженно {0} записей.", rec));
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message);
                }
            }
        }

        private void BarButtonItem3ItemClick(object sender, ItemClickEventArgs e)
        {
            if(XtraMessageBox.Show("Очистить отмеченные позиции?","Очистка", MessageBoxButtons.YesNo) == DialogResult.Yes)
                Model.ClearCheck();
        }

        private void AssortimentForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Model.SaveUserViewLayout(gridView);
        }
    }
}