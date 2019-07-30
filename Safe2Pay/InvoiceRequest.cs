using System;
using System.Net.Http;
using Newtonsoft.Json;
using Safe2Pay.Core;
using Safe2Pay.Models;

namespace Safe2Pay
{
    public class InvoiceRequest
    {
        private Client Client { get; }
        
        /// <summary>
        /// Construtor para as operações com Solicitações de Cobrança / Vendas Rápidas.
        /// </summary>
        /// <param name="config">Dados de autenticação na API.</param>
        public InvoiceRequest(Config config) => Client = new Client().Create(false, config);

        /// <summary>
        /// Nova solicitação de cobrança.
        /// </summary>
        /// <param name="invoice">Objeto com base na classe SingleSale.</param>
        /// <returns></returns>
        public object New(object invoice)
        {
            var response = Client.Post("v2/SingleSale/Add", invoice);

            var responseObj = JsonConvert.DeserializeObject<Response<InvoiceResponse>>(response);
            if (responseObj.HasError)
                throw new Safe2PayException(responseObj.ErrorCode, responseObj.Error);

            return responseObj.ResponseDetail;
        }

        /// <summary>
        /// Consultar solicitação de cobrança.
        /// </summary>
        /// <param name="singleSaleHash">Hash gerado para a solicitação de cobrança.</param>
        /// <returns></returns>
        public object Get(object singleSaleHash)
        {
            var query = singleSaleHash is string
                ? $"SingleSaleHash={singleSaleHash}"
                : new FormUrlEncodedContent(singleSaleHash.ToQueryString()).ReadAsStringAsync().Result;

            var response = Client.Get($"v2/SingleSale/Get?{query}");

            var responseObj = JsonConvert.DeserializeObject<Response<InvoiceResponse>>(response);
            if (responseObj.HasError)
                throw new Safe2PayException(responseObj.ErrorCode, responseObj.Error);

            return responseObj.ResponseDetail;
        }

        /// <summary>
        /// Listar solicitações de cobrança.
        /// </summary>
        /// <param name="initialDate">Data inicial.</param>
        /// <param name="endDate">Data final.</param>
        /// <param name="pageNumber">Número da página da listagem.</param>
        /// <param name="rowsPerPage">Número de itens por página.</param>
        /// <returns></returns>
        public object List(DateTime initialDate, DateTime endDate, int pageNumber = 1, int rowsPerPage = 10)
        {
            var filter = new RangeDateFilter<SingleSale>
            {
                InitialDate = initialDate,
                EndDate = endDate,
                PageNumber = pageNumber,
                RowsPerPage = rowsPerPage
            };
            var query = new FormUrlEncodedContent(filter.ToQueryString()).ReadAsStringAsync().Result;

            var response = Client.Get($"v2/SingleSale/List?{query}");

            var responseObj = JsonConvert.DeserializeObject<Response<SubscriptionResponse>>(response);
            if (responseObj.HasError)
                throw new Safe2PayException(responseObj.ErrorCode, responseObj.Error);

            return responseObj.ResponseDetail;
        }
        
        /// <summary>
        /// Cancelar solicitação de cobrança.
        /// </summary>
        /// <param name="singleSaleHash">Hash gerado para a solicitação de cobrança.</param>
        /// <returns></returns>
        public bool Cancel(object singleSaleHash)
        {
            var query = singleSaleHash is string
                ? $"SingleSaleHash={singleSaleHash}"
                : new FormUrlEncodedContent(singleSaleHash.ToQueryString()).ReadAsStringAsync().Result;

            var response = Client.Delete($"v2/SingleSale/Delete?{query}");

            var responseObj = JsonConvert.DeserializeObject<Response<object>>(response);
            if (responseObj.HasError)
                throw new Safe2PayException(responseObj.ErrorCode, responseObj.Error);

            return (bool)responseObj.ResponseDetail;
        }

        /// <summary>
        /// Substituir solicitação de cobrança.
        /// </summary>
        /// <param name="invoice">Dados da nova solicitação de cobrança, com base na classe SingleSale.</param>
        /// <param name="singleSaleHash">Hash gerado para a cobrança que deverá ser cancelada e substituída.</param>
        /// <returns></returns>
        public object Replace(object invoice, object singleSaleHash)
        {
            var query = singleSaleHash is string
                ? $"SingleSaleHash={singleSaleHash}"
                : new FormUrlEncodedContent(singleSaleHash.ToQueryString()).ReadAsStringAsync().Result;

            var response = Client.Put($"v2/SingleSale/Replace?{query}", invoice);

            var responseObj = JsonConvert.DeserializeObject<Response<InvoiceResponse>>(response);
            if (responseObj.HasError)
                throw new Safe2PayException(responseObj.ErrorCode, responseObj.Error);

            return responseObj.ResponseDetail;
        }

        /// <summary>
        /// Reenviar solicitação de cobrança.
        /// </summary>
        /// <param name="singleSaleHash">Hash gerado para a solicitação de cobrança.</param>
        /// <returns></returns>
        public bool Resend(object singleSaleHash)
        {
            var query = singleSaleHash is string
                ? $"SingleSaleHash={singleSaleHash}"
                : new FormUrlEncodedContent(singleSaleHash.ToQueryString()).ReadAsStringAsync().Result;

            var response = Client.Get($"v2/SingleSale/Resend?{query}");

            var responseObj = JsonConvert.DeserializeObject<Response<object>>(response);
            if (responseObj.HasError)
                throw new Safe2PayException(responseObj.ErrorCode, responseObj.Error);

            return (bool)responseObj.ResponseDetail;
        }
    }
}