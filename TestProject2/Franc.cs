using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject2
{
    public class Franc : Money
    {
        public Franc(int amount, string currency) : base(amount, currency) { }


        public override Money Times(int multiplier)
        {
            return new Money(amount * multiplier, currency);
        }

        static Money franc(int amount)
        {
            return new Money(amount, "CHF");
        }


    }
}
