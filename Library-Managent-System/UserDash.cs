using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library_Managent_System
{
    public partial class UserDash : Form
    {
        public UserDash(string username)
        {
            InitializeComponent();
            try
            {
                SqlConnection connection = Connection.Connect();
                string sql = "select BookName,ISBN,Author from issuetable where issuedby=(select top 1 name from libuser where username='"+username+"')";
                SqlDataAdapter dataAdapter= new SqlDataAdapter(sql,connection);
                DataSet ds= new DataSet();
                connection.Open();
                dataAdapter.Fill(ds,"Books");
                connection.Close();
                dataGridView1.DataSource=ds;
                dataGridView1.DataMember = "Books";
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dataGridView1.Columns[dataGridView1.ColumnCount - 3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView1.Columns[dataGridView1.ColumnCount - 2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView1.Columns[dataGridView1.ColumnCount - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void UserDash_Load(object sender, EventArgs e)
        {

        }
    }
}
