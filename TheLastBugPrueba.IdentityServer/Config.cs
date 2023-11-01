using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

public static class Config
{
    public static IEnumerable<IdentityResource> GetIdentityResources()
    {
        return new List<IdentityResource>
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(),
            // Otros recursos de identidad que necesites
        };
    }

    public static IEnumerable<ApiScope> GetApiScopes()
    {
        return new List<ApiScope>
        {
            new ApiScope("api1", "Mi API Primera"),
            // Otros scopes de API que necesites
        };
    }

    public static IEnumerable<ApiResource> GetApiResources()
    {
        return new List<ApiResource>
        {
            new ApiResource("api1", "Mi API Primera")
            {
                Scopes = { "api1" }
            },
            // Otros recursos de API que necesites
        };
    }

    public static IEnumerable<Client> GetClients()
    {
        return new List<Client>
        {
            // Cliente para el flujo de credenciales del cliente
            new Client
            {
                ClientId = "client",
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                ClientSecrets =
                {
                    new Secret("secret".Sha256())
                },
                AllowedScopes = { "api1" }
            },
            // Cliente para el flujo de código de autorización (usado para aplicaciones interactivas como un cliente web)
            new Client
            {
                ClientId = "mvc",
                ClientName = "MVC Client",
                AllowedGrantTypes = GrantTypes.Code,

                // Dónde redirigir después del login y del logout
                RedirectUris = { "https://localhost:5002/signin-oidc" },
                PostLogoutRedirectUris = { "https://localhost:5002/signout-callback-oidc" },

                // Permiso para acceder al userinfo endpoint y solicitar ID token y access token
                AllowedScopes = new List<string>
                {
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile,
                    "api1"
                },

                // Configuración para que el token se envíe a través del navegador
                AllowAccessTokensViaBrowser = true,

                RequireConsent = false,

                // Secreto compartido entre la aplicación cliente y el servidor de identidad
                ClientSecrets =
                {
                    new Secret("secret".Sha256())
                }
            },
            // Otros clientes que necesites
        };
    }
}
