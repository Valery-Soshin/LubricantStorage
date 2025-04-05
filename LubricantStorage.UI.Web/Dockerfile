# См. статью по ссылке https://aka.ms/customizecontainer, чтобы узнать как настроить контейнер отладки
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 5006
EXPOSE 5007

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Копируем все .csproj файлы
COPY ["LubricantStorage.UI.Web/LubricantStorage.UI.Web.csproj", "LubricantStorage.UI.Web/"]
COPY ["LubricantStorage.API/LubricantStorage.API.csproj", "LubricantStorage.API/"]
COPY ["LubricantStorage.Core/LubricantStorage.Core.csproj", "LubricantStorage.Core/"]
COPY ["LubricantStorage.Infrastructure/LubricantStorage.Infrastructure.csproj", "LubricantStorage.Infrastructure/"]

# Восстанавливаем зависимости для всех проектов
RUN dotnet restore "LubricantStorage.UI.Web/LubricantStorage.UI.Web.csproj"
RUN dotnet restore "LubricantStorage.API/LubricantStorage.API.csproj"

# Копируем остальные файлы
COPY . .

# Собираем и публикуем Web проект
FROM build AS publish-web
ARG BUILD_CONFIGURATION=Release
WORKDIR "/src/LubricantStorage.UI.Web"
RUN dotnet publish "LubricantStorage.UI.Web.csproj" -c $BUILD_CONFIGURATION -o /app/publish/web /p:UseAppHost=false

# Собираем и публикуем API проект
FROM build AS publish-api
ARG BUILD_CONFIGURATION=Release
WORKDIR "/src/LubricantStorage.API"
RUN dotnet publish "LubricantStorage.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish/api /p:UseAppHost=false

# Финальный образ
FROM base AS final
WORKDIR /app

# Копируем опубликованные файлы из обоих проектов
COPY --from=publish-web /app/publish/web .
COPY --from=publish-api /app/publish/api ./api

ENTRYPOINT ["dotnet", "LubricantStorage.UI.Web.dll"]