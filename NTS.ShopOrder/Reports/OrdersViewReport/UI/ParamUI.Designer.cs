namespace OrdersViewReport.UI
{
    partial class ParamUI
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
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.cbGroup = new DevExpress.XtraEditors.CheckedComboBoxEdit();
            this.cbSupplier = new DevExpress.XtraEditors.CheckedComboBoxEdit();
            this.cbShop = new DevExpress.XtraEditors.CheckedComboBoxEdit();
            this.dateEnd = new DevExpress.XtraEditors.DateEdit();
            this.dateBeg = new DevExpress.XtraEditors.DateEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbGroup.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbSupplier.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbShop.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEnd.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEnd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateBeg.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateBeg.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.cbGroup);
            this.layoutControl1.Controls.Add(this.cbSupplier);
            this.layoutControl1.Controls.Add(this.cbShop);
            this.layoutControl1.Controls.Add(this.dateEnd);
            this.layoutControl1.Controls.Add(this.dateBeg);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(386, 150);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // cbGroup
            // 
            this.cbGroup.Location = new System.Drawing.Point(102, 108);
            this.cbGroup.Name = "cbGroup";
            this.cbGroup.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbGroup.Size = new System.Drawing.Size(272, 20);
            this.cbGroup.StyleController = this.layoutControl1;
            this.cbGroup.TabIndex = 8;
            // 
            // cbSupplier
            // 
            this.cbSupplier.Location = new System.Drawing.Point(102, 84);
            this.cbSupplier.Name = "cbSupplier";
            this.cbSupplier.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbSupplier.Size = new System.Drawing.Size(272, 20);
            this.cbSupplier.StyleController = this.layoutControl1;
            this.cbSupplier.TabIndex = 7;
            // 
            // cbShop
            // 
            this.cbShop.Location = new System.Drawing.Point(102, 60);
            this.cbShop.Name = "cbShop";
            this.cbShop.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbShop.Size = new System.Drawing.Size(272, 20);
            this.cbShop.StyleController = this.layoutControl1;
            this.cbShop.TabIndex = 6;
            // 
            // dateEnd
            // 
            this.dateEnd.EditValue = new System.DateTime(2011, 8, 18, 0, 0, 0, 0);
            this.dateEnd.Location = new System.Drawing.Point(102, 36);
            this.dateEnd.Name = "dateEnd";
            this.dateEnd.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEnd.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateEnd.Size = new System.Drawing.Size(272, 20);
            this.dateEnd.StyleController = this.layoutControl1;
            this.dateEnd.TabIndex = 5;
            // 
            // dateBeg
            // 
            this.dateBeg.EditValue = new System.DateTime(2011, 8, 1, 0, 0, 0, 0);
            this.dateBeg.Location = new System.Drawing.Point(102, 12);
            this.dateBeg.Name = "dateBeg";
            this.dateBeg.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateBeg.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateBeg.Size = new System.Drawing.Size(272, 20);
            this.dateBeg.StyleController = this.layoutControl1;
            this.dateBeg.TabIndex = 4;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.layoutControlItem5});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(386, 150);
            this.layoutControlGroup1.Text = "layoutControlGroup1";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.dateBeg;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(366, 24);
            this.layoutControlItem1.Text = "Период с";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(86, 13);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.dateEnd;
            this.layoutControlItem2.CustomizationFormText = "layoutControlItem2";
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(366, 24);
            this.layoutControlItem2.Text = "Период по";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(86, 13);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.cbShop;
            this.layoutControlItem3.CustomizationFormText = "layoutControlItem3";
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 48);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(366, 24);
            this.layoutControlItem3.Text = "Магазин";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(86, 13);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.cbSupplier;
            this.layoutControlItem4.CustomizationFormText = "layoutControlItem4";
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 72);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(366, 24);
            this.layoutControlItem4.Text = "Поставщик";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(86, 13);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.cbGroup;
            this.layoutControlItem5.CustomizationFormText = "layoutControlItem5";
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 96);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(366, 34);
            this.layoutControlItem5.Text = "Товарная группа";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(86, 13);
            // 
            // ParamUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.layoutControl1);
            this.Name = "ParamUI";
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cbGroup.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbSupplier.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbShop.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEnd.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEnd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateBeg.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateBeg.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.CheckedComboBoxEdit cbGroup;
        private DevExpress.XtraEditors.CheckedComboBoxEdit cbSupplier;
        private DevExpress.XtraEditors.CheckedComboBoxEdit cbShop;
        private DevExpress.XtraEditors.DateEdit dateEnd;
        private DevExpress.XtraEditors.DateEdit dateBeg;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
    }
}
