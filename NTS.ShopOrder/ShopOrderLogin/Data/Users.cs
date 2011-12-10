using System;
using System.ComponentModel;
using System.Linq;
using DataBase;
using DataBase.DataObject;
using DevExpress.XtraTreeList;
using Microsoft.Practices.Unity;

namespace ShopOrderLogin.Data
{
    /// <summary>
    /// Список пользователей
    /// </summary>
    public class Users : BindingList<UserObj>, TreeList.IVirtualTreeListData
    {
        private IUnityContainer Unity { get; set; }

        [InjectionConstructor]
        public Users(IUnityContainer container)
        {
            Unity = container;
            Load();
        }

        public BindingList<sp_sel_OperationPermissionsResult> GetPermissionsList()
        {
            using (var oc = Unity.Resolve<OrderDataContext>())
            {
                 return new BindingList<sp_sel_OperationPermissionsResult>(oc.DataBaseContext.sp_sel_OperationPermissions().ToList());
            }
        }

        public void SaveUserPermission(int permission, Guid idUser)
        {
            using (var oc = Unity.Resolve<OrderDataContext>())
            {
                oc.DataBaseContext.sp_set_UserPermission(idUser, permission);
            }
        }

        private void Load()
        {
            using (var oc = Unity.Resolve<OrderDataContext>())
            {
                var us = from or in oc.DataBaseContext.sp_sel_Users()
                         select new UserObj()
                                    {
                                        Active = or.Active,
                                        DefaultPermissions = or.DefaultPermissions,
                                        IdShop = or.id_Shop,
                                        IdUser = or.id,
                                        IdUserType = or.id_UserType,
                                        Permissions = or.Permissions,
                                        UserLogin = or.UserLogin,
                                        UserName = or.UserName,
                                        UserPassword = or.UserPassword
                                    };

                foreach (UserObj userObj in us)
                {
                    Add(userObj);
                }
            }
        }

        public void VirtualTreeGetChildNodes(VirtualTreeGetChildNodesInfo info)
        {

        }

        public void VirtualTreeGetCellValue(VirtualTreeGetCellValueInfo info)
        {
            var obj = info.Node as UserObj;
            switch (info.Column.FieldName)
            {
                case "Name":
                    if (obj != null)
                        info.CellData = obj;
                    break;

            }
        }

        public void VirtualTreeSetCellValue(VirtualTreeSetCellValueInfo info)
        {
            info.Cancel = true;
        }
    }
}