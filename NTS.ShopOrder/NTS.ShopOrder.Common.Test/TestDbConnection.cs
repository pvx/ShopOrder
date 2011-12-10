using NUnit.Framework;
using NTS.ShopOrder;

namespace Common.Test
{
    [TestFixture]
    public class TestNtsConnection
    {
        const string _server = "SRV-13";
        const string _dataBase = "DB23";
        const string _userName = "User2";
        private const string _userPassword = "Psw$352";
         
        private OrderConnection connection;

        [TestFixtureSetUp]
        public virtual void TestSetup()
        {
            OrderConnection connection = new OrderConnection(_server, _dataBase, _userName, _userPassword);
        }


        [Test]
        void TestConnection()
        {
            Assert.IsNotNull(connection);
          //  Assert.AreEqual(employee.Id, 1);
        }




    }
}
