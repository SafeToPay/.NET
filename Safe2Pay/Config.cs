namespace Safe2Pay
{
    public class Config
    {
        /// <summary>
        /// Configuração para poder enviar os dados de sua empresa nas chamadas para a API.
        /// </summary>
        /// <param name="token">Token de integração gerado, disponível na área de Integração do painel administrativo.</param>
        /// <param name="secretKey">Secret Key, disponível na área de Integração do painel administrativo.</param>
        /// <param name="timeout">Valor inteiro para definir o tempo em segundos de timeout do client. Valor default 60 segundos.</param>
        public Config(string token, string secretKey, int timeout = 60)
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