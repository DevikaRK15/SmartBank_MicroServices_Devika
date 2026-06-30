using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Team1_SmartBank.API.Data;
using Team1_SmartBank.API.Models;

namespace Team1_SmartBank.API.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly AppDbContext _context;
        public CustomerRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Customer> Login(string email, string password)
        {
            return await _context.Customers.FirstOrDefaultAsync(u=>
               u.Email == email &&
               u.Password == password
            );
        }

        public async Task Register(Customer customer)
        {
            await _context.Customers.AddAsync(customer);
            await _context.SaveChangesAsync();
        }
    }
}