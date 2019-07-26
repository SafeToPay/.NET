using System;
using System.Net.Http;
using Newtonsoft.Json;
using Safe2Pay.Core;
using Safe2Pay.Models;

namespace Safe2Pay
{
    public class DebitAccountRequest
    {
        private Client Client { get; }
        
        /// <summary>
        /// Construtor para as operações com Débito em Conta.
        /// </summary>
        /// <param name="config">Dados de autenticação na API.</param>

        public DebitAccountRequest(Config config) => Client = new Client().Create(false, config);
        
        /// <summary>
        /// Consultar Débito em Conta.
        /// </summary>
        /// <param name="id">Código gerado para a transação.</param>
        /// <returns></returns>
        public object Detail(object id)
        {
            var query = id is int || id is string
                ? $"Id={id}"
                : new FormUrlEncodedContent(id.ToQueryString()).ReadAsStringAsync().Result;
            
            var response = Client.Get($"v2/DebitAccount/Get?{query}");

            var responseObj = JsonConvert.DeserializeObject<Response<AccountResponse>>(response);
            if (responseObj.HasError)
                throw new Exception($"Erro {responseObj.ErrorCode} - {responseObj.Error}");

            return responseObj.ResponseDetail;
        }

        /// <summary>
        /// Cancelar débito em conta.
        /// </summary>
        /// <param name="id">Código gerado para a transação.</param>
        /// <returns></returns>
        public object Cancel(object id)
        {
            var query = id is int || id is string
                ? $"Id={id}"
                : new FormUrlEncodedContent(id.ToQueryString()).ReadAsStringAsync().Result;
            
            var response = Client.Get($"v2/DebitAccount/Cancel?{query}");

            var responseObj = JsonConvert.DeserializeObject<Response<AccountResponse>>(response);
            if (responseObj.HasError)
                throw new Exception($"Erro {responseObj.ErrorCode} - {responseObj.Error}");

            return responseObj.ResponseDetail;
        }
    }
}