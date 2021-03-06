using Cuhadar.Bank.Application.Configuration.Commands;
using Cuhadar.Bank.Application.Configuration.Identity;
using Cuhadar.Bank.Domain.Customers;
using Cuhadar.Bank.Domain.SeedWork;
using Cuhadar.Bank.Domain.Transactions;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Cuhadar.Bank.Application.Transactions.WithdrawMoney
{
    public class WithdrawMoneyCommandHandler : ICommandHandler<WithdrawMoneyCommand, Guid>
    {
        private readonly IAccountRepository accountRepository;
        private readonly ITransactionRepository transactionRepository;
        private readonly IUnitOfWork unitOfWork;

        public WithdrawMoneyCommandHandler(
            IAccountRepository accountRepository,
            ITransactionRepository transactionRepository,
            IUnitOfWork unitOfWork)
        {
            this.accountRepository = accountRepository;
            this.transactionRepository = transactionRepository;

            this.unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(WithdrawMoneyCommand request, CancellationToken cancellationToken)
        {
            var account =await accountRepository.GetAccountAsync(request.AccountId);
            var transaction = account.WithDrawMoney(request.Value);
            var result = await transactionRepository.AddTransactionAsync(transaction);  
            await this.unitOfWork.CommitAsync(cancellationToken);
            return result;
        }
    }
}
