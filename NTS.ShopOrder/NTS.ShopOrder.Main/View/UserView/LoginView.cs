using System;
using System.Data;
using System.Windows.Forms;
using Common;
using System.Data.SqlClient;
using Common.Logger;
using DataBase;
using Microsoft.Practices.Unity;

namespace NTS.ShopOrder.Main.View.UserView
{
    public partial class LoginView : Form
    {
        private IOrderUserInfo OrderUserInfo { get; set; }

        private IOrderConnection OrderConnection { get; set; }

        [Dependency]
        public IUnityContainer UnityContainer { get; set; }

        [Dependency]
        public Logger Log { get; set; }

        [InjectionConstructor]
        public LoginView(IOrderUserInfo orderUserInfo)
        {
            InitializeComponent();
            OrderUserInfo = orderUserInfo;
            BindingControls();
        }

        private void BindingControls()
        {
            tbLogin.DataBindings.Add(new Binding("Text", OrderUserInfo, "UserName"));
            tbPassword.DataBindings.Add(new Binding("Text", OrderUserInfo, "UserPassword"));
            lbInfo.DataBindings.Add(new Binding("Text", OrderUserInfo, "Info"));
        }

        private void BtEnterClick(object sender, EventArgs e)
        {
            Login();
        }

        private void SetUserProperty()
        {
            using(OrderDataContext orderDataContext = UnityContainer.Resolve<OrderDataContext>())
            {
                UnityContainer.Resolve<IOrderUserInfo>().Property =
                Utility.StringToDict(orderDataContext.DataBaseContext.GetUser());
            }
        }

        private void Login()
        {
            OrderConnection = UnityContainer.Resolve<IOrderConnection>();
            try
            {
                using (SqlConnection conn = OrderConnection.GetSqlConnection())
                {
                    conn.Open();
                    if (conn.State == ConnectionState.Open)
                        DialogResult = DialogResult.OK;
                }
                SetUserProperty();
            }
            catch (Exception ex)
            {
                Log.Error("Ошибка подключения к базе данных.", ex);
            }
        }

        private void LoginView_Load(object sender, EventArgs e)
        {
            
        }

        private void btCancel_Click(object sender, EventArgs e)
        {

        }
    }
}
