using Common;
using Common.Logger;
using DevExpress.XtraEditors;
using Microsoft.Practices.Unity;

namespace ShopOrderCustom
{
    public class AssortmentModel: ModelBase
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
                    return _view = new AssortimentForm(this);

                return _view;
            }
            set
            {
                if (_view == null)
                    _view = value;
            }
        }

        [InjectionConstructor]
        public AssortmentModel(IUnityContainer unityContainer)
        {
            UnityContainer = unityContainer;
        }
    }
}