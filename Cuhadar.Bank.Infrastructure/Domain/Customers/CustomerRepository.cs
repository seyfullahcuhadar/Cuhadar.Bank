using Cuhadar.Bank.Domain.Customers;
using Cuhadar.Bank.Infrastructure.Database;
using Cuhadar.Bank.Infrastructure.SeedWork;
using Microsoft.EntityFrameworkCore;
using System;

using System.Threading.Tasks;

namespace Cuhadar.Bank.Infrastructure.Domain.Customers
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly BankContext context;

        public CustomerRepository(BankContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task AddAsync(Customer customer)
        {
            await this.context.Customers.AddAsync(customer);
        }

        public async Task<Customer> GetByIdAsync(Guid id)
        {
            return await this.context.Customers
                .SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Customer> GetCustomerByUsernameAsync(string username)
        {
            return await this.context.Customers.SingleOrDefaultAsync(x => x.Username == username);
        }
    }
}
