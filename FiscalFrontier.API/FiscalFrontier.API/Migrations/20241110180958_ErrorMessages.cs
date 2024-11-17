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
                    /*1*/{ "Your login credentials have not been created or activated. Please contact your system administrator.", "Authentication" },
                    /*2*/{ "You must complete all required fields (first name, last name, address, etc.) before submitting your request.", "User Creation" },
                    /*3*/{ "Password must be at least 8 characters long, start with a letter, and include at least one letter, one number, and one special character.", "User Creation" },
                    /*4*/{ "Your new password cannot be a previously used password.", "Security" },
                    /*5*/{ "Your account has been suspended due to multiple incorrect password attempts.", "Authentication" },
                    /*6*/{ "Your password will expire in 3 days. Please update it to avoid service disruptions", "Authentication" },
                    /*7*/{ "An account with the same name already exists. Please choose a unique name.", "Validation" },
                    /*8*/{ "All monetary values should not have more than two decimals (eg., 100.00).", "Validation" },
                    /*9*/{ "Accounts with a balance greater than 0 cannot be deactivated. Please ensure the account balance is 0 before deactivating." , "Validation" },
                    /*10*/{ "You do not have permission to add, edit, or deactivate accounts. Please contact the administrator.", "Authorization" },
                    /*11*/{ "Unable to send email. Please ensure the email is address is valid and try again.", "Email" },
                    /*12*/{ "You must enter a reason for rejecting the journal entry. Please provide a comment", "Journal Entries" },
                    /*13*/{ "The total debits must equal the total credits. Please correct the amounts and try again.", "Validation" },
                    /*14*/{ "Unable to generate financial statement. Please check the date range and try again.", "Financial Reporting" },
                    /*15*/{ "Unable to attach source document. Please check the file format and size.", "Document Management" },
                    /*16*/{ "Login credentials are incorrect. Please try again.", "Authentication" },
                    /*17*/{ "An account with this name already exists!", "ChartOfAccounts" },
                    /*18*/{ "Account Not Found!", "Chart Of Accounts" },
                    /*19*/{ "User Not Found!", "Authentication" },
                    /*20*/{ "User Security Questions not found. Please contact our support team @ fiscalfrontier4713@gmail.com", "Authentication" },
                    /*21*/{ "No Updates have been made to Account", "Chart Of Accounts" },
                    /*22*/{ "Journal Entry Not Found", "Journal Entry" },
                    /*23*/{ "Account Not Found!", "Chart Of Accounts" },
                    /*24*/{ "Account Balance must be 0 to DeActivate an Account!", "Chart Of Accounts" }
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
