using FiscalFrontier.API.Models.Domain;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FiscalFrontier.API.Models.DTO
{
    public class ShowUserDetailsDTO
    {
        public string userId { get; set; }
        public string username { get; set; }

        public string email { get; set; }

        public string firstName { get; set; }

        public string lastName { get; set; }

        public string address { get; set; }

        public Boolean isActive { get; set; }
    }
}
