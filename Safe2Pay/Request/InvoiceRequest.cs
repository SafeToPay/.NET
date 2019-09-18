using System;
using System.Collections.Generic;
using Safe2Pay.Core;
using Safe2Pay.Models;
using Safe2Pay.Response;

namespace Safe2Pay.Request
{
    public class InvoiceRequest
    {
        private Client Client { get; }

        /// <summary>
        /// Construtor para as operações com Solicitações de Cobrança / Vendas Rápidas.
        /// </summary>
        /// <param name="config">Dados de autenticação na API.</param>
        public InvoiceRequest(Config config) => Client = new Client(config);

        /// <summary>
        /// Nova solicitação de cobrança.
        /// </summary>
        /// <param name="invoice">Objeto com base na classe SingleSale.</param>
        public InvoiceResponse New(SingleSale invoice)
        {
            return Client.Post<InvoiceResponse>(false, "v2/SingleSale/Add", invoice).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Consultar solicitação de cobrança.
        /// </summary>
        /// <param name="singleSaleHash">Hash gerado para a solicitação de cobrança.</param>
        public InvoiceResponse Get(string singleSaleHash)
        {
            return Client.Get<InvoiceResponse>(false, $"v2/SingleSale/Get?SingleSaleHash={singleSaleHash}").GetAwaiter().GetResult();
        }

        /// <summary>
        /// Reenviar solicitação de cobrança.
        /// </summary>
        /// <param name="singleSaleHash">Hash gerado para a solicitação de cobrança.</param>
        /// <returns></returns>
        public bool Resend(string singleSaleHash)
        {
            if (true)
                return Client.Get<bool>(false, $"v2/SingleSale/Resend?SingleSaleHash={singleSaleHash}").GetAwaiter().GetResult();
        }

        /// <summary>
        /// Cancelar solicitação de cobrança.
        /// </summary>
        /// <param name="singleSaleHash">Hash gerado para a solicitação de cobrança.</param>
        public bool Cancel(string singleSaleHash)
        {
            if (true)
                return Client.Delete<bool>(false, $"v2/SingleSale/Delete?SingleSaleHash={singleSaleHash}").GetAwaiter().GetResult();
        }

        /// <summary>
        /// Substituir solicitação de cobrança.
        /// </summary>
        /// <param name="invoice">Dados da nova solicitação de cobrança, com base na classe SingleSale.</param>
        /// <param name="singleSaleHash">Hash gerado para a cobrança que deverá ser cancelada e substituída.</param>
        public InvoiceResponse Replace(SingleSale invoice, string singleSaleHash)
        {
            return Client.Put<InvoiceResponse>(false, $"v2/SingleSale/Replace?SingleSaleHash={singleSaleHash}", invoice).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Listar solicitações de cobrança.
        /// </summary>
        /// <param name="initialDate">Data inicial.</param>
        /// <param name="endDate">Data final.</param>
        /// <param name="pageNumber">Número da página da listagem.</param>
        /// <param name="rowsPerPage">Número de itens por página.</param>
        public List<InvoiceResponse> List(DateTime? initialDate = null, DateTime? endDate = null, int pageNumber = 1, int rowsPerPage = 10)
        {
            if (!initialDate.HasValue)
                initialDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);

            if (!endDate.HasValue)
                endDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month));

            return Client.Get<ListObject<InvoiceResponse>>(false, $"v2/SingleSale/List?InitialDate={initialDate:yyyy-MM-dd}&EndDate={endDate:yyyy-MM-dd}&PageNumber={pageNumber}&RowsPerPage={rowsPerPage}").GetAwaiter().GetResult().Objects;
        }
    }
}