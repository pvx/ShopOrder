using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;

namespace OrdersViewReport.Data
{
    public class CatDs: BindingList<Category>
    {
        public void Load(SqlConnection connection)
        {
            using (var cn = ReportData.GetContext(connection))
            {
                var dt = from d in cn.vGroups
                         select new Category(){CategoryName = d.name, CategoryID = d.id_int};

                foreach (var item in dt)
                {
                    Add(item);
                }
            }
        }
    }
}