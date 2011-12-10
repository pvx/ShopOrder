using System;
using Common;
using Common.Logger;
using Microsoft.Practices.Unity;

namespace DataBase
{
    /// <summary>
    /// Контекст базы данных
    /// </summary>
    public class OrderDataContext: IDisposable
    {
        private readonly DataBaseDataContext _dataBaseContext;

        [Dependency]
        public Logger Log { get; set; }

        [InjectionConstructor]
        public OrderDataContext(IOrderConnection orderConnection)
        {
            _dataBaseContext = new DataBaseDataContext(orderConnection.GetSqlConnection());
        }

        public DataBaseDataContext DataBaseContext
        {
            get { return _dataBaseContext; }
        }

        public void Dispose()
        {
            //Log.Info("OrderDataContext dispose");
            //Console.Out.WriteLine("OrderDataContext dispose");
        }
    }
}