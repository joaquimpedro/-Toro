# ToroAPI


Projeto de WebAPI, escrito em .Net 5, implementado usando conceitos de _Clean Archtecture_. A lógica foi escrita se baseando no padrão CQRS.
Para ajudar, foi escolhido o MediatR e simplificar a implementação do padrão.

O projeto foi definido nas seguintes camadas:

- Api
  Disponibiliza end-points para listagem e compra de ações

- Application
  Camada onde está implementado a lógica do négocio. A mesma pode ser reutilizada em jobs, schedulers, outras aplicações.

- Domain
   Camada que define as regras do dominio
- Persistence
  Camada que provê acesso ao db/dados externos
  _Não foi implementado acesso ao db. A ideia era apenas simular._ 
- Tests
  Camada que define os testes unitários.
  Os testes foram escritos pros controllers, repositorios, e handlers

### Requisitos
- .Net5
- VS 2019
- VSCode
- Docker

### Executando

#### Docker
O projeto está configurado pra rodar no docker usando um container linux.
_Para alternar o Docker entre Linux e Windows, utilize o seguinte comando:_
    
    & $Env:ProgramFiles\Docker\Docker\DockerCli.exe -SwitchDaemon

Após a execução a API estará disponível na url [https://localhost:5001/api/trends](https://localhost:5001/api/trends)


#### Local

Executar ``dotnet run`` no diretório do projeto **Toro.Api** irá disponibilizar o serviço na URL [https://localhost:5001/api/trends](https://localhost:5001/api/trends)

#### Testes

Pode ser executado pela IDE ou atráves do comando ``dotnet run`` no diretório do projeto **Toro.Tests**

### Bibliotecas utilizadas


#### Projeto
- MediatR
- MediatR.Extensions.Microsoft.DependencyInjection

#### Testes
- Moq
- xunit
  