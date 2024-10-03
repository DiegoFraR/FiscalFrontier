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
    [Migration("20240925203613_AddedUserCreationRequestModel")]
    partial class AddedUserCreationRequestModel
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
                            userId = new Guid("ef3f97a5-4268-4ff4-a2c0-6acad09cb0fe"),
                            address = "1100 South Marietta Pkwy SE, Marietta, GA 30060",
                            createdDate = new DateTime(2024, 9, 25, 20, 36, 13, 663, DateTimeKind.Utc).AddTicks(1604),
                            dateOfBirth = new DateTime(2003, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            email = "dfraust4@students.kennesaw.edu",
                            firstName = "Diego",
                            isActive = true,
                            lastName = "Frausto",
                            password = "TestPassword",
                            passwordExpirationDate = new DateTime(2024, 12, 25, 20, 36, 13, 663, DateTimeKind.Utc).AddTicks(1610),
                            roleId = 1,
                            username = "dFrausto0924"
                        },
                        new
                        {
                            userId = new Guid("34ba1361-adf9-461a-b85b-7aa71c73c758"),
                            address = "1100 South Marietta Pkwy SE, Marietta, GA 30060",
                            createdDate = new DateTime(2024, 9, 25, 20, 36, 13, 663, DateTimeKind.Utc).AddTicks(1622),
                            dateOfBirth = new DateTime(2002, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            email = "ckirkwoo@students.kennesaw.edu",
                            firstName = "Chris",
                            isActive = true,
                            lastName = "Kirkwood",
                            password = "PasswordTest",
                            passwordExpirationDate = new DateTime(2024, 12, 25, 20, 36, 13, 663, DateTimeKind.Utc).AddTicks(1622),
                            roleId = 1,
                            username = "cKirkwood0924"
                        },
                        new
                        {
                            userId = new Guid("b83e6a5b-c8c3-4f69-8730-abfdc3657331"),
                            address = "1100 South Marietta Pkwy SE, Marietta, GA 30060",
                            createdDate = new DateTime(2024, 9, 25, 20, 36, 13, 663, DateTimeKind.Utc).AddTicks(1624),
                            dateOfBirth = new DateTime(2001, 11, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            email = "rpowel57@students.kennesaw.edu",
                            firstName = "Riley",
                            isActive = true,
                            lastName = "Powell",
                            password = "TestPassword",
                            passwordExpirationDate = new DateTime(2024, 12, 25, 20, 36, 13, 663, DateTimeKind.Utc).AddTicks(1624),
                            roleId = 1,
                            username = "rPowell0924"
                        },
                        new
                        {
                            userId = new Guid("a285b20f-7e8f-4a81-8642-2b778dd09ccd"),
                            address = "1100 South Marietta Pkwy SE, Marietta, GA 30060",
                            createdDate = new DateTime(2024, 9, 25, 20, 36, 13, 663, DateTimeKind.Utc).AddTicks(1634),
                            dateOfBirth = new DateTime(2001, 5, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            email = "hnguy126@students.kennesaw.edu",
                            firstName = "Hong",
                            isActive = true,
                            lastName = "Nguyen",
                            password = "passwordTest",
                            passwordExpirationDate = new DateTime(2024, 12, 25, 20, 36, 13, 663, DateTimeKind.Utc).AddTicks(1635),
                            roleId = 1,
                            username = "hNguyen0924"
                        },
                        new
                        {
                            userId = new Guid("55aaf9dc-9e11-4057-88bc-8424005c5cf3"),
                            address = "1100 South Marietta Pkwy SE, Marietta, GA 30060",
                            createdDate = new DateTime(2024, 9, 25, 20, 36, 13, 663, DateTimeKind.Utc).AddTicks(1637),
                            dateOfBirth = new DateTime(2024, 9, 17, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            email = "manager@students.kennesaw.edu",
                            firstName = "Manager",
                            isActive = true,
                            lastName = "Account",
                            password = "ManagerPassword",
                            passwordExpirationDate = new DateTime(2024, 12, 25, 20, 36, 13, 663, DateTimeKind.Utc).AddTicks(1638),
                            roleId = 2,
                            username = "mAccount0924"
                        },
                        new
                        {
                            userId = new Guid("9545ce91-4d23-45fe-ad6d-d7294d08f282"),
                            address = "1100 South Marietta Pkwy SE, Marietta, GA 30060",
                            createdDate = new DateTime(2024, 9, 25, 20, 36, 13, 663, DateTimeKind.Utc).AddTicks(1640),
                            dateOfBirth = new DateTime(2024, 9, 17, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            email = "accountant@students.kennesaw.edu",
                            firstName = "Accountant",
                            isActive = true,
                            lastName = "Account",
                            password = "AccountantPassword",
                            passwordExpirationDate = new DateTime(2024, 12, 25, 20, 36, 13, 663, DateTimeKind.Utc).AddTicks(1640),
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