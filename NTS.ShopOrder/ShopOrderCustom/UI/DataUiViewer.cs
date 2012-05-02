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
            var ret1 = FindControlRecursive(viewControl, "btOk");
            if (ret1 != null)
                AcceptButton = (IButtonControl)ret1;

            var ret2 = FindControlRecursive(viewControl, "btCancel");
            if (ret2 != null)
                CancelButton = (IButtonControl)ret2;
        }

        private void DataUiViewer_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {

        }

        public Control FindControlRecursive(Control container, string name)
        {
            if (container.Name == name)
                return container;

            foreach (Control ctrl in container.Controls)
            {
                Control foundCtrl = FindControlRecursive(ctrl, name);
                if (foundCtrl != null)
                    return foundCtrl;
            }
            return null;
        }

        private void DataUiViewer_FormClosing(object sender, FormClosingEventArgs e)
        {
        }
    }
}