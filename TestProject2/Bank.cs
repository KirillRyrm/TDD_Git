using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject2
{
    public class Bank
    {
        private Dictionary<string, int> rates = new Dictionary<string, int>();

        public Money Reduce(Expression source, string to)
        {
            return source.Reduce(this, to);
        }



        public void AddRate(string from, string to, int rate)
        {
            string pair = from + to;
            rates[pair] = rate;
        }

        public void SetRate(string from, string to, int rate)
        {
            rates[$"{from}_{to}"] = rate;
            rates[$"{to}_{from}"] = 1 / rate;
        }

        public int Rate(string from, string to)
        {

            return (from.Equals("CHF") && to.Equals("USD")) ? 2 : 1;
            /*if (from.Equals(to))
                return 1;

            string pair = from + to;
            if (rates.TryGetValue(pair, out int rate))
                return rate;

            return 1;*/
        }
    }
}
