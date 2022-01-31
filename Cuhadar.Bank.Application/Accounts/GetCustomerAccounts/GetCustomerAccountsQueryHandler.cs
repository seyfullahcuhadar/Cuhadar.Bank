using Cuhadar.Bank.Application.Configuration.Commands;
using Cuhadar.Bank.Application.Configuration.Queries;
using Cuhadar.Bank.Domain.Customers;
using Cuhadar.Bank.Domain.SeedWork;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Cuhadar.Bank.Application.Accounts.CreateAccount
{
    public class GetCustomerAccountsQueryHandler : IQueryHandler<GetCustomerAccountsQuery, CustomerAccountsDTO>
    {
        private readonly ICustomerRepository customerRepository;
        private readonly IAccountRepository accountRepository;

        public GetCustomerAccountsQueryHandler(
             ICustomerRepository customerRepository,
             IAccountRepository accountRepository)
        {
            this.customerRepository = customerRepository;
            this.accountRepository = accountRepository;
        }

        public async Task<CustomerAccountsDTO> Handle(GetCustomerAccountsQuery request, CancellationToken cancellationToken)
        {
            var customer = await customerRepository.GetCustomerByUsernameAsync(request.Username);
            var accounts = await accountRepository.GetCustomerAccountsAsync(customer.Id);
            return new CustomerAccountsDTO(customer, accounts);

        }
    }
}
