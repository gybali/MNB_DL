using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Tools.Ribbon;
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Tools.Excel;
using Microsoft.Office.Interop.Excel;

namespace MNB_DL
{
    public partial class Ribbon1
    {
        private void Ribbon1_Load(object sender, RibbonUIEventArgs e)
        {

        }

        private void button1_Click(object sender, RibbonControlEventArgs e)
        {
            Microsoft.Office.Tools.Excel.Worksheet worksheet = Globals.Factory.GetVstoObject(
            Globals.ThisAddIn.Application.ActiveWorkbook.Worksheets[1]);
            Excel.Range firstRow = worksheet.get_Range("A1");
            firstRow.EntireRow.Insert(Excel.XlInsertShiftDirection.xlShiftDown);
            Excel.Range newFirstRow = worksheet.get_Range("A1");
            ThisAddIn.MNBDownload();
        }
    }
}
