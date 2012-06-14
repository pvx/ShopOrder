using System;
using System.Collections.Generic;
using System.Linq;
using Common.Enum;
using Common.Interfaces;
using DataBase;
using DataBase.Log;
using DevExpress.XtraTreeList;
using Microsoft.Practices.Unity;

namespace ShopOrderCustom.TreeData
{
    public class ShopDataBase<T>: GoodsNodeDataBase<T>
    {
        protected override void AfterNodeCheck(bool check)
        {
            base.AfterNodeCheck(check);
/*
            if (ObjectList != null)
            {
                ObjectList.CheckAll(check);
            }
            */
        }

        private Guid _idShop;
        private int? _idShopCategory;
        private Guid? _idShopOwner;
        private Guid _idUser;
        private string _shopAddress;
        private string _shopCode;
        private string _shopName;
        private string _userLogin;

        public Object Orders { get; set; }

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

        public override string ToString()
        {
            return string.Format("{0} - [{1}]", ShopCode, ShopName);
        }
    }

    public class ShopData: ShopDataBase<OrderNode>
    {
        protected override void AfterNodeCheck(bool check)
        {
            base.AfterNodeCheck(check);

            if (ObjectList != null)
            {
                ObjectList.CheckAll(check);
            }
        }
    }

    public class PreShopData : ShopDataBase<PreOrderNode>
    {
        protected override void AfterNodeCheck(bool check)
        {
            base.AfterNodeCheck(check);

            if (ObjectList != null)
            {
                ObjectList.CheckAll(check);
            }
        }
    }

    public class OrderHeaderData : GoodsNodeDataBase<object>
    {
        private DateTime _createDate;
        private string _name;
        private DateTime _procesDate;
        private Guid _idOrderHeader;
        private int _idOrderState;
        private Guid _idShop;
        private Guid _idUser;

        private Dictionary<int, string> _orderStateDict = new Dictionary<int, string>();
        private DateTime _commiteDate;


        public override string ToString()
        {
            DateTime dt;
            switch (_idOrderState)
            {
                case 1:
                    dt = _createDate; break;
                case 2:
                    dt = _commiteDate; break;
                case 3:
                    dt = _procesDate; break;
                default:
                    dt = _createDate; break;
            }

            return string.Format("{0:MM.dd HH:mm:ss} [{1}]", dt, StateName);
        }

        public Dictionary<int, string> OrderStateDict
        {
            get { return _orderStateDict; }
        }

        public Guid IdOrderHeader
        {
            get { return _idOrderHeader; }
            set
            {
                if ((_idOrderHeader != value))
                {
                    SendPropertyChanging();
                    _idOrderHeader = value;
                    SendPropertyChanged("IdOrderHeader");
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
                    SendPropertyChanging();
                    _idUser = value;
                    SendPropertyChanged("IdUser");
                }
            }
        }

        public int IdOrderState
        {
            get { return _idOrderState; }
            set
            {
                if ((_idOrderState != value))
                {
                    SendPropertyChanging();
                    _idOrderState = value;
                    SendPropertyChanged("IdOrderState");
                }
            }
        }

        private void SetOrderShateName(int idOrderState)
        {
            if (_orderStateDict.Count > 0)
            {
                _name = _orderStateDict[idOrderState];
                SendPropertyChanged("StateName");
            }
        }

        public DateTime CreateDate
        {
            get { return _createDate; }
            set
            {
                if ((_createDate != value))
                {
                    SendPropertyChanging();
                    _createDate = value;
                    SendPropertyChanged("CreateDate");
                }
            }
        }

        public DateTime CommitDate
        {
            get { return _commiteDate; }
            set
            {
                if ((_commiteDate != value))
                {
                    SendPropertyChanging();
                    _commiteDate = value;
                    SendPropertyChanged("CommitDate");
                }
            }
        }

        public DateTime ProcesDate
        {
            get { return _procesDate; }
            set
            {
                if ((_procesDate != value))
                {
                    SendPropertyChanging();
                    _procesDate = value;
                    SendPropertyChanged("ProcesDate");
                }
            }
        }

        public Guid IdShop
        {
            get { return _idShop; }
            set
            {
                if ((_idShop != value))
                {
                    SendPropertyChanging();
                    _idShop = value;
                    SendPropertyChanged("id_Shop");
                }
            }
        }

        public string StateName
        {
            get { return _orderStateDict[_idOrderState]; }
        }
    }

    public class PreOrderHeaderData: OrderHeaderData
    {}

    public abstract class NodeShopBase<T> : NodeBase<T>, ICheckInfo
    {
        protected NodeShopBase(IUnityContainer container) : base(container)
        {
        }

        public DateTime FilterDate { get; set; }
        public Guid ShopId { get; set; }
        public abstract StateCheck GetCheckState();
        public void CheckedGoodsByCode(string code){}
    }

    public interface INodeOrderHeaderInfo
    {
        bool IsExistInState(int state);
    }

    public class ShopNode : NodeShopBase<ShopData>
    {
        public ShopNode(IUnityContainer container) : base(container)
        {
        }

        public override StateCheck GetCheckState()
        {
            int count = Items.Where(c => c.Check).Count();

            StateCheck state = StateCheck.NoChecked;

            if ((count > 0) && (Items.Count > count))
                state = StateCheck.SomeChecked;
            else
                if (Items.Count == count)
                    state = StateCheck.AllChecked;

            return state;
        }

        public override void CheckAll(bool check)
        {
            foreach (var item in Items)
            {
                item.Check = check;
            }
        }

        public override void Load()
        {
            using (var oc = UnityContainer.Resolve<OrderDataContext>())
            {
                var category = from sh in oc.DataBaseContext.sp_sel_ShopOnDate(FilterDate)
                               select new ShopData()
                               {
                                   Id = sh.id_shop,
                                   IdShopCategory = sh.id_ShopCategory,
                                   IdShopOwner = sh.id_ShopOwner,
                                   ShopAddress = sh.ShopAddress,
                                   ShopCode = sh.ShopCode,
                                   ShopName = sh.ShopName
                               };

                foreach (var categoryObj in category)
                {
                    Add(categoryObj);
                    categoryObj.ObjectList = UnityContainer.Resolve<OrderNode>();
                    categoryObj.ObjectList.FilterDate = FilterDate;
                    categoryObj.ObjectList.ShopId = categoryObj.Id;
                    categoryObj.ObjectList.Load();
                }
            }
        }

        public override void VirtualTreeGetChildNodes(VirtualTreeGetChildNodesInfo info)
        {
            var obj = info.Node as ShopData;
            if (obj != null)
                info.Children = obj.ObjectList;
        }

        public override void VirtualTreeGetCellValue(VirtualTreeGetCellValueInfo info)
        {
            var obj = info.Node as ShopData;
            switch (info.Column.FieldName)
            {
                case "Name":
                    if (obj != null)
                        info.CellData = obj;
                    break;
            }
        }

        public override void VirtualTreeSetCellValue(VirtualTreeSetCellValueInfo info)
        {
            info.Cancel = true;
        }

        public bool SaveSelectedOrder()
        {
            bool ret = false;

            using (var oc = UnityContainer.Resolve<OrderDataContext>())
            {
                foreach (ShopData obj in Items)
                {
                    if (obj.ObjectList != null)
                    {
                        foreach (var ord in (obj.ObjectList))
                        {
                            if ((ord.Check) && (ord.IdOrderState == 2))
                            {
                                oc.DataBaseContext.sp_ins_OrderForProcess(ord.IdOrderHeader);
                                ord.IdOrderState = 3;
                                ord.ProcesDate = DateTime.Now;
                                UnityContainer.Resolve<IDBLogger>().InsertLog(string.Format("Смена статуса заказа с Подтвержден на Обработан."), ord.IdOrderHeader.ToString().ToUpper());
                                ret = true;
                            }
                        }
                    }
                }
            }
            return ret;
        }

        public void ChangeSelectedOrderState()
        {
            using (var oc = UnityContainer.Resolve<OrderDataContext>())
            {
                foreach (var obj in Items)
                {
                    if (obj.ObjectList != null)
                    {
                        foreach (var ord in obj.ObjectList)
                        {
                            if ((ord.Check) && (ord.IdOrderState == 2))
                            {
                                oc.DataBaseContext.sp_upd_OrdersHeaderState(ord.IdOrderHeader, 1);
                                ord.IdOrderState = 1;
                                UnityContainer.Resolve<IDBLogger>().InsertLog(string.Format("Откат статуса заказа с Подтвержден на Введен."), ord.IdOrderHeader.ToString().ToUpper());
                            }
                        }
                    }
                }
            }
        }
    }

    public class PreShopNode : NodeShopBase<PreShopData>
    {
        public PreShopNode(IUnityContainer container)
            : base(container)
        {
        }

        public bool SaveSelectedOrder()
        {
            bool ret = false;

            using (var oc = UnityContainer.Resolve<OrderDataContext>())
            {
                foreach (PreShopData obj in Items)
                {
                    if (obj.ObjectList != null)
                    {
                        foreach (var ord in (obj.ObjectList))
                        {
                            if ((ord.Check) && (ord.IdOrderState == 2))
                            {
                                oc.DataBaseContext.sp_ins_PreOrderForProcess(ord.IdOrderHeader);
                                ord.IdOrderState = 3;
                                ord.ProcesDate = DateTime.Now;
                                UnityContainer.Resolve<IDBLogger>().InsertLog(string.Format("Смена статуса заказа с Подтвержден на Обработан."), ord.IdOrderHeader.ToString().ToUpper());
                                ret = true;
                            }
                        }
                    }
                }
            }
            return ret;
        }

        public void ChangeSelectedOrderState()
        {
            using (var oc = UnityContainer.Resolve<OrderDataContext>())
            {
                foreach (var obj in Items)
                {
                    if (obj.ObjectList != null)
                    {
                        foreach (var ord in obj.ObjectList)
                        {
                            if ((ord.Check) && (ord.IdOrderState == 2))
                            {
                                oc.DataBaseContext.sp_upd_PreOrdersHeaderState(ord.IdOrderHeader, 1);
                                ord.IdOrderState = 1;
                                UnityContainer.Resolve<IDBLogger>().InsertLog(string.Format("Откат статуса пред заказа с Подтвержден на Введен."), ord.IdOrderHeader.ToString().ToUpper());
                            }
                        }
                    }
                }
            }
        }

        public override StateCheck GetCheckState()
        {
            int count = Items.Where(c => c.Check).Count();

            StateCheck state = StateCheck.NoChecked;

            if ((count > 0) && (Items.Count > count))
                state = StateCheck.SomeChecked;
            else
                if (Items.Count == count)
                    state = StateCheck.AllChecked;

            return state;
        }

        public override void CheckAll(bool check)
        {
            foreach (var item in Items)
            {
                item.Check = check;
            }
        }

        public override void Load()
        {
            using (var oc = UnityContainer.Resolve<OrderDataContext>())
            {
                var category = from sh in oc.DataBaseContext.sp_sel_PreShopOnDate(FilterDate)
                               select new PreShopData()
                               {
                                   Id = sh.id_shop,
                                   IdShopCategory = sh.id_ShopCategory,
                                   IdShopOwner = sh.id_ShopOwner,
                                   ShopAddress = sh.ShopAddress,
                                   ShopCode = sh.ShopCode,
                                   ShopName = sh.ShopName
                               };

                foreach (var categoryObj in category)
                {
                    Add(categoryObj);
                    categoryObj.ObjectList = UnityContainer.Resolve<PreOrderNode>();
                    categoryObj.ObjectList.FilterDate = FilterDate;
                    categoryObj.ObjectList.ShopId = categoryObj.Id;
                    categoryObj.ObjectList.Load();
                }
            }
        }

        public override void VirtualTreeGetChildNodes(VirtualTreeGetChildNodesInfo info)
        {
            var obj = info.Node as PreShopData;
            if (obj != null)
                info.Children = obj.ObjectList;
        }

        public override void VirtualTreeGetCellValue(VirtualTreeGetCellValueInfo info)
        {
            var obj = info.Node as PreShopData;
            switch (info.Column.FieldName)
            {
                case "Name":
                    if (obj != null)
                        info.CellData = obj;
                    break;
            }
        }

        public override void VirtualTreeSetCellValue(VirtualTreeSetCellValueInfo info)
        {
            info.Cancel = true;
        }
    }

    public class PreOrderNode : NodeShopBase<PreOrderHeaderData>, INodeOrderHeaderInfo
    {
        public PreOrderNode(IUnityContainer container) : base(container)
        {
        }

        public bool IsExistInState(int state)
        {
            return Items.Any(item => item.IdOrderState == state);
        }

        public override StateCheck GetCheckState()
        {
            int count = Items.Where(c => c.Check).Count();

            StateCheck state = StateCheck.NoChecked;

            if ((count > 0) && (Items.Count > count))
                state = StateCheck.SomeChecked;
            else
                if (Items.Count == count)
                    state = StateCheck.AllChecked;

            return state;
        }

        public override void CheckAll(bool check)
        {
            foreach (var item in Items)
            {
                item.Check = check;
            }
        }

        public override void Load()
        {
            using (var oc = UnityContainer.Resolve<OrderDataContext>())
            {
                var category = from or in oc.DataBaseContext.sp_sel_PreOrderHeaderOnDate(ShopId, FilterDate)
                               select new PreOrderHeaderData()
                          {
                                         CreateDate = or.CreateDate,
                                         IdOrderHeader = or.id_PreOrderHeader,
                                         IdOrderState = or.id_PreOrderState.GetValueOrDefault(1),
                                         IdShop = or.id_Shop,
                                         IdUser = or.id_User,
                                         Name = or.Note,
                                         ProcesDate = or.ProcesDate.GetValueOrDefault(),
                                         CommitDate = or.CommitDate.GetValueOrDefault()
                                     };

                var sdic = (from sd in oc.DataBaseContext.OrderState
                            select sd);

                foreach (var categoryObj in category)
                {
                    foreach (var orderState in sdic)
                    {
                        categoryObj.OrderStateDict.Add(orderState.id, orderState.Name);
                    }
                    Add(categoryObj);
                }
            }
        }

        public override void VirtualTreeGetChildNodes(VirtualTreeGetChildNodesInfo info)
        {

        }

        public override void VirtualTreeGetCellValue(VirtualTreeGetCellValueInfo info)
        {
            var obj = info.Node as PreOrderHeaderData;
            switch (info.Column.FieldName)
            {
                case "Name":
                    if (obj != null)
                        info.CellData = obj;
                    break;
            }
        }

        public override void VirtualTreeSetCellValue(VirtualTreeSetCellValueInfo info)
        {
            info.Cancel = true;
        }
    }

    public class OrderNode : NodeShopBase<OrderHeaderData>, INodeOrderHeaderInfo
    {
        public OrderNode(IUnityContainer container)
            : base(container)
        {
        }

        public bool IsExistInState(int state)
        {
            return Items.Any(item => item.IdOrderState == state);
        }

        public override StateCheck GetCheckState()
        {
            int count = Items.Where(c => c.Check).Count();

            StateCheck state = StateCheck.NoChecked;

            if ((count > 0) && (Items.Count > count))
                state = StateCheck.SomeChecked;
            else
                if (Items.Count == count)
                    state = StateCheck.AllChecked;

            return state;
        }

        public override void CheckAll(bool check)
        {
            foreach (var item in Items)
            {
                item.Check = check;
            }
        }

        public override void Load()
        {
            using (var oc = UnityContainer.Resolve<OrderDataContext>())
            {
                var category = from or in oc.DataBaseContext.sp_sel_OrderHeaderOnDate(ShopId, FilterDate)
                               select new OrderHeaderData()
                               {
                                   CreateDate = or.CreateDate,
                                   IdOrderHeader = or.id_OrderHeader,
                                   IdOrderState = or.id_OrderState.GetValueOrDefault(1),
                                   IdShop = or.id_Shop,
                                   IdUser = or.id_User,
                                   Name = or.Note,
                                   ProcesDate = or.ProcesDate.GetValueOrDefault(),
                                   CommitDate = or.CommitDate.GetValueOrDefault()
                               };

                //TODO: replase OrderState -> PreOrderState
                var sdic = (from sd in oc.DataBaseContext.OrderState
                            select sd);

                foreach (var categoryObj in category)
                {
                    foreach (var orderState in sdic)
                    {
                        categoryObj.OrderStateDict.Add(orderState.id, orderState.Name);
                    }
                    Add(categoryObj);
                }
            }
        }

        public override void VirtualTreeGetChildNodes(VirtualTreeGetChildNodesInfo info)
        {

        }

        public override void VirtualTreeGetCellValue(VirtualTreeGetCellValueInfo info)
        {
            var obj = info.Node as OrderHeaderData;
            switch (info.Column.FieldName)
            {
                case "Name":
                    if (obj != null)
                        info.CellData = obj;
                    break;
            }
        }

        public override void VirtualTreeSetCellValue(VirtualTreeSetCellValueInfo info)
        {
            info.Cancel = true;
        }
    }
}