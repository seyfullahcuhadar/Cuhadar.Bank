using Cuhadar.Bank.Application.Configuration.Data;
using Cuhadar.Bank.Domain.Customers;
using Dapper;


namespace SampleProject.Application.Customers.DomainServices
{
    public class CustomerUniquenessChecker : ICustomerUniquenessChecker
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        public CustomerUniquenessChecker(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }

        public bool IsUsernameUnique(string username)
        {
            var connection = this._sqlConnectionFactory.GetOpenConnection();

            const string sql = "SELECT TOP 1 1" +
                               "FROM [Customers] AS [Customer] " +
                               "WHERE [Customer].[Username] = @Username";
            var customersNumber = connection.QuerySingleOrDefault<int?>(sql,
                            new
                            {
                                Username = username
                            });

            return !customersNumber.HasValue;
        }
        public bool IsTcNoUnique(string tcno)
        {
            var connection = this._sqlConnectionFactory.GetOpenConnection();

            const string sql = "SELECT TOP 1 1" +
                               "FROM [Customers] AS [Customer] " +
                               "WHERE [Customer].[TcNo] = @TcNo";
            var customersNumber = connection.QuerySingleOrDefault<int?>(sql,
                            new
                            {
                                TcNo = tcno
                            });

            return !customersNumber.HasValue;
        }
    }
}