namespace FiscalFrontier.API.Services.Interfaces
{
    public interface IAccountNumberGenerator
    {

        Task<int> GenerateAccountNumber(string accountCategory);
    }
}
