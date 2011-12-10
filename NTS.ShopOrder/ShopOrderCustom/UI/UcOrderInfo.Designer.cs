namespace ShopOrderCustom.UI
{
	partial class UcOrderInfo
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
            this.propertyGrid = new DevExpress.XtraVerticalGrid.PropertyGridControl();
            ((System.ComponentModel.ISupportInitialize)(this.propertyGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // propertyGrid
            // 
            this.propertyGrid.AutoGenerateRows = true;
            this.propertyGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGrid.Location = new System.Drawing.Point(0, 0);
            this.propertyGrid.Name = "propertyGrid";
            this.propertyGrid.OptionsBehavior.Editable = false;
            this.propertyGrid.Size = new System.Drawing.Size(563, 526);
            this.propertyGrid.TabIndex = 0;
            // 
            // UcOrderInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.propertyGrid);
            this.Name = "UcOrderInfo";
            this.Size = new System.Drawing.Size(563, 526);
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.UcOrderInfo_PreviewKeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.propertyGrid)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

        private DevExpress.XtraVerticalGrid.PropertyGridControl propertyGrid;
	}
}
