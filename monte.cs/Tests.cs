using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace monte.cs
{
    [TestClass]
    public class testMonte
    {
        [TestMethod]
        public void testGausian()
        { // push the changes
          // push the changes downstairs
            Monte mc = new Monte();
            double g = mc.gaussian_box_muller();
            Assert.IsTrue(g < 0);
        }
    }
}
