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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            fillCombo();
        }

        void fillCombo()
        {

            string myConnection = "datasource = localhost; Port = 3306; username = root; password = Martins14$";
            string Query = "SELECT * FROM database.csharptraining";

            MySqlConnection myconn = new MySqlConnection(myConnection);
            MySqlCommand cmd = new MySqlCommand(Query, myconn);

            MySqlDataReader myReader;

            try
            {
                myconn.Open();
                myReader = cmd.ExecuteReader();
                

                while (myReader.Read())
                {

                    string sName = myReader.GetString("name");
                    comboBox1.Items.Add(sName);
                
                }


            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }


        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string myConnection = "datasource = localhost; Port = 3306; username = root; password = Martins14$";
            string Query = "INSERT INTO database.csharptraining (idcsharpTraining, name, surname, age ) VALUES ('"+txtEid.Text+"','"+txtFirstName.Text+"','"+txtLastName.Text+"', '"+txtAge.Text+"'); ";

            MySqlConnection myconn = new MySqlConnection(myConnection);
            MySqlCommand cmd = new MySqlCommand(Query, myconn);

            MySqlDataReader myReader;

            try
            {
                myconn.Open();
                myReader = cmd.ExecuteReader();
                MessageBox.Show("Saved");

                while (myReader.Read())
                {

                }


            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

            string myConnection = "datasource = localhost; Port = 3306; username = root; password = Martins14$";
            string Query = "UPDATE database.csharptraining SET idcsharpTraining = '" + txtEid.Text + "', name = '" + txtFirstName.Text + "',  surname = '" + txtLastName.Text + "', age = '" + txtAge.Text + "' WHERE idcsharpTraining = '" + txtEid.Text + "' ";

            MySqlConnection myconn = new MySqlConnection(myConnection);
            MySqlCommand cmd = new MySqlCommand(Query, myconn);

            MySqlDataReader myReader;

            try
            {
                myconn.Open();
                myReader = cmd.ExecuteReader();
                MessageBox.Show("Updated");

                while (myReader.Read())
                {

                }


            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string myConnection = "datasource = localhost; Port = 3306; username = root; password = Martins14$";
            string Query = "Delete From database.csharptraining WHERE idcsharpTraining = '" + txtEid.Text + "'";         MySqlConnection myconn = new MySqlConnection(myConnection);
            MySqlCommand cmd = new MySqlCommand(Query, myconn);

            MySqlDataReader myReader;

            try
            {
                myconn.Open();
                myReader = cmd.ExecuteReader();
                MessageBox.Show("Deleted");

                while (myReader.Read())
                {

                }


            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void btnAddString_Click(object sender, EventArgs e)
        {
            string namestr = txtFirstName.Text;
            comboBox1.Items.Add(namestr);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtEid.Text = comboBox1.Text;
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
