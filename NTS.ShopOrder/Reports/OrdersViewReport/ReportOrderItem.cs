using OrdersViewReport.UI;
using ReportCore;
using ReportCore.UI;

namespace OrdersViewReport
{
    public class ReportOrderItem: IReportItem
    {
        private readonly IReportCallParameter _parameter;

        public ReportOrderItem(IReportCallParameter parameter)
        {
            _parameter = parameter;
        }

        public ParamUIBase GetParam()
        {
            return new ParamUI(_parameter);
        }
    }
}