FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 5006
EXPOSE 5007

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["LubricantStorage.UI.Web/LubricantStorage.UI.Web.csproj", "LubricantStorage.UI.Web/"]
COPY ["LubricantStorage.API/LubricantStorage.API.csproj", "LubricantStorage.API/"]
COPY ["LubricantStorage.Core/LubricantStorage.Core.csproj", "LubricantStorage.Core/"]
COPY ["LubricantStorage.Infrastructure/LubricantStorage.Infrastructure.csproj", "LubricantStorage.Infrastructure/"]
RUN dotnet restore "./LubricantStorage.UI.Web/LubricantStorage.UI.Web.csproj"
COPY . .
WORKDIR "/src/LubricantStorage.UI.Web"
RUN dotnet build "./LubricantStorage.UI.Web.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./LubricantStorage.UI.Web.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LubricantStorage.UI.Web.dll"]