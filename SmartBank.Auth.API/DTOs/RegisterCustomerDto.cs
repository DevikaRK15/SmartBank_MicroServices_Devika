using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Team1_SmartBank.API.DTOs
{
    public class RegisterCustomerDto
    {
        public string FullName {get; set;}
        public string Email {get; set;}
        public string Phone {get; set;}
        public string Password {get; set;}
        public string Role {get; set;} = "USER";
    }
}