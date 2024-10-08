using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FiscalFrontier.API.Migrations.AuthDb
{
    /// <inheritdoc />
    public partial class ModifiedUserObjectForAuthentication : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    firstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    createdDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    passwordExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SecurityQuestions",
                columns: table => new
                {
                    securityQuestionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    securityQuestion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SecurityQuestions", x => x.securityQuestionId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserSecurityQuestion",
                columns: table => new
                {
                    userSecurityQuestionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    securityQuestionId = table.Column<int>(type: "int", nullable: false),
                    answer = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSecurityQuestion", x => x.userSecurityQuestionId);
                    table.ForeignKey(
                        name: "FK_UserSecurityQuestion_AspNetUsers_userId",
                        column: x => x.userId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserSecurityQuestion_SecurityQuestions_securityQuestionId",
                        column: x => x.securityQuestionId,
                        principalTable: "SecurityQuestions",
                        principalColumn: "securityQuestionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "18ba9546-05ff-44a7-b1e3-ba79f546f06b", "18ba9546-05ff-44a7-b1e3-ba79f546f06b", "Administrator", "ADMINISTRATOR" },
                    { "8d6430ec-2c87-4ca9-bc3a-b5025a41d8c9", "8d6430ec-2c87-4ca9-bc3a-b5025a41d8c9", "Accountant", "ACCOUNTANT" },
                    { "ee8190d1-63cd-4c9c-bea4-2d4252de752b", "ee8190d1-63cd-4c9c-bea4-2d4252de752b", "Manager", "MANAGER" }
                });

            migrationBuilder.InsertData(
                table: "SecurityQuestions",
                columns: new[] { "securityQuestionId", "securityQuestion" },
                values: new object[,]
                {
                    {1, "What was the first exam you failed?" },
                    {2, "What was your Mother/Father's first car brand?" },
                    {3, "What was the name of your siblings favorite stuffed animal?" },
                    {4, "In what city was your Grandmother or Grandfather born?" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "address", "createdDate", "dateOfBirth", "firstName", "isActive", "lastName", "passwordExpirationDate" },
                values: new object[,]
                {
                    { "6c03716f-09dd-47d4-9ea2-5442c05d4e36", 0, "2874298b-6c91-4b2c-95a1-e08ea38b2305", "User", "accountantAccount@gmail.com", false, false, null, "ACCOUNTANTACCOUNT@GMAIL.COM", null, "AQAAAAIAAYagAAAAEBC+LeCnUpMajOKEk7So87X0C+CyU3P3KwVQK1ro35nzzD78uycUa9yqS/YzPgcmMA==", null, false, "e81f6053-39ee-4826-9dbe-2a14e3a5156b", false, "AAccount0824", "1100 South Marietta Pkwy SE, Marietta, GA 30060", new DateTime(2024, 9, 26, 20, 27, 13, 412, DateTimeKind.Utc).AddTicks(6384), new DateTime(2003, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Accountant", true, "Account", new DateTime(2024, 12, 26, 20, 27, 13, 412, DateTimeKind.Utc).AddTicks(6384) },
                    { "705f3e55-408a-4fe1-887c-cfb86cd83e73", 0, "bd8cb3cc-8bea-45a3-b845-c93b1a70486f", "User", "managerAccount@gmail.com", false, false, null, "MANAGERACCOUNT@GMAIL.COM", null, "AQAAAAIAAYagAAAAEEFlmvV/his1aylh2zTo7nuKIZrtYLWhUwXoPdzVun/dpm69EJNdYAMbup59JiOw6A==", null, false, "8bba35af-667a-492c-bed9-d655f384ca43", false, "MAccount0924", "1100 South Marietta Pkwy SE, Marietta, GA 30060", new DateTime(2024, 9, 26, 20, 27, 13, 412, DateTimeKind.Utc).AddTicks(6376), new DateTime(2003, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Manager", true, "Account", new DateTime(2024, 12, 26, 20, 27, 13, 412, DateTimeKind.Utc).AddTicks(6377) },
                    { "b1166ae1-b210-4956-b145-b644b4ad9c44", 0, "043dd152-1edf-4fdb-9d51-4680cbd71aa9", "User", "adminAccount@gmail.com", false, false, null, "ADMINACCOUNT@GMAIL.COM", null, "AQAAAAIAAYagAAAAEOuIUT3fa+Z4oGzha06kHkQdD3NINmYDF08Krw2KASZrWqRaVcnisfm1V8nqcT4FhQ==", null, false, "4181462b-dd50-46dc-a818-53b373963e48", false, "AAccount0924", "1100 South Marietta Pkwy SE, Marietta, GA 30060", new DateTime(2024, 9, 26, 20, 27, 13, 412, DateTimeKind.Utc).AddTicks(6358), new DateTime(2003, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Admin", true, "SAccount", new DateTime(2024, 12, 26, 20, 27, 13, 412, DateTimeKind.Utc).AddTicks(6365) }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "ee8190d1-63cd-4c9c-bea4-2d4252de752b", "6c03716f-09dd-47d4-9ea2-5442c05d4e36" },
                    { "8d6430ec-2c87-4ca9-bc3a-b5025a41d8c9", "705f3e55-408a-4fe1-887c-cfb86cd83e73" },
                    { "ee8190d1-63cd-4c9c-bea4-2d4252de752b", "705f3e55-408a-4fe1-887c-cfb86cd83e73" },
                    { "18ba9546-05ff-44a7-b1e3-ba79f546f06b", "b1166ae1-b210-4956-b145-b644b4ad9c44" },
                    { "8d6430ec-2c87-4ca9-bc3a-b5025a41d8c9", "b1166ae1-b210-4956-b145-b644b4ad9c44" },
                    { "ee8190d1-63cd-4c9c-bea4-2d4252de752b", "b1166ae1-b210-4956-b145-b644b4ad9c44" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_UserSecurityQuestion_securityQuestionId",
                table: "UserSecurityQuestion",
                column: "securityQuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSecurityQuestion_userId",
                table: "UserSecurityQuestion",
                column: "userId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "UserSecurityQuestion");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "SecurityQuestions");
        }
    }
}
