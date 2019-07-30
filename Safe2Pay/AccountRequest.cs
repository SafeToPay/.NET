using System;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;
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
        public AccountRequest(Config config) => Client = new Client().Create(false, config);

        /// <summary>
        /// Buscar dados bancários da empresa.
        /// </summary>
        /// <returns></returns>
        public object GetBankData()
        {
            var response = Client.Get("v2/MerchantBankData/Get");

            var responseObj = JsonConvert.DeserializeObject<Response<AccountResponse>>(response);
            if (responseObj.HasError)
                throw new Safe2PayException(responseObj.ErrorCode, responseObj.Error);

            return responseObj.ResponseDetail;
        }

        //TODO: Método com resposta vazia no retorno da API, porém o PUT é efetuado normalmente. Será ajustado para melhor tratamento da resposta.
        /// <summary>
        /// Atualização dos dados bancários da empresa.
        /// </summary>
        /// <param name="bankCode">Código do Banco, conforme lista oficial do Banco Central e Federação Brasileira de Bancos (FEBRABAN).</param>
        /// <param name="bankAgency">Número da agência.</param>
        /// <param name="agencyDigit">Dígito da agência.</param>
        /// <param name="bankAccount">Número da conta.</param>
        /// <param name="accountDigit">Dígito da conta.</param>
        /// <param name="operation">Tipo de operação.</param>
        /// <returns></returns>
        public object UpdateBankData(string bankCode, string bankAgency, string agencyDigit, string bankAccount, string accountDigit, string operation)
        {
            var bankData = new BankData
            {
                Bank = new Bank { Code = bankCode },
                BankAgency = bankAgency,
                BankAgencyDigit = agencyDigit,
                BankAccount = bankAccount,
                BankAccountDigit = accountDigit,
                Operation = operation
            };

            Client.Put($"v2/MerchantBankData/Update", bankData);
            
            //var response = Client.Put($"v2/MerchantBankData/Update", bankData);
            //var responseObj = JsonConvert.DeserializeObject<Response<AccountResponse>>(response);
            //if (responseObj.HasError) throw new Safe2PayException(responseObj.ErrorCode, responseObj.Error);

            return true;
        }

        /// <summary>
        /// Buscar frequência de recebimento.
        /// </summary>
        /// <returns></returns>
        public object GetPaymentDate()
        {
            var response = Client.Get("v2/MerchantPaymentDate/Get");

            var responseObj = JsonConvert.DeserializeObject<Response<AccountResponse>>(response);
            if (responseObj.HasError)
                throw new Safe2PayException(responseObj.ErrorCode, responseObj.Error);

            return responseObj.ResponseDetail;
        }

        //TODO: Método com resposta vazia no retorno da API, porém o PUT é efetuado normalmente. Será ajustado para melhor tratamento da resposta.
        /// <summary>
        /// Atualizar frequência de recebimento.
        /// </summary>
        /// <param name="planFrequence">Frequência do recebimento. 1 = Uma vez por mês. 6 = Uma vez por semana.7 = Todos os dias.</param>
        /// <param name="paymentDay">Dia para recebimento. Se = 1, informar o número do dia desejado para recebimento. Se = 6, informar de 2 a 6 para definir de segunda a sexta. Se = 7, não enviar paymentDay.</param>
        /// <returns></returns>
        public object UpdatePaymentDate(int planFrequence = 7, int paymentDay = 0)
        {
            var frequency = new MerchantPaymentDate
            {
                PlanFrequence = new PlanFrequence { Code = planFrequence.ToString() },
                PaymentDay = paymentDay
            };

            var response = Client.Put($"v2/MerchantPaymentDate/Update", frequency);

            var responseObj = JsonConvert.DeserializeObject<Response<AccountResponse>>(response);
            if (responseObj.HasError)
                throw new Safe2PayException(responseObj.ErrorCode, responseObj.Error);

            return true;
        }

        /// <summary>
        /// Buscar Saldo e Operações no mês corrente.
        /// </summary>
        /// <returns></returns>
        public object GetBalance()
        {
            var response = Client.Get("v2/CheckingAccount/GetBalance");

            var responseObj = JsonConvert.DeserializeObject<Response<AccountResponse>>(response);
            if (responseObj.HasError)
                throw new Safe2PayException(responseObj.ErrorCode, responseObj.Error);

            return responseObj.ResponseDetail;
        }

        /// <summary>
        /// Listar depósitos dentro de um período específico.
        /// </summary>
        /// <param name="initialDate">Data inicial.</param>
        /// <param name="endDate">Data final.</param>
        /// <returns></returns>
        public object ListDeposits(DateTime initialDate, DateTime endDate)
        {
            var filter = new CheckingAccountFilter
            {
                InitialDate = initialDate,
                EndDate = endDate
            };
            var query = new FormUrlEncodedContent(filter.ToQueryString()).ReadAsStringAsync().Result;

            var response = Client.Get($"v2/CheckingAccount/List?{query}");

            var responseObj = JsonConvert.DeserializeObject<Response<List<AccountResponse>>>(response);
            if (responseObj.HasError)
                throw new Safe2PayException(responseObj.ErrorCode, responseObj.Error);

            return responseObj.ResponseDetail;
        }

        /// <summary>
        /// Detalhar os lançamentos do depósito a ser realizado na data.
        /// </summary>
        /// <param name="initialDate">Data desejada para a consulta.</param>
        /// <param name="pageNumber">Número da página da listagem.</param>
        /// <param name="rowsPerPage">Número de itens por página.</param>
        /// <returns></returns>
        public object DetailDayDeposits(DateTime initialDate, int pageNumber = 1, int rowsPerPage = 10)
        {
            var filter = new CheckingAccountFilter
            {
                InitialDate = initialDate,
                PageNumber = pageNumber,
                RowsPerPage = rowsPerPage
            };
            var query = new FormUrlEncodedContent(filter.ToQueryString()).ReadAsStringAsync().Result;

            var response = Client.Get($"v2/CheckingAccount/ListPeriod?{query}");

            var responseObj = JsonConvert.DeserializeObject<Response<AccountResponse>>(response);
            if (responseObj.HasError)
                throw new Safe2PayException(responseObj.ErrorCode, responseObj.Error);

            return responseObj.ResponseDetail;
        }
    }
}