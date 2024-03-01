# Use the official .NET Core SDK image as the build image
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src

# Copy the project file and restore dependencies
COPY sample-app.csproj .
RUN dotnet restore

# Copy the remaining source code
COPY . .

# Build the application
RUN dotnet build -c Release -o /app

# Use the official .NET Core runtime image as the base image
FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS runtime
WORKDIR /app

# Copy the built application from the build image
COPY --from=build /app .

# Expose port 80 for the application
EXPOSE 80

# Define the entry point for the application
ENTRYPOINT ["dotnet", "sample-app.dll"]
