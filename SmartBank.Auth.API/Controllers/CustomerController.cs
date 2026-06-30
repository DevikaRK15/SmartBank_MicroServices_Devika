using Microsoft.AspNetCore.Mvc;
using Team1_SmartBank.API.Data;
using Team1_SmartBank.API.Models;
using Team1_SmartBank.API.DTOs;
using Team1_SmartBank.API.Services;

namespace Team1_SmartBank.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        // private readonly AppDbContext _context;
        private readonly IJwtService _jwtService;
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService, IJwtService jwtService)
        {
            _customerService = customerService;
            _jwtService = jwtService;
        }

        // ? GET ALL CUSTOMERS
        // [HttpGet]
        // public IActionResult GetAll()
        // {
        //     // var customers = _customerService.
        //     // return Ok(customers);
        // }

        // ? GET CUSTOMER BY ID
        // [HttpGet("{id}")]
        // public IActionResult GetById(int id)
        // {
        //     var customer = _context.Customers.Find(id);

        //     if (customer == null)
        //         return NotFound("Customer not found");

        //     return Ok(customer);
        // }

        // ? CREATE CUSTOMER
        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterCustomerDto dto)
        {
           await _customerService.Register(dto);
            // _context.Customers.Add(customer);
            // _context.SaveChanges();

            return Ok(dto);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginCustomerDto dto)
        {
            await _customerService.Login(dto);
            // if(!ModelState.IsValid)
            // {
            //     return View(dto);
            // }
            var user = await _customerService.Login(dto);
            if(user == null)
            {
                // ViewBag.Message = "Invalid Email or Password";
                return BadRequest(dto);
            }
            var token = _jwtService.GenerateToken(user);
            
            // using cookies instead of sessions or local_storage
            Response.Cookies.Append(
                "jwt", token, new CookieOptions
                {
                    HttpOnly = true,
                    Secure = false,
                    Expires = DateTimeOffset.UtcNow.AddMinutes(30)
                }
            );

            Console.WriteLine($"Token {token}");

            // HttpContext.Session.SetString("JWToken", token);

            // return RedirectToAction("Dashboard", "Product");
            return Ok(new{token});
        }

        // ? UPDATE CUSTOMER
        // [HttpPut]
        // public IActionResult Update(Customer customer)
        // {
        //     var existing = _context.Customers.Find(customer.CustomerId);

        //     if (existing == null)
        //         return NotFound("Customer not found");

        //     existing.FullName = customer.FullName;
        //     existing.Email = customer.Email;
        //     existing.Phone = customer.Phone;

        //     _context.SaveChanges();

        //     return Ok(existing);
        // }

        // ? DELETE CUSTOMER
        // [HttpDelete("{id}")]
        // public IActionResult Delete(int id)
        // {
        //     var customer = _context.Customers.Find(id);

        //     if (customer == null)
        //         return NotFound("Customer not found");

        //     _context.Customers.Remove(customer);
        //     _context.SaveChanges();

        //     return Ok("Customer deleted successfully");
        // }
    }
}
