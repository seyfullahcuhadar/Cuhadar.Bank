using Cuhadar.Bank.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuhadar.Bank.Domain.Customers.Rules
{
    public class CustomerTcMustBeValid : IBusinessRule
    {
        private readonly string _tcNo;

        public CustomerTcMustBeValid(string TcNo)
        {
            _tcNo = TcNo;
        }


        public string Message => $"Customer with this tc no ({_tcNo}) is not valid";

        public bool IsBroken()
        {
            return !IsTcNoValid(_tcNo);
        }
        private  bool IsTcNoValid(string TcNo)
        {
            bool returnvalue = false;
            if (TcNo.Length == 11)
            {
                Int64 ATCNO, BTCNO, tcno;
                long C1, C2, C3, C4, C5, C6, C7, C8, C9, Q1, Q2;

                tcno = Int64.Parse(TcNo);

                ATCNO = tcno / 100;
                BTCNO = tcno / 100;

                C1 = ATCNO % 10; ATCNO = ATCNO / 10;
                C2 = ATCNO % 10; ATCNO = ATCNO / 10;
                C3 = ATCNO % 10; ATCNO = ATCNO / 10;
                C4 = ATCNO % 10; ATCNO = ATCNO / 10;
                C5 = ATCNO % 10; ATCNO = ATCNO / 10;
                C6 = ATCNO % 10; ATCNO = ATCNO / 10;
                C7 = ATCNO % 10; ATCNO = ATCNO / 10;
                C8 = ATCNO % 10; ATCNO = ATCNO / 10;
                C9 = ATCNO % 10; ATCNO = ATCNO / 10;
                Q1 = ((10 - ((((C1 + C3 + C5 + C7 + C9) * 3) + (C2 + C4 + C6 + C8)) % 10)) % 10);
                Q2 = ((10 - (((((C2 + C4 + C6 + C8) + Q1) * 3) + (C1 + C3 + C5 + C7 + C9)) % 10)) % 10);

                returnvalue = ((BTCNO * 100) + (Q1 * 10) + Q2 == tcno);
            }
            return returnvalue;
        }
    }
}
