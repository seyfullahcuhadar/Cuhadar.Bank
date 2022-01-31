using Cuhadar.Bank.Domain.Accounts;
using Cuhadar.Bank.Domain.Customers;
using Cuhadar.Bank.Domain.SeedWork;
using Cuhadar.Bank.Domain.Transactions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Cuhadar.Bank.Infrastructure.Database
{
    public class BankContext:DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public BankContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BankContext).Assembly);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            foreach (var entityEntry in ChangeTracker.Entries()) // Iterate all made changes
            {
                if (entityEntry.Entity is Entity entity)
                {
                    if (entityEntry.State == EntityState.Added) // If you want to update TenantId when Order is added
                    {
                        entity.ModifiedAt = DateTime.Now;
                        entity.CreatedAt = DateTime.Now;

                    }
                    else if (entityEntry.State == EntityState.Modified) // If you want to update TenantId when Order is modified
                    {
                        entity.ModifiedAt = DateTime.Now;
                    }
                }
            }
            return base.SaveChangesAsync();
        }

    }
}
