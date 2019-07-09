using System;
using System.Net.Http;
using Newtonsoft.Json;
using Safe2Pay.Core;

namespace Safe2Pay
{
    public class Sales
    {
        private static readonly Client Client = Client.Create(false);
        
        /// <summary>
        /// Método para gerar uma nova solicitação de cobrança / venda rápida.
        /// </summary>
        /// <param name="data">Dados do destinatário da cobrança, dos produtos e formas de pagamento que estarão habilitadas para uso.</param>
        /// <returns></returns>
        public static object New(object data)
        {
            var response = Client.Post("SingleSale/Add", data);
                
            var responseObj = JsonConvert.DeserializeObject<Response<InvoiceResponse>>(response);
            if (responseObj.HasError) 
                throw new Exception($"Erro {responseObj.ErrorCode} - {responseObj.Error}");

            return responseObj.ResponseDetail;
        }

        /// <summary>
        /// Consultar dados da venda rápida.
        /// </summary>
        /// <param name="data">Enviar o Hash gerado na solicitação de cobrança.</param>
        /// <returns></returns>
        public static object Query(object data)
        {
            var response = Client.Get($"SingleSale/Get?singleSaleHash={data}");

            var responseObj = JsonConvert.DeserializeObject<Response<InvoiceResponse>>(response);
            if (responseObj.HasError) 
                throw new Exception($"Erro {responseObj.ErrorCode} - {responseObj.Error}");

            return responseObj.ResponseDetail;
        }

        /// <summary>
        /// Cancelar uma venda rápida.
        /// </summary>
        /// <param name="data">Enviar o Hash gerado na solicitação de cobrança.</param>
        /// <returns></returns>
        public static bool Cancel(object data)
        {
            var encodedQuery = new FormUrlEncodedContent(data.ToQueryString());
            var queryString = encodedQuery.ReadAsStringAsync().Result;

            var response = Client.Delete($"SingleSale/Delete?{queryString}");

            var responseObj = JsonConvert.DeserializeObject<Response<object>>(response);
            if (responseObj.HasError) 
                throw new Exception($"Erro {responseObj.ErrorCode} - {responseObj.Error}");

            return (bool) responseObj.ResponseDetail;
        }
    }
}
