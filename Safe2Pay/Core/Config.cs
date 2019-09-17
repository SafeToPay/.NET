using Safe2Pay.Core;

namespace Safe2Pay
{
    public class Config
    {
        public string Token { get; }
        public string SecretKey { get; }
        public int Timeout { get; }

        public Config(string token, string secret = null, int timeout = 60)
        {
            if (string.IsNullOrEmpty(token)) 
                throw new Safe2PayException("O Token é obrigatório!");

            if (timeout < 15) 
                throw new Safe2PayException("O tempo definido para timeout é muito baixo! É recomendável mantê-lo acima de pelo menos 15 segundos.");

            Token = token;
            SecretKey = secret;
            Timeout = timeout;
        }
    }
}