# Используем официальный образ .NET SDK для сборки приложения
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Устанавливаем рабочую директорию
WORKDIR /src

# Копируем .csproj файл и восстанавливаем зависимости
COPY ["WebApplication1/WebApplication1.csproj", "WebApplication1/"]
RUN dotnet restore "WebApplication1/WebApplication1.csproj"

# Копируем остальные файлы и собираем приложение
COPY . .
WORKDIR "/src/WebApplication1"
RUN dotnet build "WebApplication1.csproj" -c Release -o /app/build

# Публикуем приложение
RUN dotnet publish "WebApplication1.csproj" -c Release -o /app/publish

# Устанавливаем dotnet-ef
RUN dotnet tool install --global dotnet-ef

# Добавляем путь к глобальным инструментам в текущую сессию
RUN export PATH="$PATH:/root/.dotnet/tools"

# Восстанавливаем инструменты для текущей сессии
RUN dotnet tool restore

# Выполняем миграции

# Используем минимальный runtime образ для выполнения
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

# Копируем опубликованное приложение из стадии сборки
COPY --from=build /app/publish .

# Открываем порт для приложения (если нужно)
EXPOSE 8080

RUN export PATH="$PATH:/root/.dotnet/tools"

RUN dotnet ef database update

# Запуск приложения
ENTRYPOINT ["dotnet", "WebApplication1.dll"]
