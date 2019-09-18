using System;
using NUnit.Framework;

namespace Safe2Pay.Tests
{
    [TestFixture]
    public class TransactionTests
    {
        private static readonly Safe2Pay_Request safe2pay = new Safe2Pay_Request("TOKEN", "SECRET", 30);

        [Test]
        public void Get_Transaction()
        {
            var response = safe2pay.Transaction.Detail(1044142);

            Assert.NotNull(response);

            Console.WriteLine(response.IdTransaction);
            Console.WriteLine(response.Status);
        }

        [Test]
        public void List_By_Reference()
        {
            var response = safe2pay.Transaction.ListByReference("Teste");

            Assert.NotNull(response);

            foreach (var items in response)
            {
                Console.WriteLine(" --- ");

                Console.WriteLine(items.IdTransaction);
                Console.WriteLine(items.Status);
                Console.WriteLine(items.Amount);

                Console.WriteLine(" --- ");
            }
        }

        [Test]
        public void List()
        {
            var response = safe2pay.Transaction.List();

            Assert.NotNull(response);

            foreach (var items in response)
            {
                Console.WriteLine(" --- ");

                Console.WriteLine(items.IdTransaction);
                Console.WriteLine(items.Status);
                Console.WriteLine(items.Amount);

                Console.WriteLine(" --- ");
            }
        }

        [Test]
        public void Release_Bank_Slip()
        {
            var response = safe2pay.Transaction.ReleaseBankSlip(1044532);

            Assert.NotNull(response);
            Assert.IsTrue(response);
            Console.WriteLine("Boleto liberado com sucesso!");
        }

        [Test]
        public void Cancel_Bank_Slip()
        {
            var response = safe2pay.Transaction.WriteOffBankSlip(1044534);

            Assert.NotNull(response);
            Assert.IsTrue(response);
            Console.WriteLine("Boleto cancelado com sucesso!");
        }

        [Test]
        public void Credit_Refund()
        {
            var response = safe2pay.Transaction.RefundCredit(1044538);

            Assert.NotNull(response);
            Assert.IsTrue(response);
            Console.WriteLine("Estorno realizado com sucesso!");
        }

        [Test]
        public void Debit_Refund()
        {
            var response = safe2pay.Transaction.RefundDebit(1044545);

            Assert.NotNull(response);
            Assert.IsTrue(response);
            Console.WriteLine("Estorno realizado com sucesso!");
        }
    }
}