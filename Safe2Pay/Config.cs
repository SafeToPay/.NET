namespace Safe2Pay
{
    public class Config
    {
        public Config(string token, string secretKey, int timeout = 60)
        {
            Token = token;
            SecretKey = secretKey;
            Timeout = timeout;
        }

        public string Token { get; private set; }
        public string SecretKey { get; private set; }
        public double Timeout { get; private set; }
    }
}