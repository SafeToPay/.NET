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
        public void Get_Balance()
        {
            var response = safe2pay.Account.GetBalance();

            Assert.IsNotNull(response);

            Console.WriteLine(response.AmountReceived);
            Console.WriteLine(response.AmountPreview);
            Console.WriteLine(response.AmountCanceled);
            Console.WriteLine(response.AmountContestation);
            Console.WriteLine(response.AmountTaxes);
            Console.WriteLine(response.AmountAvailableToday);
        }

        [Test]
        public void List_Deposits()
        {
            var response = safe2pay.Account.ListDeposits();

            Assert.IsNotNull(response);

            Console.WriteLine(response.Count);

            foreach (var items in response)
            {
                Console.WriteLine(" --- ");
                
                Console.WriteLine(items.Amount);
                Console.WriteLine(items.Tax);
                Console.WriteLine(items.IsTransferred);
                Console.WriteLine(items.IsToday);
                Console.WriteLine(items.ReleaseDate);
                Console.WriteLine(items.CreatedDate);
                Console.WriteLine(items.InstallmentNumber);
                Console.WriteLine(items.InstallmentQuantity);

                Console.WriteLine(" --- ");
            }
        }

        [Test]
        public void List_Period()
        {
            var response = safe2pay.Account.DetailDayDeposits();

            Assert.IsNotNull(response);

            Console.WriteLine(response.TotalAmountDay);
            Console.WriteLine(response.IsReceived);
            Console.WriteLine(response.TotalTax);
            Console.WriteLine(response.TotalChargeback);
            Console.WriteLine(response.SelectDate);

            Console.WriteLine(response.Objects.Count);

            foreach (var items in response.Objects)
            {
                Console.WriteLine(" --- ");
                
                Console.WriteLine(items.IdTransaction);
                Console.WriteLine(items.Description);
                Console.WriteLine(items.Reference);
                Console.WriteLine(items.Amount);
                Console.WriteLine(items.Tax);
                Console.WriteLine(items.IsTransferred);
                Console.WriteLine(items.IsToday);
                Console.WriteLine(items.ReleaseDate);
                Console.WriteLine(items.CreatedDate);
                Console.WriteLine(items.InstallmentNumber);
                Console.WriteLine(items.InstallmentQuantity);

                Console.WriteLine(" --- ");
            }
        }
    }
}