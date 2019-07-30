namespace Safe2Pay.Models
{
    public class Safe2PayException : System.Exception
    {
        public string Code { get; private set; }
        public string Error { get; private set; }
        public Safe2PayException(string code, string error) : base($"{code} - {error}") {}
        public override string ToString() => $"{Code} - {Error}";
    }
}
