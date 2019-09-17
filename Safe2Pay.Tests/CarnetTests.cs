using System;
using System.Collections.Generic;
using NUnit.Framework;
using Safe2Pay.Models;

namespace Safe2Pay.Tests
{
    [TestFixture]
    public class CarnetTests
    {
        private static readonly Safe2Pay safe2pay = new Safe2Pay("TOKEN", "SECRET", 30);

        [Test]
        public void New_Carnet()
        {
            var transaction = new Transaction<Carnet>
            {
                IsSandbox = true,

                CallbackUrl = "http://url.de.callback.com/",
                Application = "Teste",
                Vendor = "Vendedor",
                Reference = "safe2pay-dotnet",
                Customer = new Customer
                {
                    Name = "CLIENTE DE TESTE",
                    Identity = RandomCNPJ(),
                    Email = "cliente@provedor.com.br",
                    Phone = "51 99999 9999",
                    Address = new Address
                    {
                        Street = "Rua Tomaz Gonzaga",
                        Number = "481",
                        District = "Três Figueiras",
                        ZipCode = "91340-480",
                        CityName = "Porto Alegre",
                        StateInitials = "RS",
                        CountryName = "Brasil"
                    }
                },
                Products = new List<Product>
                {
                    new Product {Code = "001", Description = "Produto 1", UnitPrice = 1.99M, Quantity = 1M},
                    new Product {Code = "002", Description = "Produto 2", UnitPrice = 2.99M, Quantity = 2M},
                    new Product {Code = "003", Description = "Produto 3", UnitPrice = 3.99M, Quantity = 3M}
                },
                PaymentMethod = new PaymentMethod { Code = "1" },
                PaymentObject = new Carnet
                {
                    BankSlips = new List<BankSlip>
                    {
                        new BankSlip
                        {
                            Amount = 1.99M,
                            DueDate = new DateTime(DateTime.Now.Year, DateTime.Now.AddMonths(1).Month, DateTime.Now.Day),
                            Message = new List<string> {"Boleto 1"}
                        },
                        new BankSlip
                        {
                            Amount = 1.99M,
                            DueDate = new DateTime(DateTime.Now.Year, DateTime.Now.AddMonths(2).Month, DateTime.Now.Day),
                            Message = new List<string> {"Boleto 2"}
                        },
                        new BankSlip
                        {
                            Amount = 1.99M,
                            DueDate = new DateTime(DateTime.Now.Year, DateTime.Now.AddMonths(3).Month, DateTime.Now.Day),
                            Message = new List<string> {"Boleto 3"}
                        }
                    },
                    IsEnablePartialPayment = false,
                    PayableAfterDue = false,
                    PenaltyAmount = 10m, //Multa
                    InterestAmount = 10m, //Juros
                    Reference = "Referência",
                    Message = "Teste"
                }
            };

            var response = safe2pay.Carnet.New(transaction);

            Assert.IsNotNull(response);

            Console.WriteLine(response.CarnetUrl);
            Console.WriteLine(response.Identifier);
            Console.WriteLine(response.BankSlips.Count);

            foreach (var items in response.BankSlips)
            {
                Console.WriteLine(" --- ");

                Console.WriteLine(items.IdTransaction);
                Console.WriteLine(items.Status);
                Console.WriteLine(items.Message);
                Console.WriteLine(items.Description);
                Console.WriteLine(items.BankSlipNumber);
                Console.WriteLine(items.DueDate);
                Console.WriteLine(items.DigitableLine);
                Console.WriteLine(items.Barcode);
                Console.WriteLine(items.BankSlipUrl);

                Console.WriteLine(" --- ");
            }
        }

        [Test]
        public void Cancel_Carnet()
        {
            var response = safe2pay.Carnet.Cancel("edfe413abb6044d4b5acf7e0b1e7b371");

            Assert.IsNotNull(response);

            Console.WriteLine(response.BankSlips.Count);

            foreach (var items in response.BankSlips)
            {
                Console.WriteLine(" --- ");

                Assert.IsTrue(items.isCancelled);
                
                Console.WriteLine(items.IdTransaction);
                Console.WriteLine(items.BankSlipNumber);
                Console.WriteLine(items.Message);

                Console.WriteLine(" --- ");
            }
        }

        [Test]
        public void Resend_Carnet()
        {
            var response = safe2pay.Carnet.Resend("7b358eb2769e4f009cea79c7ee52de04");

            Assert.IsNotNull(response);
            Assert.IsTrue(response);
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
    }
}