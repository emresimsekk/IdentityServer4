using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace UdemyIdentityServer.AuthServer
{
    public static class Config
    {
        public static IEnumerable<ApiResource> GetApiResources()
        {

            return new List<ApiResource>()
            {
                new ApiResource("resource_api1")
                {
                    Scopes={ "api1.read", "api1.write", "api1.update" }
                },
                new ApiResource("resource_api2")
                {
                    Scopes={ "api2.read", "api2.write", "api2.update" }
                },
            };

        }
        public static IEnumerable<ApiScope> GetApiScopes()
        {
            return new List<ApiScope>()
            {
                new ApiScope("api1.read","Okuma"),
                new ApiScope("api1.write","Yazma"),
                new ApiScope("api1.update","Güncelleme"),

                new ApiScope("api2.read","Okuma"),
                new ApiScope("api2.write","Yazma"),
                new ApiScope("api2.update","Güncelleme"),

            };
        }

        //ClientCredentials
        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>(){
                
                //ClientCredentials
                new Client()
                {
                    ClientId="Client1",
                    ClientName="Client 1  uygulama",
                    ClientSecrets=new []{new Secret("secret".Sha256())},
                    AllowedGrantTypes=GrantTypes.ClientCredentials,
                    AllowedScopes={"api1.read"}
                },
                  //ClientCredentials
                new Client()
                {
                    ClientId="Client2",
                    ClientName="Client 2 uygulama",
                    ClientSecrets=new []{new Secret("secret".Sha256())},
                     AllowedGrantTypes=GrantTypes.ClientCredentials,
                    AllowedScopes={"api1.read","api1.update","api2.write","api2.update" }
                },


                  new Client()
                {
                    ClientId="Client1-Mvc",
                    RequirePkce=false,
                    ClientName="Client1 mvc uygulama",
                    ClientSecrets=new []{new Secret("secret".Sha256())},
                    AllowedGrantTypes=GrantTypes.Hybrid,
                    RedirectUris=new List<string>{"https://localhost:5006/signin-oidc"},
                    AllowedScopes=
                      {
                            IdentityServerConstants.StandardScopes.OpenId,
                            IdentityServerConstants.StandardScopes.Profile,
                            "api1.read",
                            IdentityServerConstants.StandardScopes.OfflineAccess
                      },
                    AccessTokenLifetime=DateTime.Now.AddHours(2).Second,
                    AllowOfflineAccess=true,
                    RefreshTokenUsage=TokenUsage.ReUse,
                    SlidingRefreshTokenLifetime=DateTime.Now.AddDays(60).Second,

                    

                }
            };
        }
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>()
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
            };
        }
        public static IEnumerable<TestUser> GetUsers()
        {
            return new List<TestUser>()
            {
                new TestUser
                {
                    SubjectId = "1",
                    Username = "esimsek",
                    Password = "password",
                    Claims = new List<Claim>()
                    {
                        new Claim("given_name", "Emre"),
                        new Claim("family_name", "Şimşek"),
                    }
                },
                 new TestUser
                {
                    SubjectId = "2",
                    Username = "uciftci",
                    Password = "password",
                    Claims = new List<Claim>()
                    {
                        new Claim("given_name", "Uğur"),
                        new Claim("family_name", "Çiftci"),
                    }
                }
            };

        }

    }
}

