using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Safe2Pay.Core
{
    internal class Client : IDisposable
    {
        private readonly HttpClient _client;

        private Client(string baseUrl)
        {
            _client = new HttpClient
            {
                BaseAddress = new Uri(baseUrl), 
                Timeout = new TimeSpan(0, 0, 0, 15)
            };
            
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _client.DefaultRequestHeaders.Add("X-API-KEY", Config.GetToken());
        }

        private static Client _paymentClient;
        private static Client _mainClient;

        public static Client Create(bool payment)
        {
            if (!payment)
            {
                _mainClient = _mainClient ?? new Client("https://api.safe2pay.com.br/v2/");
                return _mainClient;
            }

            _paymentClient = _paymentClient ?? new Client("https://payment.safe2pay.com.br/v2/");
            return _paymentClient;
        }

        public void Dispose() => _client.Dispose();

        //Serializar objeto de envio para JSON

        private static readonly JsonSerializerSettings settings = new JsonSerializerSettings
            { 
                NullValueHandling = NullValueHandling.Ignore, 
                DefaultValueHandling = DefaultValueHandling.Ignore
            };
        
        private static StringContent Serialize(object data)
            => new StringContent(JsonConvert.SerializeObject(data, settings), Encoding.UTF8, "application/json");

        //Chamadas síncronas

        public string Get(string url) =>
            _client.GetAsync(url).Result.Content.ReadAsStringAsync().Result;

        public string Post(string url, object data) =>
            _client.PostAsync(url, Serialize(data)).Result.Content.ReadAsStringAsync().Result;

        public string Put(string url, object data) =>
            _client.PutAsync(url, Serialize(data)).Result.Content.ReadAsStringAsync().Result;

        public string Delete(string url) =>
            _client.DeleteAsync(url).Result.Content.ReadAsStringAsync().Result;

        //Chamadas assíncronas

        public async Task<HttpResponseMessage> GetAsync(string url) =>
            await _client.GetAsync(url).ConfigureAwait(false);

        public async Task<HttpResponseMessage> PostAsync(string url, object data) =>
            await _client.PostAsync(url, Serialize(data)).ConfigureAwait(false);

        public async Task<HttpResponseMessage> PutAsync(string url, object data) =>
            await _client.PutAsync(url, Serialize(data)).ConfigureAwait(false);

        public async Task<HttpResponseMessage> DeleteAsync(string url) =>
            await _client.DeleteAsync(url).ConfigureAwait(false);
    }
}