using SmartBank.Account.API.Models;

namespace SmartBank.Account.API.Services;

public interface IAccountService
{
    List<BankAccount> GetAllAccounts();

    BankAccount? GetAccountById(int id);

    BankAccount CreateAccount(BankAccount account);

    bool DeleteAccount(int id);

    void UpdateAccount(BankAccount account);
}