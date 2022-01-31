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

namespace Cuhadar.Bank.Application.Customers.GetCustomer
{
    internal class GetCustomerQueryHandler : IQueryHandler<GetCustomerQuery, CustomerDTO>
    {
        private readonly ICustomerRepository customerRepository;
        public GetCustomerQueryHandler(
          ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }
        async Task<CustomerDTO> IRequestHandler<GetCustomerQuery, CustomerDTO>.Handle(GetCustomerQuery request, CancellationToken cancellationToken)
        {
            var customer =await customerRepository.GetCustomerByUsernameAsync(request.Username);
            if (customer is null) return null;

            var customerDTO = new CustomerDTO(customer,"");
            return customerDTO;
        }
    }
}
