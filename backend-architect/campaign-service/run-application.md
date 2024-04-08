# Start application to test

## Dockerize postgres to launch application

Docker compose file is just for postgres image, First it is needed to be dockerize.

Database will be created with initial scripts under campaign-service/script/init.sql

```bash
cd campaign-service
docker compose up -d
```

## Test application with swagger

```bash
cd campaign-service
dotnet build campaign-service.csproj
dotnet run campaign-service.csproj
```

## Swagger url

https://localhost:7257/swagger/index.html

Vscode is used to develop. To make debug
