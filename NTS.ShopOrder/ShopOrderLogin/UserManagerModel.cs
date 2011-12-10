using Common;
using Common.Logger;
using DataBase.DataObject;
using DevExpress.XtraEditors;
using Microsoft.Practices.Unity;
using ShopOrderLogin.Data;

namespace ShopOrderLogin
{
    /// <summary>
    /// Модель данных UI менеджера пользователей
    /// </summary>
    public class UserManagerModel : ModelBase
    {
        private IUnityContainer UnityContainer { get; set; }

        [Dependency]
        public IOrderUserInfo OrderUserInfo { get; set; }

        [Dependency]
        public Logger Log { get; set; }

        public Users UserList { get; set; }

        private XtraForm _view;
        public XtraForm View
        {
            get
            {
                if (_view == null)
                    return _view = new UserManagerForm(this);

                return _view;
            }
            set
            {
                if (_view == null)
                    _view = value;
            }
        }

        public void Save(UserObj userObj)
        {
            UserList.SaveUserPermission(userObj.Permissions, userObj.IdUser);
        }


        [InjectionConstructor]
        public UserManagerModel(IUnityContainer unityContainer)
        {
            UnityContainer = unityContainer;
            UserList = UnityContainer.Resolve<Users>();
        }
    }
}