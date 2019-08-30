using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Safe2Pay.Core;
using Safe2Pay.Models;

namespace Safe2Pay
{
    public class CheckoutRequest
    {
        private Client Client { get; }

        /// <summary>
        /// Construtor para as funções de Transação..
        /// </summary>
        /// <param name="config">Dados de autenticação na API.</param>
        public CheckoutRequest(Config config)
        {
            Client = new Client().Create(true, config);
            configAux = config;
        }

        private Config configAux { get; set; }
        /// <summary>
        /// Geração de uma transação por Boleto Bancário.
        /// </summary>
        /// <param name="transaction">Objeto com base na classe Transaction<T>, do tipo BankSlip.</param>
        /// <returns></returns>
        public object BankSlip(object transaction)
        {
            try
            {
                var response = Client.Post("v2/Payment", transaction);

                var responseObj = JsonConvert.DeserializeObject<Response<CheckoutResponse>>(response);
                if (responseObj.HasError)
                    throw new Safe2PayException(responseObj.ErrorCode, responseObj.Error);

                return responseObj.ResponseDetail;
            }
            catch (AggregateException ex)
            {
                if (ex.InnerException is TaskCanceledException)
                {
                    var transactionRequest = new TransactionRequest(configAux);
                    var returnReference = transactionRequest.ListByReference(((Base)transaction).Reference);

                    if (returnReference != null && ((List<Transaction<object>>)returnReference).Count > 0)
                    {
                        returnReference = ((List<Transaction<object>>)returnReference)[0];
                        return new CheckoutResponse
                        {
                            IdTransaction = ((Base)returnReference).Id,
                            Status = ((Base)returnReference).TransactionStatus.Code,
                            Message = ((Base)returnReference).TransactionStatus.Name,
                            Description = "Estamos aguardando o pagamento do boleto bancário. Após o pagamento, o boleto poderá levar até 2 dias úteis para ser compensado.",
                            BankSlipNumber = JObject.Parse(JsonConvert.SerializeObject(((Transaction<object>)returnReference).PaymentObject))["BankSlipNumber"]?.ToString(),
                            DueDate = JObject.Parse(JsonConvert.SerializeObject(((Transaction<object>)returnReference).PaymentObject))["DueDate"]?.ToString(),
                            DigitableLine = JObject.Parse(JsonConvert.SerializeObject(((Transaction<object>)returnReference).PaymentObject))["DigitableLine"]?.Value<string>(),
                            Barcode = JObject.Parse(JsonConvert.SerializeObject(((Transaction<object>)returnReference).PaymentObject))["Barcode"]?.Value<string>(),
                            BankSlipUrl = JObject.Parse(JsonConvert.SerializeObject(((Transaction<object>)returnReference).PaymentObject))["BankSplipUrl"]?.Value<string>(),
                            OperationDate = JObject.Parse(JsonConvert.SerializeObject(((Transaction<object>)returnReference).PaymentObject))["OperationDate"]?.Value<string>(),
                            BankName = JObject.Parse(JsonConvert.SerializeObject(((Transaction<object>)returnReference).PaymentObject))["BankName"]?.Value<string>(),
                            CodeBank = JObject.Parse(JsonConvert.SerializeObject(((Transaction<object>)returnReference).PaymentObject))["CodeBank"]?.Value<string>(),
                            Wallet = JObject.Parse(JsonConvert.SerializeObject(((Transaction<object>)returnReference).PaymentObject))["Wallet"]?.Value<string>(),
                            Agency = JObject.Parse(JsonConvert.SerializeObject(((Transaction<object>)returnReference).PaymentObject))["Agency"]?.Value<string>(),
                            Account = JObject.Parse(JsonConvert.SerializeObject(((Transaction<object>)returnReference).PaymentObject))["Account"]?.Value<string>(),
                            CodeAssignor = JObject.Parse(JsonConvert.SerializeObject(((Transaction<object>)returnReference).PaymentObject))["CodeAssignor"]?.Value<string>(),
                            WalletDescription = JObject.Parse(JsonConvert.SerializeObject(((Transaction<object>)returnReference).PaymentObject))["WalletDescription"]?.Value<string>(),
                            AgencyDV = JObject.Parse(JsonConvert.SerializeObject(((Transaction<object>)returnReference).PaymentObject))["AgencyDV"]?.Value<string>(),
                            AccountDV = JObject.Parse(JsonConvert.SerializeObject(((Transaction<object>)returnReference).PaymentObject))["AccountDV"]?.Value<string>(),
                            DocType = JObject.Parse(JsonConvert.SerializeObject(((Transaction<object>)returnReference).PaymentObject))["DocType"]?.Value<string>(),
                            Accept = JObject.Parse(JsonConvert.SerializeObject(((Transaction<object>)returnReference).PaymentObject))["Accept"]?.Value<string>(),
                            GuarantorName = JObject.Parse(JsonConvert.SerializeObject(((Transaction<object>)returnReference).PaymentObject))["GuarantorName"]?.Value<string>(),
                            GuarantorIdentity = JObject.Parse(JsonConvert.SerializeObject(((Transaction<object>)returnReference).PaymentObject))["GuarantorIdentity"]?.Value<string>(),
                        };
                    }
                }
                return null;
            }
        }

        /// <summary>
        /// Geração de uma transação por Boleto Bancário.
        /// </summary>
        /// <param name="carnet">Objeto com base na classe Transaction<T>, do tipo Carnet.</param>
        /// <returns></returns>
        public object Carnet(object carnet)
        {
            var response = Client.Post("v2/Carnet", carnet);

            var responseObj = JsonConvert.DeserializeObject<Response<CheckoutResponse>>(response);
            if (responseObj.HasError)
                throw new Safe2PayException(responseObj.ErrorCode, responseObj.Error);

            return responseObj.ResponseDetail;
        }

        /// <summary>
        /// Geração de uma transação por Boleto Bancário.
        /// </summary>
        /// <param name="carnet">Objeto com base na classe CarnetLot.</param>
        /// <returns></returns>
        public object CarnetLot(object carnet)
        {
            var transactionCompressed = Utils.Compress(Utils.Serialize(carnet));
            var carnetLot = new CarnetLot { JsonGzip = transactionCompressed };

            var response = Client.Post("v2/CarnetAsync", carnetLot);

            var responseObj = JsonConvert.DeserializeObject<Response<CheckoutResponse>>(response);
            if (responseObj.HasError)
                throw new Safe2PayException(responseObj.ErrorCode, responseObj.Error);

            return responseObj.ResponseDetail;
        }

        /// <summary>
        /// Geração de uma transação por Boleto Bancário.
        /// </summary>
        /// <param name="transaction">Objeto com base na classe Transaction<T>, do tipo CreditCard.</param>
        /// <returns></returns>
        public object Credit(object transaction)
        {
            try
            {
                var response = Client.Post("v2/Payment", transaction);

                var responseObj = JsonConvert.DeserializeObject<Response<CheckoutResponse>>(response);
                if (responseObj.HasError)
                    throw new Safe2PayException(responseObj.ErrorCode, responseObj.Error);

                return responseObj.ResponseDetail;
            }
            catch (AggregateException ex)
            {
                if (ex.InnerException is TaskCanceledException)
                {
                    var transactionRequest = new TransactionRequest(configAux);
                    var returnReference = transactionRequest.ListByReference(((Base)transaction).Reference);

                    if (returnReference != null && ((List<Transaction<object>>)returnReference).Count > 0)
                    {
                        returnReference = ((List<Transaction<object>>)returnReference)[0];
                        var status = ((Base)returnReference).TransactionStatus.Code;
                        switch (status)
                        {
                            case "1":
                                return new CheckoutResponse
                                {
                                    IdTransaction = ((Base)returnReference).Id,
                                    Token = JObject.Parse(JsonConvert.SerializeObject(((Transaction<object>)returnReference)))["Token"]?.Value<string>(),
                                    Description = "Estamos aguardando a confirmação do pagamento.",
                                    Status = ((Base)returnReference).TransactionStatus.Code,
                                    Message = ((Base)returnReference).TransactionStatus.Name,
                                    CardNumber = JObject.Parse(JsonConvert.SerializeObject(((Transaction<object>)returnReference).PaymentObject))["CardNumber"]?.Value<string>(),
                                    Brand = JObject.Parse(JsonConvert.SerializeObject(((Transaction<object>)returnReference).PaymentObject))["Brand"]["Code"]?.Value<string>(),
                                    Installments = JObject.Parse(JsonConvert.SerializeObject(((Transaction<object>)returnReference).PaymentObject))["Installments"]?.Value<string>(),
                                };
                            case "3":
                                return new CheckoutResponse
                                {
                                    IdTransaction = ((Base)returnReference).Id,
                                    Token = JObject.Parse(JsonConvert.SerializeObject(((Transaction<object>)returnReference)))["Token"]?.ToString(),
                                    Description = "O seu pagamento foi autorizado pela operadora do cartão de crédito.",
                                    Status = ((Base)returnReference).TransactionStatus.Code,
                                    Message = ((Base)returnReference).TransactionStatus.Name,
                                    CardNumber = JObject.Parse(JsonConvert.SerializeObject(((Transaction<object>)returnReference).PaymentObject))["CardNumber"]?.Value<string>(),
                                    Brand = JObject.Parse(JsonConvert.SerializeObject(((Transaction<object>)returnReference).PaymentObject))["Brand"]["Code"]?.Value<string>(),
                                    Installments = JObject.Parse(JsonConvert.SerializeObject(((Transaction<object>)returnReference).PaymentObject))["Installments"]?.Value<string>(),
                                };
                            case "6":
                                return new CheckoutResponse
                                {
                                    IdTransaction = ((Base)returnReference).Id,
                                    Token = JObject.Parse(JsonConvert.SerializeObject(((Transaction<object>)returnReference)))["Token"]?.Value<string>(),
                                    Description = "O pagamento foi devolvido integralmente ao comprador.",
                                    Status = ((Base)returnReference).TransactionStatus.Code,
                                    Message = ((Base)returnReference).TransactionStatus.Name,
                                    CardNumber = JObject.Parse(JsonConvert.SerializeObject(((Transaction<object>)returnReference).PaymentObject))["CardNumber"]?.Value<string>(),
                                    Brand = JObject.Parse(JsonConvert.SerializeObject(((Transaction<object>)returnReference).PaymentObject))["Brand"]["Code"]?.Value<string>(),
                                    Installments = JObject.Parse(JsonConvert.SerializeObject(((Transaction<object>)returnReference).PaymentObject))["Installments"]?.Value<string>()
                                };
                            case "8":
                                return new CheckoutResponse
                                {
                                    IdTransaction = ((Base)returnReference).Id,
                                    Token = JObject.Parse(JsonConvert.SerializeObject(((Transaction<object>)returnReference)))["Token"]?.Value<string>(),
                                    Description = "Essa operação foi recusada pela operadora do cartão de crédito.",
                                    Status = ((Base)returnReference).TransactionStatus.Code,
                                    Message = ((Base)returnReference).TransactionStatus.Name,
                                    CardNumber = JObject.Parse(JsonConvert.SerializeObject(((Transaction<object>)returnReference).PaymentObject))["CardNumber"]?.Value<string>(),
                                    Brand = JObject.Parse(JsonConvert.SerializeObject(((Transaction<object>)returnReference).PaymentObject))["Brand"]["Code"]?.Value<string>(),
                                    Installments = JObject.Parse(JsonConvert.SerializeObject(((Transaction<object>)returnReference).PaymentObject))["Installments"]?.Value<string>()
                                };
                        }
                    }
                }
                return null;
            }
        }

        /// <summary>
        /// Geração de uma transação por Boleto Bancário.
        /// </summary>
        /// <param name="transaction">Objeto com base na classe Transaction<T>, do tipo CryptoCoin.</param>
        /// <returns></returns>
        public object CryptoCurrency(object transaction)
        {
            try
            {
                var response = Client.Post("v2/Payment", transaction);

                var responseObj = JsonConvert.DeserializeObject<Response<CheckoutResponse>>(response);
                if (responseObj.HasError)
                    throw new Safe2PayException(responseObj.ErrorCode, responseObj.Error);

                return responseObj.ResponseDetail;
            }
            catch (AggregateException ex)
            {
                if (ex.InnerException is TaskCanceledException)
                {
                    var transactionRequest = new TransactionRequest(configAux);
                    var returnReference = transactionRequest.ListByReference(((Base)transaction).Reference);

                    if (returnReference != null && ((List<Transaction<object>>)returnReference).Count > 0)
                    {
                        returnReference = ((List<Transaction<object>>)returnReference)[0];
                        var symbol = JObject.Parse(JsonConvert.SerializeObject(((Transaction<object>)returnReference).PaymentObject))["Symbol"]?.ToString();
                        switch (symbol)
                        {
                            case "BTC":
                                return new CheckoutResponse
                                {
                                    IdTransaction = ((Base)returnReference).Id,
                                    Status = ((Base)returnReference).TransactionStatus.Code,
                                    Message = ((Base)returnReference).TransactionStatus.Name,
                                    Description = "Estamos aguardando a transferência do valor em " + symbol + ". Após a transferência, o pagamento pode levar até 15 minutos para ser compensado.",
                                    QrCode = JObject.Parse(JsonConvert.SerializeObject(((Transaction<object>)returnReference).PaymentObject))["QrCode"]?.ToString(),
                                    Symbol = JObject.Parse(JsonConvert.SerializeObject(((Transaction<object>)returnReference).PaymentObject))["Symbol"]?.ToString(),
                                    AmountBTC = JObject.Parse(JsonConvert.SerializeObject(((Transaction<object>)returnReference).PaymentObject))["Amount"].Value<decimal>(),
                                    WalletAddress = JObject.Parse(JsonConvert.SerializeObject(((Transaction<object>)returnReference).PaymentObject))["WalletAddress"]?.Value<string>(),
                                };
                            case "LTC":
                                return new CheckoutResponse
                                {
                                    IdTransaction = ((Base)returnReference).Id,
                                    Status = ((Base)returnReference).TransactionStatus.Code,
                                    Message = ((Base)returnReference).TransactionStatus.Name,
                                    QrCode = JObject.Parse(JsonConvert.SerializeObject(((Transaction<object>)returnReference).PaymentObject))["QrCode"]?.ToString(),
                                    Symbol = JObject.Parse(JsonConvert.SerializeObject(((Transaction<object>)returnReference).PaymentObject))["Symbol"]?.ToString(),
                                    AmountLTC = JObject.Parse(JsonConvert.SerializeObject(((Transaction<object>)returnReference).PaymentObject))["Amount"].Value<decimal>(),
                                    WalletAddress = JObject.Parse(JsonConvert.SerializeObject(((Transaction<object>)returnReference).PaymentObject))["WalletAddress"]?.Value<string>(),

                                };
                            case "BCH":
                                return new CheckoutResponse
                                {
                                    IdTransaction = ((Base)returnReference).Id,
                                    Status = ((Base)returnReference).TransactionStatus.Code,
                                    Message = ((Base)returnReference).TransactionStatus.Name,
                                    QrCode = JObject.Parse(JsonConvert.SerializeObject(((Transaction<object>)returnReference).PaymentObject))["QrCode"]?.ToString(),
                                    Symbol = JObject.Parse(JsonConvert.SerializeObject(((Transaction<object>)returnReference).PaymentObject))["Symbol"]?.ToString(),
                                    AmountBCH = JObject.Parse(JsonConvert.SerializeObject(((Transaction<object>)returnReference).PaymentObject))["Amount"].Value<decimal>(),
                                    WalletAddress = JObject.Parse(JsonConvert.SerializeObject(((Transaction<object>)returnReference).PaymentObject))["WalletAddress"]?.Value<string>(),

                                };
                        }
                    }
                }
                return null;
            }
        }

        /// <summary>
        /// Geração de uma transação por Boleto Bancário.
        /// </summary>
        /// <param name="transaction">Objeto com base na classe Transaction<T>, do tipo DebitCard.</param>
        /// <returns></returns>
        public object DebitCard(object transaction)
        {
            try
            {
                var response = Client.Post("v2/Payment", transaction);

                var responseObj = JsonConvert.DeserializeObject<Response<CheckoutResponse>>(response);
                if (responseObj.HasError)
                    throw new Safe2PayException(responseObj.ErrorCode, responseObj.Error);

                return responseObj.ResponseDetail;
            }
            catch (AggregateException ex)
            {
                if (ex.InnerException is TaskCanceledException)
                {
                    var transactionRequest = new TransactionRequest(configAux);
                    var returnReference = transactionRequest.ListByReference(((Base)transaction).Reference);

                    if (returnReference != null && ((List<Transaction<object>>)returnReference).Count > 0)
                    {
                        returnReference = ((List<Transaction<object>>)returnReference)[0];
                        var status = ((Base)returnReference).TransactionStatus.Code;
                        switch (status)
                        {
                            case "1":
                                return new CheckoutResponse
                                {
                                    IdTransaction = ((Base)returnReference).Id,
                                    Token = JObject.Parse(JsonConvert.SerializeObject(((Transaction<object>)returnReference)))["Token"]?.Value<string>(),
                                    Description = "Para finalizar a operação, você deve concluir a operação no ambiente bancário.",
                                    Status = ((Base)returnReference).TransactionStatus.Code,
                                    Message = ((Base)returnReference).TransactionStatus.Name,
                                    CardNumber = JObject.Parse(JsonConvert.SerializeObject(((Transaction<object>)returnReference).PaymentObject))["CardNumber"]?.Value<string>(),
                                    Brand = JObject.Parse(JsonConvert.SerializeObject(((Transaction<object>)returnReference).PaymentObject))["Brand"]["Code"]?.Value<string>(),
                                    AuthenticationUrl = JObject.Parse(JsonConvert.SerializeObject(((Transaction<object>)returnReference).PaymentObject))["AuthenticationUrl"]?.Value<string>(),
                                };
                            case "3":
                                return new CheckoutResponse
                                {
                                    IdTransaction = ((Base)returnReference).Id,
                                    Token = JObject.Parse(JsonConvert.SerializeObject(((Transaction<object>)returnReference)))["Token"]?.ToString(),
                                    Description = "O seu pagamento foi autorizado pela instituição financeira.",
                                    Status = ((Base)returnReference).TransactionStatus.Code,
                                    Message = ((Base)returnReference).TransactionStatus.Name,
                                    CardNumber = JObject.Parse(JsonConvert.SerializeObject(((Transaction<object>)returnReference).PaymentObject))["CardNumber"]?.Value<string>(),
                                    Brand = JObject.Parse(JsonConvert.SerializeObject(((Transaction<object>)returnReference).PaymentObject))["Brand"]["Code"]?.Value<string>(),
                                    AuthenticationUrl = JObject.Parse(JsonConvert.SerializeObject(((Transaction<object>)returnReference).PaymentObject))["AuthenticationUrl"]?.Value<string>(),
                                };
                            case "8":
                                return new CheckoutResponse
                                {
                                    IdTransaction = ((Base)returnReference).Id,
                                    Token = JObject.Parse(JsonConvert.SerializeObject(((Transaction<object>)returnReference)))["Token"]?.Value<string>(),
                                    Description = "Essa operação foi recusada pela instituição financeira que emitiu seu cartão.",
                                    Status = ((Base)returnReference).TransactionStatus.Code,
                                    Message = ((Base)returnReference).TransactionStatus.Name,
                                    CardNumber = JObject.Parse(JsonConvert.SerializeObject(((Transaction<object>)returnReference).PaymentObject))["CardNumber"]?.Value<string>(),
                                    Brand = JObject.Parse(JsonConvert.SerializeObject(((Transaction<object>)returnReference).PaymentObject))["Brand"]["Code"]?.Value<string>(),
                                    AuthenticationUrl = JObject.Parse(JsonConvert.SerializeObject(((Transaction<object>)returnReference).PaymentObject))["AuthenticationUrl"]?.Value<string>(),
                                };
                        }
                    }
                }
                return null;
            }
        }

        /// <summary>
        /// Geração de uma transação por Transferência Bancária.
        /// </summary>
        /// <param name="transferRegister">Objeto com base na classe TransferRegisterLot.</param>
        /// <returns></returns>
        public object Transfer(object transferRegister)
        {
            var response = Client.Post("v2/Transfer", transferRegister);

            var responseObj = JsonConvert.DeserializeObject<Response<CheckoutResponse>>(response);
            if (responseObj.HasError)
                throw new Safe2PayException(responseObj.ErrorCode, responseObj.Error);

            return responseObj.ResponseDetail;
        }
    }
}