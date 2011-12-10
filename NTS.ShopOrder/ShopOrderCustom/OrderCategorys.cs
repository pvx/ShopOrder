using System;
using System.ComponentModel;
using System.Data.Common;
using System.Linq;
using Common;
using DataBase;
using DataBase.DataObject;
using DevExpress.XtraTreeList;
using Microsoft.Practices.Unity;
using ShopOrderCustom.Data;

namespace ShopOrderCustom
{
    /// <summary>
    /// Класс списка категорий товаров
    /// </summary>
    public class OrderCategorys : BindingList<GoodsNodeCategoryObj>, TreeList.IVirtualTreeListData
    {
        private IUnityContainer unityContainer { get; set; }

        [InjectionConstructor]
        public OrderCategorys(IUnityContainer container)
        {
            unityContainer = container;
            Load();
        }

        public void CheckedGoodsByCode(string code)
        {
            foreach (var categoryObj in Items)
            {
                if(categoryObj.ObjectList is GroupAssort)
                    ((GroupAssort)categoryObj.ObjectList).CheckedGoodsByCode(code);
            }    
        }

        private void Load()
        {
            using (var oc = unityContainer.Resolve<OrderDataContext>())
            {
                var category = from c in oc.DataBaseContext.vCategory
                               select new GoodsNodeCategoryObj() 
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
                
                foreach (GoodsNodeCategoryObj categoryObj in category)
                {
                    Add(categoryObj);
                    categoryObj.ObjectList = unityContainer.Resolve<GroupAssort>();
                    (categoryObj.ObjectList as GroupAssort).Load(categoryObj.IdInt);
                }
            }
        }

        public void VirtualTreeGetChildNodes(VirtualTreeGetChildNodesInfo info)
        {
            var obj = info.Node as GoodsNodeCategoryObj;
            if (obj != null) 
                info.Children = (GroupAssort)obj.ObjectList;
        }

        public void VirtualTreeGetCellValue(VirtualTreeGetCellValueInfo info)
        {
            var obj = info.Node as GoodsNodeCategoryObj;
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

        /// <exception cref="Exception"><c>Exception</c>.</exception>
        public void Save()
        {
            using (var oc = unityContainer.Resolve<OrderDataContext>())
            {
                DbConnection con = oc.DataBaseContext.Connection;
                try
                {
                    con.Open();
                    oc.DataBaseContext.Transaction = con.BeginTransaction();
                    oc.DataBaseContext.sp_del_AssortForOrder();
                    foreach (var categoryObj in Items)
                    {
                        if(categoryObj.ObjectList is GroupAssort)
                        {
                            var g = ((GroupAssort) categoryObj.ObjectList);
                            foreach (GoodsNodeGroupObj groupObj in g)
                            {
                                if (groupObj.ObjectList is GoodsAssorts)
                                {
                                    var ga = ((GoodsAssorts) groupObj.ObjectList);
                                    foreach (GoodsNodeBalanceObj balanceObj in ga)
                                    {
                                        if(balanceObj.Check)
                                        {
                                            oc.DataBaseContext.sp_ins_AssortForOrder(balanceObj.Code);
                                        }
                                    }
                                }
                            }
                        }
                    }
                    oc.DataBaseContext.sp_AfterBalanceLoad_UpdateGB_IsForOrder();
                    oc.DataBaseContext.Transaction.Commit();
                }
                catch(Exception)
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

        public void VirtualTreeSetCellValue(VirtualTreeSetCellValueInfo info)
        {
            info.Cancel = true;
        }
    }
}