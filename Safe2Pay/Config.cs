namespace Safe2Pay
{
    public class Config
    {
        /// <summary>
        /// Configuração para poder enviar os dados de sua empresa nas chamadas para a API.
        /// </summary>
        /// <param name="token">Token de integração gerado, disponível na área de Integração do painel administrativo.</param>
        /// <param name="secretKey">Secret Key, disponível na área de Integração do painel administrativo.</param>
        /// <param name="isSandbox">Valor booleano para definir se os dados enviados serão em Sandbox ou não. USAR O TOKEN e SECRET KEY correspondentes.</param>
        /// <param name="timeout">Valor inteiro para definir o tempo em segundos de timeout do client. Valor default 60 segundos.</param>
        public Config(string token, string secretKey, bool isSandbox, int timeout = 15)
        {
            Timeout = timeout;

            if (isSandbox)
            {
                TokenSandbox = token;
                SecretKeySandbox = secretKey;
                SetSandbox();
            }
            else
            {
                Token = token;
                SecretKey = secretKey;
                SetProduction();
            }
        }

        private bool IsSandbox { get; set; }
        private string Token { get; set; }
        private string TokenSandbox { get; set; }
        private string SecretKey { get; set; }
        private string SecretKeySandbox { get; set; }

        public string GetToken() => !IsSandBox() ? Token : TokenSandbox;
        public string GetSecret() => !IsSandBox() ? SecretKey : SecretKeySandbox;
        public bool IsSandBox() => IsSandbox;
        private void SetSandbox() => IsSandbox = true;
        private void SetProduction() => IsSandbox = false;

        private int Timeout { get; set; }

        public int GetTimeout() => Timeout;
    }
}