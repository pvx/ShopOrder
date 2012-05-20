using NUnit.Framework;

namespace Common.Test
{
    [TestFixture]
    public class TestFixtureBase
    {
        [TestFixtureSetUp]
        public virtual void TestFixtureSetup()
        {

        }

        [TearDown]
        public virtual void AfterEachTest()
        { }

    }
}