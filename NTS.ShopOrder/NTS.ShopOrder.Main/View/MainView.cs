using System;
using System.Windows.Forms;
using Common;
using Microsoft.Practices.Unity;
using NTS.ShopOrder.Main.View.UserView;
using Supervisor;


namespace NTS.ShopOrder.Main.View
{
    public partial class MainView : Form
    {
        //private int childFormNumber = 0;

        //private IOrderUserInfo _orderUserInfo;

        [Dependency]
        public IUnityContainer UnityContainer { get; set;}

        public MainView(/*IOrderUserInfo orderUserInfo*/)
        {
            InitializeComponent();
            Text = Text + " " + Application.ProductVersion;
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            OrderView baseView = UnityContainer.Resolve<OrderView>();
            baseView.MdiParent = this;
            baseView.WindowState = FormWindowState.Maximized;
            baseView.Show();   
        }

        private void OpenFile(object sender, EventArgs e)
        {

        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void MainView_Load(object sender, EventArgs e)
        {
            Login();
        }

        private void Login()
        {
            using (LoginView loginView = UnityContainer.Resolve<LoginView>())
            {
                if (loginView.ShowDialog() != DialogResult.OK)
                    Close();
            }
        }

        private void tbSupervisor_Click(object sender, EventArgs e)
        {
            SupervisorModel model = UnityContainer.Resolve<SupervisorModel>();
            BaseView baseView = model.CreateForm();
            baseView.MdiParent = this;
            baseView.WindowState = FormWindowState.Maximized;
            baseView.Show();
        }
    }
}
