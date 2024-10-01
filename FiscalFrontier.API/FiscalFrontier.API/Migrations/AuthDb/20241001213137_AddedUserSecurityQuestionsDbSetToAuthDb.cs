using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FiscalFrontier.API.Migrations.AuthDb
{
    /// <inheritdoc />
    public partial class AddedUserSecurityQuestionsDbSetToAuthDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserSecurityQuestion_AspNetUsers_userId",
                table: "UserSecurityQuestion");

            migrationBuilder.DropForeignKey(
                name: "FK_UserSecurityQuestion_SecurityQuestions_securityQuestionId",
                table: "UserSecurityQuestion");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserSecurityQuestion",
                table: "UserSecurityQuestion");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "ee8190d1-63cd-4c9c-bea4-2d4252de752b", "6c03716f-09dd-47d4-9ea2-5442c05d4e36" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "8d6430ec-2c87-4ca9-bc3a-b5025a41d8c9", "705f3e55-408a-4fe1-887c-cfb86cd83e73" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "ee8190d1-63cd-4c9c-bea4-2d4252de752b", "705f3e55-408a-4fe1-887c-cfb86cd83e73" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "18ba9546-05ff-44a7-b1e3-ba79f546f06b", "b1166ae1-b210-4956-b145-b644b4ad9c44" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "8d6430ec-2c87-4ca9-bc3a-b5025a41d8c9", "b1166ae1-b210-4956-b145-b644b4ad9c44" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "ee8190d1-63cd-4c9c-bea4-2d4252de752b", "b1166ae1-b210-4956-b145-b644b4ad9c44" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6c03716f-09dd-47d4-9ea2-5442c05d4e36");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "705f3e55-408a-4fe1-887c-cfb86cd83e73");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b1166ae1-b210-4956-b145-b644b4ad9c44");

            migrationBuilder.RenameTable(
                name: "UserSecurityQuestion",
                newName: "UserSecurityQuestions");

            migrationBuilder.RenameIndex(
                name: "IX_UserSecurityQuestion_userId",
                table: "UserSecurityQuestions",
                newName: "IX_UserSecurityQuestions_userId");

            migrationBuilder.RenameIndex(
                name: "IX_UserSecurityQuestion_securityQuestionId",
                table: "UserSecurityQuestions",
                newName: "IX_UserSecurityQuestions_securityQuestionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserSecurityQuestions",
                table: "UserSecurityQuestions",
                column: "userSecurityQuestionId");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "address", "createdDate", "dateOfBirth", "firstName", "isActive", "lastName", "passwordExpirationDate" },
                values: new object[,]
                {
                    { "1db47540-e787-4fa6-aa4f-5c24444019df", 0, "3cc086d8-aa36-42d9-b703-e21d4bebfd58", "User", "accountantAccount@gmail.com", false, false, null, "ACCOUNTANTACCOUNT@GMAIL.COM", null, "AQAAAAIAAYagAAAAEKpEEmcYHDQ4LXkh5+OAQc6y9EPwZXXB7pPlc1qK+ralt65xsfMPzJ2BOXKtpd7Xwg==", null, false, "2e24bf6b-1ad6-4444-8257-a6e990003c9f", false, "AAccount0824", "1100 South Marietta Pkwy SE, Marietta, GA 30060", new DateTime(2024, 10, 1, 21, 31, 37, 1, DateTimeKind.Utc).AddTicks(2360), new DateTime(2003, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Accountant", true, "Account", new DateTime(2025, 1, 1, 21, 31, 37, 1, DateTimeKind.Utc).AddTicks(2360) },
                    { "88621266-4f74-469e-9b07-4f3d9e1190b8", 0, "34dc587f-39d5-4e10-89f2-b8ce23fffce4", "User", "adminAccount@gmail.com", false, false, null, "ADMINACCOUNT@GMAIL.COM", null, "AQAAAAIAAYagAAAAEBkZRMP5LPTABrpjYcdwHSnBs1qmc2YvE/iSVx83M+s4bOKL9fYK1eNoO0XNvs5eOQ==", null, false, "273d7035-1d60-4548-a1b6-41beab245617", false, "AAccount0924", "1100 South Marietta Pkwy SE, Marietta, GA 30060", new DateTime(2024, 10, 1, 21, 31, 37, 1, DateTimeKind.Utc).AddTicks(2334), new DateTime(2003, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Admin", true, "SAccount", new DateTime(2025, 1, 1, 21, 31, 37, 1, DateTimeKind.Utc).AddTicks(2338) },
                    { "efef4286-fa1a-49ae-96f1-6bf50e7cce07", 0, "e882309e-1a57-4b08-9f0d-6e8820460deb", "User", "managerAccount@gmail.com", false, false, null, "MANAGERACCOUNT@GMAIL.COM", null, "AQAAAAIAAYagAAAAEIwk0R6wbDcr0uUefn5AsSOZ9qIMDFTx+8SegaiuAOLNSZRrh91dO+S82ux/xWDp4w==", null, false, "ac255e6c-b5d8-407c-b2de-a5e7ab889d37", false, "MAccount0924", "1100 South Marietta Pkwy SE, Marietta, GA 30060", new DateTime(2024, 10, 1, 21, 31, 37, 1, DateTimeKind.Utc).AddTicks(2353), new DateTime(2003, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Manager", true, "Account", new DateTime(2025, 1, 1, 21, 31, 37, 1, DateTimeKind.Utc).AddTicks(2353) }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "ee8190d1-63cd-4c9c-bea4-2d4252de752b", "1db47540-e787-4fa6-aa4f-5c24444019df" },
                    { "18ba9546-05ff-44a7-b1e3-ba79f546f06b", "88621266-4f74-469e-9b07-4f3d9e1190b8" },
                    { "8d6430ec-2c87-4ca9-bc3a-b5025a41d8c9", "88621266-4f74-469e-9b07-4f3d9e1190b8" },
                    { "ee8190d1-63cd-4c9c-bea4-2d4252de752b", "88621266-4f74-469e-9b07-4f3d9e1190b8" },
                    { "8d6430ec-2c87-4ca9-bc3a-b5025a41d8c9", "efef4286-fa1a-49ae-96f1-6bf50e7cce07" },
                    { "ee8190d1-63cd-4c9c-bea4-2d4252de752b", "efef4286-fa1a-49ae-96f1-6bf50e7cce07" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_UserSecurityQuestions_AspNetUsers_userId",
                table: "UserSecurityQuestions",
                column: "userId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserSecurityQuestions_SecurityQuestions_securityQuestionId",
                table: "UserSecurityQuestions",
                column: "securityQuestionId",
                principalTable: "SecurityQuestions",
                principalColumn: "securityQuestionId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserSecurityQuestions_AspNetUsers_userId",
                table: "UserSecurityQuestions");

            migrationBuilder.DropForeignKey(
                name: "FK_UserSecurityQuestions_SecurityQuestions_securityQuestionId",
                table: "UserSecurityQuestions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserSecurityQuestions",
                table: "UserSecurityQuestions");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "ee8190d1-63cd-4c9c-bea4-2d4252de752b", "1db47540-e787-4fa6-aa4f-5c24444019df" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "18ba9546-05ff-44a7-b1e3-ba79f546f06b", "88621266-4f74-469e-9b07-4f3d9e1190b8" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "8d6430ec-2c87-4ca9-bc3a-b5025a41d8c9", "88621266-4f74-469e-9b07-4f3d9e1190b8" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "ee8190d1-63cd-4c9c-bea4-2d4252de752b", "88621266-4f74-469e-9b07-4f3d9e1190b8" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "8d6430ec-2c87-4ca9-bc3a-b5025a41d8c9", "efef4286-fa1a-49ae-96f1-6bf50e7cce07" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "ee8190d1-63cd-4c9c-bea4-2d4252de752b", "efef4286-fa1a-49ae-96f1-6bf50e7cce07" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1db47540-e787-4fa6-aa4f-5c24444019df");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "88621266-4f74-469e-9b07-4f3d9e1190b8");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "efef4286-fa1a-49ae-96f1-6bf50e7cce07");

            migrationBuilder.RenameTable(
                name: "UserSecurityQuestions",
                newName: "UserSecurityQuestion");

            migrationBuilder.RenameIndex(
                name: "IX_UserSecurityQuestions_userId",
                table: "UserSecurityQuestion",
                newName: "IX_UserSecurityQuestion_userId");

            migrationBuilder.RenameIndex(
                name: "IX_UserSecurityQuestions_securityQuestionId",
                table: "UserSecurityQuestion",
                newName: "IX_UserSecurityQuestion_securityQuestionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserSecurityQuestion",
                table: "UserSecurityQuestion",
                column: "userSecurityQuestionId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_UserSecurityQuestion_AspNetUsers_userId",
                table: "UserSecurityQuestion",
                column: "userId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserSecurityQuestion_SecurityQuestions_securityQuestionId",
                table: "UserSecurityQuestion",
                column: "securityQuestionId",
                principalTable: "SecurityQuestions",
                principalColumn: "securityQuestionId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
