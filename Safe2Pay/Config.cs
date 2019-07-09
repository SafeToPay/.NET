namespace Safe2Pay
{
    public static class Config
    {
        private static bool IsSandbox { get; set; }
        private static string Token { get; set; }
        private static string TokenSandbox { get; set; }
        private static string SecretKey { get; set; }
        private static string SecretKeySandbox { get; set; }

        private static bool IsSandBox() => IsSandbox;
        private static void SetSandBox() => IsSandbox = true;
        private static void SetProduction() => IsSandbox = false;

        public static string GetToken() => !IsSandBox() ? Token : TokenSandbox;
        
        public static string GetSecret() => !IsSandBox() ? SecretKey : SecretKeySandbox;
        
        /// <summary>
        /// Configuração para poder enviar os dados de sua empresa nas chamadas para a API.
        /// </summary>
        /// <param name="token">Token de integração gerado, disponível na área de Integração do painel administrativo.</param>
        /// <param name="secret">Secret Key, disponível na área de Integração do painel administrativo.</param>
        /// <param name="isSandbox">Valor booleano para definir se os dados enviados serão em Sandbox ou não. USAR O TOKEN e SECRET KEY correspondentes.</param>
        public static void SetEnvironment(string token, string secret, bool isSandbox)
        {
            if (!isSandbox)
            {
                SetProduction(); 
                Token = token;
                SecretKey = secret;
            }
            else
            {
                SetSandBox(); 
                TokenSandbox = token;
                SecretKeySandbox = secret;
            }
        }
    }
}