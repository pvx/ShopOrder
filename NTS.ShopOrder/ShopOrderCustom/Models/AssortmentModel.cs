using System.Collections.Generic;
using Common;
using Common.Logger;
using DataBase.DataObject;
using DataBase.Repository;
using DevExpress.XtraEditors;
using Microsoft.Practices.Unity;
using ShopOrderCustom.UI;
using ShopOrderExcel;
using ShopOrderExcel.Interfaces;

namespace ShopOrderCustom.Models
{
    /// <summary>
    /// Модель данных UI ассортимента к заказу
    /// </summary>
    public class AssortmentModel : ModelLayout
    {
        public IUnityContainer UnityContainer { get; set; }

        [Dependency]
        public IOrderUserInfo OrderUserInfo { get; set; }

        [Dependency]
        public Logger Log { get; set; }

        private ReqAssorts Assorts { get; set; }
        public ShopCategorys Categorys { get { return _shopCategorys; } }

        private ShopCategorys _shopCategorys;

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

        public void ClearCheck()
        {
            foreach (ReqAssortObj obj in Assorts)
            {
                obj.ReqAssort = false;
            }
        }

        public int LoadFromExcel(string path)
        {
            int counter = 0;
            IExcelImport ex = UnityContainer.Resolve<ReqAssortImport>();
            IList<IDataRecord> dataExcel = ex.GetDataFromExcel(path);

            foreach (IDataRecord dataRecord in dataExcel)
            {
                if (Assorts.CheckedGoodsByCode(dataRecord.Code))
                    counter++;
            }
            return counter;
        }

        public ReqAssorts GetReqAssortData(ShopCategoryObj categoryObj)
        {
            Assorts.Load(categoryObj.Id);
            return Assorts;
        }

        public void Save()
        {
            if (Assorts.Save())
                XtraMessageBox.Show("Данные успешно сохранены");
            else
                XtraMessageBox.Show("Ошибка сохранения");
        }   

        [InjectionConstructor]
        public AssortmentModel(IUnityContainer unityContainer) : base(unityContainer)
        {
            ViewCode = ViewConst.ED_REQ_ASSORT;
            UnityContainer = unityContainer;
            Assorts = unityContainer.Resolve<ReqAssorts>();
            _shopCategorys = unityContainer.Resolve<ShopCategorys>();
        }
    }
}