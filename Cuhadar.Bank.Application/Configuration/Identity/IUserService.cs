using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuhadar.Bank.Application.Configuration.Identity
{
    public interface IUserService
    {
        public Task<string> LoginAsync(string username, string password);
        public Task<string> RegisterAsync(string username, string password);

    }
}
