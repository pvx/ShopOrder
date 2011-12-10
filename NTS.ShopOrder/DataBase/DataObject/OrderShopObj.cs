using System;

namespace DataBase.DataObject
{
    /// <summary>
    /// Класс описания данных магазина
    /// </summary>
    public partial class OrderShopObj
    {
        private string _shopAddress;
        private string _shopCode;
        private string _shopName;
        private string _userLogin;
        private int? _idShopCategory;
        private Guid? _idShopOwner;
        private Guid _idShop;
        private Guid _idUser;

        public Object Orders { get; set; }

        public override string ToString()
        {
            return string.Format("{0} - [{1}]", ShopCode, ShopName);
        }

        public Guid IdShop
        {
            get { return _idShop; }
            set
            {
                if ((_idShop != value))
                {
                    _idShop = value;
                }
            }
        }

        public string ShopName
        {
            get { return _shopName; }
            set
            {
                if ((_shopName != value))
                {
                    _shopName = value;
                }
            }
        }

        public string ShopAddress
        {
            get { return _shopAddress; }
            set
            {
                if ((_shopAddress != value))
                {
                    _shopAddress = value;
                }
            }
        }

        public string ShopCode
        {
            get { return _shopCode; }
            set
            {
                if ((_shopCode != value))
                {
                    _shopCode = value;
                }
            }
        }

        public Guid? IdShopOwner
        {
            get { return _idShopOwner; }
            set
            {
                if ((_idShopOwner != value))
                {
                    _idShopOwner = value;
                }
            }
        }

        public int? IdShopCategory
        {
            get { return _idShopCategory; }
            set
            {
                if ((_idShopCategory != value))
                {
                    _idShopCategory = value;
                }
            }
        }

        public Guid IdUser
        {
            get { return _idUser; }
            set
            {
                if ((_idUser != value))
                {
                    _idUser = value;
                }
            }
        }

        public string UserLogin
        {
            get { return _userLogin; }
            set
            {
                if ((_userLogin != value))
                {
                    _userLogin = value;
                }
            }
        }
    }
}