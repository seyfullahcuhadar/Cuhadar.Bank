using Cuhadar.Bank.Domain.Accounts;
using Cuhadar.Bank.Domain.Customers.Rules;
using Cuhadar.Bank.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuhadar.Bank.Domain.Customers
{
    public class Customer:Entity
    {
        public string Name { get; }
        public string Surname { get;}
        public string Username { get;}
        public string TcNo { get;}
        public ICollection<Account> Accounts { get;}

        private Customer(string name, string surname, string username, string tcNo)
        {

            this.Id = Guid.NewGuid();
            Name = name;
            Surname = surname;
            this.Username = username;
            TcNo = tcNo;
            if (Accounts == null)
                Accounts = new List<Account>();
        }
        public static Customer Create(string name,string surname,string username,string tcNo, ICustomerUniquenessChecker customerUniquenessChecker)
        {
            CheckRule(new CustomerTcMustBeValid(tcNo));
            CheckRule(new CustomerUsernameMustBeUnique(customerUniquenessChecker,username));
            
            
            var customer = new Customer(name, surname, username, tcNo);
            return customer;
        }
        public  Account CreateAccount()
        {
            var account = Account.CreateNew(this.Id);
            Accounts.Add(account);
            return account;

        }
        public void RemoveAccount(Guid accountId)
        {
            var account = Accounts.SingleOrDefault(a=>a.Id == accountId);
            Accounts.Remove(account);
        }


    }
}
