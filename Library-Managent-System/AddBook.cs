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
    public partial class AddBook : Form
    {
        public AddBook()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection connection=Connection.Connect();
                string Sql = "insert into books values('"+textBox1.Text+"','"+textBox2.Text+"','"+textBox3.Text+"','"+dateTimePicker1.Text+"','"+textBox4.Text+"','"+richTextBox1.Text+"',"+textBox5.Text+")";
                SqlCommand command=new SqlCommand(Sql,connection);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Book Added Successfully");
                this.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
           (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > 0))
            {
                e.Handled = true;
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
           (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') >0))
            {
                e.Handled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection connection = Connection.Connect();
                string sql = "update books set total=total+"+textBox6.Text+" where bookname='"+comboBox1.Text+"'  and Author='"+comboBox3.Text+"'";
                MessageBox.Show(sql);
                SqlCommand commmand = new SqlCommand(sql, connection);
                connection.Open();

                commmand.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Books added Successfully");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

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


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            comboBox1.DataSource = list;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            List<string> list = new List<string>();

            try
            {
                SqlConnection sqlConnection = Connection.Connect();
                string sql = "select Author from books where bookname='"+comboBox1.Text+"'";
                sqlConnection.Open();
                SqlCommand command = new SqlCommand(sql, sqlConnection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(reader.GetString(0));
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            comboBox3.DataSource = list;
        }
    }
}
