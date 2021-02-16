// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4;
using IdentityServer4.Models;
using System;
using System.Collections.Generic;

namespace UdemyIdentityServer_IdentityApi.AuthServer
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
                new ApiResource(IdentityServerConstants.LocalApi.ScopeName)
               
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
                new ApiScope(IdentityServerConstants.LocalApi.ScopeName)
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

                //code
                new Client()
                {
                    ClientId="Client1-Mvc",
                    RequirePkce=false,
                    ClientName="Client1 mvc uygulama",
                    ClientSecrets=new []{new Secret("secret".Sha256())},
                    AllowedGrantTypes=GrantTypes.Hybrid,
                    RedirectUris=new List<string>{"https://localhost:5006/signin-oidc"},
                    PostLogoutRedirectUris=new List<string>{"https://localhost:5006/signout-callback-oidc" },
                    AllowedScopes=
                      {
                            IdentityServerConstants.StandardScopes.OpenId,
                            IdentityServerConstants.StandardScopes.Profile,
                            "api1.read",
                            IdentityServerConstants.StandardScopes.OfflineAccess,
                            "CountryAndCity",
                            "Roles",
                            IdentityServerConstants.StandardScopes.Email,
                      },
                    AccessTokenLifetime=(int)(DateTime.Now.AddHours(2)-DateTime.Now).TotalSeconds,
                    AllowOfflineAccess=true,
                    RefreshTokenUsage=TokenUsage.ReUse,
                    RefreshTokenExpiration=TokenExpiration.Absolute,
                    AbsoluteRefreshTokenLifetime=(int)(DateTime.Now.AddDays(60)-DateTime.Now).TotalSeconds,
                    RequireConsent=false



                },

                new Client()
                {
                    ClientId="Client2-Mvc",
                    RequirePkce=false,
                    ClientName="Client2 mvc uygulama",
                    ClientSecrets=new []{new Secret("secret".Sha256())},
                    AllowedGrantTypes=GrantTypes.Hybrid,
                    RedirectUris=new List<string>{"https://localhost:5011/signin-oidc"},
                    PostLogoutRedirectUris=new List<string>{"https://localhost:5011/signout-callback-oidc" },
                    AllowedScopes=
                      {
                            IdentityServerConstants.StandardScopes.OpenId,
                            IdentityServerConstants.StandardScopes.Profile,
                            "api1.read","api2.read",
                            IdentityServerConstants.StandardScopes.OfflineAccess,
                            "CountryAndCity",
                            "Roles"
                      },
                    AccessTokenLifetime=(int)(DateTime.Now.AddHours(2)-DateTime.Now).TotalSeconds,
                    AllowOfflineAccess=true,
                    RefreshTokenUsage=TokenUsage.ReUse,
                    RefreshTokenExpiration=TokenExpiration.Absolute,
                    AbsoluteRefreshTokenLifetime=(int)(DateTime.Now.AddDays(60)-DateTime.Now).TotalSeconds,
                    RequireConsent=false
                },

                new Client()
                {
                    ClientId="js-client",
                    RequireClientSecret=false,
                    AllowedGrantTypes=GrantTypes.Code,
                    ClientName="js Client(Angular)",
                    AllowedScopes=
                      {
                            IdentityServerConstants.StandardScopes.Email,
                            IdentityServerConstants.StandardScopes.OpenId,
                            IdentityServerConstants.StandardScopes.Profile,
                            "api1.read",
                            IdentityServerConstants.StandardScopes.OfflineAccess,
                            "CountryAndCity",
                            "Roles"
                      },
                    RedirectUris={"http://localhost:4200/callback"},
                    //tarayıcı için cors
                    AllowedCorsOrigins={ "http://localhost:4200" },
                    PostLogoutRedirectUris={ "http://localhost:4200" }

                },

                //pwd
                new Client()
                {
                    ClientId="ClientResourceOwner-Mvc",
                    ClientName="Client mvc uygulama",
                    ClientSecrets=new []{new Secret("secret".Sha256())},
                    AllowedGrantTypes=GrantTypes.ResourceOwnerPasswordAndClientCredentials,
                    AllowedScopes=
                      {
                            IdentityServerConstants.StandardScopes.OpenId,
                            IdentityServerConstants.StandardScopes.Profile,
                            "api1.read",
                            IdentityServerConstants.StandardScopes.OfflineAccess,
                            "CountryAndCity",
                            "Roles",
                            IdentityServerConstants.StandardScopes.Email,
                            IdentityServerConstants.LocalApi.ScopeName

                      },
                    AccessTokenLifetime=(int)(DateTime.Now.AddHours(2)-DateTime.Now).TotalSeconds,
                    AllowOfflineAccess=true,
                    RefreshTokenUsage=TokenUsage.ReUse,
                    RefreshTokenExpiration=TokenExpiration.Absolute,
                    AbsoluteRefreshTokenLifetime=(int)(DateTime.Now.AddDays(60)-DateTime.Now).TotalSeconds,



                },


            };
        }
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>()
            {
                new IdentityResources.Email(),
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResource(){Name="CountryAndCity",DisplayName="Country and City",Description="Kullanıcının ilçe ve şehir bilgisi",
                    UserClaims=new []{ "country","city"} },
                new IdentityResource(){Name="Roles",DisplayName="Roles",Description="Kullanıcı Rolleri",
                    UserClaims=new []{"role" } }
            };
        }
      

    }
}