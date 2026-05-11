# CleanWebApiTemplate

A starter ASP.NET Core Web API template with a Clean Architecture-inspired structure.

The project is intended to be cloned as a base for new services. It currently defines the main layers and domain shape for:

- RBAC: users, roles, and permissions
- Entity Framework Core with manual entity configuration
- Redis-based caching
- Logging
- Onion/Clean Architecture fundamentals

## Project Structure

```text
src/
  CleanWebApiTemplate.Api/             HTTP API entry point
  CleanWebApiTemplate.Application/     Use cases, contracts, application services
  CleanWebApiTemplate.Domain/          Entities, enums, domain exceptions
  CleanWebApiTemplate.Infrastructure/  EF Core, cache, external integrations
```

## Requirements

- .NET 10 SDK
- PostgreSQL
- Redis

## Getting Started

Clone the repository and restore dependencies:

```bash
dotnet restore CleanWebApiTemplate.sln
```

Local development defaults are stored in:

```text
src/CleanWebApiTemplate.Api/appsettings.Development.json
```

For real secrets, prefer ASP.NET Core user secrets:

```bash
dotnet user-secrets init --project src/CleanWebApiTemplate.Api/CleanWebApiTemplate.Api.csproj
dotnet user-secrets set "Jwt:Secret" "replace-with-a-long-random-local-secret" --project src/CleanWebApiTemplate.Api/CleanWebApiTemplate.Api.csproj
dotnet user-secrets set "ConnectionStrings:DefaultConnection" "Host=localhost;Port=5432;Database=clean_web_api_template;Username=postgres;Password=postgres" --project src/CleanWebApiTemplate.Api/CleanWebApiTemplate.Api.csproj
```

Build the solution:

```bash
dotnet build CleanWebApiTemplate.sln
```

Run the API:

```bash
dotnet run --project src/CleanWebApiTemplate.Api/CleanWebApiTemplate.Api.csproj
```

By default, the development profile listens on:

```text
http://localhost:5177
```

OpenAPI JSON is available in development at:

```text
http://localhost:5177/openapi/v1.json
```

## Configuration

Local settings should come from environment variables or untracked local settings files.

Tracked:

- `appsettings.json`
- `appsettings.Development.json`

Untracked:

- `appsettings.Local.json`
- `appsettings.*.local.json`

## Current Template Status

The solution builds, but the infrastructure and feature slices are still early-stage. Before using this as a production project template, finish these items:

- Register Application and Infrastructure services in the API layer
- Configure `AppDbContext` with provider options and entity configuration scanning
- Add migrations and initial RBAC seed data
- Implement authentication and permission-based authorization
- Implement Redis cache service
- Add global exception handling and structured logging
- Add example controllers/use cases and tests

## Useful Commands

```bash
dotnet build CleanWebApiTemplate.sln
dotnet test CleanWebApiTemplate.sln
dotnet run --project src/CleanWebApiTemplate.Api/CleanWebApiTemplate.Api.csproj
```

## License

Add a license before publishing this repository as a public GitHub template.
