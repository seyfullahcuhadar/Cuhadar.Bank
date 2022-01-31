namespace Cuhadar.Bank.Domain.Customers
{
    public interface ICustomerUniquenessChecker
    {
        bool IsTcNoUnique(string TcNo);
        bool IsUsernameUnique(string TcNo);

    }
}