namespace FiscalFrontier.API.Services.Interfaces
{
    public interface IAccountNumberGenerator
    {

        int GenerateAccountNumber(string accountCategory);
    }
}
