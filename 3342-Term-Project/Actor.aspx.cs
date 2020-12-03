using ClassLibrary;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilities;

namespace _3342_Term_Project
{
    public partial class Actor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
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

                // Create an HTTP Web Request and get the HTTP Web Response from the server.
                WebRequest request = WebRequest.Create("https://localhost:44301/WebAPI/TermProject/GetAllActorsRoles/" + Session["ActorSelectedID"].ToString());
                WebResponse response = request.GetResponse();
                // Read the data from the Web Response, which requires working with streams.
                Stream theDataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(theDataStream);
                String data = reader.ReadToEnd();
                reader.Close();
                response.Close();
                // Deserialize a JSON string into a Team object.
                JavaScriptSerializer js = new JavaScriptSerializer();
                Roles[] show = js.Deserialize<Roles[]>(data);
                //gvResults.DataSource = Movie;
                // gvResults.DataBind();
                rptActorRoles.DataSource = show;
                rptActorRoles.DataBind();
                lblError.Text = "";
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
            if (Session["ActorSelectedID"] != null)
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

        protected void Image_Click(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "ImageMovieClick")
            {
                int MovieID = Convert.ToInt32(e.CommandArgument);
                Session["MovieID"] = MovieID;
                DBConnect objDB = new DBConnect();
                SqlCommand sqlComm = new SqlCommand();

                sqlComm.CommandType = CommandType.StoredProcedure;
                sqlComm.CommandText = "TP_GetMovieByID";

                SqlParameter member = new SqlParameter("@movieID", MovieID);
                member.Direction = ParameterDirection.Input;
                member.SqlDbType = SqlDbType.VarChar;
                sqlComm.Parameters.Add(member);


                DataSet ds = objDB.GetDataSetUsingCmdObj(sqlComm);

                if (ds.Tables[0].Rows.Count == 1) //member record found
                {
                    Session["TitleName"] = ds.Tables[0].Rows[0]["Movie_Name"].ToString();
                    Session["TitleImage"] = ds.Tables[0].Rows[0]["Movie_Image"].ToString();
                    Session["TitleYear"] = ds.Tables[0].Rows[0]["Movie_Year"].ToString();
                    Session["TitleDescription"] = ds.Tables[0].Rows[0]["Movie_Description"].ToString();
                    Session["TitleRunTime"] = ds.Tables[0].Rows[0]["Movie_RunTime"].ToString();
                    Session["TitleGenre"] = ds.Tables[0].Rows[0]["Movie_Genre"].ToString();
                    Session["TitleAgeRating"] = ds.Tables[0].Rows[0]["Movie_Age_Rating"].ToString();
                    Session["TitleBudget"] = ds.Tables[0].Rows[0]["Movie_Budget"].ToString();
                    Session["TitleIncome"] = ds.Tables[0].Rows[0]["Movie_Income"].ToString();
                    Session["TitleCreator"] = null;

                    lblError.Text = "saved session info";
                    Response.Redirect("Title.aspx");
                }
                else
                {
                    lblError.Text = "table doesnt exist";
                }
            }
            else if (e.CommandName == "ImageShowClick")
            {

                Session["MovieReviews"] = false;
                Session["ShowReviews"] = true;
                Session["GameReviews"] = false;

                int ShowID = Convert.ToInt32(e.CommandArgument);
                Session["ShowID"] = ShowID;
                DBConnect objDB = new DBConnect();
                SqlCommand sqlComm = new SqlCommand();

                sqlComm.CommandType = CommandType.StoredProcedure;
                sqlComm.CommandText = "TP_GetShowByID";

                SqlParameter member = new SqlParameter("@showID", ShowID);
                member.Direction = ParameterDirection.Input;
                member.SqlDbType = SqlDbType.VarChar;
                sqlComm.Parameters.Add(member);

                DataSet ds = objDB.GetDataSetUsingCmdObj(sqlComm);

                if (ds.Tables[0].Rows.Count == 1) //member record found
                {
                    Session["TitleName"] = ds.Tables[0].Rows[0]["TV_Show_Name"].ToString();
                    Session["TitleImage"] = ds.Tables[0].Rows[0]["TV_Show_Image"].ToString();
                    Session["TitleYear"] = ds.Tables[0].Rows[0]["TV_Show_Years"].ToString();
                    Session["TitleDescription"] = ds.Tables[0].Rows[0]["TV_Show_Description"].ToString();
                    Session["TitleRunTime"] = ds.Tables[0].Rows[0]["TV_Show_RunTime"].ToString();
                    Session["TitleGenre"] = ds.Tables[0].Rows[0]["TV_Show_Genre"].ToString();
                    Session["TitleAgeRating"] = ds.Tables[0].Rows[0]["TV_Show_Age_Rating"].ToString();
                    Session["TitleCreator"] = null;
                    Session["TitleBudget"] = null;
                    Session["TitleIncome"] = null;

                    lblError.Text = "saved session info";
                    Server.Transfer("Title.aspx");
                }
                else
                {
                    lblError.Text = "table doesnt exist";
                }
            }
        }
    }
}