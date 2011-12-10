using System;
using System.Collections.Generic;
using System.Linq;
using DataBase.DataObject;
using Microsoft.Practices.Unity;

namespace DataBase.Repository
{
    [Obsolete]
    public class GoodsOrderRepo
    {
        [Dependency]
        public IUnityContainer UnityContainer { get; set; }

        public List<GoodsObject> GoodsObjectList { get; set; }

        private OrderDataContext _orderDataContext;

        public GoodsOrderRepo()
        {

        }

        public void Init()
        {
            Load();
        }

        private void Load()
        {
            using (_orderDataContext = UnityContainer.Resolve<OrderDataContext>())
            {
                var qr = from c in _orderDataContext.DataBaseContext.vGoodsBalance
                         where c.Date.Date == DateTime.Now.Date
                         select new GoodsObject() {
                            Barcode = c.Barcode,
                            Code = c.Code, Date = c.Date, 
                            FreeBalance = c.FreeBalance.GetValueOrDefault(0),
                            Group = c.GoodsGroup, 
                            Id = c.id_GoodsBalance,
                            Measure = c.Measure,
                            MinOrder = c.MinOrder.GetValueOrDefault(0),
                            Name = c.Name,
                            Price = c.Price.GetValueOrDefault(0),
                            Quantity = c.Balance.GetValueOrDefault(0),
                            QuantityInPack = c.QuantityInPack.GetValueOrDefault(0),
                            RequeryQuantity = c.ReqQuantity,
                            Reserved = c.Reserved.GetValueOrDefault(0),
                            Supplier = c.Supplier
                         };

                GoodsObjectList = qr.ToList();
            }
        }
    }
}