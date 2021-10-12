using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalCurrencyConverterLibrary
{
    public class Litecoin : Currency
    {
        public Litecoin(decimal amount)
            :base(amount)
        {
            CashValue = 0.023808m;
        }


        //Public ToString() Override
        public override string ToString()
        {
            return $"{Amount:F2} Litecoin.  Equivalent to {(Amount * 0.023808m):c}";
        }
    }
}
