namespace ShopOrderExcel
{
    /// <summary>
    /// Класс данных из Excel заказа Nestle
    /// </summary>
    public class NestleOrderRecord : DataRecord
    {
        public string ShopPoint { get; set; }
        public string DocNumber { get; set; }
        public string DocDate { get; set; }
        public string Quantity { get; set; }
    }
}