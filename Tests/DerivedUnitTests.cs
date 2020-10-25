using Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.LogicTests
{
    [TestClass]
    public class DerivedUnitTests {
        private DerivedUnit t;
        private BaseMeasure bm1;
        private BaseMeasure bm2;
        private BaseMeasure bm3;
        private BaseUnit m1;
        private BaseUnit m2;
        private BaseUnit m3;
        private DerivedUnit d1;
        private DerivedUnit d2;
        private DerivedUnit d3;
        private DerivedUnit d4;

        [TestInitialize]
        public void InitTests() {
            t = new DerivedUnit();
            bm1 = new BaseMeasure("pk");
            bm2 = new BaseMeasure("ae");
            bm3 = new BaseMeasure("mi");
            Measures.Instance.Add(bm1);
            Measures.Instance.Add(bm2);
            Measures.Instance.Add(bm3);        
            m1 = new BaseUnit(bm1, 1, "s", "pikkus");
            m2 = new BaseUnit(bm2, 1, "t", "aeg");
            m3 = new BaseUnit(bm3, 1, "k", "midagi");
            Units.Instance.Add(m1);
            Units.Instance.Add(m2);
            Units.Instance.Add(m3);
            d1 = (DerivedUnit) m1.Multiply(m2);//s1*t1
            d2 = (DerivedUnit) m1.Multiply(m3);//s1*k1
            d3 = (DerivedUnit) m2.Multiply(m3);//t1*k1
            d4 = (DerivedUnit) m3.Multiply(m3);//k2
            
        }

        [TestCleanup]
        public void CleanTests() {
            t = null;
            bm1 = null;
            bm2 = null;
            bm3 = null;
            m1 = null;
            m2 = null;
            m3 = null;
            d1 = null;
            d2 = null;
            d3 = null;
            d4 = null;
        }

        [TestMethod]
        public void ConstructorTest() { Assert.IsNotNull(t);}

        [TestMethod]
        public void ExponentationTest() {            
            var a = d1.Exponentiation(3);
            var b = d2.Exponentiation(5);
            var c = d3.Exponentiation(0);
            var d = d4.Exponentiation(2);
            Assert.AreEqual("pk^3*ae^3", a.Measure.Name);
            Assert.AreEqual("s^3*t^3", a.Formula());
            Assert.AreEqual("s^5*k^5", b.Formula());            
            Assert.AreEqual("k^4", d.Formula());
        }

        [TestMethod]
        public void ReciprocalTest() {
            var a = d1.Reciprocal();
            var b = d4.Reciprocal();
            Assert.AreEqual("pk^-1*ae^-1", a.Measure.Name);
            Assert.AreEqual("s^-1*t^-1", a.Formula());
            Assert.AreEqual("k^-2", b.Formula());
        }

        [TestMethod]
        public void MultiplyTest()
        {
            var q = d1.Multiply(d3);
            var s = d2.Multiply(d3);
            var d = d1.Multiply(d2);
            Assert.AreEqual("pk^1*ae^2*mi^1", q.Measure.Name);
            Assert.AreEqual("s*t^2*k", q.Formula());
            Assert.AreEqual("s*k^2*t", s.Formula());
            Assert.AreEqual("s^2*t*k", d.Formula());
        }

        [TestMethod]
        public void MultiplySameDerivedUnits()
        {
            var q = d1.Multiply(d1);
            Assert.AreEqual("s^2*t^2", q.Formula());
        }

        [TestMethod]
        public void DivideTest()
        {
            var q = d1.Divide(d3);
            var s = d1.Divide(d2);
            Assert.AreEqual("pk^1*mi^-1", q.Measure.Name);
            Assert.AreEqual("s*k^-1", q.Formula());
            Assert.AreEqual("t*k^-1", s.Formula());
        }

        [TestMethod]
        public void DivideSameDerivedUnits()
        {
            var q = d1.Divide(d1);
            Assert.AreEqual(new BaseUnit().Name, q.Name);
        }       
    }
  }

