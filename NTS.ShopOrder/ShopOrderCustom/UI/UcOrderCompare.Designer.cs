namespace ShopOrderCustom.UI
{
    partial class UcOrderCompare
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.colQuantitySrc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orderTransferCompareBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colBarcode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMeasure = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSupplier = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGroup = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDateDest = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDateSrc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colQuantityDest = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colQuantityInPack = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIsEqual = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.orderTransferCompareBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            this.SuspendLayout();
            // 
            // colQuantitySrc
            // 
            this.colQuantitySrc.Caption = "Исходное кол-во.";
            this.colQuantitySrc.FieldName = "QuantitySrc";
            this.colQuantitySrc.Name = "colQuantitySrc";
            this.colQuantitySrc.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            this.colQuantitySrc.Visible = true;
            this.colQuantitySrc.VisibleIndex = 0;
            this.colQuantitySrc.Width = 99;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "ObjectList";
            this.dataGridViewTextBoxColumn1.HeaderText = "ObjectList";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // orderTransferCompareBindingSource
            // 
            this.orderTransferCompareBindingSource.DataSource = typeof(DataBase.DataObject.OrderTransferCompare);
            // 
            // gridControl
            // 
            this.gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl.Location = new System.Drawing.Point(0, 0);
            this.gridControl.MainView = this.gridView;
            this.gridControl.Name = "gridControl";
            this.gridControl.Size = new System.Drawing.Size(703, 305);
            this.gridControl.TabIndex = 2;
            this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView});
            // 
            // gridView
            // 
            this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colBarcode,
            this.colCode,
            this.colMeasure,
            this.colSupplier,
            this.colGroup,
            this.colDateDest,
            this.colDateSrc,
            this.colPrice,
            this.colQuantityDest,
            this.colQuantitySrc,
            this.colQuantityInPack,
            this.colName,
            this.colIsEqual});
            this.gridView.GridControl = this.gridControl;
            this.gridView.Name = "gridView";
            this.gridView.OptionsBehavior.Editable = false;
            this.gridView.OptionsBehavior.ReadOnly = true;
            this.gridView.OptionsView.ShowAutoFilterRow = true;
            this.gridView.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colIsEqual, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.gridView.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.gridView_CustomDrawCell);
            // 
            // colBarcode
            // 
            this.colBarcode.Caption = "Штрихкод";
            this.colBarcode.FieldName = "Barcode";
            this.colBarcode.Name = "colBarcode";
            this.colBarcode.Visible = true;
            this.colBarcode.VisibleIndex = 8;
            // 
            // colCode
            // 
            this.colCode.Caption = "Код товара";
            this.colCode.FieldName = "Code";
            this.colCode.Name = "colCode";
            this.colCode.Visible = true;
            this.colCode.VisibleIndex = 7;
            // 
            // colMeasure
            // 
            this.colMeasure.Caption = "Ед. измерения";
            this.colMeasure.FieldName = "Measure";
            this.colMeasure.Name = "colMeasure";
            this.colMeasure.Visible = true;
            this.colMeasure.VisibleIndex = 3;
            this.colMeasure.Width = 82;
            // 
            // colSupplier
            // 
            this.colSupplier.Caption = "Поставщик";
            this.colSupplier.FieldName = "Supplier";
            this.colSupplier.Name = "colSupplier";
            this.colSupplier.Visible = true;
            this.colSupplier.VisibleIndex = 11;
            // 
            // colGroup
            // 
            this.colGroup.Caption = "Группа товара";
            this.colGroup.FieldName = "Group";
            this.colGroup.Name = "colGroup";
            this.colGroup.Visible = true;
            this.colGroup.VisibleIndex = 10;
            this.colGroup.Width = 84;
            // 
            // colDateDest
            // 
            this.colDateDest.Caption = "Дата нового заказа";
            this.colDateDest.FieldName = "DateDest";
            this.colDateDest.Name = "colDateDest";
            this.colDateDest.Visible = true;
            this.colDateDest.VisibleIndex = 6;
            this.colDateDest.Width = 110;
            // 
            // colDateSrc
            // 
            this.colDateSrc.Caption = "Дата иходного заказа";
            this.colDateSrc.FieldName = "DateSrc";
            this.colDateSrc.Name = "colDateSrc";
            this.colDateSrc.Visible = true;
            this.colDateSrc.VisibleIndex = 5;
            this.colDateSrc.Width = 123;
            // 
            // colPrice
            // 
            this.colPrice.Caption = "Цена";
            this.colPrice.FieldName = "Price";
            this.colPrice.Name = "colPrice";
            this.colPrice.Visible = true;
            this.colPrice.VisibleIndex = 4;
            // 
            // colQuantityDest
            // 
            this.colQuantityDest.Caption = "Новое кол-во.";
            this.colQuantityDest.FieldName = "QuantityDest";
            this.colQuantityDest.Name = "colQuantityDest";
            this.colQuantityDest.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            this.colQuantityDest.Visible = true;
            this.colQuantityDest.VisibleIndex = 1;
            this.colQuantityDest.Width = 81;
            // 
            // colQuantityInPack
            // 
            this.colQuantityInPack.Caption = "Минимальный заказ";
            this.colQuantityInPack.FieldName = "QuantityInPack";
            this.colQuantityInPack.Name = "colQuantityInPack";
            this.colQuantityInPack.Visible = true;
            this.colQuantityInPack.VisibleIndex = 2;
            this.colQuantityInPack.Width = 110;
            // 
            // colName
            // 
            this.colName.Caption = "Название";
            this.colName.FieldName = "Name";
            this.colName.Name = "colName";
            this.colName.Visible = true;
            this.colName.VisibleIndex = 9;
            // 
            // colIsEqual
            // 
            this.colIsEqual.Caption = "Равны";
            this.colIsEqual.FieldName = "IsEqual";
            this.colIsEqual.Name = "colIsEqual";
            this.colIsEqual.Visible = true;
            this.colIsEqual.VisibleIndex = 12;
            // 
            // UcOrderCompare
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridControl);
            this.Name = "UcOrderCompare";
            this.Size = new System.Drawing.Size(703, 305);
            ((System.ComponentModel.ISupportInitialize)(this.orderTransferCompareBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.BindingSource orderTransferCompareBindingSource;
        private DevExpress.XtraGrid.GridControl gridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private DevExpress.XtraGrid.Columns.GridColumn colBarcode;
        private DevExpress.XtraGrid.Columns.GridColumn colCode;
        private DevExpress.XtraGrid.Columns.GridColumn colMeasure;
        private DevExpress.XtraGrid.Columns.GridColumn colSupplier;
        private DevExpress.XtraGrid.Columns.GridColumn colGroup;
        private DevExpress.XtraGrid.Columns.GridColumn colDateDest;
        private DevExpress.XtraGrid.Columns.GridColumn colDateSrc;
        private DevExpress.XtraGrid.Columns.GridColumn colPrice;
        private DevExpress.XtraGrid.Columns.GridColumn colQuantityDest;
        private DevExpress.XtraGrid.Columns.GridColumn colQuantitySrc;
        private DevExpress.XtraGrid.Columns.GridColumn colQuantityInPack;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colIsEqual;

    }
}
