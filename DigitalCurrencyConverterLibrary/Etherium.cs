using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalCurrencyConverterLibrary
{
    public class Etherium : Currency
    {
        public Etherium(decimal amount)
            :base(amount)
        {
            CashValue = 0.11723m;
        }


        //Public ToString() Override
        public override string ToString()
        {
            return $"{Amount:F2} Bitcoin.  Equivalent to {(Amount * 0.11723m):c}";
        }
    }
}
