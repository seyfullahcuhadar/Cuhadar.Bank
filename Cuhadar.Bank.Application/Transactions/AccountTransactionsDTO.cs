using Cuhadar.Bank.Domain.Transactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuhadar.Bank.Application.Transactions
{
    public class AccountTransactionsDTO
    {
        public Guid AccountId { get; set; }
        public List<TransactionDTO> Transactions { get; set; }

        public AccountTransactionsDTO(Guid AccountId,List<Transaction> transactions)
        {
            this.AccountId = AccountId;
            this.Transactions = transactions.Select(t => new TransactionDTO(t.Id, t.Value, t.Type)).ToList();
        }
    }
}
