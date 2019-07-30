using System;
using System.Net.Http;
using Newtonsoft.Json;
using Safe2Pay.Core;
using Safe2Pay.Models;

namespace Safe2Pay
{
    public class PlanRequest
    {
        private Client Client { get; }
        
        /// <summary>
        /// Construtor para as operações com Planos.
        /// </summary>
        /// <param name="config">Dados de autenticação na API.</param>
        public PlanRequest(Config config) => Client = new Client().Create(false, config);

        /// <summary>
        /// Novo plano.
        /// </summary>
        /// <param name="plan">Objeto com base na classe Plan.</param>
        /// <returns></returns>
        public object New(object plan)
        {
            var response = Client.Post("v2/Plan/Add", plan);

            var responseObj = JsonConvert.DeserializeObject<Response<PlanResponse>>(response);
            if (responseObj.HasError)
                throw new Safe2PayException(responseObj.ErrorCode, responseObj.Error);

            return responseObj.ResponseDetail;
        }

        //TODO: Método com resposta vazia no retorno da API, porém o PUT é efetuado normalmente. Será ajustado para melhor tratamento da resposta.
        /// <summary>
        /// Atualizar detalhes de um plano existente.
        /// </summary>
        /// <param name="plan">Objeto com base na classe Plan. Informar a propriedade Id, com o código gerado para o plano.</param>
        /// <returns></returns>
        public bool Update(object plan)
        {
            Client.Put($"v2/Plan/Update", plan);
            return true;
        }

        /// <summary>
        /// Consultar detalhes de um plano.
        /// </summary>
        /// <param name="id">Código do plano que será consultado.</param>
        /// <returns></returns>
        public object Get(object id)
        {
            var query = id is int || id is string
                ? $"Id={id}"
                : new FormUrlEncodedContent(id.ToQueryString()).ReadAsStringAsync().Result;

            var response = Client.Get($"v2/Plan/Get?{query}");

            var responseObj = JsonConvert.DeserializeObject<Response<PlanResponse>>(response);
            if (responseObj.HasError)
                throw new Safe2PayException(responseObj.ErrorCode, responseObj.Error);

            return responseObj.ResponseDetail;
        }

        /// <summary>
        /// Listar os planos cadastrados.
        /// </summary>
        /// <param name="pageNumber">Número da página da listagem.</param>
        /// <param name="rowsPerPage">Número de itens por página.</param>
        /// <returns></returns>
        public object List(int pageNumber = 1, int rowsPerPage = 10)
        {
            var filter = new Filter<Plan>
            {
                PageNumber = pageNumber,
                RowsPerPage = rowsPerPage
            };
            var query = new FormUrlEncodedContent(filter.ToQueryString()).ReadAsStringAsync().Result;

            var response = Client.Get($"v2/Plan/List?{query}");

            var responseObj = JsonConvert.DeserializeObject<Response<PlanResponse>>(response);
            if (responseObj.HasError)
                throw new Safe2PayException(responseObj.ErrorCode, responseObj.Error);

            return responseObj.ResponseDetail.Objects;
        }
    }
}