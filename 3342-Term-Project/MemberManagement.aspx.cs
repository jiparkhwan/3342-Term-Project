using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _3342_Term_Project
{
    public partial class MemberManagement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lnkBtnAddActor_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddActor.aspx");
        }

        protected void lnkbtnShowClick_Click(object sender, EventArgs e)
        {
            Session["AddActor"] = null;
            Session["AddMovie"] = null;
            Session["AddShow"] = "Show_Button";
            Session["AddGame"] = null;

            Response.Redirect("AddTitle.aspx");
        }

        protected void lnkBtnAddMovie_Click(object sender, EventArgs e)
        {
            Session["AddActor"] = null;
            Session["AddMovie"] = "Movie_Button";
            Session["AddShow"] = null;
            Session["AddGame"] = null;

            Response.Redirect("AddTitle.aspx");
        }

        protected void lnkbtnGameClick_Click(object sender, EventArgs e)
        {
            Session["AddActor"] = null;
            Session["AddMovie"] = null;
            Session["AddShow"] = null;
            Session["AddGame"] = "Game_Button";

            Response.Redirect("AddTitle.aspx");
        }
    }
}