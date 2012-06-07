using System;
using System.Windows.Forms;
using Common.Enum;
using Common.Interfaces;
using DataBase.DataObject;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraTreeList.Nodes;
using ShopOrderCustom.Models;
using ShopOrderCustom.TreeData;

namespace ShopOrderCustom.UI
{
    public partial class DistributionForm : XtraForm
    {
        private DistributionFormModel _model;
        private DistributionFormModel Model
        {
            get { return _model; }
        }

        public DistributionForm(DistributionFormModel model)
        {
            _model = model;
            InitializeComponent();
            Model.LoadUserViewLayout(gridView);         
            LoadData();
            SetUI();
        }

        void SetUI()
        {
            btSave.Enabled = treeList.DataSource != null;
        }

        void SetTreeList(int ShopCategoryId)
        {
            treeList.DataSource = Model.GetCategoryNode(ShopCategoryId);
            SetUI(); 
            treeList.ExpandAll();
        }

        void LoadData()
        {
            foreach (ShopCategoryObj obj in Model.ShopCategorys)
            {
                cbRepCategory.Items.Add(obj);
            }
        }

        private void DistributionFormFormClosed(object sender, FormClosedEventArgs e)
        {
            Model.SaveUserViewLayout(gridView);
        }

        private void CbCategoryEditValueChanged(object sender, EventArgs e)
        {
            var obj = ((ShopCategoryObj)((BarEditItem)(sender)).EditValue);
            if (obj != null)
            {
                grid.DataSource = null;
                SetTreeList(obj.Id);
            }
        }

        private void TreeListAfterFocusNode(object sender, DevExpress.XtraTreeList.NodeEventArgs e)
        {
            if (e.Node != null)
            {
                object data = e.Node.GetValue(0);

                if (data is GoodsDataGroup)
                {
                    grid.DataSource = (data as GoodsDataGroup).ObjectList;
                }
                else
                {
                    grid.DataSource = null;
                }
            }
        }

        private void TreeListAfterCheckNode(object sender, DevExpress.XtraTreeList.NodeEventArgs e)
        {
            SetCheckedChildNodes(e.Node, e.Node.CheckState);
            SetCheckedParentNodes(e.Node, e.Node.CheckState);
        }

        private static void SetCheckedChildNodes(TreeListNode node, CheckState check)
        {
            if (node.GetValue(0) != null)
            {
                if (Equals(node.GetValue(0).GetType(), typeof(GoodsDataCategory)))
                {
                    var oh = (GoodsDataCategory)node.GetValue(0);
                    oh.Check = check == CheckState.Checked;
                }

                if (Equals(node.GetValue(0).GetType(), typeof(GoodsDataGroup)))
                {
                    var oh = (GoodsDataGroup)node.GetValue(0);
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

        private void TreeListBeforeCheckNode(object sender, DevExpress.XtraTreeList.CheckNodeEventArgs e)
        {
            e.State = (e.PrevState == CheckState.Checked ? CheckState.Unchecked : CheckState.Checked);
        }

        private void GridViewCellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            treeList.Refresh();
        }

        private void TreeListGetStateImage(object sender, DevExpress.XtraTreeList.GetStateImageEventArgs e)
        {
            ICheckInfo checkInfo = null;

            if (e.Node.GetValue(0) is GoodsDataCategory)
            {
                var obj = e.Node.GetValue(0) as GoodsDataCategory;
                if (obj.ObjectList is ICheckInfo)
                    checkInfo = (ICheckInfo)obj.ObjectList;
            }

            if (e.Node.GetValue(0) is GoodsDataGroup)
            {
                var obj = e.Node.GetValue(0) as GoodsDataGroup;
                if (obj.ObjectList is ICheckInfo)
                    checkInfo = (ICheckInfo)obj.ObjectList;
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

        private void BarButtonItem1ItemClick(object sender, ItemClickEventArgs e)
        {
            if (XtraMessageBox.Show("Сохранить введённые данные?",
                        "Сохранение распределения", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if(treeList.DataSource != null)
                {
                    ((GoodsCategoryNode) treeList.DataSource).Save();
                }
            }
        }

    }
}