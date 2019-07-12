using System;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;
using Safe2Pay.Core;

namespace Safe2Pay
{
    public class Account
    {
        /// <summary>
        /// Construtor para as funções de Conta-Corrente
        /// </summary>
        /// <param name="config">Dados de autenticação</param>
        public Account(Config config) => Client = new Client().Create(false, config);

        private Client Client { get; set; }

        /// <summary>
        /// Consultar dados bancários da empresa.
        /// </summary>
        /// <returns></returns>
        public object GetBankData()
        {
            var response = Client.Get("MerchantBankData/Get");

            var responseObj = JsonConvert.DeserializeObject<Response<AccountResponse>>(response);
            if (responseObj.HasError)
                throw new Exception($"Erro {responseObj.ErrorCode} - {responseObj.Error}");

            return responseObj.ResponseDetail;
        }

        /// <summary>
        /// Consultar recebimentos no mês corrente.
        /// </summary>
        /// <returns></returns>
        public object GetBalance()
        {
            var response = Client.Get("CheckingAccount/GetBalance");

            var responseObj = JsonConvert.DeserializeObject<Response<AccountResponse>>(response);
            if (responseObj.HasError)
                throw new Exception($"Erro {responseObj.ErrorCode} - {responseObj.Error}");

            return responseObj.ResponseDetail;
        }

        /// <summary>
        /// Listar depósitos entre duas datas, InitialDate e EndDate.
        /// </summary>
        /// <param name="date">Informar filtros com base no CheckingAccountFilter.</param>
        /// <returns></returns>
        public object List(object date)
        {
            var query = new FormUrlEncodedContent(date.ToQueryString()).ReadAsStringAsync().Result;

            var response = Client.Get($"CheckingAccount/List?{query}");

            var responseObj = JsonConvert.DeserializeObject<Response<List<AccountResponse>>>(response);
            if (responseObj.HasError)
                throw new Exception($"Erro {responseObj.ErrorCode} - {responseObj.Error}");

            return responseObj.ResponseDetail;
        }

        /// <summary>
        /// Detalhar depósitos no mês.
        /// </summary>
        /// <param name="year">Inteiro do ano desejado</param>
        /// <param name="month">Inteiro para o mês desejado.</param>
        /// <returns></returns>
        public object ListDeposits(int year, int month)
        {
            var response = Client.Get($"CheckingAccount/GetListDeposits?month={month}&year={year}");

            var responseObj = JsonConvert.DeserializeObject<Response<AccountResponse>>(response);
            if (responseObj.HasError)
                throw new Exception($"Erro {responseObj.ErrorCode} - {responseObj.Error}");

            return responseObj.ResponseDetail;
        }

        /// <summary>
        /// Detalhar depósitos no dia.
        /// </summary>
        /// <param name="year">Inteiro do ano desejado</param>
        /// <param name="month">Inteiro para o mês desejado.</param>
        /// <param name="day">Inteiro para o dia desejado</param>
        /// <returns></returns>
        public object ListPeriod(int year, int month, int day)
        {
            var response = Client.Get($"CheckingAccount/ListPeriod?InitialDate={year}-{month}-{day}");

            var responseObj = JsonConvert.DeserializeObject<Response<AccountResponse>>(response);
            if (responseObj.HasError)
                throw new Exception($"Erro {responseObj.ErrorCode} - {responseObj.Error}");

            return responseObj.ResponseDetail;
        }
    }
}