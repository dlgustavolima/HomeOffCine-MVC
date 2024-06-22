FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["HomeOffCine.App/HomeOffCine.App.csproj", "HomeOffCine.App/"]
COPY ["HomeOffCine.Business/HomeOffCine.Business.csproj", "HomeOffCine.Business/"]
COPY ["HomeOffCine.Infra/HomeOffCine.Infra.csproj", "HomeOffCine.Infra/"]
RUN dotnet restore "HomeOffCine.App/HomeOffCine.App.csproj"
COPY . .
WORKDIR "/src/HomeOffCine.App"
RUN dotnet build "HomeOffCine.App.csproj" -c Development -o /app

FROM build AS publish
RUN dotnet publish "HomeOffCine.App.csproj" -c Development -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HomeOffCine.App.dll"]