using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FiscalFrontier.API.Migrations
{
    /// <inheritdoc />
    public partial class AddedJournalEntries : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "JournalEntries",
                columns: table => new
                {
                    JournalEntryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JournalEntryType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JournalEntryDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JournalEntryPostReference = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JournalEntryStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JournalEntryRejectionReasoning = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JournalEntryCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    JournalEntryUpdated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JournalEntries", x => x.JournalEntryId);
                });

            migrationBuilder.CreateTable(
                name: "Credits",
                columns: table => new
                {
                    CreditId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChartOfAccountId = table.Column<int>(type: "int", nullable: false),
                    CreditAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    JournalEntryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Credits", x => x.CreditId);
                    table.ForeignKey(
                        name: "FK_Credits_ChartOfAccounts_ChartOfAccountId",
                        column: x => x.ChartOfAccountId,
                        principalTable: "ChartOfAccounts",
                        principalColumn: "accountId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Credits_JournalEntries_JournalEntryId",
                        column: x => x.JournalEntryId,
                        principalTable: "JournalEntries",
                        principalColumn: "JournalEntryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Debits",
                columns: table => new
                {
                    DebitId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChartOfAccountId = table.Column<int>(type: "int", nullable: false),
                    DebitAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    JournalEntryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Debits", x => x.DebitId);
                    table.ForeignKey(
                        name: "FK_Debits_ChartOfAccounts_ChartOfAccountId",
                        column: x => x.ChartOfAccountId,
                        principalTable: "ChartOfAccounts",
                        principalColumn: "accountId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Debits_JournalEntries_JournalEntryId",
                        column: x => x.JournalEntryId,
                        principalTable: "JournalEntries",
                        principalColumn: "JournalEntryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FileRecords_JournalEntryId",
                table: "FileRecords",
                column: "JournalEntryId");

            migrationBuilder.CreateIndex(
                name: "IX_Credits_ChartOfAccountId",
                table: "Credits",
                column: "ChartOfAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Credits_JournalEntryId",
                table: "Credits",
                column: "JournalEntryId");

            migrationBuilder.CreateIndex(
                name: "IX_Debits_ChartOfAccountId",
                table: "Debits",
                column: "ChartOfAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Debits_JournalEntryId",
                table: "Debits",
                column: "JournalEntryId");

            migrationBuilder.AddForeignKey(
                name: "FK_FileRecords_JournalEntries_JournalEntryId",
                table: "FileRecords",
                column: "JournalEntryId",
                principalTable: "JournalEntries",
                principalColumn: "JournalEntryId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FileRecords_JournalEntries_JournalEntryId",
                table: "FileRecords");

            migrationBuilder.DropTable(
                name: "Credits");

            migrationBuilder.DropTable(
                name: "Debits");

            migrationBuilder.DropTable(
                name: "JournalEntries");

            migrationBuilder.DropIndex(
                name: "IX_FileRecords_JournalEntryId",
                table: "FileRecords");
        }
    }
}
