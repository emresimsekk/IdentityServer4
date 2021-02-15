using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UdemyIdentityServer.AuthServer.Models
{
    public class CustomDbContext:DbContext
    {
        public CustomDbContext(DbContextOptions<CustomDbContext> opts):base(opts)
        {

        }
        public DbSet<CustomUser> customUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CustomUser>().HasData(
                new CustomUser() { Id=1, UserName="esimsek",Email="emresimsek801@gmail.com",Password="password",City="Bursa"},
                new CustomUser() { Id = 2, UserName = "uciftci", Email = "ugur801@gmail.com", Password = "password", City = "Ankara" },
                new CustomUser() { Id = 3, UserName = "mcarp", Email = "mehmet@gmail.com", Password = "password", City = "İzmir" }

                );
            base.OnModelCreating(modelBuilder);
        }

    }
}
