using Cuhadar.Bank.Application.Customers;
using Cuhadar.Bank.Application.Customers.GetCustomer;
using Cuhadar.Bank.Application.Customers.LoginCustomer;
using Cuhadar.Bank.Application.Customers.RegisterCustomer;
using Cuhadar.Bank.Domain.Customers;
using Cuhadar.Bank.Infrastructure.Identity;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Cuhadar.Bank.API.Customers
{   [Authorize]
    [Route("api/customers")]
    [ApiController]
    public class CustomersController : Controller
    {
        private readonly IMediator _mediator;

        public CustomersController(IMediator mediator)
        {
            this._mediator = mediator;

        }

        /// <summary>
        /// Register customer.
        /// </summary>
        [Route("register")]
        [HttpPost]
        [AllowAnonymous]

        [ProducesResponseType(typeof(Guid), (int)HttpStatusCode.Created)]
        public async Task<IActionResult> RegisterCustomer([FromBody] RegisterCustomerRequest request)
        {

            var customer = await _mediator.Send(new RegisterCustomerCommand(tcNo:request.TcNo,name:request.Name,surname:request.Surname,username:request.Username,password: request.Password));
            return Created(string.Empty, customer);
        }

        [Route("login")]
        [HttpPost]
        [AllowAnonymous]
        [ProducesResponseType(typeof(CustomerDTO), (int)HttpStatusCode.Created)]
        public async Task<IActionResult> LoginCustomer([FromBody] LoginCustomerRequest request)
        {

            var customer = await _mediator.Send(new LoginCustomerQuery(request.Username,request.Password));
            return Ok(customer);
        }
        [Authorize]
        [Route("")]
        [HttpGet]
        [ProducesResponseType(typeof(CustomerDTO), (int)HttpStatusCode.Created)]
        public async Task<IActionResult> GetCustomer([FromQuery] string username)
        {

            var customer = await _mediator.Send(new GetCustomerQuery(username));
            return Ok(customer);
        }

    }
}
