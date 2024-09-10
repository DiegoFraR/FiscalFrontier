using System.ComponentModel.DataAnnotations;

namespace FiscalFrontier.API.Models.DTO
{
    public class CreateUserRequestDTO
    {
        [Required, StringLength(255)]
        public string email { get; set; }
        
        [Required, StringLength(255)]
        public string firstName { get; set; }

        [Required, StringLength(255)]
        public string lastName { get; set; }

        [Required, StringLength(255)]
        public string password { get; set; }
    }
}
