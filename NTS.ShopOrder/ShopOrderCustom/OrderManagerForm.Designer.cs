namespace ShopOrderCustom
{
    partial class OrderManagerForm
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
            Model.Dispose();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrderManagerForm));
            this.barManager = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.repositoryItemProgressBar1 = new DevExpress.XtraEditors.Repository.RepositoryItemProgressBar();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.treeList = new DevExpress.XtraTreeList.TreeList();
            this.treeListColumn1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.grid = new DevExpress.XtraGrid.GridControl();
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colReqQuantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemSpinEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.colid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGroup = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colQuantityInPack = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOrdered = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMeasure = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colQuantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSupplier = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBarcode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colReserved = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFreeBalance = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMinOrder = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemProgressBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // barManager
            // 
            this.barManager.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1,
            this.bar3});
            this.barManager.DockControls.Add(this.barDockControlTop);
            this.barManager.DockControls.Add(this.barDockControlBottom);
            this.barManager.DockControls.Add(this.barDockControlLeft);
            this.barManager.DockControls.Add(this.barDockControlRight);
            this.barManager.Form = this;
            this.barManager.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barButtonItem1});
            this.barManager.MaxItemId = 2;
            this.barManager.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemProgressBar1});
            this.barManager.StatusBar = this.bar3;
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonItem1, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar1.Text = "Tools";
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "Сформировать заказы";
            this.barButtonItem1.Glyph = global::ShopOrderCustom.Properties.Resources.gearred;
            this.barButtonItem1.Id = 0;
            this.barButtonItem1.Name = "barButtonItem1";
            toolTipTitleItem1.Text = "Формирование заказов";
            toolTipItem1.LeftIndent = 6;
            toolTipItem1.Text = "Формируются файлы заказов для выбранных заказов";
            superToolTip1.Items.Add(toolTipTitleItem1);
            superToolTip1.Items.Add(toolTipItem1);
            this.barButtonItem1.SuperTip = superToolTip1;
            this.barButtonItem1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem1_ItemClick);
            // 
            // bar3
            // 
            this.bar3.BarName = "Status bar";
            this.bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bar3.DockCol = 0;
            this.bar3.DockRow = 0;
            this.bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar3.OptionsBar.AllowQuickCustomization = false;
            this.bar3.OptionsBar.DrawDragBorder = false;
            this.bar3.OptionsBar.UseWholeRow = true;
            this.bar3.Text = "Status bar";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(711, 47);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 429);
            this.barDockControlBottom.Size = new System.Drawing.Size(711, 23);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 47);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 382);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(711, 47);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 382);
            // 
            // repositoryItemProgressBar1
            // 
            this.repositoryItemProgressBar1.Name = "repositoryItemProgressBar1";
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
            this.splitContainerControl1.Size = new System.Drawing.Size(711, 382);
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
            this.treeList.OptionsView.ShowCheckBoxes = true;
            this.treeList.OptionsView.ShowIndicator = false;
            this.treeList.Size = new System.Drawing.Size(225, 382);
            this.treeList.TabIndex = 1;
            this.treeList.AfterFocusNode += new DevExpress.XtraTreeList.NodeEventHandler(this.treeList_AfterFocusNode);
            this.treeList.BeforeCheckNode += new DevExpress.XtraTreeList.CheckNodeEventHandler(this.treeList_BeforeCheckNode);
            this.treeList.AfterCheckNode += new DevExpress.XtraTreeList.NodeEventHandler(this.treeList_AfterCheckNode);
            // 
            // treeListColumn1
            // 
            this.treeListColumn1.Caption = "Заказы";
            this.treeListColumn1.FieldName = "Name";
            this.treeListColumn1.MinWidth = 32;
            this.treeListColumn1.Name = "treeListColumn1";
            this.treeListColumn1.Visible = true;
            this.treeListColumn1.VisibleIndex = 0;
            // 
            // grid
            // 
            this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid.Location = new System.Drawing.Point(0, 0);
            this.grid.MainView = this.gridView;
            this.grid.Name = "grid";
            this.grid.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemSpinEdit1});
            this.grid.Size = new System.Drawing.Size(481, 382);
            this.grid.TabIndex = 1;
            this.grid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView});
            // 
            // gridView
            // 
            this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colReqQuantity,
            this.colid,
            this.colGroup,
            this.colName,
            this.colPrice,
            this.colQuantityInPack,
            this.colOrdered,
            this.colMeasure,
            this.colQuantity,
            this.colSupplier,
            this.colCode,
            this.colDate,
            this.colBarcode,
            this.colReserved,
            this.colFreeBalance,
            this.colMinOrder});
            this.gridView.GridControl = this.grid;
            this.gridView.Name = "gridView";
            this.gridView.OptionsView.ShowFooter = true;
            // 
            // colReqQuantity
            // 
            this.colReqQuantity.AppearanceCell.BackColor = System.Drawing.Color.LightGreen;
            this.colReqQuantity.AppearanceCell.Options.UseBackColor = true;
            this.colReqQuantity.Caption = "Заказ";
            this.colReqQuantity.ColumnEdit = this.repositoryItemSpinEdit1;
            this.colReqQuantity.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colReqQuantity.FieldName = "ReqQuantity";
            this.colReqQuantity.MaxWidth = 50;
            this.colReqQuantity.Name = "colReqQuantity";
            this.colReqQuantity.OptionsColumn.AllowEdit = false;
            this.colReqQuantity.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.colReqQuantity.Visible = true;
            this.colReqQuantity.VisibleIndex = 0;
            this.colReqQuantity.Width = 50;
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
            this.colGroup.VisibleIndex = 4;
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
            this.colName.VisibleIndex = 3;
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
            this.colPrice.VisibleIndex = 5;
            this.colPrice.Width = 50;
            // 
            // colQuantityInPack
            // 
            this.colQuantityInPack.FieldName = "QuantityInPack";
            this.colQuantityInPack.Name = "colQuantityInPack";
            this.colQuantityInPack.OptionsColumn.AllowEdit = false;
            this.colQuantityInPack.OptionsColumn.AllowFocus = false;
            this.colQuantityInPack.OptionsColumn.ReadOnly = true;
            this.colQuantityInPack.Width = 27;
            // 
            // colOrdered
            // 
            this.colOrdered.AppearanceCell.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.colOrdered.AppearanceCell.Options.UseBackColor = true;
            this.colOrdered.Caption = "Резерв";
            this.colOrdered.FieldName = "Ordered";
            this.colOrdered.MaxWidth = 50;
            this.colOrdered.Name = "colOrdered";
            this.colOrdered.OptionsColumn.AllowEdit = false;
            this.colOrdered.OptionsColumn.AllowFocus = false;
            this.colOrdered.OptionsColumn.ReadOnly = true;
            this.colOrdered.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.colOrdered.Visible = true;
            this.colOrdered.VisibleIndex = 2;
            this.colOrdered.Width = 50;
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
            this.colMeasure.Width = 50;
            // 
            // colQuantity
            // 
            this.colQuantity.AppearanceCell.BackColor = System.Drawing.Color.LightCoral;
            this.colQuantity.AppearanceCell.Options.UseBackColor = true;
            this.colQuantity.Caption = "Остаток";
            this.colQuantity.FieldName = "Quantity";
            this.colQuantity.MaxWidth = 50;
            this.colQuantity.Name = "colQuantity";
            this.colQuantity.OptionsColumn.AllowEdit = false;
            this.colQuantity.OptionsColumn.AllowFocus = false;
            this.colQuantity.OptionsColumn.ReadOnly = true;
            this.colQuantity.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.colQuantity.Width = 50;
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
            this.colSupplier.VisibleIndex = 7;
            this.colSupplier.Width = 50;
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
            // colDate
            // 
            this.colDate.Caption = "Дата загрузки";
            this.colDate.FieldName = "Date";
            this.colDate.Name = "colDate";
            this.colDate.OptionsColumn.AllowEdit = false;
            this.colDate.OptionsColumn.AllowFocus = false;
            this.colDate.OptionsColumn.ReadOnly = true;
            this.colDate.Visible = true;
            this.colDate.VisibleIndex = 8;
            this.colDate.Width = 50;
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
            this.colBarcode.VisibleIndex = 9;
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
            this.colMinOrder.AppearanceCell.BackColor = System.Drawing.Color.CornflowerBlue;
            this.colMinOrder.AppearanceCell.Options.UseBackColor = true;
            this.colMinOrder.Caption = "Минимальный заказ";
            this.colMinOrder.FieldName = "MinOrder";
            this.colMinOrder.MaxWidth = 50;
            this.colMinOrder.Name = "colMinOrder";
            this.colMinOrder.OptionsColumn.AllowEdit = false;
            this.colMinOrder.OptionsColumn.AllowFocus = false;
            this.colMinOrder.OptionsColumn.ReadOnly = true;
            this.colMinOrder.Visible = true;
            this.colMinOrder.VisibleIndex = 1;
            this.colMinOrder.Width = 50;
            // 
            // OrderManagerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(711, 452);
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "OrderManagerForm";
            this.Text = "Менеджер заказов";
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemProgressBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEdit1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraTreeList.TreeList treeList;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn1;
        private DevExpress.XtraGrid.GridControl grid;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private DevExpress.XtraGrid.Columns.GridColumn colReqQuantity;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit repositoryItemSpinEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn colid;
        private DevExpress.XtraGrid.Columns.GridColumn colGroup;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colPrice;
        private DevExpress.XtraGrid.Columns.GridColumn colQuantityInPack;
        private DevExpress.XtraGrid.Columns.GridColumn colOrdered;
        private DevExpress.XtraGrid.Columns.GridColumn colMeasure;
        private DevExpress.XtraGrid.Columns.GridColumn colQuantity;
        private DevExpress.XtraGrid.Columns.GridColumn colSupplier;
        private DevExpress.XtraGrid.Columns.GridColumn colCode;
        private DevExpress.XtraGrid.Columns.GridColumn colDate;
        private DevExpress.XtraGrid.Columns.GridColumn colBarcode;
        private DevExpress.XtraGrid.Columns.GridColumn colReserved;
        private DevExpress.XtraGrid.Columns.GridColumn colFreeBalance;
        private DevExpress.XtraGrid.Columns.GridColumn colMinOrder;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraEditors.Repository.RepositoryItemProgressBar repositoryItemProgressBar1;
    }
}