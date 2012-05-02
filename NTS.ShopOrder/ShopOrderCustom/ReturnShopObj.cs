using System;
using System.ComponentModel;
using DataBase.DataObject;

namespace ShopOrderCustom
{
    public class ReturnShopObj : NotifyDataObjectBase
    {
        private string _ShopCode;
        private string _ShopName;
        private Guid _id_Shop;

        private ReturnItemPool _returnItems = new ReturnItemPool();

        public ReturnItemPool ReturnItemsPool
        {
            get { return _returnItems; }
      
        }

        public override string ToString()
        {
            return string.Format("{0} - [{1}]", ShopCode, ShopName);
        }

        public Returns Returns { get; set; }

        public bool IsCommitPresent()
        {
            bool ret = false;

            foreach (ReturnObj obj in Returns)
            {
                if (obj.ReturnStateId == 2)
                    ret = true;
            }
            return ret;
        }


        public Guid ShopId
        {
            get { return _id_Shop; }
            set
            {
                if ((_id_Shop != value))
                {
                    SendPropertyChanging("ShopId");
                    _id_Shop = value;
                    SendPropertyChanged("ShopId");
                }
            }
        }

        public string ShopName
        {
            get { return _ShopName; }
            set
            {
                if ((_ShopName != value))
                {
                    SendPropertyChanging("ShopName");
                    _ShopName = value;
                    SendPropertyChanged("ShopName");
                }
            }
        }

        public string ShopCode
        {
            get { return _ShopCode; }
            set
            {
                if ((_ShopCode != value))
                {
                    SendPropertyChanging("ShopCode");
                    _ShopCode = value;
                    SendPropertyChanged("ShopCode");
                }
            }
        }
    }
}

