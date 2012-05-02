using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DataBase;
using DataBase.DataObject;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraTreeList;
using ShopOrderCustom.Models;

namespace ShopOrderCustom.UI
{
    public partial class GoodsReturnForm : XtraForm
    {
        public GoodsReturnForm(GoodsReturnModel model)
        {
            InitializeComponent();
            Model = model;
            Model.LoadUserViewLayout(gridView);
            Model.ChangeDateFilter += ModelChangeDateFilter;
            Model.FilterDate = DateTime.Now.Date;
            cdDateFilter.EditValue = Model.FilterDate;   
        }

        void ModelChangeDateFilter(object sender, EventChangeDateFilter e)
        {
            btNewReturn.Enabled = Model.IsAllowAdd();
            InitTreeListControl();
        }

        private void InitTreeListControl()
        {DataBinding();
        }

        private void DataBinding()
        {
            treeList.ExpandAll();
            treeList.DataSource = null;
            treeList.DataSource = Model.GetReturnsHeader();
            treeList.BestFitColumns();
            grid.DataSource = null;
        }

        private GoodsReturnModel Model { get; set; }

        private void CdDateFilterEditValueChanged(object sender, EventArgs e)
        {
            Model.FilterDate = (DateTime)cdDateFilter.EditValue;
        }

        private void BtNewReturnItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            AddReturn();
        }

        private void AddReturn()
        {
            if (XtraMessageBox.Show("Создать новый возврат и подтвердить все не подтверждённые?",
                        "Создание возврата", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (treeList.DataSource != null)
                {
                    var ord = (Returns) treeList.DataSource;
                    if(ord.CommitAll())
                        ord.AddReturnHeader();
                    else
                    {
                        XtraMessageBox.Show("Нельзя подтвердить пустой возврат", "Создание возврата", MessageBoxButtons.OK);
                    }
                    SetUiControls();
                }
            }
        }

        private void TreeListAfterFocusNode(object sender, DevExpress.XtraTreeList.NodeEventArgs e)
        {
            if (e.Node != null)
            {

                Model.CurrentReturnHeader = ((Returns)e.Node.TreeList.DataSource)[e.Node.Id];
               
                grid.BeginUpdate();
                try
                {
                    var item = Model.GetReturnList();
                    lpReasonLookUp.DataSource = item.ReturnReasons;
                    lpStatePos.DataSource = Model.ReturnStatePos;
                    grid.DataSource = item;
                    
                    SetUiControls();
                }
                finally
                {
                    grid.EndUpdate();
                }
            }
        }

        private void TreeListGetStateImage(object sender, DevExpress.XtraTreeList.GetStateImageEventArgs e)
        {
            if (e.Node.GetValue(0) is ReturnObj)
            {
                var oh = (ReturnObj)e.Node.GetValue(0);
                if (oh.ReturnStateId == 1)
                    e.NodeImageIndex = 0;

                if (oh.ReturnStateId == 2)
                    e.NodeImageIndex = 1;

                if (oh.ReturnStateId == 3)
                    e.NodeImageIndex = 2;

                if (oh.ReturnStateId == 4)
                    e.NodeImageIndex = 3;

                if (oh.ReturnStateId == 5)
                    e.NodeImageIndex = 4;
            }
       }

        private void BtCommitItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(XtraMessageBox.Show("Подтвердить возврат?","Смена статуса возврата",MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Model.CommitReturn();
                SetUiControls();
            }
        }

        private void SetUiControls()
        {
            btCommit.Enabled = Model.AllowEdit;
            btAdd.Enabled = Model.AllowEdit;
            btEdit.Enabled = Model.AllowEdit;
            btDel.Enabled = Model.AllowEdit;

        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
         
        }

        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //Model.CurrentReturnHeader.ReturnItems.
        }

        private void AddReturnItem()
        {
            Model.AddReturnItem();
        }

        private void barButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            AddReturnItem();
        }

        private void barButtonItem5_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            AddReturnItem();
        }

        private void barButtonItem6_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DelReturnItem(GetSelectedItem());               
        }

        private void DelReturnItem(ReturnItemObj items)
        {
            Model.DelReturnItem(items);
        }

        private ReturnItemObj GetSelectedItem()
        {
            if (gridView.SelectedRowsCount > 0)
            {
                var hs = gridView.GetSelectedRows();
                var reti = (ReturnItems)gridView.DataSource;
                return reti[gridView.GetDataSourceRowIndex(hs[0])];
            }
            return null;
        }

        private void barButtonItem7_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Model.EditReturnItem(GetSelectedItem());          
        }

        private void barButtonItem10_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Model.EditReturnItem(GetSelectedItem());   
        }

        private void BtAddItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            AddReturnItem();
        }

        private void BtDelItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DelReturnItem(GetSelectedItem());    
        }

        private void btRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DataBinding();
        }

        private dynamic _resSumm;

        private void gridView_CustomSummaryCalculate(object sender, DevExpress.Data.CustomSummaryEventArgs e)
        {
            var item = e.Item as GridColumnSummaryItem;
            var view = sender as GridView;
            if (item != null && Equals("summary", item.Tag))
            {
                if (e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Start)
                    _resSumm = 0;

                if (e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Calculate)
                {
                    try
                    {
                        dynamic prc = double.Parse(view.GetRowCellValue(e.RowHandle, "Price").ToString());
                        dynamic qty = view.GetRowCellValue(e.RowHandle, "QuantityRet");
                        dynamic ret = prc*qty;
                        _resSumm += ret;
                    }
                    catch (Exception)
                    {
                        _resSumm = 0;                  
                    }

                }
                if (e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Finalize)
                {
                    e.TotalValue = _resSumm;
                    e.TotalValueReady = true;}
            }
        }

        private void TreeListCustomDrawNodeCell(object sender, CustomDrawNodeCellEventArgs e)
        {
            if (e.Node.GetValue(0).GetType().Equals(typeof(ReturnObj)))
            {
                e.Appearance.BackColor2 = Color.Empty;

                e.Appearance.BackColor = ((ReturnObj)e.CellValue).ReturnStateId == 1 ? Color.LightGreen : Color.LightPink;

                if (e.Node.Focused)
                {
                    e.Appearance.BackColor2 = Color.White;
                    return;
                }
            }
        }
    }
}