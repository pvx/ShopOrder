using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using DataBase.DataObject;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraPrinting;
using DevExpress.XtraTreeList;
using ShopOrderCustom.Models;

namespace ShopOrderCustom.UI
{
    public partial class OrderForm : XtraForm
    {
        public OrderForm(OrderModel orderModel)
        {
            InitializeComponent();
            Model = orderModel;
            Model.LoadUserViewLayout(gridView);
            Model.ChangeDateFilter += Model_ChangeDateFilter;
            Model.FilterDate = DateTime.Now.Date;
            cdDateFilter.EditValue = Model.FilterDate;   
            
        }

        void Model_ChangeDateFilter(object sender, EventChangeDateFilter e)
        {
            InitTreeListControl();
        }

        private OrderModel Model { get; set; }

        private void InitTreeListControl()
        {
            DataBinding();
        }

        private void DataBinding()
        {
            treeList.ExpandAll();
            treeList.DataSource = null;
            treeList.DataSource = Model.GetOrdersHeader();
            treeList.BestFitColumns();
            grid.DataSource = null;
        }

        private void TreeListAfterFocusNode(object sender, NodeEventArgs e)
        {
            if (e.Node != null)
            {
                Model.CurrentOrderHeader = ((Orders) e.Node.TreeList.DataSource)[e.Node.Id];
                Model.IdOrderHeader = Model.CurrentOrderHeader.IdOrderHeader;
                grid.BeginUpdate();
                try
                {
                    grid.DataSource = Model.GetOrderList();                
                    btCommit.Enabled = Model.AllowEdit;
                    bеForOrder.Enabled = Model.AllowEdit;
                    colReqQuantity.OptionsColumn.AllowEdit = Model.AllowEdit;
                }
                finally
                {
                    grid.EndUpdate();
                }

            }
        }

        private void ReloadGrid()
        {
            grid.DataSource = Model.GetOrderList();
        }

        private bool CheckOrder()
        {
            var ord = treeList.DataSource as Orders;
            if (ord != null)
                foreach (OrderHeaderObj orderHeaderObj in ord)
                {
                    if (orderHeaderObj.IdOrderState == 1)
                    {
                        if (!Model.CheckSaveOrder(orderHeaderObj.IdOrderHeader))
                        {
                            XtraMessageBox.Show("Пустой заказ не может быть подтверждён", "Подтверждение заказа",
                                                MessageBoxButtons.OK);
                            return true;
                        }
                    }
                }
            return false;
        }

        private void AddOrder()
        {
            if (!Model.CheckCreateOrder())
            {
                XtraMessageBox.Show("Невозможно создать новый заказ так как остатки не были загружены",
                                    "Новый заказ",
                                    MessageBoxButtons.OK);
                return;
            }

            if (CheckOrder())
                return;

            if (treeList.DataSource != null)
            {
                var ord = (Orders)treeList.DataSource;
                if (ord.Count > 0)
                {
                    if (XtraMessageBox.Show("Создать новый заказ и подтвердить все неподтвержденные заказы?",
                                            "Новый заказ",
                                            MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        ord.AddOrderHeader();
                        treeList.MoveLastVisible();
                    }
                }
                else
                {
                    grid.BeginUpdate();
                    try
                    {
                        ord.AddOrderHeader();
                        treeList.MoveLastVisible();
                        Model.SetAutoOrder();
                        SetStorehouse(!Model.StoreHouseType);
                        Model.SetAutoOrder();
                        SetStorehouse(!Model.StoreHouseType);
                    }
                    finally
                    {
                        grid.EndUpdate();
                    }
                }
            }
        }

        private void BarButtonItem1ItemClick(object sender, ItemClickEventArgs e)
        {
            AddOrder();
        }

        private void BarButtonItem4ItemClick(object sender, ItemClickEventArgs e)
        {
            if (Model.CurrentOrderHeader != null)
            {
                if (!Model.CheckSaveOrder())
                {
                    XtraMessageBox.Show("Пустой заказ не может быть подтверждён", "Подтверждение заказа",
                                        MessageBoxButtons.OK);
                    return;
                }
                if (Model.CurrentOrderHeader.IdOrderState == 1)
                {
                    if (XtraMessageBox.Show("Подтвердить заказ?", "Подтверждение заказа",
                                            MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        if (treeList.DataSource != null)
                        {
                            ((Orders) treeList.DataSource).CommitOrderHeader(Model.CurrentOrderHeader.IdOrderHeader);
                            Model.CurrentOrderHeader.IdOrderState = 2;
                            colReqQuantity.OptionsColumn.AllowEdit = Model.CurrentOrderHeader.IdOrderState == 1;
                            btCommit.Enabled = Model.CurrentOrderHeader.IdOrderState == 1;
                            bеForOrder.Enabled = false;
                        }
                    }
                }
            }
        }

        private void GridViewCustomDrawCell(object sender, RowCellCustomDrawEventArgs e)
        {
        }

        private void GridViewRowStyle(object sender, RowStyleEventArgs e)
        {
        }

        private void TreeListCustomDrawNodeCell(object sender, CustomDrawNodeCellEventArgs e)
        {
            if (e.Node.GetValue(0).GetType().Equals(typeof (OrderHeaderObj)))
            {
                e.Appearance.BackColor2 = Color.Empty;
                
                e.Appearance.BackColor = ((OrderHeaderObj) e.CellValue).IdOrderState == 1 ? Color.LightGreen : Color.LightPink;

                if (e.Node.Focused)
                {
                    e.Appearance.BackColor2 = Color.White;
                    return;
                }
            }
        }

        private void SetStorehouse(bool flag)
        {
            Model.StoreHouseType = flag;
            ReloadGrid();
        }

        private void BarCheckCheckedChanged(object sender, ItemClickEventArgs e)
        {
            SetStorehouse(false);
        }

        private void BarCheckNtsCheckedChanged(object sender, ItemClickEventArgs e)
        {
            SetStorehouse(true);
        }

        private void BtRefreshItemClick(object sender, ItemClickEventArgs e)
        {
            InitTreeListControl();
            ReloadGrid();
        }
        
        private void BarButtonItem3ItemClick(object sender, ItemClickEventArgs e)
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

        private void TreeListBeforeFocusNode(object sender, BeforeFocusNodeEventArgs e)
        {
            
        }

        private void DateFilterChange(object sender, EventArgs e)
        {
            Model.FilterDate = (DateTime)cdDateFilter.EditValue;
            btNewOrder.Enabled = Model.ServerDate.Date == Model.FilterDate.Date; 
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (XtraMessageBox.Show("Применить рекомендованный заказ к обязательному ассортименту?",
                                    "Подтверждение рекомендованного заказа", MessageBoxButtons.YesNo) ==
                DialogResult.Yes)
            {
                Cursor.Current = Cursors.WaitCursor;
                try
                {
                    Model.CopyForOrder(true);
                }
                finally
                {
                    Cursor.Current = Cursors.Default; 
                }
            }
        }

        private void OrderFormFormClosed(object sender, FormClosedEventArgs e)
        {
            Model.SaveUserViewLayout(gridView);
        }

        private void barButtonItem4_ItemClick(object sender, ItemClickEventArgs e)
        {
            Model.SetAutoOrder();
        }
    }
}