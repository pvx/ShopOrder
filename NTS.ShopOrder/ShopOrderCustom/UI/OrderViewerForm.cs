using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Common;
using DataBase;
using DataBase.DataObject;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraPrinting;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using Microsoft.Practices.Unity;
using ShopOrderCustom.Models;

namespace ShopOrderCustom.UI
{
    public partial class OrdeViewerForm : XtraForm
    {
        public OrdeViewerForm(OrderViewerModel model)
        {
            Model = model;
            InitializeComponent();
            Model.LoadUserViewLayout(gridView);
            Model.ChangeDateFilter += ModelChangeDateFilter;
            //Model.FilterDate = DateTime.Now.Date;
            cdDateFilter.EditValue = Model.FilterDate;
            cdDateFilterEnd.EditValue = Model.FilterDateEnd;
        }

        private OrderViewerModel Model { get; set; }

        private void ModelChangeDateFilter(object sender, EventChangeDateFilter e)
        {
            DataBinding();
        }

        private void DataBinding()
        {
            grid.DataSource = null;
            treeList.ExpandAll();
            treeList.DataSource = Model.GetOrdersHeader();
            treeList.BestFitColumns();
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
                    grid.DataSource = null;
                    Model.CurrentOrderHeader = (OrderHeaderObj)e.Node.GetValue(0);
                    grid.DataSource = Model.GetOrderList();
                    btInfo.Enabled = true;
                    Model.ShopObj = null;
                }
                else
                {
                    grid.DataSource = null;
                    Model.ShopObj = (OrderShopObj)e.Node.GetValue(0);
                    grid.DataSource = Model.GetOrderByShopList();
                    btInfo.Enabled = false;
                    Model.CurrentOrderHeader = null;
                    
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

        private void CdDateFilterEndEditValueChanged(object sender, EventArgs e)
        {
            Model.FilterDateEnd = (DateTime)cdDateFilterEnd.EditValue;
        }

        private void TreeListGetStateImage(object sender, GetStateImageEventArgs e)
        {
            if (e.Node.GetValue(0) is OrderShopObj)
                e.NodeImageIndex = 0;

            if (e.Node.GetValue(0) is OrderHeaderObj)
            {
                var oh = (OrderHeaderObj)e.Node.GetValue(0);
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

        private void BarButtonItem2ItemClick(object sender, ItemClickEventArgs e)
        {
            treeList.ExpandAll();
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

        private void BtExportItemClick(object sender, ItemClickEventArgs e)
        {
            ExportExcel();
        }

        private static string GetTempFolder()
        {
            return Environment.GetEnvironmentVariable("TEMP", EnvironmentVariableTarget.User);
        }

        private void ExportExcel()
        {
            string path = string.Empty;
            try
            {
                path = string.Format(@"{0}\ExcelOut_{1}.xlsx", GetTempFolder(), DateTime.Now.ToFileTime());

                var xlsxOptions = new XlsxExportOptions
                {
                    ShowGridLines = false,
                    TextExportMode = TextExportMode.Value,
                    ExportHyperlinks = true
                };

                grid.ExportToXlsx(path, xlsxOptions);
                Process.Start(path);
            }
            catch (Exception e)
            {
                XtraMessageBox.Show(e.Message + "  " + path, "Ошибка экспорта");
            }
        }

        private void OrdeViewerFormFormClosed(object sender, FormClosedEventArgs e)
        {
            Model.SaveUserViewLayout(gridView);
        }

        private void OrdeViewerFormLoad(object sender, EventArgs e)
        {
            RefreshTree();
        }
    }
}