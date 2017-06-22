using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Uhr;

namespace TestUhr
{
    [TestClass]
    public class TestSwap
    {
        [TestMethod]
        public void SwapVerkehrte()
        {
            double a = 3, b = 2, c = 1;
            Uhr.Angle.Sort3(ref a, ref b, ref c);
            Assert.AreEqual(1, a);
            Assert.AreEqual(2, b);
            Assert.AreEqual(3, c);
        }
    }
}
