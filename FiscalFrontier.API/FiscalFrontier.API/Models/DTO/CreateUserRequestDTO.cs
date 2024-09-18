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

        [Required, StringLength(255)]
        public string address { get; set; }

        [Required]
        public DateTime dateOfBirth { get; set; }

        [Required]
        public int securityQuestion1Id { get; set; }

        [Required, StringLength(255)]
        public required string securityQuestion1Answer { get; set; }

        [Required]
        public int securityQuestion2Id { get; set; }

        [Required, StringLength(255)]
        public required string securityQuestion2Answer { get; set; }

    }
}
