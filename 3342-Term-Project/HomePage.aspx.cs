using ClassLibrary;
using System;
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
    public partial class HomePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            frmHomePage.Visible = true;
            pnlSearchMedia.Visible = true;
            if (Session["MemberAccount"] == null)
            {
                Server.Transfer("Login.aspx", false);
            }
            else
            {
                string email = Session["MemberAccount"].ToString();
    
            }
        }
       

        protected void btnFindByName_Click(object sender, EventArgs e)
        {
            //VALIDATE THE API REQUEST!!!//
            

            if (ddlSelectMedia.Text == "movies")
            {
                pnlHome.Visible = false;
                FooterNav.Visible = false;
                pnlMovieRepeater.Visible = true;
                pnlShowRepeater.Visible = false;
                pnlGameRepeater.Visible = false;
                Session["Movie_Searched"] = "Movie";
              
                try
                {
                    // Create an HTTP Web Request and get the HTTP Web Response from the server.
                    WebRequest request = WebRequest.Create("https://localhost:44301/WebAPI/TermProject/GetMovieByName/" + txtFindByName.Text);
                    WebResponse response = request.GetResponse();
                    // Read the data from the Web Response, which requires working with streams.
                    Stream theDataStream = response.GetResponseStream();
                    StreamReader reader = new StreamReader(theDataStream);
                    String data = reader.ReadToEnd();
                    reader.Close();
                    response.Close();
                    // Deserialize a JSON string into a Team object.
                    JavaScriptSerializer js = new JavaScriptSerializer();
                    Movies[] movie = js.Deserialize<Movies[]>(data);
                    //gvResults.DataSource = Movie;
                    // gvResults.DataBind();
                    rptMovieSearchRes.DataSource = movie;
                    rptMovieSearchRes.DataBind();
                    lblError.Text = "";
                }
                catch(Exception)
                {
                    lblError.Text = "Please enter a movie name first";
                }
            }
            else if(ddlSelectMedia.Text == "shows")
            {
                pnlHome.Visible = false;
                FooterNav.Visible = false;
                pnlMovieRepeater.Visible = false;
                pnlShowRepeater.Visible = true;
                pnlGameRepeater.Visible = false;
                Session["Show_Searched"] = "Show";

                try
                {
                    // Create an HTTP Web Request and get the HTTP Web Response from the server.
                    WebRequest request = WebRequest.Create("https://localhost:44301/WebAPI/TermProject/GetShowByName/" + txtFindByName.Text);
                    WebResponse response = request.GetResponse();
                    // Read the data from the Web Response, which requires working with streams.
                    Stream theDataStream = response.GetResponseStream();
                    StreamReader reader = new StreamReader(theDataStream);
                    String data = reader.ReadToEnd();
                    reader.Close();
                    response.Close();
                    // Deserialize a JSON string into a Team object.
                    JavaScriptSerializer js = new JavaScriptSerializer();
                    TVShows[] show = js.Deserialize<TVShows[]>(data);
                    //gvResults.DataSource = Movie;
                    // gvResults.DataBind();
                    rptShowSearchRes.DataSource = show;
                    rptShowSearchRes.DataBind();
                    lblError.Text = "";
                }
                catch(Exception)
                {
                    lblError.Text = "Enter a TVshow name first!";
                }
            }
            else if(ddlSelectMedia.Text == "videoGames")
            {
                pnlHome.Visible = false;
                FooterNav.Visible = false;
                pnlMovieRepeater.Visible = false;
                pnlShowRepeater.Visible = false;
                pnlGameRepeater.Visible = true;
                Session["Game_Searched"] = "Game";


                try
                {
                    // Create an HTTP Web Request and get the HTTP Web Response from the server.
                    WebRequest request = WebRequest.Create("https://localhost:44301/WebAPI/TermProject/GetGameByName/" + txtFindByName.Text);
                    WebResponse response = request.GetResponse();
                    // Read the data from the Web Response, which requires working with streams.
                    Stream theDataStream = response.GetResponseStream();
                    StreamReader reader = new StreamReader(theDataStream);
                    String data = reader.ReadToEnd();
                    reader.Close();
                    response.Close();
                    // Deserialize a JSON string into a Team object.
                    JavaScriptSerializer js = new JavaScriptSerializer();
                    VideoGames[] game = js.Deserialize<VideoGames[]>(data);
                    //gvResults.DataSource = Movie;
                    // gvResults.DataBind();
                    rptGameSearchRes.DataSource = game;
                    rptGameSearchRes.DataBind();
                    lblError.Text = "";
                }
                catch(Exception)
                {
                    lblError.Text = "Please enter a video game name first!";
                }
            }
            else if (ddlSelectMedia.Text == "actors")
            {
                pnlHome.Visible = false;
                FooterNav.Visible = false;
                pnlMovieRepeater.Visible = false;
                pnlShowRepeater.Visible = false;
                pnlGameRepeater.Visible = false;
                pnlActorRepeater.Visible = true;

                // Create an HTTP Web Request and get the HTTP Web Response from the server.
                WebRequest request = WebRequest.Create("https://localhost:44301/WebAPI/TermProject/GetActorByName/" + txtFindByName.Text);
                WebResponse response = request.GetResponse();
                // Read the data from the Web Response, which requires working with streams.
                Stream theDataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(theDataStream);
                String data = reader.ReadToEnd();
                reader.Close();
                response.Close();
                // Deserialize a JSON string into a Team object.
                JavaScriptSerializer js = new JavaScriptSerializer();
                Actors[] actor = js.Deserialize<Actors[]>(data);
                //gvResults.DataSource = Movie;
                // gvResults.DataBind();
                rptActorSearchRes.DataSource = actor;
                rptActorSearchRes.DataBind();
                lblError.Text = "";
            }

        }

        protected void Image_Click(object sender, CommandEventArgs e)
        {
          if(e.CommandName == "ImageClick")
            {
                if (ddlSelectMedia.Text == "movies")
                {
                    Session["MovieReviews"] = true;
                    Session["ShowReviews"] = false;
                    Session["GameReviews"] = false;
                   
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
                else if(ddlSelectMedia.Text == "shows")
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
                        Session["TitleBudget"] = null;
                        Session["TitleIncome"] = null;
                        Session["TitleCreator"] = null;


                            lblError.Text = "saved session info";
                        Server.Transfer("Title.aspx");
                    }
                    else
                    {
                        lblError.Text = "table doesnt exist";
                    }
                }
                else if(ddlSelectMedia.Text == "videoGames")
                {
                    Session["MovieReviews"] = false;
                    Session["ShowReviews"] = false;
                    Session["GameReviews"] = true;
                
                    int GameID = Convert.ToInt32(e.CommandArgument);
                    Session["GameID"] = GameID;
                    DBConnect objDB = new DBConnect();
                    SqlCommand sqlComm = new SqlCommand();

                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "TP_GetGameByID";

                    SqlParameter member = new SqlParameter("@gameID", GameID);
                    member.Direction = ParameterDirection.Input;
                    member.SqlDbType = SqlDbType.VarChar;
                    sqlComm.Parameters.Add(member);


                    DataSet ds = objDB.GetDataSetUsingCmdObj(sqlComm);

                    if (ds.Tables[0].Rows.Count == 1) //member record found
                    {
                        Session["TitleName"] = ds.Tables[0].Rows[0]["Video_Game_Name"].ToString();
                        Session["TitleImage"] = ds.Tables[0].Rows[0]["Video_Game_Image"].ToString();
                        Session["TitleYear"] = ds.Tables[0].Rows[0]["Video_Game_Year"].ToString();
                        Session["TitleDescription"] = ds.Tables[0].Rows[0]["Video_Game_Description"].ToString();
                        Session["TitleRunTime"] = null;
                        Session["TitleGenre"] = ds.Tables[0].Rows[0]["Video_Game_Genre"].ToString();
                        Session["TitleAgeRating"] = ds.Tables[0].Rows[0]["Video_Game_Age_Rating"].ToString();
                        Session["TitleBudget"] = null;
                        Session["TitleIncome"] = null;
                        Session["TitleCreator"] = ds.Tables[0].Rows[0]["Video_Game_Creator"].ToString();


                        lblError.Text = "saved session info";
                        Server.Transfer("Title.aspx");
                    }
                    else
                    {
                        lblError.Text = "table doesnt exist";
                    }
                }
                else if (ddlSelectMedia.Text == "actors")
                {
                    int actorID = Convert.ToInt32(e.CommandArgument);
                    Session["ActorSelectedID"] = actorID;
                    DBConnect objDB = new DBConnect();
                    SqlCommand sqlComm = new SqlCommand();

                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "TP_GetActorByID";

                    SqlParameter member = new SqlParameter("@actorID", actorID);
                    member.Direction = ParameterDirection.Input;
                    member.SqlDbType = SqlDbType.VarChar;
                    sqlComm.Parameters.Add(member);


                    DataSet ds = objDB.GetDataSetUsingCmdObj(sqlComm);

                    if (ds.Tables[0].Rows.Count == 1) //member record found
                    {
                        Session["ActorID"] = ds.Tables[0].Rows[0]["Actor_ID"].ToString();
                        Session["ActorName"] = ds.Tables[0].Rows[0]["Actor_Name"].ToString();
                        Session["ActorImage"] = ds.Tables[0].Rows[0]["Actor_Image"].ToString();
                        Session["ActorDescription"] = ds.Tables[0].Rows[0]["Actor_Description"].ToString();
                        Session["ActorHeight"] = ds.Tables[0].Rows[0]["Actor_Height"].ToString();
                        Session["ActorDOB"] = ds.Tables[0].Rows[0]["Actor_DOB"].ToString();
                        Session["ActorBirthCity"] = ds.Tables[0].Rows[0]["Actor_Birth_City"].ToString();
                        Session["ActorBirthState"] = ds.Tables[0].Rows[0]["Actor_Birth_State"].ToString();
                        Session["ActorBirthCountry"] = ds.Tables[0].Rows[0]["Actor_Birth_Country"].ToString();

                        lblError.Text = "saved session info";
                        Server.Transfer("Actor.aspx");
                    }
                    else
                    {
                        lblError.Text = "table doesnt exist";
                    }
                }
            }
        }



        protected void btnFindMoviesRating_Click(object sender, EventArgs e)
        {
            //VALIDATE THE API REQUEST!!!//

            // Create an HTTP Web Request and get the HTTP Web Response from the server.
            WebRequest request = WebRequest.Create("http://localhost:55733/api/Service/FindUserByAgeRating/"/* + ddlRating.SelectedValue*/);
            WebResponse response = request.GetResponse();
            // Read the data from the Web Response, which requires working with streams.
            Stream theDataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(theDataStream);
            String data = reader.ReadToEnd();
            reader.Close();
            response.Close();
            // Deserialize a JSON string into a Team object.
            JavaScriptSerializer js = new JavaScriptSerializer();
            Movies[] movie = js.Deserialize<Movies[]>(data);
            // gvResults.DataSource = movie;
            // gvResults.DataBind();
            rptMovieSearchRes.DataSource = movie;
            rptMovieSearchRes.DataBind();
            lblError.Text = "";


        }
        protected void btnFindMoviesGenre_Click(object sender, EventArgs e)
        {

            // Create an HTTP Web Request and get the HTTP Web Response from the server.
            WebRequest request = WebRequest.Create("http://localhost:55733/api/Service/FindMoviesByGenre/"/* + ddlGenre.SelectedValue*/);
            WebResponse response = request.GetResponse();
            // Read the data from the Web Response, which requires working with streams.
            Stream theDataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(theDataStream);
            String data = reader.ReadToEnd();
            reader.Close();
            response.Close();
            // Deserialize a JSON string into a Team object.
            JavaScriptSerializer js = new JavaScriptSerializer();
            Movies[] movie = js.Deserialize<Movies[]>(data);
            // gvResults.DataSource = movie;
            // gvResults.DataBind();
            rptMovieSearchRes.DataSource = movie;
            rptMovieSearchRes.DataBind();
            lblError.Text = "";

        }

        protected void btnRandMovie_Click(object sender, EventArgs e)
        {
            //Session["RandomClick"] = "Movie";
            ddlSelectMedia.Text = "movies";
            //VALIDATE THE API REQUEST!!!//
            pnlHome.Visible = false;
            FooterNav.Visible = false;
            pnlMovieRepeater.Visible = true;         
        
            // Create an HTTP Web Request and get the HTTP Web Response from the server.
            WebRequest request = WebRequest.Create("https://localhost:44301/WebAPI/TermProject/GetRandomMovie/");
            WebResponse response = request.GetResponse();
            // Read the data from the Web Response, which requires working with streams.
            Stream theDataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(theDataStream);
            String data = reader.ReadToEnd();
            reader.Close();
            response.Close();
            // Deserialize a JSON string into a Team object.
            JavaScriptSerializer js = new JavaScriptSerializer();
            Movies[] movie = js.Deserialize<Movies[]>(data);
            // gvResults.DataSource = movie;
            // gvResults.DataBind();
            rptMovieSearchRes.DataSource = movie;
            rptMovieSearchRes.DataBind();
            lblError.Text = "";
        }

        protected void btnRandShow_Click(object sender, EventArgs e)
        {
            //Session["RandomClick"] = "Show";
            ddlSelectMedia.Text = "shows";
            //VALIDATE THE API REQUEST!!!//
            pnlHome.Visible = false;
            FooterNav.Visible = false;
            pnlShowRepeater.Visible = true;


            // Create an HTTP Web Request and get the HTTP Web Response from the server.
            WebRequest request = WebRequest.Create("https://localhost:44301/WebAPI/TermProject/GetRandomShow/");
            WebResponse response = request.GetResponse();
            // Read the data from the Web Response, which requires working with streams.
            Stream theDataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(theDataStream);
            String data = reader.ReadToEnd();
            reader.Close();
            response.Close();
            // Deserialize a JSON string into a Team object.
            JavaScriptSerializer js = new JavaScriptSerializer();
            TVShows[] show = js.Deserialize<TVShows[]>(data);
            // gvResults.DataSource = movie;
            // gvResults.DataBind();
            rptShowSearchRes.DataSource = show;
            rptShowSearchRes.DataBind();
            lblError.Text = "";
        }

        protected void btnRandGame_Click(object sender, EventArgs e)
        {
            //Session["RandomClick"] = "Show";
            ddlSelectMedia.Text = "videoGames";
            //VALIDATE THE API REQUEST!!!//
            pnlHome.Visible = false;
            FooterNav.Visible = false;
            pnlGameRepeater.Visible = true;

            // Create an HTTP Web Request and get the HTTP Web Response from the server.
            WebRequest request = WebRequest.Create("https://localhost:44301/WebAPI/TermProject/GetRandomGame/");
            WebResponse response = request.GetResponse();
            // Read the data from the Web Response, which requires working with streams.
            Stream theDataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(theDataStream);
            String data = reader.ReadToEnd();
            reader.Close();
            response.Close();
            // Deserialize a JSON string into a Team object.
            JavaScriptSerializer js = new JavaScriptSerializer();
            VideoGames[] game = js.Deserialize<VideoGames[]>(data);
            // gvResults.DataSource = movie;
            // gvResults.DataBind();
            rptGameSearchRes.DataSource = game;
            rptGameSearchRes.DataBind();
            lblError.Text = "";
        }

    }
}