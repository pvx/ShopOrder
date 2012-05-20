using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataBase.DataObject;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraPrinting;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraTreeList.Nodes.Operations;
using ShopOrderCustom.Models;

namespace ShopOrderCustom.UI
{
    public partial class GoodsReturnStateForm : XtraForm
    {
        private GoodsReturnStateModel Model { get; set; }

        public GoodsReturnStateForm(GoodsReturnStateModel model)
        {
            Model = model;
            InitializeComponent();

            Model.LoadUserViewLayout(gridView);
            Model.ChangeDateFilter += ModelChangeDateFilter;
            Model.FilterDate = DateTime.Now.Date;
            cdDateFilter.EditValue = Model.FilterDate;
            cbItemMode.Items.AddRange(Model.ReturnStatePos);
        }

        void ModelChangeDateFilter(object sender, EventChangeDateFilter e)
        {
            InitTreeListControl();
        }


        private void InitTreeListControl()
        {
            DataBinding();
        }

        private void DataBinding()
        {
            treeList.ExpandAll();
            treeList.DataSource = null;
            treeList.DataSource = Model.GetReturnShop();
            treeList.BestFitColumns();
            grid.DataSource = null;
        }

        private void CdDateFilterEditValueChanged(object sender, EventArgs e)
        {
            Model.FilterDate = (DateTime)cdDateFilter.EditValue;
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

        private void TreeListBeforeCheckNode(object sender, DevExpress.XtraTreeList.CheckNodeEventArgs e)
        {
            if (e.Node.GetValue(0).GetType().Equals(typeof(ReturnObj)))
            {
                e.CanCheck = ((ReturnObj)e.Node.GetValue(0)).CanCheck;
            }
            e.State = (e.PrevState == CheckState.Checked ? CheckState.Unchecked : CheckState.Checked);
        }

        private void SetCheckedChildNodes(TreeListNode node, CheckState check)
        {
            if (node.GetValue(0) != null)
                if (Equals(node.GetValue(0).GetType(), typeof(ReturnObj)))
                {
                    var oh = (ReturnObj)node.GetValue(0);
                    if (oh.CanCheck)
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

        private void TreeListAfterFocusNode(object sender, NodeEventArgs e)
        {
            if (e.Node != null)
            {                    
                grid.BeginUpdate();
                try
                {
                    grid.DataSource = null;

                    if (e.Node.Level == 1)
                    {
                        Model.CurrentReturnShop = null;
                        Model.CurrentReturnHeader = (ReturnObj)e.Node.GetValue(0);
                        var item = Model.GetReturnList();
                        lpReasonLookUp.DataSource = item.ReturnReasons;
                        lpStatePos.DataSource = item.ReturnStatePos;
                        item.AllowEdit = Model.CurrentReturnHeader.CanEdit;
                        btExport.Enabled = !item.AllowEdit;
                        grid.DataSource = item;
                        LpStatePosEditValueChanged(null, new EventArgs());
                    }

                    if (e.Node.Level == 0)
                    {
                        Model.CurrentReturnHeader = null;
                        Model.CurrentReturnShop = (ReturnShopObj)e.Node.GetValue(0);
                        lpReasonLookUp.DataSource = Model.ReturnReasons;
                        lpStatePos.DataSource = Model.ReturnStatePos;
                        grid.DataSource = Model.CurrentReturnShop.ReturnItemsPool;
                        btExport.Enabled = false;
                    }
                }
                finally
                {
                    grid.EndUpdate();
                }
            }
        }

        private void BtRefreshItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DataBinding();
        }

        private void BtApplyItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if ((_categoryObj != null) && (((Model.CurrentReturnHeader != null) && (Model.CurrentReturnHeader.CanEdit) && (Model.CurrentReturnHeader.ReturnItems.Count > 0))
                || ((Model.CurrentReturnShop != null) && (Model.CurrentReturnShop.ReturnItemsPool.Count > 0))) 
                && (XtraMessageBox.Show("Применить выбранное свойство ко всем отображаемым строкам?",
                        "Применение свойства", MessageBoxButtons.YesNo) == DialogResult.Yes))
            {
                var ids = Model.ReturnStatePos.Where(g => g.StateCode == "AGREEDNTS" || g.StateCode == "NOTAGREED").Select(s => s.Id).ToArray();
                var selPos = new List<ReturnItemObj>();
                for (int i = 0; i < gridView.RowCount; i++)
                {
                    int rowHandle = gridView.GetVisibleRowHandle(i);
                    if (gridView.IsDataRow(rowHandle))
                    {
                        dynamic re = gridView.GetRow(rowHandle);
                        if (!ids.Any(x => x == re.ReturnPositionStateId))
                            selPos.Add(re);
                    }
                }
                foreach (var curItem in selPos)
                    curItem.ReturnPositionStateId = _categoryObj.Id;
                
                /*for (int i = 0; i < gridView.RowCount; i++)
                {
                    int rowHandle = gridView.GetVisibleRowHandle(i);
                    if (gridView.IsDataRow(rowHandle))
                    {
                        dynamic re = gridView.GetRow(rowHandle);
                        //if (re.ReturnReasonId == _categoryObj.AutoReplaceReasonId)
                        
                        if(!ids.Any(x => x == re.ReturnPositionStateId))
                            re.ReturnPositionStateId = _categoryObj.Id;
                    }
                }*/
            }
        }

        private ReturnPosStateObj _categoryObj;

        private void CbModeEditValueChanged(object sender, EventArgs e)
        {
            _categoryObj = ((BarEditItem)sender).EditValue is ReturnPosStateObj ? ((ReturnPosStateObj)(((BarEditItem)sender).EditValue)) : null;
        }

        private void BtCommitItemClick(object sender, ItemClickEventArgs e)
        {         
            if (XtraMessageBox.Show("Сформировать выбранные возвраты?",
                        "Формирование возвратов", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                var list = new List<string>();

                if (treeList.DataSource is ReturnShops)
                {
                    var os = (ReturnShops) treeList.DataSource;
                    foreach (ReturnShopObj shop in os)
                    {
                        var rets = shop.Returns;
                        foreach (var retObj in rets)
                        {
                            var res = retObj.IsCanChangeState();
                            if ((retObj.Checked) && (res))
                            {
                                retObj.CreateReturn();
                                Model.ChangeReturnState(retObj);
                                retObj.Checked = false;

                                var fno = new FindNodeOperation(retObj);
                                treeList.NodesIterator.DoOperation(fno);
                                if (fno.Node != null)
                                    fno.Node.Checked = false;
                            }

                            if (((retObj.Checked) )&&(!res))
                            {
                                list.Add(retObj.ToString());
                            }
                        }
                    }

                    if(list.Count > 0)
                    {   
                        var sb = new StringBuilder();
                        sb.AppendLine(
                            "Некоторые возвраты не были сформированы, т.к. статусы позиций не соответствуют [Согласован НТС] или [Не согласован].");
                        sb.AppendLine(string.Format("Возвраты: {0}", string.Join(",", list)));
                        XtraMessageBox.Show(sb.ToString(), "Формирование возвратов",
                                            MessageBoxButtons.OK);
                    }
                }
            }
        }

        private void TreeListCustomDrawNodeCell(object sender, CustomDrawNodeCellEventArgs e)
        {
            if (e.Node.GetValue(0).GetType().Equals(typeof(ReturnShopObj)))
            {
                e.Appearance.BackColor2 = Color.Empty;

                e.Appearance.BackColor = ((ReturnShopObj)e.CellValue).IsCommitPresent() ? Color.LightGreen : Color.LightPink;

                if (e.Node.Focused)
                {
                    e.Appearance.BackColor2 = Color.White;
                    return;
                }
            }

            if (e.Node.GetValue(0).GetType().Equals(typeof(ReturnObj)))
            {
                e.Appearance.BackColor2 = Color.Empty;

                e.Appearance.BackColor = ((ReturnObj)e.CellValue).ReturnStateId == 2 ? Color.LightGreen : Color.LightPink;

                if (e.Node.Focused)
                {
                    e.Appearance.BackColor2 = Color.White;
                    return;
                }
            }
        }

        private void BarButtonItem1ItemClick(object sender, ItemClickEventArgs e)
        {
            if ((Model.IsAllowRollback()) && (Model.CurrentReturnHeader != null) && (Model.CurrentReturnHeader.ReturnStateId == 2))
            {
                if (XtraMessageBox.Show("Изменить статус возврата на 'Введен'?",
                        "Изменение статуса", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Model.CurrentReturnHeader.ReturnStateId = 1;
                    Model.ChangeReturnState(Model.CurrentReturnHeader);
                    foreach (var item in Model.CurrentReturnHeader.ReturnItems)
                    {
                        item.ReturnPositionStateId = 1;
                    }
                    Model.CurrentReturnHeader.ReturnItems.AllowEdit = Model.CurrentReturnHeader.CanEdit;
                }
            }
            /*
            if((Model.CurrentReturnHeader != null) && (Model.CurrentReturnHeader.ReturnStateId == 3))
            {
                if(XtraMessageBox.Show("Изменить статус возврата на 'Подтвержден'?",
                        "Изменение статуса", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Model.CurrentReturnHeader.ReturnStateId = 2;
                    Model.ChangeReturnState(Model.CurrentReturnHeader);
                    Model.CurrentReturnHeader.ReturnItems.AllowEdit = Model.CurrentReturnHeader.CanEdit;
                }
            }

            if ((Model.CurrentReturnHeader != null) && (Model.CurrentReturnHeader.ReturnStateId == 4))
            {
                if (XtraMessageBox.Show("Изменить статус возврата на 'Сформирован'?",
                        "Изменение статуса", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Model.CurrentReturnHeader.ReturnStateId = 3;
                    Model.ChangeReturnState(Model.CurrentReturnHeader);
                    Model.CurrentReturnHeader.ReturnItems.AllowEdit = Model.CurrentReturnHeader.CanEdit;
                }
            }*/
        }
        private dynamic _resSumm;

        private static string GetTempFolder()
        {
            return Environment.GetEnvironmentVariable("TEMP", EnvironmentVariableTarget.User);
        }

        private void ExportExcel()
        {
            string path = string.Empty;
            try
            {
                
                path = string.Format(@"{0}\ReturnsOut_{1}.xlsx", GetTempFolder(), DateTime.Now.ToFileTime());

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
                        dynamic ret = prc * qty;
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
                    e.TotalValueReady = true;
                }
            }
        }

        private void btExport_ItemClick(object sender, ItemClickEventArgs e)
        {
            colPosState.FilterMode = ColumnFilterMode.DisplayText;
            gridView.ActiveFilterString = "[ReturnPositionStateId] = 'Согласован НТС'";
            try
            {
                ExportExcel();
            }
            finally
            {
                gridView.ActiveFilterString = "";
            }     
        }

        private void GridViewFocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (Model.CurrentReturnHeader != null)
            {
                var view = sender as GridView;
                if (view != null)
                {
                    if (e.FocusedRowHandle >= 0)
                    {
                        var stid = (int) view.GetRowCellValue(e.FocusedRowHandle, "ReturnPositionStateId");
                        var ids =
                            Model.ReturnStatePos.Where(g => g.StateCode == "AGREEDNTS" || g.StateCode == "NOTAGREED").
                                Select(s => s.Id).ToArray();
                        colPosState.ColumnEdit.ReadOnly = ids.Any(x => x == stid);

                        SetLockupState(Model.ReturnStatePos.Where(x => x.Id == stid).Select(x=>x.StateCode).FirstOrDefault());
                    }
                    else
                    {
                        colPosState.ColumnEdit.ReadOnly = false;
                    }
                }
            }
        }

        private string GetFilterStr(IEnumerable<string> states)
        {
            if (states == null)
                return "";

            var sb = new StringBuilder();

            foreach (string state in states)
            {
                foreach (string result in Model.ReturnStatePos.Where(g => g.StateCode == state).Select(s => s.Name))
                {
                    if (sb.Length > 0)
                        sb.Append(" Or ");
                    sb.Append(string.Format("[Name] = '{0}'", result));
                }
            }
            return sb.ToString();
        }
             

        private void SetLockupState(string stid)
        {
            switch (stid)
            {
                case "TOAGREED":
                    lpStatePos.View.ActiveFilterString = GetFilterStr(new[] { "TOAGREED", "AGREEDSALES", "NOTAGREED"  });//"[Name] = 'На согласование' Or [Name] = 'Согласован торговым отделом' Or [Name] = 'Согласован отделом продаж'";
                    break;

                case "AGREEDSALESDEPT":
                    lpStatePos.View.ActiveFilterString = GetFilterStr(new[] { "AGREEDNTS", "NOTAGREED" });//"[Name] = 'Согласован НТС' Or [Name] = 'Не согласован' Or [Name] = 'Согласован торговым отделом' Or [Name] = 'Согласован отделом продаж'";
                    break;

                case "AGREEDSALES":
                    lpStatePos.View.ActiveFilterString = GetFilterStr(new[] {"AGREEDSALESDEPT", "AGREEDSALES", "NOTAGREED"  });//"[Name] = 'Согласован НТС' Or [Name] = 'Не согласован' Or [Name] = 'Согласован торговым отделом' Or [Name] = 'Согласован отделом продаж'";
                    break;


                default:
                    lpStatePos.View.ActiveFilterString = "";
                    break;
            }
        }

        private void LpStatePosEditValueChanged(object sender, EventArgs e)
        {
            var view = (ColumnView)grid.FocusedView;
            if (view != null)
            {
                view.CloseEditor();
                view.UpdateCurrentRow();
                if (view.FocusedRowHandle >= 0)
                {
                    var stid = (int) view.GetRowCellValue(view.FocusedRowHandle, "ReturnPositionStateId");
                    var ids =
                        Model.ReturnStatePos.Where(g => g.StateCode == "AGREEDNTS" || g.StateCode == "NOTAGREED").
                            Select(s => s.Id).ToArray();
                    colPosState.ColumnEdit.ReadOnly = ids.Any(x => x == stid);

                    SetLockupState(
                        Model.ReturnStatePos.Where(x => x.Id == stid).Select(x => x.StateCode).FirstOrDefault());
                }
                else
                {
                    colPosState.ColumnEdit.ReadOnly = false;
                }
            }//view.EditingValue
            //    productsTableAdapter.Update(nwindDataSet.Products);
        }
    }



    public class FindNodeOperation : TreeListOperation
    {
        private ReturnObj _returnObj;
        public FindNodeOperation(ReturnObj obj)
        {
            _returnObj = obj;
        }

        public override void Execute(TreeListNode node)
        {
            var fn = node.GetValue(0);
            if( fn is ReturnObj)
            {
                var ret = (ReturnObj) fn;
                if (ret.Id == _returnObj.Id)
                    nodeCore = node;
            }
        }
        private TreeListNode nodeCore;
        public TreeListNode Node { get { return nodeCore; } }
    }
}