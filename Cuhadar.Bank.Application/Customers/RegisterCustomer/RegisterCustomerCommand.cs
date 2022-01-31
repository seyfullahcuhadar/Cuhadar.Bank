using Cuhadar.Bank.Application.Configuration.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuhadar.Bank.Application.Customers.RegisterCustomer
{
    public class RegisterCustomerCommand: CommandBase<CustomerDTO>
    {
        public string TcNo { get; }
        public string Username { get; }

        public string Name { get; }
        public string Surname { get; }
        public string Password { get; set; }

        public RegisterCustomerCommand(string tcNo, string username, string name, string surname,string password)
        {
            TcNo = tcNo;
            Username = username;
            Name = name;
            Surname = surname;
            Password = password;
        }
    }
}
