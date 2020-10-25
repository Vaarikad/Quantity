using System.Runtime.InteropServices;
using Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.LogicTests {
    [TestClass]
    public class QuantityTest {
        private Quantity quantity1;
        private Quantity quantity2;
        private Quantity quantity3;
        private Quantity quantity4;
        private BaseMeasure baseMeasure1;
        private BaseMeasure baseMeasure2;
        private BaseUnit baseUnit1;
        private BaseUnit baseUnit2;
        private BaseUnit baseUnit3;        

        [TestInitialize]
        public void InitTests() {            
            baseMeasure1 = new BaseMeasure("pikkus");
            baseMeasure2 = new BaseMeasure("aeg");
            baseUnit1 = new BaseUnit(baseMeasure1, 1, "m", "meeter");
            baseUnit2 = new BaseUnit(baseMeasure2, 1, "s", "sekund");
            baseUnit3 = new BaseUnit(baseMeasure1, 1000,"km","kilomeeter");
            Measures.Instance.Add(baseMeasure1);
            Measures.Instance.Add(baseMeasure2);
            Units.Instance.Add(baseUnit1);
            Units.Instance.Add(baseUnit2);
            Units.Instance.Add(baseUnit3);
            quantity1 = new Quantity(200, baseUnit1);
            quantity2 = new Quantity(300, baseUnit2);
            quantity3 = new Quantity(400, baseUnit3);
            quantity4 = new Quantity(213.4565, baseUnit3);
        }

        [TestCleanup]
        public void CleanTests() {
            quantity1 = null;
            quantity2 = null;
            quantity3 = null;
            quantity4 = null;
            baseMeasure1 = null;
            baseMeasure2 = null;
            baseUnit1 = null;
            baseUnit2 = null;
            baseUnit3 = null;
        }

        [TestMethod]
        public void ConstructorTest() {
            quantity1.Unit = null;
            Assert.AreEqual("", quantity1.Unit.Name);
            Assert.IsNotNull(quantity1);
        }

        [TestMethod]
        public void GetUnitTest() {
            var c = quantity1.Unit;
            Assert.AreEqual("m", c.Symbol);
        }

        [TestMethod]
        public void IsEqualQuanityTest()
        {
            Assert.IsFalse(quantity1.IsEqual(quantity2));
            Assert.IsTrue(quantity1.IsEqual(quantity1));
        }

        [TestMethod]
        public void IsGreaterThanTest() {
            Assert.IsFalse(quantity2.IsGreaterThan(quantity2));
            Assert.IsFalse(quantity2.IsGreaterThan(quantity1));
            Assert.IsTrue(quantity1.IsGreaterThan(quantity3));
        }

        [TestMethod]
        public void IsLessThanTest() {
            Assert.IsFalse(quantity2.IsLessThan(quantity2));
            Assert.IsFalse(quantity2.IsLessThan(quantity1));
            Assert.IsTrue(quantity3.IsLessThan(quantity1));
        }

        [TestMethod]
        public void ConvertTest() {
            var a = quantity3.Convert(baseUnit1);
            var b = quantity3.Convert(baseUnit2);
            Assert.AreEqual(400000, a.Amount);
            Assert.AreEqual("meeter", a.Unit.Name);
            Assert.AreEqual(400000,b.Amount);
            Assert.AreEqual("sekund", b.Unit.Name);
        }
        [TestMethod]
        public void ConvertoTest()
        {
            var a = quantity3.ConvertTo(baseUnit1);
            var b = quantity3.ConvertTo(baseUnit2);
            Assert.AreEqual(400000, a.Amount);
            Assert.AreEqual("meeter", a.Unit.Name);
            Assert.AreEqual(double.NaN, b.Amount);
            Assert.AreEqual("sekund", b.Unit.Name);
        }

        [TestMethod]
        public void AddTest() {
            var a = quantity1.Add(quantity3);
            var b = quantity1.Add(quantity2);
            Assert.AreEqual(400.200, a.Amount);
            Assert.AreEqual("kilomeeter", a.Unit.Name);            
        }

        [TestMethod]
        public void SubtractTest() {
            var a = quantity1.Subtract(quantity3);
            var b = quantity1.Subtract(quantity2);
            Assert.AreEqual(-399.800, a.Amount);
            Assert.AreEqual("kilomeeter", a.Unit.Name);            
        }

        [TestMethod]
        public void MultiplyDoubleTest() {
            var a = quantity3.Multiply(3);
            Assert.AreEqual(1200, a.Amount);
            Assert.AreEqual("kilomeeter", a.Unit.Name);
        }

        [TestMethod]
        public void DivideDoubleTest()
        {
            var a = quantity3.Divide(2);
            Assert.AreEqual(200, a.Amount);
            Assert.AreEqual("kilomeeter", a.Unit.Name);
        }

        [TestMethod]
        public void MultiplyQuantitiesTest() {
            var a = quantity1.Multiply(quantity3);
            var b = quantity3.Multiply(quantity1);
            var c = quantity1.Multiply(quantity2);
            Assert.AreEqual(80, a.Amount);
            Assert.AreEqual("meeter*kilomeeter", a.Unit.Name);
            Assert.AreEqual(80000000, b.Amount);
            Assert.AreEqual("kilomeeter*meeter", b.Unit.Name);            
        }

        [TestMethod]
        public void DivideQuantitiesTest() {
            var a = quantity1.Divide(quantity3);
            var b = quantity3.Divide(quantity1);
            var c = quantity1.Divide(quantity2);
            Assert.AreEqual(0.0005, a.Amount);
            Assert.AreEqual("meeter*kilomeeter^-1", a.Unit.Name);
            Assert.AreEqual(2000, b.Amount);
            Assert.AreEqual("kilomeeter*meeter^-1", b.Unit.Name);            
        }

        [TestMethod]
        public void RoundTest() {
            var r = new RoundingPolicy();
            var a = quantity4.Round(r);
            Assert.AreEqual(213.46, a.Amount);
        }     
    }
}
