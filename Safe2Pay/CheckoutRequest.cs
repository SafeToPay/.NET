using System;
using Newtonsoft.Json;
using Safe2Pay.Core;
using Safe2Pay.Models;

namespace Safe2Pay
{
    public class CheckoutRequest
    {
        private Client Client { get; }

        /// <summary>
        /// Construtor para as funções de Transação..
        /// </summary>
        /// <param name="config">Dados de autenticação na API.</param>
        public CheckoutRequest(Config config) => Client = new Client().Create(true, config);

        /// <summary>
        /// Geração de uma transação por Boleto Bancário.
        /// </summary>
        /// <param name="transaction">Objeto com base na classe Transaction<T>, do tipo BankSlip.</param>
        /// <returns></returns>
        public object BankSlip(object transaction)
        {
            var response = Client.Post("v2/Payment", transaction);

            var responseObj = JsonConvert.DeserializeObject<Response<CheckoutResponse>>(response);
            if (responseObj.HasError)
                throw new Exception($"Erro {responseObj.ErrorCode} - {responseObj.Error}");

            return responseObj.ResponseDetail;
        }

        /// <summary>
        /// Geração de uma transação por Boleto Bancário.
        /// </summary>
        /// <param name="carnet">Objeto com base na classe Transaction<T>, do tipo Carnet.</param>
        /// <returns></returns>
        public object Carnet(object carnet)
        {
            var response = Client.Post("v2/Carnet", carnet);

            var responseObj = JsonConvert.DeserializeObject<Response<CheckoutResponse>>(response);
            if (responseObj.HasError)
                throw new Exception($"Erro {responseObj.ErrorCode} - {responseObj.Error}");

            return responseObj.ResponseDetail;
        }

        /// <summary>
        /// Geração de uma transação por Boleto Bancário.
        /// </summary>
        /// <param name="carnet">Objeto com base na classe CarnetLot.</param>
        /// <returns></returns>
        public object CarnetLot(object carnet)
        {
            var transactionCompressed = Utils.Compress(Utils.Serialize(carnet));
            var carnetLot = new CarnetLot { JsonGzip = transactionCompressed };

            var response = Client.Post("v2/CarnetAsync", carnetLot);

            var responseObj = JsonConvert.DeserializeObject<Response<CheckoutResponse>>(response);
            if (responseObj.HasError)
                throw new Exception($"Erro {responseObj.ErrorCode} - {responseObj.Error}");

            return responseObj.ResponseDetail;
        }

        /// <summary>
        /// Geração de uma transação por Boleto Bancário.
        /// </summary>
        /// <param name="transaction">Objeto com base na classe Transaction<T>, do tipo CreditCard.</param>
        /// <returns></returns>
        public object Credit(object transaction)
        {
            var response = Client.Post("v2/Payment", transaction);

            var responseObj = JsonConvert.DeserializeObject<Response<CheckoutResponse>>(response);
            if (responseObj.HasError)
                throw new Exception($"Erro {responseObj.ErrorCode} - {responseObj.Error}");

            return responseObj.ResponseDetail;
        }

        /// <summary>
        /// Geração de uma transação por Boleto Bancário.
        /// </summary>
        /// <param name="transaction">Objeto com base na classe Transaction<T>, do tipo CryptoCoin.</param>
        /// <returns></returns>
        public object CryptoCurrency(object transaction)
        {
            var response = Client.Post("v2/Payment", transaction);

            var responseObj = JsonConvert.DeserializeObject<Response<CheckoutResponse>>(response);
            if (responseObj.HasError)
                throw new Exception($"Erro {responseObj.ErrorCode} - {responseObj.Error}");

            return responseObj.ResponseDetail;
        }

        /// <summary>
        /// Geração de uma transação por Boleto Bancário.
        /// </summary>
        /// <param name="transaction">Objeto com base na classe Transaction<T>, do tipo DebitCard.</param>
        /// <returns></returns>
        public object DebitCard(object transaction)
        {
            var response = Client.Post("v2/Payment", transaction);

            var responseObj = JsonConvert.DeserializeObject<Response<CheckoutResponse>>(response);
            if (responseObj.HasError)
                throw new Exception($"Erro {responseObj.ErrorCode} - {responseObj.Error}");

            return responseObj.ResponseDetail;
        }

        /// <summary>
        /// Geração de uma transação por Boleto Bancário.
        /// </summary>
        /// <param name="debitAccount">Objeto com base na classe Transaction<T>, do tipo DebitAccount.</param>
        /// <returns></returns>
        public object DebitAccount(object debitAccount)
        {
            var response = Client.Post("v2/Payment", debitAccount);

            var responseObj = Utils.Deserialize<Response<CheckoutResponse>>(response);
            if (responseObj.HasError)
                throw new Exception($"Erro {responseObj.ErrorCode} - {responseObj.Error}");

            return responseObj.ResponseDetail;
        }

        /// <summary>
        /// Geração de uma transação por Boleto Bancário.
        /// </summary>
        /// <param name="transferRegister">Objeto com base na classe TransferRegisterLot.</param>
        /// <returns></returns>
        public object Transfer(object transferRegister)
        {
            var response = Client.Post("v2/Transfer", transferRegister);

            var responseObj = JsonConvert.DeserializeObject<Response<CheckoutResponse>>(response);
            if (responseObj.HasError)
                throw new Exception($"Erro {responseObj.ErrorCode} - {responseObj.Error}");

            return responseObj.ResponseDetail;
        }
    }
}