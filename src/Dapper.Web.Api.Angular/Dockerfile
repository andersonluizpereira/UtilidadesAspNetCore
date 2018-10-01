FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["src/Dapper.Web.Api.Angular/Dapper.Web.Api.Angular.csproj", "src/Dapper.Web.Api.Angular/"]
RUN dotnet restore "src/Dapper.Web.Api.Angular/Dapper.Web.Api.Angular.csproj"
COPY . .
WORKDIR "/src/src/Dapper.Web.Api.Angular"
RUN dotnet build "Dapper.Web.Api.Angular.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Dapper.Web.Api.Angular.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Dapper.Web.Api.Angular.dll"]