using FiscalFrontier.API.Services.Interfaces;
using System.Collections.Concurrent;

namespace FiscalFrontier.API.Services.Implementation
{
    public class AccountNumberGenerator : IAccountNumberGenerator
    {
        private readonly ConcurrentDictionary<string, int> lastUsedNumbers = new()
        {
            ["Asset"] = 10000,
            ["Liability"] = 20000,
            ["Equity"] = 30000,
            ["Expenses"] = 40000,
            ["Revenue"] = 50000
        };

        public int GenerateAccountNumber(string accountCategory)
        {
            if (!lastUsedNumbers.ContainsKey(accountCategory)) 
            {
                throw new ArgumentException("Invalid Account Category");
            }

            lastUsedNumbers[accountCategory]++;

            return lastUsedNumbers[accountCategory];
        }
    }
}
