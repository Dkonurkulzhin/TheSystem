using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Overlord
{
    public static class FinancialManager
    {
        private static Cashbox cashbox = new Cashbox();
        public static bool CashInitialized = false;

        public delegate void MessageDelegate(string message);
        public static event MessageDelegate OnNotify;

        public static void Initialize()
        {
            LoadCashboxData();
        }

        public static bool LoadCashboxData()
        {
            cashbox = XMLManager.DeserializeCashData();
            if (cashbox!=null)
                CashInitialized = true;
            cashbox.Currency = GlobalVars.DefaultCurrency;
            UpdateCash();
            if (GlobalVars.isLocal)
                return true;
            else
                return false;
        }

        public static string getCurrency()
        {
            return cashbox.Currency;
        }

        public static long getCurrentCash()
        {
            return cashbox.CurrentCash;
        }

        public static void WithdrawFunds(long Val, bool RequresNotify = false, string NotifyMessage = "")
        {
            cashbox.CurrentCash = cashbox.CurrentCash - Val;
            UpdateCash();
            if (RequresNotify)
                OnNotify?.Invoke(NotifyMessage);

        }

        public static void AddFunds(long Val, bool RequresNotify = false, string NotifyMessage = "")
        {
            cashbox.CurrentCash = cashbox.CurrentCash + Val;
            UpdateCash();
            if (RequresNotify)
                OnNotify?.Invoke(NotifyMessage);
        }

        public static void UpdateCash()
        {
            XMLManager.SerializeCashData(cashbox);
            //   Program.MainForm.label1.Text = "В кассе: " + CurrentCash.ToString() + " " + Currency;
        }

        public static string GetCashString()
        {
            return cashbox.CurrentCash.ToString() + " " + cashbox.Currency;
        }

        public static void ClearCash()
        {
            cashbox = new Cashbox();
            UpdateCash();
        }

        public static void SetUpMachineGroupPrices(int groupIndex, decimal multiplier)
        {

        }
    }
}
