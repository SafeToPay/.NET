namespace Safe2Pay
{
    public class Config
    {
        public Config(string token, string secretKey)
        {
            Token = token;
            SecretKey = secretKey;
        }

        public string Token { get; private set; }
        public string SecretKey { get; private set; }
    }
}