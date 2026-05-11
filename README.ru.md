# CleanWebApiTemplate

[English version](README.md)

Стартовый шаблон ASP.NET Core Web API со структурой, вдохновленной Clean Architecture и соответствующий 152 ФЗ О персональных данных.

Проект предназначен для клонирования как основа для новых сервисов. Сейчас он задает основные слои и доменную модель для:

- RBAC: пользователи, роли и разрешения
- Entity Framework Core с ручной конфигурацией сущностей
- Кеширование на базе Redis
- Логирование
- Базовые идеи Onion/Clean Architecture

## Структура Проекта

```text
src/
  CleanWebApiTemplate.Api/             точка входа HTTP API
  CleanWebApiTemplate.Application/     use cases, контракты, application services
  CleanWebApiTemplate.Domain/          сущности, enum-ы, доменные исключения
  CleanWebApiTemplate.Infrastructure/  EF Core, кеш, внешние интеграции
```

## Требования

- .NET 10 SDK
- PostgreSQL
- Redis
- Docker (необязательно)

## Быстрый Старт

Клонируйте репозиторий и восстановите зависимости:

```bash
dotnet restore CleanWebApiTemplate.sln
```

Настройки для локальной разработки находятся здесь:

```text
src/CleanWebApiTemplate.Api/appsettings.Development.json
```

Соберите решение:

```bash
dotnet build CleanWebApiTemplate.sln
```

Запустите API:

```bash
dotnet run --project src/CleanWebApiTemplate.Api/CleanWebApiTemplate.Api.csproj
```

По умолчанию development-профиль слушает:

```text
http://localhost:5177
```

OpenAPI JSON доступен в development-режиме:

```text
http://localhost:5177/openapi/v1.json
```

## Конфигурация

Локальные настройки должны приходить из переменных окружения или из локальных файлов настроек, которые не коммитятся.

Коммитятся:

- `appsettings.json`
- `appsettings.Development.json`

Не коммитятся:

- `appsettings.Local.json`
- `appsettings.*.local.json`

## Текущий Статус Шаблона

Решение собирается, но инфраструктура и feature slices пока находятся на ранней стадии. Перед использованием шаблона для production-проекта нужно закончить:

- Зарегистрировать Application и Infrastructure сервисы в API-слое
- Настроить `AppDbContext` с provider options и сканированием entity configurations
- Добавить миграции и начальные RBAC данные
- Реализовать аутентификацию и authorization на базе permissions
- Реализовать Redis cache service
- Добавить глобальную обработку исключений и структурное логирование
- Добавить примеры controllers/use cases и тесты
