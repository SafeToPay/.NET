using System;

namespace Safe2Pay.Core
{
    public class Safe2PayException : Exception
    {
        public Safe2PayException(string error) : base(error)
        {
            //...
        }

        public Safe2PayException(string code, string error) : base($"{code} - {error}")
        {
            //...
        }

        public Safe2PayException(string error, Exception innerException) : base(error, innerException)
        {
            //...
        }
    }
}