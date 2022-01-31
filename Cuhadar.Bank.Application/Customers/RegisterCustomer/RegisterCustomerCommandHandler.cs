using Cuhadar.Bank.Application.Configuration.Commands;
using Cuhadar.Bank.Application.Configuration.Identity;
using Cuhadar.Bank.Domain.Customers;
using Cuhadar.Bank.Domain.SeedWork;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Cuhadar.Bank.Application.Customers.RegisterCustomer
{
    public class RegisterCustomerCommandHandler : ICommandHandler<RegisterCustomerCommand, CustomerDTO>
    {
        private readonly ICustomerRepository customerRepository;
        private readonly ICustomerUniquenessChecker customerUniquenessChecker;
        private readonly IUserService userService;
        private readonly IUnitOfWork unitOfWork;

        public RegisterCustomerCommandHandler(
            ICustomerRepository customerRepository,
            ICustomerUniquenessChecker customerUniquenessChecker,
            IUserService userService,
            IUnitOfWork unitOfWork)
        {
            this.customerRepository = customerRepository;
            this.customerUniquenessChecker = customerUniquenessChecker;
            this.userService = userService;
            this.unitOfWork = unitOfWork;
        }

        public async Task<CustomerDTO> Handle(RegisterCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = Customer.Create(request.Name, request.Surname, request.Username, request.TcNo, customerUniquenessChecker);
            await this.customerRepository.AddAsync(customer);
            var token = await userService.RegisterAsync(request.Username, request.Password);
            
            await this.unitOfWork.CommitAsync(cancellationToken);




            return new CustomerDTO(customer,token);
        }
    }
}
