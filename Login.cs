using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;

namespace MainApplication
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();

            String dbserver = System.Configuration.ConfigurationManager.AppSettings["DBSERVER"].ToString();
            String dbname = System.Configuration.ConfigurationManager.AppSettings["DBNAME"].ToString();

            txtCurrentServer.Text = "Server:" + dbserver + "\\" + dbname;
            txtCurrentServer.Enabled = false;

            if (IsBeingDebugged())
                    System.Environment.Exit(1);

            if(isServerConfigured())
                MessageBox.Show("This application is usable only after configuring the server");
            else
                btnConfigureServer.Enabled = false;
        }

        private bool isServerConfigured()
        {
            return false;
        }

        private bool IsBeingDebugged()
        {
            if (System.Diagnostics.Debugger.IsAttached)
                return true;
            else
                return false;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            String username = txtLoginUsername.Text.Trim();
            String password = txtLoginPassword.Text.Trim();
            if (username == string.Empty || password == string.Empty)
            {
                MessageBox.Show("Please enter all the fields!");
                return;
            }

            DBAccessClass db = new DBAccessClass();
            db.OpenConnection();

           SqlDataReader data = db.CheckCredentials(username,password);
           if (data.HasRows)
           {
               String user;
               String pass;
               String email;
               int isAdmin=0;

               while (data.Read())
               {
                   user = data.GetString(1);
                   pass = data.GetString(2);
                   email = data.GetString(3);
                   isAdmin = (int) data.GetValue(4);

                   if (user != "admin")
                   {
                       Microsoft.Win32.RegistryKey key;
                       key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("prog8290");
                       key.SetValue("username", user);
                       key.SetValue("password", pass);
                       key.SetValue("email", email);
                       key.SetValue("isLoggedIn", "true");
                       key.Close();
                   }
               }
               txtLoginUsername.Text = "";
               txtLoginPassword.Text = "";

               if(isAdmin != 1)
               {
                   this.Close();
                   Main main = new Main();
                   main.ShowDialog();
                   Application.Exit();
               }
               else
               {                
                   this.Hide();
                   Admin admin = new Admin();
                   admin.ShowDialog();
                   Application.Exit();
               }
                return;   
           }
           else
           {
               MessageBox.Show("Invalid Login");
               txtLoginUsername.Text = "";
               txtLoginPassword.Text = "";
           }
            db.CloseConnection();
        }

        private void btnRegisterUser_Click(object sender, EventArgs e)
        {
            this.Hide();
            Register register = new Register();
            register.ShowDialog();
            Application.Exit();

        }

        private void btnConfigureServer_Click(object sender, EventArgs e)
        {
            string loggedInUser, loggedInValue;
            Microsoft.Win32.RegistryKey key;
            key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("prog8290");

            loggedInUser = (string)key.GetValue("username", "null");
            loggedInValue = (string)key.GetValue("isLoggedIn", "null");

            if (loggedInUser == "admin" && loggedInValue == "true")
            {
                String oldSetting = txtCurrentServer.Text;
                var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

                //update dbserver
                var entry1 = config.AppSettings.Settings["DBSERVER"];
                if (entry1 == null)
                    config.AppSettings.Settings.Add("DBSERVER", oldSetting);
                else
                    config.AppSettings.Settings["DBSERVER"].Value = oldSetting;

                //update ftp server
                var entry2 = config.AppSettings.Settings["FTPSERVER"];
                if (entry2 == null)
                    config.AppSettings.Settings.Add("FTPSERVER", oldSetting);
                else
                    config.AppSettings.Settings["FTPSERVER"].Value = oldSetting;

                config.Save(ConfigurationSaveMode.Modified);
                txtCurrentServer.Text = "";
                MessageBox.Show("Server successfully configured");
            }
            key.Close();
        }
    }
}
