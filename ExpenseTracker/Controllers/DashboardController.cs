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
            DateTime StartDate = DateTime.Today.AddDays(-6);
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
                    FormattedAmount = s.Sum(a => a.Amount).ToString("C0")
                })
                .ToList();

            return View();
        }
    }
}
