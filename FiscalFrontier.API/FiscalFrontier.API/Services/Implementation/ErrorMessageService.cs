using FiscalFrontier.API.Data;
using FiscalFrontier.API.Models.Domain;
using FiscalFrontier.API.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FiscalFrontier.API.Services.Implementation
{
    public class ErrorMessageService : IErrorMessageService
    {
        private readonly ApplicationDbContext dbContext;

        public ErrorMessageService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<ErrorMessages> GetErrorMessage(int errorMessageId)
        {
            var errorMessage = await dbContext.ErrorMessages.FirstOrDefaultAsync(em => em.ErrorMessageId == errorMessageId);

            if (errorMessage == null)
            {
                throw new InvalidOperationException($"Error message with ID {errorMessageId} not found.");
            }

            return errorMessage;
        }

        public async Task<List<ErrorMessages>> GetErrorMessages()
        {
            return await dbContext.ErrorMessages.ToListAsync();
        }

    }
}
