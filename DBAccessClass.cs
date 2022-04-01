
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Configuration;
    using System.Security.Cryptography;
    using System.Data.SqlClient;
    using System.Data;

public class DBAccessClass
{
    String decryptedDBPassword;
    SqlConnection conn;


    //Function to Decrypt DB Password

    public String decryptPassword()
    {
        String dbpassword = System.Configuration.ConfigurationManager.AppSettings["DBPASSWORD"].ToString();
        String key = System.Configuration.ConfigurationManager.AppSettings["AESKEY"].ToString();
        String IV = System.Configuration.ConfigurationManager.AppSettings["IV"].ToString();

        byte[] encryptedBytes = Convert.FromBase64String(dbpassword);

        AesCryptoServiceProvider aes = new AesCryptoServiceProvider();

        aes.BlockSize = 128;
        aes.KeySize = 256;
        aes.Key = System.Text.ASCIIEncoding.ASCII.GetBytes(key);
        aes.IV = System.Text.ASCIIEncoding.ASCII.GetBytes(IV);
        aes.Padding = PaddingMode.PKCS7;
        aes.Mode = CipherMode.CBC;
        ICryptoTransform crypto = aes.CreateDecryptor(aes.Key, aes.IV);
        byte[] decryptedbytes = crypto.TransformFinalBlock(encryptedBytes, 0, encryptedBytes.Length);
        decryptedDBPassword = System.Text.ASCIIEncoding.ASCII.GetString(decryptedbytes);


        Console.WriteLine(decryptedDBPassword);

        return decryptedDBPassword;

    }

    // open connection

    public void OpenConnection()
    {

        String dbserver = System.Configuration.ConfigurationManager.AppSettings["DBSERVER"].ToString();
        String dbname = System.Configuration.ConfigurationManager.AppSettings["DBNAME"].ToString();
        String dbusername = System.Configuration.ConfigurationManager.AppSettings["DBUSERNAME"].ToString();

        String dbpassword = decryptPassword();
        String connectionString = "server=" + dbserver + ";Initial Catalog=" + dbname + ";User Id=" + dbusername + ";Password=" + dbpassword + ";connection timeout=30; max pool size=1000;Integrated Security=false";

        conn = new SqlConnection();
        conn.ConnectionString = connectionString;
        conn.Open();
    }

    // user login
    public SqlDataReader CheckCredentials(String clientusername, String clientpassword)
    {
        String username = clientusername;
        String password = clientpassword;
        String sqlcmd = "SELECT * FROM users where username='" + username + "' and password='" + password + "'";

        SqlCommand cmd = new SqlCommand(sqlcmd, conn);
        SqlDataReader dataReaderResults = cmd.ExecuteReader();

        return dataReaderResults;
    }

    public bool RegisterUser(String clientusername, String clientpassword, String clientemailid)
    {

        bool success = false;
        int isAdmin = 0;
        string sqlquery = "insert into users values('" + clientusername + "','" + clientpassword + "','" + clientemailid + "','" + isAdmin + "')";
        SqlCommand cmd = new SqlCommand(sqlquery, conn);

        try
        {
            cmd.ExecuteNonQuery();
            success = true;
        }
        catch (Exception e)
        {
            success = false;
        }

        return success;
    }
    public bool AddExpenses(String addDt, String additem, String addprice, String addemail, String addTime)
    {

        bool success = false;
        string sqlquery = "insert into expenses values('" + addemail + "','" + additem + "','" + addprice + "','" + addDt + "','" + addTime + "')";
        SqlCommand cmd = new SqlCommand(sqlquery, conn);

        try
        {
            cmd.ExecuteNonQuery();
            success = true;
        }
        catch (Exception e)
        {
            success = false;
        }

        return success;
    }

    public DataTable ViewExpenses(String emailid)
    {
        SqlCommand objCommand = new SqlCommand("select item, price, date,time from expenses where email='" + emailid + "'", conn);
        SqlDataReader dataReaderResult = objCommand.ExecuteReader();
        DataTable dataTable = new DataTable();
        dataTable.Load(dataReaderResult);

        return dataTable;
    }

    public DataTable getExpensesOfAll()
    {
        SqlCommand objCommand = new SqlCommand("select * from expenses", conn);
        SqlDataReader dataTableResults = objCommand.ExecuteReader();
        DataTable dataTable = new DataTable();
        dataTable.Load(dataTableResults);

        return dataTable;
    }


    public bool ClearExpenses(String emailid)
    {
        bool success = false;
        String sqlcmd = "DELETE FROM expenses where email='" + emailid + "'";
        SqlCommand cmd = new SqlCommand(sqlcmd, conn);

        try
        {
            cmd.ExecuteNonQuery();
            success = true;
        }
        catch (Exception e)
        {
            success = false;
        }

        return success;
    }

    public void CloseConnection()
    {
        conn.Close();
    }

}

