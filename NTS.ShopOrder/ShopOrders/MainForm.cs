using System;
using System.Linq;
using System.Security.Principal;
using System.Windows.Forms;
using Common;
using Common.Enum;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using Microsoft.Practices.Unity;
using ReportCore;
using ShopOrderCustom;
using ShopOrderCustom.Models;
using ShopOrderLogin;

namespace ShopOrders
{
    public partial class MainForm : XtraForm
    {
        string skinMask = "�����: ";
        private IUnityContainer unityContainer { get; set; }
        private MainModel Model { get; set; }

        public MainForm(MainModel model)
        {
            Model = model;
            InitializeComponent();
            unityContainer = model.UnityContainer;
            InitSkins();
            InitReports();
        }

        private void InitReports()
        {
            var repm = unityContainer.Resolve<IReportManager>().GetReportsList();
            if (repm == null)
                mReports.Visibility = BarItemVisibility.Never;
            else
            {
                var groups = (from gr in repm where !string.IsNullOrEmpty(gr.Group) select gr.Group).Distinct();
                foreach (string gr in groups)
                {
                    var subitm = new BarSubItem(barManager, gr);
                    mReports.AddItem(subitm );
                    var itm = repm.Where(it => it.Group == gr);
                    foreach (var item in itm.Select(reportRecord => new BarButtonItem(barManager, reportRecord.Name) { Tag = reportRecord.Id }))
                    {
                        item.ItemClick += OnReportClick;
                        subitm.AddItem(item);
                    }
                }

                var rpwg = repm.Where(it => string.IsNullOrEmpty(it.Group));
                foreach (var item in rpwg.Select(reportRecord => new BarButtonItem(barManager, reportRecord.Name) { Tag = reportRecord.Id }))
                {
                    item.ItemClick += OnReportClick;
                    mReports.AddItem(item);
                }             
            }
        }

        private void OnReportClick(object sender, ItemClickEventArgs e)
        {
            unityContainer.Resolve<IReportManager>().ShowReport(Guid.Parse(e.Item.Tag.ToString()));
        }

        /*
        static bool Check(byte permission, byte code)
        {
            return (permission & code) == code;
        }

        static bool CheckPermission(byte permission, Permission prm)
        {
            return Check(permission, (byte) prm);
        }

        BarItemVisibility GetPermission(Permission prm)
        {
            var perm = (byte)unityContainer.Resolve<IOrderUserInfo>().Permission;
            return CheckPermission(perm, prm) ? BarItemVisibility.Always : BarItemVisibility.Never;        
        }
        */

        static bool Check(short permission, short code)
        {
            return (permission & code) == code;
        }

        static bool CheckPermission(short permission, Permission prm)
        {
            return Check(permission, (short)prm);
        }

        BarItemVisibility GetPermission(Permission prm)
        {
            var perm = (short)unityContainer.Resolve<IOrderUserInfo>().Permission;
            return CheckPermission(perm, prm) ? BarItemVisibility.Always : BarItemVisibility.Never;
        }

        void SetPermissionUi()
        {
            mAssort.Visibility = GetPermission(Permission.EditReqAssort);
            mCreateOrder.Visibility = GetPermission(Permission.CreateOrder);
            mProcessOrder.Visibility = GetPermission(Permission.ProcessOrders);
            mMinorder.Visibility = GetPermission(Permission.EditMinOrder);
            mAssortOrder.Visibility = GetPermission(Permission.EditAssortForOrder);
            mViewOrder.Visibility = GetPermission(Permission.ViewOrders);
            mViewActualAssort.Visibility = GetPermission(Permission.ViewActualAssort);
            mUsers.Visibility = GetPermission(Permission.EditUsers);
            mBalanceEditor.Visibility = GetPermission(Permission.EditBalance);
            mReports.Visibility = GetPermission(Permission.ReportView);
            mGoodsReturn.Visibility = GetPermission(Permission.CreateReturn);
            mGoodsReturnSt.Visibility = GetPermission(Permission.CreateReturnSt);
            mDistributionGoods.Visibility = GetPermission(Permission.DistributionGoods);
            miPreOrder.Visibility = GetPermission(Permission.CreatePreOrder);
        }

        private void MainFormLoad(object sender, System.EventArgs e)
        {
            if (Model.Login())
            {
                SetPermissionUi();
                Text = FormatCaption();
            }
        }

        string FormatCaption()
        {     
            var usr = unityContainer.Resolve<IOrderUserInfo>();
            string username = usr.UserName;
            string shop = usr.Property["SHOP_NAME"];
            
            WindowsIdentity wi = WindowsIdentity.GetCurrent();
            string wuName = string.Empty;
            if (wi != null)
                wuName = wi.Name;
            return string.Format("{0} {1} ({2} | {3}) ��� ��������: {4}", Text, Application.ProductVersion, username, wuName, shop);
        }

        private void INewItemClick(object sender, ItemClickEventArgs e)
        {
            Model.ShowForm(typeof(OrderModel));
        }

        private void IOpenItemClick(object sender, ItemClickEventArgs e)
        {
            Model.ShowForm(typeof(OrderManagerModel));
        }

        private void BarButtonItem1ItemClick(object sender, ItemClickEventArgs e)
        {
            Model.ShowForm(typeof(AssortmentModel));
        }

        private void BarButtonItem1ItemClick1(object sender, ItemClickEventArgs e)
        {
            Model.ShowForm(typeof(MinOrderModel));
        }

        private void MAssortOrderItemClick(object sender, ItemClickEventArgs e)
        {
            Model.ShowForm(typeof(AssortForOrderModel));
        }

        private void MUsersItemClick(object sender, ItemClickEventArgs e)
        {
            Model.ShowForm(typeof(UserManagerModel));
        }

        #region Skins

        void InitSkins()
        {
            barManager.ForceInitialize();
            foreach (DevExpress.Skins.SkinContainer cnt in DevExpress.Skins.SkinManager.Default.Skins)
            {
                var item = new BarButtonItem(barManager, skinMask + cnt.SkinName);
                iPaintStyle.AddItem(item);
                item.ItemClick += new ItemClickEventHandler(OnSkinClick);
            }
        }
        void OnSkinClick(object sender, ItemClickEventArgs e)
        {
            string skinName = e.Item.Caption.Replace(skinMask, @"");
            DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle(skinName);
            barManager.GetController().PaintStyleName = "Skin";
            iPaintStyle.Caption = e.Item.Caption;
            iPaintStyle.Hint = iPaintStyle.Caption;
            iPaintStyle.ImageIndex = -1;
        }
        #endregion

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            Model.ShowForm(typeof(OrderViewerModel));
        }
        
        private void MViewActualAssortItemClick(object sender, ItemClickEventArgs e)
        {
            Model.ShowForm(typeof(ActualAssortViewerModel));
        }

        private void MBalanceEditorItemClick(object sender, ItemClickEventArgs e)
        {
            Model.ShowForm(typeof(BalanceEditorModel));
        }

        private void MGoodsReturnItemClick(object sender, ItemClickEventArgs e)
        {
            Model.ShowForm(typeof(GoodsReturnModel));
        }

        private void MGoodsReturnStItemClick(object sender, ItemClickEventArgs e)
        {
            Model.ShowForm(typeof(GoodsReturnStateModel));
        }

        private void MDistributionGoodsItemClick(object sender, ItemClickEventArgs e)
        {
            Model.ShowForm(typeof(DistributionFormModel));
        }

        private void miPreOrder_ItemClick(object sender, ItemClickEventArgs e)
        {
            Model.ShowForm(typeof(PreOrderModel));
        }
    }
}