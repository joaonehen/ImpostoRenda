# Avaliação HBSIS
## Cenário
Digitar o CPF, nome do contribuinte, número de dependentes e renda bruta mensal de cada contribuinte.
Após encerrar a entrada dos contribuintes, deve solicitar o valor do Salário Mínimo e então calcular e escrever o IR de cada contribuinte, em ordem crescente de valor de IR e ordem crescente de nome.
**Regras para cálculo do IR do contribuinte**:
Para cada contribuinte será concedido um desconto de 5% do valor Salário Mínimo por dependente. Os valores da alíquota para cálculo do imposto são:

Renda Líquida | Alíquota
--------- | ------
até 2 salários mínimos | isento
acima de 2 até 4 salários mínimos | 7,5%
acima de 4 até 5 salários mínimos | 15%
acima de 5 até 7 salários mínimos | 22,5%
acima de 7 salários mínimos | 27,5%

**Renda Líquida = Renda Bruta - Descontos por Dependente;**

## Requisitos
* Os Contribuintes devem ser persistidos em um banco de dados.
* O frontend deve ser escrito em Javascript/html (framework JS fica a critério do desenvolvedor)
* Deve ser utilizado uma interface REST para se comunicar com o frontend (o framework de REST fica a critério do desenvolvedor)
* Para persistência dos dados deve ser utilizado algum framework de ORM, caso o banco escolhido seja NOSql desconsidere este requisito.
* Não é necessário editar/excluir.
## Observações
* O Backend deve ser escrito em .NET
* O Frontend deve ser escrito em HTML/JS
* Usabilidade, UX do frontend NÃO serão critérios avaliado.
* É obrigatório o uso de REST para resolver o problema.
* Testes unitários, divisão das camadas, modelagem, design patterns são fatores que serão levados em conta.

## Sobre o projeto.

O projeto IR tem o intuito de demonstrar uma aplicação em .Net Core para realizar calculo de imposto de renda.

### Tecnologias
* ASP.NET Core 2.0 (utilizando .NET Core)
* ASP.NET WebApi Core
* Vue.js 2.0
* AutoMapper
* MediatR (possibilitará Event Sourcing)
* FluentValidator
* Entity Framework Core 2.0
* FluentAssertions
* NSubstitute

### Arquitetura
* DDD (Domain Driven Design) utilizando arquitetura em camadas.
* Generic Repository
* Repository
* Unit of Work
* SOLID
* Clean Code
* Commands e Services (possibilitará aplicação de CQRS)