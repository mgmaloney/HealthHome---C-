﻿// <auto-generated />
using HealthHome;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace HealthHome___C_.Migrations
{
    [DbContext(typeof(HealthHomeDbContext))]
    partial class HealthHomeDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("HealthHome.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .HasColumnType("text");

                    b.Property<bool>("Admin")
                        .HasColumnType("boolean");

                    b.Property<string>("Birthdate")
                        .HasColumnType("text");

                    b.Property<string>("Credential")
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<string>("Gender")
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("Provider")
                        .HasColumnType("boolean");

                    b.Property<string>("Sex")
                        .HasColumnType("text");

                    b.Property<string>("Ssn")
                        .HasColumnType("text");

                    b.Property<string>("Uid")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "12 Princeton Ln, Plainsboro, NJ 08512",
                            Admin = false,
                            Credential = "MD",
                            Email = "house@malpractice.com",
                            FirstName = "Gregory",
                            Gender = "he/him",
                            LastName = "House",
                            PhoneNumber = "555-555-5555",
                            Provider = true,
                            Sex = "male"
                        },
                        new
                        {
                            Id = 3,
                            Address = "125 Witchy Lane",
                            Admin = false,
                            Email = "junejune22@gmail.com",
                            FirstName = "June",
                            LastName = "Bloom",
                            Provider = false
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
