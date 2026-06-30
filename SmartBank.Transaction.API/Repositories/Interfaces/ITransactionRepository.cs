using SmartBankT.Transaction.API.Models;

namespace SmartBankT.Transaction.API.Repositories.Interfaces;

public interface ITransactionRepository
{
    Task<IEnumerable<BankTransaction>> GetAllAsync();

    Task<BankTransaction?> GetByIdAsync(int id);

    Task<BankTransaction> AddAsync(BankTransaction transaction);

    Task<IEnumerable<BankTransaction>> GetMiniStatementAsync(string accountNumber);
}