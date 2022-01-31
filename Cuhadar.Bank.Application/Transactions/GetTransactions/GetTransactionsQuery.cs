using Cuhadar.Bank.Application.Configuration.Queries;
using Cuhadar.Bank.Application.Customers;
using System;

namespace Cuhadar.Bank.Application.Transactions.GetTransactions
{
    public class GetTransactionsQuery : IQuery<AccountTransactionsDTO>
    {
        public Guid AccountId { get; set; }

        public GetTransactionsQuery (Guid accountId)
        {
            AccountId = accountId;
        }
    }
}
