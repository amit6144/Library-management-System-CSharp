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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Library_Managent_System
{
    public partial class Return_Book : Form
    {
        public Return_Book()
        {
            InitializeComponent();
        }
        //1
        private void button3_Click(object sender, EventArgs e)
        {
            List<string> list = new List<string>();

            try
            {
                SqlConnection sqlConnection = Connection.Connect();
                string sql = "select distinct(bookname) from issuetable";
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
        private void button5_Click(object sender, EventArgs e)
        {
            List<string> list = new List<string>();

            try
            {
                SqlConnection sqlConnection = Connection.Connect();
                string sql = "select issuedby from issuetable where bookname='"+comboBox1.Text+"'";
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

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = Connection.Connect();
                string sql = "delete from issuetable where bookname='"+comboBox1.Text+"' and issuedby='"+comboBox4.Text+"'";
                SqlCommand command = new SqlCommand(sql, con);
                con.Open();
                command.ExecuteNonQuery();
                string sql1 = "update books set total=total+1 where bookname='" + comboBox1.Text + "'";
                SqlCommand command1 = new SqlCommand(sql1, con);
                command1.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Book has been Returned Successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
