using System;
using Newtonsoft.Json;
using Safe2Pay.Core;

namespace Safe2Pay
{
    /// <summary>
    /// <para>Usada para a geração de novas transações.</para>
    /// Deve ser utilizada para o envio (POST) de um objeto com base nas opções de pagamento disponíveis:
    /// Boleto Bancário (1), Cartão de Crédito (2), BitCoin (3), Cartão de Débito (4) ou Transferência Bancária (5).
    /// </summary>
    public class Checkout 
    {
        private static readonly Client Client = Client.Create(true);
        
        /// <summary>
        /// Método para gerar uma nova transação por Boleto Bancário.
        /// </summary>
        /// <param name="data">Objeto com base no modelo BankSlip, da classe Transaction.</param>
        /// <returns></returns>
        public static object BankSlip(object data)
        {
            var response = Client.Post("Payment", data);
                
            var responseObj = JsonConvert.DeserializeObject<Response<CheckoutResponse>>(response);
            if (responseObj.HasError) 
                throw new Exception($"Erro {responseObj.ErrorCode} - {responseObj.Error}");

            return responseObj.ResponseDetail;
        }

        /// <summary>
        /// Método para gerar uma nova transação por Carnê/Fatura.
        /// </summary>
        /// <param name="data">Objeto com base no modelo Carnet, da classe Transaction.</param>
        /// <returns></returns>
        public static object Carnet(object data)
        {
            var response = Client.Post("Carnet", data);
                
            var responseObj = JsonConvert.DeserializeObject<Response<CheckoutResponse>>(response);
            if (responseObj.HasError) 
                throw new Exception($"Erro {responseObj.ErrorCode} - {responseObj.Error}");

            return responseObj.ResponseDetail;
        }

        /// <summary>
        /// Método para gerar uma nova transação por Carnê/Fatura em lote.
        /// </summary>
        /// <param name="data">Objeto com base no modelo CarnetLot, da classe Transaction.</param>
        /// <returns></returns>
        public static object CarnetLot(object data)
        {
            var transactionCompressed = Utils.Compress(Utils.Serialize(data));
            var carnetLot = new CarnetLot { JsonGzip = transactionCompressed };
            
            var response = Client.Post("CarnetAsync", carnetLot);
            //var objDecompressed = Utils.Decompress(response);

            var responseObj = JsonConvert.DeserializeObject<Response<CheckoutResponse>>(response);
            if (responseObj.HasError) 
                throw new Exception($"Erro {responseObj.ErrorCode} - {responseObj.Error}");

            return responseObj.ResponseDetail;
        }

        /// <summary>
        /// Método para gerar uma nova transação por Cartão de Crédito.
        /// </summary>
        /// <param name="data">Objeto com base no modelo CreditCard, da Transaction.</param>
        /// <returns></returns>
        public static object Credit(object data)
        {
            var response = Client.Post("Payment", data);
            
            var responseObj = JsonConvert.DeserializeObject<Response<CheckoutResponse>>(response);
            if (responseObj.HasError) 
                throw new Exception($"Erro {responseObj.ErrorCode} - {responseObj.Error}");

            return responseObj.ResponseDetail;
        }

        /// <summary>
        /// Método para tokenizar os dados de um cartão de crédito.
        /// </summary>
        /// <param name="data">Objeto com base no modelo CreditCard.</param>
        /// <returns></returns>
        public static object Tokenize(object data)
        {
            var response = Client.Post("Token", data);
            
            var responseObj = JsonConvert.DeserializeObject<Response<CheckoutResponse>>(response);
            if (responseObj.HasError) 
                throw new Exception($"Erro {responseObj.ErrorCode} - {responseObj.Error}");

            return responseObj.ResponseDetail;
        }

        /// <summary>
        /// Método para gerar uma nova transação por Cartão de Débito.
        /// </summary>
        /// <param name="data">Objeto com base no modelo DebitCard, da Transaction.</param>
        /// <returns></returns>
        public static object Debit(object data)
        {
            var response = Client.Post("Payment", data);
            
            var responseObj = JsonConvert.DeserializeObject<Response<CheckoutResponse>>(response);
            if (responseObj.HasError) 
                throw new Exception($"Erro {responseObj.ErrorCode} - {responseObj.Error}");

            return responseObj.ResponseDetail;
        }

        /// <summary>
        /// Método para gerar uma nova transação por Bitcoin.
        /// </summary>
        /// <param name="data">Objeto com base no modelo Bitcoin, da Transaction.</param>
        /// <returns></returns>
        public static object Bitcoin(object data)
        {
            var response = Client.Post("Payment", data);
            
            var responseObj = JsonConvert.DeserializeObject<Response<CheckoutResponse>>(response);
            if (responseObj.HasError) 
                throw new Exception($"Erro {responseObj.ErrorCode} - {responseObj.Error}");

            return responseObj.ResponseDetail;
        }
    }
}