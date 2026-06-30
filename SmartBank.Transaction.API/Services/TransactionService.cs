using SmartBankT.Transaction.API.DTOs;
using SmartBankT.Transaction.API.Models;
using SmartBankT.Transaction.API.Repositories.Interfaces;
using SmartBankT.Transaction.API.Services.Interfaces;

namespace SmartBankT.Transaction.API.Services;

public class TransactionService : ITransactionService
{
    private readonly ITransactionRepository _repository;

    public TransactionService(ITransactionRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<TransactionResponseDto>> GetAllAsync()
    {
        var transactions = await _repository.GetAllAsync();

        return transactions.Select(Map);
    }

    public async Task<TransactionResponseDto?> GetByIdAsync(int id)
    {
        var transaction = await _repository.GetByIdAsync(id);

        if (transaction == null)
            return null;

        return Map(transaction);
    }

    public async Task<TransactionResponseDto> DepositAsync(DepositRequestDto request)
    {
        var transaction = new BankTransaction
        {
            TransactionType = "Deposit",
            Amount = request.Amount,
            DestinationAccountNumber = request.AccountNumber
        };

        var result = await _repository.AddAsync(transaction);

        return Map(result);
    }

    public async Task<TransactionResponseDto> WithdrawAsync(WithdrawRequestDto request)
    {
        var transaction = new BankTransaction
        {
            TransactionType = "Withdraw",
            Amount = request.Amount,
            SourceAccountNumber = request.AccountNumber
        };

        var result = await _repository.AddAsync(transaction);

        return Map(result);
    }

    public async Task<TransactionResponseDto> TransferAsync(TransferRequestDto request)
    {
        var transaction = new BankTransaction
        {
            TransactionType = "Transfer",
            Amount = request.Amount,
            SourceAccountNumber = request.FromAccountNumber,
            DestinationAccountNumber = request.ToAccountNumber
        };

        var result = await _repository.AddAsync(transaction);

        return Map(result);
    }

    private static TransactionResponseDto Map(BankTransaction transaction)
    {
        return new TransactionResponseDto
        {
            Id = transaction.Id,
            TransactionType = transaction.TransactionType,
            Amount = transaction.Amount,
            SourceAccountNumber = transaction.SourceAccountNumber,
            DestinationAccountNumber = transaction.DestinationAccountNumber,
            TransactionDate = transaction.TransactionDate
        };

        
    }
    public async Task<IEnumerable<MiniStatementDto>> GetMiniStatementAsync(string accountNumber)
{
    var transactions =
        await _repository.GetMiniStatementAsync(accountNumber);

    return transactions.Select(t => new MiniStatementDto
    {
        Id = t.Id,
        TransactionType = t.TransactionType,
        Amount = t.Amount,
        TransactionDate = t.TransactionDate
    });
}
}