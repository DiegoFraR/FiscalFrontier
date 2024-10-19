using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FiscalFrontier.API.Migrations.AuthDb
{
    /// <inheritdoc />
    public partial class AddedTeamMembersAsAdmins : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "address", "createdDate", "dateOfBirth", "firstName", "isActive", "lastName", "passwordExpirationDate" },
                values: new object[,]
                {
                    { "3cc02f88-d557-4550-86a7-52c994865981", 0, "cef8e151-b1d4-4b59-aa20-b967a45e4105", "User", "accountantAccount@gmail.com", false, false, null, "ACCOUNTANTACCOUNT@GMAIL.COM", null, "AQAAAAIAAYagAAAAEC+2qeGSxE1DuueCB/XKuK6sq7KfNXiavwA6fa63Z0zUuCO/1qYoVba/Jcjpvvc8xw==", null, false, "5d1713c2-201f-450a-a8a3-b8ac60622c6e", false, "AAccount0824", "1100 South Marietta Pkwy SE, Marietta, GA 30060", new DateTime(2024, 10, 19, 15, 22, 28, 306, DateTimeKind.Utc).AddTicks(5108), new DateTime(2003, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Accountant", true, "Account", new DateTime(2025, 1, 19, 15, 22, 28, 306, DateTimeKind.Utc).AddTicks(5108) },
                    { "61e2095b-4248-4eff-b5a5-7a0d0becf05f", 0, "32262c41-8f3e-41cc-9018-e7ef69f0690e", "User", "hnguy126@students.kennesaw.edu", false, false, null, "HNGUY126@STUDENTS.KENNESAW.EDU", null, "AQAAAAIAAYagAAAAEPDxAPAlFghYWxYaZElTh/bepo7n6HxmjOBw6TAJlWMHEmeHPnKS8EHaKqS1P1cFyw==", null, false, "7429cb21-aeeb-4344-8a0c-486c4db96c64", false, "HNguyen1024", "1100 South Marietta Pkwy SE, Marietta, GA 30060", new DateTime(2024, 10, 19, 15, 22, 28, 272, DateTimeKind.Utc).AddTicks(8278), new DateTime(2003, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hong", true, "Nguyen", new DateTime(2025, 1, 19, 15, 22, 28, 272, DateTimeKind.Utc).AddTicks(8287) },
                    { "67177e9c-8bec-4523-9e56-7b8718f5b211", 0, "fbf34607-3d67-4bfe-b95a-ba0e5d175f9d", "User", "ckirkwoo@students.kennesaw.edu", false, false, null, "CKIRKWOO@STUDENTS.KENNESAW.EDU", null, "AQAAAAIAAYagAAAAECmpHc/QrNqp5ueTMorifxvvGJybvkrT8VFP8l+HoTLKm0nXuUDf39Z98dUzmT2NLw==", null, false, "a5a78625-1aaf-4af6-8927-996e3839ee45", false, "CKirkwood1024", "1100 South Marietta Pkwy SE, Marietta, GA 30060", new DateTime(2024, 10, 19, 15, 22, 28, 204, DateTimeKind.Utc).AddTicks(6247), new DateTime(2002, 4, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chris", true, "Kirkwood", new DateTime(2025, 1, 19, 15, 22, 28, 204, DateTimeKind.Utc).AddTicks(6253) },
                    { "727bc198-a42d-49f8-8cd1-5f62201189fe", 0, "7e641913-773e-4577-8798-c598939a88d9", "User", "rpowel57@students.kennesaw.edu", false, false, null, "RPOWEL57@STUDENTS.KENNESAW.EDU", null, "AQAAAAIAAYagAAAAEGAIx4Q741NAXf/cYz6ZeW2s0OZ8s8N/WpJ9PTvl4e6V9uiKGwh70ms+vhZinc5Ofw==", null, false, "e3b0ef70-7684-418f-a9bb-3f5862227c98", false, "RPowell1024", "1100 South Marietta Pkwy SE, Marietta, GA 30060", new DateTime(2024, 10, 19, 15, 22, 28, 239, DateTimeKind.Utc).AddTicks(232), new DateTime(2002, 7, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Riley", true, "Powell", new DateTime(2025, 1, 19, 15, 22, 28, 239, DateTimeKind.Utc).AddTicks(239) },
                    { "c0a369a7-1b57-4125-9500-cc2a385ef35d", 0, "a11c9d3b-b66f-425c-8c5c-329f9e9f5369", "User", "dfraust4@students.kennesaw.edu", false, false, null, "DFRAUST4@STUDENTS.KENNESAW.EDU", null, "AQAAAAIAAYagAAAAEK8jRz8xcV0ytsDG561aPnl4pkkmgtcXzz8jPsOmRz0yV+iRp5ymGFKjO90deiOXFQ==", null, false, "9629bb3c-c098-4394-bd38-28501d073a40", false, "DFrausto1024", "1100 South Marietta Pkwy SE, Marietta, GA 30060", new DateTime(2024, 10, 19, 15, 22, 28, 169, DateTimeKind.Utc).AddTicks(9698), new DateTime(2003, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Diego", true, "Frausto", new DateTime(2025, 1, 19, 15, 22, 28, 169, DateTimeKind.Utc).AddTicks(9702) },
                    { "da93e5b5-7621-4080-b54b-0ef06f0dc995", 0, "f700fe2c-0d47-438e-8d62-e0e03746cf1c", "User", "managerAccount@gmail.com", false, false, null, "MANAGERACCOUNT@GMAIL.COM", null, "AQAAAAIAAYagAAAAEJaQkVIo3GWlwdokncP1U6KWBfl5qRBJvO6LoW0yd/xbPnM4ftb3BaNXEc3ZNuJK3g==", null, false, "a8bb1e67-96dc-4095-9967-4888269572c4", false, "MAccount0924", "1100 South Marietta Pkwy SE, Marietta, GA 30060", new DateTime(2024, 10, 19, 15, 22, 28, 306, DateTimeKind.Utc).AddTicks(5097), new DateTime(2003, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Manager", true, "Account", new DateTime(2025, 1, 19, 15, 22, 28, 306, DateTimeKind.Utc).AddTicks(5100) }
                });

            migrationBuilder.UpdateData(
                table: "UserSecurityQuestions",
                keyColumn: "userSecurityQuestionId",
                keyValue: 1,
                column: "userId",
                value: "c0a369a7-1b57-4125-9500-cc2a385ef35d");

            migrationBuilder.UpdateData(
                table: "UserSecurityQuestions",
                keyColumn: "userSecurityQuestionId",
                keyValue: 2,
                column: "userId",
                value: "c0a369a7-1b57-4125-9500-cc2a385ef35d");

            migrationBuilder.UpdateData(
                table: "UserSecurityQuestions",
                keyColumn: "userSecurityQuestionId",
                keyValue: 3,
                columns: new[] { "answer", "securityQuestionId", "userId" },
                values: new object[] { "Accounting 101", 1, "67177e9c-8bec-4523-9e56-7b8718f5b211" });

            migrationBuilder.UpdateData(
                table: "UserSecurityQuestions",
                keyColumn: "userSecurityQuestionId",
                keyValue: 4,
                columns: new[] { "answer", "securityQuestionId", "userId" },
                values: new object[] { "Porsche", 2, "67177e9c-8bec-4523-9e56-7b8718f5b211" });

            migrationBuilder.UpdateData(
                table: "UserSecurityQuestions",
                keyColumn: "userSecurityQuestionId",
                keyValue: 5,
                columns: new[] { "answer", "userId" },
                values: new object[] { "Accounting 101", "727bc198-a42d-49f8-8cd1-5f62201189fe" });

            migrationBuilder.UpdateData(
                table: "UserSecurityQuestions",
                keyColumn: "userSecurityQuestionId",
                keyValue: 6,
                columns: new[] { "answer", "securityQuestionId", "userId" },
                values: new object[] { "Porsche", 2, "727bc198-a42d-49f8-8cd1-5f62201189fe" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "ee8190d1-63cd-4c9c-bea4-2d4252de752b", "3cc02f88-d557-4550-86a7-52c994865981" },
                    { "18ba9546-05ff-44a7-b1e3-ba79f546f06b", "61e2095b-4248-4eff-b5a5-7a0d0becf05f" },
                    { "8d6430ec-2c87-4ca9-bc3a-b5025a41d8c9", "61e2095b-4248-4eff-b5a5-7a0d0becf05f" },
                    { "ee8190d1-63cd-4c9c-bea4-2d4252de752b", "61e2095b-4248-4eff-b5a5-7a0d0becf05f" },
                    { "18ba9546-05ff-44a7-b1e3-ba79f546f06b", "67177e9c-8bec-4523-9e56-7b8718f5b211" },
                    { "8d6430ec-2c87-4ca9-bc3a-b5025a41d8c9", "67177e9c-8bec-4523-9e56-7b8718f5b211" },
                    { "ee8190d1-63cd-4c9c-bea4-2d4252de752b", "67177e9c-8bec-4523-9e56-7b8718f5b211" },
                    { "18ba9546-05ff-44a7-b1e3-ba79f546f06b", "727bc198-a42d-49f8-8cd1-5f62201189fe" },
                    { "8d6430ec-2c87-4ca9-bc3a-b5025a41d8c9", "727bc198-a42d-49f8-8cd1-5f62201189fe" },
                    { "ee8190d1-63cd-4c9c-bea4-2d4252de752b", "727bc198-a42d-49f8-8cd1-5f62201189fe" },
                    { "18ba9546-05ff-44a7-b1e3-ba79f546f06b", "c0a369a7-1b57-4125-9500-cc2a385ef35d" },
                    { "8d6430ec-2c87-4ca9-bc3a-b5025a41d8c9", "c0a369a7-1b57-4125-9500-cc2a385ef35d" },
                    { "ee8190d1-63cd-4c9c-bea4-2d4252de752b", "c0a369a7-1b57-4125-9500-cc2a385ef35d" },
                    { "8d6430ec-2c87-4ca9-bc3a-b5025a41d8c9", "da93e5b5-7621-4080-b54b-0ef06f0dc995" },
                    { "ee8190d1-63cd-4c9c-bea4-2d4252de752b", "da93e5b5-7621-4080-b54b-0ef06f0dc995" }
                });

            migrationBuilder.InsertData(
                table: "UserSecurityQuestions",
                columns: new[] { "userSecurityQuestionId", "answer", "securityQuestionId", "userId" },
                values: new object[,]
                {
                    { 7, "Accounting 101", 1, "61e2095b-4248-4eff-b5a5-7a0d0becf05f" },
                    { 8, "Porsche", 2, "61e2095b-4248-4eff-b5a5-7a0d0becf05f" },
                    { 9, "Clifford the Big Red Dog", 3, "da93e5b5-7621-4080-b54b-0ef06f0dc995" },
                    { 10, "Marietta, Georgia", 4, "da93e5b5-7621-4080-b54b-0ef06f0dc995" },
                    { 11, "Nissan", 1, "3cc02f88-d557-4550-86a7-52c994865981" },
                    { 12, "Atlanta, Georgia", 4, "3cc02f88-d557-4550-86a7-52c994865981" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "ee8190d1-63cd-4c9c-bea4-2d4252de752b", "3cc02f88-d557-4550-86a7-52c994865981" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "18ba9546-05ff-44a7-b1e3-ba79f546f06b", "61e2095b-4248-4eff-b5a5-7a0d0becf05f" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "8d6430ec-2c87-4ca9-bc3a-b5025a41d8c9", "61e2095b-4248-4eff-b5a5-7a0d0becf05f" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "ee8190d1-63cd-4c9c-bea4-2d4252de752b", "61e2095b-4248-4eff-b5a5-7a0d0becf05f" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "18ba9546-05ff-44a7-b1e3-ba79f546f06b", "67177e9c-8bec-4523-9e56-7b8718f5b211" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "8d6430ec-2c87-4ca9-bc3a-b5025a41d8c9", "67177e9c-8bec-4523-9e56-7b8718f5b211" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "ee8190d1-63cd-4c9c-bea4-2d4252de752b", "67177e9c-8bec-4523-9e56-7b8718f5b211" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "18ba9546-05ff-44a7-b1e3-ba79f546f06b", "727bc198-a42d-49f8-8cd1-5f62201189fe" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "8d6430ec-2c87-4ca9-bc3a-b5025a41d8c9", "727bc198-a42d-49f8-8cd1-5f62201189fe" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "ee8190d1-63cd-4c9c-bea4-2d4252de752b", "727bc198-a42d-49f8-8cd1-5f62201189fe" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "18ba9546-05ff-44a7-b1e3-ba79f546f06b", "c0a369a7-1b57-4125-9500-cc2a385ef35d" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "8d6430ec-2c87-4ca9-bc3a-b5025a41d8c9", "c0a369a7-1b57-4125-9500-cc2a385ef35d" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "ee8190d1-63cd-4c9c-bea4-2d4252de752b", "c0a369a7-1b57-4125-9500-cc2a385ef35d" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "8d6430ec-2c87-4ca9-bc3a-b5025a41d8c9", "da93e5b5-7621-4080-b54b-0ef06f0dc995" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "ee8190d1-63cd-4c9c-bea4-2d4252de752b", "da93e5b5-7621-4080-b54b-0ef06f0dc995" });

            migrationBuilder.DeleteData(
                table: "UserSecurityQuestions",
                keyColumn: "userSecurityQuestionId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "UserSecurityQuestions",
                keyColumn: "userSecurityQuestionId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "UserSecurityQuestions",
                keyColumn: "userSecurityQuestionId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "UserSecurityQuestions",
                keyColumn: "userSecurityQuestionId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "UserSecurityQuestions",
                keyColumn: "userSecurityQuestionId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "UserSecurityQuestions",
                keyColumn: "userSecurityQuestionId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3cc02f88-d557-4550-86a7-52c994865981");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "61e2095b-4248-4eff-b5a5-7a0d0becf05f");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "67177e9c-8bec-4523-9e56-7b8718f5b211");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "727bc198-a42d-49f8-8cd1-5f62201189fe");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c0a369a7-1b57-4125-9500-cc2a385ef35d");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "da93e5b5-7621-4080-b54b-0ef06f0dc995");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "address", "createdDate", "dateOfBirth", "firstName", "isActive", "lastName", "passwordExpirationDate" },
                values: new object[,]
                {
                    { "7986a011-569b-42e2-8c72-aceec91935b6", 0, "388df760-d93f-42b9-a820-f6903172798e", "User", "accountantAccount@gmail.com", false, false, null, "ACCOUNTANTACCOUNT@GMAIL.COM", null, "AQAAAAIAAYagAAAAEHnv4i/xUHpcsdjoOfzxLqgBKy1hpCBiB8uUyH9WvQRtjnXCp8PiYtCgGCApC3Ndbg==", null, false, "b69bd6f7-eef7-4bbf-b2cc-e920ec012bed", false, "AAccount0824", "1100 South Marietta Pkwy SE, Marietta, GA 30060", new DateTime(2024, 10, 6, 20, 20, 7, 509, DateTimeKind.Utc).AddTicks(1812), new DateTime(2003, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Accountant", true, "Account", new DateTime(2025, 1, 6, 20, 20, 7, 509, DateTimeKind.Utc).AddTicks(1813) },
                    { "dc1fa6d7-e0a9-475a-bdcb-f9ce52ea3e84", 0, "075576b4-41a2-4b04-8912-09f4410fd0ae", "User", "adminAccount@gmail.com", false, false, null, "ADMINACCOUNT@GMAIL.COM", null, "AQAAAAIAAYagAAAAEEQtpXvPdmfUDSR1x3UViM91GhSWoyEVx1nDiuH6YvnU7TwJLcpG0M+aNc3YJpckAA==", null, false, "8df4cea3-6691-4623-9bb4-8a6b2e0a487f", false, "AAccount0924", "1100 South Marietta Pkwy SE, Marietta, GA 30060", new DateTime(2024, 10, 6, 20, 20, 7, 509, DateTimeKind.Utc).AddTicks(1788), new DateTime(2003, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Admin", true, "SAccount", new DateTime(2025, 1, 6, 20, 20, 7, 509, DateTimeKind.Utc).AddTicks(1792) },
                    { "dfc5d997-71da-4f11-8ec9-f15065a717e9", 0, "8fa70163-b1d9-4018-bf3e-1020d645f764", "User", "managerAccount@gmail.com", false, false, null, "MANAGERACCOUNT@GMAIL.COM", null, "AQAAAAIAAYagAAAAEGi9qzGH0Zq7n3EVWUFoBeLlJfzJkd0Q4RlNICzkg/8M8cUVo1xIAWlAyDISQFZIAw==", null, false, "726424bf-4044-4fce-8883-3b28e9a6fc39", false, "MAccount0924", "1100 South Marietta Pkwy SE, Marietta, GA 30060", new DateTime(2024, 10, 6, 20, 20, 7, 509, DateTimeKind.Utc).AddTicks(1807), new DateTime(2003, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Manager", true, "Account", new DateTime(2025, 1, 6, 20, 20, 7, 509, DateTimeKind.Utc).AddTicks(1807) }
                });

            migrationBuilder.UpdateData(
                table: "UserSecurityQuestions",
                keyColumn: "userSecurityQuestionId",
                keyValue: 1,
                column: "userId",
                value: "dc1fa6d7-e0a9-475a-bdcb-f9ce52ea3e84");

            migrationBuilder.UpdateData(
                table: "UserSecurityQuestions",
                keyColumn: "userSecurityQuestionId",
                keyValue: 2,
                column: "userId",
                value: "dc1fa6d7-e0a9-475a-bdcb-f9ce52ea3e84");

            migrationBuilder.UpdateData(
                table: "UserSecurityQuestions",
                keyColumn: "userSecurityQuestionId",
                keyValue: 3,
                columns: new[] { "answer", "securityQuestionId", "userId" },
                values: new object[] { "Clifford the Big Red Dog", 3, "dfc5d997-71da-4f11-8ec9-f15065a717e9" });

            migrationBuilder.UpdateData(
                table: "UserSecurityQuestions",
                keyColumn: "userSecurityQuestionId",
                keyValue: 4,
                columns: new[] { "answer", "securityQuestionId", "userId" },
                values: new object[] { "Marietta, Georgia", 4, "dfc5d997-71da-4f11-8ec9-f15065a717e9" });

            migrationBuilder.UpdateData(
                table: "UserSecurityQuestions",
                keyColumn: "userSecurityQuestionId",
                keyValue: 5,
                columns: new[] { "answer", "userId" },
                values: new object[] { "Nissan", "7986a011-569b-42e2-8c72-aceec91935b6" });

            migrationBuilder.UpdateData(
                table: "UserSecurityQuestions",
                keyColumn: "userSecurityQuestionId",
                keyValue: 6,
                columns: new[] { "answer", "securityQuestionId", "userId" },
                values: new object[] { "Atlanta, Georgia", 4, "dc1fa6d7-e0a9-475a-bdcb-f9ce52ea3e84" });

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
        }
    }
}
