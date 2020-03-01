using System.Xml;
using Microsoft.Office.Tools.Ribbon;
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Excel;
using System.Data;
using Workbook = Microsoft.Office.Interop.Excel.Workbook;
using System.Reflection;
using System.IO;

namespace MNB_DL
{
    public partial class Ribbon1
    {
        private void Ribbon1_Load(object sender, RibbonUIEventArgs e)
        {

        }

        private void button1_Click(object sender, RibbonControlEventArgs e)
        {
            XmlDocument xd = new XmlDocument();
            xd.LoadXml(ThisAddIn.CallWebService()); //soap message
            XmlNode xn = xd.DocumentElement;
            string result = xn.InnerText; //you should give exact condition
            DataSet ds = new DataSet();
            ds.ReadXml(new StringReader(result));
            Range r = Globals.ThisAddIn.Application.Worksheets["Sheet1"].Range["A1", Missing.Value];
            Workbook w = Globals.ThisAddIn.Application.ActiveWorkbook;
            Excel.XmlMap map = w.XmlMaps.Add(ds.GetXmlSchema(), "MNBExchangeRates");
            w.XmlImportXml(ds.GetXml(), out map, true, r);
        }
    }
}
