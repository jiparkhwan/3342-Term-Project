using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;
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
            actorInfoPanel.Visible = true;
            editDeletePanel.Visible = true;
            lblError.Text = "";
            if (Session["MemberAccount"] == null)
            {
                Server.Transfer("Login.aspx", false);
            }

        }
        protected void btnDeleteActor_Click(object sender, EventArgs e)
        {
            try
            {
                // Create an HTTP Web Request and get the HTTP Web Response from the server.
                WebRequest request = WebRequest.Create("https://localhost:44301/WebAPI/TermProject/DeleteActor/" + Session["ActorID"].ToString());
                request.Method = "DELETE";
                request.ContentLength = 0;

                WebResponse response = request.GetResponse();
                // Read the data from the Web Response, which requires working with streams.
                Stream theDataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(theDataStream);
                string data = reader.ReadToEnd();
                reader.Close();
                response.Close();
                
                lblError.Text = "Actor has been successfully deleted!";
                actorInfoPanel.Visible = false;
                editDeletePanel.Visible = false;
            }
            catch (Exception E)
            {
                lblError.Text = E.Message;
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