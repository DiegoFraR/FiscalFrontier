namespace FiscalFrontier.API.Models.DTO
{
    public class UpdateChartOfAccountDto
    {
        public string? accountName { get; set; }
        public string? accountDescription { get; set; }
        public string? accountCategory { get; set; }
        public string? accountSubcategory { get; set; }
        public string? accountComment { get; set; }
        public Boolean accountActive { get; set; }
    }
}
