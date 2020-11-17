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
                member.Visible = false;
                btnMember.Visible = true;
                btnBack.Visible = false;
            }
        } //end of Page_Load

        protected void btnMember_Click(object sender, EventArgs e)
        {
            member.Visible = true;
            memberSubmitBtn.Visible = false;
            memberEmailForgot.Visible = false;
            memberPwdForgot.Visible = false;
            btnBack.Visible = true;
            memberForgotDL.SelectedIndex = 0;
        } //end of btnmemberomer_Click

      
        protected void memberForgotDL_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (memberForgotDL.Text == "Email")
            {
                member.Visible = true;
                memberPwdForgot.Visible = false;
                memberEmailForgot.Visible = true;
                memberSubmitBtn.Visible = true;

                FnameTxt.Text = "";
                LnameTxt.Text = "";
                dobTxt.Text = "";
            }
            if (memberForgotDL.Text == "Password")
            {
                member.Visible = true;
                memberEmailForgot.Visible = false;
                memberPwdForgot.Visible = true;
                memberSubmitBtn.Visible = true;
                emailTxt.ReadOnly = false;
                securityQs.Visible = false;
                memberSubmitBtn.Text = "Recover Email";

                emailTxt.Text = "";
                q1.Text = "";
                q2.Text = "";
                q3.Text = "";
                ans1.Text = "";
                ans2.Text = "";
                ans3.Text = "";
            }
            if (memberForgotDL.Text == "-----")
            {
                member.Visible = true;
                memberSubmitBtn.Visible = false;
                memberEmailForgot.Visible = false;
                memberPwdForgot.Visible = false;
            }
        } //end of memberForgotDL_SelectedIndexChanged

        protected void memberPwdSubmitBtn_Click(object sender, EventArgs e)
        {
            if (securityQs.Visible == false)
            {
                try
                {
                    DBConnect objDB = new DBConnect();
                    SqlCommand sqlComm = new SqlCommand();

                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "TP_RetrieverMemberAcc";

                    SqlParameter account = new SqlParameter("@email", emailTxt.Text);
                    account.Direction = ParameterDirection.Input;
                    account.SqlDbType = SqlDbType.VarChar;
                    sqlComm.Parameters.Add(account);

                    DataSet ds = objDB.GetDataSetUsingCmdObj(sqlComm);

                    if (ds.Tables[0].Rows.Count == 1)
                    {
                        member.Visible = true;
                        memberPwdForgot.Visible = true;
                        securityQs.Visible = true;
                        emailTxt.ReadOnly = true;
                        memberSubmitBtn.Text = "Recover Password";

                        q1.Text = ds.Tables[0].Rows[0]["Member_SecurityQ1"].ToString();
                        q2.Text = ds.Tables[0].Rows[0]["Member_SecurityQ2"].ToString();
                        q3.Text = ds.Tables[0].Rows[0]["Member_SecurityQ3"].ToString();
                    }
                    else
                    {
                        Output.Text = "No account found with that email.";
                    }
                }
                catch (Exception ex)
                {
                    Output.Text = ex.Message;
                }
            }
            else if (securityQs.Visible == true && memberPwdForgot.Visible == true)
            {
                try
                {
                    DBConnect objDB = new DBConnect();
                    SqlCommand sqlComm = new SqlCommand();

                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "TP_RetrieverMemberAcc";

                    SqlParameter account = new SqlParameter("@email", emailTxt.Text);
                    account.Direction = ParameterDirection.Input;
                    account.SqlDbType = SqlDbType.VarChar;
                    sqlComm.Parameters.Add(account);

                    DataSet ds = objDB.GetDataSetUsingCmdObj(sqlComm);

                    if (ds.Tables[0].Rows.Count == 1)
                    {
                       
                        string Answer1 = ds.Tables[0].Rows[0]["Member_SecurityA1"].ToString().ToLower();
                        string Answer2 = ds.Tables[0].Rows[0]["Member_SecurityA2"].ToString().ToLower();
                        string Answer3 = ds.Tables[0].Rows[0]["Member_SecurityA3"].ToString().ToLower();

                        if (Answer1 == ans1.Text.Trim().ToLower() && Answer2 == ans2.Text.Trim().ToLower() && Answer3 == ans3.Text.Trim().ToLower())
                        {
                            Output.Text = "Your password is: " + ds.Tables[0].Rows[0]["Member_Password"].ToString();
                        }
                    }

                }
                catch (Exception ex)
                {
                    Output.Text = ex.Message;
                }
            }
        } //end of memberPwdSubmitBtn_Click

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

                account = new SqlParameter("@dob", dobTxt.Text.Trim());
                account.Direction = ParameterDirection.Input;
                account.SqlDbType = SqlDbType.VarChar;
                sqlComm.Parameters.Add(account);
                DataSet result = objDB.GetDataSetUsingCmdObj(sqlComm);
                if (result.Tables[0].Rows.Count == 1) //record found
                {
                    Output.Text = "Your email is: " + result.Tables[0].Rows[0]["Member_Email"].ToString();


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
            member.Visible = false;
            btnMember.Visible = true;
            btnBack.Visible = false;
        } //end of Back_Click
    } //end of class
} //end of namespace