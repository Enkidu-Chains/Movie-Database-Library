Before running project you need to use thise commands from the root of the project src/api/Api.Web

	```
	dotnet user-secerts init

	dotnet user-secrets set "Google:DriverApiKey" "*Key*"

	dotnet user-secrets set "PostgreSql:Password" "*Password*"
	```

	Key - Google api key with access to GoogleDriver
	Password - Password to your database

If there is not migration in src/infrastructure/Infrastructure.DataAccess/Migrations

	```
	dotnet ef migrations add InitialCreate -o Migrations -s src/api/Api.Web/ -p src/infrastructure/Infrastructure.DataAccess/

	SET ASPNETCORE_ENVIRONMENT=Development

	dotnet ef database update  -s src/api/Api.Web/ -p src/infrastructure/Infrastructure.DataAccess/
	```

If there is migration in src/infrastructure/Infrastructure.DataAccess/Migrations

	`dotnet ef database update --environment Development -s src/api/Api.Web/ -p src/infrastructure/Infrastructure.DataAccess/`

If you need Production setting, replace `Development` to `Production`.


Server=localhost;Port=5432;Database=movie_library_bd_development;User Id=postgres;Password=myPassword;CommandTimeout=20;