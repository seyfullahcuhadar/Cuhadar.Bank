using Cuhadar.Bank.Domain.SeedWork;
using Cuhadar.Bank.Infrastructure.Database;
using System.Threading;
using System.Threading.Tasks;


namespace Cuhadar.Bank.Infrastructure.Domain
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BankContext bankContext;

        public UnitOfWork(
            BankContext bankContext)
        {
            this.bankContext = bankContext;
        }

        public async Task<int> CommitAsync(CancellationToken cancellationToken = default)
        {

            return await bankContext.SaveChangesAsync(cancellationToken);
        }
    }
}