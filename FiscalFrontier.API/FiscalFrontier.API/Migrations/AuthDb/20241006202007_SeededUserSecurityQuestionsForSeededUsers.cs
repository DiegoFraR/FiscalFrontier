using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FiscalFrontier.API.Migrations.AuthDb
{
    /// <inheritdoc />
    public partial class SeededUserSecurityQuestionsForSeededUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { "7986a011-569b-42e2-8c72-aceec91935b6", 0, "388df760-d93f-42b9-a820-f6903172798e", "User", "accountantAccount@gmail.com", false, false, null, "ACCOUNTANTACCOUNT@GMAIL.COM", null, "AQAAAAIAAYagAAAAEHnv4i/xUHpcsdjoOfzxLqgBKy1hpCBiB8uUyH9WvQRtjnXCp8PiYtCgGCApC3Ndbg==", null, false, "b69bd6f7-eef7-4bbf-b2cc-e920ec012bed", false, "AAccount0824", "1100 South Marietta Pkwy SE, Marietta, GA 30060", new DateTime(2024, 10, 6, 20, 20, 7, 509, DateTimeKind.Utc).AddTicks(1812), new DateTime(2003, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Accountant", true, "Account", new DateTime(2025, 1, 6, 20, 20, 7, 509, DateTimeKind.Utc).AddTicks(1813) },
                    { "dc1fa6d7-e0a9-475a-bdcb-f9ce52ea3e84", 0, "075576b4-41a2-4b04-8912-09f4410fd0ae", "User", "adminAccount@gmail.com", false, false, null, "ADMINACCOUNT@GMAIL.COM", null, "AQAAAAIAAYagAAAAEEQtpXvPdmfUDSR1x3UViM91GhSWoyEVx1nDiuH6YvnU7TwJLcpG0M+aNc3YJpckAA==", null, false, "8df4cea3-6691-4623-9bb4-8a6b2e0a487f", false, "AAccount0924", "1100 South Marietta Pkwy SE, Marietta, GA 30060", new DateTime(2024, 10, 6, 20, 20, 7, 509, DateTimeKind.Utc).AddTicks(1788), new DateTime(2003, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Admin", true, "SAccount", new DateTime(2025, 1, 6, 20, 20, 7, 509, DateTimeKind.Utc).AddTicks(1792) },
                    { "dfc5d997-71da-4f11-8ec9-f15065a717e9", 0, "8fa70163-b1d9-4018-bf3e-1020d645f764", "User", "managerAccount@gmail.com", false, false, null, "MANAGERACCOUNT@GMAIL.COM", null, "AQAAAAIAAYagAAAAEGi9qzGH0Zq7n3EVWUFoBeLlJfzJkd0Q4RlNICzkg/8M8cUVo1xIAWlAyDISQFZIAw==", null, false, "726424bf-4044-4fce-8883-3b28e9a6fc39", false, "MAccount0924", "1100 South Marietta Pkwy SE, Marietta, GA 30060", new DateTime(2024, 10, 6, 20, 20, 7, 509, DateTimeKind.Utc).AddTicks(1807), new DateTime(2003, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Manager", true, "Account", new DateTime(2025, 1, 6, 20, 20, 7, 509, DateTimeKind.Utc).AddTicks(1807) }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "ee8190d1-63cd-4c9c-bea4-2d4252de752b", "7986a011-569b-42e2-8c72-aceec91935b6" },
                    { "18ba9546-05ff-44a7-b1e3-ba79f546f06b", "dc1fa6d7-e0a9-475a-bdcb-f9ce52ea3e84" },
                    { "8d6430ec-2c87-4ca9-bc3a-b5025a41d8c9", "dc1fa6d7-e0a9-475a-bdcb-f9ce52ea3e84" },
                    { "ee8190d1-63cd-4c9c-bea4-2d4252de752b", "dc1fa6d7-e0a9-475a-bdcb-f9ce52ea3e84" },
                    { "8d6430ec-2c87-4ca9-bc3a-b5025a41d8c9", "dfc5d997-71da-4f11-8ec9-f15065a717e9" },
                    { "ee8190d1-63cd-4c9c-bea4-2d4252de752b", "dfc5d997-71da-4f11-8ec9-f15065a717e9" }
                });

            migrationBuilder.InsertData(
                table: "UserSecurityQuestions",
                columns: new[] { "userSecurityQuestionId", "answer", "securityQuestionId", "userId" },
                values: new object[,]
                {
                    { 1, "Accounting 101", 1, "dc1fa6d7-e0a9-475a-bdcb-f9ce52ea3e84" },
                    { 2, "Porsche", 2, "dc1fa6d7-e0a9-475a-bdcb-f9ce52ea3e84" },
                    { 3, "Clifford the Big Red Dog", 3, "dfc5d997-71da-4f11-8ec9-f15065a717e9" },
                    { 4, "Marietta, Georgia", 4, "dfc5d997-71da-4f11-8ec9-f15065a717e9" },
                    { 5, "Nissan", 1, "7986a011-569b-42e2-8c72-aceec91935b6" },
                    { 6, "Atlanta, Georgia", 4, "dc1fa6d7-e0a9-475a-bdcb-f9ce52ea3e84" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "ee8190d1-63cd-4c9c-bea4-2d4252de752b", "7986a011-569b-42e2-8c72-aceec91935b6" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "18ba9546-05ff-44a7-b1e3-ba79f546f06b", "dc1fa6d7-e0a9-475a-bdcb-f9ce52ea3e84" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "8d6430ec-2c87-4ca9-bc3a-b5025a41d8c9", "dc1fa6d7-e0a9-475a-bdcb-f9ce52ea3e84" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "ee8190d1-63cd-4c9c-bea4-2d4252de752b", "dc1fa6d7-e0a9-475a-bdcb-f9ce52ea3e84" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "8d6430ec-2c87-4ca9-bc3a-b5025a41d8c9", "dfc5d997-71da-4f11-8ec9-f15065a717e9" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "ee8190d1-63cd-4c9c-bea4-2d4252de752b", "dfc5d997-71da-4f11-8ec9-f15065a717e9" });

            migrationBuilder.DeleteData(
                table: "UserSecurityQuestions",
                keyColumn: "userSecurityQuestionId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "UserSecurityQuestions",
                keyColumn: "userSecurityQuestionId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "UserSecurityQuestions",
                keyColumn: "userSecurityQuestionId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "UserSecurityQuestions",
                keyColumn: "userSecurityQuestionId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "UserSecurityQuestions",
                keyColumn: "userSecurityQuestionId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "UserSecurityQuestions",
                keyColumn: "userSecurityQuestionId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7986a011-569b-42e2-8c72-aceec91935b6");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dc1fa6d7-e0a9-475a-bdcb-f9ce52ea3e84");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dfc5d997-71da-4f11-8ec9-f15065a717e9");

            migrationBuilder.DeleteData(
                table: "SecurityQuestions",
                keyColumn: "securityQuestionId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "SecurityQuestions",
                keyColumn: "securityQuestionId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "SecurityQuestions",
                keyColumn: "securityQuestionId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "SecurityQuestions",
                keyColumn: "securityQuestionId",
                keyValue: 4);

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
    }
}
