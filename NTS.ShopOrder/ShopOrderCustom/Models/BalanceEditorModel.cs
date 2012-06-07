using Common;
using Common.Logger;
using DataBase.Repository;
using DevExpress.XtraEditors;
using Microsoft.Practices.Unity;
using ShopOrderCustom.UI;

namespace ShopOrderCustom.Models
{
    /// <summary>
    /// Класс модели данных редактора остатков
    /// </summary>
    public class BalanceEditorModel : ModelLayout
    {
        //public IUnityContainer UnityContainer { get; set; }

        [Dependency]
        public IOrderUserInfo OrderUserInfo { get; set; }

        [Dependency]
        public Logger Log { get; set; }

        private BalanceEditRepo _editRepo;
        public BalanceEditRepo EditRepo
        {
            get { return _editRepo; }
            set { _editRepo = value; }
        }

        private XtraForm _view;
        public XtraForm View
        {
            get
            {
                if (_view == null)
                    return _view = new BalanceEditorForm(this);

                return _view;
            }
            set
            {
                if (_view == null)
                    _view = value;
            }
        }

        [InjectionConstructor]
        public BalanceEditorModel(IUnityContainer unityContainer)
            : base(unityContainer)
        {
            ViewCode = ViewConst.ED_BALANCE;
            //UnityContainer = unityContainer;
            _editRepo = UnityContainer.Resolve<BalanceEditRepo>();
        }

        public object RefreshData(OnChangeDenied changeDenied)
        {   _editRepo = UnityContainer.Resolve<BalanceEditRepo>();
            _editRepo.OnChangeDenied += changeDenied;
            return _editRepo;
        }

        public object GetData()
        {
            return _editRepo;
        }
    }
}