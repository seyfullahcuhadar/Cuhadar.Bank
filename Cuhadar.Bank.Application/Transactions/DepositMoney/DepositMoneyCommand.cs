using Cuhadar.Bank.Application.Configuration.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuhadar.Bank.Application.Transactions.DepositMoney
{
    public class DepositMoneyCommand : CommandBase<Guid>
    {

        public Guid AccountId { get; }
        public double Value { get;}

        public DepositMoneyCommand(Guid accountId,double value)
        {
            AccountId = accountId;
            this.Value = value;
        }

    }
}
