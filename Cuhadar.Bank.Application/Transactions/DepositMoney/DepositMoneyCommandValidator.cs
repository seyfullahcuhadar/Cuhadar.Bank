using FluentValidation;


namespace Cuhadar.Bank.Application.Transactions.DepositMoney
{
    public class DepositMoneyCommandValidator : AbstractValidator<DepositMoneyCommand>
    {
        public DepositMoneyCommandValidator()
        {
            RuleFor(x => x.AccountId).NotEmpty().WithMessage("AccountId is empty");

            RuleFor(x => x.Value).GreaterThan(0)
                .WithMessage("Invalid Value It must be greater than zero");
        }
    }
}
