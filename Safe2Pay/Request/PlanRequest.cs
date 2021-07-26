using System.Collections.Generic;
using Safe2Pay.Core;
using Safe2Pay.Models;
using Safe2Pay.Response;

namespace Safe2Pay.Request
{
    public class PlanRequest
    {
        private Client Client { get; }

        /// <summary>
        /// Construtor para as operações de Tokenização de Cartão de Crédito.
        /// </summary>
        /// <param name="config">Dados de autenticação na API.</param>
        public PlanRequest(Config config) => Client = new Client(config);

        public PlanResponse New(Plan plan)
        {
            return Client.Post<PlanResponse>(false, "v2/Plan/Add", plan).GetAwaiter().GetResult();
        }

        public PlanResponse Update(Plan plan)
        {
            return Client.Put<PlanResponse>(false, "v2/Plan/Update", plan).GetAwaiter().GetResult();
        }

        public PlanResponse UpdateEnabled(Plan plan)
        {
            return Client.Put<PlanResponse>(false, "v2/Plan/UpdateEnabled", plan).GetAwaiter().GetResult();
        }

        public PlanResponse Get(int id)
        {
            return Client.Get<PlanResponse>(false, $"v2/Plan/Get?Id={id}").GetAwaiter().GetResult();
        }

        //public object Delete(int id)
        //{
        //    return Client.Delete<object>(false, $"v2/Plan/Delete?Id={id}").GetAwaiter().GetResult();
        //}
        
        public List<PlanResponse> List(int pageNumber = 1, int rowsPerPage = 10)
        {
            return Client.Get<ListObject<PlanResponse>>(false, $"v2/Plan/List?PageNumber={pageNumber}&RowsPerPage={rowsPerPage}").GetAwaiter().GetResult().Objects;
        }
    }
}