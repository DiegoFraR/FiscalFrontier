using System.ComponentModel.DataAnnotations;

namespace FiscalFrontier.API.Models.Domain
{
    public class UserCreationRequest
    {
        [Key]
        public int userCreationRequestId { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public string firstName {  get; set; }
        public string lastName { get; set; }
        public string address { get; set; }
        public DateTime dateOfBirth { get; set; }
        public Boolean isApproved { get; set; }
        public int securityQuestion1Id { get; set; }
        public string securityQuestion1Answer { get; set; }
        public int securityQuestion2Id { get; set; }
        public string securityQuestion2Answer { get; set; }
    }
}
