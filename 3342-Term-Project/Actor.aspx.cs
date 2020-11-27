using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _3342_Term_Project
{
    public partial class Actor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            lblActorName.Text = Session["ActorName"].ToString();
            imgActorImage.ImageUrl = Session["ActorImage"].ToString();
            lblActorDescription.Text = Session["ActorDescription"].ToString();
            lblActorDOB.Text = Session["ActorDOB"].ToString();
            lblActorHeight.Text = Session["ActorHeight"].ToString();
            lblActorBirthCity.Text = Session["ActorBirthCity"].ToString();
            lblActorBirthState.Text = Session["ActorBirthState"].ToString();
            lblActorBirthCountry.Text = Session["ActorBirthCountry"].ToString();

            if (Session["MemberAccount"] == null)
            {
                Server.Transfer("Login.aspx", false);
            }

        }

        protected void btnEditActor_Click(object sender, EventArgs e)
        {
            Session["Edit_Actor_Activated"] = "Edit Actor";
            if(Session["ActorSelectedID"] != null)
            {
                Session["EditActorID"] = Session["ActorSelectedID"].ToString();
                Session["EditActorName"] = Session["ActorName"].ToString();
                Session["EditActorImage"] = Session["ActorImage"].ToString();
                Session["EditActorDescription"] = Session["ActorDescription"].ToString();
                Session["EditActorDOB"] = Session["ActorDOB"].ToString();
                Session["EditActorHeight"] = Session["ActorHeight"].ToString();
                Session["EditActorBirthCity"] = Session["ActorBirthCity"].ToString();
                Session["EditActorBirthState"] = Session["ActorBirthState"].ToString();
                Session["EditActorBirthCountry"] = Session["ActorBirthCountry"].ToString();
            }
            Response.Redirect("AddActor.aspx");
        }
    }
}