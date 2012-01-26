using System;

namespace ReportCore
{
    public interface IReportMetadata
    {
        string Name { get; }
        string Id { get; }
        string MenuGroupId { get; }
    }
}