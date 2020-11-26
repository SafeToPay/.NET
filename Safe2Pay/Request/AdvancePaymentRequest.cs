using Safe2Pay.Core;
using Safe2Pay.Response;

namespace Safe2Pay.Request
{
    public class AdvancePaymentRequest
    {
        private Client Client { get; }

        /// <summary>
        /// Construtor para as funções de Antecipação de recebíveis.
        /// </summary>
        /// <param name="config">Dados de autenticação na API.</param>
        public AdvancePaymentRequest(Config config) => Client = new Client(config);

        /// <summary>
        /// Simular a antecipação de recebíveis.
        /// </summary>
        public AdvancePaymentResponse AdvancePaymentSimulation()
        {
            return Client.Get<AdvancePaymentResponse>(false, "v2/AdvancePayment/Simulation").GetAwaiter().GetResult();
        }
        /// <summary>
        /// Solicitar a antecipação de recebíveis.
        /// </summary>
        public AdvancePaymentResponse AdvancePaymentRequire()
        {
            return Client.Get<AdvancePaymentResponse>(false, "v2/AdvancePayment/Require").GetAwaiter().GetResult();
        }
    }
}
