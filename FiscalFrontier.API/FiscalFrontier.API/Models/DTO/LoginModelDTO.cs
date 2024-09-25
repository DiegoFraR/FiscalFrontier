using System.ComponentModel.DataAnnotations;

namespace FiscalFrontier.API.Models.DTO
{
    public class LoginModelDTO
    {
        [Required]
        public required string username { get; set; }
        [Required]
        public required string password { get; set; }
    }
}
