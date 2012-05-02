using System;
using System.ComponentModel;
using System.Linq;
using Microsoft.Practices.Unity;

namespace DataBase.DataObject
{
    public class InvoiceData : BindingList<sp_sel_InvoiceDataForReturnResult>
    {
        private IUnityContainer _container;

        [InjectionConstructor]
        public InvoiceData(IUnityContainer container)
        {
            _container = container;
        }

        public void Load(Guid shopId)
        {
            using (var oc = _container.Resolve<OrderDataContext>())
            {
                var rets = oc.DataBaseContext.sp_sel_InvoiceDataForReturn(shopId);
                foreach (var returnObj in rets)
                {
                    Add(returnObj);
                }
            }
        }

        public void Refresh(Guid shopId)
        {
            using (var oc = _container.Resolve<OrderDataContext>())
            {
                var rets = oc.DataBaseContext.sp_sel_InvoiceDataForReturnRefresh(shopId);
                foreach (var rt in rets)
                {
                    var obj = this.Where(x => x.id_Invoice == rt.id_Invoice).SingleOrDefault();
                    if (obj != null)
                    {
                        obj.Quantity = rt.Quantity;
                    }
                }
            }
        }

        private void RefreshItem(int idInvoice, sp_sel_InvoiceItemForReturnResult item)
        {
            var invItem = this.Where(x => x.id_Invoice == idInvoice).SingleOrDefault();
            if(invItem != null)
            {
                invItem.Quantity = item.Quantity;
            }
            else
            {
                var ni = new sp_sel_InvoiceDataForReturnResult()
                             {
                                 Group = item.Group,
                                 Supplier = item.Supplier,
                                 Name = item.Name,
                                 id_Invoice = item.id_Invoice,
                                 Seria = item.Seria,
                                 InvoiceDate = item.InvoiceDate,
                                 Quantity = item.Quantity,
                                 Number = item.Number,
                                 Price = item.Price,
                                 Barcode = item.Barcode
                             };
                Add(ni);
            }
        }

        public void Refresh(int idInvoice)
        {
            using (var oc = _container.Resolve<OrderDataContext>())
            {
                var rets = oc.DataBaseContext.sp_sel_InvoiceItemForReturn(idInvoice);
                foreach (var returnObj in rets)
                {
                    RefreshItem(idInvoice, returnObj);
                }
            }
        }
    }
}