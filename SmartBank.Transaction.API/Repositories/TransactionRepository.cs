using Microsoft.EntityFrameworkCore;
using SmartBankT.Transaction.API.Data;
using SmartBankT.Transaction.API.Models;
using SmartBankT.Transaction.API.Repositories.Interfaces;
using System.Linq;
namespace SmartBankT.Transaction.API.Repositories;

public class TransactionRepository : ITransactionRepository
{
    private readonly AppDbContext _context;

    public TransactionRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<BankTransaction>> GetAllAsync()
    {
        return await _context.Transactions.ToListAsync();
    }

    public async Task<BankTransaction?> GetByIdAsync(int id)
    {
        return await _context.Transactions.FindAsync(id);
    }

    public async Task<BankTransaction> AddAsync(BankTransaction transaction)
    {
        _context.Transactions.Add(transaction);

        await _context.SaveChangesAsync();

        return transaction;
    }

    public async Task<IEnumerable<BankTransaction>> GetMiniStatementAsync(string accountNumber)
{
    return await _context.Transactions
        .Where(t =>
            t.SourceAccountNumber == accountNumber ||
            t.DestinationAccountNumber == accountNumber)
        .OrderByDescending(t => t.TransactionDate)
        .Take(10)
        .ToListAsync();
}
}