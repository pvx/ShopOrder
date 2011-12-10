using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraTreeList;

namespace ShopOrderCustom
{
    public partial class OrderForm : XtraForm
    {
        private OrderModel Model { get; set; }

        public OrderForm(OrderModel orderModel)
        {
            InitializeComponent();
            Model = orderModel;
            InitTreeListControl();
        }

        void InitTreeListControl()
        {
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
            if (e.Node != null){
                Model.CurrentOrderHeader = (e.Node.TreeList.DataSource as Orders)[e.Node.Id];
                Model.IdOrderHeader = Model.CurrentOrderHeader.IdOrderHeader;
                btCommit.Enabled = Model.CurrentOrderHeader.IdOrderState == 1;
                colReqQuantity.OptionsColumn.AllowEdit = Model.CurrentOrderHeader.IdOrderState == 1;
                grid.DataSource = Model.GetOrderList();
            }
        }

        void ReloadGrid()
        {
            grid.DataSource = Model.GetOrderList();
        }

        void AddOrder()
        {
            if (treeList.DataSource != null)
            {
                Orders ord = (treeList.DataSource as Orders);
                if (ord.Count > 0)
                {
                    if (XtraMessageBox.Show("Создать новый заказ и подтвердить все не подтвержденные заказы?", "Новый заказ",
                                        MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        ord.AddOrderHeader();
                        treeList.MoveLastVisible();}
                }
                else
                {
                    ord.AddOrderHeader(); 
                    treeList.MoveLastVisible();
                }
            }           
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            AddOrder();
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Model.StoreHouseType = true;
            ReloadGrid();
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Model.StoreHouseType = false;
            ReloadGrid();
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Model.CurrentOrderHeader != null)
            {
                if (Model.CurrentOrderHeader.IdOrderState == 1)
                {
                    if (XtraMessageBox.Show("Подтвердить заказ?", "Подтверждение заказа",
                                        MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        if (treeList.DataSource != null)
                        {
                            (treeList.DataSource as Orders).CommitOrderHeader(Model.CurrentOrderHeader.IdOrderHeader);
                            Model.CurrentOrderHeader.IdOrderState = 2;
                            colReqQuantity.OptionsColumn.AllowEdit = Model.CurrentOrderHeader.IdOrderState == 1;
                            btCommit.Enabled = Model.CurrentOrderHeader.IdOrderState == 1;
                        }
                    }
                }
            }
        }

        private void gridView_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            //e.Appearance.BackColor = Color.DeepSkyBlue;
        }
    }
}