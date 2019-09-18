using Safe2Pay.Core;
using Safe2Pay.Models;
using Safe2Pay.Response;

namespace Safe2Pay.Request
{
    public class CheckoutRequest
    {
        private Client Client { get; }

        /// <summary>
        /// Construtor para as funções de Transação..
        /// </summary>
        /// <param name="config">Dados de autenticação na API.</param>
        public CheckoutRequest(Config config) => Client = new Client(config);

        /// <summary>
        /// Geração de uma transação por Boleto Bancário.
        /// </summary>
        /// <param name="transaction">Objeto com base na classe Transaction, do tipo BankSlip.</param>
        /// <returns></returns>
        public BankSlipResponse BankSlip(Transaction<BankSlip> transaction)
        {
            return Client.Post<BankSlipResponse>(true, "v2/Payment", transaction).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Geração de uma transação por Boleto Bancário.
        /// </summary>
        /// <param name="transaction">Objeto com base na classe Transaction, do tipo CreditCard.</param>
        /// <returns></returns>
        public CreditCardResponse Credit(Transaction<CreditCard> transaction)
        {
            return Client.Post<CreditCardResponse>(true, "v2/Payment", transaction).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Geração de uma transação por Boleto Bancário.
        /// </summary>
        /// <param name="transaction">Objeto com base na classe Transaction, do tipo CryptoCoin.</param>
        /// <returns></returns>
        public CryptoCurrencyResponse CryptoCurrency(Transaction<CryptoCoin> transaction)
        {
            return Client.Post<CryptoCurrencyResponse>(true, "v2/Payment", transaction).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Geração de uma transação por Boleto Bancário.
        /// </summary>
        /// <param name="transaction">Objeto com base na classe Transaction, do tipo DebitCard.</param>
        /// <returns></returns>
        public DebitCardResponse Debit(Transaction<DebitCard> transaction)
        {
            return Client.Post<DebitCardResponse>(true, "v2/Payment", transaction).GetAwaiter().GetResult();
        }
    }
}