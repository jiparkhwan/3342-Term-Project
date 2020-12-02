using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassLibrary;

namespace _3342_Term_Project
{
    public partial class AddActor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            bind_year_ddl();

            if(Session["Edit_Actor_Activated"] != null)
            {
                Session["NewActorInfo"] = "EditActor";
                txtAddName.Text = Session["EditActorName"].ToString();
                txtAddImage.Text = Session["EditActorImage"].ToString();
                txtAddHeight.Text = Session["EditActorHeight"].ToString();
                string month = Session["EditActorDOB"].ToString().Substring(0,2);
                string day = Session["EditActorDOB"].ToString().Substring(3,2);
                string year = Session["EditActorDOB"].ToString().Substring(6);
                ddlAddDOBMonth.Text = month;
                ddlAddDOBDay.Text = day;
                ddlAddDOBYear.Text = year;
                txtAddBirthCity.Text = Session["EditActorBirthCity"].ToString();
                txtAddBirthState.Text = Session["EditActorBirthState"].ToString();
                txtAddBirthCountry.Text = Session["EditActorBirthCountry"].ToString();
                txtAddDescription.Text = Session["EditActorDescription"].ToString();
                Session["Edit_Actor_Activated"] = null;
            }
        }

        protected void ddlAddBOBYear_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void bind_year_ddl()
        {
            int year = (System.DateTime.Now.Year);
            for (int intCount = year; intCount >= 1900; intCount--)
            {
                ddlAddDOBYear.Items.Add(intCount.ToString());
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Actors actor = new Actors();
            actor.MemberID = Convert.ToInt32(Session["MemberID"].ToString());

            actor.ActorID = Convert.ToInt32(Session["EditActorID"].ToString());
            actor.ActorImage = txtAddImage.Text;
            actor.ActorName = txtAddName.Text;
            actor.ActorDescription = txtAddDescription.Text;
            actor.ActorHeight = txtAddHeight.Text;
            actor.ActorDOB = ddlAddDOBMonth.Text + "/" + ddlAddDOBDay.Text + "/" + ddlAddDOBYear.Text;
            actor.ActorBirthCity = txtAddBirthCity.Text;
            actor.ActorBirthState = txtAddBirthState.Text;
            actor.ActorBirthCountry = txtAddBirthCountry.Text;

            JavaScriptSerializer js = new JavaScriptSerializer();

            String jsonActor = js.Serialize(actor);

            try
            {
                if (Session["NewActorInfo"] != null)
                {
                    WebRequest request = WebRequest.Create("https://localhost:44301/WebAPI/TermProject/UpdateActor/");
                    request.Method = "PUT";
                    request.ContentLength = jsonActor.Length;
                    request.ContentType = "application/json";

                    // Write the JSON data to the Web Request
                    StreamWriter writer = new StreamWriter(request.GetRequestStream());
                    writer.Write(jsonActor);
                    writer.Flush();
                    writer.Close();

                    // Read the data from the Web Response, which requires working with streams.
                    WebResponse response = request.GetResponse();
                    Stream theDataStream = response.GetResponseStream();
                    StreamReader reader = new StreamReader(theDataStream);
                    String data = reader.ReadToEnd();
                    reader.Close();
                    response.Close();

                    if (data == "true")
                        lblDisplay.Text = "The actor was successfully saved to the database.";
                    else
                        lblDisplay.Text = "A problem occurred while editing the actor. The data wasn't recorded.";
                }
                else
                {
                    WebRequest request = WebRequest.Create("https://localhost:44301/WebAPI/TermProject/AddActor/");
                    request.Method = "POST";
                    request.ContentLength = jsonActor.Length;
                    request.ContentType = "application/json";

                    // Write the JSON data to the Web Request
                    StreamWriter writer = new StreamWriter(request.GetRequestStream());
                    writer.Write(jsonActor);
                    writer.Flush();
                    writer.Close();

                    // Read the data from the Web Response, which requires working with streams.
                    WebResponse response = request.GetResponse();
                    Stream theDataStream = response.GetResponseStream();
                    StreamReader reader = new StreamReader(theDataStream);
                    String data = reader.ReadToEnd();
                    reader.Close();
                    response.Close();

                    if (data == "true")
                        lblDisplay.Text = "The actor was successfully saved to the database.";
                    else
                        lblDisplay.Text = "A problem occurred while adding the actor to the database. The data wasn't recorded.";
                }
            }

            catch (Exception ex)
            {
                lblDisplay.Text = "Error: " + ex.Message;
            }
        }
    }
}