using System.ComponentModel.DataAnnotations;

namespace FiscalFrontier.API.Models.Domain
{
    public class Role
    {
        [Key] 
        public int Id { get; set; }

        [Required, StringLength(50)]
        public string roleName { get; set; }
    }
}
