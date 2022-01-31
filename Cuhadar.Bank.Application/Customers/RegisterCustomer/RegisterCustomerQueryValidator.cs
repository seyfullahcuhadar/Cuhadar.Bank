using FluentValidation;


namespace Cuhadar.Bank.Application.Customers.RegisterCustomer
{
    public class RegisterCustomerQueryValidator : AbstractValidator<RegisterCustomerCommand>
    {
        public RegisterCustomerQueryValidator()
        {
            RuleFor(x => x.Username).NotEmpty().WithMessage("Username is empty");

            RuleFor(x => x.Password).NotEmpty().WithMessage("Password is empty");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is empty");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Surname is empty");


        }
    }
}
