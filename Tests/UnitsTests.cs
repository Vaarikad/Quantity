using System.Runtime.Serialization;
using System.Xml.Serialization;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logic;

namespace Tests.LogicTests
{    
    [TestClass]
    public class UnitsTests
    {
        private Units unit;
        [TestInitialize]
        public void TestInitialize()
        {
            unit = new Units();
        }
        
        [TestMethod]
        public void ConstructorTest()
        {
            Assert.IsNotNull(unit);
        }        
    }
}
