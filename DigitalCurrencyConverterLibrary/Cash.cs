using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalCurrencyConverterLibrary
{
    public class Cash : Currency
    {
        public Cash(decimal amount)
            :base(amount)
        {
            CashValue = 1;
        }

        //------------------ Methods ------------------
        //Convert Cash to Bitcoin
        public static Bitcoin GetBitcoin(Cash cash)
        {
            Bitcoin bitcoin = new Bitcoin(cash.Amount / 1.496m);
            return bitcoin;
        }

        //Convert Cash to Litecoin
        public static Litecoin GetLitecoin(Cash cash)
        {
            Litecoin litecoin = new Litecoin(cash.Amount / 0.023808m);
            return litecoin;
        }

        //Convert Cash to Etherium
        public static Etherium GetEtherium(Cash cash)
        {
            Etherium etherium = new Etherium(cash.Amount / 0.11723m);
            return etherium;
        }




        //Public ToString() Override
        public override string ToString()
        {
            return $"{Amount:c}";
        }
    }
}
