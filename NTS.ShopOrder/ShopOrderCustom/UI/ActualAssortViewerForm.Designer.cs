﻿namespace ShopOrderCustom.UI
{
    partial class ActualAssortViewerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ActualAssortViewerForm));
            DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition1 = new DevExpress.XtraGrid.StyleFormatCondition();
            this.colIsReqAssort = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.barManager = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.btRefresh = new DevExpress.XtraBars.BarButtonItem();
            this.btExport = new DevExpress.XtraBars.BarButtonItem();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem4 = new DevExpress.XtraBars.BarButtonItem();
            this.repositoryItemProgressBar1 = new DevExpress.XtraEditors.Repository.RepositoryItemProgressBar();
            this.cdDateFilterItem = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.treeList = new DevExpress.XtraTreeList.TreeList();
            this.treeListColumn1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn2 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.ilNode = new System.Windows.Forms.ImageList(this.components);
            this.grid = new DevExpress.XtraGrid.GridControl();
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colBalance = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGoodsGroup = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colQuantityInPack = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMeasure = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSupplier = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBarcode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coldate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMinOrder = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colForOrder = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAvgSell = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colShopBalance = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemSpinEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.repositoryItemTimeEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit();
            this.spselOrderGoodsByHeaderHistoryResultBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.popupMenuNodes = new DevExpress.XtraBars.PopupMenu(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemProgressBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdDateFilterItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdDateFilterItem.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTimeEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spselOrderGoodsByHeaderHistoryResultBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenuNodes)).BeginInit();
            this.SuspendLayout();
            // 
            // colIsReqAssort
            // 
            this.colIsReqAssort.Caption = "Обязательный ассортимент";
            this.colIsReqAssort.ColumnEdit = this.repositoryItemCheckEdit1;
            this.colIsReqAssort.FieldName = "IsReqAssort";
            this.colIsReqAssort.Name = "colIsReqAssort";
            this.colIsReqAssort.Visible = true;
            this.colIsReqAssort.VisibleIndex = 12;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            this.repositoryItemCheckEdit1.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
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
            this.btRefresh,
            this.barButtonItem3,
            this.barButtonItem4,
            this.btExport});
            this.barManager.MaxItemId = 11;
            this.barManager.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemProgressBar1,
            this.cdDateFilterItem});
            this.barManager.StatusBar = this.bar3;
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btRefresh, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btExport, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar1.Text = "Tools";
            // 
            // btRefresh
            // 
            this.btRefresh.Caption = "Обновить";
            this.btRefresh.Glyph = global::ShopOrderCustom.Properties.Resources.reload_all_tabs;
            this.btRefresh.Id = 2;
            this.btRefresh.Name = "btRefresh";
            this.btRefresh.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BtRefreshItemClick);
            // 
            // btExport
            // 
            this.btExport.Caption = "Экспорт";
            this.btExport.Glyph = global::ShopOrderCustom.Properties.Resources.Excel_icon;
            this.btExport.Id = 10;
            this.btExport.Name = "btExport";
            this.btExport.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BtExportItemClick);
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
            this.barDockControlTop.Size = new System.Drawing.Size(973, 47);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 429);
            this.barDockControlBottom.Size = new System.Drawing.Size(973, 23);
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
            this.barDockControlRight.Location = new System.Drawing.Point(973, 47);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 382);
            // 
            // barButtonItem3
            // 
            this.barButtonItem3.Caption = "Gthgd";
            this.barButtonItem3.Id = 6;
            this.barButtonItem3.Name = "barButtonItem3";
            // 
            // barButtonItem4
            // 
            this.barButtonItem4.Caption = "Перенести на текущий день";
            this.barButtonItem4.Id = 7;
            this.barButtonItem4.Name = "barButtonItem4";
            // 
            // repositoryItemProgressBar1
            // 
            this.repositoryItemProgressBar1.Name = "repositoryItemProgressBar1";
            // 
            // cdDateFilterItem
            // 
            this.cdDateFilterItem.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.cdDateFilterItem.AutoHeight = false;
            this.cdDateFilterItem.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cdDateFilterItem.Name = "cdDateFilterItem";
            this.cdDateFilterItem.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
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
            this.splitContainerControl1.Size = new System.Drawing.Size(973, 382);
            this.splitContainerControl1.SplitterPosition = 260;
            this.splitContainerControl1.TabIndex = 4;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // treeList
            // 
            this.treeList.Appearance.SelectedRow.BackColor = System.Drawing.Color.Silver;
            this.treeList.Appearance.SelectedRow.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.treeList.Appearance.SelectedRow.Options.UseBackColor = true;
            this.treeList.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListColumn1,
            this.treeListColumn2});
            this.treeList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeList.Location = new System.Drawing.Point(0, 0);
            this.treeList.Name = "treeList";
            this.treeList.OptionsBehavior.Editable = false;
            this.treeList.OptionsSelection.UseIndicatorForSelection = true;
            this.treeList.OptionsView.ShowHorzLines = false;
            this.treeList.OptionsView.ShowVertLines = false;
            this.treeList.Size = new System.Drawing.Size(260, 382);
            this.treeList.StateImageList = this.ilNode;
            this.treeList.TabIndex = 1;
            this.treeList.GetStateImage += new DevExpress.XtraTreeList.GetStateImageEventHandler(this.TreeListGetStateImage);
            this.treeList.AfterFocusNode += new DevExpress.XtraTreeList.NodeEventHandler(this.TreeListAfterFocusNode);
            this.treeList.CustomDrawNodeCell += new DevExpress.XtraTreeList.CustomDrawNodeCellEventHandler(this.TreeListCustomDrawNodeCell);
            // 
            // treeListColumn1
            // 
            this.treeListColumn1.Caption = "Заказы";
            this.treeListColumn1.FieldName = "Name";
            this.treeListColumn1.MinWidth = 49;
            this.treeListColumn1.Name = "treeListColumn1";
            this.treeListColumn1.Visible = true;
            this.treeListColumn1.VisibleIndex = 0;
            this.treeListColumn1.Width = 201;
            // 
            // treeListColumn2
            // 
            this.treeListColumn2.Caption = "Блок.";
            this.treeListColumn2.FieldName = "User";
            this.treeListColumn2.Name = "treeListColumn2";
            this.treeListColumn2.Width = 57;
            // 
            // ilNode
            // 
            this.ilNode.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilNode.ImageStream")));
            this.ilNode.TransparentColor = System.Drawing.Color.Transparent;
            this.ilNode.Images.SetKeyName(0, "home.png");
            this.ilNode.Images.SetKeyName(1, "basket_go.png");
            this.ilNode.Images.SetKeyName(2, "basket_put (1).png");
            this.ilNode.Images.SetKeyName(3, "export.png");
            // 
            // grid
            // 
            this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid.Location = new System.Drawing.Point(0, 0);
            this.grid.MainView = this.gridView;
            this.grid.Name = "grid";
            this.grid.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemSpinEdit1,
            this.repositoryItemTimeEdit1,
            this.repositoryItemCheckEdit1});
            this.grid.Size = new System.Drawing.Size(708, 382);
            this.grid.TabIndex = 1;
            this.grid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView});
            // 
            // gridView
            // 
            this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colBalance,
            this.colGoodsGroup,
            this.colName,
            this.colPrice,
            this.colQuantityInPack,
            this.colMeasure,
            this.colSupplier,
            this.colCode,
            this.colBarcode,
            this.coldate,
            this.colMinOrder,
            this.colIsReqAssort,
            this.colForOrder,
            this.colAvgSell,
            this.colShopBalance});
            styleFormatCondition1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            styleFormatCondition1.Appearance.Options.UseFont = true;
            styleFormatCondition1.ApplyToRow = true;
            styleFormatCondition1.Column = this.colIsReqAssort;
            styleFormatCondition1.Condition = DevExpress.XtraGrid.FormatConditionEnum.Equal;
            styleFormatCondition1.Value1 = true;
            this.gridView.FormatConditions.AddRange(new DevExpress.XtraGrid.StyleFormatCondition[] {
            styleFormatCondition1});
            this.gridView.GridControl = this.grid;
            this.gridView.Name = "gridView";
            this.gridView.OptionsBehavior.Editable = false;
            this.gridView.OptionsView.ShowAutoFilterRow = true;
            this.gridView.OptionsView.ShowFooter = true;
            // 
            // colBalance
            // 
            this.colBalance.Caption = "Остаток";
            this.colBalance.FieldName = "Balance";
            this.colBalance.Name = "colBalance";
            this.colBalance.Visible = true;
            this.colBalance.VisibleIndex = 4;
            // 
            // colGoodsGroup
            // 
            this.colGoodsGroup.Caption = "Группа товара";
            this.colGoodsGroup.FieldName = "GoodsGroup";
            this.colGoodsGroup.Name = "colGoodsGroup";
            this.colGoodsGroup.Visible = true;
            this.colGoodsGroup.VisibleIndex = 5;
            // 
            // colName
            // 
            this.colName.Caption = "Название товара";
            this.colName.FieldName = "Name";
            this.colName.Name = "colName";
            this.colName.Visible = true;
            this.colName.VisibleIndex = 6;
            // 
            // colPrice
            // 
            this.colPrice.Caption = "Цена";
            this.colPrice.FieldName = "Price";
            this.colPrice.Name = "colPrice";
            this.colPrice.Visible = true;
            this.colPrice.VisibleIndex = 7;
            // 
            // colQuantityInPack
            // 
            this.colQuantityInPack.Caption = "Кол. в упаковке";
            this.colQuantityInPack.FieldName = "QuantityInPack";
            this.colQuantityInPack.Name = "colQuantityInPack";
            this.colQuantityInPack.Visible = true;
            this.colQuantityInPack.VisibleIndex = 8;
            // 
            // colMeasure
            // 
            this.colMeasure.Caption = "Единица измерения";
            this.colMeasure.FieldName = "Measure";
            this.colMeasure.Name = "colMeasure";
            this.colMeasure.Visible = true;
            this.colMeasure.VisibleIndex = 9;
            // 
            // colSupplier
            // 
            this.colSupplier.Caption = "Поставщик";
            this.colSupplier.FieldName = "Supplier";
            this.colSupplier.Name = "colSupplier";
            this.colSupplier.Visible = true;
            this.colSupplier.VisibleIndex = 10;
            // 
            // colCode
            // 
            this.colCode.Caption = "Код товара";
            this.colCode.FieldName = "Code";
            this.colCode.Name = "colCode";
            // 
            // colBarcode
            // 
            this.colBarcode.Caption = "Штрихкод";
            this.colBarcode.FieldName = "Barcode";
            this.colBarcode.Name = "colBarcode";
            this.colBarcode.Visible = true;
            this.colBarcode.VisibleIndex = 11;
            // 
            // coldate
            // 
            this.coldate.Caption = "Дата заказа";
            this.coldate.FieldName = "date";
            this.coldate.Name = "coldate";
            // 
            // colMinOrder
            // 
            this.colMinOrder.Caption = "Минимальный заказ";
            this.colMinOrder.FieldName = "MinOrder";
            this.colMinOrder.Name = "colMinOrder";
            this.colMinOrder.Visible = true;
            this.colMinOrder.VisibleIndex = 0;
            // 
            // colForOrder
            // 
            this.colForOrder.Caption = "Рекомендовано к заказу";
            this.colForOrder.FieldName = "ForOrder";
            this.colForOrder.Name = "colForOrder";
            this.colForOrder.Visible = true;
            this.colForOrder.VisibleIndex = 1;
            // 
            // colAvgSell
            // 
            this.colAvgSell.Caption = "Средние продажи";
            this.colAvgSell.FieldName = "AvgSell";
            this.colAvgSell.Name = "colAvgSell";
            this.colAvgSell.Visible = true;
            this.colAvgSell.VisibleIndex = 2;
            // 
            // colShopBalance
            // 
            this.colShopBalance.Caption = "Остаток в магазине";
            this.colShopBalance.FieldName = "ShopBalance";
            this.colShopBalance.Name = "colShopBalance";
            this.colShopBalance.Visible = true;
            this.colShopBalance.VisibleIndex = 3;
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
            // repositoryItemTimeEdit1
            // 
            this.repositoryItemTimeEdit1.AutoHeight = false;
            this.repositoryItemTimeEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.repositoryItemTimeEdit1.Name = "repositoryItemTimeEdit1";
            // 
            // spselOrderGoodsByHeaderHistoryResultBindingSource
            // 
            this.spselOrderGoodsByHeaderHistoryResultBindingSource.DataSource = typeof(DataBase.sp_sel_OrderGoodsByHeaderHistoryResult);
            // 
            // popupMenuNodes
            // 
            this.popupMenuNodes.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem4)});
            this.popupMenuNodes.Manager = this.barManager;
            this.popupMenuNodes.Name = "popupMenuNodes";
            // 
            // ActualAssortViewerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(973, 452);
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ActualAssortViewerForm";
            this.Text = "Просмотр актуального ассортимента";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ActualAssortViewerForm_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemProgressBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdDateFilterItem.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdDateFilterItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTimeEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spselOrderGoodsByHeaderHistoryResultBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenuNodes)).EndInit();
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
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit repositoryItemSpinEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemProgressBar repositoryItemProgressBar1;
        private DevExpress.XtraBars.BarButtonItem btRefresh;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit cdDateFilterItem;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn2;
        private System.Windows.Forms.ImageList ilNode;
        private DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit repositoryItemTimeEdit1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem3;
        private DevExpress.XtraBars.BarButtonItem barButtonItem4;
        private DevExpress.XtraBars.PopupMenu popupMenuNodes;
        private System.Windows.Forms.BindingSource spselOrderGoodsByHeaderHistoryResultBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colBalance;
        private DevExpress.XtraGrid.Columns.GridColumn colGoodsGroup;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colPrice;
        private DevExpress.XtraGrid.Columns.GridColumn colQuantityInPack;
        private DevExpress.XtraGrid.Columns.GridColumn colMeasure;
        private DevExpress.XtraGrid.Columns.GridColumn colSupplier;
        private DevExpress.XtraGrid.Columns.GridColumn colCode;
        private DevExpress.XtraGrid.Columns.GridColumn colBarcode;
        private DevExpress.XtraGrid.Columns.GridColumn coldate;
        private DevExpress.XtraGrid.Columns.GridColumn colMinOrder;
        private DevExpress.XtraGrid.Columns.GridColumn colIsReqAssort;
        private DevExpress.XtraGrid.Columns.GridColumn colForOrder;
        private DevExpress.XtraGrid.Columns.GridColumn colAvgSell;
        private DevExpress.XtraGrid.Columns.GridColumn colShopBalance;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraBars.BarButtonItem btExport;
    }
}