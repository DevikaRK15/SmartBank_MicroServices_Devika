using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Team1_SmartBank.API.Models;

namespace Team1_SmartBank.API.Services
{
    public interface IJwtService
    {
        string GenerateToken(Customer customer);
    }
}