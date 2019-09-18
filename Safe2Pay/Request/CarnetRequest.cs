using Safe2Pay.Core;
using Safe2Pay.Models;
using Safe2Pay.Response;

namespace Safe2Pay.Request
{
    public class CarnetRequest
    {
        private Client Client { get; }

        /// <summary>
        /// Construtor para as funções de Transação..
        /// </summary>
        /// <param name="config">Dados de autenticação na API.</param>
        public CarnetRequest(Config config) => Client = new Client(config);

        /// <summary>
        /// Geração de uma transação por Carnê.
        /// </summary>
        /// <param name="transaction">Objeto com base na classe Transaction, do tipo Carnet.</param>
        /// <returns></returns>
        public CarnetResponse New(Transaction<Carnet> transaction)
        {
            return Client.Post<CarnetResponse>(true, "v2/Carnet", transaction).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Cancelamento de um Carnê simples.
        /// </summary>
        /// <param name="identifier">Identificador/hash do Carnê.</param>
        /// <returns></returns>
        public CarnetResponse Cancel(string identifier)
        {
            return Client.Delete<CarnetResponse>(false, $"v2/Carnet/Delete?Identifier={identifier}").GetAwaiter().GetResult();
        }

        /// <summary>
        /// Reenvio de um carnê por e-mail.
        /// </summary>
        /// <param name="identifier">Identificador/hash do Carnê.</param>
        /// <returns></returns>
        public bool Resend(string identifier)
        {
            if (true)
                return Client.Get<bool>(false, $"v2/Carnet/Resend?Identifier={identifier}").GetAwaiter().GetResult();
        }
    }
}