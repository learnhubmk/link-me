# LinkMe - Strengthening your social circles

LinkeMe is a website solution for centralized indexing, discovery of all kinds of NGOs, initiatives, communities, forums and Facebook/Viber/Telegram/Whatsapp groups, physical as well as online/virtual.

The goal is to facilitate networking by hobby and interests, strengthen our social circles and to easily find communities and people on the same frequency as ours.

The project is being developed in cooperation with [42.mk](https://42.mk).

# Structure

```
link-me
│   package.json    
└───api (dotnet)
│   │   package.json
└───app (svelte)
    │   package.json
```

# Setup
Make a copy of appsettings.json, name it appsettings.Development.json and customize your local development solution as per your liking (this file is ignored by git and will not affect other devs).

## Auto

[Obsolete]
In the main [package.json](package.json) you can find the following commands:
- `auto-install` - installs the dependencies for `api` and `app`
- `auto-build` - builds the production ready environments for `api` and `app`
- `auto-develop` - starts `api` and `app` in developer mode
You can run the commands in command prompt `npm run {command}`.
- 
Note: For `api`, you still have to manually create an `.env` file based on [.env.example](./api/.env.example)

## Manual
### API (.NET)

1. Data Layer
ORM: Entity Framework 
Databases:
1.1. Sqlite (Development)
1.2. SqlServer (Production)


To add new SQL migration via Entity Framework, navigate to src/LinkMe and execute the following commands in .net cli via Powershell or Developer Powershell in Visual Studio:
dotnet ef migrations add {MigrationName} --context LinkMeSqliteDbContext --project LinkMe.Infrastructure.Sqlite
dotnet ef migrations add {MigrationName} --context LinkMeSqlServerDbContext --project LinkMe.Infrastructure.SqlServer

Pending migrations are applied on app start.

### APP (Svelte)
1. Navigate to `app`
2. Run `npm install`
3. Run `npm run dev`
