using System;
using System.Net.Http;
using System.Reflection;
using Newtonsoft.Json;
using Safe2Pay.Core;

namespace Safe2Pay
{
    /// <summary>
    /// <para>Usada para demais interações com transações.</para>
    /// Deve ser utilizada para o envio (POST) de um objeto com base nas propriedades da classe SingleSale.
    /// </summary>
    public class Transaction
    {
        /// <summary>
        /// Construtor para as funções de transações
        /// </summary>
        /// <param name="config">Dados de autenticação</param>
        public Transaction(Config config) => Client = new Client().Create(false, config);

        private Client Client { get; set; }

        /// <summary>
        /// Método para consultar os detalhes de uma transação.
        /// </summary>
        /// <param name="id">Informar o código gerado para a transação.</param>
        /// <returns></returns>
        public object Get(object id)
        {
            var query = id is int
                ? $"Id={id}"
                : new FormUrlEncodedContent(id.ToQueryString()).ReadAsStringAsync().Result;

            var response = Client.Get($"Transaction/Get?{query}");

            var responseObj = JsonConvert.DeserializeObject<Response<CheckoutResponse>>(response);
            if (responseObj.HasError)
                throw new Exception($"Erro {responseObj.ErrorCode} - {responseObj.Error}");

            return responseObj.ResponseDetail;
        }

        /// <summary>
        /// Método para realizar o estorno de uma transação gerada por Cartão de Crédito.
        /// </summary>
        /// <param name="id">Informar o código gerado para a transação.</param>
        /// <returns></returns>
        public object Refund(object id)
        {
            var query = id is int
                ? id
                : id.GetType().GetRuntimeProperty("Id").GetValue(id, null);

            var response = Client.Delete($"CreditCard/Cancel/{query}");

            var responseObj = JsonConvert.DeserializeObject<Response<CheckoutResponse>>(response);
            if (responseObj.HasError)
                throw new Exception($"Erro {responseObj.ErrorCode} - {responseObj.Error}");

            return responseObj.ResponseDetail;
        }

        /// <summary>
        /// Método para realizar o cancelamento de um boleto bancário.
        /// </summary>
        /// <param name="id">Informar o código identificador da transação.</param>
        /// <returns></returns>
        public object WriteOffBankSlip(object id)
        {
            var query = id is int
                ? $"Id={id}"
                : new FormUrlEncodedContent(id.ToQueryString()).ReadAsStringAsync().Result;

            var response = Client.Delete($"BankSlip/WriteOffBankSlip?{query}");

            var responseObj = JsonConvert.DeserializeObject<Response<CheckoutResponse>>(response);
            if (responseObj.HasError)
                throw new Exception($"Erro {responseObj.ErrorCode} - {responseObj.Error}");

            return responseObj.ResponseDetail;
        }

        /// <summary>
        /// Método para realizar a liberação de um boleto bancário.
        /// </summary>
        /// <param name="id">Informar o código identificador da transação.</param>
        /// <returns></returns>
        public object ReleaseBankSlip(object id)
        {
            var query = id is int
                ? $"Id={id}"
                : new FormUrlEncodedContent(id.ToQueryString()).ReadAsStringAsync().Result;

            var response = Client.Get($"BankSlip/ReleaseBankSlip?{query}");

            var responseObj = JsonConvert.DeserializeObject<Response<CheckoutResponse>>(response);
            if (responseObj.HasError)
                throw new Exception($"Erro {responseObj.ErrorCode} - {responseObj.Error}");

            return responseObj.ResponseDetail;
        }

        /// <summary>
        /// Método para realizar o cancelamento de um carnê.
        /// </summary>
        /// <param name="identifier">Informar o código identificador do carnê.</param>
        /// <returns></returns>
        public object CancelCarnet(object identifier)
        {
            var query = identifier is string
                ? $"Id={identifier}"
                : new FormUrlEncodedContent(identifier.ToQueryString()).ReadAsStringAsync().Result;

            var response = Client.Delete($"Carnet/Delete?{query}");

            var responseObj = JsonConvert.DeserializeObject<Response<CheckoutResponse>>(response);
            if (responseObj.HasError)
                throw new Exception($"Erro {responseObj.ErrorCode} - {responseObj.Error}");

            return responseObj.ResponseDetail;
        }

        /// <summary>
        /// Método para realizar o cancelamento de um lote de carnês.
        /// </summary>
        /// <param name="identifier">Informar o código identificador do carnê.</param>
        /// <returns></returns>
        public object CancelCarnetLot(object identifier)
        {
            var query = identifier is string
                ? $"Id={identifier}"
                : new FormUrlEncodedContent(identifier.ToQueryString()).ReadAsStringAsync().Result;

            var response = Client.Delete($"CarnetAsync/Delete?{query}");

            var responseObj = JsonConvert.DeserializeObject<Response<CheckoutResponse>>(response);
            if (responseObj.HasError)
                throw new Exception($"Erro {responseObj.ErrorCode} - {responseObj.Error}");

            return responseObj.ResponseDetail;
        }
    }
}