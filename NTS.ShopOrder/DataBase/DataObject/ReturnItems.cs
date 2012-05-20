using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Microsoft.Practices.Unity;

namespace DataBase.DataObject
{
    public class ReturnItems : BindingList<ReturnItemObj>
    {
        private IUnityContainer UnityContainer { get; set; }
        public List<ReturnReasonObj> ReturnReasons { get; private set; }
        public List<ReturnPosStateObj> ReturnStatePos { get; private set; }
        

        public bool IsLoaded { get; private set; }

        [InjectionConstructor]
        public ReturnItems(IUnityContainer container)
        {
            UnityContainer = container;
            LoadReasons();
            LoadStatePos();
            IsLoaded = false;
        }

        public Guid ReturnId { get; set; }

        public ReturnItemObj CreateNew()
        {
            var item = new ReturnItemObj() {ReturnHeaderId = ReturnId, ReturnReasonObjs = ReturnReasons};
            Add(item);
            return item;
        }

        public bool IsCanChangeState()
        {
            bool ret = false;

            foreach (ReturnItemObj item in Items)
            {
                if (ReturnStatePos.Where(x => x.StateCode == "AGREEDNTS" || x.StateCode == "NOTAGREED").Any(x => x.Id == item.ReturnPositionStateId))
                    ret = true;
                else
                    return false;
            }
            return ret;
        }

        public void Load(Guid returnId)
        {
            using (var oc = UnityContainer.Resolve<OrderDataContext>())
            {
                var rets = (from o in oc.DataBaseContext.sp_sel_ReturnItems(returnId)
                            select new ReturnItemObj()
                            {
                               Group = o.Group,
                               Name = o.Name,
                               Supplier = o.Supplier,
                               InvoiceDataId = o.id_InvoiceData,
                               InvoiceDate = o.InvoiceDate,
                               LotNumber = string.Format("{0} {1}", o.Seria, o.Number),
                               Price = o.Price,
                               Quantity = o.Quantity,
                               QuantityRet = o.QuantityRet,
                               ReturnHeaderId = o.id_ReturnHeader,
                               ReturnReasonId = o.id_ReturnReason,
                               ReturnReasonObjs = ReturnReasons,
                               Id = o.id,
                               ReturnPositionStateId = o.id_ReturnPositionState,
                               Barcode = o.Barcode,
                               Code = o.Code
                            });
                foreach (var returnObj in rets)
                {
                    Add(returnObj);
                    returnObj.OnChangeReturnPositionState += returnObj_OnChangeReturnPositionState;
                    returnObj.IsLoaded = true;
                }
            }
            IsLoaded = true;
        }

        void returnObj_OnChangeReturnPositionState(object sender, EventChangeReturnPositionState e)
        {
            using (var oc = UnityContainer.Resolve<OrderDataContext>())
            {
                if(e.Item != null)
                    oc.DataBaseContext.sp_upd_ReturnStatesPos(e.Item.Id, e.Item.ReturnPositionStateId);
            }
        }

        private void LoadReasons()
        {
            using (var oc = UnityContainer.Resolve<OrderDataContext>())
            {
                ReturnReasons = (from or in oc.DataBaseContext.sp_sel_ReturnReasons()
                                 select new ReturnReasonObj() { Id = or.id, Name = or.Name }).ToList();
            }
        }
        private void LoadStatePos()
        {
            using (var oc = UnityContainer.Resolve<OrderDataContext>())
            {
                ReturnStatePos = (from or in oc.DataBaseContext.sp_sel_ReturnStatesPos()
                                  select new ReturnPosStateObj() { Id = or.id, Name = or.Name, StateCode = or.StateCode }).ToList();
            }
        }
    }
}