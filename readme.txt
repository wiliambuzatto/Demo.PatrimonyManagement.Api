+ Considerações gerais
- WEB API desenvolvida em .NET Core versão 2.1, seguindo boas práticas de programação em conjunto com o padrão DDD;
- Todo código foi escrito em inglês, mas procurando preservar a linguagem ubíqua durante o desenvolvimento;
- Foi utilizada a lib Swagger para documentação técnica e pode ser acessa via url/swagger. Exemplo no ambiente de denvolvimento: https://localhost:44304/swagger;
- Banco de dados SQL Server Express 2017, com EntityFramework Core, seguindo o conceito de Code First.
- Os scripts de banco encontram-se no diretório DB_Scripts;
- Organização dividida em multicamadas da seguinte forma:

0 - Api (Aplicação)
Camada de aplicação, responsável por organizar e orquestrar as requisições efetuadas à aplicação.
Desenvolvida utilizando arquitetura MVC/MVVM.

1 - Domain (Domínio)
Responsável por conter a modelagem das entidades, representando todo o contexto das funcionalidades a serem executadas pela aplicação.
Em conjunto com a lib FluentValidator, possui as regras principais de validação de suas classes.

2 - Service (Negócio/Serviço)
Responsável por todo Core Business da aplicação, com todas as regras de negócio.
Possui interfaces para ligação entre as camadas de Aplicação e Dados para gerenciamento das informações.
Aplicação do Repository Pattern e conceito de Unit of Work, no qual sempre utilizo como modelo e venho aperfeiçoando o desenvolvimento, com base em estudos e troca de experências.
Possui o mapeamento entre as entidades de banco e de domínio.

3 - Data (Dados)
Camada de dados, responsável pela persistência das informações no banco de dados.

4 - Common (Comum)
Camada de acesso comum às demais.


5 - Test (Teste)
Camada de teste, utilizando a lib XUnit para validação das regras de negócio.

+ Definições extras

- Criada entidade LogEntry para registros todos eventos executados pela aplicação;
- Autenticação Bearer via JWT. Para executar as chamadas da API, deve-se enviar uma requisição POST, do serviço api/user/Login para retornar o token de autenticação do usuário logado (previamente cadastrado);
- A senha definida para o usuário deve ser uma senha forte;
- O e-mail do usuário deve ser um e-mail válido;
- Foi definido que o campo "número do tombo" do patrimônio,gerado automaticamente, possui o tipo de identificador único (Guid);