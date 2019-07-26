using System;
using Newtonsoft.Json;
using Safe2Pay.Core;
using Safe2Pay.Models;

namespace Safe2Pay
{
    public class TokenRequest
    {
        private Client Client { get; }
        
        /// <summary>
        /// Construtor para as operações de Tokenização de Cartão de Crédito.
        /// </summary>
        /// <param name="config">Dados de autenticação na API.</param>
        public TokenRequest(Config config) => Client = new Client().Create(true, config);

        /// <summary>
        /// Tokenizar Cartão de Crédito.
        /// </summary>
        /// <param name="creditCard">Objeto com base na classe CreditCard.</param>
        /// <returns></returns>
        public string Tokenize(object creditCard)
        {
            var response = Client.Post("v2/Token", creditCard);

            var responseObj = JsonConvert.DeserializeObject<Response<CheckoutResponse>>(response);
            if (responseObj.HasError)
                throw new Exception($"Erro {responseObj.ErrorCode} - {responseObj.Error}");

            return responseObj.ResponseDetail.Token;
        }
    }
}