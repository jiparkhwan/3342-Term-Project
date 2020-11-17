using ClassLibrary;
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
            pnlEditorsPicks.Visible = false;
            RepeaterPanel.Visible = true;

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
            //gvResults.DataSource = Movie;
            // gvResults.DataBind();
            rptHomeSearchRes.DataSource = movie;
            rptHomeSearchRes.DataBind();
            lblError.Text = "";
        }
    }
}