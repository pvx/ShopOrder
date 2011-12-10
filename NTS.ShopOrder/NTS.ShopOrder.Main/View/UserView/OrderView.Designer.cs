using System.Windows.Forms;

namespace NTS.ShopOrder.Main.View.UserView
{
    partial class OrderView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrderView));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.tbAddOrder = new System.Windows.Forms.ToolStripButton();
            this.tbCommit = new System.Windows.Forms.ToolStripButton();
            this.tbClear = new System.Windows.Forms.ToolStripButton();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.OrdersHeaderData = new System.Windows.Forms.BindingSource();
            this.c1TrueDBGrid1 = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
            this.CurrentOrderBalanceData = new System.Windows.Forms.BindingSource();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.toolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OrdersHeaderData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1TrueDBGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CurrentOrderBalanceData)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.radioButton2);
            this.splitContainer1.Panel1.Controls.Add(this.radioButton1);
            this.splitContainer1.Panel1.Controls.Add(this.toolStrip);
            this.splitContainer1.Panel1.Controls.Add(this.listBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.c1TrueDBGrid1);
            this.splitContainer1.Size = new System.Drawing.Size(791, 499);
            this.splitContainer1.SplitterDistance = 246;
            this.splitContainer1.TabIndex = 2;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(12, 37);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(81, 17);
            this.radioButton2.TabIndex = 3;
            this.radioButton2.Tag = "1";
            this.radioButton2.Text = "Склад НТС";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(99, 37);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(98, 17);
            this.radioButton1.TabIndex = 4;
            this.radioButton1.Tag = "2";
            this.radioButton1.Text = "Склад Аренды";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbAddOrder,
            this.tbCommit,
            this.tbClear});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip.Size = new System.Drawing.Size(246, 25);
            this.toolStrip.TabIndex = 2;
            this.toolStrip.Text = "toolStrip1";
            // 
            // tbAddOrder
            // 
            this.tbAddOrder.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbAddOrder.Image = global::NTS.ShopOrder.Main.Properties.Resources.edit_add;
            this.tbAddOrder.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbAddOrder.Name = "tbAddOrder";
            this.tbAddOrder.Size = new System.Drawing.Size(23, 22);
            this.tbAddOrder.Text = "toolStripButton1";
            this.tbAddOrder.ToolTipText = "Добавить новый заказ";
            this.tbAddOrder.Click += new System.EventHandler(this.tbAddOrder_Click);
            // 
            // tbCommit
            // 
            this.tbCommit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbCommit.Image = global::NTS.ShopOrder.Main.Properties.Resources.check;
            this.tbCommit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbCommit.Name = "tbCommit";
            this.tbCommit.Size = new System.Drawing.Size(23, 22);
            this.tbCommit.Text = "toolStripButton2";
            this.tbCommit.ToolTipText = "Подтвердить заказ";
            this.tbCommit.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // tbClear
            // 
            this.tbClear.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbClear.Image = global::NTS.ShopOrder.Main.Properties.Resources.edit_clear;
            this.tbClear.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbClear.Name = "tbClear";
            this.tbClear.Size = new System.Drawing.Size(23, 22);
            this.tbClear.Text = "toolStripButton1";
            this.tbClear.ToolTipText = "Очистить заказ";
            this.tbClear.Click += new System.EventHandler(this.tbClear_Click);
            // 
            // listBox1
            // 
            this.listBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox1.DataSource = this.OrdersHeaderData;
            this.listBox1.DisplayMember = "Name";
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(3, 76);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(240, 420);
            this.listBox1.TabIndex = 1;
            this.listBox1.ValueMember = "id_OrderHeader";
            // 
            // OrdersHeaderData
            // 
            this.OrdersHeaderData.DataSource = typeof(DataBase.DataSet.DataSet.sp_sel_OrdersHeaderDataTable);
            // 
            // c1TrueDBGrid1
            // 
            this.c1TrueDBGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.c1TrueDBGrid1.CaptionHeight = 20;
            this.c1TrueDBGrid1.DataSource = this.CurrentOrderBalanceData;
            this.c1TrueDBGrid1.DataView = C1.Win.C1TrueDBGrid.DataViewEnum.GroupBy;
            this.c1TrueDBGrid1.DirectionAfterEnter = C1.Win.C1TrueDBGrid.DirectionAfterEnterEnum.MoveDown;
            this.c1TrueDBGrid1.ExtendRightColumn = true;
            this.c1TrueDBGrid1.FilterBar = true;
            this.c1TrueDBGrid1.GroupByCaption = "Перетащите сюда столбец для группировки";
            this.c1TrueDBGrid1.Images.Add(((System.Drawing.Image)(resources.GetObject("c1TrueDBGrid1.Images"))));
            this.c1TrueDBGrid1.Location = new System.Drawing.Point(2, 3);
            this.c1TrueDBGrid1.Name = "c1TrueDBGrid1";
            this.c1TrueDBGrid1.PreviewInfo.Location = new System.Drawing.Point(0, 0);
            this.c1TrueDBGrid1.PreviewInfo.Size = new System.Drawing.Size(0, 0);
            this.c1TrueDBGrid1.PreviewInfo.ZoomFactor = 75D;
            this.c1TrueDBGrid1.PrintInfo.PageSettings = ((System.Drawing.Printing.PageSettings)(resources.GetObject("c1TrueDBGrid1.PrintInfo.PageSettings")));
            this.c1TrueDBGrid1.RowHeight = 18;
            this.c1TrueDBGrid1.Size = new System.Drawing.Size(535, 493);
            this.c1TrueDBGrid1.TabIndex = 0;
            this.c1TrueDBGrid1.Text = "c1TrueDBGrid1";
            this.c1TrueDBGrid1.VisualStyle = C1.Win.C1TrueDBGrid.VisualStyle.Office2010Blue;
            this.c1TrueDBGrid1.BeforeColEdit += new C1.Win.C1TrueDBGrid.BeforeColEditEventHandler(this.c1TrueDBGrid1_BeforeColEdit);
            this.c1TrueDBGrid1.PropBag = resources.GetString("c1TrueDBGrid1.PropBag");
            // 
            // CurrentOrderBalanceData
            // 
            this.CurrentOrderBalanceData.DataSource = typeof(DataBase.DataSet.DataSet.sp_sel_CurrentOrderBalanceDataTable);
            // 
            // OrderView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(791, 499);
            this.Controls.Add(this.splitContainer1);
            this.Name = "OrderView";
            this.Text = "Заказы";
            this.Load += new System.EventHandler(this.OrderView_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OrdersHeaderData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1TrueDBGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CurrentOrderBalanceData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private C1.Win.C1TrueDBGrid.C1TrueDBGrid c1TrueDBGrid1;
        private System.Windows.Forms.BindingSource CurrentOrderBalanceData;
        private System.Windows.Forms.BindingSource OrdersHeaderData;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton tbAddOrder;
        private System.Windows.Forms.ToolStripButton tbCommit;
        private RadioButton radioButton2;
        private RadioButton radioButton1;
        private ToolStripButton tbClear;

    }
}