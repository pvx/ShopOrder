using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using Common;
using Common.Logger;
using DataBase;
using DataBase.DataObject;
using DevExpress.XtraEditors;
using Microsoft.Practices.Unity;
using ShopOrderCustom.UI;

namespace ShopOrderCustom.Models
{
    public class GoodsReturnStateModel : ModelLayout
    {
        private readonly DateTime _serverDate;
  
        private DateTime _filterDate;
        private XtraForm _view;

        public List<ReturnReasonObj> ReturnReasons { get; private set; }
        public List<ReturnPosStateObj> ReturnStatePos { get; private set; }

        public bool AllowEdit { get { return IsAllowEdit(); } }

        [InjectionConstructor]
        public GoodsReturnStateModel(IUnityContainer unityContainer)
            : base(unityContainer)
        {
            ViewCode = ViewConst.ED_GOODRETURN_STATE;
            this.unityContainer = unityContainer;
            _serverDate = DateTime.Parse(unityContainer.Resolve<IOrderUserInfo>().Property["SERVER_DATE"]);
            LoadReasons();
            LoadStatePos();
        }

        public ReturnItems GetReturnList()
        {
            if (_currentReturnHeader != null)
            {
                _currentReturnHeader.LoadItems();
                
                return _currentReturnHeader.ReturnItems;
            }
            return null;
        }

        public ReturnShopObj CurrentReturnShop { get; set; }

        private ReturnObj _currentReturnHeader;
        public ReturnObj CurrentReturnHeader
        {
            get { return _currentReturnHeader; }
            set { _currentReturnHeader = value; }
        }

        public bool IsAllowRollback()
        {
            return _serverDate.Date == _filterDate.Date;
        }

        private bool IsAllowEdit()
        {
            return true;//((_currentReturnHeader.ReturnStateId == 1) && (_serverDate.Date == _currentReturnHeader.CreateDate.Date));
        }
        public IUnityContainer unityContainer { get; set; }

        [Dependency]
        public Logger Log { get; set; }

        public XtraForm View
        {
            get
            {
                if (_view == null)
                    return _view = new GoodsReturnStateForm(this);

                return _view;
            }
            set
            {
                if (_view == null)
                    _view = value;
            }
        }

        public DateTime FilterDate
        {
            get { return _filterDate; }
            set
            {
                if ((_filterDate != value))
                {
                    _filterDate = value;
                    SendChangeDataFilter(_filterDate);
                }
            }
        }

        public event ChangeDateFilter ChangeDateFilter;

        protected virtual void SendChangeDataFilter(DateTime date)
        {
            if ((ChangeDateFilter != null))
            {
                ChangeDateFilter(this, new EventChangeDateFilter { Date = date });
            }
        }

        public ReturnShops GetReturnShop()
        {
            var ret = unityContainer.Resolve<ReturnShops>();
            ret.Load(_filterDate);
            return ret;  
        }

        private void LoadReasons()
        {
            using (var oc = unityContainer.Resolve<OrderDataContext>())
            {
                ReturnReasons = (from or in oc.DataBaseContext.sp_sel_ReturnReasons()
                                 select new ReturnReasonObj() { Id = or.id, Name = or.Name }).ToList();
            }
        }
        private void LoadStatePos()
        {
            using (var oc = unityContainer.Resolve<OrderDataContext>())
            {
                ReturnStatePos = (from or in oc.DataBaseContext.sp_sel_ReturnStatesPos()
                                  select new ReturnPosStateObj() { Id = or.id, Name = or.Name, StateCode = or.StateCode }).ToList();
            }
        }

        public void ChangeReturnState(ReturnObj obj)
        {
            if (obj != null)
            {
                //_currentReturnHeader.CommitReturn();
                using (var oc = unityContainer.Resolve<OrderDataContext>())
                {
                    WindowsIdentity wi = WindowsIdentity.GetCurrent();
                    oc.DataBaseContext.sp_upd_ReturnHeaderState(obj.Id,
                                                                obj.ReturnStateId,
                                                                wi.Name);
                }
            }    
        }
    }
}