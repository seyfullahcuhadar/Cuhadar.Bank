using Cuhadar.Bank.Domain.Accounts;
using Cuhadar.Bank.Domain.Customers;
using Cuhadar.Bank.Domain.Transactions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cuhadar.Bank.Infrastructure.Domain.Customers
{
    public class CustomerEntityTypeConfiguration : IEntityTypeConfiguration<Customer>
    {
        internal const string AccountsList = "Accounts";
        internal const string TransactionsList = "Transactions";

        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customers");
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Name).HasColumnName("Name").IsRequired();
            builder.Property(a => a.Surname).HasColumnName("Surname").IsRequired();
            builder.Property(a => a.Username).HasColumnName("Username").IsRequired();
            builder.Property(a => a.TcNo).HasColumnName("TcNo").IsRequired();
            builder.HasMany(c => c.Accounts)
                    .WithOne()
                    .HasForeignKey(c => c.CustomerId);
                    
        }
    }
}
