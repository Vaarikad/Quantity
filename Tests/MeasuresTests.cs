using Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.LogicTests {
    [TestClass]
    public class MeasuresTest {
        private Measures measures;

        [TestInitialize]
        public void TestInitialize() {            
            measures = new Measures();
        }

        [TestMethod]
        public void ConstructorTest() {
            Assert.IsNotNull(measures);
        }       
    }
}
