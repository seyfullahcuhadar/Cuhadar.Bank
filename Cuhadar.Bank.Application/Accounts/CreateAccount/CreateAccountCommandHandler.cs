using Cuhadar.Bank.Application.Configuration.Commands;
using Cuhadar.Bank.Domain.Customers;
using Cuhadar.Bank.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Cuhadar.Bank.Application.Accounts.CreateAccount
{
    public class CreateAccountCommandHandler : ICommandHandler<CreateAccountCommand, Guid>
    {
        private readonly ICustomerRepository customerRepository;
        private readonly IUnitOfWork unitOfWork;

        public CreateAccountCommandHandler(
             ICustomerRepository customerRepository,
             IUnitOfWork unitOfWork)
        {
            this.customerRepository = customerRepository;
            this.unitOfWork = unitOfWork;
        }


        public async Task<Guid> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
        {
            var customer =await  customerRepository.GetCustomerByUsernameAsync(request.Username);
            var account = customer.CreateAccount();
            await unitOfWork.CommitAsync();
            return account.Id;
        }
    }
}
