using ExpenseTracker.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTracker.Controllers
{
    public class DashboardController : Controller
    {
        private readonly ExpensetrackerDb _context;

        public DashboardController(ExpensetrackerDb context)
        {
            _context = context;
        }
        public async Task<ActionResult> Index()
        {
            //last 7days transactions
            DateTime StartDate = DateTime.Today.AddDays(-7);
            DateTime EndDate = DateTime.Today;

            List<Transaction> SelectedTransactions = await _context.Transactions
                .Include(t => t.Category)
                .Where(u => u.Date >= StartDate && u.Date <= EndDate)
                .ToListAsync();

            //Total Income
            Decimal TotalIncome = SelectedTransactions
                .Where(t => t.Category != null && t.Category.Type == "Income")
                .Sum(s => s.Amount);

            //Total Expense
            Decimal TotalExpense = SelectedTransactions
                .Where(t => t.Category != null && t.Category.Type == "Expense")
                .Sum(s => s.Amount);

            //Balance
            Decimal Balance = TotalIncome - TotalExpense;

            ViewBag.Balance = Balance.ToString("C0");
            ViewBag.TotalExpense = TotalExpense.ToString("C0");
            ViewBag.TotalIncome = TotalIncome.ToString("C0");

            //Doughnut Chart - Expense by Category

            ViewBag.ExpenseByCategory = SelectedTransactions
                .Where(t => t.Category != null && t.Category.Type == "Expense")
                .GroupBy(g => g.Category!.CategoryId)
                .Select(s => new
                {
                    Category = s.Key,
                    Amount = s.Sum(a => a.Amount),
                    FormattedAmount = s.Sum(a => a.Amount).ToString("C0"),
                    CategoryTitleWithIcon = s.First().Category!.Icon + " " + s.First().Category!.Title
                })
                .OrderByDescending(o => o.Amount)
                .ToList();

            //Spline Chart - Income vs Expense
            //Income
            List<SplineChartData> IncomeSummary = SelectedTransactions
                .Where(i => i.Category != null && i.Category.Type == "Income")
                .GroupBy(d => d.Date)
                .Select(k => new SplineChartData()
                {
                    Day = k.First().Date.ToString("dd-MMM"),
                    Income = k.Sum(s => s.Amount),
                }).ToList();
            //Expense
            List<SplineChartData> ExpenseSummary = SelectedTransactions
                .Where(i => i.Category != null && i.Category.Type == "Expense")
                .GroupBy(d => d.Date)
                .Select(k => new SplineChartData()
                {
                    Day = k.First().Date.ToString("dd-MMM"),
                    Expense = k.Sum(s => s.Amount),
                }).ToList();

            //Combine Income and Expense
            string[] Last30Days = Enumerable.Range(0, 7)
                .Select(d => StartDate.AddDays(d).ToString("dd-MMM"))
                .ToArray();

            ViewBag.SplineChart = from Day in Last30Days
                                  join Income in IncomeSummary on Day equals Income.Day into IncomeGroup
                                  join Expense in ExpenseSummary on Day equals Expense.Day into ExpenseGroup
                                  from Income in IncomeGroup.DefaultIfEmpty()
                                  from Expense in ExpenseGroup.DefaultIfEmpty()
                                  select new SplineChartData()
                                  {
                                      Day = Day,
                                      Income = Income?.Income ?? 0,
                                      Expense = Expense?.Expense ?? 0
                                  };

            //recent transactions
            ViewBag.RecentTransactions = SelectedTransactions
                            .OrderByDescending(o => o.Date)
                            .Take(5)
                            .ToList();

            //TotalEarnings
            List<Transaction> AllTransactions = await _context.Transactions
                .Include(t => t.Category)
                .ToListAsync();

            Decimal TotalEarnings = AllTransactions
                .Where(t => t.Category != null && t.Category.Type == "Income")
                .Sum(s => s.Amount);

            ViewBag.TotalEarnings = TotalEarnings.ToString("C0");

            return View();
        }
    }

    public class SplineChartData
    {
        public required string Day { get; set; }
        public Decimal Income { get; set; }
        public Decimal Expense { get; set; }
    }
}
