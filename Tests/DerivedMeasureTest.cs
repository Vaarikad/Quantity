using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logic;
namespace Tests.LogicTests
{
    [TestClass]
    public class DerivedMeasureTest
        {
        private DerivedMeasure t;
        private BaseMeasure m1;
        private BaseMeasure m2;
        private BaseMeasure m3;
        private DerivedMeasure d1;
        private DerivedMeasure d2;
        private DerivedMeasure d3;
        private DerivedMeasure d4;
        [TestInitialize]
        public void InitTests()
        {
            t = new DerivedMeasure();
            m1 = new BaseMeasure("v");
            m2 = new BaseMeasure("t");
            m3 = new BaseMeasure("c");
            Measures.Instance.Add(m1);
            Measures.Instance.Add(m2);
            Measures.Instance.Add(m3);
            d1 = (DerivedMeasure) m1.Multiply(m2);
            d2 = (DerivedMeasure) m1.Multiply(m1);
            d3 = (DerivedMeasure) m3.Multiply(m3);
            d4 = (DerivedMeasure) m1.Multiply(m3);
        }

        [TestCleanup]
        public void CleanTests() { t = null; }
        [TestMethod]
        public void ConstructorTest() { Assert.IsNotNull(t); }

        [TestMethod]
        public void MultiplyTest() {            
            var q = d1.Multiply(d3);
            var s = d2.Multiply(d3);
            var d = d1.Multiply(d2);
            Assert.AreEqual("v^1*t^1*c^2", q.Formula());
            Assert.AreEqual("v^2*c^2", s.Formula());
            Assert.AreEqual("v^3*t^1", d.Formula());
        }

        [TestMethod]
        public void MultiplySameDerivedMeasures() {
            var q = d1.Multiply(d1);
            Assert.AreEqual("v^2*t^2", q.Formula());            
        }

        [TestMethod]
        public void DivideTest() {
            var q = d1.Divide(d3);
            var s = d1.Divide(d2);
            Assert.AreEqual("v^1*t^1*c^-2", q.Formula());            
            Assert.AreEqual("v^-1*t^1", s.Formula());            
        }

        [TestMethod]
        public void DivideSameDerivedMeasures() {
            var q = d1.Divide(d1);
            Assert.AreEqual(new BaseMeasure().Name, q.Name);
        }

        [TestMethod]
        public void DivadeSamePowersTest() {
            var b = d1.Divide(d4);
            Assert.AreEqual("t^1*c^-1", b.Formula());
        }

        [TestMethod]
        public void ExponentiationTest() {
            var a = d1.Exponentiation(2);
            var b = d2.Exponentiation(3);
            var c = d3.Exponentiation(0);
            Assert.AreEqual("v^2*t^2", a.Formula());
            Assert.AreEqual("v^6", b.Formula());            
        }

        [TestMethod]
        public void ReciprocalTest(){
            var a = d1.Reciprocal();
            var b = d3.Reciprocal();
            Assert.AreEqual("v^-1*t^-1", a.Formula());
            Assert.AreEqual("c^-2",b.Formula());
        }       
    }
}