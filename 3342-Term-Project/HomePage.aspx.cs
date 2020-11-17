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
                // Create an HTTP Web Request and get the HTTP Web Response from the server.
                string email = Session["MemberAccount"].ToString();
    
            }
        }
   
        protected void btnFindByName_Click(object sender, EventArgs e)
        {
            //VALIDATE THE API REQUEST!!!//

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
            rptHomeSearchRes.DataSource = movie;
            rptHomeSearchRes.DataBind();
            lblError.Text = "";

        }

        protected void Image_Click(object sender, CommandEventArgs e)
        {
          if(e.CommandName == "ImageClick")
            {
                int MovieID = Convert.ToInt32(e.CommandArgument);

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
                    Session["MovieName"] = ds.Tables[0].Rows[0]["Movie_Name"].ToString();
                    Session["MovieImage"] = ds.Tables[0].Rows[0]["Movie_Image"].ToString();
                    Session["MovieYear"] = ds.Tables[0].Rows[0]["Movie_Year"].ToString();
                    Session["MovieDescription"] = ds.Tables[0].Rows[0]["Movie_Description"].ToString();
                    Session["MovieRunTime"] = ds.Tables[0].Rows[0]["Movie_Age_Rating"].ToString();
                    Session["MovieGenre"] = ds.Tables[0].Rows[0]["Movie_Genre"].ToString();
                    Session["MovieAgeRating"] = ds.Tables[0].Rows[0]["Movie_Name"].ToString();
                    Session["MovieBudget"] = ds.Tables[0].Rows[0]["Movie_Budget"].ToString();
                    Session["MovieIncome"] = ds.Tables[0].Rows[0]["Movie_Income"].ToString();


                    ErrorText.Text = "saved session info";
                    Server.Transfer("Title.aspx");
                }
                else
                {
                    ErrorText.Text = "table doesnt exist";
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
            rptHomeSearchRes.DataSource = movie;
            rptHomeSearchRes.DataBind();
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
            rptHomeSearchRes.DataSource = movie;
            rptHomeSearchRes.DataBind();
            lblError.Text = "";

        }

        protected void repeaterResults_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

        }

        protected void btnRandMovie_Click(object sender, EventArgs e)
        {
            //VALIDATE THE API REQUEST!!!//
            Movies movie = new Movies();

            JavaScriptSerializer js = new JavaScriptSerializer();
            String randMovie = js.Serialize(movie);
            // Create an HTTP Web Request and get the HTTP Web Response from the server.
            WebRequest request = WebRequest.Create("https://localhost:44301/WebAPI/TermProject/GetRandomMovie/");
            request.Method = "GET";
            request.ContentLength = randMovie.Length;
            request.ContentType = "application/json";

            StreamWriter writer = new StreamWriter(request.GetRequestStream());
            writer.Write(randMovie);
            writer.Flush();
            writer.Close();
            WebResponse response = request.GetResponse();
            // Read the data from the Web Response, which requires working with streams.
            Stream theDataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(theDataStream);
            String data = reader.ReadToEnd();
            reader.Close();
            response.Close();
            // Deserialize a JSON string into a Team object.
            //JavaScriptSerializer js = new JavaScriptSerializer();
            //Movies[] movie = js.Deserialize<Movies[]>(data);
            //gvResults.DataSource = Movie;
            // gvResults.DataBind();
            rptHomeSearchRes.DataSource = movie;
            rptHomeSearchRes.DataBind();
            lblError.Text = "";
        }
    }
}