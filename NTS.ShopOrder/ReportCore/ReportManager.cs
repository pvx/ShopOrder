using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using DataBase;
using DevExpress.XtraReports.UI;
using Microsoft.Practices.Unity;
using ReportCore.Model;

namespace ReportCore
{
    public class ReportManager : IReportManager
    {
        private IUnityContainer _container;

        [ImportMany(typeof(IReport))]
        public List<Lazy<IReport, IReportMetadata>> ReportsList { get; set; }

        private SqlConnection _connection;

        [InjectionConstructor]
        public ReportManager(IUnityContainer container)
        {
            _container = container;
            ReportsList = new List<Lazy<IReport, IReportMetadata>>();

            if (!Directory.Exists("Reports"))
                Directory.CreateDirectory("Reports");
            var cat = new AggregateCatalog();
            cat.Catalogs.Add(new DirectoryCatalog("Reports"));

            var contnr = new CompositionContainer(cat);

            contnr.ComposeParts(this);
        }

        private void CheckReport(Guid id)
        {
            if (!ReportsList.Any(item => item.Metadata.Id == id.ToString().ToUpper()))
                throw new Exception(string.Format("Отчёт с таким ID: {0} не существует в списке", id));
        }

        private XtraReport GetReportById(Guid id)
        {
            _connection = (SqlConnection)_container.Resolve<OrderDataContext>().DataBaseContext.Connection;
            var callParameter = new ReportCallParameter(){Connection = _connection};
            return ReportsList.Where(item => item.Metadata.Id == id.ToString().ToUpper()).Select(item => item.Value.GetReport(callParameter)).FirstOrDefault();
        }

        public void ShowReport(Guid id)
        {
            CheckReport(id);
            var rep = GetReportById(id);
            var rvm = new ReportViewerModel(rep);
            rvm.ShowReport();
        }

        public List<ReportRecord> GetReportsList()
        {
            if(ReportsList.Count > 0)
            {
                return ReportsList.Select(item => new ReportRecord() {Id = Guid.Parse(item.Metadata.Id), 
                    Name = item.Metadata.Name, Group = item.Metadata.MenuGroupId}).ToList();
            }
            return null;
        }
    }
}