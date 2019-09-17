# Safe2Pay .NET SDK

![Safe2Pay](https://safe2pay.com.br/static/img/banner-github.png)

#### Biblioteca de integração em .NET para o [Safe2Pay](https://safe2pay.com.br/Safe2Pay/).

Recomendamos a utilização do pacote da galeria do NuGet, para manter-se com a versão mais atualizada da biblioteca, com todas as funcionalidades atuais e as que estão por vir!

**Compatível com:** .NET Standard 1.1+, .NET Framework 4.5+ ou .NET Core 1.0+.

## Instalação

[![NuGet version](https://img.shields.io/nuget/vpre/Safe2Pay.svg?style=flat-square)](https://www.nuget.org/packages/Safe2Pay)

Usando o .NET CLI:  
>`dotnet add package Safe2Pay`

Usando o Package Manager: 
>`Install-Package Safe2Pay`

## Utilização

A integração com a API do Safe2Pay se dá pelo modelo RESTful, enviando de forma segura e simplificada os dados pelo formato JSON. Para facilitar o envio dos dados, deve-se montar um objeto para envio baseado nos modelos disponíveis e a própria chamada do método desejado realizará o tratamento e conversão deste objeto para JSON, retornando as propriedades disponíveis.

### Configuração

Antes de iniciar a utilização da biblioteca, é necessário informar os dados básicos de autenticação na API, **não esquecendo de utilizar o Token e da Secret Key correspondentes ao ambiente definido, se Produção ou Sandbox**. 

Esta configuração está disponível inicializando a classe `Safe2Pay`, que contém todas as classes e métodos disponíveis pela biblioteca de integração.

```
Safe2Pay safe2pay = new Safe2Pay(
    token: "PREENCHA_COM_SEU_TOKEN",
    secret: "PREENCHA_COM_SUA_SECRET_KEY", //Opcional
	timeout: 30); //Opcional

var transaction = /*CONSTRUÇÃO DO OBJETO DE UMA TRANSAÇÃO COM CARTÃO DE CRÉDITO...*/

var checkout = safe2pay.Payment.Credit(transaction);
```

### Principais recursos

* Tokenização de cartão de crédito (`TokenRequest`)
* Transações (`Payment`)
    * Boleto bancário
    * Cartão de crédito 
	* Cartão de débito
    * Criptomoedas
* Carnês (`Carnet`)
    * Geração
    * Consulta e reenvio
    * Cancelamento
* Transferência Bancária (`Transfer`)
    * Geração de novos lotes de transferência
    * Consulta e listagem
* Solicitações de cobrança (`Invoice`)
    * Geração de novas solicitações
	* Consulta, cancelamento e substituição
    * Reenvio
* Conta-Corrente (`Account`)
    * Consulta de recebíveis 
	* Detalhamento e calendário de recebimentos
	* Consulta e solicitação de antecipação de recebíveis
* Gestão de Marketplace (`Marketplace`)
    * Inclusão, atualização e exclusão de subcontas
    * Consulta e listagem de subcontas

## Pagamentos / Transações

O objeto esperado para uma transação deve seguir o modelo abaixo:

```
var transaction = new Transaction<object>
{
	IsSandbox = true, //Definir com base no Token utilizado
		
	PaymentMethod = new PaymentMethod { Code = "CODIGO_DA_FORMA_DE_PAGAMENTO" },
	PaymentObject = { /*CORPO DO OBJETO ESPERADO PARA A FORMA DE PAGAMENTO*/ };
	Application = "NOME_DA_SUA_APLICAÇÃO",
	Vendor = "VENDEDOR",
	Reference = "REFERÊNCIA",
	CallbackUrl = "https://callbacks.exemplo.com/api/notify",
	Customer = new Customer
	{
		Name = "Destinatário da Transação",
		Identity = "99999999999999", //CPF ou CNPJ do Destinatário
		Email = "email@empresa.com.br",
		Address = new Address
		{
			Street = "Endereço do Destinatário",
			Number = "Número 123",
			District = "Bairro",
			ZipCode = "99999999", 
			CityName = "Porto Alegre",
			StateInitials = "RS",
			CountryName = "Brasil"
		}
	},
	Products = new List<Product>
	{
		new Product {Code = "001", Description = "Produto 1", UnitPrice = 10M, Quantity = 1M},
		new Product {Code = "002", Description = "Produto 2", UnitPrice = 9.99M, Quantity = 2M},
	}
};
```

A informação da forma de pagamento é dada por meio da propriedade `Payment`, onde deve ser informado o código correspondente ao método desejado:

```
1 = Boleto bancário (`BankSlip`)
2 = Cartão de crédito (`Credit`)
3 = Criptomoedas (`CryptoCurrency`)
4 = Cartão de débito (`Debit`)
```

O retorno do envio da transação trará um status para esta. [Consulte todos os status disponíveis nesta lista](https://developers.safe2pay.com.br/reference/transaction_info).

#### Boleto Bancário

```
var bankSlip = new Transaction<BankSlip>
{
	PaymentMethod = new PaymentMethod { Code = "1" },
	PaymentObject = new BankSlip
	{
		//OBRIGATÓRIO 
		DueDate = new DateTime(2019, 07, 31), //Data de vencimento do Boleto Bancário
		
		//OPCIONAIS
		Message = new List<string> { "Mensagem 1", "Mensagem 2" }, //Mensagens (máx. 10) que serão impressas no Boleto
		Instruction = "Instrução", //Mensagem na área de "Instruções"
		CancelAfterDue = true, //Se o boleto deve ser cancelado após a data de vencimento
		IsEnablePartialPayment = false, //Se o boleto aceita pagamento diferente do valor de registro
		InterestRate = 1m, //Valor da Taxa de Juros
		PenaltyRate = 1m, //Valor da Multa
		DaysBeforeCancel = 30 //Prazo para baixa do boleto após o vencimento
	},
	//DEMAIS DADOS DO OBJETO DA TRANSAÇÃO, CONFORME O MODELO ACIMA
};
```

O método `BankSlip` é o responsável pelo envio de uma transação com boleto e está na classe `Payment`.

```
var transaction = new Transaction<BankSlip> { /*CORPO DO OBJETO DA TRANSAÇÃO*/ };

var response = safe2pay.Payment.BankSlip(transaction);

Console.WriteLine($"Transação {response.IdTransaction} gerada com sucesso.");

Console.WriteLine($"Pagamento pendente. Copie a linha digitável para realizar o pagamento do boleto: {response.DigitableLine}");
//OU...
Console.WriteLine($"Pagamento pendente. O link para download e impressão do boleto é: {response.BankSlipUrl}");
```

#### Cartão de Crédito

Para realizar a tokenização dos dados do cartão de crédito de um cliente, deve-se usar o método `Tokenize`, em `Token`, que retorna uma string com o token gerado para posterior utilização segura em uma transação.

```
var card = new CreditCard
{
	CardNumber = "4111111111111111",
	Holder = "Titular do Cartão",
	ExpirationDate = "12/2021",
	SecurityCode = "999"
};

var response = safe2pay.Token.Tokenize(card);

Console.WriteLine($"Token '{response}' criado com sucesso!");
```

Formato do objeto de envio de uma transação por cartão de crédito:

```
var credit = new Transaction<CreditCard>
{
	PaymentMethod = new PaymentMethod { Code = "2" },
	PaymentObject = new CreditCard
	{
		//OPCIONAL - Número de parcelas
		InstallmentQuantity = 3,

		//Caso os dados do cartão já estejam tokenizados, informar apenas o token
		Token = "INFORMAR_O_CARTÃO_TOKENIZADO"
				
		//Ou os dados completos do cartão de crédito do cliente
		CardNumber = "4111111111111111",
		Holder = "Titular do Cartão",
		ExpirationDate = "12/2021",
		SecurityCode = "999"
	},
	//DEMAIS DADOS DO OBJETO DA TRANSAÇÃO, CONFORME O MODELO ACIMA
};
```

O método `Credit` é o responsável pelo envio de uma transação com cartão de crédito e está na classe `Payment`:

```
var transaction = new Transaction<CreditCard> { /*CORPO DO OBJETO DA TRANSAÇÃO*/ };

var response = safe2pay.Payment.Credit(transaction);

Console.WriteLine($"Transação {response.IdTransaction} gerada com sucesso!");

Console.WriteLine(response.Status.Equals("3")
	? $"Transação {response.IdTransaction} autorizada!"
	: $"Ocorreu um erro: {response.Message}"); // Se status != 3, exibir a mensagem com o erro ocorrido
```

Para realizar o estorno de uma transação realizada por cartão de crédito, deve-se utilizar o método `RefundCredit`, dentro da classe `Transaction`.

```
var refund = safe2pay.Transaction.RefundCredit(response.IdTransaction); //Utilizando a transação anterior como exemplo

if (refund) 
	Console.WriteLine("Estorno realizado com sucesso!");
```

#### CriptoMoedas

```
var transaction = new Transaction<Bitcoin>
{
	PaymentMethod = new PaymentMethod { Code = "3" },
	//DEMAIS DADOS DO OBJETO DA TRANSAÇÃO, CONFORME O MODELO ACIMA
};
```
Para uma transação por Bitcoin, basta informar o código do método de pagamento (`Code = "3"`). A propriedade `PaymentObject` **não é necessária**. 

O método `Bitcoin` é o responsável pelo envio de uma transação com Bitcoin e está na classe `Checkout`.

```
var transaction = new Transaction<Bitcoin> { /*CORPO DO OBJETO DA TRANSAÇÃO*/ };

var checkout = new CheckoutRequest(config);
var response = (CheckoutResponse)checkout.Bitcoin(transaction);

Console.WriteLine($"Transação {response.IdTransaction} gerada com sucesso.");

Console.WriteLine($"Pagamento pendente. Por favor, escaneie o código da imagem {response.QrCode} para realizar o pagamento!");
//OU...
Console.WriteLine($"Pagamento pendente. Por favor, realizar o envio de {response.AmountBTC} BTC para o endereço {response.WalletAddress} para completar a transação!");
```

#### Cartão de Débito

```
var debit = new Transaction<DebitCard>
{
	PaymentMethod = new PaymentMethod { Code = "4" },
	PaymentObject = new DebitCard
	{
		//Deve ser verdadeiro para a transação ser finalizada no internet banking da Instituição Bancária do cliente
		Authenticate = true,

		//Dados completos do cartão de débito do cliente
		CardNumber = "4111111111111111",
		Holder = "Titular do Cartão",
		ExpirationDate = "12/2021",
		SecurityCode = "999"
	},
	//DEMAIS DADOS DO OBJETO DA TRANSAÇÃO, CONFORME O MODELO ACIMA
};
```

O método `Debit` é o responsável pelo envio de uma transação com cartão de débito e está na classe `Checkout`:

```
var transaction = new Transaction<DebitCard> { /*CORPO DO OBJETO DA TRANSAÇÃO*/ };

var response = safe2pay.Payment.Debit(transaction);

Console.WriteLine($"Transação {response.IdTransaction} gerada com sucesso!");

Console.WriteLine($"Pagamento pendente. Por favor, acesse a página {response.AuthenticationUrl} para finalizar o pagamento através do Internet Banking de sua Instituição Bancária!");
```

Para realizar o estorno de uma transação realizada por cartão de crédito, deve-se utilizar o método `RefundDebit`, dentro da classe `Transaction`.

```
var refund = safe2pay.Transaction.RefundDebit(response.IdTransaction); //Utilizando a transação anterior como exemplo

if (refund) 
	Console.WriteLine("Estorno realizado com sucesso!");
```

## Solicitações de Cobrança / Vendas Rápidas

Na classe `Invoice` estão os métodos disponíveis pela geração e tratamento de solicitações de cobrança. **Solicitações de cobrança não podem ser geradas em Sandbox.**

O objeto para uma nova venda deve ser montado seguindo o modelo abaixo:

```
var invoice = new SingleSale
{
    Customer = new Customer
    {
        Name = "Destinatário da Cobrança",
        Identity = "99999999999", //CPF ou CNPJ do Destinatário
        Email = "email@empresa.com.br",
        Address = new Address
        {
            Street = "Endereço do Destinatário",
            Number = "Número 123",
            District = "Bairro",
            ZipCode = "99999999",
            CityName = "Porto Alegre",
            StateInitials = "RS",
            CountryName = "Brasil"
        }
    },
    Products = new List<Product>
    {
        new Product {Code = "001", Description = "Produto 1", UnitPrice = 1.99M, Quantity = 1M},
        new Product {Code = "002", Description = "Produto 2", UnitPrice = 2.99M, Quantity = 2M},
        new Product {Code = "003", Description = "Produto 3", UnitPrice = 3.99M, Quantity = 3M}
    },
    ExpirationDate = new DateTime(2019, 07, 10), //Data de expiração da cobrança
    DiscountAmount = 10, //Valor do desconto, em Reais, caso exista
    Instruction = "Solicitação de cobrança pelos produtos 1, 2 e 3.",
    PaymentMethods = new List<PaymentMethod>
    {
        new PaymentMethod { CodePaymentMethod = "1" }, //Boleto
        new PaymentMethod { CodePaymentMethod = "2" }, //Crédito
        new PaymentMethod { CodePaymentMethod = "3" }, //Bitcoin
        new PaymentMethod { CodePaymentMethod = "4" }, //Débito
    },
    DueDate = new DateTime(2019, 07, 10), //Vencimento do Boleto Bancário, caso  habilitado
    InterestAmount = 2, //Valor dos Juros do Boleto Bancário, caso  habilitado
    PenaltyAmount = 3, //Valor da Multa do Boleto Bancário, caso  habilitado
    Messages = new List<string> { "Mensagem 1", "Mensagem 2" },
    Emails = new List<string> { "email1@empresa.com.br", "email2@company.com" } //E-mails para envio da cobrança
};

var response = safe2pay.Invoice.New(invoice);

Console.WriteLine($"Solicitação {response.SingleSaleHash} gerada com sucesso!");
Console.WriteLine($"Siga o link para realizar o pagamento: {response.SingleSaleUrl} ");
```

Para realizar o cancelamento de uma solicitação de cobrança, basta realizar uma chamada para o método `Cancel`, informando o hash gerado para a solicitação desejada. A resposta será um booleano com a confirmação do cancelamento.

```
//Utilizando a resposta do método anterior como variável
var saleToCancel = "SingleSaleHash"; 

var confirmation = safe2pay.Invoice.Cancel(saleToCancel);

if (true)
	Console.WriteLine("Cobrança cancelada com sucesso!");
```

A orientação sobre a utilização da API também está disponível na documentação de referência da API, [disponível aqui]([https://developers.safe2pay.com.br/](https://developers.safe2pay.com.br/)), porém salientamos que ela se encontra em atualização para a nova versão da API e, por isso, recomendamos a utilização do [pacote da galeria do NuGet](https://www.nuget.org/packages/Safe2Pay), para que você esteja sempre com a versão mais atualizada!

Em caso de dúvidas, [ficamos à disposição em nosso formulário de contato](https://safe2pay.com.br/contato) ou diretamente pelo e-mail <integracao@safe2pay.com.br>.