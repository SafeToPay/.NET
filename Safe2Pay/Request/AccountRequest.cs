using System;
using System.Collections.Generic;
using Safe2Pay.Core;
using Safe2Pay.Models;

namespace Safe2Pay
{
    public class AccountRequest
    {
        private Client Client { get; }

        /// <summary>
        /// Construtor para as funções de Conta-Corrente.
        /// </summary>
        /// <param name="config">Dados de autenticação na API.</param>
        public AccountRequest(Config config) => Client = new Client(config);

        /// <summary>
        /// Consultar dados bancários da empresa.
        /// </summary>
        public BankDataResponse GetBankData()
        {
            return Client.Get<BankDataResponse>(false, "v2/MerchantBankData/Get").GetAwaiter().GetResult();
        }

        /// <summary>
        /// Consultar os totalizadores de recebíveis do mês corrente.
        /// </summary>
        public CheckingAccountBalance GetBalance()
        {
            return Client.Get<CheckingAccountBalance>(false, "v2/CheckingAccount/GetBalance").GetAwaiter().GetResult();
        }

        /// <summary>
        /// Listar depósitos realizados e pendentes dentro de um período específico.
        /// Se não for passado nenhum parâmetro, retorno será o calendário de depósitos do mês corrente.
        /// </summary>
        /// <param name="initialDate">Data inicial. Se não informado, valor padrão será o primeiro dia do mês atual.</param>
        /// <param name="endDate">Data final. Se não informado, valor padrão será o último dia do mês atual.</param>
        public List<CheckingAccount> ListDeposits(DateTime? initialDate = null, DateTime? endDate = null)
        {
            if (!initialDate.HasValue) 
                initialDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            
            if (!endDate.HasValue) 
                endDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month));

            return Client.Get<List<CheckingAccount>>(false, $"v2/CheckingAccount/List?InitialDate={initialDate:yyyy-MM-dd}&EndDate={endDate:yyyy-MM-dd}").GetAwaiter().GetResult();
        }

        /// <summary>
        /// Detalhar os lançamentos realizados na data.
        /// Se não for passado nenhum parâmetro, retorno será o detalhamento de transações do depósito referentes ao dia atual.
        /// </summary>
        /// <param name="initialDate">Data inicial. Se não informado, valor padrão será o dia atual.</param>
        /// <param name="pageNumber">Número da página da listagem.</param>
        /// <param name="rowsPerPage">Número de itens por página.</param>
        public CheckingAccountList DetailDayDeposits(DateTime? initialDate = null, int pageNumber = 1, int rowsPerPage = 10)
        {
            if (!initialDate.HasValue) 
                initialDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            
            return Client.Get<CheckingAccountList>(false, $"v2/CheckingAccount/ListPeriod?InitialDate={initialDate:yyyy-MM-dd}&PageNumber={pageNumber}&RowsPerPage={rowsPerPage}").GetAwaiter().GetResult();
        }
    }
}