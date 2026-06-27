using Microsoft.AspNetCore.Mvc;
using Team1_SmartBank.API.Data;
using Team1_SmartBank.API.Models;
using Team1_SmartBank.API.DTOs;

namespace Team1_SmartBank.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CustomerController(AppDbContext context)
        {
            _context = context;
        }

        // ✅ GET ALL CUSTOMERS
        [HttpGet]
        public IActionResult GetAll()
        {
            var customers = _context.Customers.ToList();
            return Ok(customers);
        }

        // ✅ GET CUSTOMER BY ID
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var customer = _context.Customers.Find(id);

            if (customer == null)
                return NotFound("Customer not found");

            return Ok(customer);
        }

        // ✅ CREATE CUSTOMER
        [HttpPost]
        public IActionResult Create(CustomerDto dto)
        {
            var customer = new Customer
            {
                FullName = dto.FullName,
                Email = dto.Email,
                Phone = dto.Phone
            };

            _context.Customers.Add(customer);
            _context.SaveChanges();

            return Ok(customer);
        }

        // ✅ UPDATE CUSTOMER
        [HttpPut]
        public IActionResult Update(Customer customer)
        {
            var existing = _context.Customers.Find(customer.CustomerId);

            if (existing == null)
                return NotFound("Customer not found");

            existing.FullName = customer.FullName;
            existing.Email = customer.Email;
            existing.Phone = customer.Phone;

            _context.SaveChanges();

            return Ok(existing);
        }

        // ✅ DELETE CUSTOMER
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var customer = _context.Customers.Find(id);

            if (customer == null)
                return NotFound("Customer not found");

            _context.Customers.Remove(customer);
            _context.SaveChanges();

            return Ok("Customer deleted successfully");
        }
    }
}