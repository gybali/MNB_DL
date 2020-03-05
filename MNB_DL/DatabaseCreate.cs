using System;
using System.Data.OleDb;
using System.IO;
using System.Runtime.InteropServices;
using Microsoft.Office.Interop.Access;

namespace MNB_DL
{
    public class CreateDatabase
    {
        private readonly string _fileName;

        private readonly OleDbConnectionStringBuilder _builder =
            new OleDbConnectionStringBuilder { Provider = "Microsoft.ACE.OLEDB.12.0" };

        /// <summary>
        /// Create database, one table and insert one record
        /// </summary>
        /// <returns></returns>
        public bool Execute()
        {

            if (File.Exists(_fileName))
            {
                return false;
            }

            if (Create())
            {
                return CreateTable();
            }
            else
            {
                return false;
            }

        }
        /// <summary>
        /// Create database
        /// </summary>
        /// <returns></returns>
        public bool Create()
        {

            try
            {
                Application app = new Application();

                app.NewCurrentDatabase(
                    _fileName,
                    AcNewDatabaseFormat.acNewDatabaseFormatAccess2007,
                    Type.Missing);

                app.CloseCurrentDatabase();
                Marshal.FinalReleaseComObject(app);
                app = null;

                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
        /// <summary>
        /// Create table, insert one record
        /// </summary>
        /// <returns></returns>
        public bool CreateTable()
        {

            var tableName = "MNBLog";

            using (var cn = new OleDbConnection(_builder.ConnectionString))
            {
                using (var cmd = new OleDbCommand("", cn))
                {
                    cmd.CommandText = $"CREATE TABLE {tableName} ([Id] COUNTER PRIMARY KEY, [userName] TEXT(25),[time] DATETIME,[description] TEXT(255))";

                    try
                    {
                        cn.Open();
                        // create table
                        cmd.ExecuteNonQuery();
                        cn.Close();
                        return true;
                    }
                    catch (Exception)
                    {
                        return false;
                    }

                }
            }
        }

        public CreateDatabase(string fileName)
        {
            _fileName = fileName;
            _builder.DataSource = fileName;
        }
    }
}
