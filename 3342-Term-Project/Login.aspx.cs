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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Error.Text = "";
            if (Request.Cookies["Member"] != null)
            {
                txtMemberID.Text = Request.Cookies["Member"]["MemberID"];
            }
        } //end of Page_Load

        protected void signInBtn_Click(object sender, EventArgs e)
        {
        
            try
            {
                DBConnect objDB = new DBConnect();
                SqlCommand sqlComm = new SqlCommand();

                sqlComm.CommandType = CommandType.StoredProcedure;
                sqlComm.CommandText = "TP_MerchantLogin";

                SqlParameter member = new SqlParameter("@memberID", txtMemberID.Text);
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
                        HttpCookie memberCookie = new HttpCookie("Member");
                        memberCookie.Values["Member_ID"] = ds.Tables[0].Rows[0]["Member_ID"].ToString();
                        memberCookie.Expires = DateTime.Now.AddDays(1); //cookie expire in 1 day 

                        Response.Cookies.Add(memberCookie);

                    }
                    else if (!cboxRemeberMe.Checked && Request.Cookies["Member"] != null)
                    {
                        HttpCookie memberCookie = Request.Cookies["Member"];
                        memberCookie.Expires = DateTime.Now.AddDays(-1);
                        Response.Cookies.Add(memberCookie);
                    }



                    Session["MemberAccount"] = ds.Tables[0].Rows[0]["Member_ID"].ToString();
                    Response.Redirect("HomePage.aspx");
                }
                else
                {
                    Error.Text = "Account not found!";
                }
            }
            catch (Exception ex)
            {
                Error.Text = ex.Message;
            }
        } //end of signInBtn_Click
    } //end of class
} //end of namespace