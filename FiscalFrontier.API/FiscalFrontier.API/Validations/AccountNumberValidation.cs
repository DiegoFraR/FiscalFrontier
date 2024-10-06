using FiscalFrontier.API.Models.Domain;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace FiscalFrontier.API.Validations
{
    public class AccountNumberValidation : ValidationAttribute
    {
        private const string pattern = @"^\d+$";
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var accountNumber = value as string;

            if (string.IsNullOrWhiteSpace(accountNumber) || accountNumber.Length == 0) 
            {
                return new ValidationResult("Account number is required");
            }

            if(!Regex.IsMatch(accountNumber, pattern))
            {
                return new ValidationResult("Account number must contain only digits and cannot have decimal points.");
            }

            var account = (ChartOfAccount)validationContext.ObjectInstance;

            char startingDigit = accountNumber[0];

            switch(account.accountCategory)
            {
                case "Asset":
                    if (startingDigit != '1')
                        return new ValidationResult("Asset account numbers must start with a '1'!");
                    break;
                case "Liability":
                    if (startingDigit != '2')
                        return new ValidationResult("Liability account numbers must start with a '2'!");
                    break;
                case "Equity": 
                    if(startingDigit != '3')
                        return new ValidationResult("Equity account numbers must start with a '3'!");
                    break;
                case "Expense":
                    if (startingDigit != '4')
                        return new ValidationResult("Expense account numbers must start with a '4'!");
                    break;
                case "Revenue":
                    if (startingDigit != '5')
                        return new ValidationResult("Revenue account numbers must start with a '5'!");
                    break;
                default:
                    return new ValidationResult("Invalid account category!");
            }
            
            return ValidationResult.Success;
        }
    }
}
