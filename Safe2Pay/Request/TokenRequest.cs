using Safe2Pay.Core;
using Safe2Pay.Models;
using Safe2Pay.Response;

namespace Safe2Pay
{
    public class TokenRequest
    {
        private Client Client { get; }

        /// <summary>
        /// Construtor para as operações de Tokenização de Cartão de Crédito.
        /// </summary>
        /// <param name="config">Dados de autenticação na API.</param>
        public TokenRequest(Config config) => Client = new Client(config);

        /// <summary>
        /// Tokenizar Cartão de Crédito.
        /// </summary>
        /// <param name="creditCard">Objeto com base na classe CreditCard.</param>
        public TokenResponse Tokenize(CreditCard creditCard)
        {
            return Client.Post<TokenResponse>(true, "v2/Token", creditCard).GetAwaiter().GetResult();
        }
    }
}