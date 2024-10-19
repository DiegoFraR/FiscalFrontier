﻿// <auto-generated />
using System;
using FiscalFrontier.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FiscalFrontier.API.Migrations.AuthDb
{
    [DbContext(typeof(AuthDbContext))]
    partial class AuthDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.HasData(
                        new
                        {
                            userSecurityQuestionId = 1,
                            answer = "Accounting 101",
                            securityQuestionId = 1,
                            userId = "c0a369a7-1b57-4125-9500-cc2a385ef35d"
                        },
                        new
                        {
                            userSecurityQuestionId = 2,
                            answer = "Porsche",
                            securityQuestionId = 2,
                            userId = "c0a369a7-1b57-4125-9500-cc2a385ef35d"
                        },
                        new
                        {
                            userSecurityQuestionId = 3,
                            answer = "Accounting 101",
                            securityQuestionId = 1,
                            userId = "67177e9c-8bec-4523-9e56-7b8718f5b211"
                        },
                        new
                        {
                            userSecurityQuestionId = 4,
                            answer = "Porsche",
                            securityQuestionId = 2,
                            userId = "67177e9c-8bec-4523-9e56-7b8718f5b211"
                        },
                        new
                        {
                            userSecurityQuestionId = 5,
                            answer = "Accounting 101",
                            securityQuestionId = 1,
                            userId = "727bc198-a42d-49f8-8cd1-5f62201189fe"
                        },
                        new
                        {
                            userSecurityQuestionId = 6,
                            answer = "Porsche",
                            securityQuestionId = 2,
                            userId = "727bc198-a42d-49f8-8cd1-5f62201189fe"
                        },
                        new
                        {
                            userSecurityQuestionId = 7,
                            answer = "Accounting 101",
                            securityQuestionId = 1,
                            userId = "61e2095b-4248-4eff-b5a5-7a0d0becf05f"
                        },
                        new
                        {
                            userSecurityQuestionId = 8,
                            answer = "Porsche",
                            securityQuestionId = 2,
                            userId = "61e2095b-4248-4eff-b5a5-7a0d0becf05f"
                        },
                        new
                        {
                            userSecurityQuestionId = 9,
                            answer = "Clifford the Big Red Dog",
                            securityQuestionId = 3,
                            userId = "da93e5b5-7621-4080-b54b-0ef06f0dc995"
                        },
                        new
                        {
                            userSecurityQuestionId = 10,
                            answer = "Marietta, Georgia",
                            securityQuestionId = 4,
                            userId = "da93e5b5-7621-4080-b54b-0ef06f0dc995"
                        },
                        new
                        {
                            userSecurityQuestionId = 11,
                            answer = "Nissan",
                            securityQuestionId = 1,
                            userId = "3cc02f88-d557-4550-86a7-52c994865981"
                        },
                        new
                        {
                            userSecurityQuestionId = 12,
                            answer = "Atlanta, Georgia",
                            securityQuestionId = 4,
                            userId = "3cc02f88-d557-4550-86a7-52c994865981"
                        });
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
                            UserId = "c0a369a7-1b57-4125-9500-cc2a385ef35d",
                            RoleId = "18ba9546-05ff-44a7-b1e3-ba79f546f06b"
                        },
                        new
                        {
                            UserId = "c0a369a7-1b57-4125-9500-cc2a385ef35d",
                            RoleId = "ee8190d1-63cd-4c9c-bea4-2d4252de752b"
                        },
                        new
                        {
                            UserId = "c0a369a7-1b57-4125-9500-cc2a385ef35d",
                            RoleId = "8d6430ec-2c87-4ca9-bc3a-b5025a41d8c9"
                        },
                        new
                        {
                            UserId = "67177e9c-8bec-4523-9e56-7b8718f5b211",
                            RoleId = "18ba9546-05ff-44a7-b1e3-ba79f546f06b"
                        },
                        new
                        {
                            UserId = "67177e9c-8bec-4523-9e56-7b8718f5b211",
                            RoleId = "ee8190d1-63cd-4c9c-bea4-2d4252de752b"
                        },
                        new
                        {
                            UserId = "67177e9c-8bec-4523-9e56-7b8718f5b211",
                            RoleId = "8d6430ec-2c87-4ca9-bc3a-b5025a41d8c9"
                        },
                        new
                        {
                            UserId = "727bc198-a42d-49f8-8cd1-5f62201189fe",
                            RoleId = "18ba9546-05ff-44a7-b1e3-ba79f546f06b"
                        },
                        new
                        {
                            UserId = "727bc198-a42d-49f8-8cd1-5f62201189fe",
                            RoleId = "ee8190d1-63cd-4c9c-bea4-2d4252de752b"
                        },
                        new
                        {
                            UserId = "727bc198-a42d-49f8-8cd1-5f62201189fe",
                            RoleId = "8d6430ec-2c87-4ca9-bc3a-b5025a41d8c9"
                        },
                        new
                        {
                            UserId = "61e2095b-4248-4eff-b5a5-7a0d0becf05f",
                            RoleId = "18ba9546-05ff-44a7-b1e3-ba79f546f06b"
                        },
                        new
                        {
                            UserId = "61e2095b-4248-4eff-b5a5-7a0d0becf05f",
                            RoleId = "ee8190d1-63cd-4c9c-bea4-2d4252de752b"
                        },
                        new
                        {
                            UserId = "61e2095b-4248-4eff-b5a5-7a0d0becf05f",
                            RoleId = "8d6430ec-2c87-4ca9-bc3a-b5025a41d8c9"
                        },
                        new
                        {
                            UserId = "da93e5b5-7621-4080-b54b-0ef06f0dc995",
                            RoleId = "ee8190d1-63cd-4c9c-bea4-2d4252de752b"
                        },
                        new
                        {
                            UserId = "da93e5b5-7621-4080-b54b-0ef06f0dc995",
                            RoleId = "8d6430ec-2c87-4ca9-bc3a-b5025a41d8c9"
                        },
                        new
                        {
                            UserId = "3cc02f88-d557-4550-86a7-52c994865981",
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
                            Id = "c0a369a7-1b57-4125-9500-cc2a385ef35d",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "a11c9d3b-b66f-425c-8c5c-329f9e9f5369",
                            Email = "dfraust4@students.kennesaw.edu",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "DFRAUST4@STUDENTS.KENNESAW.EDU",
                            PasswordHash = "AQAAAAIAAYagAAAAEK8jRz8xcV0ytsDG561aPnl4pkkmgtcXzz8jPsOmRz0yV+iRp5ymGFKjO90deiOXFQ==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "9629bb3c-c098-4394-bd38-28501d073a40",
                            TwoFactorEnabled = false,
                            UserName = "DFrausto1024",
                            address = "1100 South Marietta Pkwy SE, Marietta, GA 30060",
                            createdDate = new DateTime(2024, 10, 19, 15, 22, 28, 169, DateTimeKind.Utc).AddTicks(9698),
                            dateOfBirth = new DateTime(2003, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            firstName = "Diego",
                            isActive = true,
                            lastName = "Frausto",
                            passwordExpirationDate = new DateTime(2025, 1, 19, 15, 22, 28, 169, DateTimeKind.Utc).AddTicks(9702)
                        },
                        new
                        {
                            Id = "67177e9c-8bec-4523-9e56-7b8718f5b211",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "fbf34607-3d67-4bfe-b95a-ba0e5d175f9d",
                            Email = "ckirkwoo@students.kennesaw.edu",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "CKIRKWOO@STUDENTS.KENNESAW.EDU",
                            PasswordHash = "AQAAAAIAAYagAAAAECmpHc/QrNqp5ueTMorifxvvGJybvkrT8VFP8l+HoTLKm0nXuUDf39Z98dUzmT2NLw==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "a5a78625-1aaf-4af6-8927-996e3839ee45",
                            TwoFactorEnabled = false,
                            UserName = "CKirkwood1024",
                            address = "1100 South Marietta Pkwy SE, Marietta, GA 30060",
                            createdDate = new DateTime(2024, 10, 19, 15, 22, 28, 204, DateTimeKind.Utc).AddTicks(6247),
                            dateOfBirth = new DateTime(2002, 4, 24, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            firstName = "Chris",
                            isActive = true,
                            lastName = "Kirkwood",
                            passwordExpirationDate = new DateTime(2025, 1, 19, 15, 22, 28, 204, DateTimeKind.Utc).AddTicks(6253)
                        },
                        new
                        {
                            Id = "727bc198-a42d-49f8-8cd1-5f62201189fe",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "7e641913-773e-4577-8798-c598939a88d9",
                            Email = "rpowel57@students.kennesaw.edu",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "RPOWEL57@STUDENTS.KENNESAW.EDU",
                            PasswordHash = "AQAAAAIAAYagAAAAEGAIx4Q741NAXf/cYz6ZeW2s0OZ8s8N/WpJ9PTvl4e6V9uiKGwh70ms+vhZinc5Ofw==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "e3b0ef70-7684-418f-a9bb-3f5862227c98",
                            TwoFactorEnabled = false,
                            UserName = "RPowell1024",
                            address = "1100 South Marietta Pkwy SE, Marietta, GA 30060",
                            createdDate = new DateTime(2024, 10, 19, 15, 22, 28, 239, DateTimeKind.Utc).AddTicks(232),
                            dateOfBirth = new DateTime(2002, 7, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            firstName = "Riley",
                            isActive = true,
                            lastName = "Powell",
                            passwordExpirationDate = new DateTime(2025, 1, 19, 15, 22, 28, 239, DateTimeKind.Utc).AddTicks(239)
                        },
                        new
                        {
                            Id = "61e2095b-4248-4eff-b5a5-7a0d0becf05f",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "32262c41-8f3e-41cc-9018-e7ef69f0690e",
                            Email = "hnguy126@students.kennesaw.edu",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "HNGUY126@STUDENTS.KENNESAW.EDU",
                            PasswordHash = "AQAAAAIAAYagAAAAEPDxAPAlFghYWxYaZElTh/bepo7n6HxmjOBw6TAJlWMHEmeHPnKS8EHaKqS1P1cFyw==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "7429cb21-aeeb-4344-8a0c-486c4db96c64",
                            TwoFactorEnabled = false,
                            UserName = "HNguyen1024",
                            address = "1100 South Marietta Pkwy SE, Marietta, GA 30060",
                            createdDate = new DateTime(2024, 10, 19, 15, 22, 28, 272, DateTimeKind.Utc).AddTicks(8278),
                            dateOfBirth = new DateTime(2003, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            firstName = "Hong",
                            isActive = true,
                            lastName = "Nguyen",
                            passwordExpirationDate = new DateTime(2025, 1, 19, 15, 22, 28, 272, DateTimeKind.Utc).AddTicks(8287)
                        },
                        new
                        {
                            Id = "da93e5b5-7621-4080-b54b-0ef06f0dc995",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "f700fe2c-0d47-438e-8d62-e0e03746cf1c",
                            Email = "managerAccount@gmail.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "MANAGERACCOUNT@GMAIL.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAEJaQkVIo3GWlwdokncP1U6KWBfl5qRBJvO6LoW0yd/xbPnM4ftb3BaNXEc3ZNuJK3g==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "a8bb1e67-96dc-4095-9967-4888269572c4",
                            TwoFactorEnabled = false,
                            UserName = "MAccount0924",
                            address = "1100 South Marietta Pkwy SE, Marietta, GA 30060",
                            createdDate = new DateTime(2024, 10, 19, 15, 22, 28, 306, DateTimeKind.Utc).AddTicks(5097),
                            dateOfBirth = new DateTime(2003, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            firstName = "Manager",
                            isActive = true,
                            lastName = "Account",
                            passwordExpirationDate = new DateTime(2025, 1, 19, 15, 22, 28, 306, DateTimeKind.Utc).AddTicks(5100)
                        },
                        new
                        {
                            Id = "3cc02f88-d557-4550-86a7-52c994865981",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "cef8e151-b1d4-4b59-aa20-b967a45e4105",
                            Email = "accountantAccount@gmail.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "ACCOUNTANTACCOUNT@GMAIL.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAEC+2qeGSxE1DuueCB/XKuK6sq7KfNXiavwA6fa63Z0zUuCO/1qYoVba/Jcjpvvc8xw==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "5d1713c2-201f-450a-a8a3-b8ac60622c6e",
                            TwoFactorEnabled = false,
                            UserName = "AAccount0824",
                            address = "1100 South Marietta Pkwy SE, Marietta, GA 30060",
                            createdDate = new DateTime(2024, 10, 19, 15, 22, 28, 306, DateTimeKind.Utc).AddTicks(5108),
                            dateOfBirth = new DateTime(2003, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            firstName = "Accountant",
                            isActive = true,
                            lastName = "Account",
                            passwordExpirationDate = new DateTime(2025, 1, 19, 15, 22, 28, 306, DateTimeKind.Utc).AddTicks(5108)
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
