using FiscalFrontier.API.Data;
using FiscalFrontier.API.Models.Domain;
using FiscalFrontier.API.Models.DTO;
using FiscalFrontier.API.Services.Implementation;
using FiscalFrontier.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace FiscalFrontier.API.Controllers
{
    public class JournalEntryController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IAccountNumberGenerator accountNumberGenerator;
        public JournalEntryController(ApplicationDbContext dbContext, IAccountNumberGenerator accountNumberGenerator)
        {
            this.dbContext = dbContext;
            this.accountNumberGenerator = accountNumberGenerator;
        }

        [HttpGet]
        [Route("{accountId}")]
        public async Task<IActionResult> GetJournalEntryByJournalId(int accountId)
        {
            var journalEntry = await dbContext.JournalEntries.FindAsync(accountId);

            if (journalEntry == null)
            {
                return NotFound("Account Not Found!");
            }

            else
            {
                var journalEntryDTO = new ShowJournalEntryDTO
                {
                    JournalEntryType = journalEntry.JournalEntryType,
                    JournalEntryDescription = journalEntry.JournalEntryDescription,
                    CreatedBy = journalEntry.CreatedBy,
                    UpdatedBy = journalEntry.UpdatedBy,
                    JournalEntryPostReference = journalEntry.JournalEntryPostReference,
                    JournalEntryStatus = journalEntry.JournalEntryStatus,
                    JournalEntryRejectionReasoning = journalEntry.JournalEntryRejectionReasoning,
                    ChartOfAccountId = journalEntry.ChartOfAccountId,
                };
                return Ok(journalEntryDTO);
            }

        }
        [HttpGet]
        public async Task<IActionResult> GetJournalEntryByStatus(string approvedStatus, int journalEntryId)
        {
            var journalEntry = await dbContext.JournalEntries.FindAsync(journalEntryId);
            approvedStatus = journalEntry.JournalEntryStatus;
            if (journalEntry == null)
            {
                return NotFound("Account Not Found!");
            }
            if (approvedStatus != "approved") //could be something besides null 
            {
                return NotFound("Approved Status is denied");
            }

            else
            {
                var journalEntryDTO = new ShowJournalEntryDTO
                {
                    JournalEntryType = journalEntry.JournalEntryType,
                    JournalEntryDescription = journalEntry.JournalEntryDescription,
                    CreatedBy = journalEntry.CreatedBy,
                    UpdatedBy = journalEntry.UpdatedBy,
                    JournalEntryPostReference = journalEntry.JournalEntryPostReference,
                    JournalEntryStatus = journalEntry.JournalEntryStatus,
                    JournalEntryRejectionReasoning = journalEntry.JournalEntryRejectionReasoning,
                    ChartOfAccountId = journalEntry.ChartOfAccountId,
                };

                return Ok(journalEntryDTO);
            }

        }

        [HttpGet]
        public async Task<IActionResult> GetAllJournalEntry()
        {

            var journalEntry = await dbContext.JournalEntries.ToListAsync();

            var journalEntryDTO = journalEntry.Select(journalEntry => new ShowJournalEntryDTO
            {
                JournalEntryType = journalEntry.JournalEntryType,
                JournalEntryDescription = journalEntry.JournalEntryDescription,
                CreatedBy = journalEntry.CreatedBy,
                UpdatedBy = journalEntry.UpdatedBy,
                JournalEntryPostReference = journalEntry.JournalEntryPostReference,
                JournalEntryStatus = journalEntry.JournalEntryStatus,
                JournalEntryRejectionReasoning = journalEntry.JournalEntryRejectionReasoning,
                ChartOfAccountId = journalEntry.ChartOfAccountId,
            }).ToList();

            return Ok(journalEntryDTO);
        }


        [HttpPost]
        [Route("/create")]
        public async Task<IActionResult> CreateJournalEntry([FromBody] CreateJournalEntryDTO request)
        {



            var journalEntryCreationRequest = new JournalEntry
            {
                JournalEntryType = request.JournalEntryType,
                JournalEntryDescription = request.JournalEntryDescription,
                CreatedBy = request.CreatedBy,
                UpdatedBy = request.UpdatedBy,
                JournalEntryPostReference = request.JournalEntryPostReference,
                JournalEntryStatus = request.JournalEntryStatus,
                JournalEntryRejectionReasoning = request.JournalEntryRejectionReasoning,
                ChartOfAccountId = request.ChartOfAccountId,
                Account = request.Account,
                Debits = request.Debits,
                Credits = request.Credits,
                Files = request.Files,
                JournalEntryCreated = request.JournalEntryCreated,
            };

            await dbContext.JournalEntries.AddAsync(journalEntryCreationRequest);

            await dbContext.SaveChangesAsync();

            return Ok(new { Message = "Created Chart Of Account " + journalEntryCreationRequest.JournalEntryId });

        }

        [HttpPut]
        [Route("modify")]
        public async Task<IActionResult> ModifyJournalEntry([FromBody] UpdateJournalEntryDTO request)
        {
            var journalEntry = await dbContext.JournalEntries.FindAsync(request.JournalEntryId);

            var changes = new List<string>();

            if (journalEntry == null)
            {
                return NotFound($"Journal with ID {request.JournalEntryId} not found.");

            }

            if (request.JournalEntryType != null && !await dbContext.JournalEntries.AnyAsync(a => a.JournalEntryType == request.JournalEntryType))
            {
                changes.Add($"Changed Account Name from \"{journalEntry.JournalEntryType}\" to \"{request.JournalEntryType}\".");
                journalEntry.JournalEntryType = request.JournalEntryType.Trim();

            }

            if (request.JournalEntryDescription != null && (request.JournalEntryDescription != journalEntry.JournalEntryDescription))
            {
                changes.Add($"Changed Account Description from \"{journalEntry.JournalEntryDescription}\" to \"{request.JournalEntryDescription}\".");
                journalEntry.JournalEntryDescription = request.JournalEntryDescription.Trim();
            }

            if (request.JournalEntryPostReference != null && (request.JournalEntryPostReference != journalEntry.JournalEntryPostReference))
            {
                changes.Add($"Changed Account Description from \"{journalEntry.JournalEntryPostReference}\" to \"{request.JournalEntryPostReference}\".");
                journalEntry.JournalEntryPostReference = request.JournalEntryPostReference.Trim();
            }


            /*if (request.accountCredit != null && (request.accountCredit != journalEntry.accountCredit))
            {
                //Variables that are changed
                var accountNumber = journalEntry.accountNumber;
                var accountCategory = journalEntry.accountCategory;
                var normalSide = journalEntry.accountNormalSide;
                var debit = journalEntry.accountDebit;
                var credit = journalEntry.accountCredit;
                var accountBalance = journalEntry.accountBalance;

                //Changes
                journalEntry.accountNumber = await accountNumberGenerator.GenerateAccountNumber(request.accountCategory);
                journalEntry.accountCategory = request.accountCategory;
            }

            if (request.accountStatement != null && request.accountStatement != journalEntry.accountStatement)
            {
                changes.Add($"Changed Account Statement from \"{journalEntry.accountStatement}\" to \"{request.accountStatement}\".");
                journalEntry.accountStatement = request.accountStatement;
            }

            if (request.accountCredit != 0)
            {
                switch (journalEntry.accountNormalSide)
                {
                    case "Debit":
                        journalEntry.accountCredit -= request.accountCredit;
                        break;
                    case "Credit":
                        journalEntry.accountCredit += request.accountCredit;
                        break;
                }
                journalEntry.accountBalance += journalEntry.accountCredit;
                changes.Add($"Added {request.accountCredit} to the Credit of {journalEntry.accountName} resulting in a Credit total of {journalEntry.accountCredit} & a Total Account Balance of {journalEntry.accountBalance}.");
            }

            if (changes.Count > 0)
            {
                var updateHistory = new AccountUpdateHistory
                {
                    accountId = journalEntry.ChartOfAccountId,
                    updateDate = DateTime.UtcNow,
                    changes = string.Join("; ", changes)
                };

                dbContext.AccountUpdatesHistories.Add(updateHistory);
            }

            await dbContext.SaveChangesAsync();
*/
            return Ok(new { Message = "Account has been updated!" });
        }
    }
}
