using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilities;

namespace _3342_Term_Project
{
    public partial class AccountRecovery : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Output.Text = "";
            if (!IsPostBack)
            {
                customer.Visible = false;
                btnCustomer.Visible = true;
                btnBack.Visible = false;
            }
        } //end of Page_Load

        protected void btnCustomer_Click(object sender, EventArgs e)
        {
            customer.Visible = true;
            custSubmitBtn.Visible = false;
            custEmailForgot.Visible = false;
            custPwdForgot.Visible = false;
            btnBack.Visible = true;
            custForgotDL.SelectedIndex = 0;
        } //end of btnCustomer_Click

        protected void btnMerchant_Click(object sender, EventArgs e)
        {
            btnCustomer.Visible = false;
            btnBack.Visible = true;
        } //end of btnMerchant_Click

        protected void custForgotDL_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (custForgotDL.Text == "Email")
            {
                customer.Visible = true;
                custPwdForgot.Visible = false;
                custEmailForgot.Visible = true;
                custSubmitBtn.Visible = true;

                FnameTxt.Text = "";
                LnameTxt.Text = "";
                dobTxt.Text = "";
            }
            if (custForgotDL.Text == "Password")
            {
                customer.Visible = true;
                custEmailForgot.Visible = false;
                custPwdForgot.Visible = true;
                custSubmitBtn.Visible = true;
                emailTxt.ReadOnly = false;
                securityQs.Visible = false;
                custSubmitBtn.Text = "Find Account";

                emailTxt.Text = "";
                q1.Text = "";
                q2.Text = "";
                q3.Text = "";
                ans1.Text = "";
                ans2.Text = "";
                ans3.Text = "";
            }
            if (custForgotDL.Text == "-----")
            {
                customer.Visible = true;
                custSubmitBtn.Visible = false;
                custEmailForgot.Visible = false;
                custPwdForgot.Visible = false;
            }
        } //end of custForgotDL_SelectedIndexChanged

        protected void custPwdSubmitBtn_Click(object sender, EventArgs e)
        {
            if (securityQs.Visible == false)
            {
                try
                {
                    DBConnect objDB = new DBConnect();
                    SqlCommand sqlComm = new SqlCommand();

                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "TP_RetrieveMemberAcc";

                    SqlParameter account = new SqlParameter("@email", emailTxt.Text);
                    account.Direction = ParameterDirection.Input;
                    account.SqlDbType = SqlDbType.VarChar;
                    sqlComm.Parameters.Add(account);

                    DataSet ds = objDB.GetDataSetUsingCmdObj(sqlComm);

                    if (ds.Tables[0].Rows.Count == 1)
                    {
                        customer.Visible = true;
                        custPwdForgot.Visible = true;
                        securityQs.Visible = true;
                        emailTxt.ReadOnly = true;
                        custSubmitBtn.Text = "Submit";

                        q1.Text = ds.Tables[0].Rows[0]["Security_Q1"].ToString();
                        q2.Text = ds.Tables[0].Rows[0]["Security_Q2"].ToString();
                        q3.Text = ds.Tables[0].Rows[0]["Security_Q3"].ToString();
                    }
                    else
                    {
                        Output.Text = "No account found";
                    }
                }
                catch (Exception ex)
                {
                    Output.Text = ex.Message;
                }
            }
            else if (securityQs.Visible == true && custPwdForgot.Visible == true)
            {
                try
                {
                    DBConnect objDB = new DBConnect();
                    SqlCommand sqlComm = new SqlCommand();

                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "TP_RetrieveUserAcc";

                    SqlParameter account = new SqlParameter("@email", emailTxt.Text);
                    account.Direction = ParameterDirection.Input;
                    account.SqlDbType = SqlDbType.VarChar;
                    sqlComm.Parameters.Add(account);

                    DataSet ds = objDB.GetDataSetUsingCmdObj(sqlComm);

                    if (ds.Tables[0].Rows.Count == 1)
                    {
                        string Answer1 = ds.Tables[0].Rows[0]["Answer1"].ToString().ToLower();
                        string Answer2 = ds.Tables[0].Rows[0]["Answer2"].ToString().ToLower();
                        string Answer3 = ds.Tables[0].Rows[0]["Answer3"].ToString().ToLower();

                        if (Answer1 == ans1.Text.Trim().ToLower() && Answer2 == ans2.Text.Trim().ToLower() && Answer3 == ans3.Text.Trim().ToLower())
                        {
                            Output.Text = "Your password: " + ds.Tables[0].Rows[0]["Password"].ToString();
                        }
                    }

                }
                catch (Exception ex)
                {
                    Output.Text = ex.Message;
                }
            }
        } //end of custPwdSubmitBtn_Click

        protected void emailForgotSubmitBtn_Click(object sender, EventArgs e)
        {
            try
            {
                DBConnect objDB = new DBConnect();
                SqlCommand sqlComm = new SqlCommand();

                sqlComm.CommandType = CommandType.StoredProcedure;
                sqlComm.CommandText = "TP_RetrieveUserEmail";

                SqlParameter account = new SqlParameter("@firstName", FnameTxt.Text.Trim());
                account.Direction = ParameterDirection.Input;
                account.SqlDbType = SqlDbType.VarChar;
                sqlComm.Parameters.Add(account);

                account = new SqlParameter("@lastName", LnameTxt.Text.Trim());
                account.Direction = ParameterDirection.Input;
                account.SqlDbType = SqlDbType.VarChar;
                sqlComm.Parameters.Add(account);

                account = new SqlParameter("@phone", phoneTxt.Text.Trim());
                account.Direction = ParameterDirection.Input;
                account.SqlDbType = SqlDbType.VarChar;
                sqlComm.Parameters.Add(account);
                DataSet result = objDB.GetDataSetUsingCmdObj(sqlComm);
                if (result.Tables[0].Rows.Count == 1) //record found
                {
                    Output.Text = "Your email: " + result.Tables[0].Rows[0]["Customer_Email"].ToString();


                }
                else
                {
                    Output.Text = "Account not found!";
                }
            }
            catch (Exception ex)
            {
                Output.Text = ex.Message;
            }
        } //end of emailForgotSubmitBtn_Click

       
      
       
        protected void Back_Click(object sender, EventArgs e)
        {
            customer.Visible = false;
            btnCustomer.Visible = true;
            btnBack.Visible = false;
        } //end of Back_Click
    } //end of class
} //end of namespace