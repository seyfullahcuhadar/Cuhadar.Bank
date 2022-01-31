using Cuhadar.Bank.Application.Configuration.Queries;
using Cuhadar.Bank.Domain.Transactions;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Cuhadar.Bank.Application.Transactions.GetTransactions
{
    public class GetTransactionsQueryHandler : IQueryHandler<GetTransactionsQuery, AccountTransactionsDTO>
    {
        private readonly ITransactionRepository transactionRepository;
        public GetTransactionsQueryHandler(
          ITransactionRepository transactionRepository)
        {
            this.transactionRepository = transactionRepository;
        }
     

        async Task<AccountTransactionsDTO> IRequestHandler<GetTransactionsQuery, AccountTransactionsDTO>.Handle(GetTransactionsQuery request, CancellationToken cancellationToken)
        {
            var transactions = await transactionRepository.GetTransactionsAsync(request.AccountId);
            var accountTransactionsDTO = new AccountTransactionsDTO(request.AccountId, transactions);

            return accountTransactionsDTO;
        }
    }
}
