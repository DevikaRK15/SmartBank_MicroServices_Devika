using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Team1_SmartBank.API.Models;

namespace Team1_SmartBank.API.Repositories
{
    public interface ICustomerRepository
    {
        Task Register(Customer customer);
        Task<Customer> Login(string email, string password);
    }
}