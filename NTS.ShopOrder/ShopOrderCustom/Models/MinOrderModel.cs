using Common;
using Common.Logger;
using DataBase.DataObject;
using DataBase.Repository;
using DevExpress.XtraEditors;
using Microsoft.Practices.Unity;
using ShopOrderCustom.Models;

namespace ShopOrderCustom
{
    /// <summary>
    /// ћодель данных UI редактора минимального заказа
    /// </summary>
    public class MinOrderModel : ModelLayout
    {
        public IUnityContainer UnityContainer { get; set; }

        [Dependency]
        public IOrderUserInfo OrderUserInfo { get; set; }

        [Dependency]
        public Logger Log { get; set; }

        public ShopCategorys Categorys { get { return _shopCategorys; } }

        private ShopCategorys _shopCategorys;


        private XtraForm _view;
        public XtraForm View
        {
            get
            {
                if (_view == null)
                    return _view = new MinOrderForm(this);

                return _view;
            }
            set
            {
                if (_view == null)
                    _view = value;
            }
        }

        public MinOrders GetMinOrderData(ShopCategoryObj obj)
        {
            var minOrders = UnityContainer.Resolve<MinOrders>();
            if (minOrders != null)
            {
                minOrders.Load(obj.Id);              
            }
            return minOrders;
        }

        [InjectionConstructor]
        public MinOrderModel(IUnityContainer unityContainer) : base(unityContainer)
        {
            ViewCode = ViewConst.ED_MIN_ORDER;
            UnityContainer = unityContainer;
            _shopCategorys = unityContainer.Resolve<ShopCategorys>();
        }
    }
}