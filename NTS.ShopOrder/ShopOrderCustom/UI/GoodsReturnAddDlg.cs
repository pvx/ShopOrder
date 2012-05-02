using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataBase;
using DataBase.DataObject;
using DevExpress.XtraEditors;
using ShopOrderCustom.Models;

namespace ShopOrderCustom.UI
{
    public partial class GoodsReturnAddDlg : XtraForm
    {
        private GoodsReturnAddModel _model;

        public GoodsReturnAddDlg(GoodsReturnAddModel model)
        {
            InitializeComponent();
            _model = model;
            InitData();
        }

        private void InitData()
        {
            //cbGoods.Properties.DataSource = _model.GetInvoiceData();
            cbReason.Properties.DataSource = _model.GetReasonData();
            cbGoodsLk.Properties.DataSource = _model.GetInvoiceData();
            if(_model.IsEdit)
            {
                if(_model.EdititItem != null)
                {
                    Text = @"Редактирование позиции возврата";
                    cbGoodsLk.EditValue = _model.EdititItem.id_Invoice;
                    //cbGoods.Properties.KeyValue = _model.EdititItem;
                    var rd = (ReasonData)cbReason.Properties.DataSource;
                    cbReason.Properties.KeyValue = rd.Where(x => x.id == _model.EdititItem.ReturnReasonId).SingleOrDefault();
                    edQuantity.Value = decimal.Parse(_model.EdititItem.QuantityRet.ToString());
                }
            }
        }

        private void GoodsReturnAddDlgFormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult == DialogResult.OK)
            {    
                e.Cancel = !ValidateData();
                if(!e.Cancel)
                {
                    var ds = (InvoiceData)((SearchLookUpEdit)cbGoodsLk).Properties.DataSource;
                    if (cbGoodsLk.EditValue != null)
                    {
                        var item = ds.Where(x => x.id_Invoice == (int) cbGoodsLk.EditValue).SingleOrDefault();
                        var ret = (sp_sel_InvoiceDataForReturnResult) item;
                        var reason = (sp_sel_ReturnReasonsResult) cbReason.Properties.KeyValue;
                        //r.id_Invoice
                        _model.SetSelReturn(ret, reason, edQuantity.Value);
                        // cbGoods.ItemIndex
                    }
                }
            }
            
        }
        
        private bool ValidateData()
        {
            bool ret = true;

            ret = ((cbGoodsLk.EditValue == null) || (cbGoodsLk.EditValue == "Не выбран"));
            if(ret)
            {
                cbGoodsLk.Focus();
                //XtraMessageBox.Show("Не выбрана товарная позиция возврата");
                lbMsg.Text = "Не выбрана товарная позиция возврата";
                return !ret;
            }

            ret = edQuantity.Value > 0;
            if (!ret)
            {
                edQuantity.Focus();
                lbMsg.Text = ("Не указано количество к возврату");
                return ret;}          

            ret = cbReason.ItemIndex != -1;
            if (!ret)
            {
                cbReason.Focus();
                lbMsg.Text = ("Не выбрана причина возврата");
                return ret;
            }
            return ret;
        }

        private void cbGoods_EditValueChanged(object sender, EventArgs e)
        {
            /*edQuantity.Properties.MaxValue =
                decimal.Parse(
                    ((sp_sel_InvoiceDataForReturnResult) (((LookUpEdit) (sender)).Properties.KeyValue)).Quantity.
                        ToString());
            edQuantity.Enabled = edQuantity.Properties.MaxValue > 0;
            */
        }

        private void cbReason_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void edQuantity_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {

        }

        private void CbBarcodeCheckedChanged(object sender, EventArgs e)
        {
            //cbGoods.Properties.AutoSearchColumnIndex = 8;
        }

        private void CbGoodsNameCheckedChanged(object sender, EventArgs e)
        {
            //cbGoods.Properties.AutoSearchColumnIndex = 5;
        }

        private void CbSupplierCheckedChanged(object sender, EventArgs e)
        {
            //cbGoods.Properties.AutoSearchColumnIndex = 7;
        }

        private void GoodsReturnAddDlg_Load(object sender, EventArgs e)
        {
            cbGoodsLk.Focus();
        }

        private void GoodsReturnAddDlg_Shown(object sender, EventArgs e)
        {
            cbGoodsLk.Focus();
        }

        private void GoodsReturnAddDlg_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void CbGoodsLkEditValueChanged(object sender, EventArgs e)
        {
            var ds = (InvoiceData) ((SearchLookUpEdit) sender).Properties.DataSource;
            if (cbGoodsLk.EditValue != null)
            {
                var item = ds.Where(x => x.id_Invoice == (int) cbGoodsLk.EditValue).SingleOrDefault();
                if (item != null)
                {
                    edQuantity.Properties.MaxValue = decimal.Parse(item.Quantity.ToString());
                    edQuantity.Enabled = edQuantity.Properties.MaxValue > 0;
                }
            }
        }
    }
}