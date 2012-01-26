using System;
using ReportCore;

namespace OrdersViewReport.Data
{
    public interface IOrderReportDataSource: IReportDataSource 
    {
        DateTime DateBegin { get; set; }
        DateTime DateEnd { get; set; }

        string ShopCode { get; set; }
        string Group { get; set; }
        string Supplier { get; set; }
        string Barcode { get; set; }
    }
}