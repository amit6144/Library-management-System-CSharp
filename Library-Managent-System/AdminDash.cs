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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Library_Managent_System
{
    public partial class AdminDash : Form
    {
        public  void fill1()
        {
            try
            {
                // fill Book table
                SqlConnection connection = Connection.Connect();
                string sql = "select * from books";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(sql, connection);
                DataSet ds = new DataSet();
                connection.Open();
                dataAdapter.Fill(ds, "Books");
                connection.Close();
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "Books";
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dataGridView1.Columns[dataGridView1.ColumnCount - 3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView1.Columns[dataGridView1.ColumnCount - 2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView1.Columns[dataGridView1.ColumnCount - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public  void fill2()
        {
            try
            {
                SqlConnection connection = Connection.Connect();
                string sql = "select * from Issuetable ";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(sql, connection);
                DataSet ds = new DataSet();
                connection.Open();
                dataAdapter.Fill(ds, "Books");
                connection.Close();
                dataGridView2.DataSource = ds;
                dataGridView2.DataMember = "Books";
                dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dataGridView2.Columns[dataGridView2.ColumnCount - 3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView2.Columns[dataGridView2.ColumnCount - 2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView2.Columns[dataGridView2.ColumnCount - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public AdminDash()
        {
            InitializeComponent();
            fill1();
            fill2();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new AddBook().ShowDialog();
            fill1();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new IssueBook().ShowDialog(); fill2();
            fill1();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new Return_Book().ShowDialog();fill1();
            fill2();

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void AdminDash_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            new Form1().Show();
            this.Hide();

        }
    }
}
