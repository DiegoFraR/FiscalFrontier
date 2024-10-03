﻿// <auto-generated />
using System;
using FiscalFrontier.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FiscalFrontier.API.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240920005524_AddedIsActivePropertyToUsers")]
    partial class AddedIsActivePropertyToUsers
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FiscalFrontier.API.Models.Domain.Role", b =>
                {
                    b.Property<int>("roleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("roleId"));

                    b.Property<string>("roleName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("roleId");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            roleId = 1,
                            roleName = "Administrator"
                        },
                        new
                        {
                            roleId = 2,
                            roleName = "Manager"
                        },
                        new
                        {
                            roleId = 3,
                            roleName = "Accountant"
                        });
                });

            modelBuilder.Entity("FiscalFrontier.API.Models.Domain.SecurityQuestions", b =>
                {
                    b.Property<int>("securityQuestionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("securityQuestionId"));

                    b.Property<string>("securityQuestion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("securityQuestionId");

                    b.ToTable("SecurityQuestions");

                    b.HasData(
                        new
                        {
                            securityQuestionId = 1,
                            securityQuestion = "What was the first exam you failed?"
                        },
                        new
                        {
                            securityQuestionId = 2,
                            securityQuestion = "What was your Mother/Father's first car brand?"
                        },
                        new
                        {
                            securityQuestionId = 3,
                            securityQuestion = "What was the name of your siblings favorite stuffed animal?"
                        },
                        new
                        {
                            securityQuestionId = 4,
                            securityQuestion = "In what city was your Grandmother or Grandfather born?"
                        });
                });

            modelBuilder.Entity("FiscalFrontier.API.Models.Domain.User", b =>
                {
                    b.Property<Guid>("userId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("createdDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("dateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("firstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isActive")
                        .HasColumnType("bit");

                    b.Property<string>("lastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime>("passwordExpirationDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("roleId")
                        .HasColumnType("int");

                    b.Property<string>("username")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("userId");

                    b.HasIndex("roleId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            userId = new Guid("c8ccce42-b84b-47e1-9088-020c34d520cc"),
                            address = "1100 South Marietta Pkwy SE, Marietta, GA 30060",
                            createdDate = new DateTime(2024, 9, 20, 0, 55, 23, 926, DateTimeKind.Utc).AddTicks(9170),
                            dateOfBirth = new DateTime(2003, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            email = "dfraust4@students.kennesaw.edu",
                            firstName = "Diego",
                            isActive = true,
                            lastName = "Frausto",
                            password = "TestPassword",
                            passwordExpirationDate = new DateTime(2024, 12, 20, 0, 55, 23, 926, DateTimeKind.Utc).AddTicks(9175),
                            roleId = 1,
                            username = "dFrausto0924"
                        },
                        new
                        {
                            userId = new Guid("26d81325-ecbb-4c62-832f-4be67264f075"),
                            address = "1100 South Marietta Pkwy SE, Marietta, GA 30060",
                            createdDate = new DateTime(2024, 9, 20, 0, 55, 23, 926, DateTimeKind.Utc).AddTicks(9185),
                            dateOfBirth = new DateTime(2002, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            email = "ckirkwoo@students.kennesaw.edu",
                            firstName = "Chris",
                            isActive = true,
                            lastName = "Kirkwood",
                            password = "PasswordTest",
                            passwordExpirationDate = new DateTime(2024, 12, 20, 0, 55, 23, 926, DateTimeKind.Utc).AddTicks(9185),
                            roleId = 1,
                            username = "cKirkwood0924"
                        },
                        new
                        {
                            userId = new Guid("ff80c86a-2c36-469f-9353-733f156f1fa3"),
                            address = "1100 South Marietta Pkwy SE, Marietta, GA 30060",
                            createdDate = new DateTime(2024, 9, 20, 0, 55, 23, 926, DateTimeKind.Utc).AddTicks(9187),
                            dateOfBirth = new DateTime(2001, 11, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            email = "rpowel57@students.kennesaw.edu",
                            firstName = "Riley",
                            isActive = true,
                            lastName = "Powell",
                            password = "TestPassword",
                            passwordExpirationDate = new DateTime(2024, 12, 20, 0, 55, 23, 926, DateTimeKind.Utc).AddTicks(9187),
                            roleId = 1,
                            username = "rPowell0924"
                        },
                        new
                        {
                            userId = new Guid("8b66cd7f-3cbe-4c9a-b325-f1a6eafdfe31"),
                            address = "1100 South Marietta Pkwy SE, Marietta, GA 30060",
                            createdDate = new DateTime(2024, 9, 20, 0, 55, 23, 926, DateTimeKind.Utc).AddTicks(9189),
                            dateOfBirth = new DateTime(2001, 5, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            email = "hnguy126@students.kennesaw.edu",
                            firstName = "Hong",
                            isActive = true,
                            lastName = "Nguyen",
                            password = "passwordTest",
                            passwordExpirationDate = new DateTime(2024, 12, 20, 0, 55, 23, 926, DateTimeKind.Utc).AddTicks(9189),
                            roleId = 1,
                            username = "hNguyen0924"
                        },
                        new
                        {
                            userId = new Guid("58ba2a7d-b508-4853-ba31-a2301d4e0b53"),
                            address = "1100 South Marietta Pkwy SE, Marietta, GA 30060",
                            createdDate = new DateTime(2024, 9, 20, 0, 55, 23, 926, DateTimeKind.Utc).AddTicks(9193),
                            dateOfBirth = new DateTime(2024, 9, 17, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            email = "manager@students.kennesaw.edu",
                            firstName = "Manager",
                            isActive = true,
                            lastName = "Account",
                            password = "ManagerPassword",
                            passwordExpirationDate = new DateTime(2024, 12, 20, 0, 55, 23, 926, DateTimeKind.Utc).AddTicks(9194),
                            roleId = 2,
                            username = "mAccount0924"
                        },
                        new
                        {
                            userId = new Guid("cf7437e5-84bd-4bec-a490-0dc754b8ed4f"),
                            address = "1100 South Marietta Pkwy SE, Marietta, GA 30060",
                            createdDate = new DateTime(2024, 9, 20, 0, 55, 23, 926, DateTimeKind.Utc).AddTicks(9195),
                            dateOfBirth = new DateTime(2024, 9, 17, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            email = "accountant@students.kennesaw.edu",
                            firstName = "Accountant",
                            isActive = true,
                            lastName = "Account",
                            password = "AccountantPassword",
                            passwordExpirationDate = new DateTime(2024, 12, 20, 0, 55, 23, 926, DateTimeKind.Utc).AddTicks(9196),
                            roleId = 3,
                            username = "aAccount0924"
                        });
                });

            modelBuilder.Entity("FiscalFrontier.API.Models.Domain.UserSecurityQuestion", b =>
                {
                    b.Property<int>("userSecurityQuestionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("userSecurityQuestionId"));

                    b.Property<string>("answer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("securityQuestionId")
                        .HasColumnType("int");

                    b.Property<Guid>("userId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("userSecurityQuestionId");

                    b.HasIndex("securityQuestionId");

                    b.HasIndex("userId");

                    b.ToTable("UserSecurityQuestions");
                });

            modelBuilder.Entity("FiscalFrontier.API.Models.Domain.User", b =>
                {
                    b.HasOne("FiscalFrontier.API.Models.Domain.Role", "role")
                        .WithMany("users")
                        .HasForeignKey("roleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("role");
                });

            modelBuilder.Entity("FiscalFrontier.API.Models.Domain.UserSecurityQuestion", b =>
                {
                    b.HasOne("FiscalFrontier.API.Models.Domain.SecurityQuestions", "securityQuestion")
                        .WithMany()
                        .HasForeignKey("securityQuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FiscalFrontier.API.Models.Domain.User", "user")
                        .WithMany("securityQuestions")
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("securityQuestion");

                    b.Navigation("user");
                });

            modelBuilder.Entity("FiscalFrontier.API.Models.Domain.Role", b =>
                {
                    b.Navigation("users");
                });

            modelBuilder.Entity("FiscalFrontier.API.Models.Domain.User", b =>
                {
                    b.Navigation("securityQuestions");
                });
#pragma warning restore 612, 618
        }
    }
}