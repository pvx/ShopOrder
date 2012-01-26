using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Common;
using DataBase;
using DataBase.DataObject;
using DataBase.Log;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using Microsoft.Practices.Unity;
using ShopOrderCustom.Models;

namespace ShopOrderCustom.UI
{
    public partial class OrderManagerForm : XtraForm
    {
        public OrderManagerForm(OrderManagerModel model)
        {
            Model = model;
            InitializeComponent();
            Model.LoadUserViewLayout(gridView);
            Model.ChangeDateFilter += Model_ChangeDateFilter;
            Model.FilterDate = DateTime.Now.Date;
            cdDateFilter.EditValue = Model.FilterDate;
        }

        private OrderManagerModel Model { get; set; }

        private void Model_ChangeDateFilter(object sender, EventChangeDateFilter e)
        {
            SetUi();
            DataBinding();
        }

        private void DataBinding()
        {
            grid.DataSource = null;
            treeList.ExpandAll();
            treeList.DataSource = Model.GetOrdersHeader();
            treeList.BestFitColumns();
        }

        private void SetUi()
        {
            btCreateOrders.Enabled = Model.ServerDate.Date == Model.FilterDate.Date;
        }

        private void RefreshTree()
        {
            DataBinding();
        }

        private void TreeListAfterFocusNode(object sender, NodeEventArgs e)
        {
            if (e.Node != null)
            {
                if (e.Node.Level == 1)
                {
                    Model.CurrentOrderHeader = (OrderHeaderObj)e.Node.GetValue(0);
                    grid.DataSource = Model.GetOrderList();
                    btChangeState.Enabled = Model.CurrentOrderHeader.IdOrderState == 2;
                    btInfo.Enabled = true;
                }
                else
                {
                    btInfo.Enabled = false;
                    Model.CurrentOrderHeader = null;
                    grid.DataSource = null;
                }
            }
        }

        private void SetCheckedChildNodes(TreeListNode node, CheckState check)
        {
            if (node.GetValue(0) != null)
                if (Equals(node.GetValue(0).GetType(), typeof(OrderHeaderObj)))
                {
                    var oh = (OrderHeaderObj)node.GetValue(0);
                    if (Model.CanCheck(oh))
                    {
                        oh.Checked = check == CheckState.Checked;
                    }
                    else
                    {
                        oh.Checked = false;
                        node.CheckState = CheckState.Unchecked;
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
                        b = true;
                        break;
                    }
                }
                node.ParentNode.CheckState = b ? CheckState.Indeterminate : check;
                SetCheckedParentNodes(node.ParentNode, check);
            }
        }

        private void TreeListAfterCheckNode(object sender, NodeEventArgs e)
        {
            SetCheckedChildNodes(e.Node, e.Node.CheckState);
            SetCheckedParentNodes(e.Node, e.Node.CheckState);
        }

        private void TreeListBeforeCheckNode(object sender, CheckNodeEventArgs e)
        {
            if (e.Node.GetValue(0).GetType().Equals(typeof(OrderHeaderObj)))
            {
                e.CanCheck = Model.CanCheck((e.Node.GetValue(0) as OrderHeaderObj));
            }
            e.State = (e.PrevState == CheckState.Checked ? CheckState.Unchecked : CheckState.Checked);
        }

        private void BarButtonItem1ItemClick(object sender, ItemClickEventArgs e)
        {
            if (treeList.DataSource is OrderShops)
            {
                var os = (OrderShops)treeList.DataSource;
                if (os.SaveSelectedOrder())
                {
                    XtraMessageBox.Show("Заказы сформированы");
                }
            }
        }
        
        private void TreeListCustomDrawNodeCell(object sender, CustomDrawNodeCellEventArgs e)
        {
            if (e.Node.GetValue(0).GetType().Equals(typeof(OrderShopObj)))
            {
                e.Appearance.BackColor = Color.Empty;
                var oh = (OrderShopObj)e.CellValue;
                if(((Orders) oh.Orders).IsExistInState(2))
                {
                    e.Appearance.BackColor = Color.LightGreen;
                }
            }

            if (e.Node.GetValue(0).GetType().Equals(typeof(OrderHeaderObj)))
            {
                e.Appearance.BackColor2 = Color.Empty;
                var oh = (OrderHeaderObj)e.CellValue;

                if (oh != null)
                {
                    e.Appearance.BackColor = oh.IdOrderState != 2 ? Color.LightPink : Color.LightGreen;
                    e.Appearance.BackColor = oh.Locked ? Color.Violet : e.Appearance.BackColor;
                }
                if (e.Node.Focused)
                {
                    e.Appearance.BackColor2 = Color.White;
                    return;
                }
            }
        }

        private void BtRefreshItemClick(object sender, ItemClickEventArgs e)
        {
            RefreshTree();
        }

        private void CdDateFilterEditValueChanged(object sender, EventArgs e)
        {
            Model.FilterDate = (DateTime)cdDateFilter.EditValue;
        }

        private void BarButtonLockClick(object sender, ItemClickEventArgs e)
        {
            if (treeList.DataSource is OrderShops)
            {
                var os = (treeList.DataSource as OrderShops);
                os.ChangeSelectedOrderState();
            }
        }

        private void TreeListGetStateImage(object sender, GetStateImageEventArgs e)
        {
            if (e.Node.GetValue(0) is OrderShopObj)
                e.NodeImageIndex = 0;

            if (e.Node.GetValue(0) is OrderHeaderObj)
            {
                var oh = e.Node.GetValue(0) as OrderHeaderObj;
                if (oh.IdOrderState == 3)
                    e.NodeImageIndex = 1;
                if (oh.IdOrderState == 2)
                    e.NodeImageIndex = 2;
                if (oh.IdOrderState == 4)
                    e.NodeImageIndex = 3;
                if (oh.IdOrderState == 6)
                    e.NodeImageIndex = 3;
            }
        }

        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            treeList.ExpandAll();}

        private void treeList_MouseUp(object sender, MouseEventArgs e)
        {
            var tree = sender as TreeList;
            if (tree != null)
            {
                if (e.Button == MouseButtons.Right && ModifierKeys == Keys.None && tree.State == TreeListState.Regular)
                {
                    if ((Model.CurrentOrderHeader != null) && (Model.CurrentOrderHeader.IdOrderState == 2) &&
                        (Model.FilterDate != Model.ServerDate))
                    {
                        TreeListHitInfo info = tree.CalcHitInfo(tree.PointToClient(MousePosition));
                        if (tree.FocusedNode != null)
                        {
                            Rectangle rect = tree.ViewInfo.RowsInfo[tree.FocusedNode].DataBounds;
                            if (rect.Contains(info.MousePoint))
                                popupMenuNodes.ShowPopup(MousePosition);
                        }
                    }

                }
            }
        }

        private void ShowCompareViewer()
        {
            var ucCompare = new UcOrderCompare();
            BindingList<OrderTransferCompare> blc;
  
            using (var dw = new DataUiViewer(ucCompare))
            {
                using (var oc = Model.UnityContainer.Resolve<OrderDataContext>())
                {
                    var sl =
                        from s in
                            oc.DataBaseContext.sp_sel_OrderTransferCompare(Model.CurrentOrderHeader.IdOrderHeader)
                                //Guid.Parse("C1FB0325-6C2A-4C33-9F9D-03A8A4884E5D"))
                        select new OrderTransferCompare()
                                   {
                                       Active = true,
                                       Barcode = s.Barcode,
                                       Code = s.Code,
                                       DateDest = s.DateDest,
                                       DateSrc = s.DateSrc,
                                       Measure = s.Measure,
                                       Supplier = s.Supplier,
                                       QuantitySrc = s.QuantitySrc,
                                       QuantityInPack = s.QuantityInPack.GetValueOrDefault(0),
                                       QuantityDest = s.QuantityDest,
                                       Price = s.Price.GetValueOrDefault(0),
                                       Name = s.Name,
                                       Group = s.Group,
                                       IsEqual = s.QuantitySrc == s.QuantityDest
                                   };

                    blc = new BindingList<OrderTransferCompare>(sl.ToList());
                }
                ucCompare.DataSource = blc;
                dw.ShowDialog();
                
            }   
        }

        private void barButtonItem4_ItemClick(object sender, ItemClickEventArgs e)
        {
            Model.TransferOrder();
            ShowCompareViewer();
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowCompareViewer();
        }

        private void treeList_DoubleClick(object sender, EventArgs e)
        {
            if ((Model.CurrentOrderHeader != null) && (Model.CurrentOrderHeader.IdOrderState == 5))
            {
                ShowCompareViewer();
            }
        }

        private void ShowCurrentOrderInfo()
        {
            if (Model.CurrentOrderHeader != null)
            {
                using (var oc = Model.UnityContainer.Resolve<OrderDataContext>())
                {

                    using (
                        var dw =
                            new DataUiViewer(new UcOrderInfo(Utility.StringToDictObj(oc.DataBaseContext.GetOrderInfo(Model.CurrentOrderHeader.IdOrderHeader)))))
                    {
                        dw.Text = @"Информация о заказе";
                        dw.ShowDialog();
                    }
                }
            }
        }

        private void BtInfoItemClick(object sender, ItemClickEventArgs e)
        {
            ShowCurrentOrderInfo();
        }

        void BackgroundWorkerProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pbar.Visibility = BarItemVisibility.Always;
            pbar.EditValue = e.ProgressPercentage;
        }

        void ImportNestleCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            RefreshTree();
            pbar.EditValue = 0;
            pbar.Visibility = BarItemVisibility.Never;
            XtraMessageBox.Show("Заказы Nestle импортированы успешно.");
            btNestleImport.Enabled = true;
            Model.UnityContainer.Resolve<IDBLogger>().InsertLog(string.Format("Заказы Nestle импортированы успешно."), string.Empty);
        }

        void ImportOrderCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            RefreshTree();
            pbar.EditValue = 0;
            pbar.Visibility = BarItemVisibility.Never;
            XtraMessageBox.Show("Заказы импортированы успешно.");
            btOrderImport.Enabled = true;
            Model.UnityContainer.Resolve<IDBLogger>().InsertLog(string.Format("Заказы из XLS файла импортированы успешно."), string.Empty);
        }

        private void BtNestleImportItemClick(object sender, ItemClickEventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Model.UnityContainer.Resolve<IDBLogger>().InsertLog(string.Format("Импорт заказов Nestle {0}", openFileDialog.FileName), string.Empty);
                                
                    btNestleImport.Enabled = false;
                    Model.LoadFromExcelNestleOrders(openFileDialog.FileName, BackgroundWorkerProgressChanged, ImportNestleCompleted);
                    treeList.Refresh();
                }
                catch (Exception ex)
                {
                    btNestleImport.Enabled = true;
                    XtraMessageBox.Show(ex.Message);
                }
            }
        }

        private void OrderManagerForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Model.SaveUserViewLayout(gridView);
        }

        private void BarButtonItem5ItemClick(object sender, ItemClickEventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Model.UnityContainer.Resolve<IDBLogger>().InsertLog(string.Format("Импорт заказов из XLS файла {0}", openFileDialog.FileName), string.Empty);

                    btOrderImport.Enabled = false;
                    Model.LoadFromExcelOrders(openFileDialog.FileName, BackgroundWorkerProgressChanged, ImportOrderCompleted);
                    treeList.Refresh();
                }
                catch (Exception ex)
                {
                    btOrderImport.Enabled = true;
                    XtraMessageBox.Show(ex.Message);
                }
            }
        }
    }
}