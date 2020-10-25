using Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.LogicTests
{
    [TestClass]
    public class BaseUnitTests
    {
       
       [TestMethod]
       public void ExponentationTest()
       {
          var m1 = new BaseMeasure("a");
          Measures.Instance.Add(m1);
          var u = new BaseUnit(m1, 1, "s", "pikkus");
          Units.Instance.Add(u);
          var m = u.Exponentiation(4);
          var s = u.Exponentiation(1);
          var c = u.Exponentiation(0);
          var a = u.Exponentiation(-4);
          Assert.AreEqual("a^4", m.Measure.Name);
          Assert.AreEqual("s^4", m.Formula());
          Assert.AreEqual("s", s.Formula());          
          Assert.AreEqual("s^-4", a.Formula());
      }

        [TestMethod]
        public void ReciprocalTest()
        {
            var m1 = new BaseMeasure("a");
            Measures.Instance.Add(m1);
            var u = new BaseUnit(m1, 1, "s", "pikkus");
            Units.Instance.Add(u);
            var m = u.Reciprocal();
            Assert.AreEqual("s^-1", m.Formula());
            Assert.AreEqual("a^-1", m.Measure.Name);
        }

        [TestMethod]
        public void MultiplyTest() {
            var m1 = new BaseMeasure("a");
            Measures.Instance.Add(m1);
            var u1 = new BaseUnit(m1, 1, "s", "pikkus");
            var u2 = new BaseUnit(m1, 1, "t", "aeg");
            Units.Instance.Add(u1);
            Units.Instance.Add(u2);            
            var u = u1.Multiply(u2);
            Assert.AreEqual("s*t", u.Formula());
            Assert.AreEqual("pikkus*aeg", u.Formula(true));
            Assert.AreEqual("a^2", u.Measure.Name);
        }

        [TestMethod]
        public void MultiplySameUnitsTest()
        {
            var m1 = new BaseMeasure("a");
            Measures.Instance.Add(m1);
            var u = new BaseUnit(m1, 1, "s", "pikkus");
            Units.Instance.Add(u);
            var m = u.Multiply(u);
            Assert.AreEqual("a^2", m.Measure.Name);
            Assert.AreEqual("s^2", m.Formula());
        }

        [TestMethod]
        public void MultiplyBaseWithDerivedTest()
        {
            var m1 = new BaseMeasure("v");
            Measures.Instance.Add(m1);
            var u = new BaseUnit(m1, 1, "s", "pikkus");
            Units.Instance.Add(u);
            var m = u.Multiply(u);
            var m2 = u.Multiply(m);
            Assert.AreEqual("s^3", m2.Formula());
            Assert.AreEqual("v^3", m2.Measure.Name);
        }

        [TestMethod]
        public void DivideTest()
        {
            var m1 = new BaseMeasure("a");
            var m2 = new BaseMeasure("b");
            Measures.Instance.Add(m1);
            Measures.Instance.Add(m2);
            var u1 = new BaseUnit(m1, 1, "s", "pikkus");
            var u2 = new BaseUnit(m2, 1, "t", "aeg");
            Units.Instance.Add(u1);
            Units.Instance.Add(u2);
            var u = u1.Divide(u2);
            Assert.AreEqual("s*t^-1", u.Formula());
            Assert.AreEqual("a^1*b^-1", u.Measure.Name);
            Assert.AreEqual("pikkus*aeg^-1", u.Formula(true));
        }        
    }    
}


