FROM microsoft/dotnet:2.1-sdk AS build-env
WORKDIR /app

# Copiar csproj e restaurar dependencias
COPY *.csproj ./
RUN dotnet restore

# Build da aplicacao
COPY . ./
RUN dotnet publish -c Release -o out

# Build da imagem
FROM musing_wescoff
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "Dapper.Web.SignalR.dll"]