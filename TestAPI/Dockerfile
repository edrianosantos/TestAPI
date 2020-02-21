FROM mcr.microsoft.com/dotnet/core/sdk:3.1-alpine AS build-env
WORKDIR /app
EXPOSE 80
EXPOSE 443

# Copiar csproj e restaurar dependencias
COPY *.csproj ./
#COPY ["TestAPI/TestAPI.csproj", "TestAPI/"]
RUN dotnet restore
#RUN dotnet restore "TestAPI/TestAPI.csproj"

RUN pwsh -Command Write-Host "TestAPI: Gerando uma nova imagem Docker com Alpine e testando o PowerShell Core"

# Build da aplicacao
COPY . ./
RUN dotnet publish -c Release -o out

# Build da imagem
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-alpine
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "TestAPI.dll"]
