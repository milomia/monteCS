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
          // push the changes upstairs
            Monte mc = new Monte();
            double g = mc.gaussian_box_muller();
            Assert.IsTrue(g > 0);
        }
        [TestMethod]
        public void TestGetCallPrice()
        {
            double num_sims = 1000000; // Number of simulated asset paths
            double S = 100.0; // Option price
            double K = 100.0; // Strike price
            double r = 0.05;  // Risk free rate (5%)
            double v = 0.2;   // volatility of the underlying (20%)
            double T = 1.0;   // One year until expiry

            Monte mc = new Monte();

            double call = mc.GetCallPrice(ref num_sims, ref S, ref K, ref r, ref v, ref T);
            Assert.IsTrue(call > 10 && call < 15);
        }
        [TestMethod]
        public void TestGetPutPrice()
        {
            double num_sims = 1000000; // Number of simulated asset paths
            double S = 100.0; // Option price
            double K = 100.0; // Strike price
            double r = 0.05;  // Risk free rate (5%)
            double v = 0.2;   // volatility of the underlying (20%)
            double T = 1.0;   // One year until expiry

            Monte mc = new Monte();

            double put = mc.GetPutPrice(ref num_sims, ref S, ref K, ref r, ref v, ref T);
            Assert.IsTrue(put > 3 && put < 10);
        }
    }
}
