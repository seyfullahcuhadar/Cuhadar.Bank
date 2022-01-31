using Autofac;

using Cuhadar.Bank.Infrastructure.Database;
using Cuhadar.Bank.Infrastructure.Domain;
using Cuhadar.Bank.Infrastructure.Identity;
using Cuhadar.Bank.Infrastructure.Processing;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace Cuhadar.Bank.Infrastructure
{
    public class ApplicationStartup
    {
        public static void Initialize(
            IServiceCollection services,
            ContainerBuilder container,
            string connectionString,
            ILogger logger)
        {
            CreateAutofacServiceProvider(
                services,
                container,
                connectionString,
                logger
                );
        }
        private static void CreateAutofacServiceProvider(
            IServiceCollection services,
            ContainerBuilder container,
            string connectionString,
            ILogger logger)
        {
            container.RegisterModule(new DomainModule());

            container.RegisterModule(new DataAccessModule(connectionString));
            container.RegisterModule(new IdentityModule(connectionString));
            container.RegisterModule(new MediatorModule());

        }


    }
}