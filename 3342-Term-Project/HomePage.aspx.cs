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
            form1.Visible = true;
            pnlFindFriendsName.Visible = true;
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
     
  

   
        protected void btnFindMovieName_Click(object sender, EventArgs e)
        {
            //VALIDATE THE API REQUEST!!!//

            // Create an HTTP Web Request and get the HTTP Web Response from the server.
            WebRequest request = WebRequest.Create("http://localhost:55733/api/Service/FindMoviesByName/" + txtMovieName.Text);
           // +Session["Email"].ToString() + "/" + txtMovieName.Text);
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
            repeaterResults.DataSource = movie;
            repeaterResults.DataBind();
            lblFindFriendsErrorMessage.Text = "";
        }

        protected void btnFindMoviesRating_Click(object sender, EventArgs e)
        {
            //VALIDATE THE API REQUEST!!!//

            // Create an HTTP Web Request and get the HTTP Web Response from the server.
            WebRequest request = WebRequest.Create("http://localhost:55733/api/Service/FindUserByAgeRating/" + ddlRating.SelectedValue);
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
            repeaterResults.DataSource = movie;
            repeaterResults.DataBind();
            lblFindFriendsErrorMessage.Text = "";


        }
        protected void btnFindMoviesGenre_Click(object sender, EventArgs e)
        {

            // Create an HTTP Web Request and get the HTTP Web Response from the server.
            WebRequest request = WebRequest.Create("http://localhost:55733/api/Service/FindMoviesByGenre/" + ddlGenre.SelectedValue);
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
            repeaterResults.DataSource = movie;
            repeaterResults.DataBind();
            lblFindFriendsErrorMessage.Text = "";

        }
        /*
        protected void gvResults_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "viewProfile")
            {
                int rowNum = int.Parse(e.CommandArgument.ToString());
                Session.Add("TargetEmail", gvResults.DataKeys[rowNum]["Email"].ToString());
                Server.Transfer("ViewProfile.aspx");
            }
            else if (e.CommandName == "sendRequest")
            {
                //VALIDATE THE API REQUEST!!!//

                // Retrieve and display the value contained in the
                // BoundField for ProductNumber (column index 0) of the row the button was clicked
                string friendEmail = gvResults.DataKeys[Convert.ToInt32(e.CommandArgument)]["Email"].ToString();
                string userEmail = Session["Email"].ToString();
                // Create an HTTP Web Request and get the HTTP Web Response from the server.
                WebRequest request = WebRequest.Create("http://localhost:35664/api/SocialNetworkService/SendFriendRequest/" + userEmail + "/" + friendEmail);
                //WebRequest request = WebRequest.Create("http://cis-iis2.temple.edu/fall2018/cis3342_tug26951/TermProjectWS/api/SocialNetworkService/SendFriendRequest/" + userEmail + "/" + friendEmail);
                request.Method = "POST";
                request.ContentLength = 0;
                WebResponse response = request.GetResponse();
                // Read the data from the Web Response, which requires working with streams.
                Stream theDataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(theDataStream);
                String data = reader.ReadToEnd();
                reader.Close();
                response.Close();
                JavaScriptSerializer js = new JavaScriptSerializer();
                Boolean success = js.Deserialize<Boolean>(data);
                if (success == true)
                {
                    lblFindFriendsErrorMessage.Text = "Friend request sent.";
                }
                else
                {
                    lblFindFriendsErrorMessage.Text = "Cannot send request.";
                }
                if (Convert.ToInt32(Session["Action"]) == 1)
                {
                    // Create an HTTP Web Request and get the HTTP Web Response from the server.
                    request = WebRequest.Create("http://localhost:35664/api/SocialNetworkService/FindUserByName/" + Session["Email"].ToString() + "/" + txtFirstName.Text + "/" + txtLastName.Text);
                    //WebRequest request = WebRequest.Create("http://cis-iis2.temple.edu/fall2018/cis3342_tug26951/TermProjectWS/api/SocialNetworkService/FindUserByName/" + Session["Email"].ToString() + "/" + txtFirstName.Text + "/" + txtLastName.Text);
                    response = request.GetResponse();
                    // Read the data from the Web Response, which requires working with streams.
                    theDataStream = response.GetResponseStream();
                    reader = new StreamReader(theDataStream);
                    data = reader.ReadToEnd();
                    reader.Close();
                    response.Close();
                    // Deserialize a JSON string into a Team object.
                    js = new JavaScriptSerializer();
                    User[] users = js.Deserialize<User[]>(data);
                   // gvResults.DataSource = users;
                  //  gvResults.DataBind();
                    lblFindFriendsErrorMessage.Text = "";
                }
                if (Convert.ToInt32(Session["Action"]) == 2)
                {
                    // Create an HTTP Web Request and get the HTTP Web Response from the server.
                    request = WebRequest.Create("http://localhost:35664/api/SocialNetworkService/FindUserByLocation/" + Session["Email"].ToString() + "/" + txtCity.Text + "/" + ddlState.SelectedValue);
                    //WebRequest request = WebRequest.Create("http://cis-iis2.temple.edu/fall2018/cis3342_tug26951/TermProjectWS/api/SocialNetworkService/FindUserByLocation/" + Session["Email"].ToString() + "/" + txtCity.Text + "/" + ddlState.SelectedValue);
                    response = request.GetResponse();
                    // Read the data from the Web Response, which requires working with streams.
                    theDataStream = response.GetResponseStream();
                    reader = new StreamReader(theDataStream);
                    data = reader.ReadToEnd();
                    reader.Close();
                    response.Close();
                    // Deserialize a JSON string into a Team object.
                    js = new JavaScriptSerializer();
                    User[] users = js.Deserialize<User[]>(data);
                   // gvResults.DataSource = users;
                   // gvResults.DataBind();
                    lblFindFriendsErrorMessage.Text = "";
                }
                if (Convert.ToInt32(Session["Action"]) == 3)
                {
                    // Create an HTTP Web Request and get the HTTP Web Response from the server.
                    request = WebRequest.Create("http://localhost:35664/api/SocialNetworkService/FindUserByOrganization/" + Session["Email"].ToString() + "/" + txtOrganization.Text);
                    //WebRequest request = WebRequest.Create("http://cis-iis2.temple.edu/fall2018/cis3342_tug26951/TermProjectWS/api/SocialNetworkService/FindUserByOrganization/" + Session["Email"].ToString() + "/" + txtOrganization.Text);
                    response = request.GetResponse();
                    // Read the data from the Web Response, which requires working with streams.
                    theDataStream = response.GetResponseStream();
                    reader = new StreamReader(theDataStream);
                    data = reader.ReadToEnd();
                    reader.Close();
                    response.Close();
                    // Deserialize a JSON string into a Team object.
                    js = new JavaScriptSerializer();
                    User[] users = js.Deserialize<User[]>(data);
                    gvResults.DataSource = users;
                    gvResults.DataBind();
                    lblFindFriendsErrorMessage.Text = "";
                }
            }
        }

        protected void gvPeopleYouMayKnow_SelectedIndexChanged(object sender, EventArgs e)
        {
            //VALIDATE THE API REQUEST!!!//

            // Retrieve and display the value contained in the
            // BoundField for ProductNumber (column index 0) of the row the button was clicked
            string friendEmail = gvPeopleYouMayKnow.DataKeys[gvPeopleYouMayKnow.SelectedIndex]["Email"].ToString();
            string userEmail = Session["Email"].ToString();
            // Create an HTTP Web Request and get the HTTP Web Response from the server.
            WebRequest request = WebRequest.Create("http://localhost:35664/api/SocialNetworkService/SendFriendRequest/" + userEmail + "/" + friendEmail);
            //WebRequest request = WebRequest.Create("http://cis-iis2.temple.edu/fall2018/cis3342_tug26951/TermProjectWS/api/SocialNetworkService/SendFriendRequest/" + userEmail + "/" + friendEmail);
            request.Method = "POST";
            request.ContentLength = 0;
            WebResponse response = request.GetResponse();
            // Read the data from the Web Response, which requires working with streams.
            Stream theDataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(theDataStream);
            String data = reader.ReadToEnd();
            reader.Close();
            response.Close();
            JavaScriptSerializer js = new JavaScriptSerializer();
            Boolean success = js.Deserialize<Boolean>(data);
            if (success == true)
            {
                lblPeopleYouMayKnowErrorMessage.Text = "Friend request sent.";
            }
            else
            {
                lblPeopleYouMayKnowErrorMessage.Text = "Cannot send request.";
            }
            // Create an HTTP Web Request and get the HTTP Web Response from the server.
            request = WebRequest.Create("http://localhost:35664/api/SocialNetworkService/GetFriendsOfFriends/" + Session["Email"].ToString());
            //WebRequest request = WebRequest.Create("http://cis-iis2.temple.edu/fall2018/cis3342_tug26951/TermProjectWS/api/SocialNetworkService/GetFriendsOfFriends/" + Session["Email"].ToString());
            response = request.GetResponse();
            // Read the data from the Web Response, which requires working with streams.
            theDataStream = response.GetResponseStream();
            reader = new StreamReader(theDataStream);
            data = reader.ReadToEnd();
            reader.Close();
            response.Close();
            // Deserialize a JSON string into a Team object.
            js = new JavaScriptSerializer();
            User[] users = js.Deserialize<User[]>(data);
            gvPeopleYouMayKnow.DataSource = users;
            gvPeopleYouMayKnow.DataBind();

        }
        */

    }
}