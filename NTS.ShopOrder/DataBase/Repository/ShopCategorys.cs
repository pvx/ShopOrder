using System.ComponentModel;
using System.Linq;
using DataBase.DataObject;
using Microsoft.Practices.Unity;

namespace DataBase.Repository
{
    /// <summary>
    /// Класс списка категорий магазина
    /// </summary>
    public class ShopCategorys : BindingList<ShopCategoryObj>
    {
        private IUnityContainer unityContainer { get; set; }

        [InjectionConstructor]
        public ShopCategorys(IUnityContainer container)
        {
            unityContainer = container;
            Load();
        }

        void Load()
        {
            using (OrderDataContext oc = unityContainer.Resolve<OrderDataContext>())
            {
                var minorder = from m in oc.DataBaseContext.ShopCategory
                               select new ShopCategoryObj(m.CategoryName, m.id);

                foreach (ShopCategoryObj obj in minorder)
                {
                    Add(obj); 
                }

            }
        }

    }
}