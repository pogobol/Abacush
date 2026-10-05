using Abacush.Api.Configuration;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;

namespace Abacush.Api.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddApiServices(this IServiceCollection services, IConfiguration configuration)
    {
        var auth0 = configuration.GetSection(Auth0Options.SectionName).Get<Auth0Options>()
            ?? new Auth0Options();

        services.Configure<Auth0Options>(configuration.GetSection(Auth0Options.SectionName));

        services.AddApiVersioning(options =>
        {
            options.DefaultApiVersion = new ApiVersion(1, 0);
            options.AssumeDefaultVersionWhenUnspecified = true;
            options.ReportApiVersions = true;
        });

        services.AddVersionedApiExplorer(options =>
        {
            options.GroupNameFormat = "'v'VVV";
            options.SubstituteApiVersionInUrl = true;
        });

        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        services.AddCors(options =>
        {
            options.AddPolicy("AbacushCors", policy =>
            {
                policy.AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod();
            });
        });

        if (string.IsNullOrWhiteSpace(auth0.Domain))
        {
            throw new InvalidOperationException("Auth0:Domain must be configured.");
        }

        if (string.IsNullOrWhiteSpace(auth0.Audience))
        {
            throw new InvalidOperationException("Auth0:Audience must be configured.");
        }

        var authority = $"https://{auth0.Domain.TrimEnd('/')}/";

        services.AddAuthentication(options =>
        {
            options.DefaultScheme = "Auth0Selector";
            options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
        })
        .AddPolicyScheme("Auth0Selector", "Auth0 authentication selector", options =>
        {
            options.ForwardDefaultSelector = context =>
                context.Request.Headers.ContainsKey("Authorization")
                    ? JwtBearerDefaults.AuthenticationScheme
                    : CookieAuthenticationDefaults.AuthenticationScheme;
        })
        .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme)
        .AddOpenIdConnect(OpenIdConnectDefaults.AuthenticationScheme, options =>
        {
            options.Authority = authority;
            options.ClientId = auth0.ClientId;
            options.ClientSecret = auth0.ClientSecret;
            options.ResponseType = OpenIdConnectResponseType.Code;
            options.UsePkce = true;
            options.SaveTokens = true;
            options.Scope.Clear();
            foreach (var scope in auth0.Scope.Split(' ', StringSplitOptions.RemoveEmptyEntries))
            {
                options.Scope.Add(scope);
            }
        })
        .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
        {
            options.Authority = authority;
            options.Audience = auth0.Audience;
        });

        services.AddAuthorization(options =>
        {
            options.FallbackPolicy = new Microsoft.AspNetCore.Authorization.AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()
                .Build();
        });
        services.AddHealthChecks();

        return services;
    }
}
