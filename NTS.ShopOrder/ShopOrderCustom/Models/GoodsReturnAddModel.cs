using System;
using System.Linq;using Common;
using Common.Logger;
using DataBase;
using DataBase.DataObject;
using Microsoft.Practices.Unity;

namespace ShopOrderCustom.Models
{
    public class GoodsReturnAddModel : ModelBase
    {
        [Dependency]
        public Logger Log { get; set; }
/*
        private XtraForm _view;
        public XtraForm View
        {
            get
            {
                if (_view == null)
                    return _view = new GoodsReturnAddDlg(this);

                return _view;
            }
            set
            {
                if (_view == null)
                    _view = value;
            }
        }
        */
        private IUnityContainer _unityContainer;
        private InvoiceData invoiceData;
        
        [InjectionConstructor]
        public GoodsReturnAddModel(IUnityContainer unityContainer)
        {
            _unityContainer = unityContainer;
            invoiceData = _unityContainer.Resolve<InvoiceData>();
            invoiceData.Load(Guid.Parse(_unityContainer.Resolve<IOrderUserInfo>().Property["USER_SHOP"]));
        }

        public void RemoveReturnItem(ReturnItemObj itemObj)
        {
            invoiceData.Refresh(itemObj.InvoiceDataId);
        }

        public ReturnItemObj InsertNewItem()
        {

            return null;
        }

        public bool EditItem(ReturnItemObj itemObj)
        {
            return true;
        }

        public InvoiceData GetInvoiceData()
        {
            return invoiceData;
        }

        public ReasonData GetReasonData()
        {
            var data = _unityContainer.Resolve<ReasonData>();
            data.Load();
            return data;
        }

        private ReturnItemObj ReturnItemObj { get; set; }

        public ReturnItemObj GetReturnItemObj()
        {
            return ReturnItemObj;
        }

        public void SetSelReturn(sp_sel_InvoiceDataForReturnResult ret, sp_sel_ReturnReasonsResult reason, decimal value)
        {
            ret.Quantity -= double.Parse(value.ToString());

            ReturnItemObj = new ReturnItemObj()
                          {
                              Group = ret.Group,
                              InvoiceDate = ret.InvoiceDate,
                              Name = ret.Name,
                              LotNumber = string.Format("{0} {1}", ret.Seria, ret.Number),
                              InvoiceDataId = ret.id_Invoice,
                              Price = ret.Price,
                              Quantity = ret.Quantity,
                              QuantityRet = double.Parse(value.ToString()),
                              Supplier = ret.Supplier,
                              ReturnReasonId = reason.id,
                              Barcode = ret.Barcode,
                              ReturnPositionStateId = 1,
                              Code = ret.Code
                          };

        }

        public sp_sel_InvoiceDataForReturnResult EdititItem { get; set; }

        public void EditReturnItemObj(ReturnItemObj item)
        {
           IsEdit = true;
            var inv = invoiceData.Where(x => x.id_Invoice == item.InvoiceDataId).SingleOrDefault();
            if(inv != null)
            {
                inv.Quantity += item.QuantityRet;
                inv.QuantityRet = item.QuantityRet;
                inv.ReturnReasonId = item.ReturnReasonId;
                EdititItem = inv;
            }
                
            else
            {
                EdititItem = new sp_sel_InvoiceDataForReturnResult()
                                 {
                                     Group = item.Group,
                                     InvoiceDate = item.InvoiceDate,
                                     Supplier = item.Supplier,
                                     Name = item.Name,
                                     Price = item.Price,
                                     Quantity = item.QuantityRet,
                                     Number = item.LotNumber,
                                     Seria = item.LotNumber,
                                     id_Invoice = item.InvoiceDataId,
                                     QuantityRet = item.QuantityRet,
                                     ReturnReasonId = item.ReturnReasonId,
                                     Barcode = item.Barcode,
                                     Code = item.Code
                                 };
                invoiceData.Add(EdititItem);
            }    
            
        }

        public void RefreshInvoiceData()
        {
            if (IsChanged)
            {
                invoiceData.Refresh(Guid.Parse(_unityContainer.Resolve<IOrderUserInfo>().Property["USER_SHOP"]));
                IsChanged = false;
            }
        }

        private bool _isChanged;
        public bool IsChanged
        {
            get { return _isChanged; }
            set { _isChanged = value; }
        }

        public bool IsEdit { get; set; }
    }
}