using System;
using System.ComponentModel;
using System.Linq;
using DataBase;
using DataBase.DataObject;
using Microsoft.Practices.Unity;
using DevExpress.XtraTreeList;

namespace ShopOrderCustom
{
    public class ReturnShops : BindingList<ReturnShopObj>, TreeList.IVirtualTreeListData
    {
        private IUnityContainer unityContainer { get; set; }

        [InjectionConstructor]
        public ReturnShops(IUnityContainer container)
        {
            unityContainer = container;
        }

        public void Load(DateTime filterDate)
        {
            using (var oc = unityContainer.Resolve<OrderDataContext>())
            {
                var orderShop = from sh in oc.DataBaseContext.sp_sel_ReturnShopsOnDateSt(filterDate)
                                select new ReturnShopObj()
                                {
                                    ShopId = sh.id_Shop,
                                    ShopCode = sh.ShopCode,
                                    ShopName = sh.ShopName
                                };

                foreach (var orderShopObj in orderShop)
                {
                    Add(orderShopObj);
                    var rts = unityContainer.Resolve<Returns>();
                    rts.ReturnItemsPool = orderShopObj.ReturnItemsPool;
                    rts.LoadSt(orderShopObj.ShopId, filterDate);               
                    orderShopObj.Returns = rts;
                }               
            }
        }

        void TreeList.IVirtualTreeListData.VirtualTreeGetChildNodes(VirtualTreeGetChildNodesInfo info)
        {
            var obj = info.Node as ReturnShopObj;
            if (obj != null) info.Children = obj.Returns;
        }

        void TreeList.IVirtualTreeListData.VirtualTreeGetCellValue(VirtualTreeGetCellValueInfo info)
        {
            var obj = info.Node as ReturnShopObj;
            switch (info.Column.FieldName)
            {
                case "Name": if (obj != null)
                        info.CellData = obj;
                    break;
            }
        }

        void TreeList.IVirtualTreeListData.VirtualTreeSetCellValue(VirtualTreeSetCellValueInfo info)
        {
            info.Cancel = true;
            /*
            Project obj = info.Node as Project;
            switch (info.Column.Caption)
            {
                case "Name":
                    obj.Name = (string)info.NewCellData;
                    break;
            }
            */
        }
    }
}