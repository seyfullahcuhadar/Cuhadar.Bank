
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Hellang.Middleware.ProblemDetails;
using Cuhadar.Bank.Application.Configuration.Validation;
using Cuhadar.Bank.API.SeedWork;
using Cuhadar.Bank.Domain.SeedWork;
using Cuhadar.Bank.Application.Configuration;
using Microsoft.AspNetCore.Http;
using Cuhadar.Bank.API.Configuration;
using Cuhadar.Bank.Infrastructure;
using Serilog;
using System.Reflection;
using MediatR;
using Autofac;
using Cuhadar.Bank.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.eShopWeb.ApplicationCore.Constants;
using Cuhadar.Bank.Infrastructure.SeedWork;
using Microsoft.AspNetCore.Diagnostics;

namespace Cuhadar.Bank
{
    public class Startup
    {
        private const string BankConnectionString = "BankConnectionString";

        public IConfiguration Configuration { get; }

        private static ILogger _logger;
        private IServiceCollection services { get; set; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppIdentityDbContext>(options => options.UseSqlServer(this.Configuration[BankConnectionString]));
            services.AddIdentity<ApplicationUser, IdentityRole>()
                 .AddDefaultTokenProviders()
                 .AddUserManager<UserManager<ApplicationUser>>()
                 .AddSignInManager<SignInManager<ApplicationUser>>()
                 .AddEntityFrameworkStores<AppIdentityDbContext>();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })

                     // Adding Jwt Bearer  
                     .AddJwtBearer(options =>
                     {
                         options.SaveToken = true;
                         options.RequireHttpsMetadata = false;
                         options.TokenValidationParameters = new TokenValidationParameters()
                         {
                             ValidateIssuer = true,
                             ValidateAudience = true,
                             ValidAudience = AuthorizationConstants.VALID_AUDIENCE,
                             ValidIssuer = AuthorizationConstants.VALID_ISSUER,
                             IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(AuthorizationConstants.JWT_SECRET_KEY))
                         };
                     }); 
            
            
            services.AddAuthorization();

            services.AddControllers();
            services.AddMemoryCache();

            services.AddSwaggerDocumentation();
            services.AddProblemDetails(x =>
            {
                x.Map<InvalidCommandException>(ex => new InvalidCommandProblemDetails(ex));
                x.Map<BusinessRuleValidationException>(ex => new BusinessRuleValidationExceptionProblemDetails(ex));
                x.Map<InfrastructureException>(ex => new InfrastructureExceptionProblemDetails(ex));

            });
            services.AddHttpContextAccessor();
            services.AddScoped<IExecutionContextAccessor, ExecutionContextAccessor>();
            this.services = services;
        }
        public void ConfigureContainer(ContainerBuilder builder)
        {
            ApplicationStartup.Initialize(
            this.services,
            builder,
            this.Configuration[BankConnectionString],
            _logger);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseMiddleware<CorrelationMiddleware>();
            
            if (env.IsDevelopment())
            {
                app.UseExceptionHandler(c => c.Run(async context =>
                {
                    var exception = context.Features
                        .Get<IExceptionHandlerPathFeature>()
                        .Error;
                    var response = new { error = exception.Message };
                    await context.Response.WriteAsJsonAsync(response);
                }));
            }
            else
            {
                app.UseExceptionHandler(c => c.Run(async context =>
                {
                    var exception = context.Features
                        .Get<IExceptionHandlerPathFeature>()
                        .Error;
                    var response = new { error = exception.Message };
                    await context.Response.WriteAsJsonAsync(response);
                }));
            }
            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            //app.UseSwagger();
            //app.UseSwaggerUI();
            app.UseSwaggerDocumentation();

        }
    }
}
