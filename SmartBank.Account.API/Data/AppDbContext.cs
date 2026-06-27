using Microsoft.EntityFrameworkCore;
using SmartBank.Account.API.Models;

namespace SmartBank.Account.API.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<SmartBank.Account.API.Models.BankAccount> Accounts { get; set; }
}