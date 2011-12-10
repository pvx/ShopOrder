using System;
using System.Windows.Forms;
using Common;
using Common.Logger;
using DataBase;
using DataBase.Log;
using DataBase.Repository;
using DevExpress.LookAndFeel;
using Microsoft.Practices.Unity;
using ShopOrderCustom;
using ShopOrderCustom.Models;
using ShopOrderExcel;
using ShopOrderExcel.Interfaces;
using ShopOrderLogin;
using ShopOrderLogin.Data;
using ShopOrders.Properties;


namespace ShopOrders
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            DevExpress.Skins.SkinManager.EnableFormSkins();
            DevExpress.UserSkins.OfficeSkins.Register();
            DevExpress.UserSkins.BonusSkins.Register();

            UserLookAndFeel.Default.SetSkinStyle(DateTime.Now.Date == DateTime.Parse("31.12.2011")
                                                     ? "Xmas 2008 Blue"
                                                     : "DevExpress Style");
            using (IUnityContainer container = new UnityContainer())
            {
                container.RegisterType<Logger>();
                container.RegisterType<IOrderUserInfo, OrderUserInfo>(new ContainerControlledLifetimeManager(),
                                        new InjectionConstructor(Settings.Default.Server,
                                        Settings.Default.Database,
                                        Settings.Default.User,
                                        Settings.Default.Password));

                container.RegisterType<IOrderConnection, OrderConnection>();
                container.RegisterType<OrderDataContext>();
                container.RegisterType<IDBLogger, DBLogger>();
                
                container.RegisterType<IExcelImport, AssortForOrderImport>();
                container.RegisterType<IExcelImport, ReqAssortImport>();
                container.RegisterType<IExcelImport, NestleOrderImport>();

                container.RegisterType<Orders>();
                container.RegisterType<OrderShops>();
                container.RegisterType<MinOrders>();
                container.RegisterType<ReqAssorts>();
                container.RegisterType<ShopCategorys>();
                container.RegisterType<GroupAssort>();
                container.RegisterType<OrderCategorys>();
                container.RegisterType<GoodsAssorts>();
                container.RegisterType<Users>();
                container.RegisterType<BalanceEditRepo>();

                container.RegisterType<LoginModel>();
                container.RegisterType<UserManagerModel>();
                container.RegisterType<OrderViewerModel>();
                container.RegisterType<OrderModel>();
                container.RegisterType<OrderManagerModel>();
                container.RegisterType<AssortmentModel>();
                container.RegisterType<MinOrderModel>();
                container.RegisterType<AssortForOrderModel>();
                container.RegisterType<ActualAssortViewerModel>();
                container.RegisterType<BalanceEditorModel>();
                container.RegisterType<MainModel>();

                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("ru-RU");
                Application.Run(container.Resolve<MainModel>().View);
            }
        }
    }
}