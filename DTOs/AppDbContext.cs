using BankManagementSystem.Model;
using Microsoft.EntityFrameworkCore;

namespace BankManagementSystem.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<BankAccount> bank {  get; set; }
    }
}
