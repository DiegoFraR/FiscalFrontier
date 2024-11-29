using FiscalFrontier.API.Data;
using FiscalFrontier.API.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FiscalFrontier.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Sprint5 : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public Sprint5(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        [Route("CurrentRatio")]
        public async Task<IActionResult> GetCurrentRatio()
        {
            var assetAccounts = await dbContext.ChartOfAccounts
                .Where(a => a.accountCategory == "Asset")
                .ToListAsync();

            var liabilityAccounts = await dbContext.ChartOfAccounts
                .Where(a => a.accountCategory == "Liability")
                .ToListAsync();

            decimal totalAssetAmount = 0;

            decimal totalLiabilityAmount = 0;

            foreach (var account in assetAccounts)
            {
                totalAssetAmount += account.accountBalance;
            }

            foreach (var account in liabilityAccounts)
            {
                totalLiabilityAmount += account.accountBalance;
            }

            try
            {
                var currentRatio = new CurrentRatioDTO
                {
                    CurrentRatio = Math.Round(totalAssetAmount / totalLiabilityAmount, 2) * 100
                };

                return Ok(currentRatio);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("ReturnOnAssets")]
        public async Task<IActionResult> GetReturnOnAssets()
        {
            var revenueAccounts = await dbContext.ChartOfAccounts
                .Where(a => a.accountCategory == "Revenue")
                .ToListAsync();

            var expenseAccounts = await dbContext.ChartOfAccounts
                .Where(a => a.accountCategory == "Expense")
                .ToListAsync();

            var assetAccounts = await dbContext.ChartOfAccounts
                .Where(a => a.accountCategory == "Asset")
                .ToListAsync();

            decimal totalRevenue = 0;
            decimal totalExpense = 0;
            decimal totalAssets = 0;

            foreach (var account in revenueAccounts)
            {
                totalRevenue += account.accountBalance;
            }

            foreach (var account in expenseAccounts)
            {
                totalExpense += account.accountBalance;
            }

            foreach (var account in assetAccounts)
            {
                totalAssets += account.accountBalance;
            }

            decimal netIncome = totalRevenue - totalExpense;

            try
            {
                var ROA = new ReturnOnAssetsDTO
                {
                    ReturnOnAssets = Math.Round(netIncome / totalAssets, 2) * 100
                };

                return Ok(ROA);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("ReturnOnEquity")]
        public async Task<IActionResult> GetReturnOnEquity()
        {
            var assetAccounts = await dbContext.ChartOfAccounts
                .Where(a => a.accountCategory == "Asset")
                .ToListAsync();

            var liabilityAccounts = await dbContext.ChartOfAccounts
                .Where(a => a.accountCategory == "Liability")
                .ToListAsync();

            var revenueAccounts = await dbContext.ChartOfAccounts
                .Where(a => a.accountCategory == "Revenue")
                .ToListAsync();

            var expenseAccounts = await dbContext.ChartOfAccounts
                .Where(a => a.accountCategory == "Expense")
                .ToListAsync();

            decimal totalAssets = 0;
            decimal totalLiabilities = 0;
            decimal totalRevenue = 0;
            decimal totalExpenses = 0;

            foreach (var account in assetAccounts)
            {
                totalAssets += account.accountBalance;
            }

            foreach (var account in liabilityAccounts)
            {
                totalLiabilities += account.accountBalance;
            }

            foreach (var account in revenueAccounts)
            {
                totalRevenue += account.accountBalance;
            }

            foreach (var account in expenseAccounts)
            {
                totalExpenses += account.accountBalance;
            }

            decimal netIncome = totalRevenue - totalExpenses;

            decimal shareHolderEquity = totalAssets - totalLiabilities;

            try
            {
                var ROE = new ReturnOnEquityDTO
                {
                    ReturnOnEquity = Math.Round(netIncome / shareHolderEquity, 2) * 100
                };

                return Ok(ROE);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("NetProfit")]
        public async Task<IActionResult> GetNetProfit()
        {
            var revenueAccounts = await dbContext.ChartOfAccounts
                .Where(a => a.accountCategory == "Revenue")
                .ToListAsync();

            var expenseAccounts = await dbContext.ChartOfAccounts
                .Where(a => a.accountCategory == "Expense")
                .ToListAsync();

            decimal totalRevenue = 0;
            decimal totalExpenses = 0;

            foreach (var account in revenueAccounts)
            {
                totalRevenue += account.accountBalance;
            }

            foreach (var account in expenseAccounts)
            {
                totalExpenses += account.accountBalance;
            }

            decimal netIncome = totalRevenue - totalExpenses;

            try
            {
                var NP = new NetProfitDTO
                {
                    NetProfit = Math.Round(netIncome / totalRevenue, 2) * 100
                };

                return Ok(NP);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        [Route("AssetTurnover")]
        public async Task<IActionResult> GetAssetTurnover()
        {
            var revenueAccounts = await dbContext.ChartOfAccounts
                 .Where(a => a.accountCategory == "Revenue")
                 .ToListAsync();

            var assetAccounts = await dbContext.ChartOfAccounts
                .Where(a => a.accountCategory == "Asset")
                .ToListAsync();

            decimal totalRevenue = 0;
            decimal averageAssetAmount = 0;

            foreach (var account in revenueAccounts)
            {
                totalRevenue += account.accountBalance;
            }

            foreach (var account in assetAccounts)
            {
                averageAssetAmount += account.accountBalance;
            }

            averageAssetAmount = averageAssetAmount / assetAccounts.Count;

            try
            {
                var AT = new AssetTurnoverDTO
                {
                    AssetTurnover = Math.Round(totalRevenue / averageAssetAmount, 2) * 100
                };

                return Ok(AT);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        [Route("QuickRatio")]
        public async Task<IActionResult> GetQuickRatio()
        {
            var assetAccounts = await dbContext.ChartOfAccounts
                .Where(a => a.accountCategory == "Asset")
                .ToListAsync();

            var liabilityAccounts = await dbContext.ChartOfAccounts
                .Where(a => a.accountCategory == "Liability")
                .ToListAsync();

            decimal totalAssetAmount = 0;

            decimal totalLiabilityAmount = 0;

            foreach (var account in assetAccounts)
            {
                totalAssetAmount += account.accountBalance;
            }

            foreach (var account in liabilityAccounts)
            {
                totalLiabilityAmount += account.accountBalance;
            }

            try
            {
                var currentRatio = new QuickRatioDTO
                {
                    QuickRatio = Math.Round(totalAssetAmount / totalLiabilityAmount, 2) * 100
                };

                return Ok(currentRatio);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
