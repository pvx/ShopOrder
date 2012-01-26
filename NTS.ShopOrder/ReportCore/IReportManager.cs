using System;
using System.Collections.Generic;

namespace ReportCore
{
    public interface IReportManager
    {
        List<ReportRecord> GetReportsList();
        void ShowReport(Guid id);
    }
}