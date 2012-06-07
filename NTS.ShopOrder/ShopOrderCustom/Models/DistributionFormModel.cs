using Common;
using Common.Logger;
using DataBase.Repository;
using DevExpress.XtraEditors;
using Microsoft.Practices.Unity;
using ShopOrderCustom.TreeData;
using ShopOrderCustom.UI;

namespace ShopOrderCustom.Models
{
    public class DistributionFormModel : ModelLayout
    {
        [Dependency]
        public Logger Log { get; set; }

        public XtraForm View
        {
            get
            {
                if (_view == null)
                    return _view = new DistributionForm(this);

                return _view;
            }
            set
            {
                if (_view == null)
                    _view = value;
            }
        }
        
        public ShopCategorys ShopCategorys { get { return _shopCategorys; } }
       // public GoodsCategoryNode OrderCategorys { get { return UnityContainer.Resolve<GoodsCategoryNode>(); ; } }

        public GoodsCategoryNode GetCategoryNode(int ShopCategoryId)
        {
            var cr = UnityContainer.Resolve<GoodsCategoryNode>();
            cr.ShopCategoryId = ShopCategoryId;
            cr.Load();
            return cr;
        }

        private XtraForm _view;
        private ShopCategorys _shopCategorys;
        private GoodsCategoryNode _orderCategorys;

        [InjectionConstructor]
        public DistributionFormModel(IUnityContainer unityContainer)
            : base(unityContainer)
        {
            ViewCode = ViewConst.ED_DISTRIBUTION;
            _shopCategorys = unityContainer.Resolve<ShopCategorys>();
        }
    }
}