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
    public partial class AddExpenses : Form
    {
        public AddExpenses()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("prog8290");

            String email = (string)key.GetValue("email", "null");

            String expenseDate = textDate.Text.Trim();
            String expenseItem = textItem.Text.Trim();
            String expensePrice = textPrice.Text.Trim();
            DateTime now = DateTime.Now;
            String time = now.ToString("T");
    
            if (expenseDate== string.Empty || expenseItem == string.Empty ||expensePrice== string.Empty || email == string.Empty || time == string.Empty)
            {
                MessageBox.Show("Please enter all the fields!");
                return;
            }
            else
            {
                    DBAccessClass db = new DBAccessClass();
                    db.OpenConnection();

                    if(db.AddExpenses(expenseDate,expenseItem,expensePrice,email,time))
                    {
                        textDate.Text = "";
                        textItem.Text = "";
                        textPrice.Text="";
                        time = "";                  
                        MessageBox.Show("Expense saved succesfully");
                    }
                    else
                        MessageBox.Show("Failed");
                    
                    db.CloseConnection();
                }
            }
       
        public  string Dat { get; set; }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
    

