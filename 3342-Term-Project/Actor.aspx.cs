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
    }
}