using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FiscalFrontier.API.Migrations
{
    /// <inheritdoc />
    public partial class ErrorMessages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ErrorMessages",
                columns: table => new
                {
                    ErrorMessageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ErrorMessage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ErrorMessageCategory = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ErrorMessages", x => x.ErrorMessageId);
                });

            migrationBuilder.InsertData(
                table: "ErrorMessages",
                columns: new[] { "ErrorMessage", "ErrorMessageCategory" },
                values: new object[,]
                {
                    { "Your login credentials have not been created or activated. Please contact your system administrator.", "Authentication" },
                    { "You must complete all required fields (first name, last name, address, etc.) before submitting your request.", "User Creation" },
                    { "Password must be at least 8 characters long, start with a letter, and include at least one letter, one number, and one special character.", "User Creation" },
                    { "Your new password cannot be a previously used password.", "Security" },
                    { "Your account has been suspended due to multiple incorrect password attempts.", "Authentication" },
                    { "Your password will expire in 3 days. Please update it to avoid service disruptions", "Authentication" },
                    { "An account with the same name already exists. Please choose a unique name.", "Validation" },
                    { "All monetary values should not have more than two decimals (eg., 100.00).", "Validation" },
                    { "Accounts with a balance greater than 0 cannot be deactivated. Please ensure the account balance is 0 before deactivating." , "Validation" },
                    { "You do not have permission to add, edit, or deactivate accounts. Please contact the administrator.", "Authorization" },
                    { "Unable to send email. Please ensure the email is address is valid and try again.", "Email" },
                    { "You must enter a reason for rejecting the journal entry. Please provide a comment", "Journal Entries" },
                    { "The total debits must equal the total credits. Please correct the amounts and try again.", "Validation" },
                    { "Unable to generate financial statement. Please check the date range and try again.", "Financial Reporting" },
                    { "Unable to attach source document. Please check the file format and size.", "Document Management" },
                }
                );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ErrorMessages");
        }
    }
}
