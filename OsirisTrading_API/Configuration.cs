using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System.Collections.Generic;
using System.Security.Claims;

namespace OsirisTrading_API
{
    /// <summary>
    /// Indentity Server Configureations
    /// </summary>
    public class Configuration
    {
        /// <summary>
        /// The clients
        /// </summary>
        internal static IEnumerable<Client> Clients = new List<Client>
        {
            new()
            {
                ClientId = "spa",
                AllowedGrantTypes = GrantTypes.Code,
                RequireClientSecret = false,
                RequirePkce = true,
                RequireConsent = false,
                RedirectUris =
                {
                    "http://localhost:5000/callback.html",
                    "http://localhost:5000/popup.html",
                    "http://localhost:5000/silent.html"
                },
                PostLogoutRedirectUris = { "http://localhost:5000/index.html" },
                AllowedScopes = { "openid", "profile", "email", IdentityServerConstants.LocalApi.ScopeName },
                AllowedCorsOrigins = { "http://localhost:5000" }
            },
        };

        /// <summary>
        /// The identity resources
        /// </summary>
        internal static IEnumerable<IdentityResource> IdentityResources = new List<IdentityResource>
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(),
            new IdentityResources.Email(),
        };

        /// <summary>
        /// The apis
        /// </summary>
        internal static IEnumerable<ApiResource> Apis = new List<ApiResource>
        {
            // local API
            new(IdentityServerConstants.LocalApi.ScopeName),
        };
    }

    /// <summary>
    /// The Test Users for this application
    /// </summary>
    public class TestUsers
    {
        internal static List<TestUser> Users = new()
        {
            new TestUser{SubjectId = "818727", Username = "alice", Password = "alice",
                Claims =
                {
                    new Claim(JwtClaimTypes.Name, "Alice Smith"),
                    new Claim(JwtClaimTypes.GivenName, "Alice"),
                    new Claim(JwtClaimTypes.FamilyName, "Smith"),
                    new Claim(JwtClaimTypes.Email, "AliceSmith@email.com"),
                    new Claim(JwtClaimTypes.EmailVerified, "true", ClaimValueTypes.Boolean),
                    new Claim(JwtClaimTypes.WebSite, "http://alice.com"),
                    new Claim(JwtClaimTypes.Address, @"{ 'street_address': 'One Hacker Way', 'locality': 'Heidelberg', 'postal_code': 69118, 'country': 'Germany' }", IdentityServerConstants.ClaimValueTypes.Json)
                }
            },
            new TestUser{SubjectId = "88421113", Username = "bob", Password = "bob",
                Claims =
                {
                    new Claim(JwtClaimTypes.Name, "Bob Smith"),
                    new Claim(JwtClaimTypes.GivenName, "Bob"),
                    new Claim(JwtClaimTypes.FamilyName, "Smith"),
                    new Claim(JwtClaimTypes.Email, "BobSmith@email.com"),
                    new Claim(JwtClaimTypes.EmailVerified, "true", ClaimValueTypes.Boolean),
                    new Claim(JwtClaimTypes.WebSite, "http://bob.com"),
                    new Claim(JwtClaimTypes.Address, @"{ 'street_address': 'One Hacker Way', 'locality': 'Heidelberg', 'postal_code': 69118, 'country': 'Germany' }", IdentityServerConstants.ClaimValueTypes.Json),
                    new Claim("location", "somewhere")
                }
            }
        };
    }
}