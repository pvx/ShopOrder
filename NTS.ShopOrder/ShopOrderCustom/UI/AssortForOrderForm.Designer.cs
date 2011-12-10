namespace ShopOrderCustom.UI
{
    partial class AssortForOrderForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AssortForOrderForm));
            this.xafBar = new DevExpress.ExpressApp.Win.Templates.Controls.XafBarManager(this.components);
            this.xafBar2 = new DevExpress.ExpressApp.Win.Templates.Controls.XafBar();
            this.BarState = new DevExpress.XtraBars.BarStaticItem();
            this.xafBar3 = new DevExpress.ExpressApp.Win.Templates.Controls.XafBar();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.SaveBar = new DevExpress.XtraEditors.Repository.RepositoryItemProgressBar();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.treeList = new DevExpress.XtraTreeList.TreeList();
            this.treeListColumn1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
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
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.xafBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SaveBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // xafBar
            // 
            this.xafBar.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.xafBar2,
            this.xafBar3});
            this.xafBar.DockControls.Add(this.barDockControlTop);
            this.xafBar.DockControls.Add(this.barDockControlBottom);
            this.xafBar.DockControls.Add(this.barDockControlLeft);
            this.xafBar.DockControls.Add(this.barDockControlRight);
            this.xafBar.Form = this;
            this.xafBar.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barButtonItem1,
            this.barButtonItem2,
            this.BarState});
            this.xafBar.MaxItemId = 4;
            this.xafBar.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.SaveBar});
            this.xafBar.StatusBar = this.xafBar2;
            // 
            // xafBar2
            // 
            this.xafBar2.BarName = "StatusBar";
            this.xafBar2.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.xafBar2.DockCol = 0;
            this.xafBar2.DockRow = 0;
            this.xafBar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.xafBar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.BarState)});
            this.xafBar2.OptionsBar.AllowQuickCustomization = false;
            this.xafBar2.OptionsBar.DrawDragBorder = false;
            this.xafBar2.OptionsBar.UseWholeRow = true;
            this.xafBar2.TargetPageCategoryColor = System.Drawing.Color.Empty;
            this.xafBar2.Text = "StatusBar";
            // 
            // BarState
            // 
            this.BarState.Id = 2;
            this.BarState.Name = "BarState";
            this.BarState.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // xafBar3
            // 
            this.xafBar3.BarName = "Main Toolbar";
            this.xafBar3.DockCol = 0;
            this.xafBar3.DockRow = 0;
            this.xafBar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.xafBar3.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonItem1, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonItem2, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.xafBar3.TargetPageCategoryColor = System.Drawing.Color.Empty;
            this.xafBar3.Text = "Main Toolbar";
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "Сохранить";
            this.barButtonItem1.Glyph = global::ShopOrderCustom.Properties.Resources.filesaveas;
            this.barButtonItem1.Id = 0;
            this.barButtonItem1.Name = "barButtonItem1";
            this.barButtonItem1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BarButtonItem1ItemClick);
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "Импорт";
            this.barButtonItem2.Glyph = global::ShopOrderCustom.Properties.Resources.Excel_icon;
            this.barButtonItem2.Id = 1;
            this.barButtonItem2.Name = "barButtonItem2";
            toolTipTitleItem1.Appearance.Image = global::ShopOrderCustom.Properties.Resources.Excel_icon;
            toolTipTitleItem1.Appearance.Options.UseImage = true;
            toolTipTitleItem1.Image = global::ShopOrderCustom.Properties.Resources.Excel_icon;
            toolTipTitleItem1.Text = "Импорт ассортимента к заказу из Excel файла";
            toolTipItem1.LeftIndent = 6;
            toolTipItem1.Text = "Загрузка ассортимента из файла Excel доступного для заказа в магазинах";
            superToolTip1.Items.Add(toolTipTitleItem1);
            superToolTip1.Items.Add(toolTipItem1);
            this.barButtonItem2.SuperTip = superToolTip1;
            this.barButtonItem2.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BarButtonItem2ItemClick);
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
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 379);
            this.barDockControlBottom.Size = new System.Drawing.Size(769, 26);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 47);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 332);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(769, 47);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 332);
            // 
            // SaveBar
            // 
            this.SaveBar.Name = "SaveBar";
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
            this.splitContainerControl1.Size = new System.Drawing.Size(769, 332);
            this.splitContainerControl1.SplitterPosition = 238;
            this.splitContainerControl1.TabIndex = 9;
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
            this.treeList.Size = new System.Drawing.Size(238, 332);
            this.treeList.StateImageList = this.imageList;
            this.treeList.TabIndex = 5;
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
            this.repositoryItemCheckEdit1});
            this.grid.Size = new System.Drawing.Size(526, 332);
            this.grid.TabIndex = 2;
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
            this.gridView.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.GridViewCellValueChanged);
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
            this.colName.Width = 414;
            // 
            // colPrice
            // 
            this.colPrice.Caption = "Цена";
            this.colPrice.FieldName = "Price";
            this.colPrice.Name = "colPrice";
            this.colPrice.OptionsColumn.AllowEdit = false;
            this.colPrice.OptionsColumn.AllowFocus = false;
            this.colPrice.OptionsColumn.ReadOnly = true;
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
            this.colQuantityInPack.Visible = true;
            this.colQuantityInPack.VisibleIndex = 3;
            this.colQuantityInPack.Width = 68;
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
            this.colMeasure.Width = 127;
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
            this.colSupplier.VisibleIndex = 6;
            this.colSupplier.Width = 428;
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
            this.colBarcode.VisibleIndex = 2;
            this.colBarcode.Width = 127;
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
            this.colMinOrder.Visible = true;
            this.colMinOrder.VisibleIndex = 5;
            this.colMinOrder.Width = 90;
            // 
            // colAssortReq
            // 
            this.colAssortReq.Caption = "К заказу";
            this.colAssortReq.ColumnEdit = this.repositoryItemCheckEdit1;
            this.colAssortReq.FieldName = "Check";
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
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            this.openFileDialog.Filter = "Excel|*.xls";
            // 
            // AssortForOrderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(769, 405);
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AssortForOrderForm";
            this.Text = "Ассортимент к заказу";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AssortForOrderForm_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.xafBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SaveBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEdit1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.ExpressApp.Win.Templates.Controls.XafBarManager xafBar;
        private DevExpress.ExpressApp.Win.Templates.Controls.XafBar xafBar2;
        private DevExpress.ExpressApp.Win.Templates.Controls.XafBar xafBar3;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraTreeList.TreeList treeList;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn1;
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
        private DevExpress.XtraGrid.Columns.GridColumn colAssortReq;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit repositoryItemSpinEdit1;
        private System.Windows.Forms.ImageList imageList;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private DevExpress.XtraBars.BarStaticItem BarState;
        private DevExpress.XtraEditors.Repository.RepositoryItemProgressBar SaveBar;
    }
}