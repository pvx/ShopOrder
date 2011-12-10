namespace ShopOrderCustom.UI
{
    partial class AssortimentForm
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
            this.components = new System.ComponentModel.Container();
            DevExpress.Utils.SuperToolTip superToolTip1 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem1 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem1 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip2 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem2 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem2 = new DevExpress.Utils.ToolTipItem();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AssortimentForm));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.grid = new DevExpress.XtraGrid.GridControl();
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGroup = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colQuantityInPack = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMeasure = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSupplier = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBarcode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colReserved = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFreeBalance = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMinOrder = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAssortReq = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.repositoryItemSpinEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.BarManager = new DevExpress.ExpressApp.Win.Templates.Controls.XafBarManager(this.components);
            this.xafBar2 = new DevExpress.ExpressApp.Win.Templates.Controls.XafBar();
            this.xafBar3 = new DevExpress.ExpressApp.Win.Templates.Controls.XafBar();
            this.cbCategory = new DevExpress.XtraBars.BarEditItem();
            this.cbRepCategory = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.btClear = new DevExpress.XtraBars.BarButtonItem();
            this.btImport = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BarManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbRepCategory)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.grid);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 47);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(823, 430);
            this.panelControl1.TabIndex = 5;
            // 
            // grid
            // 
            this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid.Location = new System.Drawing.Point(2, 2);
            this.grid.MainView = this.gridView;
            this.grid.Name = "grid";
            this.grid.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemSpinEdit1,
            this.repositoryItemCheckEdit1});
            this.grid.Size = new System.Drawing.Size(819, 426);
            this.grid.TabIndex = 1;
            this.grid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView});
            // 
            // gridView
            // 
            this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colid,
            this.colGroup,
            this.colName,
            this.colPrice,
            this.colQuantityInPack,
            this.colMeasure,
            this.colSupplier,
            this.colCode,
            this.colBarcode,
            this.colReserved,
            this.colFreeBalance,
            this.colMinOrder,
            this.colAssortReq});
            this.gridView.GridControl = this.grid;
            this.gridView.Name = "gridView";
            this.gridView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView.OptionsView.ShowAutoFilterRow = true;
            this.gridView.OptionsView.ShowFooter = true;
            this.gridView.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colName, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // colid
            // 
            this.colid.FieldName = "id";
            this.colid.Name = "colid";
            this.colid.OptionsColumn.AllowEdit = false;
            this.colid.OptionsColumn.AllowFocus = false;
            this.colid.OptionsColumn.ReadOnly = true;
            this.colid.Width = 27;
            // 
            // colGroup
            // 
            this.colGroup.Caption = "Группа товара";
            this.colGroup.FieldName = "Group";
            this.colGroup.Name = "colGroup";
            this.colGroup.OptionsColumn.AllowEdit = false;
            this.colGroup.OptionsColumn.AllowFocus = false;
            this.colGroup.OptionsColumn.ReadOnly = true;
            this.colGroup.Visible = true;
            this.colGroup.VisibleIndex = 2;
            this.colGroup.Width = 100;
            // 
            // colName
            // 
            this.colName.Caption = "Название";
            this.colName.FieldName = "Name";
            this.colName.Name = "colName";
            this.colName.OptionsColumn.AllowEdit = false;
            this.colName.OptionsColumn.AllowFocus = false;
            this.colName.OptionsColumn.ReadOnly = true;
            this.colName.Visible = true;
            this.colName.VisibleIndex = 1;
            this.colName.Width = 120;
            // 
            // colPrice
            // 
            this.colPrice.Caption = "Цена";
            this.colPrice.FieldName = "Price";
            this.colPrice.Name = "colPrice";
            this.colPrice.OptionsColumn.AllowEdit = false;
            this.colPrice.OptionsColumn.AllowFocus = false;
            this.colPrice.OptionsColumn.ReadOnly = true;
            this.colPrice.Visible = true;
            this.colPrice.VisibleIndex = 3;
            this.colPrice.Width = 50;
            // 
            // colQuantityInPack
            // 
            this.colQuantityInPack.Caption = "Кол. в упаковке";
            this.colQuantityInPack.FieldName = "QuantityInPack";
            this.colQuantityInPack.Name = "colQuantityInPack";
            this.colQuantityInPack.OptionsColumn.AllowEdit = false;
            this.colQuantityInPack.OptionsColumn.AllowFocus = false;
            this.colQuantityInPack.OptionsColumn.ReadOnly = true;
            this.colQuantityInPack.Width = 27;
            // 
            // colMeasure
            // 
            this.colMeasure.Caption = "Ед. изм. (шт/упак.)";
            this.colMeasure.FieldName = "Measure";
            this.colMeasure.Name = "colMeasure";
            this.colMeasure.OptionsColumn.AllowEdit = false;
            this.colMeasure.OptionsColumn.AllowFocus = false;
            this.colMeasure.OptionsColumn.ReadOnly = true;
            this.colMeasure.Visible = true;
            this.colMeasure.VisibleIndex = 4;
            this.colMeasure.Width = 50;
            // 
            // colSupplier
            // 
            this.colSupplier.Caption = "Поставщик";
            this.colSupplier.FieldName = "Supplier";
            this.colSupplier.Name = "colSupplier";
            this.colSupplier.OptionsColumn.AllowEdit = false;
            this.colSupplier.OptionsColumn.AllowFocus = false;
            this.colSupplier.OptionsColumn.ReadOnly = true;
            this.colSupplier.Visible = true;
            this.colSupplier.VisibleIndex = 5;
            this.colSupplier.Width = 100;
            // 
            // colCode
            // 
            this.colCode.Caption = "Код товара";
            this.colCode.FieldName = "Code";
            this.colCode.Name = "colCode";
            this.colCode.OptionsColumn.AllowEdit = false;
            this.colCode.OptionsColumn.AllowFocus = false;
            this.colCode.OptionsColumn.ReadOnly = true;
            this.colCode.Width = 27;
            // 
            // colBarcode
            // 
            this.colBarcode.Caption = "Штрихкод";
            this.colBarcode.FieldName = "Barcode";
            this.colBarcode.Name = "colBarcode";
            this.colBarcode.OptionsColumn.AllowEdit = false;
            this.colBarcode.OptionsColumn.AllowFocus = false;
            this.colBarcode.OptionsColumn.ReadOnly = true;
            this.colBarcode.Visible = true;
            this.colBarcode.VisibleIndex = 6;
            this.colBarcode.Width = 50;
            // 
            // colReserved
            // 
            this.colReserved.FieldName = "Reserved";
            this.colReserved.Name = "colReserved";
            this.colReserved.OptionsColumn.AllowEdit = false;
            this.colReserved.OptionsColumn.AllowFocus = false;
            this.colReserved.OptionsColumn.ReadOnly = true;
            this.colReserved.Width = 27;
            // 
            // colFreeBalance
            // 
            this.colFreeBalance.FieldName = "FreeBalance";
            this.colFreeBalance.Name = "colFreeBalance";
            this.colFreeBalance.OptionsColumn.AllowEdit = false;
            this.colFreeBalance.OptionsColumn.AllowFocus = false;
            this.colFreeBalance.OptionsColumn.ReadOnly = true;
            this.colFreeBalance.Width = 33;
            // 
            // colMinOrder
            // 
            this.colMinOrder.Caption = "Минимальный заказ";
            this.colMinOrder.FieldName = "MinOrder";
            this.colMinOrder.MaxWidth = 100;
            this.colMinOrder.Name = "colMinOrder";
            this.colMinOrder.OptionsColumn.AllowEdit = false;
            this.colMinOrder.OptionsColumn.AllowFocus = false;
            this.colMinOrder.OptionsColumn.ReadOnly = true;
            this.colMinOrder.Width = 100;
            // 
            // colAssortReq
            // 
            this.colAssortReq.Caption = "Обязательный";
            this.colAssortReq.ColumnEdit = this.repositoryItemCheckEdit1;
            this.colAssortReq.FieldName = "ReqAssort";
            this.colAssortReq.Name = "colAssortReq";
            this.colAssortReq.Visible = true;
            this.colAssortReq.VisibleIndex = 0;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // repositoryItemSpinEdit1
            // 
            this.repositoryItemSpinEdit1.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.repositoryItemSpinEdit1.AutoHeight = false;
            this.repositoryItemSpinEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.repositoryItemSpinEdit1.IsFloatValue = false;
            this.repositoryItemSpinEdit1.Mask.EditMask = "N00";
            this.repositoryItemSpinEdit1.MaxValue = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.repositoryItemSpinEdit1.Name = "repositoryItemSpinEdit1";
            // 
            // BarManager
            // 
            this.BarManager.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.xafBar2,
            this.xafBar3});
            this.BarManager.Categories.AddRange(new DevExpress.XtraBars.BarManagerCategory[] {
            new DevExpress.XtraBars.BarManagerCategory("Заказы", new System.Guid("f4698afc-915d-46b6-b4ad-e497d23d7378"))});
            this.BarManager.DockControls.Add(this.barDockControlTop);
            this.BarManager.DockControls.Add(this.barDockControlBottom);
            this.BarManager.DockControls.Add(this.barDockControlLeft);
            this.BarManager.DockControls.Add(this.barDockControlRight);
            this.BarManager.Form = this;
            this.BarManager.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.cbCategory,
            this.barButtonItem1,
            this.btImport,
            this.btClear});
            this.BarManager.MaxItemId = 13;
            this.BarManager.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.cbRepCategory});
            this.BarManager.StatusBar = this.xafBar2;
            // 
            // xafBar2
            // 
            this.xafBar2.BarName = "StatusBar";
            this.xafBar2.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.xafBar2.DockCol = 0;
            this.xafBar2.DockRow = 0;
            this.xafBar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.xafBar2.OptionsBar.AllowQuickCustomization = false;
            this.xafBar2.OptionsBar.DrawDragBorder = false;
            this.xafBar2.OptionsBar.UseWholeRow = true;
            this.xafBar2.TargetPageCategoryColor = System.Drawing.Color.Empty;
            this.xafBar2.Text = "StatusBar";
            // 
            // xafBar3
            // 
            this.xafBar3.BarName = "Main Toolbar";
            this.xafBar3.DockCol = 0;
            this.xafBar3.DockRow = 0;
            this.xafBar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.xafBar3.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.cbCategory, DevExpress.XtraBars.BarItemPaintStyle.Caption),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonItem1, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btClear, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btImport, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.xafBar3.TargetPageCategoryColor = System.Drawing.Color.Empty;
            this.xafBar3.Text = "Main Toolbar";
            // 
            // cbCategory
            // 
            this.cbCategory.Caption = "Категория магазина";
            this.cbCategory.Edit = this.cbRepCategory;
            this.cbCategory.Id = 9;
            this.cbCategory.Name = "cbCategory";
            this.cbCategory.Width = 171;
            this.cbCategory.EditValueChanged += new System.EventHandler(this.CbCategoryEditValueChanged);
            // 
            // cbRepCategory
            // 
            this.cbRepCategory.AutoComplete = false;
            this.cbRepCategory.AutoHeight = false;
            this.cbRepCategory.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbRepCategory.Name = "cbRepCategory";
            this.cbRepCategory.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "Сохранить";
            this.barButtonItem1.Glyph = global::ShopOrderCustom.Properties.Resources.filesaveas;
            this.barButtonItem1.Id = 10;
            this.barButtonItem1.Name = "barButtonItem1";
            this.barButtonItem1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BarButtonItem1ItemClick);
            // 
            // btClear
            // 
            this.btClear.Caption = "Очистить";
            this.btClear.Enabled = false;
            this.btClear.Glyph = global::ShopOrderCustom.Properties.Resources.edit_clear;
            this.btClear.Id = 12;
            this.btClear.Name = "btClear";
            toolTipTitleItem1.Appearance.Image = global::ShopOrderCustom.Properties.Resources.edit_clear;
            toolTipTitleItem1.Appearance.Options.UseImage = true;
            toolTipTitleItem1.Image = global::ShopOrderCustom.Properties.Resources.edit_clear;
            toolTipTitleItem1.Text = "Очистить все отмеченные позиции";
            toolTipItem1.LeftIndent = 6;
            toolTipItem1.Text = "Очищает все отмеченные позиции у выбранной категории магазина";
            superToolTip1.Items.Add(toolTipTitleItem1);
            superToolTip1.Items.Add(toolTipItem1);
            this.btClear.SuperTip = superToolTip1;
            this.btClear.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BarButtonItem3ItemClick);
            // 
            // btImport
            // 
            this.btImport.Caption = "Импорт";
            this.btImport.Enabled = false;
            this.btImport.Glyph = global::ShopOrderCustom.Properties.Resources.Excel_icon;
            this.btImport.Id = 11;
            this.btImport.Name = "btImport";
            toolTipTitleItem2.Appearance.Image = global::ShopOrderCustom.Properties.Resources.Excel_icon;
            toolTipTitleItem2.Appearance.Options.UseImage = true;
            toolTipTitleItem2.Image = global::ShopOrderCustom.Properties.Resources.Excel_icon;
            toolTipTitleItem2.Text = "Импорт ассортимента из Excel";
            toolTipItem2.LeftIndent = 6;
            toolTipItem2.Text = "Позиции, загруженные из файла, ДОБАВЛЯЮТСЯ к уже отмеченным позициям в списке";
            superToolTip2.Items.Add(toolTipTitleItem2);
            superToolTip2.Items.Add(toolTipItem2);
            this.btImport.SuperTip = superToolTip2;
            this.btImport.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BarButtonItem2ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(823, 47);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 477);
            this.barDockControlBottom.Size = new System.Drawing.Size(823, 23);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 47);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 430);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(823, 47);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 430);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            this.openFileDialog.Filter = "Excel|*.xls";
            // 
            // AssortimentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(823, 500);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AssortimentForm";
            this.Text = "Обязательный ассортимент";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AssortimentForm_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BarManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbRepCategory)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraGrid.GridControl grid;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private DevExpress.XtraGrid.Columns.GridColumn colid;
        private DevExpress.XtraGrid.Columns.GridColumn colGroup;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colPrice;
        private DevExpress.XtraGrid.Columns.GridColumn colQuantityInPack;
        private DevExpress.XtraGrid.Columns.GridColumn colMeasure;
        private DevExpress.XtraGrid.Columns.GridColumn colSupplier;
        private DevExpress.XtraGrid.Columns.GridColumn colCode;
        private DevExpress.XtraGrid.Columns.GridColumn colBarcode;
        private DevExpress.XtraGrid.Columns.GridColumn colReserved;
        private DevExpress.XtraGrid.Columns.GridColumn colFreeBalance;
        private DevExpress.XtraGrid.Columns.GridColumn colMinOrder;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit repositoryItemSpinEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn colAssortReq;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.ExpressApp.Win.Templates.Controls.XafBarManager BarManager;
        private DevExpress.ExpressApp.Win.Templates.Controls.XafBar xafBar2;
        private DevExpress.ExpressApp.Win.Templates.Controls.XafBar xafBar3;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarEditItem cbCategory;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox cbRepCategory;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarButtonItem btImport;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private DevExpress.XtraBars.BarButtonItem btClear;
    }
}