using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FiscalFrontier.API.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedUserClassAddedSecurityQuestions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Roles_RoleId",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "Users",
                newName: "username");

            migrationBuilder.RenameColumn(
                name: "RoleId",
                table: "Users",
                newName: "roleId");

            migrationBuilder.RenameColumn(
                name: "PasswordExpirationDate",
                table: "Users",
                newName: "passwordExpirationDate");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Users",
                newName: "password");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Users",
                newName: "lastName");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Users",
                newName: "firstName");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Users",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "Users",
                newName: "createdDate");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Users",
                newName: "userId");

            migrationBuilder.RenameIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                newName: "IX_Users_roleId");

            migrationBuilder.RenameColumn(
                name: "RoleName",
                table: "Roles",
                newName: "roleName");

            migrationBuilder.RenameColumn(
                name: "RoleId",
                table: "Roles",
                newName: "roleId");

            migrationBuilder.AddColumn<string>(
                name: "address",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "dateOfBirth",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

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
                name: "UserSecurityQuestions",
                columns: table => new
                {
                    userSecurityQuestionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    securityQuestionId = table.Column<int>(type: "int", nullable: false),
                    answer = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSecurityQuestions", x => x.userSecurityQuestionId);
                    table.ForeignKey(
                        name: "FK_UserSecurityQuestions_SecurityQuestions_securityQuestionId",
                        column: x => x.securityQuestionId,
                        principalTable: "SecurityQuestions",
                        principalColumn: "securityQuestionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserSecurityQuestions_Users_userId",
                        column: x => x.userId,
                        principalTable: "Users",
                        principalColumn: "userId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "SecurityQuestions",
                columns: new[] { "securityQuestionId", "securityQuestion" },
                values: new object[,]
                {
                    { 1, "What was the first exam you failed?" },
                    { 2, "What was your Mother/Father's first car brand?" },
                    { 3, "What was the name of your siblings favorite stuffed animal?" },
                    { 4, "In what city was your Grandmother or Grandfather born?" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserSecurityQuestions_securityQuestionId",
                table: "UserSecurityQuestions",
                column: "securityQuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSecurityQuestions_userId",
                table: "UserSecurityQuestions",
                column: "userId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Roles_roleId",
                table: "Users",
                column: "roleId",
                principalTable: "Roles",
                principalColumn: "roleId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Roles_roleId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "UserSecurityQuestions");

            migrationBuilder.DropTable(
                name: "SecurityQuestions");

            migrationBuilder.DropColumn(
                name: "address",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "dateOfBirth",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "username",
                table: "Users",
                newName: "UserName");

            migrationBuilder.RenameColumn(
                name: "roleId",
                table: "Users",
                newName: "RoleId");

            migrationBuilder.RenameColumn(
                name: "passwordExpirationDate",
                table: "Users",
                newName: "PasswordExpirationDate");

            migrationBuilder.RenameColumn(
                name: "password",
                table: "Users",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "lastName",
                table: "Users",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "firstName",
                table: "Users",
                newName: "FirstName");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "Users",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "createdDate",
                table: "Users",
                newName: "CreatedDate");

            migrationBuilder.RenameColumn(
                name: "userId",
                table: "Users",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Users_roleId",
                table: "Users",
                newName: "IX_Users_RoleId");

            migrationBuilder.RenameColumn(
                name: "roleName",
                table: "Roles",
                newName: "RoleName");

            migrationBuilder.RenameColumn(
                name: "roleId",
                table: "Roles",
                newName: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Roles_RoleId",
                table: "Users",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "RoleId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
