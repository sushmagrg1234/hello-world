using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;


namespace MainApplication
{
    public partial class Main : Form
    {
        DataTable returnvalue;

        public Main()
        {
            InitializeComponent();
            string loggedInUser,loggedInValue;               
            Microsoft.Win32.RegistryKey key;
            key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("prog8290");          
            loggedInUser= (string) key.GetValue("username", "null");
            loggedInValue =(string) key.GetValue("isLoggedIn", "null");

            if (loggedInUser == "null" || loggedInValue == "false")
            {
                this.Hide();
                Login login = new Login();
                login.ShowDialog();
                this.Close();
                Application.Exit();
            }
            else
            {
                lblLoggedInUserName.Text = loggedInUser;
            }
 
            key.Close();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Microsoft.Win32.RegistryKey key;
            key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("prog8290");

            key.SetValue("username", "null");
            key.SetValue("password", "null");
            key.SetValue("email", "null");
            key.SetValue("isLoggedIn", "false");
            key.Close();

            this.Hide();
            Login login = new Login();
            login.ShowDialog();

            return;
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            Microsoft.Win32.RegistryKey key;
            key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("prog8290");

            String username = (string)key.GetValue("username",null);
            String email = (string)key.GetValue("email", null);
            MessageBox.Show("Username: "+username+"\n"+"Email ID: "+email);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddExpenses add = new AddExpenses();
            add.ShowDialog();
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            DBAccessClass db = new DBAccessClass();
            db.OpenConnection();
           
            Microsoft.Win32.RegistryKey key;
            key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("prog8290");
            String email = (string)key.GetValue("email", "null");
            
            returnvalue = db.ViewExpenses(email);
            
            dataGridView1.DataSource = returnvalue;    
           
            db.CloseConnection();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Do you want to clear all your expenses?", "Caution", MessageBoxButtons.YesNo);

            if (dialog == DialogResult.Yes)
            {
                DBAccessClass db = new DBAccessClass();
                db.OpenConnection();

                Microsoft.Win32.RegistryKey key;
                key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("prog8290");
                String email = (string)key.GetValue("email", "null");

                if(db.ClearExpenses(email))
                {
                    MessageBox.Show("Success");
                }
                else
                {
                    MessageBox.Show("Failed");
                }

                db.CloseConnection();
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            try
            {
                string pathtodownload = Environment.GetEnvironmentVariable("USERPROFILE") + @"\" + "Downloads";
                returnvalue.WriteToCsvFile(pathtodownload + "\\"+"expenses.csv");

                MessageBox.Show("Success!  Check your Downloads folder");
            }
            catch(Exception ex)
            {
               MessageBox.Show("Failed with error: " + ex.Message);
            }
        }
    }
}
