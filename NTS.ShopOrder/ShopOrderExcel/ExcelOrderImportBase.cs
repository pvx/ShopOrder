using System;
using Microsoft.Office.Interop.Excel;

namespace ShopOrderExcel
{
    public class ExcelOrderImportBase<T> : ExcelImport where T: new() 
    {
        private string[][] _columns;

        protected virtual void SetColumnsDef()
        {
            
        }

        public string SheetName { get; set; }

        public string[][] Columns
        {
            get { return _columns; }
            set { _columns = value; }
        }

        protected void CheckColumns()
        {
            SetColumnsDef();

            foreach (string[] column in _columns)
            {
                string colname = string.Format("{0}{1}", column[0], 1);

                Cells = Sheet.Range[colname, Type.Missing];
                string str = Convert.ToString(Cells.Value2);
                if (str != column[1])
                    throw new FormatException(string.Format("Название колонки [{0}] не найдено по индексу колонки [{1}]", column[1], column[0]));
            }
        }

        protected void FormatCheck()
        {
            Excelsheets = Workbook.Worksheets;
            Sheet = (Worksheet)Excelsheets.Item[1];

            if (Sheet.Name != SheetName)
                throw new FormatException(string.Format(@"Неправильный формат файла. Лист {0} не найден.", SheetName));

            CheckColumns();
        }

        public string GetColumnIndex(int index, int row)
        {
            return string.Format("{0}{1}", _columns[index][0], row);
        }

        protected virtual T GetOrderRecord(int row)
        {
            return new T();
        }

        protected override void ReadDoc()
        {
            FormatCheck();
            /*
            bool endrange = true;
            int index = 2;

            while (endrange)
            {
                Cells = Sheet.Range[GetColumnIndex(0, index), Type.Missing];
                if (Cells.Value2 != null)
                {
                    DataRecords.Add(GetNestleOrderRecord(index));
                }
                else
                {
                    endrange = false;
                }
                index++;
            }
             * */
        }
    }
}