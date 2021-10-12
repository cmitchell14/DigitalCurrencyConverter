using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalCurrencyConverterLibrary
{
    public class Bitcoin : Currency
    {
        public Bitcoin(decimal amount)
            :base(amount)
        {
            CashValue = 1.496m;
        }


        //Public ToString() Override
        public override string ToString()
        {
            return $"{Amount:F2} Bitcoin.  Equivalent to {(Amount * 1.496m):c}";
        }
    }
}
