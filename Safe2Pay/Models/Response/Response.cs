using System.Net;

namespace Safe2Pay.Models
{
    public class Response : IResponse
    {
        public HttpStatusCode StatusCode { get; set; }
        public bool HasError => Error != null;
        public string ErrorCode { get; set; }
        public string Error { get; set; }
    }

    public class Response<T> : Response, IResponse<T>
    {
        public T ResponseDetail { get; set; }
    }

    public interface IResponse<T> : IResponse
    {
        T ResponseDetail { get; set; }
    }

    public interface IResponse
    {
        HttpStatusCode StatusCode { get; set; }
        bool HasError { get; }
        string ErrorCode { get; set; }
        string Error { get; set; }
    }
}