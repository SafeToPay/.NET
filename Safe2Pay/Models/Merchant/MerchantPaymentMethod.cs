using System.Collections.Generic;

namespace Safe2Pay.Models
{
    public class MerchantPaymentMethod
    {
        public int Id { get; set; }
        public Merchant Merchant { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public bool IsEnabled { get; set; }
        public bool IsSendSMS { get; set; }
        public int InstallmentLimit { get; set; }
        public decimal MinorInstallmentAmount { get; set; }
        public List<MerchantPaymentMethodTax> ListTax { get; set; }
        public GenericType EnablePaymentDue { get; set; }
        public GenericType EnablePartialPayment { get; set; }
        public int DaysBeforeCancel { get; set; }
        public string DescriptionInvoice { get; set; }
        public decimal InterestPercentage { get; set; }
    }
}