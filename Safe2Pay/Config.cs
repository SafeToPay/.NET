namespace Safe2Pay
{
    public class Config
    {
        public Config(string token, string secretKey, int timeout = 1)
        {
            Timeout = timeout;
            Token = token;
            SecretKey = secretKey;
        }

        public string Token { get; private set; }
        public string SecretKey { get; private set; }
        public int Timeout { get; private set; }
    }
}