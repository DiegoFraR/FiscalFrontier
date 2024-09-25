namespace FiscalFrontier.API.Models.DTO
{
    public class UpdateUserRequestDTO
    {
        public string username { get; set; }
        public string email { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string address { get; set; }
        public DateTime dateOfBirth { get; set; }
        public int roleId { get; set; }
        public Boolean isActive { get; set; }
    }
}
