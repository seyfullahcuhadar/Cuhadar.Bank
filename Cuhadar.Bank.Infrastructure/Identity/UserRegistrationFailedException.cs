using Cuhadar.Bank.Infrastructure.SeedWork;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuhadar.Bank.Infrastructure.Identity
{
    public class UserRegistrationFailedException : InfrastructureException
    {
        public override string Code { get; }


        public UserRegistrationFailedException(IdentityResult result) : base(result.Errors.ToString())
        {
            Code = String.Join(",", result.Errors.Select(e => e.Code)); 
        }

    }
}
