using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace MNB_DL
{
    public partial class Log : Form
    {
        DataSet ds;
        OleDbDataAdapter da;
        public Log()
        {
            InitializeComponent();

        }
        OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\balint.gyokeres\\source\\repos\\MNB_DL\\MNB_DL\\MNB_Log.accdb");


        public void Log_Load(object sender, EventArgs e)
        {
            ds = new DataSet();
            da = new OleDbDataAdapter("Select * from MNBLog", conn);
            OleDbCommandBuilder cmdBldr = new OleDbCommandBuilder(da);
            da.Fill(ds, "MNBLog");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "MNBLog";
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void logSave_Click(object sender, EventArgs e)
        {
            da.Update(ds, "MNBLog");
            conn.Close();
            Hide();
        }

        private void logCancel_Click(object sender, EventArgs e)
        {
            conn.Close();
            Hide();
        }
    }
}
