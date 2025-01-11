using Duende.IdentityServer;
using Duende.IdentityServer.Models;

namespace MarketConnect.IdentityServer.Configuration;

public class IdentityConfiguration
{
    public const string Admin = "Admin";
    public const string Cliente = "Client";

    public static IEnumerable<IdentityResource> IdentityResources =>
        [
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(),
            new IdentityResources.Email(),
        ];


    public static IEnumerable<ApiScope> ApiScopes => 
        [
            //MarketConnect é aplicação web que vai acessar
            //o IdentityServer para obter o token
            new ApiScope("marketconnect","MarketConnect Server"),
            new ApiScope(name: "read", "Read data."),
            new ApiScope(name: "write", "Write data."),
            new ApiScope(name: "delete", "Delete data."),
        ];


    public static IEnumerable<Client> Clients => 
        [
            //Cliente genérico
            new Client{
                    ClientId = "client",
                    ClientSecrets = { new Secret("abracadabra#simsalabim".Sha256())},
                    AllowedGrantTypes = GrantTypes.ClientCredentials, //precisa das credenciais do usuario
                    AllowedScopes = {"read","write","profile"}
            },
            new Client{
                ClientId = "marketconnect",
                ClientSecrets = { new Secret("abracadabra#simsalabim".Sha256())},
                AllowedGrantTypes = GrantTypes.Code, //via codigo
                RedirectUris = {"https://localhost:7165/signin-oidc" }, //login
                PostLogoutRedirectUris = {"https://localhost:7165/signout-callback-oidc"}, //logout
                AllowedScopes = new List<string>{
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile,
                    IdentityServerConstants.StandardScopes.Email,
                    "marketconnet"
                }
            }
        ];

}
