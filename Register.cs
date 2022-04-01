using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainApplication
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }


		private void btnRegisterCancel_Click(object sender, EventArgs e)
		{
			base.Hide();
			Login login = new Login();
			login.ShowDialog();
		}

		private void btnRegister_Click(object sender, EventArgs e)
		{
			string username = this.txtRegisterUsername.Text.Trim();
			string password = this.txtRegisterPassword.Text.Trim();
			string confirmpassword = this.txtRegisterConfirmPassword.Text.Trim();
			string email = this.txtRegisterEmail.Text.Trim();
			bool flag = username == string.Empty || password == string.Empty || confirmpassword == string.Empty || email == string.Empty;
			if (flag)
			{
				MessageBox.Show("Please enter all the fields!");
			}
			else
			{
				bool flag2 = password != confirmpassword;
				if (flag2)
				{
					MessageBox.Show("Passwords do not match");
				}
				else
				{
					DBAccessClass db = new DBAccessClass();
					db.OpenConnection();
					bool flag3 = db.RegisterUser(username, password, email);
					if (flag3)
					{
						this.txtRegisterUsername.Text = "";
						this.txtRegisterPassword.Text = "";
						this.txtRegisterConfirmPassword.Text = "";
						this.txtRegisterEmail.Text = "";
						MessageBox.Show("Registration Success");
					}
					else
						MessageBox.Show("Registration Failed");

					db.CloseConnection();
				}
			}
		}
	}
}
