using Cuhadar.Bank.Domain.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuhadar.Bank.Application.Customers
{
    public class CustomerDTO
    {
        public Guid Id { get; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Username { get; set; }
        public string TcNo { get; set; }
        public string Token { get; set; }

        public CustomerDTO(Customer customer,string token)
        {
            Name = customer.Name;
            Surname = customer.Surname;
            Username = customer.Username;
            TcNo = customer.TcNo;
            Token = token;
            Id= customer.Id;
        }




    }
}
