using System.Drawing;
using DevExpress.XtraGrid.Views.Grid;

namespace ShopOrderCustom.UI
{
    public partial class UcOrderCompare : DevExpress.XtraEditors.XtraUserControl
    {
        public UcOrderCompare()
        {
            InitializeComponent();
            ConditionsAdjustment();
        }

        private void ConditionsAdjustment() 
        {
            gridView.BestFitColumns();
        }

        private object _dataSource;

        public object DataSource
        {
            get
            {
                _dataSource = gridControl.DataSource;
                return _dataSource;
            }
            set
            {
                _dataSource = value;
                gridControl.DataSource = _dataSource;
            }
        }

        private void gridView_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            Color cl = Color.Empty;
            Color fl = Color.Empty;
            var currentView = sender as GridView;
            if (currentView != null)
            {
                if (e.RowHandle == currentView.FocusedRowHandle) return;
                if (e.RowHandle < 0) return;

                if ((e.Column.FieldName == "QuantitySrc") || (e.Column.FieldName == "QuantityDest"))
                {
                    double v1 = (double) currentView.GetRowCellValue(e.RowHandle, currentView.Columns["QuantitySrc"]);
                    double v2 = (double) currentView.GetRowCellValue(e.RowHandle, currentView.Columns["QuantityDest"]);

                    cl = v1 != v2 ? Color.Red : Color.Empty;
                    fl = v1 != v2 ? Color.White : Color.Empty;
                    e.Appearance.BackColor = cl;
                    e.Appearance.ForeColor = fl;
                }
            }
        }
    }
}