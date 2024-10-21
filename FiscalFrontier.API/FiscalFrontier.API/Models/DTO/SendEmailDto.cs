namespace FiscalFrontier.API.Models.DTO
{
    public class SendEmailDto
    {
        public required string Subject { get; set; }
        public required string Message { get; set; }
        public required string Role { get; set; }
    }
}
