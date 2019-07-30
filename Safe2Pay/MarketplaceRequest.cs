using System;
using System.Net.Http;
using Newtonsoft.Json;
using Safe2Pay.Core;
using Safe2Pay.Models;

namespace Safe2Pay
{
    public class MarketplaceRequest
    {
        private Client Client { get; }
        
        /// <summary>
        /// Construtor para as operações com Subcontas / Marketplace.
        /// </summary>
        /// <param name="config">Dados de autenticação na API.</param>
        public MarketplaceRequest(Config config) => Client = new Client().Create(false, config);

        /// <summary>
        /// Adicionar nova subconta.
        /// </summary>
        /// <param name="merchant">Dados da empresa, com base na classe Merchant.</param>
        /// <returns></returns>
        public object New(object merchant)
        {
            var response = Client.Post("v2/Marketplace/Add", merchant);

            var responseObj = JsonConvert.DeserializeObject<Response<MarketplaceResponse>>(response);
            if (responseObj.HasError)
                throw new Safe2PayException(responseObj.ErrorCode, responseObj.Error);

            return responseObj.ResponseDetail;
        }

        /// <summary>
        /// Consultar subconta.
        /// </summary>
        /// <param name="id">Código da subconta.</param>
        /// <returns></returns>
        public object Get(object id)
        {
            var query = id is int || id is string 
                ? $"Id={id}"
                : new FormUrlEncodedContent(id.ToQueryString()).ReadAsStringAsync().Result;

            var response = Client.Get($"v2/Marketplace/Get?{query}");

            var responseObj = JsonConvert.DeserializeObject<Response<MarketplaceResponse>>(response);
            if (responseObj.HasError)
                throw new Safe2PayException(responseObj.ErrorCode, responseObj.Error);

            return responseObj.ResponseDetail;
        }

        /// <summary>
        /// Atualizar dados da subconta.
        /// </summary>
        /// <param name="merchant">Dados que serão atualizados, com base na classe Merchant.</param>
        /// <param name="id">Código da subconta que deve ser atualizada.</param>
        /// <returns></returns>
        public object Update(object merchant, object id)
        {
            var query = id is int || id is string 
                ? $"Id={id}"
                : new FormUrlEncodedContent(id.ToQueryString()).ReadAsStringAsync().Result;

            var response = Client.Put($"v2/Marketplace/Update?{query}", merchant);

            var responseObj = JsonConvert.DeserializeObject<Response<MarketplaceResponse>>(response);
            if (responseObj.HasError)
                throw new Safe2PayException(responseObj.ErrorCode, responseObj.Error);

            return responseObj.ResponseDetail;
        }

        /// <summary>
        /// Listar subcontas.
        /// </summary>
        /// <param name="pageNumber">Número da página da listagem.</param>
        /// <param name="rowsPerPage">Número de itens por página.</param>
        /// <returns></returns>
        public object List(int pageNumber = 1, int rowsPerPage = 10)
        {
            var query = new Filter<Merchant>
            {
                PageNumber = pageNumber, 
                RowsPerPage = rowsPerPage
            };
            var queryString = new FormUrlEncodedContent(query.ToQueryString()).ReadAsStringAsync().Result;

            var response = Client.Get($"v2/Marketplace/List?{queryString}");

            var responseObj = JsonConvert.DeserializeObject<Response<MarketplaceResponse>>(response);
            if (responseObj.HasError)
                throw new Safe2PayException(responseObj.ErrorCode, responseObj.Error);

            return responseObj.ResponseDetail.Objects;
        }

        /// <summary>
        /// Excluir subconta.
        /// </summary>
        /// <param name="id">Código da subconta que deve ser excluída.</param>
        /// <returns></returns>
        public bool Delete(object id)
        {
            var query = id is int || id is string 
                ? $"Id={id}"
                : new FormUrlEncodedContent(id.ToQueryString()).ReadAsStringAsync().Result;

            var response = Client.Delete($"v2/Marketplace/Delete?{query}");

            var responseObj = JsonConvert.DeserializeObject<Response<object>>(response);
            if (responseObj.HasError)
                throw new Safe2PayException(responseObj.ErrorCode, responseObj.Error);

            return (bool)responseObj.ResponseDetail;
        }
    }
}