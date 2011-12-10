using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace ShopOrderCustom.UI
{
    public partial class DataUiViewer : XtraForm
    {
        public DataUiViewer(XtraUserControl viewControl)
        {
            InitializeComponent();
            viewControl.Dock = DockStyle.Fill;
            Controls.Add(viewControl);     
            
        }

        private void DataUiViewer_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {

        }
    }
}