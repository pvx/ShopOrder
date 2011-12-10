using System.ComponentModel;
using System.Linq;
using System.Security.Principal;
using DataBase.DataObject;
using Microsoft.Practices.Unity;

namespace DataBase.Repository
{
    public delegate void OnChangeDenied(object sender, double quantity, double minQuantity);

    public class BalanceEditRepo : BindingList<EditGoodsBalanceObj>
    {
        private IUnityContainer unityContainer { get; set; }

        [InjectionConstructor]
        public BalanceEditRepo(IUnityContainer container)
        {
            unityContainer = container;
            Load();
        }

        void Load()
        {
            using (var oc = unityContainer.Resolve<OrderDataContext>())
            {
                var minorder = from m in oc.DataBaseContext.sp_sel_GoodsBalanceQuota()
                               select new EditGoodsBalanceObj()
                               {
                                   Barcode = m.Barcode,
                                   Code = m.Code,
                                   Group = m.Group,
                                   Measure = m.Measure,
                                   Name = m.Name,
                                   Price = m.Price.GetValueOrDefault(0),
                                   QuantityInPack = m.QuantityInPack.GetValueOrDefault(0),
                                   Supplier = m.Supplier,
                                   Quantity = m.Quantity,
                                   Quota = m.Quota,
                                   id = m.id,
                                   MinQuantity = m.MinQuantity.GetValueOrDefault(0),
                                   IsLoaded = true
                               };
                
                foreach (EditGoodsBalanceObj balanceObj in minorder)
                {
                    Add(balanceObj);
                    balanceObj.ChangeQuantity += MinOrderObjChangeMinOrder;
                    balanceObj.BeforeChangeBalance += BalanceObjBeforeChangeBalance;
                    balanceObj.ChangeQuota += BalanceObjChangeQuota;
                }

            }
        }

        void BalanceObjChangeQuota(object sender, EventChangeBalance e)
        {
            using (var oc = unityContainer.Resolve<OrderDataContext>())
            {
                oc.DataBaseContext.sp_upd_GoodsQuota(e.GoodsObj.Code, e.GoodsObj.Quota);
            }
        }

        void BalanceObjBeforeChangeBalance(object sender, ref bool allow, double quant, EventChangeBalance e)
        {
            using (var oc = unityContainer.Resolve<OrderDataContext>())
            {
                allow = oc.DataBaseContext.IsAllowCangeQuantity(e.GoodsObj.id, quant).GetValueOrDefault(false);
                if (!allow)
                    OnChangeQuantityDenied(e.GoodsObj.Quantity, e.GoodsObj.MinQuantity);
            }
        }

        void MinOrderObjChangeMinOrder(object sender, EventChangeBalance e)
        {
            using (var oc = unityContainer.Resolve<OrderDataContext>())
            {
                oc.DataBaseContext.sp_upd_GoodsBalance(e.GoodsObj.id, e.GoodsObj.Quantity, WindowsIdentity.GetCurrent().Name);
                var gb = oc.DataBaseContext.sp_sel_GoodsBalanceQuotaById(e.GoodsObj.id).Single();
                e.GoodsObj.MinQuantity = gb.MinQuantity.GetValueOrDefault(0);
            }

        }

        public event OnChangeDenied OnChangeDenied;

        protected virtual void OnChangeQuantityDenied(double quantity, double minQuantity)
        {
            if ((OnChangeDenied != null))
            {
                OnChangeDenied(this, quantity, minQuantity);
            }
        }
    }
}