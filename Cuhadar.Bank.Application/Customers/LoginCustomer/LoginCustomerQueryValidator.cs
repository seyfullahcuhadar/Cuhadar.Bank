using Cuhadar.Bank.Application.Customers;
using FluentValidation;


namespace Cuhadar.Bank.Application.Customers.LoginCustomer
{
    public class LoginCustomerQueryValidator : AbstractValidator<LoginCustomerQuery>
    {
        public LoginCustomerQueryValidator()
        {
            RuleFor(x => x.Username).NotEmpty().WithMessage("Username is empty");

            RuleFor(x => x.Password).NotEmpty().WithMessage("Password is empty");
        }
    }
}
