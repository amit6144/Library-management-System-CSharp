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
    public partial class IssueBook : Form
    {
        public IssueBook()
        {
            InitializeComponent();
        }
        //login
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = Connection.Connect();
                string sql = "insert into issuetable values('"+comboBox4.Text+"','"+comboBox1.Text+"','"+comboBox3.Text+"','"+comboBox2.Text +"')";
                SqlCommand command=new SqlCommand(sql, con);
                con.Open();
                command.ExecuteNonQuery();
                string sql1 = "update books set total=total-1 where bookname='"+comboBox1.Text+"'and Author='"+comboBox3.Text+"'";
                SqlCommand command1= new SqlCommand(sql1, con);
                command1.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Book has been isseud Successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //1
        private void button3_Click(object sender, EventArgs e)
        {
            List<string> list = new List<string>();

            try
            {
                SqlConnection sqlConnection = Connection.Connect();
                string sql = "select bookname from books";
                sqlConnection.Open();
                SqlCommand command = new SqlCommand(sql, sqlConnection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(reader.GetString(0));
                }
                sqlConnection.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            comboBox1.DataSource = list;
        }
        //2
        private void button4_Click(object sender, EventArgs e)
        {
            List<string> list = new List<string>();

            try
            {
                SqlConnection sqlConnection = Connection.Connect();
                string sql = "select Author from books where bookname='" + comboBox1.Text + "'";
                sqlConnection.Open();
                SqlCommand command = new SqlCommand(sql, sqlConnection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(reader.GetString(0));
                }
                sqlConnection.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            comboBox3.DataSource = list;
        }
        //3
        private void button1_Click(object sender, EventArgs e)
        {
            List<string> list = new List<string>();

            try
            {
                SqlConnection sqlConnection = Connection.Connect();
                string sql = "select ISBN from books where bookname='"+comboBox1.Text+"' and author='"+comboBox3.Text+"'";
                sqlConnection.Open();
                SqlCommand command = new SqlCommand(sql, sqlConnection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(reader.GetString(0));
                }
                sqlConnection.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            comboBox2.DataSource = list;
        }
        //4
        private void button5_Click(object sender, EventArgs e)
        {
            List<string> list = new List<string>();

            try
            {
                SqlConnection sqlConnection = Connection.Connect();
                string sql = "select name from libUser";
                sqlConnection.Open();
                SqlCommand command = new SqlCommand(sql, sqlConnection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(reader.GetString(0));
                }
                sqlConnection.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            comboBox4.DataSource = list;

        }
    }
}
