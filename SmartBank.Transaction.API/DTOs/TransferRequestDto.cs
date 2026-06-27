namespace SmartBankT.Transaction.API.DTOs;

public class TransferRequestDto
{
    public string FromAccountNumber { get; set; } = string.Empty;

    public string ToAccountNumber { get; set; } = string.Empty;

    public decimal Amount { get; set; }
}