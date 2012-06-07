using System;
using System.ComponentModel;
using System.Linq;
using Common;
using Common.Logger;
using DataBase;
using DataBase.DataObject;
using DevExpress.XtraEditors;
using Microsoft.Practices.Unity;
using ShopOrderCustom.UI;

namespace ShopOrderCustom.Models
{
    /// <summary>
    /// Модель данных UI просмотра заявок
    /// </summary>
    public class OrderViewerModel : ModelLayout
    {
        public event ChangeDateFilter ChangeDateFilter;

        //public IUnityContainer UnityContainer { get; set; }

        [Dependency]
        public IOrderUserInfo OrderUserInfo { get; set; }

        [Dependency]
        public Logger Log { get; set; }

        public Guid IdOrderHeader { get; set; }

        private DateTime _filterDate;

        public DateTime ServerDate
        {
            get { return _serverDate; }
        }

        public DateTime FilterDate
        {
            get
            {
                return _filterDate;
            }
            set
            {
                if ((_filterDate != value))
                {
                    _filterDate = value;
                    SendChangeDataFilter(_filterDate, _filterDateEnd);
                }
            }
        }

        public DateTime FilterDateEnd
        {
            get
            {
                return _filterDateEnd;
            }
            set
            {
                if ((_filterDateEnd != value))
                {
                    _filterDateEnd = value;
                    SendChangeDataFilter(_filterDate, _filterDateEnd);
                }
            }
        }

        private XtraForm _view;

        private OrderHeaderObj _currentOrderHeader;
        private DateTime _serverDate;
        private DateTime _filterDateEnd;

        protected virtual void SendChangeDataFilter(DateTime date, DateTime dateEnd)
        {
            if ((ChangeDateFilter != null))
            {
                ChangeDateFilter(this, new EventChangeDateFilter() { Date = date, DateEnd = dateEnd});
            }
        }

        public XtraForm View
        {
            get
            {
                if (_view == null)
                    return _view = new OrdeViewerForm(this);

                return _view;
            }
            set
            {
                if (_view == null)
                    _view = value;
            }
        }

        public OrderHeaderObj CurrentOrderHeader
        {
            get { return _currentOrderHeader; }
            set { _currentOrderHeader = value; }
        }

        private OrderShopObj _shopObj;

        public OrderShopObj ShopObj
        {
            get { return _shopObj; }
            set { _shopObj = value; }
        }


        public OrderShops GetOrdersHeader()
        {
            var os = UnityContainer.Resolve<OrderShops>();
            os.LoadAll(_filterDate, _filterDateEnd);
            return os;
        }

        public bool CanCheck(OrderHeaderObj orderHeaderObj)
        {
            bool ret = false;
            if (orderHeaderObj.IdOrderState == 2)
                if (OrderUserInfo.UserName.Equals(orderHeaderObj.LockUser) || string.IsNullOrEmpty(orderHeaderObj.LockUser))
                {
                    ret = true;
                }
                else
                    ret = false;
            return ret;
        }

        public BindingList<sp_sel_OrderGoodsByShopHistoryResult> GetOrderByShopList()
        {
            if (_shopObj != null)
            {
                using (var oc = UnityContainer.Resolve<OrderDataContext>())
                {
                    var orders = oc.DataBaseContext.sp_sel_OrderGoodsByShopHistory(_shopObj.IdShop, _filterDate, _filterDateEnd).ToList();
                    return new BindingList<sp_sel_OrderGoodsByShopHistoryResult>(orders);
                }
            }
            return null;
        }

        public BindingList<sp_sel_OrderGoodsByHeaderHistoryResult> GetOrderList()
        {
            if (_currentOrderHeader != null)
            {
                using (var oc = UnityContainer.Resolve<OrderDataContext>())
                {
                    var orders = oc.DataBaseContext.sp_sel_OrderGoodsByHeaderHistory(_currentOrderHeader.IdOrderHeader).ToList();
                    return new BindingList<sp_sel_OrderGoodsByHeaderHistoryResult>(orders);   
                }
            }
            return null;
        }

        [InjectionConstructor]
        public OrderViewerModel(IUnityContainer unityContainer) : base(unityContainer)
        {
            ViewCode = ViewConst.VIEW_ORDERS;
            //UnityContainer = unityContainer;
            _serverDate = DateTime.Parse(unityContainer.Resolve<IOrderUserInfo>().Property["SERVER_DATE"]);
            _filterDate = _serverDate;
            _filterDateEnd = _serverDate;
        }
    }
}