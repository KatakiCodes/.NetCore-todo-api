# .NETCORE-TODO-API

## Sobre o Projeto

Este projeto consiste em uma API desenvolvida com o objetivo de gerênciar tarefas por meio de registo de tarefas, filtragens e ações como: Marcar como conluida e marcar como não concluida

## Objetivo

Projeto desenvolvido para uso pessoal, assim como para outros interessados em gerênciar tarefas de forma simples, ou até mesmo colocar em prática conhecimentos sobre desenvolvimento web ou até mesmo outras formas de estudo

## Outros Conhecimentos Postos em Prática

Com este projeto foi possível por em prática conceitos como:

- Arquitetura limpa
  
  Embora que o nível dimensional do projeto sugira padrões arquiteturais ou uma extruturação mais simples, usei a arquitetura limpa para fins de estudo e obtênção de conhecimento prático sobre o assunto

- Padrão CQRS
  
  Assim como a arquitetura limpa o padrão CQRS foi colocado em prática para fins de estudo e conhecimento prático sobre o assunto, pois por mais pequeno que o projeto venha a ser, conceitos como validações, separação de responsabilidades quanto a escrita e leitura de dados e o desacoplamento entre camadas veem sempre garantir o crescimento ou incrementação de funcionalidades novas na aplicação de forma saudável.

- Autenticação via Token e Google (Jwt bearer)

  Neste projeto usou-se o conceito de Autenticação e autorização por meio da implementação do JwtBearer e o google.auth.api para validar tokens provenientes de Autenticação com o google
  
## Como Executar a API (.NET 9 e ASP.NET Core)

A seguir, estão os passos e comandos necessários para executar uma API .NET 9 e ASP.NET Core recém baixada do GitHub em seu ambiente local.

### Pré-requisitos

* **SDK do .NET 9:** Certifique-se de ter o SDK do .NET 9 instalado em sua máquina. Você pode baixá-lo no site oficial da Microsoft.

### Passos e Comandos

1.  **Navegue até o diretório do projeto:** Abra o terminal ou prompt de comando e navegue até a pasta onde os arquivos do projeto foram clonados do GitHub. Por exemplo:

    ```bash
    cd .NETCORE-TODO-API
    ```

2.  **Restaure as dependências NuGet:** Este comando baixa todas as bibliotecas e pacotes necessários definidos no arquivo `.csproj` do seu projeto.

    ```bash
    dotnet restore
    ```

3.  **Construa o projeto:** Este comando compila o código da sua aplicação.

    ```bash
    dotnet build
    ```

4.  **Execute a aplicação:** Este comando inicia o servidor web Kestrel (servidor padrão do ASP.NET Core) e hospeda sua API.

    ```bash
    dotnet run
    ```

    Você deverá ver uma saída no terminal indicando que a aplicação está rodando e em qual(is) URL(s) ela está acessível (geralmente `http://localhost:5xxx`).


