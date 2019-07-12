using System;
using System.Net.Http;
using Newtonsoft.Json;
using Safe2Pay.Core;

namespace Safe2Pay
{
    /// <summary>
    /// <para>Usada para demais interações com transações.</para>
    /// Deve ser utilizada para o envio (POST) de um objeto com base nas propriedades da classe SingleSale.
    /// </summary>
    public class Transactions
    {
        /// <summary>
        /// Construtor para as funções de transações
        /// </summary>
        /// <param name="config">Dados de autenticação</param>
        public Transactions(Config config) => Client = new Client().Create(false, config);

        private Client Client { get; set; }

        /// <summary>
        /// Método para consultar os detalhes de uma transação.
        /// </summary>
        /// <param name="IdTransaction">Informar o código gerado para a transação.</param>
        /// <returns></returns>
        public object Get(object IdTransaction)
        {
            var response = Client.Get($"Transaction/Get?Id={IdTransaction}");

            var responseObj = JsonConvert.DeserializeObject<Response<CheckoutResponse>>(response);
            if (responseObj.HasError) 
                throw new Exception($"Erro {responseObj.ErrorCode} - {responseObj.Error}");

            return responseObj.ResponseDetail;
        }

        /// <summary>
        /// Método para realizar o estorno de uma transação gerada por Cartão de Crédito.
        /// </summary>
        /// <param name="data">Informar o código gerado para a transação.</param>
        /// <returns></returns>
        public object Refund(object data)
        {
            var response = Client.Delete($"CreditCard/Cancel/{data}");

            var responseObj = JsonConvert.DeserializeObject<Response<CheckoutResponse>>(response);
            if (responseObj.HasError) 
                throw new Exception($"Erro {responseObj.ErrorCode} - {responseObj.Error}");

            return responseObj.ResponseDetail;
        }

        /// <summary>
        /// Método para realizar o cancelamento de um boleto bancário.
        /// </summary>
        /// <param name="data">Informar o código identificador da transação.</param>
        /// <returns></returns>
        public object WriteOffBankSlip(object data)
        {
            var encodedQuery = new FormUrlEncodedContent(data.ToQueryString());
            var queryString = encodedQuery.ReadAsStringAsync().Result;
            
            var response = Client.Delete($"BankSlip/WriteOffBankSlip?{queryString}");

            var responseObj = JsonConvert.DeserializeObject<Response<CheckoutResponse>>(response);
            if (responseObj.HasError) 
                throw new Exception($"Erro {responseObj.ErrorCode} - {responseObj.Error}");

            return responseObj.ResponseDetail;
        }

        /// <summary>
        /// Método para realizar a liberação de um boleto bancário.
        /// </summary>
        /// <param name="data">Informar o código identificador da transação.</param>
        /// <returns></returns>
        public object ReleaseBankSlip(object data)
        {
            var encodedQuery = new FormUrlEncodedContent(data.ToQueryString());
            var queryString = encodedQuery.ReadAsStringAsync().Result;
            
            var response = Client.Get($"BankSlip/RealeaseBankSlip?{queryString}");

            var responseObj = JsonConvert.DeserializeObject<Response<CheckoutResponse>>(response);
            if (responseObj.HasError) 
                throw new Exception($"Erro {responseObj.ErrorCode} - {responseObj.Error}");

            return responseObj.ResponseDetail;
        }

        /// <summary>
        /// Método para realizar o cancelamento de um carnê.
        /// </summary>
        /// <param name="data">Informar o código identificador do carnê.</param>
        /// <returns></returns>
        public object CancelCarnet(object data)
        {
            var encodedQuery = new FormUrlEncodedContent(data.ToQueryString());
            var queryString = encodedQuery.ReadAsStringAsync().Result;
            
            var response = Client.Delete($"Carnet/Delete?{queryString}");

            var responseObj = JsonConvert.DeserializeObject<Response<CheckoutResponse>>(response);
            if (responseObj.HasError) 
                throw new Exception($"Erro {responseObj.ErrorCode} - {responseObj.Error}");

            return responseObj.ResponseDetail;
        }

        /// <summary>
        /// Método para realizar o cancelamento de um lote de carnês.
        /// </summary>
        /// <param name="data">Informar o código identificador do carnê.</param>
        /// <returns></returns>
        public object CancelCarnetLot(object data)
        {
            var encodedQuery = new FormUrlEncodedContent(data.ToQueryString());
            var queryString = encodedQuery.ReadAsStringAsync().Result;
            
            var response = Client.Delete($"CarnetAsync/Delete?{queryString}");

            var responseObj = JsonConvert.DeserializeObject<Response<CheckoutResponse>>(response);
            if (responseObj.HasError) 
                throw new Exception($"Erro {responseObj.ErrorCode} - {responseObj.Error}");

            return responseObj.ResponseDetail;
        }
    }
}