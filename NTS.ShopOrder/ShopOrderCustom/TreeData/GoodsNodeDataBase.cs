using System;
using System.ComponentModel;
using System.Data.Common;
using System.Linq;
using Common.Enum;
using Common.Interfaces;
using DataBase;
using DataBase.DataObject;
using DevExpress.XtraTreeList;
using Microsoft.Practices.Unity;
using ShopOrderCustom.Data;

namespace ShopOrderCustom.TreeData
{
    public class GoodsNodeDataBase<T> : INotifyPropertyChanging, INotifyPropertyChanged
    {
        private static readonly PropertyChangingEventArgs EmptyChangingEventArgs =
            new PropertyChangingEventArgs(String.Empty);

        private Guid _id;
        private int _idInt;
        private string _name;
        private bool _active;
        private string _note;
        private string _idSap;
        private int? _parentId;
        private bool _check;

        public T ObjectList { get; set; }

        protected virtual void AfterNodeCheck(bool check)
        {

        }

        public Guid Id
        {
            get { return _id; }
            set
            {
                if ((_id != value))
                {
                    //this.OnidChanging(value);
                    SendPropertyChanging();
                    _id = value;
                    SendPropertyChanged("Id");
                    //this.OnidChanged();
                }
            }
        }

        public int IdInt
        {
            get { return _idInt; }
            set
            {
                if ((_idInt != value))
                {
                    //this.Onid_intChanging(value);
                    SendPropertyChanging();
                    _idInt = value;
                    SendPropertyChanged("IdInt");
                    //this.Onid_intChanged();
                }
            }
        }

        public override string ToString()
        {
            return _name;
        }

        public string Name
        {
            get { return _name; }
            set
            {
                if ((_name != value))
                {
                    //this.OnnameChanging(value);
                    SendPropertyChanging();
                    _name = value;
                    SendPropertyChanged("Name");
                    //this.OnnameChanged();
                }
            }
        }

        public bool Active
        {
            get { return _active; }
            set
            {
                if ((_active != value))
                {
                    SendPropertyChanging();
                    _active = value;
                    SendPropertyChanged("Active");
                }
            }
        }

        public bool Check
        {
            get { return _check; }
            set
            {
                if ((_check != value))
                {
                    SendPropertyChanging();
                    _check = value;
                    SendPropertyChanged("Check");
                    AfterNodeCheck(_check);
                }
            }
        }

        public string Note
        {
            get { return _note; }
            set
            {
                if ((_note != value))
                {
                    //this.OnnoteChanging(value);
                    SendPropertyChanging();
                    _note = value;
                    SendPropertyChanged("Note");
                    //this.OnnoteChanged();
                }
            }
        }

        public string IdSap
        {
            get { return _idSap; }
            set
            {
                if ((_idSap != value))
                {
                    //this.Onid_sapChanging(value);
                    SendPropertyChanging();
                    _idSap = value;
                    SendPropertyChanged("IdSap");
                    //this.Onid_sapChanged();
                }
            }
        }

        public int? ParentId
        {
            get { return _parentId; }
            set
            {
                if ((_parentId != value))
                {
                    //this.Ongoods_gen0_idChanging(value);
                    SendPropertyChanging();
                    _parentId = value;
                    SendPropertyChanged("ParentId");
                    //this.Ongoods_gen0_idChanged();
                }
            }
        }

        public event PropertyChangingEventHandler PropertyChanging;

        public event PropertyChangedEventHandler PropertyChanged;

        public event GoodsNodeCheck NodeCheck;

        protected virtual void SendChangeReqQuantity()
        {
            if ((NodeCheck != null))
            {
                //NodeCheck(this, new EventGoodsNodeCheck() { GoodsNode = this });
            }
        }
        protected virtual void SendPropertyChanging()
        {
            if ((PropertyChanging != null))
            {
                PropertyChanging(this, EmptyChangingEventArgs);
            }
        }

        protected virtual void SendPropertyChanged(String propertyName)
        {
            if ((PropertyChanged != null))
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

    
    public class GoodsDataCategory : GoodsNodeDataBase<GoodsGroupNode>
    {
        protected override void AfterNodeCheck(bool check)
        {
            base.AfterNodeCheck(check);

            if ((ObjectList != null) && (ObjectList is GoodsGroupNode))
            {
                ObjectList.CheckAll(check);
            }
        }
    }

    public class GoodsDataGroup : GoodsNodeDataBase<GoodsNode>
    {
        protected override void AfterNodeCheck(bool check)
        {
            base.AfterNodeCheck(check);

            if ((ObjectList != null) && (ObjectList is GoodsNode))
            {
                ObjectList.CheckAll(check);
            }
        }
    }

    public class GoodsDataDistrib : GoodsNodeDataBase<object>
    {
        private string _barcode;
        private string _code;
        private string _measure;
        private decimal _price;
        private string _supplier;

        private bool _loaded;
        public bool Loaded
        {
            get { return _loaded; }
            set { _loaded = value; }
        }

        protected override void AfterNodeCheck(bool check)
        {
            base.AfterNodeCheck(check);
            if (Loaded)
            {
                if (!check)
                    Norm = 0;
            }
        }

        public decimal Price
        {
            get { return _price; }
            set
            {
                if ((_price != value))
                {
                    SendPropertyChanging();
                    _price = value;
                    SendPropertyChanged("Price");
                }
            }
        }

        public string Measure
        {
            get { return _measure; }
            set
            {
                if ((_measure != value))
                {
                    SendPropertyChanging();
                    _measure = value;
                    SendPropertyChanged("Measure");
                }
            }
        }

        public string Supplier
        {
            get { return _supplier; }
            set
            {
                if ((_supplier != value))
                {
                    SendPropertyChanging();
                    _supplier = value;
                    SendPropertyChanged("Supplier");
                }
            }
        }

        public string Code
        {
            get { return _code; }
            set
            {
                if ((_code != value))
                {
                    SendPropertyChanging();
                    _code = value;
                    SendPropertyChanged("Code");
                }
            }
        }

        public string Barcode
        {
            get { return _barcode; }
            set
            {
                if ((_barcode != value))
                {
                    SendPropertyChanging();
                    _barcode = value;
                    SendPropertyChanged("Barcode");
                }
            }
        }

        private double _norm;
        public double Norm
        {
            get { return _norm; }
            set
            {
                SendPropertyChanging();
                _norm = value;
                SendPropertyChanged("Norm");
            }
        }
    }



    public abstract class NodeBase<T> : BindingList<T>, TreeList.IVirtualTreeListData
    {
        protected IUnityContainer UnityContainer { get; set; }

        public NodeBase(IUnityContainer container)
        {
            UnityContainer = container;
        }

        public virtual void Load()
        {  
        }

        public virtual void VirtualTreeGetChildNodes(VirtualTreeGetChildNodesInfo info)
        {
        }

        public virtual void VirtualTreeGetCellValue(VirtualTreeGetCellValueInfo info)
        {
        }

        public virtual void Save()
        {        
        }

        public virtual void VirtualTreeSetCellValue(VirtualTreeSetCellValueInfo info)
        {
            info.Cancel = true;
        }
    }

    public abstract class NodeDistribBase<T> : NodeBase<T>, ICheckInfo
    {
        protected NodeDistribBase(IUnityContainer container) : base(container)
        {
        }

        public int ShopCategoryId { get; set; }
        public abstract StateCheck GetCheckState();
        public abstract void CheckedGoodsByCode(string code);
    }

    public class GoodsCategoryNode : NodeDistribBase<GoodsDataCategory>
    {
        [InjectionConstructor]
        public GoodsCategoryNode(IUnityContainer container) : base(container)
        {
        }

        public override void Load()
        {
            using (var oc = UnityContainer.Resolve<OrderDataContext>())
            {
                var category = from c in oc.DataBaseContext.vCategory
                               select new GoodsDataCategory()
                               {
                                   Active = c.active,
                                   Check = c.check.GetValueOrDefault(false),
                                   Id = c.id,
                                   IdInt = c.id_int,
                                   IdSap = c.id_sap,
                                   Name = c.name,
                                   Note = c.note,
                                   ParentId = c.parentId
                               };

                foreach (var categoryObj in category)
                {
                    Add(categoryObj);
                    categoryObj.ObjectList = UnityContainer.Resolve<GoodsGroupNode>();
                    categoryObj.ObjectList.IdInt = categoryObj.IdInt;
                    categoryObj.ObjectList.ShopCategoryId = ShopCategoryId;
                    categoryObj.ObjectList.Load();
                }
            }
        }

        public override void VirtualTreeGetChildNodes(VirtualTreeGetChildNodesInfo info)
        {
            var obj = info.Node as GoodsDataCategory;
            if (obj != null)
                info.Children = obj.ObjectList;
        }

        public override void VirtualTreeGetCellValue(VirtualTreeGetCellValueInfo info)
        {
            var obj = info.Node as GoodsDataCategory;
            switch (info.Column.FieldName)
            {
                case "Name":
                    if (obj != null)
                        info.CellData = obj;
                    break;
                case "Check":
                    if (obj != null)
                        info.CellData = obj.Check;
                    break;

            }
        }

        public override void VirtualTreeSetCellValue(VirtualTreeSetCellValueInfo info)
        {
            info.Cancel = true;
        }

        public override StateCheck GetCheckState()
        {
            StateCheck state = StateCheck.NoChecked;

            foreach (var groupObj in Items)
            {
                if (groupObj.ObjectList is ICheckInfo)
                {
                    var ol = groupObj.ObjectList as ICheckInfo;
                    state = ol.GetCheckState();
                }
            }

            return state;
        }

        public override void CheckedGoodsByCode(string code)
        {
            foreach (var groupObj in Items)
            {
                groupObj.ObjectList.CheckedGoodsByCode(code);
            }
        }

        public override void Save()
        {
            using (var oc = UnityContainer.Resolve<OrderDataContext>())
            {
                DbConnection con = oc.DataBaseContext.Connection;
                try
                {
                    con.Open();
                    oc.DataBaseContext.Transaction = con.BeginTransaction();
                    oc.DataBaseContext.sp_del_GoodsNorm(ShopCategoryId);
                    foreach (var categoryObj in Items)
                    {
                        foreach (var groupObj in categoryObj.ObjectList)
                        {
                            foreach (var balanceObj in groupObj.ObjectList)
                            {
                                if (balanceObj.Check)
                                {
                                    oc.DataBaseContext.sp_ins_GoodsNorm(ShopCategoryId, balanceObj.Norm, balanceObj.Code, "");
                                }
                            }

                        }

                    }
                    oc.DataBaseContext.Transaction.Commit();
                }
                catch (Exception)
                {
                    if (oc.DataBaseContext.Transaction != null)
                        oc.DataBaseContext.Transaction.Rollback();
                    throw;
                }
                finally
                {
                    con.Close();
                }
            }
        }
    }

    public class GoodsGroupNode : NodeDistribBase<GoodsDataGroup>
    {
        [InjectionConstructor]
        public GoodsGroupNode(IUnityContainer container)
            : base(container)
        {
        }

        public int IdInt { get; set; }

        public override void Load()
        {
            using (var oc = UnityContainer.Resolve<OrderDataContext>())
            {
                var category = from c in oc.DataBaseContext.vGroup
                               where c.parentId == IdInt
                               select new GoodsDataGroup()
                               {
                                   Active = c.active,
                                   Check = c.check.GetValueOrDefault(false),
                                   Id = c.id,
                                   IdInt = c.id_int,
                                   IdSap = c.id_sap,
                                   Name = c.name,
                                   Note = c.note,
                                   ParentId = c.parentId
                               };

                foreach (var categoryObj in category)
                {
                    Add(categoryObj);
                    categoryObj.ObjectList = UnityContainer.Resolve<GoodsNode>();
                    categoryObj.ObjectList.IdInt = categoryObj.IdInt;
                    categoryObj.ObjectList.ShopCategoryId = ShopCategoryId;
                    categoryObj.ObjectList.Load();

                }
            }
        }

        public override void VirtualTreeGetChildNodes(VirtualTreeGetChildNodesInfo info)
        {
        }

        public override void VirtualTreeGetCellValue(VirtualTreeGetCellValueInfo info)
        {
            var obj = info.Node as GoodsDataGroup;
            switch (info.Column.FieldName)
            {
                case "Name":
                    if (obj != null)
                        info.CellData = obj;
                    break;
                case "Check":
                    if (obj != null)
                        info.CellData = obj.Check;
                    break;

            }
        }

        public override void VirtualTreeSetCellValue(VirtualTreeSetCellValueInfo info)
        {
            info.Cancel = true;
        }

        public override StateCheck GetCheckState()
        {
            StateCheck state = StateCheck.NoChecked;

            foreach (var groupObj in Items)
            {
                if (groupObj.ObjectList is ICheckInfo)
                {
                    var ol = groupObj.ObjectList as ICheckInfo;
                    state = ol.GetCheckState();
                }
            }

            return state;
        }

        public override void CheckedGoodsByCode(string code)
        {
            foreach (var groupObj in Items)
            {
                groupObj.ObjectList.CheckedGoodsByCode(code);
            }
        }

        public void CheckAll(bool check)
        {
            foreach (var item in Items)
            {
                item.Check = check;
            }
        }
    }

    public class GoodsNode : NodeDistribBase<GoodsDataDistrib>
    {
        [InjectionConstructor]
        public GoodsNode(IUnityContainer container)
            : base(container)
        {
        }

        public int IdInt { get; set; }

        public override void Load()
        {
            using (var oc = UnityContainer.Resolve<OrderDataContext>())
            {
                var category = from c in oc.DataBaseContext.sp_sel_GoodsDistribution(ShopCategoryId, IdInt)

                               select new GoodsDataDistrib()
                               {
                                   Active = c.active.GetValueOrDefault(true),
                                   Check = c.check.GetValueOrDefault(false),
                                   Price = c.Price.GetValueOrDefault(0),
                                   IdInt = c.id_int,
                                   IdSap = c.id_sap,
                                   Name = c.name,
                                   Note = c.note,
                                   ParentId = c.parentId,
                                   Barcode = c.Barcode,
                                   Code = c.Code,
                                   Measure = c.Measure,
                                   Supplier = c.Supplier,
                                   Norm = c.Norm,
                                   Loaded = true
                               };

                foreach (var categoryObj in category)
                {
                    Add(categoryObj);
                }
            }
        }

        public override void VirtualTreeGetChildNodes(VirtualTreeGetChildNodesInfo info)
        {
        }

        public override void VirtualTreeGetCellValue(VirtualTreeGetCellValueInfo info)
        {
            var obj = info.Node as GoodsDataDistrib;
            switch (info.Column.FieldName)
            {
                case "Name":
                    if (obj != null)
                        info.CellData = obj;
                    break;
                case "Barcode":
                    if (obj != null)
                        info.CellData = obj.Barcode;
                    break;

                case "Measure":
                    if (obj != null)
                        info.CellData = obj.Measure;
                    break;

                case "Check":
                    if (obj != null)
                        info.CellData = obj.Check;

                    break;
            }
        }

        public override void VirtualTreeSetCellValue(VirtualTreeSetCellValueInfo info)
        {
            info.Cancel = true;
        }

        private StateCheck GetState()
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

        public override StateCheck GetCheckState()
        {
            return GetState();
        }

        public void CheckAll(bool check)
        {
            foreach (var item in Items)
            {
                item.Check = check;
            }
        }

        public override void CheckedGoodsByCode(string code)
        {
            var itm = from i in Items where i.Code == code select i;
            foreach (var balanceObj in itm)
            {
                balanceObj.Check = true;
            }
        }
    }

    
}