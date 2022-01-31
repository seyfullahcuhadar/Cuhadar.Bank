using Cuhadar.Bank.Domain.Transactions;
using Cuhadar.Bank.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cuhadar.Bank.Infrastructure.Domain.Transactions
{
    public class TransactionRepository:ITransactionRepository
    {
        private readonly BankContext context;

        public TransactionRepository(BankContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Guid> AddTransactionAsync(Transaction transaction)
        {
       
            await context.Transactions.AddAsync(transaction);
            return transaction.Id;
        }
        public async Task<List<Transaction>> GetTransactionsAsync(Guid accountId)
        {
            var transactions = await context.Accounts.Where(a => a.Id == accountId).SelectMany(a=>a.Transactions).ToListAsync();
            return transactions;

        }
    }
}
