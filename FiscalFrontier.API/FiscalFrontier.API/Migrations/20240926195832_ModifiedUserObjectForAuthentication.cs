using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FiscalFrontier.API.Migrations
{
    /// <inheritdoc />
    public partial class ModifiedUserObjectForAuthentication : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Roles_roleId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_UserSecurityQuestions_Users_userId",
                table: "UserSecurityQuestions");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_roleId",
                table: "Users");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "userId",
                keyColumnType: "uniqueidentifier",
                keyValue: new Guid("3202aecf-edea-41bf-a784-631fd6f0320e"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "userId",
                keyColumnType: "uniqueidentifier",
                keyValue: new Guid("44ffb2db-7a91-4cd1-940a-21ec94c8400c"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "userId",
                keyColumnType: "uniqueidentifier",
                keyValue: new Guid("58a09024-66ab-4c80-b567-1df45afdfb8b"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "userId",
                keyColumnType: "uniqueidentifier",
                keyValue: new Guid("73379e82-f63c-43c1-aa59-780ca136e953"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "userId",
                keyColumnType: "uniqueidentifier",
                keyValue: new Guid("c83b828c-31cb-43c3-a67f-051ea1cd41d3"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "userId",
                keyColumnType: "uniqueidentifier",
                keyValue: new Guid("c93bc577-2124-47cb-abbe-5c047b1aac5c"));

            migrationBuilder.DropColumn(
                name: "userId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "password",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "username",
                table: "Users",
                newName: "UserName");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "Users",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "roleId",
                table: "Users",
                newName: "AccessFailedCount");

            migrationBuilder.AlterColumn<string>(
                name: "userId",
                table: "UserSecurityQuestions",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);

            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "Users",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ConcurrencyStamp",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "EmailConfirmed",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "LockoutEnabled",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "LockoutEnd",
                table: "Users",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedEmail",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedUserName",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PasswordHash",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PhoneNumberConfirmed",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "SecurityStamp",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "TwoFactorEnabled",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserSecurityQuestions_Users_userId",
                table: "UserSecurityQuestions",
                column: "userId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserSecurityQuestions_Users_userId",
                table: "UserSecurityQuestions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ConcurrencyStamp",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "EmailConfirmed",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LockoutEnabled",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LockoutEnd",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "NormalizedEmail",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "NormalizedUserName",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PhoneNumberConfirmed",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "SecurityStamp",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "TwoFactorEnabled",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "Users",
                newName: "username");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Users",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "AccessFailedCount",
                table: "Users",
                newName: "roleId");

            migrationBuilder.AlterColumn<Guid>(
                name: "userId",
                table: "UserSecurityQuestions",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "username",
                table: "Users",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "email",
                table: "Users",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "userId",
                table: "Users",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "password",
                table: "Users",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "userId");

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    roleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    roleName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.roleId);
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "roleId", "roleName" },
                values: new object[,]
                {
                    { 1, "Administrator" },
                    { 2, "Manager" },
                    { 3, "Accountant" }
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

            migrationBuilder.CreateIndex(
                name: "IX_Users_roleId",
                table: "Users",
                column: "roleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Roles_roleId",
                table: "Users",
                column: "roleId",
                principalTable: "Roles",
                principalColumn: "roleId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserSecurityQuestions_Users_userId",
                table: "UserSecurityQuestions",
                column: "userId",
                principalTable: "Users",
                principalColumn: "userId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
