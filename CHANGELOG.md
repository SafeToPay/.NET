## Changelog

Todas as mudanças e atualizações relevantes serão listadas neste documento, assim como uma previsão das funcionalidades que serão implementadas em novas versões.

#### Planejado para a próxima versão

- [ ] **Exemplos de uso de todos os métodos disponíveis na biblioteca**;
- [ ] Refinamento no tratamento das respostas de todos os métodos;
- [ ] Tratamento customizado de exceções;
- [ ] Tratamento para quando a resposta excede o tempo limite de timeout.

#### [1.0.8] - 26, Jul, 2019

- Adicionada a classe `RetryHandler`, com a a utilização da biblioteca Polly, finalidade de tornar o HttpClient mais resiliente e ter um melhor recurso para o tratamento de falhas das chamadas.

#### [1.0.7] - 26, Jul, 2019

- Ajustes de nomenclatura de classes e métodos para fins de padronização;
- Inclusão de classes para gestão de Planos (`PlanRequest` e `PlanResponse`) e Adesões (`SubscriptionRequest` e `SubscriptionResponse`);
- Separação do método de tokenização de dados de cartão de crédito para a classe `TokenRequest`;
- Inclusão do método `Resend` em `InvoiceRequest` para o reenvio de solicitações de cobrança;
- Inclusão do método `ListByReference` em `TransactionRequest` para o consulta de transações pela referência;
- Pequenos ajustes.

#### [1.0.4 - 1.0.6] - 16, Jul, 2019

- Retirada da necessidade do envio da propriedade `IsSandbox`  das configurações;
- Padronizações em geral, namespaces corrigidos e definições;
- Inclusão da classe `Transfer`, para gestão de transferências bancárias.

#### [1.0.2 - 1.0.3] - 12, Jul, 2019

- Remoção dos métodos estáticos;
- `Account` para interações relacionadas à conta-corrente e dados bancários;
- `Marketplace` para gestão de subcontas;
- `Sales`, de gestão de solicitações de cobrança, renomeada para `Invoice`  para fins de padronização;
- `Transactions`, para interações com transações, renomeada para `Transaction`.

#### [1.0.0 - 1.0.1] - 9, Jul, 2019

- Versão inicial da Biblioteca de Integração em C#;
- `Config` para os dados de autenticação na API e do ambiente, se Sandbox ou Produção;
- Métodos para a geração de transações disponíveis na classe `Checkout`;
- Métodos para gestão de solicitações de cobrança em `Sales`;
- Métodos para interações com transações em `Transactions`.