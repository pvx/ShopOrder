namespace ShopOrders
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.barManager = new DevExpress.XtraBars.BarManager();
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.mOperation = new DevExpress.XtraBars.BarSubItem();
            this.mCreateOrder = new DevExpress.XtraBars.BarButtonItem();
            this.mProcessOrder = new DevExpress.XtraBars.BarButtonItem();
            this.mAssort = new DevExpress.XtraBars.BarButtonItem();
            this.mMinorder = new DevExpress.XtraBars.BarButtonItem();
            this.mAssortOrder = new DevExpress.XtraBars.BarButtonItem();
            this.mViewOrder = new DevExpress.XtraBars.BarButtonItem();
            this.mViewActualAssort = new DevExpress.XtraBars.BarButtonItem();
            this.mBalanceEditor = new DevExpress.XtraBars.BarButtonItem();
            this.mUsers = new DevExpress.XtraBars.BarButtonItem();
            this.iPaintStyle = new DevExpress.XtraBars.BarSubItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.iClose = new DevExpress.XtraBars.BarButtonItem();
            this.iAbout = new DevExpress.XtraBars.BarButtonItem();
            this.xtraTabbedMdiManager1 = new DevExpress.XtraTabbedMdi.XtraTabbedMdiManager();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // barManager
            // 
            this.barManager.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar2});
            this.barManager.DockControls.Add(this.barDockControlTop);
            this.barManager.DockControls.Add(this.barDockControlBottom);
            this.barManager.DockControls.Add(this.barDockControlLeft);
            this.barManager.DockControls.Add(this.barDockControlRight);
            this.barManager.Form = this;
            this.barManager.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.mOperation,
            this.barButtonItem2,
            this.mProcessOrder,
            this.iClose,
            this.mCreateOrder,
            this.iAbout,
            this.mAssort,
            this.mMinorder,
            this.mAssortOrder,
            this.mUsers,
            this.iPaintStyle,
            this.mViewOrder,
            this.mViewActualAssort,
            this.mBalanceEditor});
            this.barManager.MainMenu = this.bar2;
            this.barManager.MaxItemId = 21;
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.mOperation),
            new DevExpress.XtraBars.LinkPersistInfo(this.mUsers),
            new DevExpress.XtraBars.LinkPersistInfo(this.iPaintStyle)});
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // mOperation
            // 
            this.mOperation.Caption = "&��������";
            this.mOperation.Id = 0;
            this.mOperation.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.mCreateOrder),
            new DevExpress.XtraBars.LinkPersistInfo(this.mProcessOrder),
            new DevExpress.XtraBars.LinkPersistInfo(this.mAssort),
            new DevExpress.XtraBars.LinkPersistInfo(this.mMinorder),
            new DevExpress.XtraBars.LinkPersistInfo(this.mAssortOrder),
            new DevExpress.XtraBars.LinkPersistInfo(this.mViewOrder),
            new DevExpress.XtraBars.LinkPersistInfo(this.mViewActualAssort),
            new DevExpress.XtraBars.LinkPersistInfo(this.mBalanceEditor)});
            this.mOperation.Name = "mOperation";
            // 
            // mCreateOrder
            // 
            this.mCreateOrder.Caption = "�������� �������";
            this.mCreateOrder.Id = 6;
            this.mCreateOrder.Name = "mCreateOrder";
            this.mCreateOrder.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.INewItemClick);
            // 
            // mProcessOrder
            // 
            this.mProcessOrder.Caption = "������������ �������";
            this.mProcessOrder.Id = 4;
            this.mProcessOrder.Name = "mProcessOrder";
            this.mProcessOrder.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.IOpenItemClick);
            // 
            // mAssort
            // 
            this.mAssort.Caption = "������������ �����������";
            this.mAssort.Id = 12;
            this.mAssort.Name = "mAssort";
            this.mAssort.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BarButtonItem1ItemClick);
            // 
            // mMinorder
            // 
            this.mMinorder.Caption = "����������� �����";
            this.mMinorder.Id = 13;
            this.mMinorder.Name = "mMinorder";
            this.mMinorder.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BarButtonItem1ItemClick1);
            // 
            // mAssortOrder
            // 
            this.mAssortOrder.Caption = "����������� � ������";
            this.mAssortOrder.Id = 14;
            this.mAssortOrder.Name = "mAssortOrder";
            this.mAssortOrder.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.MAssortOrderItemClick);
            // 
            // mViewOrder
            // 
            this.mViewOrder.Caption = "�������� �������";
            this.mViewOrder.Id = 18;
            this.mViewOrder.Name = "mViewOrder";
            this.mViewOrder.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem1_ItemClick);
            // 
            // mViewActualAssort
            // 
            this.mViewActualAssort.Caption = "�������� ����������� ������������";
            this.mViewActualAssort.Id = 19;
            this.mViewActualAssort.Name = "mViewActualAssort";
            this.mViewActualAssort.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.MViewActualAssortItemClick);
            // 
            // mBalanceEditor
            // 
            this.mBalanceEditor.Caption = "�������� ������� ��������";
            this.mBalanceEditor.Id = 20;
            this.mBalanceEditor.Name = "mBalanceEditor";
            this.mBalanceEditor.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.MBalanceEditorItemClick);
            // 
            // mUsers
            // 
            this.mUsers.Caption = "������������";
            this.mUsers.Id = 15;
            this.mUsers.Name = "mUsers";
            this.mUsers.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.MUsersItemClick);
            // 
            // iPaintStyle
            // 
            this.iPaintStyle.Caption = "�����";
            this.iPaintStyle.Id = 17;
            this.iPaintStyle.Name = "iPaintStyle";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(889, 22);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 477);
            this.barDockControlBottom.Size = new System.Drawing.Size(889, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 22);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 455);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(889, 22);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 455);
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "Open";
            this.barButtonItem2.Id = 2;
            this.barButtonItem2.Name = "barButtonItem2";
            // 
            // iClose
            // 
            this.iClose.Caption = "&Close";
            this.iClose.Id = 5;
            this.iClose.Name = "iClose";
            // 
            // iAbout
            // 
            this.iAbout.Caption = "&About";
            this.iAbout.Id = 11;
            this.iAbout.Name = "iAbout";
            // 
            // xtraTabbedMdiManager1
            // 
            this.xtraTabbedMdiManager1.MdiParent = this;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(889, 477);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "��� ����� �������";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarSubItem mOperation;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraBars.BarButtonItem mProcessOrder;
        private DevExpress.XtraBars.BarButtonItem iClose;
        private DevExpress.XtraBars.BarButtonItem mCreateOrder;
        private DevExpress.XtraBars.BarButtonItem iAbout;
        private DevExpress.XtraBars.BarButtonItem mAssort;
        private DevExpress.XtraBars.BarButtonItem mMinorder;
        private DevExpress.XtraBars.BarButtonItem mAssortOrder;
        private DevExpress.XtraBars.BarButtonItem mUsers;
        private DevExpress.XtraTabbedMdi.XtraTabbedMdiManager xtraTabbedMdiManager1;
        private DevExpress.XtraBars.BarSubItem iPaintStyle;
        private DevExpress.XtraBars.BarButtonItem mViewOrder;
        private DevExpress.XtraBars.BarButtonItem mViewActualAssort;
        private DevExpress.XtraBars.BarButtonItem mBalanceEditor;

    }
}
