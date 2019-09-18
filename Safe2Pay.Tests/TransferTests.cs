using System;
using System.Collections.Generic;
using NUnit.Framework;
using Safe2Pay.Models;

namespace Safe2Pay.Tests
{
    [TestFixture]
    public class TransferTests
    {
        private static readonly Safe2Pay_Request safe2pay = new Safe2Pay_Request("TOKEN", "SECRET", 30);

        [Test]
        public void New_Transfer()
        {
            var transfer = new TransferRegisterLot
            {
                //IsUseCheckingAccount = true,

                TransferRegisters = new List<TransferRegister>
                {
                    new TransferRegister
                    {
                        BankData = new BankData
                        {
                            Bank = new Bank { Code = "001"},
                            BankAgency = "1234",
                            BankAgencyDigit = "5",
                            BankAccount = "5432",
                            BankAccountDigit = "1",
                        },
                        ReceiverName = "Primeiro Cliente de Teste",
                        Identity = RandomCPF(),
                        Identification = "Teste Automatizado",
                        Amount = 100m,
                        CompensationDate = new DateTime(DateTime.Now.Year, DateTime.Now.AddMonths(1).Month, DateTime.Now.Day)
                    },
                    new TransferRegister
                    {
                        BankData = new BankData
                        {
                            Bank = new Bank { Code = "001"},
                            BankAgency = "1234",
                            BankAgencyDigit = "5",
                            BankAccount = "5432",
                            BankAccountDigit = "1",
                        },
                        ReceiverName = "Segundo Cliente de Teste",
                        Identity = RandomCNPJ(),
                        Identification = "Teste Automatizado",
                        Amount = 200m,
                        CompensationDate = new DateTime(DateTime.Now.Year, DateTime.Now.AddMonths(1).Month, DateTime.Now.Day)
                    },
                }
            };

            var response = safe2pay.Transfer.New(transfer);

            Assert.IsNotNull(response);

            Console.WriteLine(response.BankSlipUrl);
            Console.WriteLine(response.DigitableLine);
            Console.WriteLine(response.DueDate);
            Console.WriteLine(response.BankSlipNumber);
            Console.WriteLine(response.Description);
            Console.WriteLine(response.Message);
        }

        [Test]
        public void Detail_Transfer()
        {
            var response = safe2pay.Transfer.Detail(297070);

            Assert.IsNotNull(response);

            Console.WriteLine(response.ReceiverName);
            Console.WriteLine(response.Identity);
            Console.WriteLine(response.Amount);
            Console.WriteLine(response.Identification);
            Console.WriteLine(response.IsTransferred);
            Console.WriteLine(response.HashConfirmation);
            Console.WriteLine(response.CreatedDate);
            Console.WriteLine(response.CompensationDate);
            Console.WriteLine(response.HashConfirmation);
            Console.WriteLine(response.HashConfirmation);
            Console.WriteLine(response.HashConfirmation);
        }

        [Test]
        public void List_Transfers()
        {
            var response = safe2pay.Transfer.List();

            Assert.IsNotNull(response);

            foreach (var item in response)
            {
                Console.WriteLine(item.ReceiverName);
                Console.WriteLine(item.Identity);
                Console.WriteLine(item.Amount);
                Console.WriteLine(item.Identification);
                Console.WriteLine(item.IsTransferred);
                Console.WriteLine(item.HashConfirmation);
                Console.WriteLine(item.CreatedDate);
                Console.WriteLine(item.CompensationDate);
                Console.WriteLine(item.HashConfirmation);
                Console.WriteLine(item.HashConfirmation);
                Console.WriteLine(item.HashConfirmation);
            }
        }

        [Test]
        public void List_Transfer_Lot()
        {
            var response = safe2pay.Transfer.ListLot(
                new DateTime(DateTime.Now.Year, DateTime.Now.AddMonths(-1).Month, DateTime.Now.Day),
                new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day), 1, 100);

            Assert.IsNotNull(response);

            foreach (var item in response)
            {
                Console.WriteLine(item.AmountLot);
                Console.WriteLine(item.AmountTax);
                Console.WriteLine(item.CreatedDate);
                Console.WriteLine(item.BankSlipUrl);
            }
        }

        public static string RandomCNPJ()
        {
            var random = new Random();
            var n1 = random.Next(0, 10);
            var n2 = random.Next(0, 10);
            var n3 = random.Next(0, 10);
            var n4 = random.Next(0, 10);
            var n5 = random.Next(0, 10);
            var n6 = random.Next(0, 10);
            var n7 = random.Next(0, 10);
            var n8 = random.Next(0, 10);
            const int n9 = 0;
            const int n10 = 0;
            const int n11 = 0;
            const int n12 = 1;

            var sum1 = n1 * 5 + n2 * 4 + n3 * 3 + n4 * 2 + n5 * 9 + n6 * 8 + n7 * 7 + n8 * 6 + n9 * 5 + n10 * 4 +
                       n11 * 3 + n12 * 2;
            var vd1 = sum1 % 11;

            vd1 = vd1 < 2 ? 0 : 11 - vd1;

            var sum2 = n1 * 6 + n2 * 5 + n3 * 4 + n4 * 3 + n5 * 2 + n6 * 9 + n7 * 8 + n8 * 7 + n9 * 6 + n10 * 5 +
                       n11 * 4 + n12 * 3 + vd1 * 2;
            var vd2 = sum2 % 11;
            vd2 = vd2 < 2 ? 0 : 11 - vd2;

            return n1.ToString() + n2 + n3 + n4 + n5 + n6 + n7 + n8 + n9 + n10 + n11 + n12 + vd1 + vd2;
        }

        public static string RandomCPF()
        {
            var sum = 0;
            var multiplier1 = new[] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            var multiplier2 = new[] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            var random = new Random();
            var seed = random.Next(100000000, 999999999).ToString();

            for (var i = 0; i < 9; i++) sum += int.Parse(seed[i].ToString()) * multiplier1[i];

            var rest = sum % 11;
            rest = rest < 2 ? 0 : 11 - rest;

            seed += rest;
            sum = 0;

            for (var i = 0; i < 10; i++) sum += int.Parse(seed[i].ToString()) * multiplier2[i];

            rest = sum % 11;
            rest = rest < 2 ? 0 : 11 - rest;
            seed += rest;

            return seed;
        }
    }
}