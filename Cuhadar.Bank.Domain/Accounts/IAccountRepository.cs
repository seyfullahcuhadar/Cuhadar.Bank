using Cuhadar.Bank.Domain.Accounts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cuhadar.Bank.Domain.Customers
{
    public interface IAccountRepository
    {
        Task<List<Account>> GetCustomerAccountsAsync(Guid customerId);

        Task<Account> GetAccountAsync(Guid accountId);

    }
}
