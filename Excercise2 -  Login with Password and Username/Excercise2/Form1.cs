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

namespace Excercise2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            txtPassword.PasswordChar ='*';
            txtPassword.MaxLength = 10;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try {
                string myConnection = "datasource = localhost; Port = 3306 ;username = root; password = Martins14$";
                MySqlConnection myconn = new MySqlConnection(myConnection);
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM database.csharptraining WHERE user_name ='" + this.txtUsername.Text + "' and password  = '" + this.txtPassword.Text + "';", myconn);

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
                }

                else if (count > 1)
                {

                    MessageBox.Show("Duplicate Username and Password ... Access denied");
                }

                else
                {
                    MessageBox.Show("Username and password is not correct.. please try again");

                }
                txtPassword.Text = "";
                txtUsername.Text = "";
            }

            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
