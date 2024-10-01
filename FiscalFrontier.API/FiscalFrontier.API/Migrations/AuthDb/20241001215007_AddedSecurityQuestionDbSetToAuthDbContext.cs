using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FiscalFrontier.API.Migrations.AuthDb
{
    /// <inheritdoc />
    public partial class AddedSecurityQuestionDbSetToAuthDbContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "address", "createdDate", "dateOfBirth", "firstName", "isActive", "lastName", "passwordExpirationDate" },
                values: new object[,]
                {
                    { "214289ac-6983-4c0f-a226-2b59f85da302", 0, "498e956c-707e-4aa5-92fd-ced6903bdab9", "User", "adminAccount@gmail.com", false, false, null, "ADMINACCOUNT@GMAIL.COM", null, "AQAAAAIAAYagAAAAEAedejwnxicXLK3ilAhmza7hJP7aB+6TrkTGee+AqxXpIwSGU3Py83JpMjDUYF5XGg==", null, false, "8eb231ac-c236-4622-aab3-22b903b69598", false, "AAccount0924", "1100 South Marietta Pkwy SE, Marietta, GA 30060", new DateTime(2024, 10, 1, 21, 50, 7, 94, DateTimeKind.Utc).AddTicks(6124), new DateTime(2003, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Admin", true, "SAccount", new DateTime(2025, 1, 1, 21, 50, 7, 94, DateTimeKind.Utc).AddTicks(6130) },
                    { "9764d926-ef60-451e-8ad6-13fc4a9b51a6", 0, "0be58c9e-659c-462a-870c-300b75843500", "User", "accountantAccount@gmail.com", false, false, null, "ACCOUNTANTACCOUNT@GMAIL.COM", null, "AQAAAAIAAYagAAAAEHF7WT+jMP85GiwyT5KtIgjBtINd51Zq4j9Q0aOQ6bagZKVfdnnGJbt3utptuP2pjQ==", null, false, "5bd761c5-0974-44c8-802e-b14d97f1879d", false, "AAccount0824", "1100 South Marietta Pkwy SE, Marietta, GA 30060", new DateTime(2024, 10, 1, 21, 50, 7, 94, DateTimeKind.Utc).AddTicks(6150), new DateTime(2003, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Accountant", true, "Account", new DateTime(2025, 1, 1, 21, 50, 7, 94, DateTimeKind.Utc).AddTicks(6150) },
                    { "c698a3d7-25f4-4b2d-b40d-e38520a38f5c", 0, "38219c31-21fa-4f56-a622-a545d2113928", "User", "managerAccount@gmail.com", false, false, null, "MANAGERACCOUNT@GMAIL.COM", null, "AQAAAAIAAYagAAAAEBRWKXD7k0JUOnjVprnGYsQVRBJfHBFdlJOkuB67Mj6nblQMC1aa92mvlv9JulBnzA==", null, false, "dfd2e817-a38b-468d-b356-c01fc8fb3337", false, "MAccount0924", "1100 South Marietta Pkwy SE, Marietta, GA 30060", new DateTime(2024, 10, 1, 21, 50, 7, 94, DateTimeKind.Utc).AddTicks(6142), new DateTime(2003, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Manager", true, "Account", new DateTime(2025, 1, 1, 21, 50, 7, 94, DateTimeKind.Utc).AddTicks(6142) }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "18ba9546-05ff-44a7-b1e3-ba79f546f06b", "214289ac-6983-4c0f-a226-2b59f85da302" },
                    { "8d6430ec-2c87-4ca9-bc3a-b5025a41d8c9", "214289ac-6983-4c0f-a226-2b59f85da302" },
                    { "ee8190d1-63cd-4c9c-bea4-2d4252de752b", "214289ac-6983-4c0f-a226-2b59f85da302" },
                    { "ee8190d1-63cd-4c9c-bea4-2d4252de752b", "9764d926-ef60-451e-8ad6-13fc4a9b51a6" },
                    { "8d6430ec-2c87-4ca9-bc3a-b5025a41d8c9", "c698a3d7-25f4-4b2d-b40d-e38520a38f5c" },
                    { "ee8190d1-63cd-4c9c-bea4-2d4252de752b", "c698a3d7-25f4-4b2d-b40d-e38520a38f5c" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "18ba9546-05ff-44a7-b1e3-ba79f546f06b", "214289ac-6983-4c0f-a226-2b59f85da302" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "8d6430ec-2c87-4ca9-bc3a-b5025a41d8c9", "214289ac-6983-4c0f-a226-2b59f85da302" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "ee8190d1-63cd-4c9c-bea4-2d4252de752b", "214289ac-6983-4c0f-a226-2b59f85da302" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "ee8190d1-63cd-4c9c-bea4-2d4252de752b", "9764d926-ef60-451e-8ad6-13fc4a9b51a6" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "8d6430ec-2c87-4ca9-bc3a-b5025a41d8c9", "c698a3d7-25f4-4b2d-b40d-e38520a38f5c" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "ee8190d1-63cd-4c9c-bea4-2d4252de752b", "c698a3d7-25f4-4b2d-b40d-e38520a38f5c" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "214289ac-6983-4c0f-a226-2b59f85da302");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9764d926-ef60-451e-8ad6-13fc4a9b51a6");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c698a3d7-25f4-4b2d-b40d-e38520a38f5c");

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
        }
    }
}
