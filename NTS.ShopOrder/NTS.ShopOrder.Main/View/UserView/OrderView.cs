using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Common;
using Common.Events;
using DataBase.DataSet;
using Microsoft.Practices.Unity;
using DataSet = DataBase.DataSet.DataSet;

namespace NTS.ShopOrder.Main.View.UserView
{
    public partial class OrderView : BaseView
    {
        private const int StateCreated = 1;
        private bool _isAlco;

        [Dependency]
        public IUnityContainer UnityContainer { get; set; }

        private DataClass DataClass { get; set; }

        [InjectionConstructor]
        public OrderView(DataClass dataClass)
        {
            this.DataClass = dataClass;
            InitializeComponent();

            CurrentOrderBalanceData.DataSource = dataClass.DataSet.sp_sel_CurrentOrderBalance;
            OrdersHeaderData.DataSource = dataClass.DataSet.sp_sel_OrdersHeader;
            radioButton2.Checked = true;
        }

        private void OrderView_Load(object sender, EventArgs e)
        {
            DataClass.OrdersHeaderFill();
            OrdersHeaderData_CurrentItemChanged(OrdersHeaderData, new EventArgs());
            OrdersHeaderData.CurrentItemChanged += new EventHandler(OrdersHeaderData_CurrentItemChanged);
        }

        void OrdersHeaderData_CurrentItemChanged(object sender, EventArgs e)
        {
            if (((BindingSource)(sender)).Current != null)
            {
                DataRow row = ((DataRowView)(((BindingSource)(sender)).Current)).Row;

                DataClass.InvokeOnChangeOrderHeader(new EventChangeOrderHeader() { IdOrderHeader = (Guid)row["id_OrderHeader"], OrderHeaderState = (int)row["id_OrderState"] });
            }
        }

        private void tvOrder_AfterSelect(object sender, TreeViewEventArgs e)
        {
            Text = e.Node.Tag.ToString();
        }

        private void tbAddOrder_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Подтвердить все заказы и создать новый заказ? ", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Guid g = Guid.NewGuid();
                DataClass.SpInsOrdersHeader(g);
                OrdersHeaderData.Position = OrdersHeaderData.Find("id_OrderHeader", g);
                DataClass.InvokeOnChangeOrderHeader(new EventChangeOrderHeader() { IdOrderHeader = g, OrderHeaderState = StateCreated });
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Подтвердить заказ? ", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                DataClass.SpUpdOrdersHeaderState(2);
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (sender != null)
            {
                _isAlco = Equals((sender as Control).Tag, "2");
                DataClass.IdStorehouse = int.Parse((sender as Control).Tag.ToString());
                CurrentOrderBalanceData.Filter = (Equals((sender as Control).Tag, "2")) ? "GoodsGroup like 'АЛКОГОЛЬНЫЕ%'" : "GoodsGroup not like 'АЛКОГОЛЬНЫЕ%'";
            }
        }

        private void c1TrueDBGrid1_BeforeColEdit(object sender, C1.Win.C1TrueDBGrid.BeforeColEditEventArgs e)
        {
            e.Cancel = DataClass.IdOrderHeaderState != StateCreated;
        }

        private void tbClear_Click(object sender, EventArgs e)
        {
            DataClass.SpClearOrder(_isAlco);
        }
    }
}