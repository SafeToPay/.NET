using Safe2Pay.Core;
using Safe2Pay.Models;
using Safe2Pay.Response;
using System;
using System.Collections.Generic;

namespace Safe2Pay.Request
{
    public class MerchantPaymentMethodRequest
    {
        private Client Client { get; }

        /// <summary>
        /// Construtor para as funções de formas de pagamento.
        /// </summary>
        /// <param name="config">Dados de autenticação na API.</param>
        public MerchantPaymentMethodRequest(Config config) => Client = new Client(config);

        /// <summary>
        /// Consultar formas de pagamento da empresa
        /// </summary>
        public List<MerchantPaymentMethodResponse> List()
        {
            return Client.Get<List<MerchantPaymentMethodResponse>>(false, "v2/MerchantPaymentMethod/List").GetAwaiter().GetResult();
        }
    }
}
