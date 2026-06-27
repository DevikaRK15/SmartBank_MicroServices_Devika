using SmartBank.Account.API.Data;
using SmartBank.Account.API.Models;

namespace SmartBank.Account.API.Repositories;

public class AccountRepository : IAccountRepository
{
    private readonly AppDbContext _context;

    public AccountRepository(AppDbContext context)
    {
        _context = context;
    }

    public List<BankAccount> GetAllAccounts()
    {
        return _context.Accounts.ToList();
    }

    public BankAccount? GetAccountById(int id)
    {
        return _context.Accounts.Find(id);
    }

    public BankAccount CreateAccount(BankAccount account)
    {
        _context.Accounts.Add(account);
        _context.SaveChanges();

        return account;
    }

    public bool DeleteAccount(int id)
    {
        var account = _context.Accounts.Find(id);

        if (account == null)
            return false;

        _context.Accounts.Remove(account);
        _context.SaveChanges();

        return true;
    }


    public void UpdateAccount(BankAccount account)
    {
        _context.Accounts.Update(account);
        _context.SaveChanges();
    }
}