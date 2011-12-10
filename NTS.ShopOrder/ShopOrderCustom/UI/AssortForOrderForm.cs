using System;
using System.Windows.Forms;
using Common.Enum;
using Common.Interfaces;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using ShopOrderCustom.Data;
using ShopOrderCustom.Models;

namespace ShopOrderCustom.UI
{
    public partial class AssortForOrderForm : XtraForm
    {
        public AssortForOrderForm(AssortForOrderModel model)
        {
            Model = model;
            InitializeComponent();
            Model.LoadUserViewLayout(gridView);
            treeList.DataSource = Model.OrderCategorys;
            treeList.ExpandAll();
        }

        private AssortForOrderModel Model { get; set; }

        private void TreeListAfterFocusNode(object sender, NodeEventArgs e)
        {
            if (e.Node != null)
            {
                object data = e.Node.GetValue(0);

                if (data is GoodsNodeGroupObj)
                {
                    grid.DataSource = (data as GoodsNodeGroupObj).ObjectList;
                }
                else
                {
                    grid.DataSource = null;
                }
            }
        }

        private void TreeListAfterCheckNode(object sender, NodeEventArgs e)
        {
            SetCheckedChildNodes(e.Node, e.Node.CheckState);
            SetCheckedParentNodes(e.Node, e.Node.CheckState);
        }

        private void TreeListBeforeCheckNode(object sender, CheckNodeEventArgs e)
        {
            e.State = (e.PrevState == CheckState.Checked ? CheckState.Unchecked : CheckState.Checked);
        }

        private static void SetCheckedChildNodes(TreeListNode node, CheckState check)
        {
            if (node.GetValue(0) != null)
            {
                if (Equals(node.GetValue(0).GetType(), typeof (GoodsNodeCategoryObj)))
                {
                    var oh = (GoodsNodeCategoryObj) node.GetValue(0);
                    oh.Check = check == CheckState.Checked;
                }

                if (Equals(node.GetValue(0).GetType(), typeof (GoodsNodeGroupObj)))
                {
                    var oh = (GoodsNodeGroupObj) node.GetValue(0);
                    oh.Check = check == CheckState.Checked;
                }
            }

            for (int i = 0; i < node.Nodes.Count; i++)
            {
                node.Nodes[i].CheckState = check;
                SetCheckedChildNodes(node.Nodes[i], check);
            }
        }

        private static void SetCheckedParentNodes(TreeListNode node, CheckState check)
        {
            if (node.ParentNode != null)
            {
                bool b = false;
                for (int i = 0; i < node.ParentNode.Nodes.Count; i++)
                {
                    CheckState state = node.ParentNode.Nodes[i].CheckState;
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

        private void TreeListGetStateImage(object sender, GetStateImageEventArgs e)
        {
            ICheckInfo checkInfo = null;

            if (e.Node.GetValue(0) is GoodsNodeCategoryObj)
            {
                var obj = e.Node.GetValue(0) as GoodsNodeCategoryObj;
                if (obj.ObjectList is ICheckInfo)
                    checkInfo = (ICheckInfo) obj.ObjectList;
            }

            if (e.Node.GetValue(0) is GoodsNodeGroupObj)
            {
                var obj = e.Node.GetValue(0) as GoodsNodeGroupObj;
                if (obj.ObjectList is ICheckInfo)
                    checkInfo = (ICheckInfo) obj.ObjectList;
            }

            if (checkInfo != null)
            {
                switch (checkInfo.GetCheckState())
                {
                    case StateCheck.AllChecked:
                        e.NodeImageIndex = 0;
                        //e.Node.Checked = true;
                        break;
                    case StateCheck.SomeChecked:
                        e.NodeImageIndex = 1;
                        //e.Node.Checked = false;
                        break;
                    case StateCheck.NoChecked:
                        e.NodeImageIndex = 2;
                        //e.Node.Checked = false;
                        break;
                }
            }
        }

        private void BarButtonItem2ItemClick(object sender, ItemClickEventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Model.LoadFromExcel(openFileDialog.FileName);
                    treeList.Refresh();
                    BarState.Caption = @"Загружено из Excel";
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message);
                }
            }
        }

        private void BarButtonItem1ItemClick(object sender, ItemClickEventArgs e)
        {
            if (XtraMessageBox.Show("Сохранить выбранный ассортимент?",
                                    "Сохранение ассортимента", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Model.Save();
                BarState.Caption = @"Успешно сохранен";
            }
        }

        private void GridViewCellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            treeList.Refresh();
        }

        private void AssortForOrderForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Model.SaveUserViewLayout(gridView);
        }
    }
}