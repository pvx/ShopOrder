using System;
using System.ComponentModel;
using Microsoft.Practices.Unity;

namespace DataBase.DataObject
{
    public class ReasonData : BindingList<sp_sel_ReturnReasonsResult>
    {
        private IUnityContainer _container;

        [InjectionConstructor]
        public ReasonData(IUnityContainer container)
        {
            _container = container;
        }

        public void Load()
        {
            using (var oc = _container.Resolve<OrderDataContext>())
            {
                var rets = oc.DataBaseContext.sp_sel_ReturnReasons();
                foreach (var returnObj in rets)
                {
                    Add(returnObj);
                }
            }
        }
    }
}