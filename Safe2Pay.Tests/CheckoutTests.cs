using System;
using System.Collections.Generic;
using NUnit.Framework;
using Safe2Pay.Models;
using Safe2Pay.Models.Payment;

namespace Safe2Pay.Tests
{
    [TestFixture]
    public class CheckoutTests
    {
        private static readonly Safe2Pay_Request safe2pay = new Safe2Pay_Request("TOKEN", "SECRET", 30);

        [Test]
        public void Bank_Slip()
        {
            var transaction = new Transaction<BankSlip>
            {
                IsSandbox = false,

                CallbackUrl = "http://url.de.callback.com/",
                Application = "Teste",
                Vendor = "Vendedor",
                Reference = "safe2pay-dotnet",
                Customer = new Customer
                {
                    Name = "Cliente de Teste",
                    Identity = RandomCNPJ(),
                    Email = "email@provedor.com.br",
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
                    new Product { Code = "001", Description = "Produto 1", UnitPrice = 10M, Quantity = 1M },
                    new Product { Code = "002", Description = "Produto 2", UnitPrice = 20M, Quantity = 1M },
                    new Product { Code = "003", Description = "Produto 3", UnitPrice = 30M, Quantity = 1M }
                },
                PaymentMethod = new PaymentMethod { Code = "1" },
                PaymentObject = new BankSlip
                {
                    DueDate = new DateTime(DateTime.Now.Year, DateTime.Now.AddMonths(1).Month, DateTime.Now.Day),
                    CancelAfterDue = true,
                    IsEnablePartialPayment = false,
                    //DaysBeforeCancel = 15,
                    DiscountAmount = 1m,
                    DiscountType = 3,
                    DiscountDue = new DateTime(DateTime.Now.Year, DateTime.Now.AddMonths(1).Month, DateTime.Now.Day),
                    PenaltyRate = 1m, //Multa
                    InterestRate = 2m, //Juros
                    Message = new List<string> { "Teste 1", "Teste 2", "Teste 3" },
                    Instruction = "Teste de Instrução"
                }
            };

            var response = safe2pay.Payment.BankSlip(transaction);

            Assert.NotNull(response);

            Console.WriteLine(response.IdTransaction);
            Console.WriteLine(response.Status);
            Console.WriteLine(response.Message);
            Console.WriteLine(response.Description);
            Console.WriteLine(response.BankSlipNumber);
            Console.WriteLine(response.DueDate);
            Console.WriteLine(response.DigitableLine);
            Console.WriteLine(response.Barcode);
            Console.WriteLine(response.BankSlipUrl);
            Console.WriteLine(response.OperationDate);
            Console.WriteLine(response.BankName);
            Console.WriteLine(response.CodeBank);
            Console.WriteLine(response.Wallet);
            Console.WriteLine(response.WalletDescription);
            Console.WriteLine(response.Agency);
            Console.WriteLine(response.Account);
            Console.WriteLine(response.CodeAssignor);
            Console.WriteLine(response.AgencyDV);
            Console.WriteLine(response.AccountDV);
            Console.WriteLine(response.DocType);
            Console.WriteLine(response.Accept);
            Console.WriteLine(response.Currency);
            Console.WriteLine(response.GuarantorName);
            Console.WriteLine(response.GuarantorIdentity);
        }

        [Test]
        public void Credit_Card()
        {
            var transaction = new Transaction<CreditCard>
            {
                IsSandbox = false,

                CallbackUrl = "http://url.de.callback.com/",
                Application = "Nome da Aplicação",
                Vendor = "Vendedor",
                Reference = "safe2pay-dotnet",
                Customer = new Customer
                {
                    Name = "Cliente de Teste",
                    Identity = RandomCNPJ(),
                    Email = "email@provedor.com.br",
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
                    new Product { Code = "001", Description = "Produto 1", UnitPrice = 100M, Quantity = 1M },
                    new Product { Code = "002", Description = "Produto 2", UnitPrice = 20M, Quantity = 1M },
                    new Product { Code = "003", Description = "Produto 3", UnitPrice = 30M, Quantity = 1M }
                },
                PaymentMethod = new PaymentMethod { Code = "2" },
                PaymentObject = new CreditCard
                {
                    CardNumber = "4111111111111111",
                    Holder = "Cliente de Teste",
                    ExpirationDate = "03/2020",
                    SecurityCode = "999",
                    InstallmentQuantity = 2
                }
            };

            var response = safe2pay.Payment.Credit(transaction);

            Assert.NotNull(response);

            Console.WriteLine(response.IdTransaction);
            Console.WriteLine(response.Token);
            Console.WriteLine(response.Description);
            if (response.Status == 3) Console.WriteLine("Autorizado!");
            Console.WriteLine(response.Message);
            Console.WriteLine(response.CreditCard.CardNumber);
            Console.WriteLine(response.CreditCard.Brand);
            Console.WriteLine(response.CreditCard.Installments);
        }

        [Test]
        public void Credit_Card_Tokenized()
        {
            var card = new CreditCard
            {
                CardNumber = "4111111111111111",
                Holder = "Cliente de Teste",
                ExpirationDate = "03/2020",
                SecurityCode = "999"
            };

            var token = safe2pay.Token.Tokenize(card);

            Assert.NotNull(token);

            Console.WriteLine($"Token '{token.Token}' gerado com sucesso!");
            Console.WriteLine($"Bandeira '{token.Brand}'!");

            var transaction = new Transaction<CreditCard>
            {
                IsSandbox = true,

                CallbackUrl = "http://url.de.callback.com/",
                Application = "Nome da Aplicação",
                Vendor = "Vendedor",
                Reference = "safe2pay-dotnet",
                Customer = new Customer
                {
                    Name = "Cliente de Teste",
                    Identity = RandomCNPJ(),
                    Email = "email@provedor.com.br",
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
                    new Product { Code = "001", Description = "Produto 1", UnitPrice = 10M, Quantity = 1M },
                    new Product { Code = "002", Description = "Produto 2", UnitPrice = 20M, Quantity = 1M },
                    new Product { Code = "003", Description = "Produto 3", UnitPrice = 30M, Quantity = 1M }
                },
                PaymentMethod = new PaymentMethod { Code = "2" },
                PaymentObject = new CreditCard { Token = token.Token }
            };

            var response = safe2pay.Payment.Credit(transaction);

            Assert.NotNull(response);

            Console.WriteLine(response.IdTransaction);
            Console.WriteLine(response.Token);
            Console.WriteLine(response.Description);
            if (response.Status == 3) Console.WriteLine("Autorizado!");
            Console.WriteLine(response.Message);
            Console.WriteLine(response.CreditCard.CardNumber);
            Console.WriteLine(response.CreditCard.Brand);
            Console.WriteLine(response.CreditCard.Installments);
        }

        [Test]
        public void Crypto_Currency()
        {
            var transaction = new Transaction<CryptoCoin>
            {
                IsSandbox = true,

                CallbackUrl = "http://url.de.callback.com/",
                Application = "Nome da Aplicação",
                Vendor = "Vendedor",
                Reference = "safe2pay-dotnet",
                Customer = new Customer
                {
                    Name = "Cliente de Teste",
                    Identity = RandomCNPJ(),
                    Email = "email@provedor.com.br",
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
                    new Product { Code = "001", Description = "Produto 1", UnitPrice = 10M, Quantity = 1M },
                    new Product { Code = "002", Description = "Produto 2", UnitPrice = 20M, Quantity = 1M },
                    new Product { Code = "003", Description = "Produto 3", UnitPrice = 30M, Quantity = 1M }
                },
                PaymentMethod = new PaymentMethod { Code = "3" }
            };

            var response = safe2pay.Payment.CryptoCurrency(transaction);

            Assert.NotNull(response);

            Console.WriteLine(response.IdTransaction);
            Console.WriteLine(response.Status);
            Console.WriteLine(response.Message);
            Console.WriteLine(response.Description);
            Console.WriteLine(response.QrCode);
            Console.WriteLine(response.Symbol);
            Console.WriteLine(response.AmountBTC);
            Console.WriteLine(response.WalletAddress);
        }

        [Test]
        public void Debit_Card()
        {
            var transaction = new Transaction<DebitCard>
            {
                IsSandbox = true,

                CallbackUrl = "http://url.de.callback.com/",
                Application = "Nome da Aplicação",
                Vendor = "Vendedor",
                Reference = "safe2pay-dotnet",
                Customer = new Customer
                {
                    Name = "Cliente de Teste",
                    Identity = RandomCNPJ(),
                    Email = "email@provedor.com.br",
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
                    new Product { Code = "001", Description = "Produto 1", UnitPrice = 10M, Quantity = 1M },
                    new Product { Code = "002", Description = "Produto 2", UnitPrice = 20M, Quantity = 1M },
                    new Product { Code = "003", Description = "Produto 3", UnitPrice = 30M, Quantity = 1M }
                },
                PaymentMethod = new PaymentMethod { Code = "4" },
                PaymentObject = new DebitCard
                {
                    CardNumber = "4111111111111111",
                    Holder = "Cliente de Teste",
                    ExpirationDate = "03/2020",
                    SecurityCode = "999"
                }
            };

            var response = safe2pay.Payment.Debit(transaction);

            Assert.NotNull(response);

            Console.WriteLine(response.IdTransaction);
            Console.WriteLine(response.Token);
            Console.WriteLine(response.Description);
            Console.WriteLine(response.Status);
            Console.WriteLine(response.Message);
            Console.WriteLine(response.AuthenticationUrl);
            Console.WriteLine(response.DebitCard.CardNumber);
            Console.WriteLine(response.DebitCard.Brand);
        }
        [Test]
        public void Pix()
        {
            var transaction = new Transaction<Pix>
            {
                IsSandbox = false,

                CallbackUrl = "http://url.de.callback.com/",
                Application = "Nome da Aplicação",
                Vendor = "Vendedor",
                Reference = "safe2pay-dotnet",
                Customer = new Customer
                {
                    Name = "Cliente de Teste",
                    Identity = "04040761065",
                    Email = "email@provedor.com.br",
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
                    new Product { Code = "001", Description = "Produto 1", UnitPrice = 10M, Quantity = 1M },
                    new Product { Code = "002", Description = "Produto 2", UnitPrice = 20M, Quantity = 1M },
                    new Product { Code = "003", Description = "Produto 3", UnitPrice = 30M, Quantity = 1M }
                },
                PaymentMethod = new PaymentMethod { Code = "6" },

                PaymentObject = new Pix
                {
                    Expiration = 3600
                }
            };

            var response = safe2pay.Payment.Pix(transaction);

            Assert.NotNull(response);

            Console.WriteLine(response.IdTransaction);
            Console.WriteLine(response.Status);
            Console.WriteLine(response.Message);
            Console.WriteLine(response.Description);
            Console.WriteLine(response.QrCode);
            Console.WriteLine(response.Key);
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