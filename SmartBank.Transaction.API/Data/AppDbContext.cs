using Microsoft.EntityFrameworkCore;
using SmartBankT.Transaction.API.Models;

namespace SmartBankT.Transaction.API.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<BankTransaction> Transactions { get; set; }
}