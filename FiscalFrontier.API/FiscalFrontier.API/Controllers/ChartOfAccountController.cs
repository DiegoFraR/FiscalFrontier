using FiscalFrontier.API.Data;
using FiscalFrontier.API.Models.Domain;
using FiscalFrontier.API.Models.DTO;
using FiscalFrontier.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FiscalFrontier.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChartOfAccountController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IAccountNumberGenerator accountNumberGenerator;

        public ChartOfAccountController(ApplicationDbContext dbContext, IAccountNumberGenerator accountNumberGenerator)
        {
            this.dbContext = dbContext;
            this.accountNumberGenerator = accountNumberGenerator;
        }

        //Creates a Chart Of Account 
        [HttpPost]
        [Route("/create")]
        //[Authorize(Roles = "Administrator")]
        public async Task<IActionResult> CreateChartOfAccount([FromBody] CreateChartOfAccountDto request)
        {
            
            if(await dbContext.ChartOfAccounts.AnyAsync(a => a.accountName == request.accountName))
            {
                return BadRequest("An account with this name already exists!");
            }

            var normalSide = setNormalSide(request.accountCategory);

            var chartOfAccountCreationRequest = new ChartOfAccount
            {
                accountName = request.accountName,
                accountNumber = await accountNumberGenerator.GenerateAccountNumber(request.accountCategory),
                accountDescription = request.accountDescription,
                accountNormalSide = setNormalSide(request.accountCategory),
                accountCategory = request.accountCategory,
                accountSubcategory = request.accountSubcategory,
                accountInitialBalance = request.accountInitialBalance,
                accountDebit = setDebitValue(request.accountDebit, normalSide),
                accountCredit = setCreditValue(request.accountCredit, normalSide),
                accountBalance = request.accountInitialBalance,
                accountDateTimeAdded = DateTime.Now,
                accountUserId = convertStringIdToGuidId(request.userId),
                accountOrder = request.accountOrder,
                accountStatement = request.accountStatement,
                accountComment = request.accountComment,
                accountActive = true
            };

            await dbContext.ChartOfAccounts.AddAsync(chartOfAccountCreationRequest);

            await dbContext.SaveChangesAsync();

            return Ok(new { Message = "Created Chart Of Account " + chartOfAccountCreationRequest.accountName});

        }

        //Update a Chart of Account
        [HttpPut]
        [Route("modify")]
        //[Authorize(Roles = "Administrator")]
        public async Task<IActionResult> ModifyChartOfAccount( [FromBody] UpdateChartOfAccountDto request)
        {
            var chartOfAccount = await dbContext.ChartOfAccounts.FindAsync(request.accountId);

            var changes = new List<string>();

            if (chartOfAccount == null) 
            {
                return NotFound($"Account with ID {request.accountId} not found.");

            }

            if(request.accountName != null && !await dbContext.ChartOfAccounts.AnyAsync(a => a.accountName == request.accountName))
            {
                changes.Add($"Changed Account Name from \"{chartOfAccount.accountName}\" to \"{request.accountName}\".");
                chartOfAccount.accountName = request.accountName.Trim();
                
            }
            

            if (request.accountDescription != null && (request.accountDescription != chartOfAccount.accountDescription)) 
            {
                changes.Add($"Changed Account Description from \"{chartOfAccount.accountDescription}\" to \"{request.accountDescription}\".");
                chartOfAccount.accountDescription = request.accountDescription.Trim();
            }

            if(request.accountOrder != 0 && (request.accountOrder != chartOfAccount.accountOrder)){

                changes.Add($"Changed Account Order from {chartOfAccount.accountOrder} to {request.accountOrder}.");
                chartOfAccount.accountOrder = request.accountOrder;
            }

            if (request.accountCategory != null && (request.accountCategory != chartOfAccount.accountCategory))
            {
                //Variables that are changed
                var accountNumber = chartOfAccount.accountNumber;
                var accountCategory = chartOfAccount.accountCategory;
                var normalSide = chartOfAccount.accountNormalSide;
                var debit = chartOfAccount.accountDebit;
                var credit = chartOfAccount.accountCredit;
                var accountBalance = chartOfAccount.accountBalance;

                //Changes
                chartOfAccount.accountNumber = await accountNumberGenerator.GenerateAccountNumber(request.accountCategory);
                chartOfAccount.accountCategory = request.accountCategory;
                chartOfAccount.accountNormalSide = setNormalSide(request.accountCategory);
                if(chartOfAccount.accountNormalSide != normalSide)
                {
                    chartOfAccount.accountNormalSide = setNormalSide(request.accountCategory);
                    chartOfAccount.accountCredit = setCreditValue(chartOfAccount.accountCredit ,chartOfAccount.accountNormalSide);
                    chartOfAccount.accountDebit = setDebitValue(chartOfAccount.accountDebit, chartOfAccount.accountNormalSide);
                    chartOfAccount.accountBalance = chartOfAccount.accountDebit + chartOfAccount.accountCredit;

                    //Beginning of Logs
                    changes.Add($"Changed Account Normal Side from \"{normalSide}\" to \"{chartOfAccount.accountNormalSide}\" due to changes in the Account Category.");
                    changes.Add($"Changed Account Credit from {credit} to {chartOfAccount.accountCredit} due to changes in the Account Category.");
                    changes.Add($"Changed Account Debit from {debit} to {chartOfAccount.accountDebit} due to changes in the Account Category.");
                    changes.Add($"Changed Account Balance from {accountBalance} to {chartOfAccount.accountBalance} due to changes in the Account Category.");
                }

                //Logs
                changes.Add($"Changed Account Number from {accountNumber} to {chartOfAccount.accountNumber}.");
                changes.Add($"Changed Account Category from \"{chartOfAccount.accountCategory}\" to \"{request.accountCategory}\".");
            }

            if (request.accountStatement != null && request.accountStatement != chartOfAccount.accountStatement) 
            {
                changes.Add($"Changed Account Statement from \"{chartOfAccount.accountStatement}\" to \"{request.accountStatement}\".");
                chartOfAccount.accountStatement = request.accountStatement;
            }

            if (request.accountDebit != 0)
            {
                switch(chartOfAccount.accountNormalSide)
                {
                    case "Debit":
                        chartOfAccount.accountDebit += request.accountDebit;
                        break;
                    case "Credit": 
                        chartOfAccount.accountDebit -= request.accountDebit;
                        break;
                }

                chartOfAccount.accountBalance += chartOfAccount.accountDebit;
                changes.Add($"Added {request.accountDebit} to the Debit of {chartOfAccount.accountName} resulting in a Debit total of {chartOfAccount.accountDebit} & a Total Account Balance of {chartOfAccount.accountBalance}.");

            }

            if (request.accountCredit != 0)
            {
                switch (chartOfAccount.accountNormalSide)
                {
                    case "Debit":
                        chartOfAccount.accountCredit -= request.accountCredit;
                        break;
                    case "Credit":
                        chartOfAccount.accountCredit += request.accountCredit;
                        break;
                }
                chartOfAccount.accountBalance += chartOfAccount.accountCredit;
                changes.Add($"Added {request.accountCredit} to the Credit of {chartOfAccount.accountName} resulting in a Credit total of {chartOfAccount.accountCredit} & a Total Account Balance of {chartOfAccount.accountBalance}.");
            }

            

            if (changes.Count > 0)
            {
                var updateHistory = new AccountUpdateHistory
                {
                    accountId = chartOfAccount.accountId,
                    updateDate = DateTime.UtcNow,
                    changes = string.Join("; ", changes)
                };

                dbContext.AccountUpdatesHistories.Add(updateHistory);
            }

            await dbContext.SaveChangesAsync();

            return Ok(new { Message = "Account has been updated!" });
        }

        [HttpGet]
        public async Task<IActionResult> GetChartOfAccounts()
        {
            var chartOfAccounts = await dbContext.ChartOfAccounts.ToListAsync();

            var chartOfAccountDtos = chartOfAccounts.Select(account => new ShowAllChartOfAccountsDTO
            {
                accountNumber = account.accountNumber,
                accountDescription = account.accountDescription,
                accountCategory = account.accountCategory,
                accountSubcategory = account.accountSubcategory,
                accountBalance = account.accountBalance,
                accountComment = account.accountComment,
                accountActive = account.accountActive
            }).ToList();

            return Ok(chartOfAccounts);
        }

        [HttpGet]
        [Route("{accountId}")]
        public async Task<IActionResult> GetAccountById(int accountId)
        {
            var chartOfAccount = await dbContext.ChartOfAccounts.FindAsync(accountId);

            if (chartOfAccount == null) 
            {
                return NotFound("Account Not Found!");
            }

            var chartOfAccountDTO = new ShowChartOfAccountDetailedDTO
            {
                accountName = chartOfAccount.accountName,
                accountNumber = chartOfAccount.accountNumber,
                accountDescription = chartOfAccount.accountDescription,
                accountNormalSide = chartOfAccount.accountNormalSide,
                accountCategory = chartOfAccount.accountCategory,
                accountSubcategory = chartOfAccount.accountSubcategory,
                accountInitialBalance = chartOfAccount.accountInitialBalance,
                accountDebit = chartOfAccount.accountDebit,
                accountCredit = chartOfAccount.accountCredit,
                accountBalance = chartOfAccount.accountBalance,
                accountDateTimeAdded = chartOfAccount.accountDateTimeAdded,
                accountUserId = chartOfAccount.accountUserId,
                accountOrder = chartOfAccount.accountOrder,
                accountStatement = chartOfAccount.accountStatement,
                accountComment = chartOfAccount.accountComment,
                accountActive = chartOfAccount.accountActive
            };

            return Ok(chartOfAccountDTO);
        }

        [HttpGet]
        [Route("{accountId}/changes")]
        public async Task<IActionResult> GetAccountChangeHistoryById(int accountId)
        {
            var updates = await dbContext.AccountUpdatesHistories
                .Where(u => u.accountId == accountId)
                .Select(u => new
                {
                    u.accountUpdateHistoryId,
                    u.changes,
                    u.updateDate,
                    AccountDetails = dbContext.ChartOfAccounts
                    .Where(c => c.accountId == accountId)
                    .Select(c => new
                    {
                        c.accountName,
                        c.accountNumber,
                    }).FirstOrDefault()
                })
                .ToListAsync();
            if(updates == null)
            {
                return NotFound($"No Updates have been made to Account {accountId}");
            }

            var updatesDTO = updates.Select(u => new AccountUpdateHistoryDTO
            {
                accountUpdateHistoryId = u.accountUpdateHistoryId,
                changes = u.changes,
                accountName = u.AccountDetails.accountName,
                accountNumber = u.AccountDetails.accountNumber,
                updateDate = u.updateDate
            });

            return Ok(updatesDTO);
        }

        [HttpGet]
        [Route("/AllChanges")]
        public async Task<IActionResult> GetAccountChangeHistories()
        {

            var updates = await dbContext.AccountUpdatesHistories
                .Join(
                    dbContext.ChartOfAccounts,
                    accountUpdate => accountUpdate.accountId,
                    chartOfAccount => chartOfAccount.accountId,
                    (accountUpdate, chartOfAccount) => new
                    {
                        accountUpdate.accountUpdateHistoryId,
                        accountName = chartOfAccount.accountName,
                        accountNumber = chartOfAccount.accountNumber,
                        accountUpdate.changes,
                        accountUpdate.updateDate
                    }
                )
                .ToListAsync();

            var updatesDTO = updates.Select(u => new AccountUpdateHistoryDTO
            {
                accountUpdateHistoryId = u.accountUpdateHistoryId,
                accountName = u.accountName,
                accountNumber = u.accountNumber,
                changes = u.changes,
                updateDate = u.updateDate
            });
            return Ok(updatesDTO);
        }

        [HttpPut]
        [Route("/api/ChartOfAccount/DeActivate/{accountId}")]
        public async Task<IActionResult> DeactivateAccount(int accountId)
        {
            var chartOfAccount = await dbContext.ChartOfAccounts.FindAsync(accountId);

            if (chartOfAccount == null) 
            {
                return NotFound("Account Not Found!");
            }

            if(chartOfAccount.accountBalance == 0)
            {
                chartOfAccount.accountActive = false;
                await dbContext.SaveChangesAsync();
                return Ok(new { message = "Account was DeActivated!" });
            }

            return BadRequest("Account Balance must be 0 to DeActivate an Account!");
        }

        [HttpPut]
        [Route("/api/ChartOfAccount/Activate/{accountId}")]
        public async Task<IActionResult> ActivateAccount(int accountId)
        {
            var chartOfAccount = await dbContext.ChartOfAccounts.FindAsync(accountId);

            if (chartOfAccount == null)
            {
                return NotFound("Account Not Found!");
            }

            chartOfAccount.accountActive = true;
            await dbContext.SaveChangesAsync();
            return Ok(new { message = "Account is Active!" });
        }



        //Helper Methods

        //Sets the Normal Side based on the Account Category
        private string setNormalSide(string accountCategory)
        {
            switch(accountCategory)
            {
                case "Asset":
                    return "Debit";
                case "Liability":
                    return "Credit";
                case "Equity":
                    return "Credit";
                case "Expense":
                    return "Debit";
                case "Revenue":
                    return "Credit";
                default:
                    throw new Exception("Account Category Invalid!");
            }
        }

        private decimal setDebitValue(decimal value, string accountNormalSide)
        {
            switch (accountNormalSide)
            {
                case "Debit": 
                    return Math.Abs(value);
                case "Credit":
                    return value < 0 ? value : -value;
                default:
                    throw new Exception("Invalid Account Normal Side");

            }
        }

        private decimal setCreditValue(decimal value, string accountNormalSide)
        {
            switch (accountNormalSide)
            {
                case "Credit":
                    return Math.Abs(value);
                case "Debit":
                    return value < 0 ? value : -value;
                default:
                    throw new Exception("Invalid Account Normal Side");
            }
        }

        private Guid convertStringIdToGuidId(string userId)
        {
            return Guid.Parse(userId);
        }
    }
}
