using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FiscalFrontier.API.Migrations
{
    /// <inheritdoc />
    public partial class AddUserCreationRequestModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "userId",
                keyValue: new Guid("34ba1361-adf9-461a-b85b-7aa71c73c758"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "userId",
                keyValue: new Guid("55aaf9dc-9e11-4057-88bc-8424005c5cf3"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "userId",
                keyValue: new Guid("9545ce91-4d23-45fe-ad6d-d7294d08f282"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "userId",
                keyValue: new Guid("a285b20f-7e8f-4a81-8642-2b778dd09ccd"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "userId",
                keyValue: new Guid("b83e6a5b-c8c3-4f69-8730-abfdc3657331"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "userId",
                keyValue: new Guid("ef3f97a5-4268-4ff4-a2c0-6acad09cb0fe"));

            migrationBuilder.CreateTable(
                name: "UserCreationRequests",
                columns: table => new
                {
                    userCreationRequestId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    firstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isApproved = table.Column<bool>(type: "bit", nullable: false),
                    securityQuestion1Id = table.Column<int>(type: "int", nullable: false),
                    securityQuestion1Answer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    securityQuestion2Id = table.Column<int>(type: "int", nullable: false),
                    securityQuestion2Answer = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCreationRequests", x => x.userCreationRequestId);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "userId", "address", "createdDate", "dateOfBirth", "email", "firstName", "isActive", "lastName", "password", "passwordExpirationDate", "roleId", "username" },
                values: new object[,]
                {
                    { new Guid("3202aecf-edea-41bf-a784-631fd6f0320e"), "1100 South Marietta Pkwy SE, Marietta, GA 30060", new DateTime(2024, 9, 25, 20, 40, 13, 122, DateTimeKind.Utc).AddTicks(3508), new DateTime(2003, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "dfraust4@students.kennesaw.edu", "Diego", true, "Frausto", "TestPassword", new DateTime(2024, 12, 25, 20, 40, 13, 122, DateTimeKind.Utc).AddTicks(3514), 1, "dFrausto0924" },
                    { new Guid("44ffb2db-7a91-4cd1-940a-21ec94c8400c"), "1100 South Marietta Pkwy SE, Marietta, GA 30060", new DateTime(2024, 9, 25, 20, 40, 13, 122, DateTimeKind.Utc).AddTicks(3547), new DateTime(2024, 9, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "accountant@students.kennesaw.edu", "Accountant", true, "Account", "AccountantPassword", new DateTime(2024, 12, 25, 20, 40, 13, 122, DateTimeKind.Utc).AddTicks(3547), 3, "aAccount0924" },
                    { new Guid("58a09024-66ab-4c80-b567-1df45afdfb8b"), "1100 South Marietta Pkwy SE, Marietta, GA 30060", new DateTime(2024, 9, 25, 20, 40, 13, 122, DateTimeKind.Utc).AddTicks(3544), new DateTime(2024, 9, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "manager@students.kennesaw.edu", "Manager", true, "Account", "ManagerPassword", new DateTime(2024, 12, 25, 20, 40, 13, 122, DateTimeKind.Utc).AddTicks(3545), 2, "mAccount0924" },
                    { new Guid("73379e82-f63c-43c1-aa59-780ca136e953"), "1100 South Marietta Pkwy SE, Marietta, GA 30060", new DateTime(2024, 9, 25, 20, 40, 13, 122, DateTimeKind.Utc).AddTicks(3542), new DateTime(2001, 5, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "hnguy126@students.kennesaw.edu", "Hong", true, "Nguyen", "passwordTest", new DateTime(2024, 12, 25, 20, 40, 13, 122, DateTimeKind.Utc).AddTicks(3542), 1, "hNguyen0924" },
                    { new Guid("c83b828c-31cb-43c3-a67f-051ea1cd41d3"), "1100 South Marietta Pkwy SE, Marietta, GA 30060", new DateTime(2024, 9, 25, 20, 40, 13, 122, DateTimeKind.Utc).AddTicks(3540), new DateTime(2001, 11, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "rpowel57@students.kennesaw.edu", "Riley", true, "Powell", "TestPassword", new DateTime(2024, 12, 25, 20, 40, 13, 122, DateTimeKind.Utc).AddTicks(3540), 1, "rPowell0924" },
                    { new Guid("c93bc577-2124-47cb-abbe-5c047b1aac5c"), "1100 South Marietta Pkwy SE, Marietta, GA 30060", new DateTime(2024, 9, 25, 20, 40, 13, 122, DateTimeKind.Utc).AddTicks(3526), new DateTime(2002, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "ckirkwoo@students.kennesaw.edu", "Chris", true, "Kirkwood", "PasswordTest", new DateTime(2024, 12, 25, 20, 40, 13, 122, DateTimeKind.Utc).AddTicks(3527), 1, "cKirkwood0924" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserCreationRequests");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "userId",
                keyValue: new Guid("3202aecf-edea-41bf-a784-631fd6f0320e"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "userId",
                keyValue: new Guid("44ffb2db-7a91-4cd1-940a-21ec94c8400c"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "userId",
                keyValue: new Guid("58a09024-66ab-4c80-b567-1df45afdfb8b"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "userId",
                keyValue: new Guid("73379e82-f63c-43c1-aa59-780ca136e953"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "userId",
                keyValue: new Guid("c83b828c-31cb-43c3-a67f-051ea1cd41d3"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "userId",
                keyValue: new Guid("c93bc577-2124-47cb-abbe-5c047b1aac5c"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "userId", "address", "createdDate", "dateOfBirth", "email", "firstName", "isActive", "lastName", "password", "passwordExpirationDate", "roleId", "username" },
                values: new object[,]
                {
                    { new Guid("34ba1361-adf9-461a-b85b-7aa71c73c758"), "1100 South Marietta Pkwy SE, Marietta, GA 30060", new DateTime(2024, 9, 25, 20, 36, 13, 663, DateTimeKind.Utc).AddTicks(1622), new DateTime(2002, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "ckirkwoo@students.kennesaw.edu", "Chris", true, "Kirkwood", "PasswordTest", new DateTime(2024, 12, 25, 20, 36, 13, 663, DateTimeKind.Utc).AddTicks(1622), 1, "cKirkwood0924" },
                    { new Guid("55aaf9dc-9e11-4057-88bc-8424005c5cf3"), "1100 South Marietta Pkwy SE, Marietta, GA 30060", new DateTime(2024, 9, 25, 20, 36, 13, 663, DateTimeKind.Utc).AddTicks(1637), new DateTime(2024, 9, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "manager@students.kennesaw.edu", "Manager", true, "Account", "ManagerPassword", new DateTime(2024, 12, 25, 20, 36, 13, 663, DateTimeKind.Utc).AddTicks(1638), 2, "mAccount0924" },
                    { new Guid("9545ce91-4d23-45fe-ad6d-d7294d08f282"), "1100 South Marietta Pkwy SE, Marietta, GA 30060", new DateTime(2024, 9, 25, 20, 36, 13, 663, DateTimeKind.Utc).AddTicks(1640), new DateTime(2024, 9, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "accountant@students.kennesaw.edu", "Accountant", true, "Account", "AccountantPassword", new DateTime(2024, 12, 25, 20, 36, 13, 663, DateTimeKind.Utc).AddTicks(1640), 3, "aAccount0924" },
                    { new Guid("a285b20f-7e8f-4a81-8642-2b778dd09ccd"), "1100 South Marietta Pkwy SE, Marietta, GA 30060", new DateTime(2024, 9, 25, 20, 36, 13, 663, DateTimeKind.Utc).AddTicks(1634), new DateTime(2001, 5, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "hnguy126@students.kennesaw.edu", "Hong", true, "Nguyen", "passwordTest", new DateTime(2024, 12, 25, 20, 36, 13, 663, DateTimeKind.Utc).AddTicks(1635), 1, "hNguyen0924" },
                    { new Guid("b83e6a5b-c8c3-4f69-8730-abfdc3657331"), "1100 South Marietta Pkwy SE, Marietta, GA 30060", new DateTime(2024, 9, 25, 20, 36, 13, 663, DateTimeKind.Utc).AddTicks(1624), new DateTime(2001, 11, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "rpowel57@students.kennesaw.edu", "Riley", true, "Powell", "TestPassword", new DateTime(2024, 12, 25, 20, 36, 13, 663, DateTimeKind.Utc).AddTicks(1624), 1, "rPowell0924" },
                    { new Guid("ef3f97a5-4268-4ff4-a2c0-6acad09cb0fe"), "1100 South Marietta Pkwy SE, Marietta, GA 30060", new DateTime(2024, 9, 25, 20, 36, 13, 663, DateTimeKind.Utc).AddTicks(1604), new DateTime(2003, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "dfraust4@students.kennesaw.edu", "Diego", true, "Frausto", "TestPassword", new DateTime(2024, 12, 25, 20, 36, 13, 663, DateTimeKind.Utc).AddTicks(1610), 1, "dFrausto0924" }
                });
        }
    }
}
