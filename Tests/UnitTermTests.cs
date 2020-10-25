using Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Tests.LogicTests
{
    [TestClass]
    public class UnitTermTests

    {      
        private UnitTerm b;
        [TestInitialize]
        public void InitTests()
        {
            b = new UnitTerm();
        }
        [TestCleanup]
        public void CleanTests()
        {
            b = null;
        }
        [TestMethod]
        public void ConstructorTest()
        {
            Assert.IsNotNull(b);
        }
    }
}
