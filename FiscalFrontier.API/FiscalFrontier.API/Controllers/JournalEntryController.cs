using FiscalFrontier.API.Data;
using FiscalFrontier.API.Models.Domain;
using FiscalFrontier.API.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FiscalFrontier.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JournalEntryController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        private readonly UserManager<User> userManager;

        public JournalEntryController(ApplicationDbContext dbContext, UserManager<User> userManager)
        {
            this.dbContext = dbContext;
            this.userManager = userManager;
        }

        //Create HTTP Calls

        //Creates a Journal Entry
        [HttpPost]
        public async Task<IActionResult> CreateJournalEntry([FromBody] CreateJournalEntryDto request)
        {

            var chartOfAccount = await dbContext.ChartOfAccounts.AnyAsync(c => c.accountId == request.ChartOfAccountId);
            var user = await userManager.FindByIdAsync(request.CreatedBy);
            if (!ModelState.IsValid)
            {
                foreach (var entry in ModelState)
                {
                    foreach (var error in entry.Value.Errors)
                    {
                        ModelState.AddModelError(entry.Key, error.ErrorMessage);
                    }
                }
            }

            if (!chartOfAccount)
            {
                ModelState.AddModelError("ChartOfAccount", "Chart of Account does not exist!");
            }

            if (user == null)
            {
                ModelState.AddModelError("User", "User does not exist!");
            }

            var debitTotal = 0.00m;
            var creditTotal = 0.00m;

            foreach (var creditValue in request.CreditValues)
            {
                creditTotal += creditValue;
            }
            foreach (var debitValue in request.DebitValues)
            {
                debitTotal += debitValue;
            }

            if (creditTotal != debitTotal)
            {
                ModelState.AddModelError("Amount", "Debit and Credit Values must equal eachother!");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var journalEntry = new JournalEntry
            {
                JournalEntryType = request.JournalEntryType,
                JournalEntryDescription = request.JournalEntryDescription,
                CreatedBy = request.CreatedBy,
                UpdatedBy = string.Empty,
                JournalEntryPostReference = request.JournalEntryPostReference,
                ChartOfAccountId = request.ChartOfAccountId,
            };

            await dbContext.JournalEntries.AddAsync(journalEntry);
            await dbContext.SaveChangesAsync();

            foreach (var creditValue in request.CreditValues)
            {
                await CreateCreditEntity(creditValue, journalEntry.JournalEntryId, journalEntry.ChartOfAccountId);
            }

            foreach (var debitValue in request.DebitValues)
            {
                await CreateDebitEntity(debitValue, journalEntry.JournalEntryId, journalEntry.ChartOfAccountId);
            }

            await dbContext.SaveChangesAsync();

            return Ok();
        }
        //Creates Respective Credit Entries
        [HttpPost]
        private async Task<IActionResult> CreateCreditEntity(decimal value, int journalEntryId, int chartOfAccountId)
        {
            var creditEntity = new Credit
            {
                ChartOfAccountId = chartOfAccountId,
                CreditAmount = value,
                JournalEntryId = journalEntryId
            };

            await dbContext.Credits.AddAsync(creditEntity);
            await dbContext.SaveChangesAsync();

            return Ok();
        }
        //Creates Respective Credit Entries
        [HttpPost]
        private async Task<IActionResult> CreateDebitEntity(decimal value, int journalEntryId, int chartOfAccountId)
        {
            var debitEntity = new Debit
            {
                ChartOfAccountId = chartOfAccountId,
                DebitAmount = value,
                JournalEntryId = journalEntryId
            };

            await dbContext.Debits.AddAsync(debitEntity);
            await dbContext.SaveChangesAsync();

            return Ok();
        }

        //Modify Existing Entities (HTTP Put Calls)

        [HttpPut]
        [Route("/approve")]
        public async Task<IActionResult> ApproveJournalEntryRequest(ApproveJournalEntryDto request)
        {
            var journalEntry = await dbContext.JournalEntries.FindAsync(request.journalEntryId);

            if (journalEntry == null)
            {
                ModelState.AddModelError("JournalEntry", "Journal Entry does not exist.");
                return BadRequest(ModelState);
            }

            var chartOfAccount = await dbContext.ChartOfAccounts.FindAsync(journalEntry.ChartOfAccountId);

            if (chartOfAccount == null)
            {
                ModelState.AddModelError("ChartOfAccount", $"A Chart of Account associated with Journal Entry {request.journalEntryId} does not Exist!.");
                return BadRequest(ModelState);
            }

            journalEntry.JournalEntryStatus = "Approved";

            var credits = await dbContext.Credits.
                Where(c => c.JournalEntryId == request.journalEntryId)
                .ToListAsync();

            var debits = await dbContext.Debits.
                Where(d => d.JournalEntryId == request.journalEntryId)
                .ToListAsync();

            foreach (var debit in debits)
            {
                await sumDebitValuestoChartOfAccount(debit.DebitAmount, journalEntry.ChartOfAccountId);
            }

            foreach (var credit in credits)
            {
                await sumCreditValuestoChartOfAccount(credit.CreditAmount, journalEntry.ChartOfAccountId);
            }

            journalEntry.UpdatedBy = request.updatedBy;

            await dbContext.SaveChangesAsync();

            return Ok();
        }

        [HttpPut]
        [Route("/deny")]
        public async Task<IActionResult> DenyJournalEntryRequest(DenyJournalEntryDto request)
        {
            var journalEntry = await dbContext.JournalEntries.FindAsync(request.journalEntryId);

            if (journalEntry == null)
            {
                ModelState.AddModelError("JournalEntry", "Journal Entry does not exist.");
                return BadRequest(ModelState);
            }

            journalEntry.JournalEntryStatus = "Denied";
            journalEntry.JournalEntryRejectionReasoning = request.journalEntryDeniedReason;
            journalEntry.UpdatedBy = request.updatedBy;

            await dbContext.SaveChangesAsync();

            return Ok();
        }


        /*
         * 
         * Need to add a method here to modify journal entries before they are approved
         * 
         * 
         */


        //Get HTTP Calls

        [HttpGet]
        [Route("/pending")]
        public async Task<IActionResult> GetAllJournalEntriesPendingApproval()
        {
            var journalEntries = await dbContext.JournalEntries.
                Where(j => j.JournalEntryStatus == "Pending")
                .Include(j => j.Account)
                .Include(j => j.Debits)
                .Include(j => j.Credits)
                .Include(j => j.Files)
                .ToListAsync();

            if (journalEntries.Count == 0)
            {
                ModelState.AddModelError("NoPendingApproval", "There are no journal entries pending approval!");
                return BadRequest(ModelState);
            }

            return Ok(journalEntries);
        }

        [HttpGet]
        [Route("/account/{journalEntryId}")]
        public async Task<IActionResult> GetJournaEntryById(int journalEntryId)
        {
            var journalEntry = await dbContext.JournalEntries.FindAsync(journalEntryId);

            if (journalEntry == null)
            {
                ModelState.AddModelError("EntryNotFound", "Journal Entry Not Found!");
                return BadRequest(ModelState);
            }

            return Ok(journalEntry);
        }

        [HttpGet]
        [Route("/{accountId}")]
        public async Task<IActionResult> GetJournalEntriesByAccountId(int accountId)
        {
            var journalEntries = await dbContext.JournalEntries
                .Where(j => j.ChartOfAccountId == accountId && j.JournalEntryStatus == "Approved")
                .ToListAsync();

            if (journalEntries.Count == 0)
            {
                ModelState.AddModelError("EntryNotFound", "This account does not contain any approved Journal Entries.");
                return BadRequest(ModelState);
            }

            return Ok(journalEntries);
        }

        //Must get Credit and Debit Values associated with entry. 
        [HttpGet]
        public async Task<IActionResult> GetAllJournalEntriesInSystem()
        {
            var journalEntries = await dbContext.JournalEntries.ToListAsync();

            return Ok(journalEntries);
        }

        //Adds the values of debits from the journal entry to the chartOfAccount Debit Value.
        [HttpPost]
        private async Task<IActionResult> sumDebitValuestoChartOfAccount(decimal debitValue, int chartOfAccountId)
        {
            var chartOfAccount = await dbContext.ChartOfAccounts.FindAsync(chartOfAccountId);

            if (chartOfAccount == null)
            {
                ModelState.AddModelError("ChartOfAccount", "Chart Of Account doesn't exist!");
                return BadRequest(ModelState);
            }

            if (chartOfAccount.accountNormalSide.Equals("Debit"))
            {
                chartOfAccount.accountDebit += debitValue;
            }
            else
            {
                chartOfAccount.accountDebit -= debitValue;
            }

            chartOfAccount.accountBalance = chartOfAccount.accountDebit + chartOfAccount.accountCredit;

            return Ok();
        }

        //Adds the values of credits from the journal entry to the chartOfAccount credit Value.
        [HttpPost]
        private async Task<IActionResult> sumCreditValuestoChartOfAccount(decimal creditValue, int chartOfAccountId)
        {
            var chartOfAccount = await dbContext.ChartOfAccounts.FindAsync(chartOfAccountId);

            if(chartOfAccount == null)
            {
                ModelState.AddModelError("ChartOfAccount", "Chart Of Account doesn't exist!");
                return BadRequest(ModelState);
            }

            if (chartOfAccount.accountNormalSide.Equals("Credit"))
            {
                chartOfAccount.accountCredit += creditValue;
            }
            else
            {
                chartOfAccount.accountCredit -= creditValue;
            }

            chartOfAccount.accountBalance = chartOfAccount.accountDebit + chartOfAccount.accountCredit;

            return Ok();
        }
    }
}
