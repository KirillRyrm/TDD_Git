using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject2
{
    public class Dollar : Money
    {
        public Dollar(int amount, string currency) : base(amount, currency) { }


        public override Money Times(int multiplier)
        {
            return new Money(amount * multiplier, currency);
        }

        static Money dollar(int amount)
        {
            return new Money(amount, "USD");
        }

    }
}
