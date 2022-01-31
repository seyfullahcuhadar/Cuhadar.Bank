using Cuhadar.Bank.Domain.Accounts;
using Cuhadar.Bank.Domain.Customers;
using Cuhadar.Bank.Domain.Transactions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cuhadar.Bank.Infrastructure.Domain.Accounts
{
    public class AccountEntityTypeConfiguration : IEntityTypeConfiguration<Account>
    {
        internal const string AccountsList = "Accounts";
        internal const string TransactionsList = "Transactions";
 
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.ToTable("Accounts");
            builder.HasKey(a => a.Id);
            builder.HasMany(a => a.Transactions)
                        .WithOne()
                        .HasForeignKey(t => t.AccountId);
        }

      
    }
}
