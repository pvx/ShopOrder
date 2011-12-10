using System.Collections.Generic;

namespace ShopOrderExcel.Interfaces
{
    /// <summary>
    /// Интерфейс загрузки даннх из Excel файла
    /// </summary>
    public interface IExcelImport
    {
        IList<IDataRecord> GetDataFromExcel(string filePath);
    }
}