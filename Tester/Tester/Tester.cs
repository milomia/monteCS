using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Tester
{
    [TestClass()]
    public class Test
    {
        [TestMethod()]
        public void TestMessage()
        {
            var test = TradeFactory.TradeFactory.CreateTrade("Bond");
        }
    }
}
