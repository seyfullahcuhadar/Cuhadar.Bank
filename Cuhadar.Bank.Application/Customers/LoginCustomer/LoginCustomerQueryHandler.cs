using Cuhadar.Bank.Application.Configuration.Identity;
using Cuhadar.Bank.Application.Configuration.Queries;
using Cuhadar.Bank.Domain.Customers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Cuhadar.Bank.Application.Customers.LoginCustomer
{
    internal class LoginCustomerQueryHandler : IQueryHandler<LoginCustomerQuery, CustomerDTO>
    {
        private readonly ICustomerRepository customerRepository;
        private readonly IUserService userService;
        public LoginCustomerQueryHandler(
          ICustomerRepository customerRepository,
          IUserService userService)
        {
            this.customerRepository = customerRepository;
            this.userService = userService;
        }
        async Task<CustomerDTO> IRequestHandler<LoginCustomerQuery, CustomerDTO>.Handle(LoginCustomerQuery request, CancellationToken cancellationToken)
        {
            var result = await userService.LoginAsync(request.Username, request.Password);
            var customer =await customerRepository.GetCustomerByUsernameAsync(request.Username);
            var customerDTO = new CustomerDTO(customer,result);
            return customerDTO;
        }
    }
}
