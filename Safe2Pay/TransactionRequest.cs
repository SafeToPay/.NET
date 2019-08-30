using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Reflection;
using Newtonsoft.Json;
using Safe2Pay.Core;
using Safe2Pay.Models;

namespace Safe2Pay
{
    public class TransactionRequest
    {
        private Client Client { get; }
        
        /// <summary>
        /// Construtor para as operações com Transações.
        /// </summary>
        /// <param name="config">Dados de autenticação na API.</param>
        public TransactionRequest(Config config) => Client = new Client().Create(false, config);

        /// <summary>
        /// Detalhar transação.
        /// </summary>
        /// <param name="idTransaction">Código gerado para a transação.</param>
        /// <returns></returns>
        public object Detail(object idTransaction)
        {
            var query = idTransaction is int || idTransaction is string
                ? $"Id={idTransaction}"
                : new FormUrlEncodedContent(idTransaction.ToQueryString()).ReadAsStringAsync().Result;

            var response = Client.Get($"v2/Transaction/Get?{query}");

            var responseObj = JsonConvert.DeserializeObject<Response<CheckoutResponse>>(response);
            if (responseObj.HasError)
                throw new Safe2PayException(responseObj.ErrorCode, responseObj.Error);

            return responseObj.ResponseDetail;
        }

        /// <summary>
        /// Listar transações.
        /// </summary>
        /// <param name="pageNumber">Número da página da listagem.</param>
        /// <param name="rowsPerPage">Número de itens por página.</param>
        /// <returns></returns>
        public object List(int pageNumber = 1, int rowsPerPage = 10)
        {
            var response = Client.Get($"v2/Transaction/List?PageNumber={pageNumber}&RowsPerPage={rowsPerPage}");

            var responseObj = JsonConvert.DeserializeObject<Response<CheckoutResponse>>(response);
            if (responseObj.HasError)
                throw new Safe2PayException(responseObj.ErrorCode, responseObj.Error);

            return responseObj.ResponseDetail.Objects;
        }

        /// <summary>
        /// Listar transações por Referência.
        /// </summary>
        /// <param name="reference">Referência desejada para filtro. Passar string direta ou objeto com a propriedade Reference, em Transaction.</param>
        /// <returns></returns>
        public object ListByReference(object reference)
        {
            var query = reference is string
                ? $"Reference={reference}"
                : new FormUrlEncodedContent(reference.ToQueryString()).ReadAsStringAsync().Result;

            var response = Client.Get($"v2/Transaction/Reference?{query}");

            var responseObj = JsonConvert.DeserializeObject<Response<CheckoutResponse>>(response);
            if (responseObj.HasError)
                throw new Safe2PayException(responseObj.ErrorCode, responseObj.Error);

            return responseObj.ResponseDetail.Objects;
        }

        /// <summary>
        /// Estornar transação autorizada por Cartão de Crédito.
        /// </summary>
        /// <param name="idTransaction">Código gerado para a transação.</param>
        /// <returns></returns>
        public object RefundCredit(object idTransaction)
        {
            var query = idTransaction is int || idTransaction is string
                ? idTransaction
                : idTransaction.GetType().GetRuntimeProperty("idTransaction").GetValue(idTransaction, null);

            var response = Client.Delete($"v2/CreditCard/Cancel/{query}");

            var responseObj = JsonConvert.DeserializeObject<Response<CheckoutResponse>>(response);
            if (responseObj.HasError)
                throw new Safe2PayException(responseObj.ErrorCode, responseObj.Error);

            return responseObj.ResponseDetail;
        }

        /// <summary>
        /// Estornar transação autorizada por Cartão de Débito.
        /// </summary>
        /// <param name="idTransaction">Código gerado para a transação.</param>
        /// <returns></returns>
        public object RefundDebit(object idTransaction)
        {
            var query = idTransaction is int
                ? idTransaction
                : idTransaction.GetType().GetRuntimeProperty("idTransaction").GetValue(idTransaction, null);

            var response = Client.Delete($"v2/DebitCard/Cancel/{query}");

            var responseObj = JsonConvert.DeserializeObject<Response<CheckoutResponse>>(response);
            if (responseObj.HasError)
                throw new Safe2PayException(responseObj.ErrorCode, responseObj.Error);

            return responseObj.ResponseDetail;
        }
        
        /// <summary>
        /// Realizar o cancelamento de um Boleto Bancário.
        /// </summary>
        /// <param name="idTransaction">Código gerado para a transação.</param>
        /// <returns></returns>
        public bool WriteOffBankSlip(object idTransaction)
        {
            var query = idTransaction is int
                ? $"idTransaction={idTransaction}"
                : new FormUrlEncodedContent(idTransaction.ToQueryString()).ReadAsStringAsync().Result;

            var response = Client.Delete($"v2/BankSlip/WriteOffBankSlip?{query}");

            var responseObj = JsonConvert.DeserializeObject<Response<object>>(response);
            if (responseObj.HasError)
                throw new Safe2PayException(responseObj.ErrorCode, responseObj.Error);

            return (bool)responseObj.ResponseDetail;
        }

        /// <summary>
        /// Realizar a liberação de um Boleto Bancário.
        /// </summary>
        /// <param name="idTransaction">Código gerado para a transação.</param>
        /// <returns></returns>
        public bool ReleaseBankSlip(object idTransaction)
        {
            var query = idTransaction is int
                ? $"idTransaction={idTransaction}"
                : new FormUrlEncodedContent(idTransaction.ToQueryString()).ReadAsStringAsync().Result;

            var response = Client.Get($"v2/BankSlip/ReleaseBankSlip?{query}");

            var responseObj = JsonConvert.DeserializeObject<Response<object>>(response);
            if (responseObj.HasError)
                throw new Safe2PayException(responseObj.ErrorCode, responseObj.Error);

            return (bool)responseObj.ResponseDetail;
        }

        /// <summary>
        /// Cancelamento de um Carnê simples.
        /// </summary>
        /// <param name="identifier">Identificador/hash do Carnê.</param>
        /// <returns></returns>
        public object CancelCarnet(object identifier)
        {
            var query = identifier is string
                ? $"Identifier={identifier}"
                : new FormUrlEncodedContent(identifier.ToQueryString()).ReadAsStringAsync().Result;

            var response = Client.Delete($"v2/Carnet/Delete?{query}");

            var responseObj = JsonConvert.DeserializeObject<Response<CheckoutResponse>>(response);
            if (responseObj.HasError)
                throw new Safe2PayException(responseObj.ErrorCode, responseObj.Error);

            return responseObj.ResponseDetail;
        }

        /// <summary>
        /// Consulta de um lote de carnês.
        /// </summary>
        /// <param name="identifier">Identificador/hash do Carnê.</param>
        /// <returns></returns>
        public object GetCarnetLot(object identifier)
        {
            var query = identifier is string
                ? $"Identifier={identifier}"
                : new FormUrlEncodedContent(identifier.ToQueryString()).ReadAsStringAsync().Result;

            var response = Client.Get($"v2/CarnetAsync/Get?{query}");

            var responseObj = JsonConvert.DeserializeObject<Response<CheckoutResponse>>(response);
            if (responseObj.HasError)
                throw new Safe2PayException(responseObj.ErrorCode, responseObj.Error);

            return responseObj.ResponseDetail;
        }

        /// <summary>
        /// Cancelar um lote de carnês.
        /// </summary>
        /// <param name="identifier">Identificador/hash do Carnê.</param>
        /// <returns></returns>
        public object CancelCarnetLot(object identifier)
        {
            var query = identifier is string
                ? $"Identifier={identifier}"
                : new FormUrlEncodedContent(identifier.ToQueryString()).ReadAsStringAsync().Result;

            var response = Client.Delete($"v2/CarnetAsync/Delete?{query}");

            var responseObj = JsonConvert.DeserializeObject<Response<CheckoutResponse>>(response);
            if (responseObj.HasError)
                throw new Safe2PayException(responseObj.ErrorCode, responseObj.Error);

            return responseObj.ResponseDetail;
        }
    }
}