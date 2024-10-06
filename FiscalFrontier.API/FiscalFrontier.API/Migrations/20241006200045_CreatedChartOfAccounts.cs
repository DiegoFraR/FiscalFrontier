using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FiscalFrontier.API.Migrations
{
    /// <inheritdoc />
    public partial class CreatedChartOfAccounts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChartOfAccounts",
                columns: table => new
                {
                    accountId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    accountName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    accountNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    accountDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    accountNormalSide = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    accountCategory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    accountSubcategory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    accountInitialBalance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    accountDebit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    accountCredit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    accountBalance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    accountDateTimeAdded = table.Column<DateTime>(type: "datetime2", nullable: false),
                    accountUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    accountOrder = table.Column<int>(type: "int", nullable: false),
                    accountStatement = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    accountComment = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChartOfAccounts", x => x.accountId);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_ChartOfAccounts_accountName",
                table: "ChartOfAccounts",
                column: "accountName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ChartOfAccounts_accountNumber",
                table: "ChartOfAccounts",
                column: "accountNumber",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChartOfAccounts");

            migrationBuilder.DropTable(
                name: "UserCreationRequests");
        }
    }
}
