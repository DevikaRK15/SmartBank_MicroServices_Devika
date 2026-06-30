using Microsoft.AspNetCore.Mvc;
using SmartBank.Account.API.Models;
using SmartBank.Account.API.Services;

namespace SmartBank.Account.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly IAccountService _service;

    public AccountController(IAccountService service)
    {
        _service = service;
    }



    [HttpGet]
    public IActionResult GetAccounts()
    {
        return Ok(_service.GetAllAccounts());
    }

    [HttpGet("{id}")]
    public IActionResult GetAccount(int id)
    {
        var account = _service.GetAccountById(id);

        if (account == null)
            return NotFound();

        return Ok(account);
    }


    [HttpPut("{id}")]
    public IActionResult UpdateAccount(int id, BankAccount account)
    {
        if (id != account.Id)
            return BadRequest();

        var existing = _service.GetAccountById(id);

        if (existing == null)
            return NotFound();

        existing.AccountType = account.AccountType;
        existing.Balance = account.Balance;
        existing.Role = account.Role;

        _service.UpdateAccount(existing);

        return Ok(existing);
    }

  

    [HttpPost]
    public IActionResult CreateAccount(BankAccount account)
    {
        var result = _service.CreateAccount(account);

        if (result == null)
        {
            return Conflict("Account Number already exists");
        }

        return Ok(result);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteAccount(int id)
    {
        var deleted = _service.DeleteAccount(id);

        if (!deleted)
            return NotFound();

        return Ok("Account Closed Successfully");
    }
}