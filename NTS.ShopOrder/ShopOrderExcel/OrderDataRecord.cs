using System.Collections.Generic;

namespace ShopOrderExcel
{
    public class OrderDataRecord : DataRecord
    {
        public Dictionary<string, double> ShopsOrder { get; set; }
    }
}