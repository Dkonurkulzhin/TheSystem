using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Excel = Microsoft.Office.Interop.Excel;

namespace Overlord.Elements
{
    public class ExcelHandler
    {

        public ExcelHandler()
        {
            
        }

        public void Init()
        {
           

            // Earlier versions of C# require explicit casting.
            //Excel._Worksheet workSheet = (Excel.Worksheet)excelApp.ActiveSheet;

            // Establish column headings in cells A1 and B1.

            var row = 1;
        }

        public void CreateShiftReport(Cashbox cashbox)
        {
            var excelApp = new Excel.Application();
            // Make the object visible.
            excelApp.Visible = true;
            Excel._Workbook workBook = excelApp.Workbooks.Add();
           
            //excelApp.S
            // This example uses a single workSheet. 
            Excel._Worksheet workSheet = excelApp.ActiveSheet;
            workSheet.Cells[1, "A"] = DateTime.Now.Date.ToString();
            workSheet.Cells[2, "A"] = "Транзакция";
            workSheet.Cells[2, "B"] = "Сумма";
            workSheet.Cells[2, "D"] = "В кассе на конец смены:";
            workSheet.Cells[2, "E"] = cashbox.CurrentCash;
            int row = 3;
            foreach (string transactionName in cashbox.Transactions.Keys)
            {
                workSheet.Cells[row, "A"] = transactionName;
                workSheet.Cells[row, "B"] = cashbox.Transactions[transactionName];
                row++;
            }
            DateTime Now = DateTime.Now;
            string workBookName = Now.DayOfWeek.ToString() + "," + Now.Day.ToString() + "." + Now.Month.ToString()
                + "." + Now.Year.ToString();
            workBook.SaveAs(GlobalVars.ReportPath + "отчет-" + workBookName + ".xls");

        }

        
    }
}
