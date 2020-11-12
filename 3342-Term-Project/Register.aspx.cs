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

namespace _3342_Term_Project
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Error.Text = "";
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
                try
                {
                    DBConnect objDB = new DBConnect();
                    SqlCommand sqlComm = new SqlCommand();

                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "TP_MemberRegister";

                    SqlParameter cust = new SqlParameter("@email", txtEmail.Text.Trim());
                    cust.Direction = ParameterDirection.Input;
                    cust.SqlDbType = SqlDbType.VarChar;
                    sqlComm.Parameters.Add(cust);

                    cust = new SqlParameter("@firstName", txtFirstName.Text.Trim());
                    cust.Direction = ParameterDirection.Input;
                    cust.SqlDbType = SqlDbType.VarChar;
                    sqlComm.Parameters.Add(cust);

                    cust = new SqlParameter("@lastName", txtLastName.Text.Trim());
                    cust.Direction = ParameterDirection.Input;
                    cust.SqlDbType = SqlDbType.VarChar;
                    sqlComm.Parameters.Add(cust);

               


                    //this need to be change when hashing pw is implemented
                    cust = new SqlParameter("@password", txtPassword.Text);
                    cust.Direction = ParameterDirection.Input;
                    cust.SqlDbType = SqlDbType.VarChar;
                    sqlComm.Parameters.Add(cust);
                    cust = new SqlParameter("@DOB", txtDOB.Text);
                    cust.Direction = ParameterDirection.Input;
                    cust.SqlDbType = SqlDbType.VarChar;
                    sqlComm.Parameters.Add(cust);


                    cust = new SqlParameter("@securityQ1", ddlSecurityQuestion1.SelectedValue.ToString());
                    cust.Direction = ParameterDirection.Input;
                    cust.SqlDbType = SqlDbType.VarChar;
                    sqlComm.Parameters.Add(cust);

                    cust = new SqlParameter("@securityA1", txtSecurityAnswer1.Text.Trim());
                    cust.Direction = ParameterDirection.Input;
                    cust.SqlDbType = SqlDbType.VarChar;
                    sqlComm.Parameters.Add(cust);

                    cust = new SqlParameter("@securityQ2", ddlSecurityQuestion2.SelectedValue.ToString());
                    cust.Direction = ParameterDirection.Input;
                    cust.SqlDbType = SqlDbType.VarChar;
                    sqlComm.Parameters.Add(cust);

                    cust = new SqlParameter("@securityA2", txtSecurityAnswer2.Text.Trim());
                    cust.Direction = ParameterDirection.Input;
                    cust.SqlDbType = SqlDbType.VarChar;
                    sqlComm.Parameters.Add(cust);

                    cust = new SqlParameter("@securityQ3", ddlSecutiryQuestion3.SelectedValue.ToString());
                    cust.Direction = ParameterDirection.Input;
                    cust.SqlDbType = SqlDbType.VarChar;
                    sqlComm.Parameters.Add(cust);

                    cust = new SqlParameter("@securityA3", txtSecurityAnswer3.Text.Trim());
                    cust.Direction = ParameterDirection.Input;
                    cust.SqlDbType = SqlDbType.VarChar;
                    sqlComm.Parameters.Add(cust);

                    
                   /*
                    if (cboxSameAddress.Checked) //same as billing address
                    {
                        cust = new SqlParameter("@shippingAddress", txtBillingAddress.Text.Trim());
                        cust.Direction = ParameterDirection.Input;
                        cust.SqlDbType = SqlDbType.VarChar;
                        sqlComm.Parameters.Add(cust);
                    }
                    else    //shipping address different than billing address
                    {
                        cust = new SqlParameter("@shippingAddress", txtShippingAddress.Text.Trim());
                        cust.Direction = ParameterDirection.Input;
                        cust.SqlDbType = SqlDbType.VarChar;
                        sqlComm.Parameters.Add(cust);
                    }
                    */

                    int result = objDB.DoUpdateUsingCmdObj(sqlComm);

                    if (result > 0)
                    {
                        Error.Text = "Account added, return to login at top!";
                    }
                    else
                    {
                        Error.Text = "Registration failed ";
                    }

                }
                catch (Exception ex)
                {
                    Error.Text = ex.Message;
                }
            }




        } //end of Submit_Click
    } //end of class
} //end of namespace