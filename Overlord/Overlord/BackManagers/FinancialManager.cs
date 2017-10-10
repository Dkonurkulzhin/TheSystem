using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Overlord.Elements;
namespace Overlord
{
    public static class FinancialManager
    {
        private static Cashbox cashbox = new Cashbox();
        public static bool CashInitialized = false;

        public delegate void MessageDelegate(string message);
        public static event MessageDelegate OnNotify;
        public static ExcelHandler Excel = new ExcelHandler();

        public delegate void TransactionEH(decimal val, string type);
        public static event TransactionEH OnTransaction;
        

        public static void Initialize()
        {
            LoadCashboxData();
            OnTransaction += LogTransaction;
        }

        public static void LogTransaction(decimal val, string type = "")
        {
            string TransactionName = DateTime.Now.ToString() + "." + type;
            if (cashbox.Transactions.ContainsKey(TransactionName))
                cashbox.Transactions[TransactionName] += val;
            else
                cashbox.Transactions.Add(TransactionName, val);
        }

        public static void MakeShiftReport()
        {
            Excel.CreateShiftReport(cashbox);
            cashbox.Transactions.Clear();
            cashbox.Transactions = null;
            UpdateCash();
            OnNotify?.Invoke("Смена закончена");
        }

        public static bool LoadCashboxData()
        {
            cashbox = XMLManager.DeserializeCashData();
            if (cashbox!=null)
                CashInitialized = true;
            else
                return false;
            cashbox.Currency = GlobalVars.DefaultCurrency;
            if (cashbox.Transactions == null)
                cashbox.Transactions = new SerializableDictionary<string, decimal>();
            UpdateCash();
            if (GlobalVars.isLocal)
                return true;
            else
                return false;
        }

        public static string getCurrency()
        {
            return (cashbox != null) ? cashbox.Currency : "";
        }

        public static decimal getCurrentCash()
        {
            return (cashbox != null) ? cashbox.CurrentCash : -1;
        }

        public static void WithdrawFunds(decimal Val, bool RequresNotify = false, string NotifyMessage = "")
        {
            cashbox.CurrentCash -= Val;
            OnTransaction?.Invoke(Val, "");
            UpdateCash();
            if (RequresNotify)
                OnNotify?.Invoke(NotifyMessage);

        }

        public static void AddFunds(decimal Val, bool RequresNotify = false, string NotifyMessage = "")
        {
            cashbox.CurrentCash += Val;
            OnTransaction?.Invoke(Val, "");
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
            return (cashbox != null)? cashbox.CurrentCash.ToString() + " " + cashbox.Currency :
                "ошибка кассы";
        }

        public static void ClearCash()
        {
            cashbox = new Cashbox();
            cashbox.Transactions = new SerializableDictionary<string, decimal>();
            UpdateCash();
        }

        public static void SetUpMachineGroupPrices(int groupIndex, decimal multiplier)
        {

        }
    }
}
