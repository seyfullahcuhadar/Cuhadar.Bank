using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuhadar.Bank.Application.Customers.RegisterCustomer
{
    public class RegisterCustomerRequest
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Username { get; set; }
        public string TcNo { get; set; }
        public string Password { get; set; }
    }
}
