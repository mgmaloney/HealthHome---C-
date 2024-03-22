﻿// <auto-generated />
using System;
using HealthHome;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace HealthHome___C_.Migrations
{
    [DbContext(typeof(HealthHomeDbContext))]
    [Migration("20240322034440_ConversationMessages")]
    partial class ConversationMessages
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("HealthHome.Models.Allergy", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int?>("PatientId")
                        .HasColumnType("integer");

                    b.Property<string>("Reaction")
                        .HasColumnType("text");

                    b.Property<string>("Severity")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Allergies");
                });

            modelBuilder.Entity("HealthHome.Models.Conversation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.HasKey("Id");

                    b.ToTable("Conversations");
                });

            modelBuilder.Entity("HealthHome.Models.Message", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Content")
                        .HasColumnType("text");

                    b.Property<int>("ConversationId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool>("Read")
                        .HasColumnType("boolean");

                    b.Property<int>("RecipientId")
                        .HasColumnType("integer");

                    b.Property<int>("SenderId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ConversationId");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("HealthHome.Models.PatientMed", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Dose")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int>("PatientId")
                        .HasColumnType("integer");

                    b.Property<string>("Route")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("PatientMeds");
                });

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

            modelBuilder.Entity("HealthHome.Models.Message", b =>
                {
                    b.HasOne("HealthHome.Models.Conversation", null)
                        .WithMany("Messages")
                        .HasForeignKey("ConversationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HealthHome.Models.Conversation", b =>
                {
                    b.Navigation("Messages");
                });
#pragma warning restore 612, 618
        }
    }
}
