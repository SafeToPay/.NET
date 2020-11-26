using Safe2Pay.Core;
using Safe2Pay.Request;

namespace Safe2Pay
{
    public class Safe2Pay_Request
    {
        private readonly Client client;
        private readonly Config config;

        public readonly AccountRequest Account;
        public readonly CarnetRequest Carnet;
        public readonly InvoiceRequest Invoice;
        public readonly MarketplaceRequest Marketplace;
        public readonly CheckoutRequest Payment;
        public readonly PlanRequest Plan;
        public readonly SubscriptionRequest Subscription;
        public readonly TokenRequest Token;
        public readonly TransferRequest Transfer;
        public readonly TransactionRequest Transaction;
        public readonly AdvancePaymentRequest AdvancePayment;

        private Safe2Pay_Request(Config config)
        {
            this.config = config;
            client = new Client(config);

            Account = new AccountRequest(this.config);
            Carnet = new CarnetRequest(this.config);
            Invoice = new InvoiceRequest(this.config);
            Marketplace = new MarketplaceRequest(this.config);
            Payment = new CheckoutRequest(this.config);
            Plan = new PlanRequest(this.config);
            Subscription = new SubscriptionRequest(this.config);
            Token = new TokenRequest(this.config);
            Transfer = new TransferRequest(this.config);
            Transaction = new TransactionRequest(this.config);
            AdvancePayment = new AdvancePaymentRequest(this.config);
        }

        public Safe2Pay_Request(string token, string secret = null, int timeout = 60) : this(new Config(token, secret, timeout))
        {
            if (string.IsNullOrEmpty(token)) 
                throw new Safe2PayException("O Token é obrigatório!");

            if (timeout < 15) 
                throw new Safe2PayException("O tempo definido para timeout é muito baixo! É recomendável mantê-lo acima de pelo menos 15 segundos.");
        }
    }
}