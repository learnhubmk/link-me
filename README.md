# LinkMe - Strengthening your social circles

LinkeMe is a website solution for centralized indexing, discovery of all kinds of NGOs, initiatives, communities, forums and Facebook/Viber/Telegram/Whatsapp groups, physical as well as online/virtual.

The goal is to facilitate networking by hobby and interests, strengthen our social circles and to easily find communities and people on the same frequency as ours.

The project is being developed in cooperation with [42.mk](https://42.mk).

# Structure

```
link-me
│   package.json    
└───api (strapi)
│   │   package.json
└───app (svelte)
    │   package.json
```

# Setup
## Auto

In the main [package.json](package.json) you can find the following commands:
- `auto-install` - installs the dependencies for `api` and `app`
- `auto-build` - builds the production ready environments for `api` and `app`
- `auto-develop` - starts `api` and `app` in developer mode
You can run the commands in command prompt `npm run {command}`.
- 
Note: For `api`, you still have to manually create an `.env` file based on [.env.example](./api/.env.example)

## Manual
### API (Strapi)
1. Navigate to `api`
2. Run `npm install`
3. Create an `.env` file based on [.env.example](./api/.env.example)
4. Run `npm run develop`

### APP (Svelte)
1. Navigate to `app`
2. Run `npm install`
3. Run `npm run dev`
