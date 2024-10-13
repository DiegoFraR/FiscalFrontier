namespace FiscalFrontier.API.Models.DTO
{
    public class LoginResponseDTO
    {
        public string email { get; set; }
        public string token { get; set; }
        public string username { get; set; }
        public string userId { get; set; }
        public List<string> roles { get; set; }
    }
}
