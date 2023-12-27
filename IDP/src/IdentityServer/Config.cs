using Duende.IdentityServer;
using Duende.IdentityServer.Models;
using IdentityModel;
using System.Net;

namespace IdentityServer;

public static class Config
{
    public static IEnumerable<IdentityResource> IdentityResources =>
        new IdentityResource[]
        { 
            new IdentityResources.OpenId(),
        new IdentityResources.Profile(),
        new IdentityResource()
      {
          Name = "verification",
          UserClaims = new List<string>
          {
              JwtClaimTypes.Email,
              JwtClaimTypes.EmailVerified
          }
      },
        new IdentityResource("roles", "Your role(s)", new [] {"role"})
        };

    // we can also add api here , once done add it to hosting
    public static IEnumerable<ApiResource> ApiResources =>
        new ApiResource[] { };

    public static IEnumerable<ApiScope> ApiScopes =>
    new List<ApiScope>
    {
        new ApiScope(name: "api1", displayName: "MyAPI")
    };

    public static IEnumerable<Client> Clients =>
    new List<Client>
    {
        // machine to machine client (from quickstart 1)
        new Client
        {
            ClientId = "client",
            ClientSecrets = { new Secret("secret".Sha256()) },

            AllowedGrantTypes = GrantTypes.ClientCredentials,
            // scopes that client has access to
            AllowedScopes = { "api1" }
        },
        // interactive ASP.NET Core Web App
        new Client
        {
            ClientId = "web",
            ClientSecrets = { new Secret("secret".Sha256()) },

            AllowedGrantTypes = GrantTypes.Code,
            
            // where to redirect to after login
            RedirectUris = { "https://localhost:5002/signin-oidc" },

            // where to redirect to after logout
            PostLogoutRedirectUris = { "https://localhost:5002/signout-callback-oidc" },

             AllowOfflineAccess = true,
            AllowedScopes = new List<string>
            {
                IdentityServerConstants.StandardScopes.OpenId,
                IdentityServerConstants.StandardScopes.Profile,
                "verification",
                "api1"
            }
        },
         // interactive ASP.NET Core Web App Role Base
        new Client
        {
            ClientId = "webRolebase",
            ClientSecrets = { new Secret("secret".Sha256()) },

            AllowedGrantTypes = GrantTypes.Code,
            //AccessTokenLifetime =
            //AuthorizationCodeLifetime =
            //IdentityTokenLifetime

            // where to redirect to after login
            RedirectUris = { "https://localhost:8002/signin-oidc" },

            // where to redirect to after logout
            PostLogoutRedirectUris = { "https://localhost:8002/signout-callback-oidc" },

            AllowOfflineAccess = true,
            UpdateAccessTokenClaimsOnRefresh = true,
            AllowedScopes = new List<string>
            {
                IdentityServerConstants.StandardScopes.OpenId,
                IdentityServerConstants.StandardScopes.Profile,
                "verification",
                "api1",
                "roles"
            }
        },
        // JavaScript BFF client
new Client
{
    ClientId = "bff",
    ClientSecrets = { new Secret("secret".Sha256()) },

    AllowedGrantTypes = GrantTypes.Code,
    
    // where to redirect to after login
    RedirectUris = { "https://localhost:7003/signin-oidc" },

    // where to redirect to after logout
    PostLogoutRedirectUris = { "https://localhost:7003/signout-callback-oidc" },

    AllowedScopes = new List<string>
    {
        IdentityServerConstants.StandardScopes.OpenId,
        IdentityServerConstants.StandardScopes.Profile,
        "api1"
    }
},
// JavaScript Client
new Client
{
    ClientId = "js",
    ClientName = "JavaScript Client",
    AllowedGrantTypes = GrantTypes.Code,
    RequireClientSecret = false,

    RedirectUris =           { "https://localhost:5003/callback.html" },
    PostLogoutRedirectUris = { "https://localhost:5003/index.html" },
    AllowedCorsOrigins =     { "https://localhost:5003" },

    AllowedScopes =
    {
        IdentityServerConstants.StandardScopes.OpenId,
        IdentityServerConstants.StandardScopes.Profile,
        "api1"
    }
}
    };
}