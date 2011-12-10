using System;
using System.Collections.Generic;
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
    /// Модель данных UI актуального ассортимента
    /// </summary>
    public class ActualAssortViewerModel : ModelLayout
    {

        public IUnityContainer UnityContainer { get; set; }

        [Dependency]
        public IOrderUserInfo OrderUserInfo { get; set; }

        [Dependency]
        public Logger Log { get; set; }

        private XtraForm _view;

        private OrderShopObj _currentShop;

        public XtraForm View
        {
            get
            {
                if (_view == null)
                    return _view = new ActualAssortViewerForm(this);

                return _view;
            }
            set
            {
                if (_view == null)
                    _view = value;
            }
        }

        public OrderShopObj CurrentShop
        {
            get { return _currentShop; }
            set { _currentShop = value; }
        }

        public OrderShops GetOrdersHeader()
        {
            var os = UnityContainer.Resolve<OrderShops>();
            os.LoadAllShops();
            return os;
        }

        public BindingList<sp_sel_ActualShopAssortResult> GetOrderList()
        {
            if (_currentShop != null)
            {
                using (var oc = UnityContainer.Resolve<OrderDataContext>())
                {
                    var orders = oc.DataBaseContext.sp_sel_ActualShopAssort(_currentShop.IdShop).ToList();
                    return new BindingList<sp_sel_ActualShopAssortResult>(orders);   
                }
            }
            return null;
        }

        [InjectionConstructor]
        public ActualAssortViewerModel(IUnityContainer unityContainer) : base(unityContainer)
        {
            ViewCode = ViewConst.VIEW_ACTUAL_ASSORT;
            UnityContainer = unityContainer;
        }
    }
}