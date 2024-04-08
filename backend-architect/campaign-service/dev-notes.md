1. Create a new .NET Core Web API project with Entity Framework Core
```bash
dotnet new webapi -n campaign-service
```

2. Adding Entity Framework to the project
``` bash
cd campaign-service
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL
dotnet restore
```

3. Adding dockerize postgresql to the project to make test.

- To do this, adding docker-compose.yml file to the project
- script folder exists initial script of the database.

4. Test and run default project was successfully running
launch postgres dockerize database and deploy initial script
```bash
docker compose up -d
```

Run .net project
```bash
dotnet run campaign-service.csproj
```

[Browse swagger doc.](https://localhost:7257/swagger/index.html) 

5. Debug or Run project

   vscode is used to develop project and there is a launch.json file under .vscode folder to debug project.

6. Install required nuget package for entity framework and jwt token

```bash
dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Microsoft.AspNetCore.Authentication.JwtBearer
dotnet add package System.IdentityModel.Tokens.Jwt
```
