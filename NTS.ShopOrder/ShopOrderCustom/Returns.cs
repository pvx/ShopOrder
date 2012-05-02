using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Principal;
using Common;
using DataBase;
using DataBase.DataObject;
using DataBase.Log;
using DevExpress.XtraTreeList;
using Microsoft.Practices.Unity;

namespace ShopOrderCustom
{
    public class Returns : BindingList<ReturnObj>, TreeList.IVirtualTreeListData
    {
        private IUnityContainer UnityContainer { get; set; }
        private Guid _userId;
        private Guid _shopId;
        private List<ReturnStateObj> ReturnStates { get; set; }

        public ReturnItemPool ReturnItemsPool { get; set; }
        
        [InjectionConstructor]
        public Returns(IUnityContainer container)
        {
            UnityContainer = container;
            _userId = new Guid(UnityContainer.Resolve<IOrderUserInfo>().Property["USER_ID"]);
            _shopId = new Guid(UnityContainer.Resolve<IOrderUserInfo>().Property["USER_SHOP"]);
            LoadStates();
        }


        #region IVirtualTreeListData

        public void VirtualTreeGetChildNodes(VirtualTreeGetChildNodesInfo info)
        {
            
        }

        public void VirtualTreeGetCellValue(VirtualTreeGetCellValueInfo info)
        {
            var obj = info.Node as ReturnObj;
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

        #endregion    

        private void LoadStates()
        {
            using (var oc = UnityContainer.Resolve<OrderDataContext>())
            {
                ReturnStates = (from or in oc.DataBaseContext.sp_sel_ReturnStates()
                                   select new ReturnStateObj() {Id = or.id, Name = or.Name}).ToList();
            }
        }

        public bool CommitAll()
        {
            bool ret = true;
            foreach (ReturnObj obj in this.Where(obj => obj.ReturnStateId == 1))
            {
                if(obj.ReturnItems.Count > 0)
                {
                    obj.CommitReturn();
                    ChangeReturnState(obj);
                }
                else
                {
                    ret = false;
                }
            }
            return ret;
        }

        public void ChangeReturnState(ReturnObj obj)
        {
            if (obj != null)
            {
                using (var oc = UnityContainer.Resolve<OrderDataContext>())
                {
                    WindowsIdentity wi = WindowsIdentity.GetCurrent();
                    oc.DataBaseContext.sp_upd_ReturnHeaderState(obj.Id,
                                                                obj.ReturnStateId,
                                                                wi.Name);
                }
            }
        }

        public void AddReturnHeader()
        {
            WindowsIdentity wi = WindowsIdentity.GetCurrent();
            var newret = new ReturnObj(UnityContainer)
                             {
                                 Id = Guid.NewGuid(),
                                 CreateDate = DateTime.Now,
                                 ReturnStateObjs = ReturnStates,
                                 ReturnStateId = 1,
                                 UserId = _userId,
                                 WinLogin = wi.Name
                             };
            using (var oc = UnityContainer.Resolve<OrderDataContext>())
            {
                oc.DataBaseContext.sp_ins_ReturnHeader(newret.Id, newret.ReturnStateId, newret.UserId,
                                                       newret.WinLogin);
            }
            newret.CreateItems();
            Add(newret);
            UnityContainer.Resolve<IDBLogger>().InsertLog("Создание возврата", newret.Id.ToString().ToUpper());
        }

        public void LoadSt(Guid shopId, DateTime date)
        {
            using (var oc = UnityContainer.Resolve<OrderDataContext>())
            {
                var rets = (from or in oc.DataBaseContext.sp_sel_ReturnHeaderOnDateSt(shopId, date)
                            select new ReturnObj(UnityContainer)
                            {
                                CreateDate = or.CreateDate,
                                Id = or.id_ReturnHeader,
                                ReturnStateObjs = ReturnStates,
                                ReturnStateId = or.id_ReturnState,
                                UserId = or.id_User
                            }).OrderBy(x => x.CreateDate);
                foreach (var returnObj in rets)
                {
                    returnObj.CreateItems();
                    Add(returnObj);
                    returnObj.ReturnItemsPool = ReturnItemsPool;
                }
            }
        }

        public void Load(DateTime date)
        {
            using (var oc = UnityContainer.Resolve<OrderDataContext>())
            {
                var rets = (from or in oc.DataBaseContext.sp_sel_ReturnHeaderOnDate(_shopId, date)
                            select new ReturnObj(UnityContainer)
                            {
                                CreateDate = or.CreateDate,
                                                   Id = or.id,
                                                   ReturnStateObjs = ReturnStates,
                                                   ReturnStateId = or.id_ReturnState,
                                                   UserId = or.id_User,
                                                   WinLogin = or.WinLogin
                           }).OrderBy(x=>x.CreateDate);
                foreach (var returnObj in rets)
                {
                    returnObj.CreateItems();
                    Add(returnObj);
                }
            }
        }
    }
}