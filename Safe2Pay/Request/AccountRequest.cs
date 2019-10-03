using System;
using System.Collections.Generic;
using Safe2Pay.Core;
using Safe2Pay.Models;
using Safe2Pay.Response;

namespace Safe2Pay.Request
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
        /// Listar depósitos realizados e pendentes dentro de um período específico.
        /// Se não for passado nenhum parâmetro, retorno será o calendário de depósitos do mês corrente.
        /// </summary>
        /// <param name="initialDate">Data inicial. Se não informado, valor padrão será o primeiro dia do mês atual.</param>
        /// <param name="endDate">Data final. Se não informado, valor padrão será o último dia do mês atual.</param>
        public CheckingAccountDeposit GetListDeposits(int Mouth, int Year)
        {
       
            return Client.Get<CheckingAccountDeposit>(false, $"v2/CheckingAccount/GetListDeposits?month={Mouth}&year={Year}").GetAwaiter().GetResult();
        }
        /// <summary>
        /// Detalhar os lançamentos realizados na data.
        /// Se não for passado nenhum parâmetro, retorno será o detalhamento de transações do depósito referentes ao dia atual.
        /// </summary>
        /// <param name="initialDate">Data inicial. Se não informado, valor padrão será o dia atual.</param>
        /// <param name="pageNumber">Número da página da listagem.</param>
        /// <param name="rowsPerPage">Número de itens por página.</param>
        public Deposit GetListDetailsDeposits(DateTime? DepositDateRes = null, int pageNumber = 1, int rowsPerPage = 10)
        {
            DateTime depositDate = new DateTime();

            if (DepositDateRes == null || DepositDateRes == DateTime.MinValue)
                depositDate = DateTime.Now;
            else
                depositDate = (DateTime)DepositDateRes;

            return Client.Get<Deposit>(false, $"v2/CheckingAccount/GetListDetailsDeposits?day={depositDate.Date.Day}&month={depositDate.Date.Month}&year={depositDate.Date.Year}&page={pageNumber}&rowsPerPage={rowsPerPage}").GetAwaiter().GetResult();
        }
    }
}