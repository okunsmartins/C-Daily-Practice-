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
            fill_listbox();
        }


        void fill_listbox()
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
                    listBox1.Items.Add(sName);

                }


            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }





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
            loadTable();
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
            string myConnection = "datasource = localhost; Port = 3306; username = root; password = Martins14$";
            string Query = "SELECT * FROM database.csharptraining WHERE name = '"+comboBox1.Text+ "';";

            MySqlConnection myconn = new MySqlConnection(myConnection);
            MySqlCommand cmd = new MySqlCommand(Query, myconn);

            MySqlDataReader myReader;

            try
            {
                myconn.Open();
                myReader = cmd.ExecuteReader();


                while (myReader.Read())
                {

                    string sEid = myReader.GetInt32("idcsharpTraining").ToString();
                    string sName = myReader.GetString("name");
                    string slastName = myReader.GetString("surname");
                    string sAge = myReader.GetInt32("age").ToString();
                    txtEid.Text = sEid;
                    txtFirstName.Text = sName;
                    txtLastName.Text = slastName;
                    txtAge.Text = sAge;

                }


            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string myConnection = "datasource = localhost; Port = 3306; username = root; password = Martins14$";
            string Query = "SELECT * FROM database.csharptraining WHERE name = '" + listBox1.Text + "';";

            MySqlConnection myconn = new MySqlConnection(myConnection);
            MySqlCommand cmd = new MySqlCommand(Query, myconn);

            MySqlDataReader myReader;

            try
            {
                myconn.Open();
                myReader = cmd.ExecuteReader();


                while (myReader.Read())
                {

                    string sEid = myReader.GetInt32("idcsharpTraining").ToString();
                    string sName = myReader.GetString("name");
                    string slastName = myReader.GetString("surname");
                    string sAge = myReader.GetInt32("age").ToString();
                    txtEid.Text = sEid;
                    txtFirstName.Text = sName;
                    txtLastName.Text = slastName;
                    txtAge.Text = sAge;

                }


            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        void loadTable()
        {
            string constring = "datasource = localhost; Port = 3306; username = root; password = Martins14$";
            MySqlConnection conDatabase = new MySqlConnection(constring);
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM database.csharptraining;", conDatabase);

            try
            {
                MySqlDataAdapter sda = new MySqlDataAdapter();
                sda.SelectCommand = cmd;
                DataTable dbdtable = new DataTable();
                sda.Fill(dbdtable);
                BindingSource bSource = new BindingSource();

                bSource.DataSource = dbdtable;
                dataGridView1.DataSource = bSource;
                sda.Update(dbdtable);

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

        }


        private void btnLoadTable_Click(object sender, EventArgs e)
        {
            loadTable();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /* this.chart1.Series["Age"].Points.AddXY("Max",30);
             chart1.Series["Scores"].Points.AddXY("Max", 91);

             this.chart1.Series["Age"].Points.AddXY("Carl", 10);
             chart1.Series["Scores"].Points.AddXY("Carl", 61);

             this.chart1.Series["Age"].Points.AddXY("Mark", 50);
             chart1.Series["Scores"].Points.AddXY("Mark", 81);

             this.chart1.Series["Age"].Points.AddXY("Michael", 100);
             chart1.Series["Scores"].Points.AddXY("Michael", 71);
             */


            string myConnection = "datasource = localhost; Port = 3306; username = root; password = Martins14$";
            string Query = "SELECT * FROM database.csharptraining  ";

            MySqlConnection myconn = new MySqlConnection(myConnection);
            MySqlCommand cmd = new MySqlCommand(Query, myconn);

            MySqlDataReader myReader;

            try
            {
                myconn.Open();
                myReader = cmd.ExecuteReader();


                while (myReader.Read())
                {

                    this.chart1.Series["Age"].Points.AddXY(myReader.GetString("name"), myReader.GetInt32("age"));
                        

                }


            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }
    }
}
