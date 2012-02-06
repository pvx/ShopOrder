using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;

namespace OrdersViewReport.Data
{
    public class ShopDs : BindingList<ShopItem>
    {
        public void Load(SqlConnection connection)
        {
            using (var cn = ReportData.GetContext(connection))
            {
                var dt = (from d in cn.Shops
                          select new ShopItem() { ShopAddress = d.ShopAddress, ShopCode = d.ShopCode, ShopName = d.ShopName}).OrderBy(dr => dr.ShopName);

                foreach (var item in dt)
                {
                    Add(item);
                }
            }
        }
    }
}