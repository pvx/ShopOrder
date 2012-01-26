using System;
using System.Text.RegularExpressions;
using Microsoft.Office.Interop.Excel;

namespace ShopOrderExcel
{
    /// <summary>
    /// Класс импорта данных из Excel заказов Nestle
    /// </summary>
    public class NestleOrderImport : ExcelImport
    {
        readonly string[][] _columns = new[]
                                  {
            new[] { "J", "код ТТ" },
            new[] { "R", "номер документа" },
            new[] { "S", "дата документа" },
            new[] { "AA", "код товара" },
            new[] { "AG", "Количество (шт.)" }
        };


        /// <exception cref="FormatException">Не правильный формат файла. Поле Код не найдено.</exception>
        private void CheckColumns()
        {
            foreach (string[] column in _columns)
            {
                string colname = string.Format("{0}{1}",column[0], 1);

                Cells = Sheet.Range[colname, Type.Missing];
                string str = Convert.ToString(Cells.Value2);
                if (str != column[1])
                    throw new FormatException(string.Format("Название колонки [{0}] не найдено по индексу колонки [{1}]", column[1], column[0]));
            }
        }

        /// <exception cref="FormatException">Не правильный формат файла. Поле Код не найдено.</exception>
        private void NestleFormatCheck()
        {
            Excelsheets = Workbook.Worksheets;
            Sheet = (Worksheet)Excelsheets.Item[1];

            if (Sheet.Name != "Лист1")
                throw new FormatException(@"Неправильный формат файла. Лист1 не найден.");

            CheckColumns();
        }

        private string GetColumnIndex(int index, int row)
        {
            return string.Format("{0}{1}", _columns[index][0], row);
        }

        private NestleOrderRecord GetNestleOrderRecord(int row)
        {
            return new NestleOrderRecord()
                       {

                           Code = Sheet.Range[GetColumnIndex(3, row), Type.Missing].Value2.ToString(),
                           DocDate = Sheet.Range[GetColumnIndex(2, row), Type.Missing].Value2.ToString(),
                           DocNumber = Sheet.Range[GetColumnIndex(1, row), Type.Missing].Value2.ToString(),
                           Quantity = Sheet.Range[GetColumnIndex(4, row), Type.Missing].Value2.ToString(),
                           ShopPoint = Sheet.Range[GetColumnIndex(0, row), Type.Missing].Value2.ToString()
                       };
        }
        
        protected override void ReadDoc()
        {
            NestleFormatCheck();
            
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
        }
    }
}