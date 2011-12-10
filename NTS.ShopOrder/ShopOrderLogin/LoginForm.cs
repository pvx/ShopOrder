using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Common;
using DataBase;
using DevExpress.XtraEditors;
using Microsoft.Practices.Unity;

namespace ShopOrderLogin
{
    public partial class LoginForm : XtraForm
    {
        private LoginModel Model {get; set;}

        public LoginForm(LoginModel model)
        {
            InitializeComponent();
            Model = model;
            BindingControls();
        }
        
        private void BindingControls()
        {
            tbLogin.DataBindings.Add(new Binding("Text", Model.OrderUserInfo, "UserName"));
            tbPassword.DataBindings.Add(new Binding("Text", Model.OrderUserInfo, "UserPassword"));
            this.DataBindings.Add(new Binding("Text", Model.OrderUserInfo, "Info"));
        }

        private void SetUserProperty()
        {
            using (OrderDataContext orderDataContext = Model.UnityContainer.Resolve<OrderDataContext>())
            {
                Model.UnityContainer.Resolve<IOrderUserInfo>().Property =
                Utility.StringToDict(orderDataContext.DataBaseContext.GetUser());
            }
        }
        
        private void Login()
        {
            panelControl.ContentImage = Properties.Resources.login_photo;
            IOrderConnection orderConnection = Model.UnityContainer.Resolve<IOrderConnection>();
            try
            {
                using (SqlConnection conn = orderConnection.GetSqlConnection())
                {
                    conn.Open();
                    if (conn.State == ConnectionState.Open)
                        DialogResult = DialogResult.OK;
                }
                SetUserProperty();
            }
            catch (Exception ex)
            {
                panelControl.ContentImage = Properties.Resources.login_photo_;
                XtraMessageBox.Show("Ошибка подключения к базе данных");
                Model.Log.Error("Ошибка подключения к базе данных.", ex);
            }
        }

        private void LoginButtonOk(object sender, EventArgs e)
        {
            Login();
            
        }
    }
}