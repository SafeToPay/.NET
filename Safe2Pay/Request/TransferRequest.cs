using System;
using System.Collections.Generic;
using Safe2Pay.Core;
using Safe2Pay.Models;
using Safe2Pay.Response;

namespace Safe2Pay
{
    public class TransferRequest
    {
        private Client Client { get; }

        /// <summary>
        /// Construtor para as operações com TransferÊncias Bancárias.
        /// </summary>
        /// <param name="config">Dados de autenticação na API.</param>
        public TransferRequest(Config config ) => Client = new Client(config);

        /// <summary>
        /// Geração de um novo lote de Transferências Bancárias.
        /// </summary>
        /// <param name="transfer">Objeto com base na classe TransferRegisterLot.</param>
        public TransferResponse New(TransferRegisterLot transfer)
        {
            return Client.Post<TransferResponse>(true, "v2/Transfer", transfer).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Detalhar Transferência Bancária.
        /// </summary>
        /// <param name="id">Código da solicitação de transferência.</param>
        public TransferResponse Detail(int id)
        {
            return Client.Get<TransferResponse>(false,$"v2/Transfer/Get?Id={id}").GetAwaiter().GetResult();
        }

        /// <summary>
        /// Listar transferências bancárias.
        /// </summary>
        /// <param name="pageNumber">Número da página da listagem.</param>
        /// <param name="rowsPerPage">Número de itens por página.</param>
        /// <returns></returns>
        public List<TransferResponse> List(int pageNumber = 1, int rowsPerPage = 10)
        {
            return Client.Get<ListObject<TransferResponse>>(false,$"v2/Transfer/List?PageNumber={pageNumber}&RowsPerPage={rowsPerPage}").GetAwaiter().GetResult().Objects;
        }

        /// <summary>
        /// Listar lotes de transferências por período.
        /// </summary>
        /// <param name="initialDate">Data inicial.</param>
        /// <param name="endDate">Data final.</param>
        /// <param name="pageNumber">Número da página da listagem.</param>
        /// <param name="rowsPerPage">Número de itens por página.</param>
        /// <returns></returns>
        public List<TransferResponse> ListLot(DateTime? initialDate = null, DateTime? endDate = null, int pageNumber = 1, int rowsPerPage = 10)
        {
            if (!initialDate.HasValue) 
                initialDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            
            if (!endDate.HasValue) 
                endDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month));
            
            return Client.Get<ListObject<TransferResponse>>(false,$"v2/Transfer/ListLot?InitialDate={initialDate:yyyy-MM-dd}&EndDate={endDate:yyyy-MM-dd}&PageNumber={pageNumber}&RowsPerPage={rowsPerPage}").GetAwaiter().GetResult().Objects;
        }
    }
}