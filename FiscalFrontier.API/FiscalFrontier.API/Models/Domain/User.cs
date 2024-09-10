using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FiscalFrontier.API.Models.Domain
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }

        [Required, StringLength(50)]
        public string userName { get; set; }

        [Required, StringLength(255)]
        public string passwordHash { get; set; }

        [Required,StringLength(255)]
        public string email { get; set; }

        public string firstName { get; set; }
        public string lastName { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? PasswordExpirationDate { get; set; }

        [ForeignKey("RoleId")]
        public Role Role { get; set; }
    }
}
