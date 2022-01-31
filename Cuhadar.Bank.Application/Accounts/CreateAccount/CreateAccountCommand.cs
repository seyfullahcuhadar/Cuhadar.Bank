using Cuhadar.Bank.Application.Configuration.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuhadar.Bank.Application.Accounts
{
    public class CreateAccountCommand: CommandBase<Guid>
    {
        public string Username { get;}

        public CreateAccountCommand(string username)
        {
            Username = username;
        }
    }
}
