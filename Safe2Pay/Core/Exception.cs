using System;

namespace Safe2Pay.Core
{
    internal class Safe2PayException : Exception
    {
        private string Code { get; }
        private string Error { get; }

        public Safe2PayException() : base() { }

        public Safe2PayException(string message) : base(message) { }

        public Safe2PayException(string code, string error) : base($"{code} - {error}")
        {
            Code = code;
            Error = error;
        }
    }
}