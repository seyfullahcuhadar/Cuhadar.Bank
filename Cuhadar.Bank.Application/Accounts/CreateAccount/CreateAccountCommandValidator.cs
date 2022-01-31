using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuhadar.Bank.Application.Accounts.CreateAccount
{
    public class CreateAccountCommandValidator: AbstractValidator<CreateAccountCommand>
    {
        public CreateAccountCommandValidator()
        {
            RuleFor(x => x.Username).NotEmpty().WithMessage("Username is empty");

        }
    }
}
