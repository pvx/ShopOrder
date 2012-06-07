using System;
using System.ComponentModel;
using System.Linq;
using Common.Enum;
using Common.Interfaces;
using DataBase;
using DataBase.DataObject;
using DevExpress.XtraTreeList;
using Microsoft.Practices.Unity;
using ShopOrderCustom.Data;

namespace ShopOrderCustom
{
    /// <summary>
    /// Класс списка групп товаров
    /// </summary>
    public class GroupAssort : BindingList<GoodsNodeGroupObj>, TreeList.IVirtualTreeListData, ICheckInfo
    {
        protected IUnityContainer unityContainer { get; set; }

        [InjectionConstructor]
        public GroupAssort(IUnityContainer container)
        {
            unityContainer = container;
        }

        public virtual void Load(int categoryId)
        {
            using (var oc = unityContainer.Resolve<OrderDataContext>())
            {
                var category = from c in oc.DataBaseContext.vGroup
                               where c.parentId == categoryId
                               select new GoodsNodeGroupObj()
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

                foreach (GoodsNodeGroupObj categoryObj in category)
                {
                    Add(categoryObj);
                    categoryObj.ObjectList = unityContainer.Resolve<GoodsAssorts>();
                    (categoryObj.ObjectList as GoodsAssorts).Load(categoryObj.IdInt);

                }
            }
        }

        private StateCheck GetState()
        {
            StateCheck state = StateCheck.NoChecked;

            foreach (GoodsNodeGroupObj groupObj in Items)
            {
                if(groupObj.ObjectList is ICheckInfo)
                {
                    var ol = groupObj.ObjectList as ICheckInfo;
                    state = ol.GetCheckState();
                }
            }

            return state;
        }

        public void CheckAll(bool check)
        {
            foreach (GoodsNodeGroupObj groupObj in Items)
            {
                groupObj.Check = check;
            }
        }

        public void VirtualTreeGetChildNodes(VirtualTreeGetChildNodesInfo info)
        {
            /*
            var obj = info.Node as GoodsNodeGroupObj;
            if (obj != null)
                info.Children = (GoodsAssorts)obj.ObjectList;
            */ 
        }

        public void VirtualTreeGetCellValue(VirtualTreeGetCellValueInfo info)
        {
            var obj = info.Node as GoodsNodeGroupObj;
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

        public void VirtualTreeSetCellValue(VirtualTreeSetCellValueInfo info)
        {
            info.Cancel = true;
        }

        public StateCheck GetCheckState()
        {
            return GetState();
        }

        public void CheckedGoodsByCode(string code)
        {
            foreach (var groupObj in Items)
            {
                if (groupObj.ObjectList is GoodsAssorts)
                    ((GoodsAssorts)groupObj.ObjectList).CheckedGoodsByCode(code);   
            }
        }
    }
}