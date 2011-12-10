using System;
using System.Text.RegularExpressions;
using Microsoft.Office.Interop.Excel;

namespace ShopOrderExcel
{
    /// <summary>
    /// Класс импорта данных из Excel по обязательному ассортименту
    /// </summary>
    public class ReqAssortImport : ExcelImport
    {
        /// <exception cref="FormatException">Не правильный формат файла. Лист AssortForOrder не найден.</exception>
        protected override void ReadDoc()
        {
            Excelsheets = Workbook.Worksheets;
            Sheet = (Worksheet)Excelsheets.Item[1];

            if (Sheet.Name != "ReqAssort")
                throw new FormatException(@"Не правильный формат файла. Лист ReqAssort не найден.");
            Cells = Sheet.Range["A1", Type.Missing];
            string str = Convert.ToString(Cells.Value2);
            if (str != "Код")
                throw new FormatException(@"Не правильный формат файла. Поле Код не найдено.");

            bool endrange = true;
            int index = 2;
            var expression = new Regex("([0-9]-[0-9]{3,18})", RegexOptions.None);
            while (endrange)
            {
                string eindex = string.Format("A{0}", index);
                Cells = Sheet.Range[eindex, Type.Missing];
                if (Cells.Value2 != null)
                {
                    Match m = expression.Match(Cells.Value2);
                    if (m.Success)
                        DataRecords.Add(new DataRecord() { Code = Convert.ToString(Cells.Value2) });
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