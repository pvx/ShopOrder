using System.ComponentModel;
using System.Linq;
using DataBase.DataObject;
using Microsoft.Practices.Unity;

namespace DataBase.Repository
{
    /// <summary>
    /// Класс списка позиций товаров для формы минимального заказа
    /// </summary>
    public class MinOrders : BindingList<MinOrderObj>
    {
        private IUnityContainer unityContainer { get; set; }
        private int IdShopCategory { get; set; }

        [InjectionConstructor]
        public MinOrders(IUnityContainer container)
        {
            unityContainer = container;
        }
        
        public void Load(int idShopCategory)
        {
            IdShopCategory = idShopCategory;
            using (var oc = unityContainer.Resolve<OrderDataContext>())
            {
                var minorder = from m in oc.DataBaseContext.sp_sel_MinOrderByShopCategory(idShopCategory)
                               select new MinOrderObj() 
                               {
                               Active = m.Active,
                               Barcode = m.Barcode,
                               Code = m.Code,
                               Group = m.Group,
                               Measure = m.Measure,
                               MinOrder = m.MinOrder,
                               Name = m.Name,
                               Price = m.Price.GetValueOrDefault(0),
                               QuantityInPack = m.QuantityInPack.GetValueOrDefault(0),
                               Supplier = m.Supplier,
                               SAPMinOrder = m.SAPMinOrder.GetValueOrDefault(0)
                               };
                foreach (MinOrderObj minOrderObj in minorder)
                {
                    Add(minOrderObj);
                    minOrderObj.ChangeMinOrder += MinOrderObjChangeMinOrder;
                }
                
            }
        }

        void MinOrderObjChangeMinOrder(object sender, EventChangeMinOrder e)
        {
            using (var oc = unityContainer.Resolve<OrderDataContext>())
            {
                 oc.DataBaseContext.sp_EditMinOrder(e.MinOrdObj.Code, e.MinOrdObj.MinOrder, IdShopCategory);
            }
        }
    }
}