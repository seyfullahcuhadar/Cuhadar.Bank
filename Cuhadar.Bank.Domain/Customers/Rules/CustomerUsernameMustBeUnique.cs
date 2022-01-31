using Cuhadar.Bank.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuhadar.Bank.Domain.Customers.Rules
{
    public class CustomerUsernameMustBeUnique : IBusinessRule
    {
        private readonly ICustomerUniquenessChecker _customerUniquenessChecker;

        private readonly string _username;

        public CustomerUsernameMustBeUnique(
            ICustomerUniquenessChecker customerUniquenessChecker,
            string username)
        {
            _customerUniquenessChecker = customerUniquenessChecker;
            _username = username;
        }

        public bool IsBroken() => !_customerUniquenessChecker.IsUsernameUnique(_username);

        public string Message => "Customer with this username already exists.";
    }
}
