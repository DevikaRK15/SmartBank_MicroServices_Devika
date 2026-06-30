namespace SmartBankT.Transaction.API.DTOs;

public class MiniStatementDto
{
    public int Id { get; set; }

    public string TransactionType { get; set; } = string.Empty;

    public decimal Amount { get; set; }

    public DateTime TransactionDate { get; set; }
}