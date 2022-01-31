

using Autofac;
using Cuhadar.Bank.Application.Configuration.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Cuhadar.Bank.Infrastructure.Identity
{
    public class IdentityModule: Module
    {
        private readonly string _databaseConnectionString;

        public IdentityModule(string databaseConnectionString)
        {
            _databaseConnectionString = databaseConnectionString;
        }
        protected override void Load(ContainerBuilder builder)
        {

           
             
            builder.RegisterType<IdentityTokenClaimService>()
                .As<ITokenClaimsService>()
                .InstancePerLifetimeScope();
            builder.RegisterType<UserService>()
            .As<IUserService>().InstancePerLifetimeScope();

            //builder.RegisterType<UserManager<ApplicationUser>>().AsSelf().InstancePerLifetimeScope();
            //builder.RegisterType<SignInManager<ApplicationUser>>().AsSelf().InstancePerLifetimeScope();



            //builder
            // .Register(c =>
            // {
            //     var dbContextOptionsBuilder = new DbContextOptionsBuilder<AppIdentityDbContext>();
            //     dbContextOptionsBuilder.UseSqlServer(_databaseConnectionString);
            //     return new AppIdentityDbContext(dbContextOptionsBuilder.Options);
            // })
            // .AsSelf()
            // .As<IdentityDbContext<ApplicationUser>>()
            // .InstancePerLifetimeScope();


        }
    }
}
