using SmartBankT.Transaction.API.DTOs;

namespace SmartBankT.Transaction.API.Services.Interfaces;

public interface ITransactionService
{
    Task<IEnumerable<TransactionResponseDto>> GetAllAsync();

    Task<TransactionResponseDto?> GetByIdAsync(int id);

    Task<TransactionResponseDto> DepositAsync(DepositRequestDto request);

    Task<TransactionResponseDto> WithdrawAsync(WithdrawRequestDto request);

    Task<TransactionResponseDto> TransferAsync(TransferRequestDto request);

    Task<IEnumerable<MiniStatementDto>> GetMiniStatementAsync(string accountNumber);
}