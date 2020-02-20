FROM mcr.microsoft.com/dotnet/core/sdk:3.1-alpine AS build-env
WORKDIR /app

# Copiar csproj e restaurar as dependencias
COPY *.csproj ./
RUN dotnet restore

RUN pwsh -Command Write-Host "TestAPI: Gerando uma nova imagem Docker com Alpine e testando o PowerShell Core"

# Build da aplicacao
COPY . ./
RUN dotnet publish -c Release -o out

# Build da imagem
FROM mcr.microsoft.com/dotnet/core/sdk:3.1-alpine
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "TestAPI.dll"]