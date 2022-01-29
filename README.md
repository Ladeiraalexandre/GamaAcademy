# Projeto MVC - API REST - Gama Academy

1. [ProjetoGamaAcademy](https://github.com/Ladeiraalexandre/GamaAcademy/tree/master/ProjetoGamaAcademy) - Projeto ASP.NET Core MVC para cadastro de serviços, posts e integrantes, utilizando Entity Framework Core. Para este projeto foi criada uma API Rest, utilizando o Swagger para documentação e Testes com XUnit. Banco de Dados SQL Server.

   API publicada na [Azure](https://api-gama.azurewebsites.net/swagger/index.html)
   
2. Instruções: Rodando a aplicação local: No ProjetoGamaAcademy configurar a string de conexão em appsettings.json, em MvcGamaContext.

   No PMC (Package Manager Console) rodar: Add-Migration Init e em seguida Update-Database

   Esses comandos irão criar o banco de dados e também a estrutura.

   Rodar a aplicação.                                                                               

3. Rodando API localmente: No projeto API configurar a string de conexão em appsettings.json em DefaultConnection.