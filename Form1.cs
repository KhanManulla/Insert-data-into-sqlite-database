using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using System.IO;



namespace schoolmgmt
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


       

    private void btnsave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtage.Text) || string.IsNullOrWhiteSpace(txthobby.Text) || string.IsNullOrWhiteSpace(txtname.Text) || string.IsNullOrWhiteSpace(txtrollnumber.Text) || string.IsNullOrWhiteSpace(txtsurname.Text))
            {
               // MessageBox.Show("Please Fill All Details Required");
                MessageBox.Show("All Field Required", "Text Box Empty", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    Classdatabaseconnection insert = new Classdatabaseconnection();
                    insert.insertstudent(txtname.Text, txtsurname.Text, txtage.Text, txtrollnumber.Text, txthobby.Text);
                    TextBoxClear();
                    showdatasubmit();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //call Database to create folder on c and create database;
            Classdatabaseconnection ccn = new Classdatabaseconnection();
            ccn.CreateDatabaseAndTable();
        }

        private void btnshow_Click(object sender, EventArgs e)
        {
            showdatasubmit();

        }

        public void showdatasubmit()
        {
            try
            {
                Classdatabaseconnection cdd = new Classdatabaseconnection();
                SQLiteConnection con = new SQLiteConnection(@"Data Source=" + cdd.cspath());
                con.Open();
                //commond object
                SQLiteCommand comm = new SQLiteCommand("Select * From student", con);

                DataTable dt = new DataTable();
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(comm);
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        public void TextBoxClear()
        {
            txtname.Text = "";
            txtsurname.Text = "";
            txtage.Text = "";
            txthobby.Text = "";
            txtrollnumber.Text = "";
        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            TextBoxClear();
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtname_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }
    }
}
