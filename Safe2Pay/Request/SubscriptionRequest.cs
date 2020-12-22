using Safe2Pay.Core;
using Safe2Pay.Models;
using Safe2Pay.Models.Subscription;

namespace Safe2Pay.Request
{
    public class SubscriptionRequest
    {
        private Client Client { get; }

        /// <summary>
        /// Construtor para as operações de Tokenização de Cartão de Crédito.
        /// </summary>
        /// <param name="config">Dados de autenticação na API.</param>
        public SubscriptionRequest(Config config) => Client = new Client(config);

        /// <summary>
        /// Tokenizar Cartão de Crédito.
        /// </summary>
        /// <param name="creditCard">Objeto com base na classe CreditCard.</param>
        public object New(Subscription subscription)
        {
            return Client.Post<object>(false, "v2/Subscription/Add", subscription).GetAwaiter().GetResult();
        }

        public object Update(Plan plan)
        {
            return Client.Put<object>(false, "v2/Subscription/Update", plan).GetAwaiter().GetResult();
        }

        public object Get(int id)
        {
            return Client.Get<object>(false, $"v2/Subscription/Get?Id={id}").GetAwaiter().GetResult();
        }

        public object Resend(int id)
        {
            return Client.Get<object>(false, $"v2/Subscription/Resend?Id={id}").GetAwaiter().GetResult();
        }

        public object Delete(int id)
        {
            return Client.Delete<object>(false, $"v2/Subscription/Delete?Id={id}").GetAwaiter().GetResult();
        }

        public object List(int pageNumber = 1, int rowsPerPage = 10)
        {
            return Client.Get<object>(false, $"v2/Subscription/List?PageNumber={pageNumber}&RowsPerPage={rowsPerPage}").GetAwaiter().GetResult();
        }
    }
}