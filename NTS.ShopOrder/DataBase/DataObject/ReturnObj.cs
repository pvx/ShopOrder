using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Practices.Unity;

namespace DataBase.DataObject
{
    public class ReturnObj : NotifyDataObjectBase
    {
        private readonly IUnityContainer _container;
        private DateTime _createDate;
        private Guid _id;

        private string _name;
        private ReturnItems _returnItems;
        private int _returnStateId;
        private List<ReturnStateObj> _returnStateObjs;

        private Guid _userId;
        private string _winLogin;

        public ReturnObj(IUnityContainer container)
        {
            _container = container;
        }

        private ReturnItemPool _returnItemsPool;
        public ReturnItemPool ReturnItemsPool
        {
            get { return _returnItemsPool; }
            set { _returnItemsPool = value; }
        }

        public ReturnItems ReturnItems
        {
            get { return _returnItems; }
        }

        public bool IsCanChangeState()
        {
            return _returnItems.IsCanChangeState();
        }

        private bool _checked;
        public bool Checked
        {
            get { return _checked; }
            set
            {
                _checked = value;
                LoadItems();
                if (_checked)
                {
                    foreach (var item in ReturnItems)
                    {
                        if(ReturnItemsPool.IndexOf(item) < 0)
                            ReturnItemsPool.Add(item);    
                    }                    
                }
                else
                {
                    foreach (var item in ReturnItems)
                    {
                        ReturnItemsPool.Remove(item);
                    }
                }
            }
        }
        public bool CanEdit { get { return IsCanEdit(); } }

        private bool IsCanEdit()
        {

            return _returnStateId == 2;
        }

        public bool CanCheck { get { return IsCanCheck(); } }

        private bool IsCanCheck()
        {
            return _returnStateId == 2;
        }

        public List<ReturnStateObj> ReturnStateObjs
        {
            get { return _returnStateObjs; }
            set
            {
                SendPropertyChanging("ReturnStateObjs");
                _returnStateObjs = value;
                SendPropertyChanged("ReturnStateObjs");
            }
        }

        public Guid Id
        {
            get { return _id; }
            set
            {
                SendPropertyChanging("Id");
                _id = value;
                SendPropertyChanged("Id");
            }
        }

        public string Name
        {
            get { return GetName(); }
        }

        public Guid UserId
        {
            get { return _userId; }
            set
            {
                SendPropertyChanging("UserId");
                _userId = value;
                SendPropertyChanged("UserId");
            }
        }

        public int ReturnStateId
        {
            get { return _returnStateId; }
            set
            {
                SendPropertyChanging("ReturnStateId");
                _returnStateId = value;
                SendPropertyChanged("ReturnStateId");
                SendPropertyChanged("Name");
            }
        }

        public DateTime CreateDate
        {
            get { return _createDate; }
            set
            {
                SendPropertyChanging("CreateDate");
                _createDate = value;
                SendPropertyChanged("CreateDate");
            }
        }

        public string WinLogin
        {
            get { return _winLogin; }
            set
            {
                SendPropertyChanging("WinLogin");
                _winLogin = value;
                SendPropertyChanged("WinLogin");
            }
        }

        private string GetName()
        {
            string name = string.Empty;

            ReturnStateObj state = ReturnStateObjs.Where(stateObj => stateObj.Id == _returnStateId).SingleOrDefault();

            if (state != null)
                name = state.Name;
            return string.Format("{0:MM.dd HH:mm:ss} [{1}]", _createDate, name);
        }

        public void CommitReturn()
        {
            ReturnStateId = 2;
        }

        public void CreateReturn()
        {
            ReturnStateId = 3;
        }

        public void CreateItems()
        {
            _returnItems = _container.Resolve<ReturnItems>();
            _returnItems.ReturnId = _id;
        }

        public void AddNewItem(ReturnItemObj itemObj)
        {
            ReturnItemObj item = null;
            if (_returnItems != null)
            {
                try
                {
                    item = _returnItems.CreateNew();
                    item.CopyFrom(itemObj);

                    InsertDb(item);
                }
                catch (Exception e)
                {
                    _returnItems.Remove(item);
                    throw;
                }
            }
        }

        public void EditItem(Guid id, ReturnItemObj itemObj)
        {
            if (_returnItems != null)
            {
                var item = _returnItems.Where(x => x.Id == id).SingleOrDefault();
                if (item != null)
                {
                    item.CopyFrom(itemObj);
                    EditDb(id, item);
                }
            }
        }

        private void EditDb(Guid id, ReturnItemObj itemObj)
        {
            if (itemObj != null)
            {
                using (var oc = _container.Resolve<OrderDataContext>())
                {
                    oc.DataBaseContext.sp_upd_ReturnItem(id, itemObj.ReturnHeaderId, itemObj.InvoiceDataId,
                                                         itemObj.ReturnReasonId, itemObj.QuantityRet);
                }
            }
        }

        private void InsertDb(ReturnItemObj itemObj)
        {
            if (itemObj != null)
            {
                using (var oc = _container.Resolve<OrderDataContext>())
                {
                    oc.DataBaseContext.sp_ins_ReturnItem(itemObj.Id, itemObj.ReturnHeaderId, itemObj.InvoiceDataId,
                                                         itemObj.ReturnReasonId, itemObj.QuantityRet);
                }
            }
        }

        public void LoadItems()
        {
            if ((_returnItems != null) && (!_returnItems.IsLoaded))
                _returnItems.Load(_id);
        }

        public override string ToString()
        {
            return Name;
        }
    }
}