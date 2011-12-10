using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
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
    /// Класс списка товаров
    /// </summary>
    public class GoodsAssorts : BindingList<GoodsNodeBalanceObj>, TreeList.IVirtualTreeListData, ICheckInfo
    {
        private IUnityContainer unityContainer { get; set; }

        [InjectionConstructor]
        public GoodsAssorts(IUnityContainer container)
        {
            unityContainer = container;
        }

        public void Load(int categoryId)
        {
            using (OrderDataContext oc = unityContainer.Resolve<OrderDataContext>())
            {
                var category =
                    oc.DataBaseContext.vGoodsOrderAssort.Where(c => c.parentId == categoryId).Select(
                        c => new GoodsNodeBalanceObj()
                                 {
                                     Active = c.active.GetValueOrDefault(true),
                                     Check = c.check.GetValueOrDefault(false),
                                     Id = c.id,
                                     IdInt = c.id_int,
                                     IdSap = c.id_sap,
                                     Name = c.name,
                                     Note = c.note,
                                     ParentId = c.parentId,
                                     Barcode = c.Barcode,
                                     Code = c.Code,
                                     Measure = c.Measure,
                                     MinOrder = c.MinOrder.GetValueOrDefault(0),
                                     Supplier = c.Supplier,
                                     QuantityInPack = c.QuantityInPack.GetValueOrDefault(0)
                                 }).OrderBy(c => c.Name);

                foreach (GoodsNodeBalanceObj categoryObj in category)
                {
                    Add(categoryObj);
                }
            }
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

        public void CheckAll(bool check)
        {
            foreach (GoodsNodeBalanceObj balanceObj in Items)
            {
                balanceObj.Check = check;
            }
        }

        public void VirtualTreeGetChildNodes(VirtualTreeGetChildNodesInfo info)
        {
            //throw new NotImplementedException();
        }

        public void VirtualTreeGetCellValue(VirtualTreeGetCellValueInfo info)
        {
            var obj = info.Node as GoodsNodeBalanceObj;
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

                case "QuantityInPack":
                    if (obj != null)
                        info.CellData = obj.QuantityInPack;
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
            var itm = from i in Items where i.Code == code select i;
            foreach (GoodsNodeBalanceObj balanceObj in itm)
            {
                balanceObj.Check = true;
            }
        }
    }
}