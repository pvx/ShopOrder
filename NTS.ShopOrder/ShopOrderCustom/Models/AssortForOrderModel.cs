using System.Collections.Generic;
using Common;
using Common.Logger;
using DataBase.Repository;
using DevExpress.XtraEditors;
using Microsoft.Practices.Unity;
using ShopOrderCustom.UI;
using ShopOrderExcel;
using ShopOrderExcel.Interfaces;

namespace ShopOrderCustom.Models
{
    /// <summary>
    /// ћодель данных UI ассортимента к заказу
    /// </summary>
    public class AssortForOrderModel : ModelLayout
    {
        public IUnityContainer UnityContainer { get; set; }

        [Dependency]
        public IOrderUserInfo OrderUserInfo { get; set; }

        [Dependency]
        public Logger Log { get; set; }

        private XtraForm _view;

        private IList<IDataRecord> _dataExcel;

        public OrderCategorys OrderCategorys { get; set; }

        public AutoOrderModes OrderModes { get; set; } 
        
        public XtraForm View
        {
            get
            {
                if (_view == null)
                    return _view = new AssortForOrderForm(this);

                return _view;
            }
            set
            {
                if (_view == null)
                    _view = value;
            }
        }

        public void LoadFromExcel(string path)
        {
            IExcelImport ex = UnityContainer.Resolve<AssortForOrderImport>();
            _dataExcel = ex.GetDataFromExcel(path);
            foreach (IDataRecord dataRecord in _dataExcel)
            {
                OrderCategorys.CheckedGoodsByCode(dataRecord.Code);
            }
        }

        public void Save()
        {
           OrderCategorys.Save(); 
        }

        [InjectionConstructor]
        public AssortForOrderModel(IUnityContainer unityContainer) : base(unityContainer)
        {
            ViewCode = ViewConst.ED_ASSORT_FOR_ORDER;
            UnityContainer = unityContainer;
            OrderCategorys = unityContainer.Resolve<OrderCategorys>();
            OrderModes = unityContainer.Resolve<AutoOrderModes>();
        }
    }
}