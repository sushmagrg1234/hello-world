using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.IO;

namespace MainApplication
{
    public partial class Admin : Form
    {
        String ftpserver = System.Configuration.ConfigurationManager.AppSettings["FTPSERVER"].ToString();
        string pathtodownload = null;
        String time;
        public Admin()
        {
            InitializeComponent();
        }

        private void btnFtp_Click(object sender, EventArgs e)
        {
            lblFtpStatusMessage.Text = "Please wait while uploading your data";

            Thread backgroundThread = new Thread(new ThreadStart(() =>
                {
                    DBAccessClass db = new DBAccessClass();
                    db.OpenConnection();

                    DataTable dataTable = db.getExpensesOfAll();
    
                    pathtodownload = Path.GetTempPath();
                    pathtodownload = pathtodownload + "ftp-";
                    dataTable.WriteToCsvFile(pathtodownload+"admin.csv");
                    string ufilename = pathtodownload + "admin.csv";
                    db.CloseConnection();

                    Upload("ftp://"+ftpserver, "asn4", "ftpP@ssw0rd", @pathtodownload + "admin.csv");
                }));
            backgroundThread.Start();

            lblFtpStatusMessage.Text = "";
        }
        private static void Upload(string ftpServer, string userName, string password, string filename)
        {
            using (System.Net.WebClient client = new System.Net.WebClient())
            {
                try
                {
                    client.Credentials = new System.Net.NetworkCredential(userName, password);
                    client.UploadFile(ftpServer + "/" + new FileInfo(filename).Name, "STOR", filename);

                    MessageBox.Show("Success");
                    return;
                }
                catch(Exception e){
                    MessageBox.Show("FTP upload failed with message: " + e.Message);
                }
            }
        }
    }
}
