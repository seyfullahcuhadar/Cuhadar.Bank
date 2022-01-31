using Cuhadar.Bank.Application.Accounts;
using Cuhadar.Bank.Application.Accounts.CreateAccount;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Cuhadar.Bank.API.Accounts
{
    [Authorize]
    [Route("api/accounts")]
    [ApiController]
    public class AccountsController : Controller
    {
        private readonly IMediator _mediator;

        public AccountsController(IMediator mediator)
        {
            this._mediator = mediator;

        }


        [Route("")]
        [HttpPost]
        [ProducesResponseType(typeof(Guid), (int)HttpStatusCode.Created)]
        public async Task<IActionResult> CreateAccount()
        {
            var username = HttpContext.User.Identity.Name;
            var account = await _mediator.Send(new CreateAccountCommand(username) );

            return Created(string.Empty, account);
        }

        [Route("")]
        [HttpGet]
        [ProducesResponseType(typeof(CustomerAccountsDTO), (int)HttpStatusCode.Created)]
        public async Task<IActionResult> GetCustomerAccounts()
        {
            var username = HttpContext.User.Identity.Name;
            var customerAccounts = await _mediator.Send(new GetCustomerAccountsQuery(username));
            return Ok(customerAccounts);
        }

    }
}
