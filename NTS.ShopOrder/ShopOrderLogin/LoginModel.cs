using System.Windows.Forms;
using Common;
using Common.Logger;
using DevExpress.XtraEditors;
using Microsoft.Practices.Unity;

namespace ShopOrderLogin
{
    /// <summary>
    /// Модель данных UI входа в программу
    /// </summary>
    public class LoginModel : ModelBase
    {
        public IUnityContainer UnityContainer { get; set; }

        [Dependency]
        public IOrderUserInfo OrderUserInfo { get; set; }

        [Dependency]
        public Logger Log { get; set; }

        private XtraForm _view;
        public XtraForm View
        {
            get
            {
                if (_view == null)
                    return _view = new LoginForm(this);

                return _view;
            }
            set
            {
                if (_view == null)
                    _view = value;
            }
        }

        [InjectionConstructor]
        public LoginModel(IUnityContainer unityContainer)
        {
            UnityContainer = unityContainer;
        }
    }
}