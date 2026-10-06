# Auth0 setup

The API validates Auth0 access tokens and the UI authenticates users with Auth0 SPA login.

## Auth0 dashboard

1. Create an Auth0 API and set its Identifier to the value used as `Auth0:Audience`.
2. Create an Auth0 Single Page Application for the Angular UI.
3. Add UI callback URLs:
	- `http://localhost:4200`
4. Add UI logout URLs:
	- `http://localhost:4200`
5. Add UI web origins:
	- `http://localhost:4200`
6. If using API interactive login endpoints (`/api/auth/login`), also create a regular web application and set:
	- Callback URL: `http://localhost:5096/signin-oidc`
	- Logout URL: `http://localhost:5096/`

## Local development

### API values (User Secrets)

From the repository root, configure API values without committing secrets:

```powershell
dotnet user-secrets init --project api/Abacush.Api/Abacush.Api.csproj
dotnet user-secrets set "Auth0:Domain" "your-tenant.us.auth0.com" --project api/Abacush.Api/Abacush.Api.csproj
dotnet user-secrets set "Auth0:Audience" "https://your-api-identifier" --project api/Abacush.Api/Abacush.Api.csproj
dotnet user-secrets set "Auth0:ClientId" "your-regular-webapp-client-id" --project api/Abacush.Api/Abacush.Api.csproj
dotnet user-secrets set "Auth0:ClientSecret" "your-regular-webapp-client-secret" --project api/Abacush.Api/Abacush.Api.csproj
```

### UI values

Set SPA values in `ui/apps/abacush/src/environments/environment.ts`:

- `auth0.domain`
- `auth0.clientId` (SPA client id)
- `auth0.audience` (same API identifier)
- `apiBaseUrl` (`http://localhost:5096` by default)

## Deployment

Set these API environment variables in deployment:

- `Auth0__Domain`
- `Auth0__Audience`
- `Auth0__ClientId`
- `Auth0__ClientSecret`
- `Auth0__Scope` (optional; defaults to `openid profile email`)

Do not commit production credentials.

## Endpoints and behavior

- `GET /api/auth/me` returns the authenticated user's claims.
- API calls authenticate with `Authorization: Bearer <Auth0 access token>`.
- `GET /api/auth/login` and `GET /api/auth/logout` are available for API-hosted interactive login flow.

Authorization uses a fallback policy, so controllers and actions are protected by default. Use `[AllowAnonymous]` explicitly for public endpoints.