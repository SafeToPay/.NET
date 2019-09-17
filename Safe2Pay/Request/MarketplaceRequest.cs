using System.Collections.Generic;
using Safe2Pay.Core;
using Safe2Pay.Models;
using Safe2Pay.Response;

namespace Safe2Pay
{
    public class MarketplaceRequest
    {
        private Client Client { get; }

        /// <summary>
        /// Construtor para as operações com Subcontas / Marketplace.
        /// </summary>
        /// <param name="config">Dados de autenticação na API.</param>
        public MarketplaceRequest(Config config) => Client = new Client(config);

        /// <summary>
        /// Adicionar nova subconta.
        /// </summary>
        /// <param name="merchant">Dados da empresa, com base na classe Merchant.</param>
        /// <returns></returns>
        public MarketplaceResponse New(Merchant merchant)
        {
            return Client.Post<MarketplaceResponse>(false, "v2/Marketplace/Add", merchant).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Consultar subconta.
        /// </summary>
        /// <param name="id">Código da subconta.</param>
        /// <returns></returns>
        public MarketplaceResponse Get(int id)
        {
            return Client.Get<MarketplaceResponse>(false, $"v2/Marketplace/Get?Id={id}").GetAwaiter().GetResult();
        }

        /// <summary>
        /// Atualizar dados da subconta.
        /// </summary>
        /// <param name="merchant">Dados que serão atualizados, com base na classe Merchant.</param>
        /// <param name="id">Código da subconta que deve ser atualizada.</param>
        /// <returns></returns>
        public MarketplaceResponse Update(Merchant merchant, int id)
        {
            return Client.Put<MarketplaceResponse>(false, $"v2/Marketplace/Update?Id={id}", merchant).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Excluir subconta.
        /// </summary>
        /// <param name="id">Código da subconta que deve ser excluída.</param>
        /// <returns></returns>
        public bool Delete(int id)
        {
            if (true)
                return Client.Delete<bool>(false, $"v2/Marketplace/Delete?Id={id}").GetAwaiter().GetResult();
        }

        /// <summary>
        /// Listar subcontas.
        /// </summary>
        /// <param name="pageNumber">Número da página da listagem.</param>
        /// <param name="rowsPerPage">Número de itens por página.</param>
        /// <returns></returns>
        public List<Merchant> List(int pageNumber = 1, int rowsPerPage = 10)
        {
            return Client.Get<ListObject<Merchant>>(false, $"v2/Marketplace/List?PageNumber={pageNumber}&RowsPerPage={rowsPerPage}").GetAwaiter().GetResult().Objects;
        }
    }
}