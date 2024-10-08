using System.ComponentModel.DataAnnotations;

namespace FiscalFrontier.API.Validations
{
    public class TwoDecimalPlacesValidation : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is decimal decimalValue)
            {
                if (decimalValue != Math.Round(decimalValue, 2))
                {
                    return new ValidationResult("Monetary values must have two decimal places. Enter 00 if no decimals are present.");
                }
            }

            return ValidationResult.Success;
        }
    }
}
