using System;
using System.Collections.Generic;
using NUnit.Framework;
using Safe2Pay.Models;

namespace Safe2Pay.Tests
{
    [TestFixture]
    public class MarketplaceTests
    {
        private static readonly Safe2Pay_Request safe2pay = new Safe2Pay_Request("TOKEN", "SECRET", 30);

        [Test]
        public void New()
        {
            var merchant = new Merchant
            {
                Name = "Empresa de Teste Ltda.",
                Identity = RandomCNPJ(),
                CommercialName = "Teste",
                ResponsibleName = "Titular da Empresa de Teste",
                ResponsibleIdentity = RandomCPF(),
                Email = "email@empresa.com.br",
                Address = new Address
                {
                    ZipCode = "91340-480",
                    Street = "Rua Tomaz Gonzaga",
                    Number = "481",
                    District = "Três Figueiras",
                    StateInitials = "RS",
                    CityName = "Porto Alegre",
                    CountryName = "Brasil"
                },
                BankData = new BankData
                {
                    Bank = new Bank { Code = "001" },
                    BankAgency = "1234",
                    BankAgencyDigit = "5",
                    BankAccount = "5432",
                    BankAccountDigit = "1",
                    Operation = "003"
                },
                MerchantSplit = new List<MerchantSplit>
                {
                    new MerchantSplit
                    {
                        PaymentMethodCode = "1", 
                        IsSubaccountTaxPayer = true,
                        Taxes = new List<MerchantSplitTax> 
                        {
                            new MerchantSplitTax { Tax = 1m, TaxTypeName = EnumTaxType.Percentage }
                        }
                    },
                    new MerchantSplit
                    {
                        PaymentMethodCode = "2", 
                        IsSubaccountTaxPayer = false,
                        Taxes = new List<MerchantSplitTax>
                        {
                            new MerchantSplitTax { Tax = 2m, TaxTypeName = EnumTaxType.Percentage }
                        }
                    },
                    new MerchantSplit
                    {
                        PaymentMethodCode = "3", 
                        IsSubaccountTaxPayer = true,
                        Taxes = new List<MerchantSplitTax>
                        {
                            new MerchantSplitTax { Tax = 3m, TaxTypeName = EnumTaxType.Percentage }
                        }
                    },
                    new MerchantSplit
                    {
                        PaymentMethodCode = "4", 
                        IsSubaccountTaxPayer = false,
                        Taxes = new List<MerchantSplitTax>
                        {
                            new MerchantSplitTax { Tax = 4m, TaxTypeName = EnumTaxType.Percentage }
                        }
                    }
                }
            };

            var response = safe2pay.Marketplace.New(merchant);

            Assert.NotNull(response);

            Console.WriteLine(response.Id);
            Console.WriteLine(response.Name);
            Console.WriteLine(response.Identity);
            Console.WriteLine(response.Token);
        }

        [Test]
        public void Get()
        {
            var response = safe2pay.Marketplace.Get(4133);

            Assert.NotNull(response);

            Console.WriteLine(response.Id);
            Console.WriteLine(response.Identity);
            Console.WriteLine(response.Name);
            Console.WriteLine(response.CommercialName);
            Console.WriteLine(response.ResponsibleName);
            Console.WriteLine(response.ResponsibleIdentity);
            Console.WriteLine(response.Integration.Token);
            Console.WriteLine(response.Integration.TokenSandbox);
            Console.WriteLine(response.Integration.SecretKey);
            Console.WriteLine(response.Integration.SecretKeySandbox);
            Console.WriteLine(response.BankData.Bank);
            Console.WriteLine(response.BankData.Agency);
            Console.WriteLine(response.BankData.AgencyDigit);
            Console.WriteLine(response.BankData.Account);
            Console.WriteLine(response.BankData.AccountDigit);
            Console.WriteLine(response.BankData.Operation);
            Console.WriteLine(response.Address.ZipCode);
            Console.WriteLine(response.Address.Street);
            Console.WriteLine(response.Address.Number);
            Console.WriteLine(response.Address.Complement);
            Console.WriteLine(response.Address.District);
            Console.WriteLine(response.Address.City);
            Console.WriteLine(response.Address.State);
            Console.WriteLine(response.Address.Country);
            
            Console.WriteLine(response.PaymentMethods.Count);

            foreach (var items in response.PaymentMethods)
            {
                Console.WriteLine(" --- ");
                
                Console.WriteLine(items.PaymentMethod);
                Console.WriteLine(items.IsPayTax);

                foreach (var taxes in items.Taxes)
                {
                    Console.WriteLine(" --- ");
                
                    Console.WriteLine(taxes.TaxType);
                    Console.WriteLine(taxes.Tax);
                
                    Console.WriteLine(" --- ");
                }
                
                Console.WriteLine(" --- ");
            }
        }

        [Test]
        public void Update()
        {
            var merchant = new Merchant
            {
                Name = "Empresa de Teste Ltda.",
                Identity = RandomCNPJ(),
                CommercialName = "Teste",
                ResponsibleName = "Titular da Empresa de Teste",
                ResponsibleIdentity = RandomCPF(),
                Email = "email@empresa.com.br",
                Address = new Address
                {
                    ZipCode = "91340-480",
                    Street = "Rua Tomaz Gonzaga",
                    Number = "481",
                    District = "Três Figueiras",
                    StateInitials = "RS",
                    CityName = "Porto Alegre",
                    CountryName = "Brasil"
                },
                BankData = new BankData
                {
                    Bank = new Bank { Code = "001" },
                    BankAgency = "1234",
                    BankAgencyDigit = "5",
                    BankAccount = "5432",
                    BankAccountDigit = "1",
                    Operation = "003"
                },
                MerchantSplit = new List<MerchantSplit>
                {
                    new MerchantSplit
                    {
                        PaymentMethodCode = "1", 
                        IsSubaccountTaxPayer = true,
                        Taxes = new List<MerchantSplitTax> 
                        {
                            new MerchantSplitTax { Tax = 1m, TaxTypeName = EnumTaxType.Percentage }
                        }
                    },
                    new MerchantSplit
                    {
                        PaymentMethodCode = "2", 
                        IsSubaccountTaxPayer = false,
                        Taxes = new List<MerchantSplitTax>
                        {
                            new MerchantSplitTax { Tax = 2m, TaxTypeName = EnumTaxType.Percentage }
                        }
                    },
                    new MerchantSplit
                    {
                        PaymentMethodCode = "3", 
                        IsSubaccountTaxPayer = true,
                        Taxes = new List<MerchantSplitTax>
                        {
                            new MerchantSplitTax { Tax = 3m, TaxTypeName = EnumTaxType.Percentage }
                        }
                    },
                    new MerchantSplit
                    {
                        PaymentMethodCode = "4", 
                        IsSubaccountTaxPayer = false,
                        Taxes = new List<MerchantSplitTax>
                        {
                            new MerchantSplitTax { Tax = 4m, TaxTypeName = EnumTaxType.Percentage }
                        }
                    }
                }
            };

            var response = safe2pay.Marketplace.Update(merchant, 4133);

            Assert.NotNull(response);

            Console.WriteLine(response.Id);
            Console.WriteLine(response.Name);
            Console.WriteLine(response.Identity);
            Console.WriteLine(response.Token);
        }

        [Test]
        public void Delete()
        {
            var response = safe2pay.Marketplace.Delete(4133);

            Assert.NotNull(response);
            Assert.IsTrue(response);
        }

        [Test]
        public void List()
        {
            var response = safe2pay.Marketplace.List();

            foreach (var items in response)
            {
                Console.WriteLine(" --- ");
                
                Console.WriteLine(items.Name);
                Console.WriteLine(items.Identity);
                Console.WriteLine(items.ResponsibleName);
                Console.WriteLine(items.ResponsibleIdentity);
                //...
                
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