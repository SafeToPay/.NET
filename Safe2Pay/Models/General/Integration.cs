namespace Safe2Pay.Models
{
    public class Integration
    {
        public string Token { get; set; }
        public object TokenSandbox { get; set; }
        public string SecretKey { get; set; }
        public object SecretKeySandbox { get; set; }
    }
}