using System;
using System.Net.Http;
using Newtonsoft.Json;
using Safe2Pay.Core;
using Safe2Pay.Models;

namespace Safe2Pay
{
    public class TransferRequest
    {
        private Client Client { get; }
        
        /// <summary>
        /// Construtor para as operações com TransferÊncias Bancárias.
        /// </summary>
        /// <param name="config">Dados de autenticação na API.</param>
        public TransferRequest(Config config) => Client = new Client().Create(false, config);

        /// <summary>
        /// Detalhar Transferência Bancária.
        /// </summary>
        /// <param name="id">Código da solicitação de transferência.</param>
        /// <returns></returns>
        public object Detail(object id)
        {
            var query = id is int || id is string
                ? $"Id={id}"
                : new FormUrlEncodedContent(id.ToQueryString()).ReadAsStringAsync().Result;

            var response = Client.Get($"v2/Transfer/Get?{query}");

            var responseObj = JsonConvert.DeserializeObject<Response<CheckoutResponse>>(response);
            if (responseObj.HasError)
                throw new Exception($"Erro {responseObj.ErrorCode} - {responseObj.Error}");

            return responseObj.ResponseDetail;
        }

        /// <summary>
        /// Listar transferências bancárias.
        /// </summary>
        /// <param name="pageNumber">Número da página da listagem.</param>
        /// <param name="rowsPerPage">Número de itens por página.</param>
        /// <returns></returns>
        public object List(int pageNumber = 1, int rowsPerPage = 10)
        {
            var filter = new Filter<TransferRegisterFilter>
            {
                PageNumber = pageNumber,
                RowsPerPage = rowsPerPage
            };
            var query = new FormUrlEncodedContent(filter.ToQueryString()).ReadAsStringAsync().Result;

            var response = Client.Get($"v2/Transfer/List?{query}");

            var responseObj = JsonConvert.DeserializeObject<Response<CheckoutResponse>>(response);
            if (responseObj.HasError)
                throw new Exception($"Erro {responseObj.ErrorCode} - {responseObj.Error}");

            return responseObj.ResponseDetail;
        }

        /// <summary>
        /// Listar lotes de transferências por período.
        /// </summary>
        /// <param name="initialDate">Data inicial.</param>
        /// <param name="endDate">Data final.</param>
        /// <param name="pageNumber">Número da página da listagem.</param>
        /// <param name="rowsPerPage">Número de itens por página.</param>
        /// <returns></returns>
        public object ListLot(DateTime initialDate, DateTime endDate, int pageNumber = 1, int rowsPerPage = 10)
        {
            var filter = new RangeDateFilter<TransferRegisterLot>
            {
                InitialDate = initialDate,
                EndDate = endDate,
                PageNumber = pageNumber,
                RowsPerPage = rowsPerPage
            };
            var query = new FormUrlEncodedContent(filter.ToQueryString()).ReadAsStringAsync().Result;

            var response = Client.Get($"v2/Transfer/ListLot?{query}");

            var responseObj = JsonConvert.DeserializeObject<Response<CheckoutResponse>>(response);
            if (responseObj.HasError)
                throw new Exception($"Erro {responseObj.ErrorCode} - {responseObj.Error}");

            return responseObj.ResponseDetail;
        }
    }
}