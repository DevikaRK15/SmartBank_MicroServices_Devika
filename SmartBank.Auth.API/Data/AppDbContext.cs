using Microsoft.EntityFrameworkCore;
using Team1_SmartBank.API.Models;

namespace Team1_SmartBank.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
    }
}
