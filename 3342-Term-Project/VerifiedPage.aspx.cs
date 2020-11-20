using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassLibrary;

namespace _3342_Term_Project
{
    public partial class VerifiedPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["RegisterEmailVerified"] == null || Session["RegisterEmailVerified"].ToString() =="")
            {
                lblResult.Text = "Something went wrong, account failed to verify";
                redirectToLogin.Visible = false;
            }
            else
            {
                try
                {
                    int result = StoredProcedures.verifyMemberAccount(Session["RegisterEmailVerified"].ToString());
                    if(result > 0 )
                    {
                        lblResult.Text = "Account has been succesfully verified for email: " + Session["RegisterEmailVerified"].ToString() + "!";
                        redirectToLogin.Visible = true;
                    }
                }
                catch(Exception E)
                {
                    lblResult.Text = E.Message;
                }
            }
        }
        
    }
}