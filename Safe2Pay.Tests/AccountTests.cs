using System;
using NUnit.Framework;

namespace Safe2Pay.Tests
{
    [TestFixture]
    public class AccountTests
    {
        private static readonly Safe2Pay safe2pay = new Safe2Pay("TOKEN", "SECRET", 30);

        [Test]
        [Description("Consultar dados bancários.")]
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
        [Description("Consultar saldo de recebíveis.")]
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
        [Description("Consultar saldo de recebíveis disponíveis para antecipação.")]
        public void Advance_Payment_Simulation()
        {
            var response = safe2pay.Account.AdvancePaymentSimulation();

            Assert.IsNotNull(response);

            Console.WriteLine(response.AmountReceivables);
            Console.WriteLine(response.AmountNetReceivables);
            Console.WriteLine(response.Tax);
            Console.WriteLine(response.Items.Count);

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
        [Description("Solicitar antecipação de recebíveis.")]
        public void Advance_Payment_Request()
        {
            var response = safe2pay.Account.AdvancePaymentRequest();

            Assert.IsNotNull(response);
            Assert.That(response.Message == "Antecipação efetuada com sucesso.");

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
        [Description("Listar depósitos realizados e futuros no mês corrente.")]
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
        [Description("Detalhar depósito diário.")]
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