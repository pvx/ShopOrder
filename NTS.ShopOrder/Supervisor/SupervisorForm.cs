using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Common;
using DataBase;

namespace Supervisor
{
    public partial class SupervisorForm : BaseView
    {
        private SupervisorModel _supervisorModel;
        private List<Guid> _orderList;

        public SupervisorForm(SupervisorModel supervisorModel)
        {
            InitializeComponent();
            _supervisorModel = supervisorModel;
            _orderList = new List<Guid>();
            dbGrid.DataSource = bindingSource;
        }

        private void SupervisorForm_Load(object sender, EventArgs e)
        {
            _supervisorModel.LoadNodes(tvOrders);
        }

        private void tvOrders_AfterSelect(object sender, TreeViewEventArgs e)
        {
            var node = e.Node.Tag;
            Text = node.GetType().ToString();
            bindingSource.DataSource = _supervisorModel.GetOrderList(node.GetType(),  node);
            //dbGrid.DataSource 
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

            _orderList.Clear();
            _supervisorModel.LoadNodes(tvOrders);
        }

        private void tvOrders_AfterCheck(object sender, TreeViewEventArgs e)
        {
            foreach (TreeNode node in e.Node.Nodes)
            {
                node.Checked = e.Node.Checked;
            }
            
            if (e.Node.Tag.GetType().Equals(typeof(vOrderHeaderAll)))
                if (e.Node.Checked)
                {
                    _orderList.Add(((vOrderHeaderAll)e.Node.Tag).id_OrderHeader);
                }
                else
                {
                    _orderList.Remove(((vOrderHeaderAll)e.Node.Tag).id_OrderHeader);
                }
             
        }
    }
}
