using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FiscalFrontier.API.Migrations
{
    /// <inheritdoc />
    public partial class AddedChartOfAccountIdNavPropertyToJournalEntries : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ChartOfAccountId",
                table: "JournalEntries",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_JournalEntries_ChartOfAccountId",
                table: "JournalEntries",
                column: "ChartOfAccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_JournalEntries_ChartOfAccounts_ChartOfAccountId",
                table: "JournalEntries",
                column: "ChartOfAccountId",
                principalTable: "ChartOfAccounts",
                principalColumn: "accountId",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JournalEntries_ChartOfAccounts_ChartOfAccountId",
                table: "JournalEntries");

            migrationBuilder.DropIndex(
                name: "IX_JournalEntries_ChartOfAccountId",
                table: "JournalEntries");

            migrationBuilder.DropColumn(
                name: "ChartOfAccountId",
                table: "JournalEntries");
        }
    }
}
