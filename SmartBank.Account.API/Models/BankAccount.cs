namespace SmartBank.Account.API.Models;

public class BankAccount
{
    public int Id { get; set; }
    public string AccountNumber { get; set; } = string.Empty;
    public string AccountType { get; set; } = string.Empty;
    public decimal Balance { get; set; }
    public string Role { get; set; } = "Customer";
    public int CustomerId { get; set; }
}