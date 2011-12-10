using System;
using System.Text.RegularExpressions;
using Microsoft.Office.Interop.Excel;

namespace ShopOrderExcel
{
    /// <summary>
    /// ����� ������� ������ �� Excel �� ������������� ������������
    /// </summary>
    public class ReqAssortImport : ExcelImport
    {
        /// <exception cref="FormatException">�� ���������� ������ �����. ���� AssortForOrder �� ������.</exception>
        protected override void ReadDoc()
        {
            Excelsheets = Workbook.Worksheets;
            Sheet = (Worksheet)Excelsheets.Item[1];

            if (Sheet.Name != "ReqAssort")
                throw new FormatException(@"�� ���������� ������ �����. ���� ReqAssort �� ������.");
            Cells = Sheet.Range["A1", Type.Missing];
            string str = Convert.ToString(Cells.Value2);
            if (str != "���")
                throw new FormatException(@"�� ���������� ������ �����. ���� ��� �� �������.");

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