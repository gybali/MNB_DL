using System.Xml;
using Microsoft.Office.Tools.Ribbon;
using Excel = Microsoft.Office.Interop.Excel;
using System.Data;
using System.IO;
using System;
using System.Data.OleDb;
using System.Globalization;

namespace MNB_DL
{
    public partial class Ribbon1
    {
        private void Ribbon1_Load(object sender, RibbonUIEventArgs e)
        {
        }

        private void Button1_Click(object sender, RibbonControlEventArgs e)
        {
            CreateDatabase newDB = new CreateDatabase("C:\\Users\\Public\\Documents\\MNB_Log.accdb");
            newDB.Execute();
            newDB.CreateTable();
            string strDSN = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\Public\\Documents\\MNB_Log.accdb";
            string userName = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            string currDate = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss");
            OleDbConnection myConn = new OleDbConnection(strDSN);

            myConn.Open();

            string dbCommand = "INSERT INTO MNBLog ([userName], [time], [description]) VALUES(@userName,@time,@description)";
            OleDbCommand myInsert = new OleDbCommand(dbCommand, myConn);
            myInsert.Parameters.AddWithValue("@userName", userName);
            myInsert.Parameters.AddWithValue("@time", currDate);
            myInsert.Parameters.AddWithValue("@description", DBNull.Value);
            myInsert.ExecuteNonQuery();

            myConn.Close();
            
            XmlDocument xd = new XmlDocument();
            xd.LoadXml(ThisAddIn.CallWebService());
            XmlNode xn = xd.DocumentElement;
            string result = xn.InnerText;
            DataSet ds = new DataSet();

            XmlDocument currDoc = new XmlDocument();
            currDoc.LoadXml(ThisAddIn.CallUnitsWebService());
            XmlNode currXn = currDoc.DocumentElement;
            string currResult = currXn.InnerText;
            DataSet currDs = new DataSet();

            currDs.ReadXml(new StringReader(currResult));
            ds.ReadXml(new StringReader(result));
            DataTable unitTable = currDs.Tables[1];
            DataTable dateTable = ds.Tables[0];
            DataTable currencyTable = ds.Tables[1];
            Excel.Worksheet currSheet = Globals.ThisAddIn.Application.ActiveSheet;
            currSheet.Cells[1, "A"].Value2 = "Dátum/ISO";
            currSheet.Cells[2, "A"].Value2 = "Egység";
            int k = 0;
            for (int i = dateTable.Rows.Count - 1; i >= 0 ;i--)
            {
                currSheet.Cells[k+3, "A"].Value2 = dateTable.Rows[i][1];
                k++;
            }
            for (int i = 0; i < unitTable.Rows.Count; i++)
            {
                currSheet.Cells[1, i + 2].Value2 = unitTable.Rows[i][0];
                currSheet.Cells[2, i + 2].Value2 = unitTable.Rows[i][1];
            }
            for (int i = 0; i < unitTable.Rows.Count; i++)
            {
                for (int j = 0; j < dateTable.Rows.Count ; j++)
                {
                    for (int z = 0; z < currencyTable.Rows.Count ; z++)
                    {
                        if (currencyTable.Rows[z][1].ToString() == unitTable.Rows[i][0].ToString() && currencyTable.Rows[z][3].ToString() == dateTable.Rows[j][0].ToString())
                        {
                            currSheet.Cells[i+2][dateTable.Rows.Count - j+2].Value2 = float.Parse(currencyTable.Rows[z][2].ToString());
                        }
                    }

                }
            }
        }

        private void Log_Click(object sender, RibbonControlEventArgs e)
        {
            Log wndw = new Log();
            wndw.Show();
        }
    }
}
