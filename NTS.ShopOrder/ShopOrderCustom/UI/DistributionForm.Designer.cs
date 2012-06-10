namespace ShopOrderCustom.UI
{
    partial class DistributionForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DistributionForm));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.BarManager = new DevExpress.ExpressApp.Win.Templates.Controls.XafBarManager(this.components);
            this.xafBar2 = new DevExpress.ExpressApp.Win.Templates.Controls.XafBar();
            this.xafBar3 = new DevExpress.ExpressApp.Win.Templates.Controls.XafBar();
            this.cbCategory = new DevExpress.XtraBars.BarEditItem();
            this.cbRepCategory = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.btSave = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.treeList = new DevExpress.XtraTreeList.TreeList();
            this.treeListColumn1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.grid = new DevExpress.XtraGrid.GridControl();
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBarcode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSupplier = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMeasure = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDistrib = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cbDistrCheck = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.colNorm = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemSpinEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repositoryItemTimeEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit();
            ((System.ComponentModel.ISupportInitialize)(this.BarManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbRepCategory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbDistrCheck)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTimeEdit2)).BeginInit();
            this.SuspendLayout();
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
            this.btSave});
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
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btSave, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
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
            // btSave
            // 
            this.btSave.Caption = "Сохранить";
            this.btSave.Glyph = global::ShopOrderCustom.Properties.Resources.filesaveas;
            this.btSave.Id = 10;
            this.btSave.Name = "btSave";
            this.btSave.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BarButtonItem1ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(757, 47);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 411);
            this.barDockControlBottom.Size = new System.Drawing.Size(757, 23);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 47);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 364);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(757, 47);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 364);
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 47);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.treeList);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.grid);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(757, 364);
            this.splitContainerControl1.SplitterPosition = 225;
            this.splitContainerControl1.TabIndex = 4;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // treeList
            // 
            this.treeList.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListColumn1});
            this.treeList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeList.Location = new System.Drawing.Point(0, 0);
            this.treeList.Name = "treeList";
            this.treeList.OptionsBehavior.Editable = false;
            this.treeList.OptionsBehavior.EnableFiltering = true;
            this.treeList.OptionsBehavior.ExpandNodesOnIncrementalSearch = true;
            this.treeList.OptionsSelection.UseIndicatorForSelection = true;
            this.treeList.OptionsView.ShowCheckBoxes = true;
            this.treeList.Size = new System.Drawing.Size(225, 364);
            this.treeList.StateImageList = this.imageList;
            this.treeList.TabIndex = 6;
            this.treeList.GetStateImage += new DevExpress.XtraTreeList.GetStateImageEventHandler(this.TreeListGetStateImage);
            this.treeList.AfterFocusNode += new DevExpress.XtraTreeList.NodeEventHandler(this.TreeListAfterFocusNode);
            this.treeList.BeforeCheckNode += new DevExpress.XtraTreeList.CheckNodeEventHandler(this.TreeListBeforeCheckNode);
            this.treeList.AfterCheckNode += new DevExpress.XtraTreeList.NodeEventHandler(this.TreeListAfterCheckNode);
            // 
            // treeListColumn1
            // 
            this.treeListColumn1.Caption = "Название";
            this.treeListColumn1.FieldName = "Name";
            this.treeListColumn1.MinWidth = 49;
            this.treeListColumn1.Name = "treeListColumn1";
            this.treeListColumn1.Visible = true;
            this.treeListColumn1.VisibleIndex = 0;
            this.treeListColumn1.Width = 301;
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "emblem-default.png");
            this.imageList.Images.SetKeyName(1, "emblem-important (1).png");
            this.imageList.Images.SetKeyName(2, "emblem-noread.png");
            // 
            // grid
            // 
            this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid.Location = new System.Drawing.Point(0, 0);
            this.grid.MainView = this.gridView;
            this.grid.Name = "grid";
            this.grid.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemSpinEdit1,
            this.repositoryItemTextEdit1,
            this.repositoryItemTimeEdit2,
            this.cbDistrCheck});
            this.grid.Size = new System.Drawing.Size(527, 364);
            this.grid.TabIndex = 0;
            this.grid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView});
            // 
            // gridView
            // 
            this.gridView.Appearance.FocusedCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.gridView.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colName,
            this.colCode,
            this.colBarcode,
            this.colSupplier,
            this.colPrice,
            this.colMeasure,
            this.colDistrib,
            this.colNorm});
            this.gridView.GridControl = this.grid;
            this.gridView.Name = "gridView";
            this.gridView.OptionsView.ShowAutoFilterRow = true;
            this.gridView.OptionsView.ShowFooter = true;
            this.gridView.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.GridViewFocusedRowChanged);
            this.gridView.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.GridViewCellValueChanged);
            // 
            // colName
            // 
            this.colName.Caption = "Название";
            this.colName.FieldName = "Name";
            this.colName.Name = "colName";
            this.colName.OptionsColumn.AllowEdit = false;
            this.colName.OptionsColumn.AllowFocus = false;
            this.colName.OptionsColumn.ReadOnly = true;
            this.colName.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
            this.colName.Visible = true;
            this.colName.VisibleIndex = 1;
            this.colName.Width = 445;
            // 
            // colCode
            // 
            this.colCode.Caption = "Код товара";
            this.colCode.FieldName = "Code";
            this.colCode.Name = "colCode";
            this.colCode.OptionsColumn.AllowEdit = false;
            this.colCode.OptionsColumn.AllowFocus = false;
            this.colCode.OptionsColumn.ReadOnly = true;
            this.colCode.Visible = true;
            this.colCode.VisibleIndex = 2;
            this.colCode.Width = 165;
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
            this.colBarcode.VisibleIndex = 3;
            this.colBarcode.Width = 134;
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
            this.colSupplier.VisibleIndex = 4;
            this.colSupplier.Width = 214;
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
            this.colPrice.VisibleIndex = 5;
            this.colPrice.Width = 108;
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
            this.colMeasure.VisibleIndex = 6;
            this.colMeasure.Width = 107;
            // 
            // colDistrib
            // 
            this.colDistrib.Caption = "Для распределения";
            this.colDistrib.ColumnEdit = this.cbDistrCheck;
            this.colDistrib.FieldName = "Check";
            this.colDistrib.Name = "colDistrib";
            this.colDistrib.Visible = true;
            this.colDistrib.VisibleIndex = 0;
            this.colDistrib.Width = 110;
            // 
            // cbDistrCheck
            // 
            this.cbDistrCheck.AutoHeight = false;
            this.cbDistrCheck.Name = "cbDistrCheck";
            // 
            // colNorm
            // 
            this.colNorm.Caption = "Норма (в ед.изм.)";
            this.colNorm.ColumnEdit = this.repositoryItemSpinEdit1;
            this.colNorm.FieldName = "Norm";
            this.colNorm.Name = "colNorm";
            this.colNorm.Visible = true;
            this.colNorm.VisibleIndex = 7;
            this.colNorm.Width = 115;
            // 
            // repositoryItemSpinEdit1
            // 
            this.repositoryItemSpinEdit1.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.repositoryItemSpinEdit1.AutoHeight = false;
            this.repositoryItemSpinEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, false, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.repositoryItemSpinEdit1.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repositoryItemSpinEdit1.HideSelection = false;
            this.repositoryItemSpinEdit1.IsFloatValue = false;
            this.repositoryItemSpinEdit1.Mask.EditMask = "\\d+";
            this.repositoryItemSpinEdit1.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.repositoryItemSpinEdit1.MaxValue = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.repositoryItemSpinEdit1.Name = "repositoryItemSpinEdit1";
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            // 
            // repositoryItemTimeEdit2
            // 
            this.repositoryItemTimeEdit2.AutoHeight = false;
            this.repositoryItemTimeEdit2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.repositoryItemTimeEdit2.Name = "repositoryItemTimeEdit2";
            // 
            // DistributionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(757, 434);
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "DistributionForm";
            this.Text = "Распределение товаров";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.DistributionFormFormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.BarManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbRepCategory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbDistrCheck)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTimeEdit2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.ExpressApp.Win.Templates.Controls.XafBarManager BarManager;
        private DevExpress.ExpressApp.Win.Templates.Controls.XafBar xafBar2;
        private DevExpress.ExpressApp.Win.Templates.Controls.XafBar xafBar3;
        private DevExpress.XtraBars.BarEditItem cbCategory;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox cbRepCategory;
        private DevExpress.XtraBars.BarButtonItem btSave;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraGrid.GridControl grid;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit repositoryItemSpinEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colPrice;
        private DevExpress.XtraGrid.Columns.GridColumn colMeasure;
        private DevExpress.XtraGrid.Columns.GridColumn colSupplier;
        private DevExpress.XtraGrid.Columns.GridColumn colCode;
        private DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit repositoryItemTimeEdit2;
        private DevExpress.XtraGrid.Columns.GridColumn colBarcode;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn colDistrib;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit cbDistrCheck;
        private DevExpress.XtraGrid.Columns.GridColumn colNorm;
        private DevExpress.XtraTreeList.TreeList treeList;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn1;
        private System.Windows.Forms.ImageList imageList;
    }
}