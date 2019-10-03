using System;
using NUnit.Framework;

namespace Safe2Pay.Tests
{
    [TestFixture]
    public class AccountTests
    {
        private static readonly Safe2Pay_Request safe2pay = new Safe2Pay_Request("TOKEN", "SECRET", 30);

        [Test]
        public void Get_Bank_Data()
        {
            var response = safe2pay.Account.GetBankData();

            Assert.IsNotNull(response);

            Console.WriteLine(response.Bank);
            Console.WriteLine(response.Account);
            Console.WriteLine(response.AccountDigit);
            Console.WriteLine(response.Agency);
            Console.WriteLine(response.AgencyDigit);
        }

        [Test]
        public void List_Deposits()
        {
            var response = safe2pay.Account.GetListDeposits(5,2019);

            Assert.IsNotNull(response);

            Console.WriteLine(response.Deposits.Count);

            foreach (var items in response.Deposits)
            {
                Console.WriteLine(" --- ");

                Console.WriteLine(items.Amount);
                Console.WriteLine(items.DepositDate);
                Console.WriteLine(items.IsTransferred);
                Console.WriteLine(items.Message);
                Console.WriteLine(items.Tax);
                Console.WriteLine(items.TotalItems);
                Console.WriteLine(" --- ");
            }
        }

        [Test]
        public void Get_ListDetailsDeposits()
        {
            var response = safe2pay.Account.GetListDetailsDeposits(new DateTime(2019, 9, 17), 1, 10);

            Assert.IsNotNull(response);

            Console.WriteLine(response.Amount);
            Console.WriteLine(response.DepositDate);
            Console.WriteLine(response.IsTransferred);
            Console.WriteLine(response.Message);
            Console.WriteLine(response.Tax);
            Console.WriteLine(response.TotalItems);


            foreach (var items in response.Extracts)
            {
                Console.WriteLine(" --- ");

                Console.WriteLine(items.Amount);
                Console.WriteLine(items.Description);
                Console.WriteLine(items.IdTransaction);           
                Console.WriteLine(items.InstallmentCurrent);     
                Console.WriteLine(items.InstallmentQuantity);
                Console.WriteLine(items.Reference);
                Console.WriteLine(items.Tax);
                Console.WriteLine(items.PaymentMethod.Name);
                Console.WriteLine(" --- ");
            }
        }
    }
}