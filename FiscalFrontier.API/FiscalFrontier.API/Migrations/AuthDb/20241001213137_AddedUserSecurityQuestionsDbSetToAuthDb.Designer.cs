﻿// <auto-generated />
using System;
using FiscalFrontier.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FiscalFrontier.API.Migrations.AuthDb
{
    [DbContext(typeof(AuthDbContext))]
    [Migration("20241001213137_AddedUserSecurityQuestionsDbSetToAuthDb")]
    partial class AddedUserSecurityQuestionsDbSetToAuthDb
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

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

                    b.Property<string>("userId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("userSecurityQuestionId");

                    b.HasIndex("securityQuestionId");

                    b.HasIndex("userId");

                    b.ToTable("UserSecurityQuestions");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "18ba9546-05ff-44a7-b1e3-ba79f546f06b",
                            ConcurrencyStamp = "18ba9546-05ff-44a7-b1e3-ba79f546f06b",
                            Name = "Administrator",
                            NormalizedName = "ADMINISTRATOR"
                        },
                        new
                        {
                            Id = "ee8190d1-63cd-4c9c-bea4-2d4252de752b",
                            ConcurrencyStamp = "ee8190d1-63cd-4c9c-bea4-2d4252de752b",
                            Name = "Manager",
                            NormalizedName = "MANAGER"
                        },
                        new
                        {
                            Id = "8d6430ec-2c87-4ca9-bc3a-b5025a41d8c9",
                            ConcurrencyStamp = "8d6430ec-2c87-4ca9-bc3a-b5025a41d8c9",
                            Name = "Accountant",
                            NormalizedName = "ACCOUNTANT"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasDiscriminator().HasValue("IdentityUser");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = "88621266-4f74-469e-9b07-4f3d9e1190b8",
                            RoleId = "18ba9546-05ff-44a7-b1e3-ba79f546f06b"
                        },
                        new
                        {
                            UserId = "88621266-4f74-469e-9b07-4f3d9e1190b8",
                            RoleId = "ee8190d1-63cd-4c9c-bea4-2d4252de752b"
                        },
                        new
                        {
                            UserId = "88621266-4f74-469e-9b07-4f3d9e1190b8",
                            RoleId = "8d6430ec-2c87-4ca9-bc3a-b5025a41d8c9"
                        },
                        new
                        {
                            UserId = "efef4286-fa1a-49ae-96f1-6bf50e7cce07",
                            RoleId = "ee8190d1-63cd-4c9c-bea4-2d4252de752b"
                        },
                        new
                        {
                            UserId = "efef4286-fa1a-49ae-96f1-6bf50e7cce07",
                            RoleId = "8d6430ec-2c87-4ca9-bc3a-b5025a41d8c9"
                        },
                        new
                        {
                            UserId = "1db47540-e787-4fa6-aa4f-5c24444019df",
                            RoleId = "ee8190d1-63cd-4c9c-bea4-2d4252de752b"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("FiscalFrontier.API.Models.Domain.User", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUser");

                    b.Property<string>("address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("createdDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("dateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("firstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isActive")
                        .HasColumnType("bit");

                    b.Property<string>("lastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("passwordExpirationDate")
                        .HasColumnType("datetime2");

                    b.HasDiscriminator().HasValue("User");

                    b.HasData(
                        new
                        {
                            Id = "88621266-4f74-469e-9b07-4f3d9e1190b8",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "34dc587f-39d5-4e10-89f2-b8ce23fffce4",
                            Email = "adminAccount@gmail.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "ADMINACCOUNT@GMAIL.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAEBkZRMP5LPTABrpjYcdwHSnBs1qmc2YvE/iSVx83M+s4bOKL9fYK1eNoO0XNvs5eOQ==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "273d7035-1d60-4548-a1b6-41beab245617",
                            TwoFactorEnabled = false,
                            UserName = "AAccount0924",
                            address = "1100 South Marietta Pkwy SE, Marietta, GA 30060",
                            createdDate = new DateTime(2024, 10, 1, 21, 31, 37, 1, DateTimeKind.Utc).AddTicks(2334),
                            dateOfBirth = new DateTime(2003, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            firstName = "Admin",
                            isActive = true,
                            lastName = "SAccount",
                            passwordExpirationDate = new DateTime(2025, 1, 1, 21, 31, 37, 1, DateTimeKind.Utc).AddTicks(2338)
                        },
                        new
                        {
                            Id = "efef4286-fa1a-49ae-96f1-6bf50e7cce07",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "e882309e-1a57-4b08-9f0d-6e8820460deb",
                            Email = "managerAccount@gmail.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "MANAGERACCOUNT@GMAIL.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAEIwk0R6wbDcr0uUefn5AsSOZ9qIMDFTx+8SegaiuAOLNSZRrh91dO+S82ux/xWDp4w==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "ac255e6c-b5d8-407c-b2de-a5e7ab889d37",
                            TwoFactorEnabled = false,
                            UserName = "MAccount0924",
                            address = "1100 South Marietta Pkwy SE, Marietta, GA 30060",
                            createdDate = new DateTime(2024, 10, 1, 21, 31, 37, 1, DateTimeKind.Utc).AddTicks(2353),
                            dateOfBirth = new DateTime(2003, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            firstName = "Manager",
                            isActive = true,
                            lastName = "Account",
                            passwordExpirationDate = new DateTime(2025, 1, 1, 21, 31, 37, 1, DateTimeKind.Utc).AddTicks(2353)
                        },
                        new
                        {
                            Id = "1db47540-e787-4fa6-aa4f-5c24444019df",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "3cc086d8-aa36-42d9-b703-e21d4bebfd58",
                            Email = "accountantAccount@gmail.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "ACCOUNTANTACCOUNT@GMAIL.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAEKpEEmcYHDQ4LXkh5+OAQc6y9EPwZXXB7pPlc1qK+ralt65xsfMPzJ2BOXKtpd7Xwg==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "2e24bf6b-1ad6-4444-8257-a6e990003c9f",
                            TwoFactorEnabled = false,
                            UserName = "AAccount0824",
                            address = "1100 South Marietta Pkwy SE, Marietta, GA 30060",
                            createdDate = new DateTime(2024, 10, 1, 21, 31, 37, 1, DateTimeKind.Utc).AddTicks(2360),
                            dateOfBirth = new DateTime(2003, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            firstName = "Accountant",
                            isActive = true,
                            lastName = "Account",
                            passwordExpirationDate = new DateTime(2025, 1, 1, 21, 31, 37, 1, DateTimeKind.Utc).AddTicks(2360)
                        });
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

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FiscalFrontier.API.Models.Domain.User", b =>
                {
                    b.Navigation("securityQuestions");
                });
#pragma warning restore 612, 618
        }
    }
}
