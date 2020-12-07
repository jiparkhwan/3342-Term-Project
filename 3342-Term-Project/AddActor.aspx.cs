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
                lblAddActorLabel.Text = "Edit Actor";
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
                ddlAddBirthState.Text = Session["EditActorBirthState"].ToString();
                ddlAddBirthCountry.Text = Session["EditActorBirthCountry"].ToString();
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
            if(ddlAddDOBDay.SelectedValue == "noneSelected")
            {
                lblDisplay.Text = "Select a date of birth";
            }
            else
            {
                if (ddlAddDOBMonth.SelectedValue == "noneSelected")
                {
                    lblDisplay.Text = "Select a date of birth";
                }
                else
                {
                    if (ddlAddDOBMonth.SelectedValue == "noneSelected")
                    {
                        lblDisplay.Text = "Select a date of birth";
                    }
                    else
                    {
                        if(ddlAddBirthCountry.SelectedValue == "noneSelected")
                        {
                            lblDisplay.Text = "Select a country";
                        }
                        else
                        {
                            if (ddlAddBirthState.SelectedValue == "noneSelected")
                            {
                                lblDisplay.Text = "Select a state";
                            }
                            else
                            {
                                Actors actor = new Actors();
                                actor.MemberID = Convert.ToInt32(Session["MemberID"].ToString());

                                if (Session["EditActorID"] != null)
                                {
                                    actor.ActorID = Convert.ToInt32(Session["EditActorID"].ToString());
                                }
                                actor.ActorImage = txtAddImage.Text;
                                actor.ActorName = txtAddName.Text;
                                actor.ActorDescription = txtAddDescription.Text;
                                actor.ActorHeight = txtAddHeight.Text;
                                actor.ActorDOB = ddlAddDOBMonth.Text + "/" + ddlAddDOBDay.Text + "/" + ddlAddDOBYear.Text;
                                actor.ActorBirthCity = txtAddBirthCity.Text;
                                actor.ActorBirthState = ddlAddBirthState.Text;
                                actor.ActorBirthCountry = ddlAddBirthCountry.Text;

                                JavaScriptSerializer js = new JavaScriptSerializer();

                                String jsonActor = js.Serialize(actor);

                                try
                                {
                                    if (Session["NewActorInfo"] != null)
                                    {
                                        WebRequest request = WebRequest.Create("https://localhost:44301/WebAPI/actors/UpdateActor/");
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
                                        {
                                            lblDisplay.Text = "The actor was successfully updated!";
                                            Response.Write("<script>alert('Actor updated successfully')</script>");
                                        }
                                        else
                                            lblDisplay.Text = "You can only edit your own added listings!";
                                    }
                                    else
                                    {
                                        WebRequest request = WebRequest.Create("https://localhost:44301/WebAPI/actors/AddActor/");
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
                                        {
                                            lblDisplay.Text = "The actor was successfully saved to the database.";

                                            Response.Write("<script>alert('Actor inserted successfully')</script>");
                                        }
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
                }
            }
            Session["NewActorInfo"] = null;
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            txtAddImage.Text = "";
            txtAddName.Text = "";
            txtAddHeight.Text = "";
            ddlAddDOBDay.SelectedValue = "noneSelected";
            ddlAddDOBMonth.SelectedValue = "noneSelected";
            ddlAddDOBYear.SelectedValue = "noneSelected";
            txtAddBirthCity.Text = "";
            ddlAddBirthState.SelectedValue = "noneSelected";
            ddlAddBirthCountry.SelectedValue = "noneSelected";
            txtAddDescription.Text = "";
        }
    }
}