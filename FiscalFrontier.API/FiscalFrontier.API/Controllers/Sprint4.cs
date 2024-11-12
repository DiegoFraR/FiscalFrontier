using FiscalFrontier.API.Data;
using FiscalFrontier.API.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;

namespace FiscalFrontier.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Sprint4 : ControllerBase
    {
        private ApplicationDbContext dbContext;
        public Sprint4(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet("trial-balance")]
        public async Task<List<TrialBalance>> GetTrialBalance()
        {
            var trialBalance = await dbContext.ChartOfAccounts
                .Select(account => new TrialBalance
                {
                    ChartOfAccountId = account.accountId,
                    ChartOfAccountName = account.accountName,
                    TotalDebits = dbContext.Debits.Where(debit => debit.ChartOfAccountId == account.accountId).Sum(debit => debit.DebitAmount),
                    TotalCredits = dbContext.Credits.Where(credit => credit.ChartOfAccountId == account.accountId).Sum(credit => credit.CreditAmount),
                }).ToListAsync();

            return trialBalance;
        }

        [HttpGet("export/trial-balance/excel")]
        public async Task<IActionResult> ExportTrialBalanceToExcel()
        {
            var trialBalance = await dbContext.ChartOfAccounts
                .Select(account => new TrialBalance
                {
                    ChartOfAccountId = account.accountId,
                    ChartOfAccountName = account.accountName,
                    TotalDebits = dbContext.Debits.Where(debit => debit.ChartOfAccountId == account.accountId).Sum(debit => debit.DebitAmount),
                    TotalCredits = dbContext.Credits.Where(credit => credit.ChartOfAccountId == account.accountId).Sum(credit => credit.CreditAmount),
                }).ToListAsync();

            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("TrialBalance");

                worksheet.Cells[1, 1].Value = "ChartOfAccountId";
                worksheet.Cells[1, 2].Value = "ChartOfAccountName";
                worksheet.Cells[1, 3].Value = "TotalDebits";
                worksheet.Cells[1, 4].Value = "TotalCredits";
                worksheet.Cells[1, 5].Value = "NetBalance";

                var row = 2;

                foreach (var account in trialBalance)
                {
                    worksheet.Cells[row, 1].Value = account.ChartOfAccountId;
                    worksheet.Cells[row, 2].Value = account.ChartOfAccountName;
                    worksheet.Cells[row, 3].Value = account.TotalDebits;
                    worksheet.Cells[row, 4].Value = account.TotalCredits;
                    worksheet.Cells[row, 5].Value = account.NetBalance;
                    row++;
                }

                var fileContent = package.GetAsByteArray();
                var fileContentResult = new FileContentResult(fileContent, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
                {
                    FileDownloadName = "TrialBalance.xlsx"
                };

                return fileContentResult;
            }
        }

        [HttpGet("income-statement")]
        public async Task<ActionResult<IncomeStatementDTO>> GetIncomeStatement()
        {
            var incomeAndExpenseAccounts = await dbContext.ChartOfAccounts
                .Where(a => a.accountCategory == "Revenue" || a.accountCategory == "Expense")
                .ToListAsync();

            decimal totalRevenue = 0;

            foreach (var account in incomeAndExpenseAccounts.Where(a => a.accountCategory == "Revenue"))
            {
                var totalCreditsForRevenue = await dbContext.Credits
                    .Where(c => c.ChartOfAccountId == account.accountId)
                    .SumAsync(c => c.CreditAmount);

                totalRevenue += totalCreditsForRevenue;
            }

            decimal totalExpenses = 0;

            foreach (var account in incomeAndExpenseAccounts.Where(a => a.accountCategory == "Expense"))
            {
                var totalDebitsForExpense = await dbContext.Debits
                    .Where(d => d.ChartOfAccountId == account.accountId)
                    .SumAsync(d => d.DebitAmount);

                totalExpenses += totalDebitsForExpense;
            }

            decimal netIncome = totalRevenue - totalExpenses;

            var incomeStatement = new IncomeStatementDTO
            {
                TotalRevenue = totalRevenue,
                TotalExpenses = totalExpenses,
                NetIncome = netIncome,
            };

            return Ok(incomeStatement);
        }

        [HttpGet("export/income-statement/excel")]
        public async Task<IActionResult> ExportIncomeStatementToExcel()
        {
            var incomeAndExpenseAccounts = await dbContext.ChartOfAccounts
                .Where(a => a.accountCategory == "Revenue" || a.accountCategory == "Expense")
                .ToListAsync();

            decimal totalRevenue = 0;
            decimal totalExpenses = 0;

            foreach (var account in incomeAndExpenseAccounts.Where(a => a.accountCategory == "Revenue"))
            {
                var totalCreditsForRevenue = await dbContext.Credits
                    .Where(c => c.ChartOfAccountId == account.accountId)
                    .SumAsync(c => c.CreditAmount);

                totalRevenue += totalCreditsForRevenue;
            }

            foreach (var account in incomeAndExpenseAccounts.Where(a => a.accountCategory == "Expense"))
            {
                var totalDebitsForExpense = await dbContext.Debits
                    .Where(d => d.ChartOfAccountId == account.accountId)
                    .SumAsync(d => d.DebitAmount);

                totalExpenses += totalDebitsForExpense;
            }

            var incomeStatementDate = new List<dynamic>
            {
                new { Category = "Total Revenue", Amount = totalRevenue },
                new { Category = "Total Expenses", Amount = totalExpenses },
                new { Category = "Net Income", Amount = totalRevenue - totalExpenses }
            };

            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Income Statement");

                worksheet.Cells[1, 1].Value = "Category";
                worksheet.Cells[1, 2].Value = "Amount";

                var row = 2;

                foreach (var item in incomeStatementDate)
                {
                    worksheet.Cells[row, 1].Value = item.Category;
                    worksheet.Cells[row, 2].Value = item.Amount;
                    row++;
                }

                using (var headerRange = worksheet.Cells[1, 1, 1, 2])
                {
                    headerRange.Style.Font.Bold = true;
                    headerRange.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                    headerRange.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightGray);
                    headerRange.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                }

                worksheet.Column(1).AutoFit();
                worksheet.Column(2).AutoFit();

                var fileContent = package.GetAsByteArray();
                var fileContentResult = new FileContentResult(fileContent, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
                {
                    FileDownloadName = "IncomeStatement-" + DateTimeOffset.Now.ToString() + ".xlsx"
                };

                return fileContentResult;
            }
        }

        [HttpGet("balance-sheet")]
        public async Task<ActionResult<BalanceSheetDTO>> GetBalanceSheet()
        {
            var balanceSheetAccounts = await dbContext.ChartOfAccounts
                .Where(a => a.accountCategory == "Asset" || a.accountCategory == "Liability" || a.accountCategory == "Equity")
                .ToListAsync();

            decimal totalAssets = 0;
            decimal totalLiability = 0;
            decimal totalEquity = 0;

            foreach (var account in balanceSheetAccounts.Where(a => a.accountCategory == "Asset"))
            {
                totalAssets += await dbContext.Debits
                    .Where(d => d.ChartOfAccountId == account.accountId)
                    .SumAsync(d => d.DebitAmount);

                totalAssets += await dbContext.Credits
                    .Where(c => c.ChartOfAccountId == account.accountId)
                    .SumAsync(c => c.CreditAmount);
            }

            foreach (var account in balanceSheetAccounts.Where(a => a.accountCategory == "Liability"))
            {
                totalLiability += await dbContext.Debits
                    .Where(d => d.ChartOfAccountId == account.accountId)
                    .SumAsync(d => d.DebitAmount);

                totalLiability += await dbContext.Credits
                    .Where(c => c.ChartOfAccountId == account.accountId)
                    .SumAsync(c => c.CreditAmount);
            }

            foreach (var account in balanceSheetAccounts.Where(a => a.accountCategory == "Equity"))
            {
                totalEquity += await dbContext.Debits
                    .Where(d => d.ChartOfAccountId == account.accountId)
                    .SumAsync(d => d.DebitAmount);

                totalEquity += await dbContext.Credits
                    .Where(c => c.ChartOfAccountId == account.accountId)
                    .SumAsync(c => c.CreditAmount);
            }

            decimal netWorth = totalAssets = totalLiability;

            var balanceSheet = new BalanceSheetDTO
            {
                TotalAssets = totalAssets,
                TotalEquity = totalEquity,
                TotalLiabilities = totalLiability,
                NetWorth = netWorth
            };

            return Ok(balanceSheet);

        }

        [HttpGet("export/balance-sheet/excel")]
        public async Task<IActionResult> ExportBalanceSheetToExcel()
        {
            var balanceSheetAccounts = await dbContext.ChartOfAccounts
                .Where(a => a.accountCategory == "Asset" || a.accountCategory == "Liability" || a.accountCategory == "Equity")
                .ToListAsync();

            decimal totalAssets = 0;
            decimal totalLiability = 0;
            decimal totalEquity = 0;

            foreach (var account in balanceSheetAccounts.Where(a => a.accountCategory == "Asset"))
            {
                totalAssets += await dbContext.Debits
                    .Where(d => d.ChartOfAccountId == account.accountId)
                    .SumAsync(d => d.DebitAmount);

                totalAssets += await dbContext.Credits
                    .Where(c => c.ChartOfAccountId == account.accountId)
                    .SumAsync(c => c.CreditAmount);
            }

            foreach (var account in balanceSheetAccounts.Where(a => a.accountCategory == "Liability"))
            {
                totalLiability += await dbContext.Debits
                    .Where(d => d.ChartOfAccountId == account.accountId)
                    .SumAsync(d => d.DebitAmount);

                totalLiability += await dbContext.Credits
                    .Where(c => c.ChartOfAccountId == account.accountId)
                    .SumAsync(c => c.CreditAmount);
            }

            foreach (var account in balanceSheetAccounts.Where(a => a.accountCategory == "Equity"))
            {
                totalEquity += await dbContext.Debits
                    .Where(d => d.ChartOfAccountId == account.accountId)
                    .SumAsync(d => d.DebitAmount);

                totalEquity += await dbContext.Credits
                    .Where(c => c.ChartOfAccountId == account.accountId)
                    .SumAsync(c => c.CreditAmount);
            }

            var balanceSheetDate = new List<dynamic>
            {
                new { Category = "Total Assets", Amount = totalAssets },
                new { Category = "Total Liabilities", Amount = totalLiability },
                new { Category = "Total Equity", Amount = totalEquity },
                new { Category = "Overall Net Worth", Amount = totalAssets - totalLiability }
            };

            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Balance Sheet");

                worksheet.Cells[1, 1].Value = "Category";
                worksheet.Cells[1, 2].Value = "Amount";

                var row = 2;

                foreach (var item in balanceSheetDate)
                {
                    worksheet.Cells[row, 1].Value = item.Category;
                    worksheet.Cells[row, 2].Value = item.Amount;
                    row++;
                }

                using (var headerRange = worksheet.Cells[1, 1, 1, 2])
                {
                    headerRange.Style.Font.Bold = true;
                    headerRange.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                    headerRange.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightGray);
                    headerRange.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                }

                worksheet.Column(1).AutoFit();
                worksheet.Column(2).AutoFit();

                var fileContent = package.GetAsByteArray();
                var fileContentResult = new FileContentResult(fileContent, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
                {
                    FileDownloadName = "BalanceSheet" + DateTimeOffset.Now.ToString() + ".xlsx"
                };

                return fileContentResult;
            }
        }

        [HttpGet("retained-earnings")]
        public async Task<ActionResult<RetainedEarningsDTO>> GetRetainedEarningsStatement()
        {
            var revenueAccounts = await dbContext.ChartOfAccounts
                .Where(a => a.accountCategory == "Revenue")
                .ToListAsync();

            decimal totalRevenue = 0;

            foreach (var account in revenueAccounts)
            {
                totalRevenue += await dbContext.Credits
                    .Where(c => c.ChartOfAccountId == account.accountId)
                    .SumAsync(c => c.CreditAmount);
            }

            var expenseAccounts = await dbContext.ChartOfAccounts
                .Where(a => a.accountCategory == "Expense")
                .ToListAsync();

            decimal totalExpense = 0;
            foreach (var account in expenseAccounts)
            {
                totalExpense += await dbContext.Debits
                    .Where(d => d.ChartOfAccountId == account.accountId)
                    .SumAsync(d => d.DebitAmount);
            }

            decimal netIncome = totalRevenue = totalExpense;

            var beginningRetainedEarnings = await dbContext.ChartOfAccounts
                .Where(a => a.accountCategory == "Equity")
                .SumAsync(a => a.accountInitialBalance);

            decimal endingRetainedEarnings = beginningRetainedEarnings + netIncome;

            var retainedEarnings = new RetainedEarningsDTO
            {
                BeginningRetainedEarnings = beginningRetainedEarnings,
                NetIncome = netIncome,
                EndingRetainedEarnings = endingRetainedEarnings
            };

            return Ok(retainedEarnings);
        }

        [HttpGet("export/retained-earnings/excel")]
        public async Task<IActionResult> ExportRetainedEarningsStatementToExcel()
        {
            var revenueAccounts = await dbContext.ChartOfAccounts
                .Where(a => a.accountCategory == "Revenue")
                .ToListAsync();

            decimal totalRevenue = 0;

            foreach (var account in revenueAccounts)
            {
                totalRevenue += await dbContext.Credits
                    .Where(c => c.ChartOfAccountId == account.accountId)
                    .SumAsync(c => c.CreditAmount);
            }

            var expenseAccounts = await dbContext.ChartOfAccounts
                .Where(a => a.accountCategory == "Expense")
                .ToListAsync();

            decimal totalExpense = 0;
            foreach (var account in expenseAccounts)
            {
                totalExpense += await dbContext.Debits
                    .Where(d => d.ChartOfAccountId == account.accountId)
                    .SumAsync(d => d.DebitAmount);
            }

            decimal netIncome = totalRevenue = totalExpense;

            var beginningRetainedEarnings = await dbContext.ChartOfAccounts
                .Where(a => a.accountCategory == "Equity")
                .SumAsync(a => a.accountInitialBalance);

            decimal endingRetainedEarnings = beginningRetainedEarnings + netIncome;

            var retainedEarnings = new RetainedEarningsDTO
            {
                BeginningRetainedEarnings = beginningRetainedEarnings,
                NetIncome = netIncome,
                EndingRetainedEarnings = endingRetainedEarnings
            };

            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Retained Earnings Statement");

                worksheet.Cells[1, 1].Value = "Beginning Retained Earnings";
                worksheet.Cells[1, 2].Value = "Net Income";
                worksheet.Cells[1, 3].Value = "Ending Retained Earnings";

                worksheet.Cells[2, 1].Value = retainedEarnings.BeginningRetainedEarnings;
                worksheet.Cells[2, 2].Value = retainedEarnings.NetIncome;
                worksheet.Cells[2, 3].Value = retainedEarnings.EndingRetainedEarnings;

                worksheet.Column(1).AutoFit();
                worksheet.Column(2).AutoFit();
                worksheet.Column(3).AutoFit();

                var fileContent = package.GetAsByteArray();

                var fileContentResult = new FileContentResult(fileContent, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
                {
                    FileDownloadName = "RetainedEarnings" + DateTimeOffset.Now.ToString() + ".xlsx"
                };

                return fileContentResult;
            }
        }
    }
}
