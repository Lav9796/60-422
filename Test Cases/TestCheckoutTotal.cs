using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BookStoreLIB.TestCases
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    namespace BookStoreLIB
    {
        [TestClass]
        public class TestCheckoutTotal
        {
            [TestMethod]
            public void TestPriceTotal()
            {

                BookOrder newOrder;

                try
                {
                    newOrder = new BookOrder();
                    double newTotal = newOrder.GetOrderTotal();
                    Assert.AreEqual(0, newTotal);

                }
                catch
                {
                    Assert.Fail("Exception should be thrown");

                }
            }
        }
    }
}
