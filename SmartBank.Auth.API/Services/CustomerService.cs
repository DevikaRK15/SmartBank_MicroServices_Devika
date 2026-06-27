using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Team1_SmartBank.API.DTOs;
using Team1_SmartBank.API.Models;
using Team1_SmartBank.API.Repositories;

namespace Team1_SmartBank.API.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _repository;
        public CustomerService(ICustomerRepository repository)
        {
            _repository = repository;
        }

        public async Task<Customer> Login(LoginCustomerDto dto)
        {
            return await _repository.Login(dto.email, dto.password);
        }

        public async Task Register(RegisterCustomerDto dto)
        {
            Customer customer = new Customer
            {
                FullName = dto.FullName,
                Email = dto.Email,
                Phone = dto.Phone,
                Password = dto.Password
            };
            await _repository.Register(customer);
        }
    }
}