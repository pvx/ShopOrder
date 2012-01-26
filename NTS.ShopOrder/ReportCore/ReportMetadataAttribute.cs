using System;
using System.ComponentModel.Composition;

namespace ReportCore
{
    [MetadataAttribute]
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class ReportMetadataAttribute : ExportAttribute, IReportMetadata
    {
        public string Name { get; set; }
        private string _id;
        public string Id
        {
            get { return _id.ToUpper(); }
            set { _id = value; }
        }

        public string MenuGroupId { get; set; }
    }
}
