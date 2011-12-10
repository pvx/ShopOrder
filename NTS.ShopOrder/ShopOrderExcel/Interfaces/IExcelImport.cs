using System.Collections.Generic;

namespace ShopOrderExcel.Interfaces
{
    /// <summary>
    /// ��������� �������� ����� �� Excel �����
    /// </summary>
    public interface IExcelImport
    {
        IList<IDataRecord> GetDataFromExcel(string filePath);
    }
}