using System.Data;
using System.Data.SqlClient;

namespace Library_Managent_System
{
    public partial class Form1 : Form
    {   
        public string check;
        public Form1()
        {
            this.MinimizeBox=false;
            this.MaximizeBox=false;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;

            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            check = radioButton1.Text;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            check = radioButton2.Text;
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length==0||textBox2.Text.Length==0) {
                MessageBox.Show("Enter User Name and password");
            }
            if(radioButton1.Checked||radioButton2.Checked) {
                SqlConnection connection=Connection.Connect();
                try
                {
                    connection.Open();
                    string q = "select * from libuser where username='"+textBox1.Text+"' and password='"+textBox2.Text+"' and usertype='"+check+"'";
                    SqlCommand sqlCommand= new SqlCommand(q, connection);
                    SqlDataReader reader=sqlCommand.ExecuteReader();
                   
                    if (reader.Read())
                    {
                        if(check=="User")
                        {
                            MessageBox.Show("Logged in as User");
                            UserDash user=new UserDash(reader.GetString(1));
                            user.Size=  new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
                            user.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Logged in as Admin");//
                          AdminDash admin = new AdminDash();
                           admin.Size = new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
                          admin.Show();
                            
                          this.Hide();
                        }
                    } 
                    else
                    {
                        MessageBox.Show("User not found");
                    }
                    connection.Close();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Please Select UserType");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new Registration().ShowDialog();
        }
    }
}