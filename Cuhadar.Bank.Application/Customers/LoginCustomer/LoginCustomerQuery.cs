using Cuhadar.Bank.Application.Configuration.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuhadar.Bank.Application.Customers.LoginCustomer
{
    public class LoginCustomerQuery: IQuery<CustomerDTO>
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public LoginCustomerQuery(string username, string password)
        {
            Username = username;
            Password = password;
        }
    }
}
