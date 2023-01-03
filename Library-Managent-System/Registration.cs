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
    public partial class Registration : Form
    {
        public Registration()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text.Length == 0)
            {
                MessageBox.Show("Enter Name");
                textBox1.Focus();
                return;
            }
            if (textBox2.Text.Length == 0)
            {
                MessageBox.Show("Enter UserName");
                textBox2.Focus();
                return;
            }
            if (textBox3.Text.Length == 0)
            {
                MessageBox.Show("Enter Email");
                textBox3.Focus();
                return;
            }
            if (textBox4.Text.Length == 0)
            {
                MessageBox.Show("Enter Password");
                textBox4.Focus();
                return;
            }
            if (textBox5.Text.Length == 0)
            {
                MessageBox.Show("Re-Enter Password");
                textBox5.Focus();
                return;
            }
            if (!textBox4.Text.Equals(textBox5.Text))
            {
                MessageBox.Show("Password not Matched");
                textBox4.Focus();
                return;
            }
            if(comboBox1.SelectedIndex==-1)
            {
                MessageBox.Show("Please Select User");
                comboBox1.Focus();
                return;
            }
            try
            {
                SqlConnection con = Connection.Connect();
                string sql = "insert into libuser  values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + comboBox1.Text + "')";
                SqlCommand command=new SqlCommand(sql, con);
                con.Open();
                command.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Registration Successful");
            }
            catch(Exception ex) { 
               MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new Form1().Show();
            this.Close();
        }
    }
}
