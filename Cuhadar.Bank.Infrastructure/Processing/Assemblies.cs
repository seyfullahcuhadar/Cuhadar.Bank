using Cuhadar.Bank.Application.Customers.RegisterCustomer;
using System.Reflection;

namespace Cuhadar.Bank.Infrastructure.Processing
{
    internal static class Assemblies
    {
        public static readonly Assembly Application = typeof(RegisterCustomerCommand).Assembly;
    }
}