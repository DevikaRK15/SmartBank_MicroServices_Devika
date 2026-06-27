using SmartBank.Account.API.Models;
using SmartBank.Account.API.Repositories;

namespace SmartBank.Account.API.Services;

public class AccountService : IAccountService
{
    private readonly IAccountRepository _repository;

    public AccountService(IAccountRepository repository)
    {
        _repository = repository;
    }

    public List<BankAccount> GetAllAccounts()
    {
        return _repository.GetAllAccounts();
    }

    public BankAccount? GetAccountById(int id)
    {
        return _repository.GetAccountById(id);
    }

   
    
    public bool DeleteAccount(int id)
    {
        return _repository.DeleteAccount(id);
    }


    public BankAccount CreateAccount(BankAccount account)
    {
        Console.WriteLine($"Incoming Account Number: {account.AccountNumber}");
        Console.WriteLine(
    $"CreateAccount called: {DateTime.Now:HH:mm:ss.fff} | {account.AccountNumber}");
        var existing = _repository
            .GetAllAccounts()
            .FirstOrDefault(a => a.AccountNumber == account.AccountNumber);
        Console.WriteLine($"Existing Found: {existing?.AccountNumber}");
        if (existing != null)
{
    return null;
}

        return _repository.CreateAccount(account);
    }

    public void UpdateAccount(BankAccount account)
    {
        _repository.UpdateAccount(account);
    }

}