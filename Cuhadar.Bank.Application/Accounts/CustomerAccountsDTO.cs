using Cuhadar.Bank.Domain.Accounts;
using Cuhadar.Bank.Domain.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuhadar.Bank.Application.Accounts
{
    public class CustomerAccountsDTO
    {
        public Guid CustomerId { get;  }
        public string Name { get; }
        public string Surname { get; }
        public string Username { get;}
        public List<AccountDTO> Accounts { get;}
        public CustomerAccountsDTO(Customer customer,List<Account> accounts)
        {
            CustomerId = customer.Id;
            Name = customer.Name;
            Surname = customer.Surname;
            Username = customer.Username;
            Accounts = accounts.Select(a => new AccountDTO { AccountId = a.Id, Balance = a.Balance }).ToList();
        }
    }
}
