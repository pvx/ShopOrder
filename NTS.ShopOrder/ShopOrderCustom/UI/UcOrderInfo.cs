using System.Collections.Generic;
using System.ComponentModel;
using Common;
using DevExpress.Utils.Design;

namespace ShopOrderCustom.UI
{
    public partial class UcOrderInfo : DevExpress.XtraEditors.XtraUserControl
    {
        private readonly IDictionary<string, object> _data;

        public UcOrderInfo(IDictionary<string, object> data)
        {
            _data = data;
            InitializeComponent();
            InitGrid();

        }

        private void InitGrid()
        {
            if(_data != null)
            {
                propertyGrid.SelectedObject = new DictionaryPropertyGridAdapter(_data);
            }
        }

        private void UcOrderInfo_PreviewKeyDown(object sender, System.Windows.Forms.PreviewKeyDownEventArgs e)
        {

        }
    }
}
