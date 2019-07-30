using System;
using System.Net.Http;
using Newtonsoft.Json;
using Safe2Pay.Core;
using Safe2Pay.Models;

namespace Safe2Pay
{
    public class SubscriptionRequest
    {
        private Client Client { get; }
        
        /// <summary>
        /// Construtor para as operações com Adesões / Assinaturas.
        /// </summary>
        /// <param name="config">Dados de autenticação na API.</param>
        public SubscriptionRequest(Config config) => Client = new Client().Create(false, config);

        /// <summary>
        /// Nova adesão.
        /// </summary>
        /// <param name="subscription">Objeto com base na classe Subscription<T>, passando o tipo de pagamento para a recorrência, se CreditCard (para recorrência no cartão de crédito) ou BankData (para recorrência com débito em conta).</param>
        /// <returns></returns>
        public object New(Subscription subscription)
        {
            var response = Client.Post("v2/Subscription", subscription);

            var responseObj = JsonConvert.DeserializeObject<Response<SubscriptionResponse>>(response);
            if (responseObj.HasError)
                throw new Safe2PayException(responseObj.ErrorCode, responseObj.Error);

            return responseObj.ResponseDetail;
        }

        //TODO: Método com resposta vazia no retorno da API, porém o PUT é efetuado normalmente. Será ajustado para melhor tratamento da resposta.
        /// <summary>
        /// Atualizar adesão
        /// </summary>
        /// <param name="subscription">Objeto com base na classe Subscription<T>, passando o tipo de pagamento para a recorrência, se CreditCard (para recorrência no cartão de crédito) ou BankData (para recorrência com débito em conta).</param>
        /// <returns></returns>
        public bool Update(Subscription subscription)
        {
            var response = Client.Put("v2/Subscription/Update", subscription);

            var responseObj = JsonConvert.DeserializeObject<Response<SubscriptionResponse>>(response);
            if (responseObj != null)
                throw new Safe2PayException(responseObj.ErrorCode, responseObj.Error);

            return true;
        }

        /// <summary>
        /// Consultar adesão.
        /// </summary>
        /// <param name="id">Código gerado para a adesão.</param>
        /// <returns></returns>
        public object Get(object id)
        {
            var query = id is int || id is string
                ? $"Id={id}"
                : new FormUrlEncodedContent(id.ToQueryString()).ReadAsStringAsync().Result;

            var response = Client.Get($"v2/Subscription/Get?{query}");

            var responseObj = JsonConvert.DeserializeObject<Response<SubscriptionResponse>>(response);
            if (responseObj.HasError)
                throw new Safe2PayException(responseObj.ErrorCode, responseObj.Error);

            return responseObj.ResponseDetail;
        }

        /// <summary>
        /// Listar adesões.
        /// </summary>
        /// <param name="initialDate">Data inicial.</param>
        /// <param name="endDate">Data final.</param>
        /// <param name="pageNumber">Número da página da listagem.</param>
        /// <param name="rowsPerPage">Número de itens por página.</param>
        /// <returns></returns>
        public object List(DateTime initialDate, DateTime endDate, int pageNumber = 1, int rowsPerPage = 10)
        {
            var filter = new RangeDateFilter<Subscription>
            {
                InitialDate = initialDate,
                EndDate = endDate,
                PageNumber = pageNumber,
                RowsPerPage = rowsPerPage
            };
            var query = new FormUrlEncodedContent(filter.ToQueryString()).ReadAsStringAsync().Result;

            var response = Client.Get($"v2/Subscription/List?{query}");

            var responseObj = JsonConvert.DeserializeObject<Response<SubscriptionResponse>>(response);
            if (responseObj.HasError)
                throw new Safe2PayException(responseObj.ErrorCode, responseObj.Error);

            return responseObj.ResponseDetail;
        }
    }
}