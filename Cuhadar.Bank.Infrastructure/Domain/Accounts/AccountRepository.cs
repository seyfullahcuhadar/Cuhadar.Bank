using Cuhadar.Bank.Domain.Accounts;
using Cuhadar.Bank.Domain.Customers;
using Cuhadar.Bank.Infrastructure.Database;
using Cuhadar.Bank.Infrastructure.SeedWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cuhadar.Bank.Infrastructure.Domain.Customers
{
    public class AccountRepository : IAccountRepository
    {
        private readonly BankContext context;

        public AccountRepository(BankContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Task<Account> GetAccountAsync(Guid accountId)
        {
            var account = context.Accounts.SingleOrDefaultAsync(a=>a.Id == accountId);
            return account;
        }

        public async Task<List<Account>> GetCustomerAccountsAsync(Guid customerId)
        {
            var accounts = await context.Customers.Where(c => c.Id == customerId).SelectMany(a => a.Accounts).ToListAsync();
            return accounts;
        }
    }
}
