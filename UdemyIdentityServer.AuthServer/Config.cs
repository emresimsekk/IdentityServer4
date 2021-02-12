using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UdemyIdentityServer.AuthServer
{
    public static class Config
    {
        public static IEnumerable<ApiResource>  GetApiResources()
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
        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>(){
                new Client()
                {
                    ClientId="Client1",
                    ClientName="Client 1  uygulama",
                    ClientSecrets=new []{new Secret("secret".Sha256())},
                    AllowedGrantTypes=GrantTypes.ClientCredentials,
                    AllowedScopes={"api1.read"}
                },
                new Client()
                {
                    ClientId="Client2",
                    ClientName="Client 2 uygulama",
                    ClientSecrets=new []{new Secret("secret".Sha256())},
                     AllowedGrantTypes=GrantTypes.ClientCredentials,
                    AllowedScopes={"api1.read","api1.update","api2.write","api2.update" }
                }
            };
        }

    }
}
