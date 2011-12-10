using ShopOrderExcel.Interfaces;

namespace ShopOrderExcel
{
    /// <summary>
    /// Класс записи данных импортированной из Excel
    /// </summary>
    public class DataRecord : IDataRecord
    {
        public string Code
        {
            get; set;
        }
    }
}