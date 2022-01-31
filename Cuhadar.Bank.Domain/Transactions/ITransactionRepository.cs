

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cuhadar.Bank.Domain.Transactions
{
    public interface ITransactionRepository
    {
        public  Task<Guid> AddTransactionAsync(Transaction transaction);
        public  Task<List<Transaction>> GetTransactionsAsync(Guid accountId);
    }
}
