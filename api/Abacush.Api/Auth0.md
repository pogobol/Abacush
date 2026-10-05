# Auth0 setup

The API supports both Auth0 access-token validation and browser login sessions.

## Auth0 dashboard

1. Create an Auth0 API and set its Identifier to the value used as `Auth0:Audience`.
2. Create a regular web application for the OpenID Connect login flow.
3. Set the application callback URL to `https://localhost:7096/signin-oidc` (or the HTTPS URL used by the API).
4. Set the application logout URL to `https://localhost:7096/`.
5. Allow the API origin used by the frontend in Auth0 application settings.

The exact local HTTPS port is shown by the ASP.NET Core launch profile or Visual Studio. Update the callback and logout URLs to match it.

## Local development

From the repository root, configure User Secrets without committing the values:

```powershell
dotnet user-secrets init --project api/Abacush.Api/Abacush.Api.csproj
dotnet user-secrets set "Auth0:Domain" "your-tenant.us.auth0.com" --project api/Abacush.Api/Abacush.Api.csproj
dotnet user-secrets set "Auth0:Audience" "https://your-api-identifier" --project api/Abacush.Api/Abacush.Api.csproj
dotnet user-secrets set "Auth0:ClientId" "your-client-id" --project api/Abacush.Api/Abacush.Api.csproj
dotnet user-secrets set "Auth0:ClientSecret" "your-client-secret" --project api/Abacush.Api/Abacush.Api.csproj
```

## Deployment

Set these environment variables in the deployment environment:

- `Auth0__Domain`
- `Auth0__Audience`
- `Auth0__ClientId`
- `Auth0__ClientSecret`
- `Auth0__Scope` (optional; defaults to `openid profile email`)

Do not commit client secrets or production credentials to `appsettings.json`.

## Endpoints

- `GET /api/auth/login` starts the Auth0 browser login flow.
- `GET /api/auth/me` returns the authenticated user's claims.
- `GET /api/auth/logout` clears the local session and starts Auth0 logout.
- API calls can authenticate with `Authorization: Bearer <Auth0 access token>`.

Because authorization uses a fallback policy, controllers and actions are protected by default. Use `[AllowAnonymous]` explicitly for public endpoints.