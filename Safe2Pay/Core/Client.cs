using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Safe2Pay.Response;

namespace Safe2Pay.Core
{
    internal class Client
    {
        private static HttpClient _client;
        private static Uri _baseUri;

        internal Client(Config config)
        {
            _client = new HttpClient(new HttpClientHandler())
                {BaseAddress = _baseUri, Timeout = TimeSpan.FromSeconds(config.Timeout)};

            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _client.DefaultRequestHeaders.Add("X-API-KEY", config.Token);
        }

        private static HttpClient CreateClient(bool payment)
        {
            _baseUri = payment
                ? new Uri("https://payment.safe2pay.com.br/")
                : new Uri("https://api.safe2pay.com.br/");

            return _client;
        }

        private static async Task<T> Send<T>(HttpMethod method, bool payment, string endpoint, object data = null)
        {
            var client = CreateClient(payment);

            var request = new HttpRequestMessage(method, _baseUri + endpoint);

            if (data != null)
            {
                var json = JsonConvert.SerializeObject(data,
                    new JsonSerializerSettings
                    {
                        DefaultValueHandling = DefaultValueHandling.Ignore,
                        NullValueHandling = NullValueHandling.Ignore
                    });

                request.Content = new StringContent(json, Encoding.UTF8, "application/json");
            }

            var response = await client.SendAsync(request).ConfigureAwait(false);
                response.EnsureSuccessStatusCode();

            return await Process<T>(response);
        }

        private static async Task<T> Process<T>(HttpResponseMessage response)
        {
            var content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            T result = default;

            if (response.Content.Headers.ContentType.MediaType == "application/json")
            {
                var responseObj = JsonConvert.DeserializeObject<Response<T>>(content);

                if (responseObj != null && responseObj.HasError)
                    throw new Safe2PayException(responseObj.ErrorCode, responseObj.Error);

                result = responseObj.ResponseDetail;
            }

            return result;
        }

        internal static async Task<T> Get<T>(bool payment, string url) => await Send<T>(HttpMethod.Get, payment, url).ConfigureAwait(false);

        internal static async Task<T> Post<T>(bool payment, string url, object data) => await Send<T>(HttpMethod.Post, payment, url, data).ConfigureAwait(false);

        internal static async Task<T> Put<T>(bool payment, string url, object data) => await Send<T>(HttpMethod.Put, payment, url, data).ConfigureAwait(false);

        internal static async Task<T> Delete<T>(bool payment, string url) => await Send<T>(HttpMethod.Delete, payment, url).ConfigureAwait(false);
    }
}