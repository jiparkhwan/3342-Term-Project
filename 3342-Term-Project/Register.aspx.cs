using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilities;
using ClassLibrary;

namespace _3342_Term_Project
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Error.Text = "";
        }
        protected void BackToLoginBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
        protected void Submit_Click(object sender, EventArgs e)
        {

            if (txtPassword.Text != txtConfirmPassword.Text)
            {
                pwdValidator.IsValid = false;
                pwdValidator.ErrorMessage = "Password does not match!";
            }
            else
            {
                
                    Email objEmail = new Email();


                    String strTO = txtEmail.Text;
                    String strFROM = "tug67579@cis-linux2.temple.edu";
                    String strSubject = "LexPark Registration Confirmation";
                    String strMessage = "Hello, click on the link to activate your account: http://localhost:55733/VerifiedPage.aspx";
           
                        objEmail.SendMail(strTO, strFROM, strSubject, strMessage);

                        Error.Text = "An email was sent to verify account!";

                    int result = StoredProcedures.addMemberAccountRegister(txtEmail.Text, txtFirstName.Text, txtLastName.Text, txtPassword.Text, txtDOB.Text,
                        ddlSecurityQuestion1.SelectedValue.ToString(), ddlSecurityQuestion2.SelectedValue.ToString(), ddlSecurityQuestion3.SelectedValue.ToString(),
                        txtSecurityAnswer1.Text, txtSecurityAnswer2.Text, txtSecurityAnswer3.Text);
                    
                    if (result > 0)
                    {
                        Session["RegisterEmailVerified"] = txtEmail.Text;


                        Error.Text = "Check your email to verify your account!";
                    }
                 

                }
             
            




        } //end of Submit_Click
    } //end of class
} //end of namespace