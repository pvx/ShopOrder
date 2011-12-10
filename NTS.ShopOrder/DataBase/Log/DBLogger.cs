using System.Security.Principal;
using Microsoft.Practices.Unity;

namespace DataBase.Log
{
    /// <summary>
    /// Класс логгера в базу данных
    /// </summary>
    public class DBLogger : IDBLogger
    {
        [Dependency]
        public IUnityContainer Container { get; set; }

        private readonly string _userLogin;

        public DBLogger()
        {
            _userLogin = WindowsIdentity.GetCurrent().Name;
        }

        public void InsertLog(string message, string docId)
        {
            using (var oc = Container.Resolve<OrderDataContext>())
            {
                oc.DataBaseContext.InsUILog(message, docId, _userLogin);
            }
        }      
    }
}