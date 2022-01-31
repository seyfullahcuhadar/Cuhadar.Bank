using Cuhadar.Bank.Application.Configuration.Queries;
using System;


namespace Cuhadar.Bank.Application.Accounts
{
    public class GetCustomerAccountsQuery: IQuery<CustomerAccountsDTO>
    {
        public string  Username { get;}

        public GetCustomerAccountsQuery(string username)
        {
            Username = username;
        }
    }
}
