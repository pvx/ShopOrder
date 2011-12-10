using System.Windows.Forms;
using DevExpress.XtraEditors;
using ShopOrderCustom.Models;

namespace ShopOrderCustom.UI
{
    public partial class BalanceEditorForm : XtraForm
    {
        private BalanceEditorModel Model { get; set; }

        public BalanceEditorForm(BalanceEditorModel model)
        {
            Model = model;
            InitializeComponent();
            Model.LoadUserViewLayout(gridView);
            Model.EditRepo.OnChangeDenied += EditRepo_OnChangeDenied;
            LoadData();
        }

        void EditRepo_OnChangeDenied(object sender, double quantity, double minQuantity)
        {
            XtraMessageBox.Show(string.Format("Остаток на складе можно уменьшить на {0} шт.", minQuantity), 
                "Редактирование остатков", MessageBoxButtons.OK);
        }

        void LoadData()
        {
            grid.DataSource = Model.GetData();
        }

        void RefreshData()
        {
            grid.DataSource = Model.RefreshData(EditRepo_OnChangeDenied);
        }

        private void BalanceEditorFormFormClosed(object sender, FormClosedEventArgs e)
        {
            Model.SaveUserViewLayout(gridView);
        }

        private void BarButtonItem1ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            RefreshData();
        }
    }
}