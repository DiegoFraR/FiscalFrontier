namespace FiscalFrontier.API.Models.DTO
{
    public class LoginResponseDTO
    {
        public string username { get; set; }
        public string token { get; set; }
        public List<string> roles { get; set; }
    }
}
