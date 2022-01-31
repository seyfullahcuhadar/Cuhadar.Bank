using System;
using System.Threading.Tasks;

namespace Cuhadar.Bank.Domain.Customers
{
    public interface ICustomerRepository
    {
        Task<Customer> GetCustomerByUsernameAsync(string username);
        Task<Customer> GetByIdAsync(Guid id);

        Task AddAsync(Customer customer);
    }
}
