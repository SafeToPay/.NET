using NUnit.Framework;
using System;

namespace Safe2Pay.Tests
{
    [TestFixture]
    public class AdvancePaymentTests
    {
        private static readonly Safe2Pay_Request safe2pay = new Safe2Pay_Request("TOKEN", "SECRET", 30);

        [Test]
        public void Simulation()
        {
            var response = safe2pay.AdvancePayment.AdvancePaymentSimulation();

            Assert.IsNotNull(response);

            Console.WriteLine(response.AmountReceivables);
            Console.WriteLine(response.AmountNetReceivables);
            Console.WriteLine(response.Tax);
            foreach (var items in response.Items)
            {
                Console.WriteLine(" --- ");

                Console.WriteLine(items.Id);
                Console.WriteLine(items.Description);
                Console.WriteLine(items.InstallmentQuantity);

                Console.WriteLine(" --- ");
            }
        }
        [Test]
        public void Require()
        {
            var response = safe2pay.AdvancePayment.AdvancePaymentRequire();

            Assert.IsNotNull(response);

            Console.WriteLine(response.Message);
            foreach (var items in response.Items)
            {
                Console.WriteLine(" --- ");

                Console.WriteLine(items.Id);
                Console.WriteLine(items.Description);
                Console.WriteLine(items.InstallmentQuantity);

                Console.WriteLine(" --- ");
            }
        }
    }
}
