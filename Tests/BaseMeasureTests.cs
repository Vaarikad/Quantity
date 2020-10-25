using Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.LogicTests
{
    [TestClass]
    public class BaseMeasureTests {
        
        private BaseMeasure b;
        [TestInitialize]
        public void InitTests() {
            b = new BaseMeasure("kiirus");
        }

        [TestCleanup]
        public void CleanTests() {
            b = null;
        }
        [TestMethod]
        public void ConstructorTest()
        {
            Assert.IsNotNull(b);
        }
        [TestMethod] public void FormulaTest() {
            Assert.AreEqual(b.Symbol, b.Formula());
        }
        [TestMethod] public void MultiplyTest() {
            var m1 = new BaseMeasure("v");
            var m2 = new BaseMeasure("t");
            Measures.Instance.Add(m1);
            Measures.Instance.Add(m2);
            var m = m1.Multiply(m2);                      
            Assert.AreEqual("v^1*t^1", m.Formula());
        }

        
        [TestMethod]
        public void MultiplySameMeasuresTest()
        {
            var m1 = new BaseMeasure("s");
            Measures.Instance.Add(m1);
            var m = m1.Multiply(m1);
            Assert.AreEqual("s^2", m.Formula());
        }

       
        [TestMethod]
        public void MultiplyBaseWithDerivedTest()
        {
            var m1 = new BaseMeasure("v");
            Measures.Instance.Add(m1);
            var m = m1.Multiply(m1);
            var m2 = m1.Multiply(m);
            Assert.AreEqual("v^3", m2.Formula());
        }

        [TestMethod]
        public void DivideTest() {
            var m1 = new BaseMeasure("a");
            var m2 = new BaseMeasure("b");
            Measures.Instance.Add(m1);
            Measures.Instance.Add(m2);
            var m = m1.Divide(m2);
            Assert.AreEqual("a^1*b^-1", m.Formula());
        }
       
        [TestMethod]
        public void ExponentiationTest() {
            var m1 = new BaseMeasure("a");
            Measures.Instance.Add(m1);
            var m = m1.Exponentiation(5);
            var s = m1.Exponentiation(1);
            var c = m1.Exponentiation(0);
            var a = m1.Exponentiation(-5);
            Assert.AreEqual("a^5", m.Formula());
            Assert.AreEqual("a", s.Formula());            
            Assert.AreEqual("a^-5", a.Formula());
        }

        [TestMethod]
        public void ReciprocalTest() {
            var m1 = new BaseMeasure("a");            
            Measures.Instance.Add(m1);            
            var m = m1.Reciprocal();
            Assert.AreEqual("a^-1", m.Formula());
        }        
    }
}
