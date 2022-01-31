using Cuhadar.Bank.Application.Transactions;
using Cuhadar.Bank.Application.Transactions.DepositMoney;
using Cuhadar.Bank.Application.Transactions.GetTransactions;
using Cuhadar.Bank.Application.Transactions.WithdrawMoney;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Cuhadar.Bank.API.Transactions
{
    [Authorize]
    [Route("api/transactions")]
    [ApiController]
    public class TransactionsController : Controller
    {
        private readonly IMediator _mediator;

        public TransactionsController(IMediator mediator)
        {
            this._mediator = mediator;

        }

        /// <summary>
        /// Register customer.
        /// </summary>
        [Route("withdrawmoney")]
        [HttpPost]
        [AllowAnonymous]

        [ProducesResponseType(typeof(Guid), (int)HttpStatusCode.Created)]
        public async Task<IActionResult> WithdrawMoney([FromBody] WithdrawMoneyRequest request)
        {

            var transaction = await _mediator.Send(new WithdrawMoneyCommand(request.AccountId,request.Value));
            return Created(string.Empty, transaction);
        }

        [Route("depositmoney")]
        [HttpPost]
        [AllowAnonymous]
        [ProducesResponseType(typeof(Guid), (int)HttpStatusCode.Created)]
        public async Task<IActionResult> DepositMoney([FromBody] DepositMoneyRequest request)
        {

            var customer = await _mediator.Send(new DepositMoneyCommand(request.AccountId, request.Value));
            return Ok(customer);
        }
        [Authorize]
        [Route("")]
        [HttpGet]
        [ProducesResponseType(typeof(AccountTransactionsDTO), (int)HttpStatusCode.Created)]
        public async Task<IActionResult> GetTransactions([FromQuery] string accountId)
        {

            var transactions = await _mediator.Send(new GetTransactionsQuery(Guid.Parse(accountId)));
            return Ok(transactions);
        }

    }
}
