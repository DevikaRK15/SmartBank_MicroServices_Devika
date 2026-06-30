using Microsoft.AspNetCore.Mvc;
using SmartBankT.Transaction.API.DTOs;
using SmartBankT.Transaction.API.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
namespace SmartBankT.Transaction.API.Controllers;

// [Authorize]
[ApiController]
[Route("api/[controller]")]
public class TransactionController : ControllerBase
{
    private readonly ITransactionService _transactionService;

    public TransactionController(ITransactionService transactionService)
    {
        _transactionService = transactionService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllTransactions()
    {
        var transactions = await _transactionService.GetAllAsync();
        return Ok(transactions);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetTransactionById(int id)
    {
        var transaction = await _transactionService.GetByIdAsync(id);

        if (transaction == null)
        {
            return NotFound($"Transaction with Id {id} not found.");
        }

        return Ok(transaction);
    }

    [HttpPost("deposit")]
    public async Task<IActionResult> Deposit([FromBody] DepositRequestDto request)
    {
        var result = await _transactionService.DepositAsync(request);
        return Ok(result);
    }

    [HttpPost("withdraw")]
    public async Task<IActionResult> Withdraw([FromBody] WithdrawRequestDto request)
    {
        var result = await _transactionService.WithdrawAsync(request);
        return Ok(result);
    }

    [HttpPost("transfer")]
    public async Task<IActionResult> Transfer([FromBody] TransferRequestDto request)
    {
        var result = await _transactionService.TransferAsync(request);
        return Ok(result);
    }

    [HttpGet("ministatement/{accountNumber}")]
public async Task<IActionResult> GetMiniStatement(string accountNumber)
{
    var result =
        await _transactionService.GetMiniStatementAsync(accountNumber);

    return Ok(result);
}
}