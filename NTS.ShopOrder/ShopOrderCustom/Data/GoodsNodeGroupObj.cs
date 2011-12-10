using DataBase.DataObject;

namespace ShopOrderCustom.Data
{
    /// <summary>
    /// Класс группы товара
    /// </summary>
    public class GoodsNodeGroupObj : GoodsNodeObjBase
    {
        protected override void AfterNodeCheck(bool check)
        {
            base.AfterNodeCheck(check);

            if ((ObjectList != null) && (ObjectList is GoodsAssorts))
            {
                var groupAssort = ObjectList as GoodsAssorts;
                groupAssort.CheckAll(check);
            }
        }
    }
}