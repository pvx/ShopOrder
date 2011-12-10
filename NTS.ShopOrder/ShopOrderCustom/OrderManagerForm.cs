using System.Threading;
using System.Windows.Forms;
using DataBase.DataObject;
using DevExpress.XtraEditors;
using DevExpress.XtraTreeList.Nodes;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Smo.Agent;

namespace ShopOrderCustom
{
    public partial class OrderManagerForm : XtraForm
    {
        private OrderManagerModel Model { get; set; }

        public OrderManagerForm(OrderManagerModel model)
        {
            Model = model;
            InitializeComponent();
            DataBinding();
        }

        void DataBinding()
        {
            treeList.ExpandAll();
            treeList.DataSource = Model.GetOrdersHeader();
            treeList.BestFitColumns();
        }

        private void treeList_AfterFocusNode(object sender, DevExpress.XtraTreeList.NodeEventArgs e)
        {
            if (e.Node != null)
            {              
                if (e.Node.Level == 1)
                {
                    Model.CurrentOrderHeader = (OrderHeaderObj)e.Node.GetValue(0);
                    grid.DataSource = Model.GetOrderList();                   
                }
                else
                {
                    grid.DataSource = null;
                }
                
            }
        }

        private void SetCheckedChildNodes(TreeListNode node, CheckState check)
        {
            if (node.GetValue(0) != null)
                if (Equals(node.GetValue(0).GetType(), typeof(OrderHeaderObj)))
                {
                    ((OrderHeaderObj)node.GetValue(0)).Checked = check == CheckState.Checked;
                }

            for (int i = 0; i < node.Nodes.Count; i++)
            {
                node.Nodes[i].CheckState = check;
                SetCheckedChildNodes(node.Nodes[i], check);
            }
        }
        private void SetCheckedParentNodes(TreeListNode node, CheckState check)
        {
            if (node.ParentNode != null)
            {
                bool b = false;
                CheckState state;
                for (int i = 0; i < node.ParentNode.Nodes.Count; i++)
                {
                    state = (CheckState)node.ParentNode.Nodes[i].CheckState;
                    if (!check.Equals(state))
                    {
                        b = !b;
                        break;
                    }
                }
                node.ParentNode.CheckState = b ? CheckState.Indeterminate : check;
                SetCheckedParentNodes(node.ParentNode, check);
            }
        }

        private void treeList_AfterCheckNode(object sender, DevExpress.XtraTreeList.NodeEventArgs e)
        {
            //TODO e.Node.GetValue(0).ch
            SetCheckedChildNodes(e.Node, e.Node.CheckState);
            SetCheckedParentNodes(e.Node, e.Node.CheckState);
        }

        private void treeList_BeforeCheckNode(object sender, DevExpress.XtraTreeList.CheckNodeEventArgs e)
        {
            e.State = (e.PrevState == CheckState.Checked ? CheckState.Unchecked : CheckState.Checked);
        }

        public Job GetJob()
        {
            ServerConnection connection = new ServerConnection("mi001-ws00071", "SA", "Oberon");
            connection.Connect();
            Server jobserver = new Server(connection);
            return jobserver.JobServer.Jobs["PVX"];   
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (treeList.DataSource is OrderShops)
            {
                if ((treeList.DataSource as OrderShops).SaveSelectedOrder())
                {
                    if (GetJob().CurrentRunStatus == JobExecutionStatus.Idle)
                    {
                        GetJob().Start();

                        Thread.Sleep(2000);

                        while (GetJob().CurrentRunStatus != JobExecutionStatus.Idle)
                        {
                            Thread.Sleep(2000);
                        }
                        XtraMessageBox.Show("Заказы сформированы");
                    }
                }
            }
        }
    }
}