using FiscalFrontier.API.Models.Domain;

namespace FiscalFrontier.API.Services.Interfaces
{
    public interface IErrorMessageService
    {
        Task<List<ErrorMessages>> GetErrorMessages();
        Task<ErrorMessages> GetErrorMessage(int errorMessageId);
    }
}
