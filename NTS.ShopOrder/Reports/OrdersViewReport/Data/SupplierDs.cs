using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;

namespace OrdersViewReport.Data
{
    public class SupplierDs : BindingList<SupplierItem>
    {
        public void Load(SqlConnection connection)
        {
            using (var cn = ReportData.GetContext(connection))
            {
                var dt = (from d in cn.vSuppliers
                          select new SupplierItem() { SupplierName = d.Supplier}).OrderBy(dr => dr.SupplierName);

                foreach (var item in dt)
                {
                    Add(item);
                }
            }
        }
    }
}