using System;
using System.Diagnostics;
using System.Windows.Forms;
using DataBase.DataObject;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraPrinting;
using DevExpress.XtraTreeList;
using ShopOrderCustom.Models;

namespace ShopOrderCustom.UI
{
    public partial class ActualAssortViewerForm : XtraForm
    {
        private ActualAssortViewerModel Model { get; set; }

        public ActualAssortViewerForm(ActualAssortViewerModel model)
        {
            Model = model;
            InitializeComponent();
            Model.LoadUserViewLayout(gridView);
            RefreshTree();
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
                if(e.Node.GetValue(0) is OrderShopObj)
                {
                    Model.CurrentShop = (OrderShopObj)e.Node.GetValue(0);
                    grid.DataSource = Model.GetOrderList();
                }
                else
                {
                    Model.CurrentShop = null;
                    grid.DataSource = null;
                }
            }
        }

        private void TreeListCustomDrawNodeCell(object sender, CustomDrawNodeCellEventArgs e)
        {
            /*
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
             */ 
        }

        private void BtRefreshItemClick(object sender, ItemClickEventArgs e)
        {
            RefreshTree();
        }

        private void TreeListGetStateImage(object sender, GetStateImageEventArgs e)
        {
            if (e.Node.GetValue(0) is OrderShopObj)
                e.NodeImageIndex = 0;
        }


        private void BtExportItemClick(object sender, ItemClickEventArgs e)
        {
            if (Model.CurrentShop != null)
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
                path = string.Format(@"{0}\{1}_{2}.xlsx", GetTempFolder(), Model.CurrentShop.ShopCode.Trim(), DateTime.Now.ToFileTime());

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

        private void ActualAssortViewerForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Model.SaveUserViewLayout(gridView);}
    }
}