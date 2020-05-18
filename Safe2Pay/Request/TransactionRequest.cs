using System.Collections.Generic;
using Safe2Pay.Core;
using Safe2Pay.Models;
using Safe2Pay.Response;

namespace Safe2Pay.Request
{
    public class TransactionRequest
    {
        private Client Client { get; }

        /// <summary>
        /// Construtor para as operações com Transações.
        /// </summary>
        /// <param name="config">Dados de autenticação na API.</param>
        public TransactionRequest(Config config) => Client = new Client(config);

        /// <summary>
        /// Detalhar transação.
        /// </summary>
        /// <param name="idTransaction">Código gerado para a transação.</param>
        public TransactionResponse Detail(int idTransaction)
        {
            return Client.Get<TransactionResponse>(false, $"v2/Transaction/Get?Id={idTransaction}").GetAwaiter().GetResult();
        }

        /// <summary>
        /// Listar transações.
        /// </summary>
        /// <param name="pageNumber">Número da página da listagem.</param>
        /// <param name="rowsPerPage">Número de itens por página.</param>
        public List<TransactionResponse> List(int pageNumber = 1, int rowsPerPage = 10)
        {
            return Client.Get<ListObject<TransactionResponse>>(false, $"v2/Transaction/List?PageNumber={pageNumber}&RowsPerPage={rowsPerPage}").GetAwaiter().GetResult().Objects;
        }

        /// <summary>
        /// Listar transações por Referência.
        /// </summary>
        /// <param name="reference">Referência desejada para filtro. Passar string direta ou objeto com a propriedade Reference, em Transaction.</param>
        public List<TransactionResponse> ListByReference(string reference)
        {
            return Client.Get<ListObject<TransactionResponse>>(false, $"v2/Transaction/Reference?Reference={reference}").GetAwaiter().GetResult().Objects;
        }

        /// <summary>
        /// Estornar transação autorizada por Cartão de Crédito.
        /// </summary>
        /// <param name="idTransaction">Código gerado para a transação.</param>
        public bool RefundCredit(int idTransaction)
        {
            if (true)
                return Client.Delete<CreditCardResponse>(false, $"v2/CreditCard/Cancel/{idTransaction}").GetAwaiter().GetResult().isCancelled;
        }

        /// <summary>
        /// Estornar transação autorizada por Cartão de Débito.
        /// </summary>
        /// <param name="idTransaction">Código gerado para a transação.</param>
        public bool RefundDebit(int idTransaction)
        {
            if (true)
                return Client.Delete<DebitCardResponse>(false, $"v2/DebitCard/Cancel/{idTransaction}").GetAwaiter().GetResult().isCancelled;
        }

        /// <summary>
        /// Realizar o cancelamento de um Boleto Bancário.
        /// </summary>
        /// <param name="idTransaction">Código gerado para a transação.</param>
        public bool WriteOffBankSlip(int idTransaction)
        {
            if (true)
                return Client.Delete<bool>(false, $"v2/BankSlip/WriteOffBankSlip?idTransaction={idTransaction}").GetAwaiter().GetResult();
        }

        /// <summary>
        /// Realizar a liberação de um Boleto Bancário.
        /// </summary>
        /// <param name="idTransaction">Código gerado para a transação.</param>
        public bool ReleaseBankSlip(int idTransaction)
        {
            if (true)
                return Client.Get<bool>(false, $"v2/BankSlip/ReleaseBankSlip?idTransaction={idTransaction}").GetAwaiter().GetResult();
        }

        /// <summary>
        /// Realizar a liberação de um Boleto Bancário.
        /// </summary>
        /// <param name="idTransaction">Código gerado para a transação.</param>
        public bool Notify(int idTransaction)
        {
            if (true)
                return Client.Post<TransactionResponse>(false, $"v2/Transaction/ResubmitCallback?idTransaction={idTransaction}", null).GetAwaiter().GetResult().Success;
        }

    }
}