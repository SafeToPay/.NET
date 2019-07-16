using System;
using Newtonsoft.Json;
using Safe2Pay.Core;
using Safe2Pay.Models;

namespace Safe2Pay
{
    /// <summary>
    /// <para>Usada para a geração de novas transações.</para>
    /// Deve ser utilizada para o envio (POST) de um objeto com base nas opções de pagamento disponíveis:
    /// Boleto Bancário (1), Cartão de Crédito (2), BitCoin (3), Cartão de Débito (4) ou Transferência Bancária (5).
    /// </summary>
    public class Checkout
    {
        /// <summary>
        /// Construtor para as funções de pagamento
        /// </summary>
        /// <param name="config">Dados de autenticação</param>
        public Checkout(Config config) => Client = new Client().Create(true, config);

        private Client Client { get; set; }

        /// <summary>
        /// Método para gerar uma nova transação por Boleto Bancário.
        /// </summary>
        /// <param name="bankSlip">Objeto com base no modelo BankSlip, da classe Transaction.</param>
        /// <returns></returns>
        public object BankSlip(object bankSlip)
        {
            var response = Client.Post("Payment", bankSlip);

            var responseObj = JsonConvert.DeserializeObject<Response<CheckoutResponse>>(response);
            if (responseObj.HasError)
                throw new Exception($"Erro {responseObj.ErrorCode} - {responseObj.Error}");

            return responseObj.ResponseDetail;
        }

        /// <summary>
        /// Método para gerar uma nova transação por Carnê/Fatura.
        /// </summary>
        /// <param name="carnet">Objeto com base no modelo Carnet, da classe Transaction.</param>
        /// <returns></returns>
        public object Carnet(object carnet)
        {
            var response = Client.Post("Carnet", carnet);

            var responseObj = JsonConvert.DeserializeObject<Response<CheckoutResponse>>(response);
            if (responseObj.HasError)
                throw new Exception($"Erro {responseObj.ErrorCode} - {responseObj.Error}");

            return responseObj.ResponseDetail;
        }

        /// <summary>
        /// Método para gerar uma nova transação por Carnê/Fatura em lote.
        /// </summary>
        /// <param name="carnet">Objeto com base no modelo CarnetLot, da classe Transaction.</param>
        /// <returns></returns>
        public object CarnetLot(object carnet)
        {
            var transactionCompressed = Utils.Compress(Utils.Serialize(carnet));
            var carnetLot = new CarnetLot { JsonGzip = transactionCompressed };

            var response = Client.Post("CarnetAsync", carnetLot);
            //var objDecompressed = Utils.Decompress(response);

            var responseObj = JsonConvert.DeserializeObject<Response<CheckoutResponse>>(response);
            if (responseObj.HasError)
                throw new Exception($"Erro {responseObj.ErrorCode} - {responseObj.Error}");

            return responseObj.ResponseDetail;
        }

        /// <summary>
        /// Método para gerar uma nova transação por Cartão de Crédito.
        /// </summary>
        /// <param name="credit">Objeto com base no modelo CreditCard, da Transaction.</param>
        /// <returns></returns>
        public object Credit(object credit)
        {
            var response = Client.Post("Payment", credit);

            var responseObj = JsonConvert.DeserializeObject<Response<CheckoutResponse>>(response);
            if (responseObj.HasError)
                throw new Exception($"Erro {responseObj.ErrorCode} - {responseObj.Error}");

            return responseObj.ResponseDetail;
        }

        /// <summary>
        /// Método para tokenizar os dados de um cartão de crédito.
        /// </summary>
        /// <param name="card">Objeto com base no modelo CreditCard.</param>
        /// <returns></returns>
        public object Tokenize(object card)
        {
            var response = Client.Post("Token", card);

            var responseObj = JsonConvert.DeserializeObject<Response<CheckoutResponse>>(response);
            if (responseObj.HasError)
                throw new Exception($"Erro {responseObj.ErrorCode} - {responseObj.Error}");

            return responseObj.ResponseDetail;
        }

        /// <summary>
        /// Método para gerar uma nova transação por Cartão de Débito.
        /// </summary>
        /// <param name="debit">Objeto com base no modelo DebitCard, da Transaction.</param>
        /// <returns></returns>
        public object Debit(object debit)
        {
            var response = Client.Post("Payment", debit);

            var responseObj = JsonConvert.DeserializeObject<Response<CheckoutResponse>>(response);
            if (responseObj.HasError)
                throw new Exception($"Erro {responseObj.ErrorCode} - {responseObj.Error}");

            return responseObj.ResponseDetail;
        }

        /// <summary>
        /// Método para gerar uma nova transação por Bitcoin.
        /// </summary>
        /// <param name="bitcoin">Objeto com base no modelo Bitcoin, da Transaction.</param>
        /// <returns></returns>
        public object Bitcoin(object bitcoin)
        {
            var response = Client.Post("Payment", bitcoin);

            var responseObj = JsonConvert.DeserializeObject<Response<CheckoutResponse>>(response);
            if (responseObj.HasError)
                throw new Exception($"Erro {responseObj.ErrorCode} - {responseObj.Error}");

            return responseObj.ResponseDetail;
        }
    }
}