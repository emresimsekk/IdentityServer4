using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Mappers;
using System.Linq;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UdemyIdentityServer.AuthServer.Seed
{
    public static class IdentityServerSeedDate
    {
        public static void seed(ConfigurationDbContext context)
        {
            //client
            if (!context.Clients.Any())
            {
                foreach (var client in Config.GetClients())
                {
                    context.Clients.Add(client.ToEntity());
                }

            }

            //resource
            if (!context.ApiResources.Any())
            {

                foreach (var apiResource in Config.GetApiResources())
                {
                    context.ApiResources.Add(apiResource.ToEntity());
                }
            }
            //scope
            if (!context.ApiScopes.Any())
            {
                Config.GetApiScopes().ToList().ForEach(apisScope =>
                {
                    context.ApiScopes.Add(apisScope.ToEntity());
                });
            }

            //IdentityResource
            if (!context.IdentityResources.Any())
            {
                Config.GetIdentityResources().ToList().ForEach(identity =>
                {
                    context.IdentityResources.Add(identity.ToEntity());
                });
            }


          
           

            context.SaveChanges();

        }
    }
}
