using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Overlord
{
    public class Cashbox
    {
        public decimal CurrentCash;
        public string Currency;
        public bool CashInitialized = false;
        public SerializableDictionary<string, decimal> Transactions;

       
    }
}
