using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Overlord
{
    public class Cashbox
    {
        public long CurrentCash;
        public string Currency;
        private bool CashInitialized = false;

        private XMLManager CashBoxXml = new XMLManager();


        public bool LoadCashboxData()
        {
            CashInitialized = true;
            UpdateCash();
                if (GlobalVars.isLocal)
                return true;
            else
                return false;
        }

        public long getCurrentCash()
        {
            Currency = GlobalVars.DefaultCurrency;
            return CurrentCash;
        } 

        public void WithdrawFunds(long Val)
        {
            CurrentCash = CurrentCash - Val;
            UpdateCash();

        }

        public void AddFunds(long Val)
        {
            CurrentCash = CurrentCash + Val;
            UpdateCash();
        }

        public void UpdateCash()
        {
            CashBoxXml.SerializeCashData(this);
         //   Program.MainForm.label1.Text = "В кассе: " + CurrentCash.ToString() + " " + Currency;
        }

        public string GetCashString()
        {
            return CurrentCash.ToString() + " " + Currency;
        }
    }
}
