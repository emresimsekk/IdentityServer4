﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UdemyIdentityServer.AuthServer.Models;

namespace UdemyIdentityServer.AuthServer.Migrations
{
    [DbContext(typeof(CustomDbContext))]
    [Migration("20210214023527_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("UdemyIdentityServer.AuthServer.Models.CustomUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("customUsers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            City = "Bursa",
                            Email = "emresimsek801@gmail.com",
                            Password = "password",
                            UserName = "esimsek"
                        },
                        new
                        {
                            Id = 2,
                            City = "Ankara",
                            Email = "ugur801@gmail.com",
                            Password = "password",
                            UserName = "uciftci"
                        },
                        new
                        {
                            Id = 3,
                            City = "İzmir",
                            Email = "mehmet@gmail.com",
                            Password = "password",
                            UserName = "mcarp"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
