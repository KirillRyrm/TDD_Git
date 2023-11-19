using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject2
{
    public class Money : Expression
    {
        protected int amount;
        protected string currency;

        public int Amount { get { return amount; } }

        public override bool Equals(object obj)
        {
            Money money = (Money)obj;
            return amount == money.amount && currency.Equals(money.currency);
        }

        public static Money dollar(int amount)
        {
            return new Money(amount, "USD");
        }

        public static Money franc(int amount)
        {
            return new Money(amount, "CHF");
        }

        public Money(int amount, string currency)
        {
            this.amount = amount;
            this.currency = currency;
        }

        //public abstract Money Times(int multiplier);

        public virtual Money Times(int multiplier)
        {
            return new Money(amount * multiplier, currency);
        }


        public string Currency
        {
            get { return currency; }
        }

        public override string ToString()
        {
            return amount + " " + currency;
        }

        public Sum plus(Money addend)
        {

            return new Sum(this, addend);
        }



        public Money Reduce(Bank bank, string to)
        {
            int rate = bank.Rate(Currency, to);
            return new Money(amount / rate, to);
        }
    }
}
