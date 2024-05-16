using Duende.IdentityServer;
using Duende.IdentityServer.Models;

namespace E_Commerce.IdentityServer;

public static class Config
{
    public static IEnumerable<ApiResource> ApiResources => new ApiResource[]
    {
        new ApiResource("ResourceCatalog")
        {
            Scopes = {"CatalogFullPermission","CatalogReadOnlyPermission"}
        },
        new ApiResource("ResourceDiscount")
        {
            Scopes = {"DiscountFullPermission","DiscountReadOnlyPermission"}
        },
        new ApiResource("ResourceOrder")
        {
            Scopes = {"OrderFullPermission","OrderReadOnlyPermission"}
        },
        new ApiResource(IdentityServerConstants.LocalApi.ScopeName)
        

    };

    public static IEnumerable<IdentityResource> IdentityResources =>
        new IdentityResource[]
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(),
            new IdentityResources.Email()
        };

    public static IEnumerable<ApiScope> ApiScopes =>
        new ApiScope[]
        {
            new ApiScope("CatalogFullPermission","Full authority for catalog operations"),
            new ApiScope("CatalogReadOnlyPermission","Reading authority for catalog operations"),
            new ApiScope("DiscountFullPermission","Full authority for discount operations"),
            new ApiScope("OrderFullPermission","Full authority for order operations"),
            new ApiScope(IdentityServerConstants.LocalApi.ScopeName)
        };

    public static IEnumerable<Client> Clients =>
        new Client[]
        {
            // Visitor
            new Client
            {
                ClientId = "E-CommerceManagerId",
                ClientName = "E-Commerce Manager User",

                AllowedGrantTypes = GrantTypes.ClientCredentials,
                ClientSecrets = { new Secret("511536EF-F270-4058-80CA-1C89C192F69A".Sha256()) },

                AllowedScopes = { "CatalogFullPermission", "DiscountFullPermission" , "OrderFullPermission" }
            },

             new Client
            {
                ClientId = "E-CommerceAdminId",
                ClientName = "E-Commerce Admin User",

                AllowedGrantTypes = GrantTypes.ClientCredentials,
                ClientSecrets = { new Secret("511536EF-F270-4058-80CA-1C89C192F69A".Sha256()) },

                AllowedScopes = { "CatalogFullPermission", "DiscountFullPermission" , "OrderFullPermission",
                IdentityServerConstants.LocalApi.ScopeName,
                IdentityServerConstants.StandardScopes.Email,
                IdentityServerConstants.StandardScopes.OpenId,
                IdentityServerConstants.StandardScopes.Profile,
                 },
                AccessTokenLifetime = 600
            },

            // interactive client using code flow + pkce
            new Client
            {
                ClientId = "E-CommerceVisitorId",
                ClientName = "E-Commerce Visitor User",
                ClientSecrets = { new Secret("49C1A7E1-0C79-4A89-A3D6-A37998FB86B0".Sha256()) },

                AllowedGrantTypes = GrantTypes.ClientCredentials,

                RedirectUris = { "https://localhost:44300/signin-oidc" },
                FrontChannelLogoutUri = "https://localhost:44300/signout-oidc",
                PostLogoutRedirectUris = { "https://localhost:44300/signout-callback-oidc" },

                AllowOfflineAccess = true,
                AllowedScopes = { "CatalogReadOnlyPermission"}
            },
        };
}
