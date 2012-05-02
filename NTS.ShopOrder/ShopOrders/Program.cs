using System;
using System.Diagnostics;
using System.Windows.Forms;
using Common;
using Common.Logger;
using DataBase;
using DataBase.DataObject;
using DataBase.Log;
using DataBase.Repository;
using DevExpress.LookAndFeel;
using Microsoft.Practices.Unity;
using ReportCore;
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
            AppDomain.CurrentDomain.UnhandledException += OnUnhandledException;
            DevExpress.Skins.SkinManager.EnableFormSkins();
            DevExpress.UserSkins.OfficeSkins.Register();
            DevExpress.UserSkins.BonusSkins.Register();

            UserLookAndFeel.Default.SetSkinStyle("DevExpress Style");
            using (IUnityContainer container = new UnityContainer())
            {
                container.RegisterType<Logger>();
                container.RegisterType<IOrderUserInfo, OrderUserInfo>(new ContainerControlledLifetimeManager(),
                                        new InjectionConstructor(Settings.Default.Server,
                                        Settings.Default.Database,
                                        Settings.Default.User,
                                        Settings.Default.Password,
                                        Settings.Default.ReportFolder));

                container.RegisterType<IOrderConnection, OrderConnection>();
                container.RegisterType<OrderDataContext>();
                container.RegisterType<IDBLogger, DBLogger>();
                
                container.RegisterType<IExcelImport, AssortForOrderImport>();
                container.RegisterType<IExcelImport, ReqAssortImport>();
                container.RegisterType<IExcelImport, NestleOrderImport>();
                container.RegisterType<IExcelImport, ExcelOrderImport>();

                container.RegisterType<Orders>();
                container.RegisterType<OrderShops>();
                container.RegisterType<MinOrders>();
                container.RegisterType<ReqAssorts>();
                container.RegisterType<ShopCategorys>();
                container.RegisterType<AutoOrderModes>();
                container.RegisterType<GroupAssort>();
                container.RegisterType<OrderCategorys>();
                container.RegisterType<GoodsAssorts>();
                container.RegisterType<Users>();
                container.RegisterType<BalanceEditRepo>();
                container.RegisterType<ReturnItems>();
                container.RegisterType<Returns>();
                container.RegisterType<InvoiceData>();
                container.RegisterType<ReasonData>();
                container.RegisterType<ReturnShops>();

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
                container.RegisterType<GoodsReturnModel>();
                container.RegisterType<GoodsReturnStateModel>();
                container.RegisterType<GoodsReturnAddModel>();
                container.RegisterType<MainModel>();

                container.RegisterInstance<IReportManager>(container.Resolve<ReportManager>());

                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("ru-RU");
                Application.Run(container.Resolve<MainModel>().View);
            }
        }

        static void OnUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            try
            {
                var ex = (Exception)e.ExceptionObject;
                const string errorMsg = "An application error occurred. Please contact the adminstrator " +
                                        "with the following information:\n\n";

                if (!EventLog.SourceExists("ThreadException"))
                {
                    EventLog.CreateEventSource("ThreadException", "Application");
                }

                var myLog = new EventLog {Source = "ThreadException"};
                myLog.WriteEntry(errorMsg + ex.Message + "\n\nStack Trace:\n" + ex.StackTrace);

                MessageBox.Show(ex.Message, "Œ¯Ë·Í‡", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            catch (Exception exc)
            {
                try
                {
                    MessageBox.Show("Fatal Non-UI Error",
                        "Fatal Non-UI Error. Could not write the error to the event log. Reason: "
                        + exc.Message, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                finally
                {
                    Application.Exit();
                }
            }
        }
    }
}