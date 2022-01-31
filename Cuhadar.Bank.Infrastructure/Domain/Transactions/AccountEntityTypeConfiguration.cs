using Cuhadar.Bank.Domain.Accounts;
using Cuhadar.Bank.Domain.Customers;
using Cuhadar.Bank.Domain.Transactions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cuhadar.Bank.Infrastructure.Domain.Accounts
{
    public class TransactionTypeConfiguration : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.ToTable("Transactions");
            builder.HasKey(a => a.Id);
            builder.Property(t => t.Type)
            .HasConversion<int>();
        }

      
    }
}
