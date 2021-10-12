using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalCurrencyConverterLibrary
{
    public class Currency
    {
        public decimal CashValue { get; set; }
        public decimal Amount { get; set; }

        public Currency(decimal amount)
        {
            Amount = amount;
        }

        public static Cash GetCashValue(Currency currency)
        {
            decimal cashAmount = currency.Amount * currency.CashValue;

            Cash nowCash = new Cash(cashAmount);
            return nowCash;
        }
    }
}
