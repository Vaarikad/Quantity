using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logic;

namespace Tests.LogicTests
{
    [TestClass]
    public class MeasureTests
    {
        private class TestClass: Measure { }
        private Measure m;
        [TestInitialize]
        public void InitTests()
        {
            m = new TestClass();
        }
        [TestCleanup]
        public void CleanTests()
        {
            m = null;
        }
        [TestMethod]
        public void ConstructorTest()
        {
            Assert.IsNotNull(m);
        }
        //[TestMethod] public void SymbolTest() {
        //    testProperty(()=>m.Symbol, x => m.Symbol = x);
        //}
        [TestMethod]
        public void NameTest() {
            Assert.IsNotNull(m.Name);
            m.Name = null;
            Assert.AreEqual(String.Empty, m.Name);
            m.Name = "Some name";
            Assert.AreEqual("Some name", m.Name);
        }
    }
}
