using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuhadar.Bank.Infrastructure.SeedWork
{
    public class InfrastructureException:Exception
    {
        public virtual string Code { get; }

        public InfrastructureException(string message) : base(message)
        {
            
        }
        
    }
}
