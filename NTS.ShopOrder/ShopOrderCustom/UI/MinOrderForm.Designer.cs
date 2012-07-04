namespace ShopOrderCustom
{
    partial class MinOrderForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MinOrderForm));
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
            this.colSAPMinOrder = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMinOrder = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemSpinEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.BarManager = new DevExpress.ExpressApp.Win.Templates.Controls.XafBarManager(this.components);
            this.xafBar2 = new DevExpress.ExpressApp.Win.Templates.Controls.XafBar();
            this.xafBar3 = new DevExpress.ExpressApp.Win.Templates.Controls.XafBar();
            this.cbCategory = new DevExpress.XtraBars.BarEditItem();
            this.cbRepCategory = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.btRefresh = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.btClear = new DevExpress.XtraBars.BarButtonItem();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BarManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbRepCategory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.grid);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 47);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(769, 401);
            this.panelControl1.TabIndex = 4;
            // 
            // grid
            // 
            this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid.Location = new System.Drawing.Point(2, 2);
            this.grid.MainView = this.gridView;
            this.grid.Name = "grid";
            this.grid.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemSpinEdit1,
            this.repositoryItemTextEdit1});
            this.grid.Size = new System.Drawing.Size(765, 397);
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
            this.colSAPMinOrder,
            this.colMinOrder});
            this.gridView.GridControl = this.grid;
            this.gridView.Name = "gridView";
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
            // colSAPMinOrder
            // 
            this.colSAPMinOrder.Caption = "Мин. заказ SAP";
            this.colSAPMinOrder.FieldName = "SAPMinOrder";
            this.colSAPMinOrder.Name = "colSAPMinOrder";
            this.colSAPMinOrder.OptionsColumn.AllowEdit = false;
            this.colSAPMinOrder.OptionsColumn.AllowFocus = false;
            this.colSAPMinOrder.OptionsColumn.ReadOnly = true;
            this.colSAPMinOrder.Visible = true;
            this.colSAPMinOrder.VisibleIndex = 7;
            this.colSAPMinOrder.Width = 33;
            // 
            // colMinOrder
            // 
            this.colMinOrder.AppearanceCell.BackColor = System.Drawing.Color.CornflowerBlue;
            this.colMinOrder.AppearanceCell.Options.UseBackColor = true;
            this.colMinOrder.Caption = "Минимальный заказ";
            this.colMinOrder.ColumnEdit = this.repositoryItemTextEdit1;
            this.colMinOrder.FieldName = "MinOrder";
            this.colMinOrder.MaxWidth = 100;
            this.colMinOrder.Name = "colMinOrder";
            this.colMinOrder.Visible = true;
            this.colMinOrder.VisibleIndex = 0;
            this.colMinOrder.Width = 100;
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
            this.btClear,
            this.btRefresh});
            this.BarManager.MaxItemId = 14;
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
            new DevExpress.XtraBars.LinkPersistInfo(this.btRefresh, true)});
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
            // btRefresh
            // 
            this.btRefresh.Caption = "Обновить";
            this.btRefresh.Glyph = global::ShopOrderCustom.Properties.Resources.reload_all_tabs;
            this.btRefresh.Id = 13;
            this.btRefresh.Name = "btRefresh";
            this.btRefresh.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BtRefreshItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(769, 47);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 448);
            this.barDockControlBottom.Size = new System.Drawing.Size(769, 23);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 47);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 401);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(769, 47);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 401);
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
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.Mask.EditMask = "n";
            this.repositoryItemTextEdit1.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            // 
            // MinOrderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(769, 471);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MinOrderForm";
            this.Text = "Минимальный заказ";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MinOrderFormFormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BarManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbRepCategory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraGrid.GridControl grid;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit repositoryItemSpinEdit1;
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
        private DevExpress.XtraGrid.Columns.GridColumn colSAPMinOrder;
        private DevExpress.XtraGrid.Columns.GridColumn colMinOrder;
        private DevExpress.ExpressApp.Win.Templates.Controls.XafBarManager BarManager;
        private DevExpress.ExpressApp.Win.Templates.Controls.XafBar xafBar2;
        private DevExpress.ExpressApp.Win.Templates.Controls.XafBar xafBar3;
        private DevExpress.XtraBars.BarEditItem cbCategory;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox cbRepCategory;
        private DevExpress.XtraBars.BarButtonItem btClear;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem btRefresh;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
    }
}