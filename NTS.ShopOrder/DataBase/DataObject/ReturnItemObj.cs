using System;
using System.Collections.Generic;

namespace DataBase.DataObject
{
    public class ReturnItemObj : NotifyDataObjectBase
    {
        public delegate void ChangeReturnPositionState(object sender, EventChangeReturnPositionState e);

        private string _group;
        private int _invoiceDataId;
        private DateTime _invoiceDate;
        private string _lotNumber;
        private string _name;
        private decimal _price;
        private double _quantity;
        private double _quantityRet;
        private Guid _returnHeaderId;
        private int _returnReasonId;
        private List<ReturnReasonObj> _returnReasonObjs;
        private string _supplier;
        private Guid _id;

        public event ChangeReturnPositionState OnChangeReturnPositionState;

        protected virtual void SendChangeReturnPositionState()
        {
            if ((OnChangeReturnPositionState != null))
            {
                OnChangeReturnPositionState(this, new EventChangeReturnPositionState() { Item = this });
            }
        }

        public string Code
        {
            get { return _code; }
            set
            {
                if ((_code != value))
                {
                    SendPropertyChanging("Code");
                    _code = value;
                    SendPropertyChanged("Code");
                }
            }
        }

        public ReturnItemObj()
        {
            Id = Guid.NewGuid();
            IsLoaded = false;
        }

        public bool IsLoaded { get; set; }

        public void CopyFrom(ReturnItemObj itemObj)
        {
            Group = itemObj.Group;
            InvoiceDataId = itemObj.InvoiceDataId;
            InvoiceDate = itemObj.InvoiceDate;
            LotNumber = itemObj.LotNumber;
            Name = itemObj.Name;
            Price = itemObj.Price;
            Quantity = itemObj.Quantity;
            QuantityRet = itemObj.QuantityRet;
            //_returnHeaderId = itemObj.ReturnHeaderId;
            //_returnReasonObjs = itemObj.ReturnReasonObjs;
            Supplier = itemObj.Supplier;
            ReturnReasonId = itemObj.ReturnReasonId;
            Id = itemObj.Id;
            ReturnPositionStateId = itemObj.ReturnPositionStateId;
            Barcode = itemObj.Barcode;
            Code = itemObj.Code;
        }

        private int _returnPositionStateId;
        public int ReturnPositionStateId
        {
            get { return _returnPositionStateId; }
            set
            {
                var oldval = _returnPositionStateId;
                SendPropertyChanging("ReturnPositionStateId");
                _returnPositionStateId = value;
                SendPropertyChanged("ReturnPositionStateId");
                if ((IsLoaded) && (oldval != _returnPositionStateId))
                    SendChangeReturnPositionState();
            }
        }

        public List<ReturnReasonObj> ReturnReasonObjs
        {
            get { return _returnReasonObjs; }
            set
            {
                SendPropertyChanging("ReturnReasonObjs");
                _returnReasonObjs = value;
                SendPropertyChanged("ReturnReasonObjs");
            }
        }

        private string _barcode;
        private string _code;

        public string Barcode
        {
            get { return _barcode; }
            set
            {
                SendPropertyChanging("Barcode");
                _barcode = value;
                SendPropertyChanged("Barcode");
            }
        }

        public int ReturnReasonId
        {
            get { return _returnReasonId; }
            set
            {
                SendPropertyChanging("ReturnReasonId");
                _returnReasonId = value;
                SendPropertyChanged("ReturnReasonId");
            }
        }

        public Guid Id
        {
            get { return _id; }
            set
            {
                SendPropertyChanging("Id");
                _id = value;
                SendPropertyChanged("Id");
            }
        }

        public Guid ReturnHeaderId
        {
            get { return _returnHeaderId; }
            set
            {
                SendPropertyChanging("ReturnHeaderId");
                _returnHeaderId = value;
                SendPropertyChanged("ReturnHeaderId");
            }
        }

        public int InvoiceDataId
        {
            get { return _invoiceDataId; }
            set
            {
                SendPropertyChanging("InvoiceDataId");
                _invoiceDataId = value;
                SendPropertyChanged("InvoiceDataId");
            }
        }

        public string Name
        {
            get { return _name; }
            set
            {
                SendPropertyChanging("Name");
                _name = value;
                SendPropertyChanged("Name");
            }
        }

        public string Group
        {
            get { return _group; }
            set
            {
                SendPropertyChanging("Group");
                _group = value;
                SendPropertyChanged("Group");
            }
        }

        public string Supplier
        {
            get { return _supplier; }
            set
            {
                SendPropertyChanging("Supplier");
                _supplier = value;
                SendPropertyChanged("Supplier");
            }
        }

        public string LotNumber
        {
            get { return _lotNumber; }
            set
            {
                SendPropertyChanging("LotNumber");
                _lotNumber = value;
                SendPropertyChanged("LotNumber");
            }
        }

        public decimal Price
        {
            get { return _price; }
            set
            {
                SendPropertyChanging("Price");
                _price = value;
                SendPropertyChanged("Price");
            }
        }

        public DateTime InvoiceDate
        {
            get { return _invoiceDate; }
            set
            {
                SendPropertyChanging("InvoiceDate");
                _invoiceDate = value;
                SendPropertyChanged("InvoiceDate");
            }
        }

        public double Quantity
        {
            get { return _quantity; }
            set
            {
                SendPropertyChanging("Quantity");
                _quantity = value;
                SendPropertyChanged("Quantity");
            }
        }

        public double QuantityRet
        {
            get { return _quantityRet; }
            set
            {
                SendPropertyChanging("QuantityRet");
                _quantityRet = value;
                SendPropertyChanged("QuantityRet");
            }
        }
    }
}