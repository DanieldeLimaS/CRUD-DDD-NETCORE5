
<h1 align="center">
<br>
 ⭐Projeto em .NET Core 5 com estrutura DDD ⭐</h1>

## :page_facing_up: Descrição

Projeto desenvolvido em .NET Core 5 implementando na estrutura DDD, foi aplicato tecnologia de ORM usando o Entity Framework e o banco de dados utilizado no projeto é o Sql Server, o projeto está um pouco avançado por se tratar de uma estrutura mais poderosa 



### ✨Pré-requisitos para a Criação do banco de dados: ✨

⚠️Antes de criar o banco de dados, altera a connectionString no Startup.cs, o nome da connectionString a ser alterada é CRUDConnectin, informe os dados so servidor do banco de dados que irá utilizar


🟠 O banco de dados é criada a partir do comando no Packaje Manager Console, por ser criado no modo Code First
Selecione o projeto CRUD.Infra.Data pelo Packaje Manager Console e execute o seguinte comando para executar uma migration ja existente e fazer a criaçao do banco de dados:
```
 Update-database -context AppDbContext
```


🟠No Projeto foi usado a autenticação do Identity e é necessário executar o seguinte comando para a criação das tabelas necessarias, primeiro selecione o projeto CRUD.Site e execute o comento no Package Manager Console:
```
Update-database -context ApplicationDbContext
```


🟢 após realizar esses dois procedimentos, o sistema já está pronto para utilizar o banco de dados.




## 🧪 Tecnologias 🧪

Esse projeto foi desenvolvido com as seguintes tecnologias:

- [.NET Core](https://dotnet.microsoft.com/download/dotnet/5.0)
- [EntityFrameworkCore 5](https://dotnet.microsoft.com/download/dotnet/5.0)
- [SQL SERVER](https://download.microsoft.com/download/C/0/F/C0F2CE8F-FBD1-4CDE-940E-C330B38C8B32/SQLEXPR_x86_PTB.exe)
- [JavaScript](https://www.javascript.com/)
- [Jquery](https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js)
- [Html]()
- [Bootstrap](https://getbootstrap.com/docs/4.3/getting-started/introduction/)




## 🧰Tempo Gasto para o Desenvolvimento do projeto🧰


🕐Aproximadamente *9* Horas trabalhadas 🕐


---


## :closed_book: Licença

This project is [MIT](https://github.com/Igor-Gregori/moveit/blob/main/LICENSE) licensed.
