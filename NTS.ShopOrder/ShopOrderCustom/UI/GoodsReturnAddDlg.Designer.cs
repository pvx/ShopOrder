namespace ShopOrderCustom.UI
{
    partial class GoodsReturnAddDlg
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.cbGoodsLk = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.cbSupplier = new DevExpress.XtraEditors.CheckEdit();
            this.cbGoodsName = new DevExpress.XtraEditors.CheckEdit();
            this.cbBarcode = new DevExpress.XtraEditors.CheckEdit();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.lbMsg = new DevExpress.XtraEditors.LabelControl();
            this.btCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btOk = new DevExpress.XtraEditors.SimpleButton();
            this.cbReason = new DevExpress.XtraEditors.LookUpEdit();
            this.edQuantity = new DevExpress.XtraEditors.SpinEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.colQuantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInvoiceDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSeria = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBarcode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSupplier = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGroup = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbGoodsLk.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbSupplier.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbGoodsName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbBarcode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbReason.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edQuantity.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.cbGoodsLk);
            this.layoutControl1.Controls.Add(this.panelControl2);
            this.layoutControl1.Controls.Add(this.panelControl1);
            this.layoutControl1.Controls.Add(this.cbReason);
            this.layoutControl1.Controls.Add(this.edQuantity);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(658, 377, 250, 350);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(796, 134);
            this.layoutControl1.TabIndex = 1;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // cbGoodsLk
            // 
            this.cbGoodsLk.EditValue = "Не выбран";
            this.cbGoodsLk.Location = new System.Drawing.Point(109, 36);
            this.cbGoodsLk.Name = "cbGoodsLk";
            this.cbGoodsLk.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbGoodsLk.Properties.DisplayMember = "Name";
            this.cbGoodsLk.Properties.NullText = "[Не выбран]";
            this.cbGoodsLk.Properties.PopupFormMinSize = new System.Drawing.Size(680, 0);
            this.cbGoodsLk.Properties.PopupResizeMode = DevExpress.XtraEditors.Controls.ResizeMode.LiveResize;
            this.cbGoodsLk.Properties.ValueMember = "id_Invoice";
            this.cbGoodsLk.Properties.View = this.searchLookUpEdit1View;
            this.cbGoodsLk.Size = new System.Drawing.Size(675, 20);
            this.cbGoodsLk.StyleController = this.layoutControl1;
            this.cbGoodsLk.TabIndex = 3;
            this.cbGoodsLk.EditValueChanged += new System.EventHandler(this.CbGoodsLkEditValueChanged);
            // 
            // searchLookUpEdit1View
            // 
            this.searchLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colQuantity,
            this.colInvoiceDate,
            this.colPrice,
            this.colNumber,
            this.colSeria,
            this.colName,
            this.colBarcode,
            this.colSupplier,
            this.colGroup});
            this.searchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpEdit1View.Name = "searchLookUpEdit1View";
            this.searchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpEdit1View.OptionsView.ShowAutoFilterRow = true;
            this.searchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.cbSupplier);
            this.panelControl2.Controls.Add(this.cbGoodsName);
            this.panelControl2.Controls.Add(this.cbBarcode);
            this.panelControl2.Location = new System.Drawing.Point(12, 12);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(772, 20);
            this.panelControl2.TabIndex = 4;
            // 
            // cbSupplier
            // 
            this.cbSupplier.Location = new System.Drawing.Point(350, 1);
            this.cbSupplier.Name = "cbSupplier";
            this.cbSupplier.Properties.AllowFocused = false;
            this.cbSupplier.Properties.Caption = "Поставщик";
            this.cbSupplier.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio;
            this.cbSupplier.Properties.RadioGroupIndex = 1;
            this.cbSupplier.Size = new System.Drawing.Size(90, 19);
            this.cbSupplier.TabIndex = 2;
            this.cbSupplier.TabStop = false;
            this.cbSupplier.Visible = false;
            this.cbSupplier.CheckedChanged += new System.EventHandler(this.CbSupplierCheckedChanged);
            // 
            // cbGoodsName
            // 
            this.cbGoodsName.Location = new System.Drawing.Point(147, 1);
            this.cbGoodsName.Name = "cbGoodsName";
            this.cbGoodsName.Properties.AllowFocused = false;
            this.cbGoodsName.Properties.Caption = "Наименование товара";
            this.cbGoodsName.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio;
            this.cbGoodsName.Properties.RadioGroupIndex = 1;
            this.cbGoodsName.Size = new System.Drawing.Size(138, 19);
            this.cbGoodsName.TabIndex = 1;
            this.cbGoodsName.TabStop = false;
            this.cbGoodsName.Visible = false;
            this.cbGoodsName.CheckedChanged += new System.EventHandler(this.CbGoodsNameCheckedChanged);
            // 
            // cbBarcode
            // 
            this.cbBarcode.EditValue = true;
            this.cbBarcode.Location = new System.Drawing.Point(5, 1);
            this.cbBarcode.Name = "cbBarcode";
            this.cbBarcode.Properties.AllowFocused = false;
            this.cbBarcode.Properties.Caption = "Штрих-код";
            this.cbBarcode.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio;
            this.cbBarcode.Properties.RadioGroupIndex = 1;
            this.cbBarcode.Size = new System.Drawing.Size(84, 19);
            this.cbBarcode.TabIndex = 0;
            this.cbBarcode.Visible = false;
            this.cbBarcode.CheckedChanged += new System.EventHandler(this.CbBarcodeCheckedChanged);
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.lbMsg);
            this.panelControl1.Controls.Add(this.btCancel);
            this.panelControl1.Controls.Add(this.btOk);
            this.panelControl1.Location = new System.Drawing.Point(12, 84);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(772, 38);
            this.panelControl1.TabIndex = 3;
            // 
            // lbMsg
            // 
            this.lbMsg.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lbMsg.Location = new System.Drawing.Point(7, 12);
            this.lbMsg.Name = "lbMsg";
            this.lbMsg.Size = new System.Drawing.Size(0, 13);
            this.lbMsg.TabIndex = 2;
            // 
            // btCancel
            // 
            this.btCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCancel.Location = new System.Drawing.Point(609, 10);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(75, 23);
            this.btCancel.TabIndex = 1;
            this.btCancel.Text = "Отмена";
            // 
            // btOk
            // 
            this.btOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btOk.Location = new System.Drawing.Point(690, 10);
            this.btOk.Name = "btOk";
            this.btOk.Size = new System.Drawing.Size(75, 23);
            this.btOk.TabIndex = 0;
            this.btOk.Text = "Сохранить";
            // 
            // cbReason
            // 
            this.cbReason.Location = new System.Drawing.Point(330, 60);
            this.cbReason.Name = "cbReason";
            this.cbReason.Properties.AutoSearchColumnIndex = 1;
            this.cbReason.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.cbReason.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbReason.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", 40, "Причина")});
            this.cbReason.Properties.NullText = "";
            this.cbReason.Properties.PopupSizeable = false;
            this.cbReason.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoComplete;
            this.cbReason.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.cbReason.Size = new System.Drawing.Size(454, 20);
            this.cbReason.StyleController = this.layoutControl1;
            this.cbReason.TabIndex = 2;
            this.cbReason.EditValueChanged += new System.EventHandler(this.cbReason_EditValueChanged);
            // 
            // edQuantity
            // 
            this.edQuantity.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.edQuantity.Location = new System.Drawing.Point(109, 60);
            this.edQuantity.Name = "edQuantity";
            this.edQuantity.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.edQuantity.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Default;
            this.edQuantity.Properties.Mask.EditMask = "d";
            this.edQuantity.Size = new System.Drawing.Size(120, 20);
            this.edQuantity.StyleController = this.layoutControl1;
            this.edQuantity.TabIndex = 1;
            this.edQuantity.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.edQuantity_EditValueChanging);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.layoutControlItem5,
            this.layoutControlItem1});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(796, 134);
            this.layoutControlGroup1.Text = "Root";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // colQuantity
            // 
            this.colQuantity.Caption = "Количество";
            this.colQuantity.FieldName = "Quantity";
            this.colQuantity.MinWidth = 50;
            this.colQuantity.Name = "colQuantity";
            this.colQuantity.Visible = true;
            this.colQuantity.VisibleIndex = 0;
            this.colQuantity.Width = 86;
            // 
            // colInvoiceDate
            // 
            this.colInvoiceDate.Caption = "Дата прихода";
            this.colInvoiceDate.FieldName = "InvoiceDate";
            this.colInvoiceDate.MinWidth = 80;
            this.colInvoiceDate.Name = "colInvoiceDate";
            this.colInvoiceDate.Visible = true;
            this.colInvoiceDate.VisibleIndex = 1;
            this.colInvoiceDate.Width = 86;
            // 
            // colPrice
            // 
            this.colPrice.Caption = "Цена";
            this.colPrice.FieldName = "Price";
            this.colPrice.MinWidth = 80;
            this.colPrice.Name = "colPrice";
            this.colPrice.Visible = true;
            this.colPrice.VisibleIndex = 2;
            this.colPrice.Width = 90;
            // 
            // colNumber
            // 
            this.colNumber.Caption = "ТТН №";
            this.colNumber.FieldName = "Number";
            this.colNumber.MinWidth = 80;
            this.colNumber.Name = "colNumber";
            this.colNumber.Visible = true;
            this.colNumber.VisibleIndex = 3;
            this.colNumber.Width = 108;
            // 
            // colSeria
            // 
            this.colSeria.Caption = "Серия";
            this.colSeria.FieldName = "Seria";
            this.colSeria.MinWidth = 40;
            this.colSeria.Name = "colSeria";
            this.colSeria.Visible = true;
            this.colSeria.VisibleIndex = 4;
            this.colSeria.Width = 45;
            // 
            // colName
            // 
            this.colName.Caption = "Товар";
            this.colName.FieldName = "Name";
            this.colName.MinWidth = 180;
            this.colName.Name = "colName";
            this.colName.Visible = true;
            this.colName.VisibleIndex = 5;
            this.colName.Width = 373;
            // 
            // colBarcode
            // 
            this.colBarcode.Caption = "Штрихкод";
            this.colBarcode.FieldName = "Barcode";
            this.colBarcode.MinWidth = 80;
            this.colBarcode.Name = "colBarcode";
            this.colBarcode.Visible = true;
            this.colBarcode.VisibleIndex = 6;
            this.colBarcode.Width = 293;
            // 
            // colSupplier
            // 
            this.colSupplier.Caption = "Поставщик";
            this.colSupplier.FieldName = "Supplier";
            this.colSupplier.MinWidth = 80;
            this.colSupplier.Name = "colSupplier";
            this.colSupplier.Visible = true;
            this.colSupplier.VisibleIndex = 7;
            this.colSupplier.Width = 147;
            // 
            // colGroup
            // 
            this.colGroup.Caption = "Группа";
            this.colGroup.FieldName = "Group";
            this.colGroup.MinWidth = 80;
            this.colGroup.Name = "colGroup";
            this.colGroup.Visible = true;
            this.colGroup.VisibleIndex = 8;
            this.colGroup.Width = 186;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.edQuantity;
            this.layoutControlItem2.CustomizationFormText = "Количество";
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 48);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(221, 24);
            this.layoutControlItem2.Text = "Количество";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(93, 13);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.panelControl1;
            this.layoutControlItem3.CustomizationFormText = "layoutControlItem3";
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 72);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(776, 42);
            this.layoutControlItem3.Text = "layoutControlItem3";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextToControlDistance = 0;
            this.layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.cbReason;
            this.layoutControlItem4.CustomizationFormText = "Причина возврата";
            this.layoutControlItem4.Location = new System.Drawing.Point(221, 48);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(555, 24);
            this.layoutControlItem4.Text = "Причина возврата";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(93, 13);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.panelControl2;
            this.layoutControlItem5.CustomizationFormText = "layoutControlItem5";
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(776, 24);
            this.layoutControlItem5.Text = "layoutControlItem5";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextToControlDistance = 0;
            this.layoutControlItem5.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.cbGoodsLk;
            this.layoutControlItem1.CustomizationFormText = "Товар";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(776, 24);
            this.layoutControlItem1.Text = "Товар";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(93, 13);
            // 
            // GoodsReturnAddDlg
            // 
            this.AcceptButton = this.btOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btCancel;
            this.ClientSize = new System.Drawing.Size(796, 134);
            this.Controls.Add(this.layoutControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.Name = "GoodsReturnAddDlg";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Новая позиция возврата";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GoodsReturnAddDlgFormClosing);
            this.Load += new System.EventHandler(this.GoodsReturnAddDlg_Load);
            this.Shown += new System.EventHandler(this.GoodsReturnAddDlg_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GoodsReturnAddDlg_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cbGoodsLk.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cbSupplier.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbGoodsName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbBarcode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbReason.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edQuantity.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btCancel;
        private DevExpress.XtraEditors.SimpleButton btOk;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraEditors.LookUpEdit cbReason;
        private DevExpress.XtraEditors.SpinEdit edQuantity;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraEditors.CheckEdit cbSupplier;
        private DevExpress.XtraEditors.CheckEdit cbGoodsName;
        private DevExpress.XtraEditors.CheckEdit cbBarcode;
        private DevExpress.XtraEditors.LabelControl lbMsg;
        private DevExpress.XtraEditors.SearchLookUpEdit cbGoodsLk;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colGroup;
        private DevExpress.XtraGrid.Columns.GridColumn colQuantity;
        private DevExpress.XtraGrid.Columns.GridColumn colInvoiceDate;
        private DevExpress.XtraGrid.Columns.GridColumn colPrice;
        private DevExpress.XtraGrid.Columns.GridColumn colNumber;
        private DevExpress.XtraGrid.Columns.GridColumn colSeria;
        private DevExpress.XtraGrid.Columns.GridColumn colSupplier;
        private DevExpress.XtraGrid.Columns.GridColumn colBarcode;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
    }
}