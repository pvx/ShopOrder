using System.ComponentModel;
using System.Linq;
using DataBase.DataObject;
using Microsoft.Practices.Unity;

namespace DataBase.Repository
{
    public class AutoOrderModes : BindingList<AutoOrderItemObj>
    {
        private IUnityContainer unityContainer { get; set; }

        [InjectionConstructor]
        public AutoOrderModes(IUnityContainer container)
        {
            unityContainer = container;
            Load();
        }

        void Load()
        {
            using (var oc = unityContainer.Resolve<OrderDataContext>())
            {
                var minorder = from m in oc.DataBaseContext.AutoOrderModes
                               select new AutoOrderItemObj(m.Name, m.id);

                foreach (AutoOrderItemObj obj in minorder)
                {
                    Add(obj);
                }

            }
        }

    }
}