using FiscalFrontier.API.Data;
using FiscalFrontier.API.Models.Domain;
using FiscalFrontier.API.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Concurrent;

namespace FiscalFrontier.API.Services.Implementation
{
    public class AccountNumberGenerator : IAccountNumberGenerator
    {
        private readonly ApplicationDbContext dbContext;

        public AccountNumberGenerator(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<int> GenerateAccountNumber(string accountCategory)
        {
            int startingNumber = accountCategory switch
            {
                "Asset" => 10000,
                "Liability" => 20000,
                "Equity" => 30000,
                "Expense" => 40000,
                "Revenue" => 50000,
                _ => throw new ArgumentException("Invalid Category")
            };

            var maxExistingNumber = await dbContext.AccountNumbers
                .Where(a => a.accountCategory == accountCategory)
                .Select(a => (int?)a.accountNumber)
                .MaxAsync();

            int newAccountNumber = (maxExistingNumber ?? startingNumber - 1) + 1;

            var accountNumber = new AccountNumbers
            {
                accountNumber = newAccountNumber,
                accountCategory = accountCategory
            };
            await dbContext.AccountNumbers.AddAsync(accountNumber);
            await dbContext.SaveChangesAsync();

            return newAccountNumber;
        }
    }
}
