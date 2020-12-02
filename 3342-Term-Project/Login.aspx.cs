using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilities;
using System.Security.Cryptography;
using System.Net;
using System.Runtime.Serialization.Formatters.Binary;       //needed for BinaryFormatter


using System.IO;                      
using System.Text;
namespace _3342_Term_Project
{
    public partial class Login : System.Web.UI.Page
    {
        private Byte[] key = { 250, 101, 18, 76, 45, 135, 207, 118, 4, 171, 3, 168, 202, 241, 37, 199 };

        private Byte[] vector = { 146, 64, 191, 111, 23, 3, 113, 119, 231, 121, 252, 112, 79, 32, 114, 156 };
        protected void Page_Load(object sender, EventArgs e)
        {
            Error.Text = "";
            if (!IsPostBack)
            {

                if (Request.Cookies["Member"] != null)
                {
                    txtMemberEmail.Text = Request.Cookies["Member"]["MemberEmail"];
                    cboxRemeberMe.Checked = true;

                    HttpCookie myCookie = Request.Cookies["Login"];
                    txtMemberEmail.Text = myCookie["Email"];
                    String encryptedPassword = myCookie.Values["Password"];
                    Byte[] encryptedPasswordBytes = Convert.FromBase64String(encryptedPassword);
                    Byte[] textBytes;
                    String plainTextPassword;

                    UTF8Encoding encoder = new UTF8Encoding();

                    RijndaelManaged rmEncryption = new RijndaelManaged();
                    MemoryStream myMemoryStream = new MemoryStream();
                    CryptoStream myDecryptionStream = new CryptoStream(myMemoryStream, rmEncryption.CreateDecryptor(key, vector), CryptoStreamMode.Write);

                    // Use the crypto stream to perform the decryption on the encrypted data in the byte array.
                    myDecryptionStream.Write(encryptedPasswordBytes, 0, encryptedPasswordBytes.Length);
                    myDecryptionStream.FlushFinalBlock();


                    // Retrieve the decrypted data from the memory stream, and write it to a separate byte array.
                    myMemoryStream.Position = 0;
                    textBytes = new Byte[myMemoryStream.Length];
                    myMemoryStream.Read(textBytes, 0, textBytes.Length);

                    // Close all the streams.
                    myDecryptionStream.Close();
                    myMemoryStream.Close();

                    // Convert the bytes to a string and display it.
                    plainTextPassword = encoder.GetString(textBytes);
                    txtPassword.Text = plainTextPassword;

                    Session.Add("Email", txtMemberEmail.Text);
                    Session.Add("Password", plainTextPassword);
                 //   Session.Add("VerificationToken", myCookie["VerificationToken"]);
                    txtMemberEmail.Text = myCookie["Email"];
                    txtPassword.Text = plainTextPassword;

                }
            }
        } //end of Page_Load

        protected void signInBtn_Click(object sender, EventArgs e)
        {
        
           try
           {
                DBConnect objDB = new DBConnect();
                SqlCommand sqlComm = new SqlCommand();

                sqlComm.CommandType = CommandType.StoredProcedure;
                sqlComm.CommandText = "TP_MemberLogin";

                SqlParameter member = new SqlParameter("@Email", txtMemberEmail.Text);
                member.Direction = ParameterDirection.Input;
                member.SqlDbType = SqlDbType.VarChar;
                sqlComm.Parameters.Add(member);

                member = new SqlParameter("@password", txtPassword.Text);
                member.Direction = ParameterDirection.Input;
                member.SqlDbType = SqlDbType.VarChar;
                sqlComm.Parameters.Add(member);

                DataSet ds = objDB.GetDataSetUsingCmdObj(sqlComm);

                if (ds.Tables[0].Rows.Count == 1) //member record found
                {
                    //set cookies for faster login
                    if (cboxRemeberMe.Checked)
                    {

                        string email = txtMemberEmail.Text;
                        string plainTextPassword = txtPassword.Text;
                        string encryptedPassword;
                      //  string verificationToken = Session["VerificationToken"].ToString();
                        UTF8Encoding encoder = new UTF8Encoding();      // used to convert bytes to characters, and back
                        Byte[] textBytes;                               // stores the plain text data as bytes

            
                        textBytes = encoder.GetBytes(plainTextPassword);

                       
                        RijndaelManaged rmEncryption = new RijndaelManaged();
                        MemoryStream myMemoryStream = new MemoryStream();
                        CryptoStream myEncryptionStream = new CryptoStream(myMemoryStream, rmEncryption.CreateEncryptor(key, vector), CryptoStreamMode.Write);

                        // Use the crypto stream to perform the encryption on the plain text byte array.
                        myEncryptionStream.Write(textBytes, 0, textBytes.Length);
                        myEncryptionStream.FlushFinalBlock();

                        // Retrieve the encrypted data from the memory stream, and write it to a separate byte array.
                        myMemoryStream.Position = 0;
                        Byte[] encryptedBytes = new Byte[myMemoryStream.Length];
                        myMemoryStream.Read(encryptedBytes, 0, encryptedBytes.Length);

                        // Close all the streams.
                        myEncryptionStream.Close();
                        myMemoryStream.Close();

                        // Convert the bytes to a string and display it.
                        encryptedPassword = Convert.ToBase64String(encryptedBytes);


                        HttpCookie memberCookie = new HttpCookie("Login");
                        memberCookie.Values["Email"] = txtMemberEmail.Text;
                        memberCookie.Values["Password"] = encryptedPassword;
                   

                    memberCookie.Expires = DateTime.Now.AddDays(1); //cookie expire in 1 day 

                        Response.Cookies.Add(memberCookie);

                    }
                    else if (!cboxRemeberMe.Checked && Request.Cookies["Login"] != null)
                    {
                        HttpCookie memberCookie = Request.Cookies["Login"];
                        memberCookie.Expires = DateTime.Now.AddDays(-1);
                        Response.Cookies.Add(memberCookie);
                    }



                    Session["MemberAccount"] = ds.Tables[0].Rows[0]["Member_Email"].ToString();
                    Session["MemberID"] = ds.Tables[0].Rows[0]["Member_ID"].ToString();
                    Response.Redirect("HomePage.aspx");
                }
                else
                {
                    Error.Text = "Account not found! Please make sure you verified your account.";
                }
            }
            catch (Exception ex)
            {
                Error.Text = ex.Message;
            }
        } //end of signInBtn_Click
    } //end of class
} //end of namespace