using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logic;

namespace Tests.LogicTests
{
    [TestClass]
    public class MetricTests {
        private class TestClass: Metric{ }
        private Metric m;
        [TestInitialize]
        public void InitTests() {
            m = new TestClass();
        }

        [TestCleanup]
        public void CleanTests() {
            m = null;
        }
        [TestMethod]
        public void ConstructorTest()
        {
            Assert.IsNotNull(m);
        }

        [TestMethod]
        public void NameTest() {
            Assert.IsNotNull(m.Name);
            m.Name = null;
            Assert.IsNotNull(m.Name);
        }
        [TestMethod]
        public void SymbolTest()
        {
            Assert.IsNotNull(m.Symbol);
            m.Symbol = null;
            Assert.IsNotNull(m.Symbol);
        }
        [TestMethod]
        public void DefinitionTest()
        {
            Assert.IsNotNull(m.Definition);
            m.Definition = null;
            Assert.IsNotNull(m.Definition);
        }

    }
}
