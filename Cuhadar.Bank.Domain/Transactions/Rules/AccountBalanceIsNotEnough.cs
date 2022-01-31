using Cuhadar.Bank.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuhadar.Bank.Domain.Transactions.Rules
{
    internal class AccountBalanceIsNotEnough : IBusinessRule
    {
        private readonly double Balance;

        public AccountBalanceIsNotEnough(double balance)
        {
            this.Balance = balance;
        }
        public string Message => "Account balance is not enough";

        public bool IsBroken()
        {
            return Balance < 0;
        }
    }
}
