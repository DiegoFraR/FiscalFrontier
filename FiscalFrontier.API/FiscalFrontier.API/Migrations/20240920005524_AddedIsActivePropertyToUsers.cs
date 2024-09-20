using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FiscalFrontier.API.Migrations
{
    /// <inheritdoc />
    public partial class AddedIsActivePropertyToUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isActive",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "userId", "address", "createdDate", "dateOfBirth", "email", "firstName", "isActive", "lastName", "password", "passwordExpirationDate", "roleId", "username" },
                values: new object[,]
                {
                    { new Guid("26d81325-ecbb-4c62-832f-4be67264f075"), "1100 South Marietta Pkwy SE, Marietta, GA 30060", new DateTime(2024, 9, 20, 0, 55, 23, 926, DateTimeKind.Utc).AddTicks(9185), new DateTime(2002, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "ckirkwoo@students.kennesaw.edu", "Chris", true, "Kirkwood", "PasswordTest", new DateTime(2024, 12, 20, 0, 55, 23, 926, DateTimeKind.Utc).AddTicks(9185), 1, "cKirkwood0924" },
                    { new Guid("58ba2a7d-b508-4853-ba31-a2301d4e0b53"), "1100 South Marietta Pkwy SE, Marietta, GA 30060", new DateTime(2024, 9, 20, 0, 55, 23, 926, DateTimeKind.Utc).AddTicks(9193), new DateTime(2024, 9, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "manager@students.kennesaw.edu", "Manager", true, "Account", "ManagerPassword", new DateTime(2024, 12, 20, 0, 55, 23, 926, DateTimeKind.Utc).AddTicks(9194), 2, "mAccount0924" },
                    { new Guid("8b66cd7f-3cbe-4c9a-b325-f1a6eafdfe31"), "1100 South Marietta Pkwy SE, Marietta, GA 30060", new DateTime(2024, 9, 20, 0, 55, 23, 926, DateTimeKind.Utc).AddTicks(9189), new DateTime(2001, 5, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "hnguy126@students.kennesaw.edu", "Hong", true, "Nguyen", "passwordTest", new DateTime(2024, 12, 20, 0, 55, 23, 926, DateTimeKind.Utc).AddTicks(9189), 1, "hNguyen0924" },
                    { new Guid("c8ccce42-b84b-47e1-9088-020c34d520cc"), "1100 South Marietta Pkwy SE, Marietta, GA 30060", new DateTime(2024, 9, 20, 0, 55, 23, 926, DateTimeKind.Utc).AddTicks(9170), new DateTime(2003, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "dfraust4@students.kennesaw.edu", "Diego", true, "Frausto", "TestPassword", new DateTime(2024, 12, 20, 0, 55, 23, 926, DateTimeKind.Utc).AddTicks(9175), 1, "dFrausto0924" },
                    { new Guid("cf7437e5-84bd-4bec-a490-0dc754b8ed4f"), "1100 South Marietta Pkwy SE, Marietta, GA 30060", new DateTime(2024, 9, 20, 0, 55, 23, 926, DateTimeKind.Utc).AddTicks(9195), new DateTime(2024, 9, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "accountant@students.kennesaw.edu", "Accountant", true, "Account", "AccountantPassword", new DateTime(2024, 12, 20, 0, 55, 23, 926, DateTimeKind.Utc).AddTicks(9196), 3, "aAccount0924" },
                    { new Guid("ff80c86a-2c36-469f-9353-733f156f1fa3"), "1100 South Marietta Pkwy SE, Marietta, GA 30060", new DateTime(2024, 9, 20, 0, 55, 23, 926, DateTimeKind.Utc).AddTicks(9187), new DateTime(2001, 11, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "rpowel57@students.kennesaw.edu", "Riley", true, "Powell", "TestPassword", new DateTime(2024, 12, 20, 0, 55, 23, 926, DateTimeKind.Utc).AddTicks(9187), 1, "rPowell0924" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "userId",
                keyValue: new Guid("26d81325-ecbb-4c62-832f-4be67264f075"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "userId",
                keyValue: new Guid("58ba2a7d-b508-4853-ba31-a2301d4e0b53"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "userId",
                keyValue: new Guid("8b66cd7f-3cbe-4c9a-b325-f1a6eafdfe31"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "userId",
                keyValue: new Guid("c8ccce42-b84b-47e1-9088-020c34d520cc"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "userId",
                keyValue: new Guid("cf7437e5-84bd-4bec-a490-0dc754b8ed4f"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "userId",
                keyValue: new Guid("ff80c86a-2c36-469f-9353-733f156f1fa3"));

            migrationBuilder.DropColumn(
                name: "isActive",
                table: "Users");
        }
    }
}
