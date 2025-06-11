# BALTA-7198-TODO-API
Projeto criado com base o curso 7198 do BALTA.io

## Sobre o Projeto

[in progress]

## Objetivo

[in progress]

## Outros Conhecimentos Postos em Prática

[in progress]

## Como Executar a API (.NET 9 e ASP.NET Core)

A seguir, estão os passos e comandos necessários para executar uma API .NET 9 e ASP.NET Core recém baixada do GitHub em seu ambiente local.

### Pré-requisitos

* **SDK do .NET 9:** Certifique-se de ter o SDK do .NET 9 instalado em sua máquina. Você pode baixá-lo no site oficial da Microsoft.

### Passos e Comandos

1.  **Navegue até o diretório do projeto:** Abra o terminal ou prompt de comando e navegue até a pasta onde os arquivos do projeto foram clonados do GitHub. Por exemplo:

    ```bash
    cd balta-7198-todo-api
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


