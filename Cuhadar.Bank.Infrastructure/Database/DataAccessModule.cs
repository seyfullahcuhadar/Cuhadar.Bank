using Autofac;
using Cuhadar.Bank.Application.Configuration.Data;
using Cuhadar.Bank.Domain.Customers;
using Cuhadar.Bank.Domain.SeedWork;
using Cuhadar.Bank.Domain.Transactions;
using Cuhadar.Bank.Infrastructure.Domain;
using Cuhadar.Bank.Infrastructure.Domain.Customers;
using Cuhadar.Bank.Infrastructure.Domain.Transactions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;


namespace Cuhadar.Bank.Infrastructure.Database
{
    public class DataAccessModule : Module
    {
        private readonly string _databaseConnectionString;

        public DataAccessModule(string databaseConnectionString)
        {
            _databaseConnectionString = databaseConnectionString;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<SqlConnectionFactory>()
                .As<ISqlConnectionFactory>()
                .WithParameter("connectionString", _databaseConnectionString)
                .InstancePerLifetimeScope();

            builder.RegisterType<UnitOfWork>()
                .As<IUnitOfWork>()
                .InstancePerLifetimeScope();

            builder.RegisterType<CustomerRepository>()
                .As<ICustomerRepository>()
                .InstancePerLifetimeScope();
            builder.RegisterType<AccountRepository>()
               .As<IAccountRepository>()
               .InstancePerLifetimeScope();
            builder.RegisterType<TransactionRepository>()
                .As<ITransactionRepository>()
                .InstancePerLifetimeScope();



            builder
                .Register(c =>
                {
                    var dbContextOptionsBuilder = new DbContextOptionsBuilder<BankContext>();
                    dbContextOptionsBuilder.UseSqlServer(_databaseConnectionString);
                    return new BankContext(dbContextOptionsBuilder.Options);
                })
                .AsSelf()
                .As<DbContext>()
                .InstancePerLifetimeScope();
        }
    }
}