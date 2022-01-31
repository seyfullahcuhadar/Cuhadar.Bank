using Cuhadar.Bank.Application.Configuration.Queries;

namespace Cuhadar.Bank.Application.Customers.GetCustomer
{
    public class GetCustomerQuery: IQuery<CustomerDTO>
    {
        public string Username { get; set; }

        public GetCustomerQuery(string username)
        {
            this.Username = username;
        }
    }
}
