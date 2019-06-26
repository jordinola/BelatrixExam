Curso .Net Core Trabajo Final

La implementaci�n actual esta dada con Postgresql. Esto debido a que actualmente no hay soporte para 
realizar la conexi�n en .Net Core 3.0 con MySql. Esto teniendo como base los siguientes links:
	- https://github.com/PomeloFoundation/Pomelo.EntityFrameworkCore.MySql/issues/740
	- https://dev.mysql.com/doc/connector-net/en/connector-net-entityframework-core.html

La librer�a de Pomelo indica que a�n no se est� dando soporte a la nueva versi�n de .Net Core y a�n 
no est� en sus planes. Por otro lado, la librer�a del propio MySql a�n no lista en sus versiones 
soportadas a la versi�n de .Net Core 3.0.

Por tal motivo, esta soluci�n se cre� empleando Postgresql. Para crear la BD tener las siguientes consideraciones:

- Validar las credenciales deseadas en los siguientes archivos: 
	- appsettings.json
	- Identity/Data/SeedData.cs
- Ejecutar el migrations a nivel de la soluci�n con los siguientes comandos:
	- IdentityDbContext: 
		dotnet ef migrations add Identity --context Belatrix.Exam.WebApi.Identity.Data.ApplicationDbContext --project Belatrix.Exam.WebApi -o Identity/Migrations
		dotnet ef database update --context Belatrix.Exam.WebApi.Identity.Data.ApplicationDbContext --project Belatrix.Exam.WebApi 

	- ChinookDbContext:
		dotnet ef migrations add Initial --context Belatrix.Exam.WebApi.Repository.Postgresql.ChinookDbContext --project Belatrix.Exam.WebApi -o Migrations
		dotnet ef database update --context Belatrix.Exam.WebApi.Repository.Postgresql.ChinookDbContext --project Belatrix.Exam.WebApi
- Recompilar la soluci�n y ejecutar
- Acceder al Swagger a trav�s de la siguiente ruta: https://localhost:44376/swagger/index.html