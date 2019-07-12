using System.Collections.Generic;

namespace Safe2Pay
{
    public class Response<T>
    {
        public bool HasError { get; set; }
        public string ErrorCode { get; set; }
        public string Error { get; set; }
        public T ResponseDetail { get; set; }
    }

    public class Object<T> where T : new()
    {
        public List<T> Objects { get; set; }
        public int TotalItems { get; set; }
    }
}