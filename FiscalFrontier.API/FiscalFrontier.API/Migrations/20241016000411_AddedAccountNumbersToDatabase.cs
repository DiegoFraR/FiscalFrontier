using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FiscalFrontier.API.Migrations
{
    /// <inheritdoc />
    public partial class AddedAccountNumbersToDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccountNumbers",
                columns: table => new
                {
                    accountNumbersId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    accountCategory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    accountNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountNumbers", x => x.accountNumbersId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountNumbers");
        }
    }
}
