using Cuhadar.Bank.Domain.SeedWork;
using Cuhadar.Bank.Domain.Transactions;
using Cuhadar.Bank.Domain.Transactions.Rules;
using System;
using System.Collections.Generic;

namespace Cuhadar.Bank.Domain.Accounts
{
    public class Account:Entity,IAggregateRoot
    {
        public Guid CustomerId { get; set; }
        public double Balance { get; set; }
        public ICollection<Transaction> Transactions { get; set; }

        private Account(Guid customerId, double balance)
        {
            Id = new Guid();
            CustomerId = customerId;
            Balance = balance;
        }
        public static Account CreateNew(Guid CustomerId)
        {
            return new Account(CustomerId, 0);
        }
        public Transaction WithDrawMoney(double value)
        {
            CheckRule(new AccountBalanceIsNotEnough(this.Balance - value));
            var transaction = Transaction.WithDrawMoney(this.Id, value);
            Balance -= value;
            return transaction;
        }
        public Transaction DepositMoney(double value)
        {
            var transaction = Transaction.DepositMoney(this.Id, value);
            Balance += value;
            return transaction;
        }

    }
}
