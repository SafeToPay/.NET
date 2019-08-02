using System;

namespace Safe2Pay
{
    public class Safe2PayException : Exception
    {
        public string Code { get; private set; }
        public string Error { get; private set; }
        public Safe2PayException(string code, string error) : base($"{code} - {error}") {}
        public override string ToString() => $"{Code} - {Error}";
    }
}
