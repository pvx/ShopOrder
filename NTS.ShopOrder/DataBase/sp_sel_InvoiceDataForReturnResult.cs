namespace DataBase
{
    public partial class sp_sel_InvoiceDataForReturnResult
    {
        public override string ToString()
        {
            return string.Format("{0} ( {1} ���: {2} {3} �� {4:yyyy.MM.dd})", Name, Supplier, Seria, Number, InvoiceDate);
        }

        public double QuantityRet { get; set; }

        public int ReturnReasonId { get; set; }}
}