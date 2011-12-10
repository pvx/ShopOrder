using System;
using System.Windows.Forms;
using Common;
using Supervisor;
using Common.Logger;
using DataBase;
using DataBase.DataSet;
using DataBase.Repository;
using Microsoft.Practices.Unity;
using NTS.ShopOrder.Main.View;
using NTS.ShopOrder.Main.Properties;
using NTS.ShopOrder.Main.View.UserView;

namespace NTS.ShopOrder.Main
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
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

                container.RegisterType<OrderRepo>();
                
                container.RegisterType<DataClass>();
                container.RegisterType<OrderView>();
                container.RegisterType<SupervisorModel>();

                container.RegisterType<LoginView>();
                container.RegisterType<MainView>();
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(container.Resolve<MainView>());
            }
        }
    }
}
