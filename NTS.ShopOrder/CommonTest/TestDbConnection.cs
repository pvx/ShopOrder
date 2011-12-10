using System.Data;
using Common;
using System.Data.SqlClient;
using Microsoft.Practices.Unity;
using NUnit.Framework;

namespace CommonTest
{
    [TestFixture]
    public class TestNtsConnection
    {
        const string _server = "mi001-ws00071";
        const string _dataBase = "ShopOrders";
        const string _userName = "sa";
        const string _userPassword = "Oberon";

        private readonly IUnityContainer _container = new UnityContainer();

        private IOrderConnection connection;

        [TestFixtureSetUp]
        public void TestSetup()
        {
            _container.RegisterType<IOrderConnection, OrderConnection>(new InjectionConstructor( _server, _dataBase, _userName, _userPassword ));   
        }

        [Test]
        public void TestIsNotNullConnection()
        {
            connection = _container.Resolve<OrderConnection>();
            Assert.IsNotNull(connection.GetSqlConnection());
        }

        [Test]
        public void TestIsConnectedToDb()
        {
            connection = _container.Resolve<OrderConnection>();
            SqlConnection con = connection.GetSqlConnection();
            con.Open();
            Assert.AreEqual(con.State, ConnectionState.Open);
        }


    }
}
