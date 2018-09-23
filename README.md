# dotnet-webapi-ef
A solution I developed in 2015 to get a feel of Web API 2 with Entity Framework.

## Table of Contents
- [Technology](#technology)
- [Database](#database)
- [Setup](#setup)
- [API Endpoints](#apiendpoints)
- [Dojocat](#dojocat)


## Technology <a id="technology">
This uses the following technology...

- C#
- ASP.NET Web API 2
- Entity Framework 6 (using code first approach)
- JsonPatch
- SimpleInjector
- NUnit
- NSubsitute
- NBuilder
- FluentAssertions


## Database <a id="database">
Developed against _localdb_

1 crie a banco de dados TransireDB no sqlserver:
 Obs. Caso seja necessario, faço ajuste na string de conexão com o banco de dados, essa configuração esta no arquivo fonte-transire\transire-app\src\TransireAPI\Web.config
  <add name="TransireDB" connectionString="Data Source=.\SQLEXPRESS;Initial Catalog=TransireDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False" providerName="System.Data.SqlClient" />

2 execute o script que esta no diretorio transire-prova\fonte-transire\scriptDB.sql no bando de dados TransireDB

3 abra o projeto \transire-prova\fonte-transire\transire-app\transire-app.sln pelo visual studio

4 Realize o build do projeto;

5 Faça publicação do projeto;

6 acesso o diretorio transire-prova\fonte-transire\transire-ui pelo terminal.

7 digite o comando npm install

8 ng serve