namespace Supervisor
{
    partial class SupervisorForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SupervisorForm));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.tvOrders = new System.Windows.Forms.TreeView();
            this.dbGrid = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
            this.bindingSource = new System.Windows.Forms.BindingSource();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dbGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
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
            this.splitContainer1.Panel1.Controls.Add(this.toolStrip1);
            this.splitContainer1.Panel1.Controls.Add(this.tvOrders);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dbGrid);
            this.splitContainer1.Size = new System.Drawing.Size(910, 486);
            this.splitContainer1.SplitterDistance = 282;
            this.splitContainer1.TabIndex = 0;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(282, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "toolStripButton1";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // tvOrders
            // 
            this.tvOrders.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tvOrders.CheckBoxes = true;
            this.tvOrders.Location = new System.Drawing.Point(3, 38);
            this.tvOrders.Name = "tvOrders";
            this.tvOrders.Size = new System.Drawing.Size(276, 445);
            this.tvOrders.TabIndex = 0;
            this.tvOrders.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tvOrders_AfterCheck);
            this.tvOrders.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvOrders_AfterSelect);
            // 
            // dbGrid
            // 
            this.dbGrid.AllowUpdate = false;
            this.dbGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dbGrid.CaptionHeight = 20;
            this.dbGrid.DataSource = this.bindingSource;
            this.dbGrid.DataView = C1.Win.C1TrueDBGrid.DataViewEnum.GroupBy;
            this.dbGrid.DirectionAfterEnter = C1.Win.C1TrueDBGrid.DirectionAfterEnterEnum.MoveDown;
            this.dbGrid.ExtendRightColumn = true;
            this.dbGrid.FilterBar = true;
            this.dbGrid.GroupByCaption = "Перетащите сюда столбец для группировки";
            this.dbGrid.Images.Add(((System.Drawing.Image)(resources.GetObject("dbGrid.Images"))));
            this.dbGrid.Location = new System.Drawing.Point(3, 3);
            this.dbGrid.Name = "dbGrid";
            this.dbGrid.PreviewInfo.Location = new System.Drawing.Point(0, 0);
            this.dbGrid.PreviewInfo.Size = new System.Drawing.Size(0, 0);
            this.dbGrid.PreviewInfo.ZoomFactor = 75D;
            this.dbGrid.PrintInfo.PageSettings = ((System.Drawing.Printing.PageSettings)(resources.GetObject("dbGrid.PrintInfo.PageSettings")));
            this.dbGrid.PropBag = resources.GetString("dbGrid.PropBag");
            this.dbGrid.RowHeight = 18;
            this.dbGrid.Size = new System.Drawing.Size(618, 480);
            this.dbGrid.TabIndex = 0;
            this.dbGrid.Text = "c1TrueDBGrid1";
            // 
            // SupervisorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(910, 486);
            this.Controls.Add(this.splitContainer1);
            this.Name = "SupervisorForm";
            this.Text = "SupervisorForm";
            this.Load += new System.EventHandler(this.SupervisorForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dbGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView tvOrders;
        private C1.Win.C1TrueDBGrid.C1TrueDBGrid dbGrid;
        private System.Windows.Forms.BindingSource bindingSource;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
    }
}