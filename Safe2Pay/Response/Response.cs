using System.Net;

namespace Safe2Pay.Response
{
    internal class Response<T>  
    {
        public T ResponseDetail { get; set; }

        public bool HasError => Error != null;
        public string ErrorCode { get; set; }
        public string Error { get; set; }
        public HttpStatusCode StatusCode { get; set; }
    }
}