FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY *.sln .
COPY Proveedores.Domain/*.csproj Proveedores.Domain/
COPY Proveedores.Application/*.csproj Proveedores.Application/
COPY Proveedores.Infrastructure/*.csproj Proveedores.Infrastructure/
COPY Proveedores.Api/*.csproj Proveedores.Api/
COPY Proveedores.Tests/*.csproj Proveedores.Tests/
RUN dotnet restore

COPY . .
RUN dotnet publish Proveedores.Api/Proveedores.Api.csproj -c Release -o /app

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app .
EXPOSE 80

ENTRYPOINT ["dotnet", "Proveedores.Api.dll"]