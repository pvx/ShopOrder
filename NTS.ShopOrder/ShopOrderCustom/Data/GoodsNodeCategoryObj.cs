using DataBase.DataObject;

namespace ShopOrderCustom.Data
{
    /// <summary>
    /// Класс категории товара
    /// </summary>
    public class GoodsNodeCategoryObj : GoodsNodeObjBase
    {
        protected override void AfterNodeCheck(bool check)
        {
            base.AfterNodeCheck(check);

            if((ObjectList != null) && (ObjectList is GroupAssort))
            {
                var groupAssort = ObjectList as GroupAssort;
                groupAssort.CheckAll(check);
            }
        }
    }
}