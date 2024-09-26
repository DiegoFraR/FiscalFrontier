﻿// <auto-generated />
using System;
using FiscalFrontier.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FiscalFrontier.API.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
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

            modelBuilder.Entity("FiscalFrontier.API.Models.Domain.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(max)");

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
                        .HasColumnType("nvarchar(max)");

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

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("FiscalFrontier.API.Models.Domain.UserCreationRequest", b =>
                {
                    b.Property<int>("userCreationRequestId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("userCreationRequestId"));

                    b.Property<string>("address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("dateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("firstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isApproved")
                        .HasColumnType("bit");

                    b.Property<string>("lastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("securityQuestion1Answer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("securityQuestion1Id")
                        .HasColumnType("int");

                    b.Property<string>("securityQuestion2Answer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("securityQuestion2Id")
                        .HasColumnType("int");

                    b.HasKey("userCreationRequestId");

                    b.ToTable("UserCreationRequests");
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

            modelBuilder.Entity("FiscalFrontier.API.Models.Domain.User", b =>
                {
                    b.Navigation("securityQuestions");
                });
#pragma warning restore 612, 618
        }
    }
}
