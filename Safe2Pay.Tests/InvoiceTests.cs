using System;
using System.Collections.Generic;
using NUnit.Framework;
using Safe2Pay.Models;

namespace Safe2Pay.Tests
{
    [TestFixture]
    public class InvoiceTests
    {
        private static readonly Safe2Pay safe2pay = new Safe2Pay("TOKEN", "SECRET", 30);

        [Test]
        public void New()
        {
            var sale = new SingleSale
            {
                CallbackUrl = "http://url.de.callback.com/",

                Customer = new Customer
                {
                    Name = "Cliente de Teste",
                    Identity = RandomCNPJ(),
                    Email = "email@cliente.com.br",
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
                    new Product { Code = "001", Description = "Teste 1", UnitPrice = 150.99M, Quantity = 1M },
                    new Product { Code = "002", Description = "Teste 2", UnitPrice = 20.99M, Quantity = 2M },
                    new Product { Code = "003", Description = "Teste 3", UnitPrice = 30.99M, Quantity = 3M }
                },
                DueDate = new DateTime(DateTime.Now.Year, DateTime.Now.AddMonths(1).Month, 1),
                ExpirationDate = new DateTime(DateTime.Now.Year, DateTime.Now.AddMonths(1).Month, 1),
                DiscountAmount = 50m,
                InterestAmount = 2,
                PenaltyAmount = 3,
                Instruction = "Pagar hoje!",
                PaymentMethods = new List<PaymentMethod>
                {
                    new PaymentMethod { CodePaymentMethod = "1" },
                    new PaymentMethod { CodePaymentMethod = "2" },
                    new PaymentMethod { CodePaymentMethod = "3" },
                    new PaymentMethod { CodePaymentMethod = "4" }
                },
                Messages = new List<string> { "Mensagem 1", "Mensagem 2" },
                Emails = new List<string> { "email1@provedor1.com", "email2@provedor2.com.br" }
            };

            var response = safe2pay.Invoice.New(sale);

            Assert.NotNull(response);

            Console.WriteLine(response.SingleSaleHash);
            Console.WriteLine(response.SingleSaleUrl);
            Console.WriteLine(response.DueDate);
            Console.WriteLine(response.ExpirationDate);
            Console.WriteLine(response.Amount);
            Console.WriteLine(response.CreatedDate);
            Console.WriteLine(response.CallbackUrl);
            Console.WriteLine(response.Status);
            Console.WriteLine(response.IsApplyPenalty);
            Console.WriteLine(response.PenaltyAmount);
            Console.WriteLine(response.IsApplyInterest);
            Console.WriteLine(response.InterestAmount);
            Console.WriteLine(response.DiscountAmount);
            Console.WriteLine(response.BankSlipUrl);
            
            Console.WriteLine(response.Products.Count);

            foreach (var products in response.Products)
            {
                Console.WriteLine(" --- ");

                Console.WriteLine(products.Description);
                Console.WriteLine(products.Quantity);
                Console.WriteLine(products.UnitPrice);

                Console.WriteLine(" --- ");
            }

            Console.WriteLine(response.Emails.Count);

            foreach (var emails in response.Emails)
                Console.WriteLine(emails);

            Console.WriteLine(response.Customer.Name);
            Console.WriteLine(response.Customer.Identity);
            Console.WriteLine(response.Customer.Email);
            Console.WriteLine(response.Customer.Phone);
            Console.WriteLine(response.Customer.Address.ZipCode);
            Console.WriteLine(response.Customer.Address.Street);
            Console.WriteLine(response.Customer.Address.Number);
            Console.WriteLine(response.Customer.Address.Complement);
            Console.WriteLine(response.Customer.Address.District);
            Console.WriteLine(response.Customer.Address.State);
            Console.WriteLine(response.Customer.Address.City);
            Console.WriteLine(response.Customer.Address.Country);
        }

        [Test]
        public void Get()
        {
            var response = safe2pay.Invoice.Get("9ec07ee37b934f8c98f5978a69b4f818");

            Assert.NotNull(response);

            Console.WriteLine(response.SingleSaleHash);
            Console.WriteLine(response.SingleSaleUrl);
            Console.WriteLine(response.DueDate);
            Console.WriteLine(response.ExpirationDate);
            Console.WriteLine(response.Amount);
            Console.WriteLine(response.CreatedDate);
            Console.WriteLine(response.Status);
            Console.WriteLine(response.IsApplyPenalty);
            Console.WriteLine(response.PenaltyAmount);
            Console.WriteLine(response.IsApplyInterest);
            Console.WriteLine(response.InterestAmount);
            Console.WriteLine(response.DiscountAmount);
            Console.WriteLine(response.BankSlipUrl);
            
            Console.WriteLine(response.Products.Count);

            foreach (var products in response.Products)
            {
                Console.WriteLine(" --- ");

                Console.WriteLine(products.Description);
                Console.WriteLine(products.Quantity);
                Console.WriteLine(products.UnitPrice);

                Console.WriteLine(" --- ");
            }

            Console.WriteLine(response.Emails.Count);

            foreach (var emails in response.Emails)
                Console.WriteLine(emails);

            Console.WriteLine(response.Customer.Name);
            Console.WriteLine(response.Customer.Identity);
            Console.WriteLine(response.Customer.Email);
            Console.WriteLine(response.Customer.Phone);
            Console.WriteLine(response.Customer.Address.ZipCode);
            Console.WriteLine(response.Customer.Address.Street);
            Console.WriteLine(response.Customer.Address.Number);
            Console.WriteLine(response.Customer.Address.Complement);
            Console.WriteLine(response.Customer.Address.District);
            Console.WriteLine(response.Customer.Address.State);
            Console.WriteLine(response.Customer.Address.City);
            Console.WriteLine(response.Customer.Address.Country);
        }

        [Test]
        public void Resend()
        {
            var response = safe2pay.Invoice.Resend("96c073441a054b64857acdce0ef31584");

            Assert.NotNull(response);
            Assert.IsTrue(response);
        }

        [Test]
        public void Cancel()
        {
            var response = safe2pay.Invoice.Cancel("ddf06ba2071a44f6b1a642f1fd66b9be");

            Assert.NotNull(response);
            Assert.IsTrue(response);
        }

        [Test]
        public void Replace()
        {
            var sale = new SingleSale
            {
                CallbackUrl = "http://url.de.callback.com/",

                Customer = new Customer
                {
                    Name = "Cliente de Teste",
                    Identity = RandomCNPJ(),
                    Email = "email@cliente.com.br",
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
                    new Product { Code = "001", Description = "Teste 1", UnitPrice = 150.99M, Quantity = 1M },
                    new Product { Code = "002", Description = "Teste 2", UnitPrice = 20.99M, Quantity = 2M },
                    new Product { Code = "003", Description = "Teste 3", UnitPrice = 30.99M, Quantity = 3M }
                },
                DueDate = new DateTime(DateTime.Now.Year, DateTime.Now.AddMonths(1).Month, 1),
                ExpirationDate = new DateTime(DateTime.Now.Year, DateTime.Now.AddMonths(1).Month, 1),
                DiscountAmount = 50m,
                InterestAmount = 2,
                PenaltyAmount = 3,
                Instruction = "Pagar hoje!",
                PaymentMethods = new List<PaymentMethod>
                {
                    new PaymentMethod { CodePaymentMethod = "1" },
                    new PaymentMethod { CodePaymentMethod = "2" },
                    new PaymentMethod { CodePaymentMethod = "3" },
                    new PaymentMethod { CodePaymentMethod = "4" }
                },
                Messages = new List<string> { "Mensagem 1", "Mensagem 2" },
                Emails = new List<string> { "email1@provedor1.com", "email2@provedor2.com.br" }
            };

            var response2 = safe2pay.Invoice.Replace(sale, "d2a7bab322f040639095f678066d2fdc");

            Assert.NotNull(response2);

            Console.WriteLine(response2.SingleSaleHash);
            Console.WriteLine(response2.SingleSaleUrl);
            //...
        }

        [Test]
        public void List()
        {
            var response = safe2pay.Invoice.List();

            Assert.NotNull(response);

            foreach (var items in response)
            {
                Console.WriteLine(" --- ");

                Console.WriteLine(items.Customer.Name);
                Console.WriteLine(items.Customer.Identity);
                Console.WriteLine(items.SingleSaleHash);
                Console.WriteLine(items.CreatedDate);
                Console.WriteLine(items.Amount);
                Console.WriteLine(items.Status);

                Console.WriteLine(" --- ");
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
    }
}