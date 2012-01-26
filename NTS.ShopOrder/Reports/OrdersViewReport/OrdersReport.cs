using System.ComponentModel.Composition;
using System.Data.SqlClient;
using DevExpress.XtraReports.UI;
using OrdersViewReport.Data;
using ReportCore;

namespace OrdersViewReport
{
    [Export(typeof(IReport)), 
    ReportMetadata(Id = "12A83E02-123B-4667-B74C-ACABFC7D2909", 
                   Name = "Просмотр заказов за период",
                   MenuGroupId = "Заказ товаров")]
    public class OrdersReport : IReport
    {
        public XtraReport GetReport(IReportCallParameter parameter)
        {
            //ReportDesignExtension.RegisterExtension(new Class1(), "PersonEnums");
            var ds = new ReportDataSource();
            //ds.Load(parameter.Connection);
            var v = new OrderViewRpt() {DataSource = ds, ReportDataConnection = parameter.Connection};
            return v;
        }
    }
    
}
