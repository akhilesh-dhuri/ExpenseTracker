using Microsoft.EntityFrameworkCore;

namespace ExpenseTracker.Models
{
    public class ExpensetrackerDb:DbContext
    {
        public ExpensetrackerDb(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Category> Categories { get; set; }


    }
}
