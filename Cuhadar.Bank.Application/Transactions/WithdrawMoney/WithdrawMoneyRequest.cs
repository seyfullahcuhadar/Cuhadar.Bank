using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuhadar.Bank.Application.Transactions.WithdrawMoney
{
    public class WithdrawMoneyRequest
    {
        public Guid AccountId { get; set; }
        public double Value { get; set; }

    }
}
