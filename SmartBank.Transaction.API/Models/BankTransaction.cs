namespace SmartBankT.Transaction.API.Models;

public class BankTransaction
{
    public int Id { get; set; }

    public string TransactionType { get; set; } = string.Empty;

    public decimal Amount { get; set; }

    public string? SourceAccountNumber { get; set; }

    public string? DestinationAccountNumber { get; set; }

    public DateTime TransactionDate { get; set; } = DateTime.UtcNow;
}