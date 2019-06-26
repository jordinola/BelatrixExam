Curso .Net Core Trabajo Final

La implementación actual esta dada con Postgresql. Esto debido a que actualmente no hay soporte para 
realizar la conexión en .Net Core 3.0 con MySql. Esto teniendo como base los siguientes links:
	- https://github.com/PomeloFoundation/Pomelo.EntityFrameworkCore.MySql/issues/740
	- https://dev.mysql.com/doc/connector-net/en/connector-net-entityframework-core.html

La librería de Pomelo indica que aún no se está dando soporte a la nueva versión de .Net Core y aún 
no está en sus planes. Por otro lado, la librería del propio MySql aún no lista en sus versiones 
soportadas a la versión de .Net Core 3.0.

Por tal motivo, esta solución se creó empleando Postgresql. Para crear la BD tener las siguientes consideraciones:

- Validar las credenciales deseadas en los siguientes archivos: 
	- appsettings.json
	- Identity/Data/SeedData.cs
- Ejecutar el migrations a nivel de la solución con los siguientes comandos:
	- IdentityDbContext: 
		dotnet ef migrations add Identity --context Belatrix.Exam.WebApi.Identity.Data.ApplicationDbContext --project Belatrix.Exam.WebApi -o Identity/Migrations
		dotnet ef database update --context Belatrix.Exam.WebApi.Identity.Data.ApplicationDbContext --project Belatrix.Exam.WebApi 

	- ChinookDbContext:
		dotnet ef migrations add Initial --context Belatrix.Exam.WebApi.Repository.Postgresql.ChinookDbContext --project Belatrix.Exam.WebApi -o Migrations
		dotnet ef database update --context Belatrix.Exam.WebApi.Repository.Postgresql.ChinookDbContext --project Belatrix.Exam.WebApi
- Recompilar la solución y ejecutar
- Acceder al Swagger a través de la siguiente ruta: https://localhost:44376/swagger/index.html