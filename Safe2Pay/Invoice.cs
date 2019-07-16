using System;
using System.Net.Http;
using Newtonsoft.Json;
using Safe2Pay.Core;
using Safe2Pay.Models;

namespace Safe2Pay
{
    public class Invoice
    {
        /// <summary>
        /// Construtor para as funções de vendas
        /// </summary>
        /// <param name="config">Dados de autenticação</param>
        public Invoice(Config config) => Client = new Client().Create(false, config);

        private Client Client { get; set; }

        /// <summary>
        /// Método para gerar uma nova solicitação de cobrança / venda rápida.
        /// </summary>
        /// <param name="data">Dados do destinatário da cobrança, dos produtos e formas de pagamento que estarão habilitadas para uso.</param>
        /// <returns></returns>
        public object New(object invoice)
        {
            var response = Client.Post("SingleSale/Add", invoice);

            var responseObj = JsonConvert.DeserializeObject<Response<InvoiceResponse>>(response);
            if (responseObj.HasError)
                throw new Exception($"Erro {responseObj.ErrorCode} - {responseObj.Error}");

            return responseObj.ResponseDetail;
        }

        /// <summary>
        /// Consultar dados da venda rápida.
        /// </summary>
        /// <param name="hash">Enviar o Hash gerado na solicitação de cobrança.</param>
        /// <returns></returns>
        public object Get(object hash)
        {
            var query = hash is string
                ? $"SingleSaleHash={hash}"
                : new FormUrlEncodedContent(hash.ToQueryString()).ReadAsStringAsync().Result;

            var response = Client.Get($"SingleSale/Get?{query}");

            var responseObj = JsonConvert.DeserializeObject<Response<InvoiceResponse>>(response);
            if (responseObj.HasError)
                throw new Exception($"Erro {responseObj.ErrorCode} - {responseObj.Error}");

            return responseObj.ResponseDetail;
        }

        /// <summary>
        /// Cancelar uma venda rápida.
        /// </summary>
        /// <param name="hash">Enviar o Hash gerado na solicitação de cobrança.</param>
        /// <returns></returns>
        public bool Cancel(object hash)
        {
            var query = hash is string
                ? $"SingleSaleHash={hash}"
                : new FormUrlEncodedContent(hash.ToQueryString()).ReadAsStringAsync().Result;

            var response = Client.Delete($"SingleSale/Delete?{query}");

            var responseObj = JsonConvert.DeserializeObject<Response<object>>(response);
            if (responseObj.HasError)
                throw new Exception($"Erro {responseObj.ErrorCode} - {responseObj.Error}");

            return (bool)responseObj.ResponseDetail;
        }

        /// <summary>
        /// Substituir uma venda rápida. Método PUT que também fará o DELETE da solicitação do hash informado.
        /// </summary>
        /// <param name="invoice">Enviar nova solicitação de cobrança, que substituirá a do Hash informado.</param>
        /// <param name="hash">Enviar o Hash gerado na solicitação de cobrança que será cancelada.</param>
        /// <returns></returns>
        public object Replace(object invoice, object hash)
        {
            var query = hash is string
                ? $"SingleSaleHash={hash}"
                : new FormUrlEncodedContent(hash.ToQueryString()).ReadAsStringAsync().Result;

            var response = Client.Put($"SingleSale/Replace?{query}", invoice);

            var responseObj = JsonConvert.DeserializeObject<Response<InvoiceResponse>>(response);
            if (responseObj.HasError)
                throw new Exception($"Erro {responseObj.ErrorCode} - {responseObj.Error}");

            return responseObj.ResponseDetail;
        }
    }
}