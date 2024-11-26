namespace FiscalFrontier.API.Models.DTO
{
    public class ResetPasswordDTO
    {
        public required string UserEmail { get; set; }
        public required string NewPassword { get; set; }
    }
}
