using Cuhadar.Bank.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuhadar.Bank.Domain.Transactions
{
    public class Transaction:Entity
    {
        public Guid AccountId { get; set; }
        public TransactionType Type { get; set; }
        public double Value { get; set; }

        private Transaction(Guid accountId, TransactionType type, double value)
        {
            Id = Guid.NewGuid();
            AccountId = accountId;
            Type = type;
            Value = value;
        }
        public static Transaction Create(Guid accountId,TransactionType type,double value)
        {
            Transaction transaction = new Transaction(accountId, type, value);
            return transaction;
        }
        public static Transaction WithDrawMoney(Guid accountId, double value)
        {

           var transaction =  new Transaction(accountId, TransactionType.WITHDRAW, value);
            return transaction;  
        }

        public static Transaction DepositMoney(Guid accountId, double value)
        {

            var transaction = new Transaction(accountId, TransactionType.DEPOSIT, value);
            return transaction;
        }


    }
}
