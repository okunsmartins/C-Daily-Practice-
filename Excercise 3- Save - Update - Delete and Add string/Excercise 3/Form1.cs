using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Excercise_3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            txtPassword.PasswordChar = '£';
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string myConnection = "datasource = localhost; Port = 3306; username = root; password = Martins14$";
                MySqlConnection myconn = new MySqlConnection(myConnection);
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM database.csharptraining WHERE user_name ='"+ txtUsername.Text+"' AND password ='"+txtUsername.Text+"';", myconn);

                MySqlDataReader myReader;

                myconn.Open();
                myReader = cmd.ExecuteReader();
                int count = 0;
                while (myReader.Read())
                {
                    count = count + 1;
                }

                if (count == 1)
                {
                    MessageBox.Show("Username and password is correct");
                    this.Hide();
                    Form2 f2 = new Form2();
                    f2.ShowDialog();

                }

                else if (count > 1)
                {
                    MessageBox.Show("Duplicate Username and password... acess denied");

                }

                else
                {
                    MessageBox.Show("Duplicate Username and password in not correct ... please try again");

                }
                txtPassword.Text = "";
                txtUsername.Text = "";

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
