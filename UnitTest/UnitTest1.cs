using Microsoft.VisualStudio.TestTools.UnitTesting;
//using UnityEngine;
//using PerfectThroughness;
namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Main()
        {
            Motorcycle moto = new Motorcycle();
            Assert.IsNotNull(moto.speed);
        }
    }
}
