using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ShopOrderExcel
{
    public class ExcelOrderImport : ExcelOrderImportBase<OrderDataRecord>
    {
        const string ShopDataStartCol = "C1";

        private readonly List<string[]> _list = new List<string[]>();

        public ExcelOrderImport()
        {
            SheetName = "Лист1";
        }

        protected override void SetColumnsDef()
        {
            Columns = new[]
                          {
                              new[] {"A", "Код товара"}
                          };
        }

        private void    CreateShopList()
        {           
            Cells = Sheet.Range[ShopDataStartCol, Type.Missing];
            while(Cells.Value2 != null)
            {
                _list.Add(new string[] { Cells.Address.Split(new[] { '$' }, 
                    StringSplitOptions.RemoveEmptyEntries)[0], Cells.Value2.ToString()});
                Cells = Cells.Next;
            }
        }

        private string GetColumnName(string name, int row)
        {
            return string.Format("{0}{1}", name, row);
        }

        protected override OrderDataRecord GetOrderRecord(int row)
        {
            Dictionary<string, double> dic = null;

            foreach (string[] cell in _list)
            {
                Cells = Sheet.Range[GetColumnName(cell[0], row), Type.Missing];
                if (Cells.Value2 != null)
                {
                    if(dic == null) 
                        dic = new Dictionary<string, double>();
                    dic.Add(cell[1], Cells.Value2);
                }
            }

            if(dic != null)
            {
                var rec = base.GetOrderRecord(row);
                rec.Code = Sheet.Range[GetColumnIndex(0, row), Type.Missing].Value2.ToString();
                rec.ShopsOrder = dic;
                return rec;
            }
            return null;
        }
        
        protected override void ReadDoc()
        {
            base.ReadDoc();
            CreateShopList();

            bool endrange = true;
            int index = 3;

            var expression = new Regex("([0-9]-[0-9]{3,18})", RegexOptions.None);

            while (endrange)
            {
                Cells = Sheet.Range[GetColumnIndex(0, index), Type.Missing];
                if (Cells.Value2 != null)
                {
                    Match m = expression.Match(Cells.Value2);
                    if (m.Success)
                    {
                        var rec = GetOrderRecord(index);
                        if(rec != null)
                            DataRecords.Add(rec);
                    }
                }
                else
                {
                    endrange = false;
                }
                index++;
            }
        }
    }
}