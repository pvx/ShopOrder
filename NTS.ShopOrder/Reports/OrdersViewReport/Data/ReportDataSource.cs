using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Dynamic;
using System.Text;
using ReportCore;

namespace OrdersViewReport.Data
{
    public class ReportDataSource : BindingList<vReportOrdersByShop>, IOrderReportDataSource
    {
        private DateTime _dateBegin;

        private DateTime _dateEnd;

        private string _shopCode;

        private string _group;

        private string _supplier;

        public void Load(SqlConnection connection)
        {
            Clear();
            if (DateBegin == DateEnd) 
                DateEnd = DateEnd.AddDays(1);

            var param = new List<KeyValuePair<string, object>>();

            param.Add(new KeyValuePair<string, object>("(GoodsDate >= @0", DateBegin));
            param.Add(new KeyValuePair<string, object>("and GoodsDate <= @1)", DateEnd));

            if(!string.IsNullOrEmpty(ShopCode))
                param.Add(new KeyValuePair<string, object>(string.Format("and (ShopCode == @{0})", param.Count), ShopCode));

            if (!string.IsNullOrEmpty(Group))
                param.Add(new KeyValuePair<string, object>(string.Format("and (Group == @{0})", param.Count), Group));

            if (!string.IsNullOrEmpty(Supplier))
                param.Add(new KeyValuePair<string, object>(string.Format("and (Supplier == @{0})", param.Count), Supplier));

            if (!string.IsNullOrEmpty(Barcode))
                param.Add(new KeyValuePair<string, object>(string.Format("and (Barcode == @{0})", param.Count), Barcode));
            var arr = param.Select(p => p.Value).ToArray();
            var str = string.Join(" ", param.Select(p => p.Key).ToArray());

            using(var cn = ReportData.GetContext(connection))
            {
                var dt = cn.vReportOrdersByShops.Where(str, arr);

                foreach(var item in dt)
                {
                    Add(item);
                }
            }
        }

        public DateTime DateBegin
        {
            get { return _dateBegin.Date; }
            set { _dateBegin = value; }
        }

        public DateTime DateEnd
        {
            get { return _dateEnd.Date; }
            set { _dateEnd = value; }
        }

        public string ShopCode
        {
            get { return _shopCode; }
            set { _shopCode = value; }
        }

        public string Group
        {
            get { return _group; }
            set { _group = value; }
        }

        public string Supplier
        {
            get { return _supplier; }
            set { _supplier = value; }
        }

        public string Barcode { get; set; }
    }
}