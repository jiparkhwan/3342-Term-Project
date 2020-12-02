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
    public partial class AddTitle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            bind_year_ddl();

            if(Session["AddMovie"] != null)
            {
                pnlAddMovie.Visible = true;
                pnlAddShow.Visible = false;
                pnlAddGame.Visible = false;

                Session["NewMovieInfo"] = "EditMovie";
                txtAddMovieImage.Text = Session["Edit_Image"].ToString();
                txtAddMovieName.Text = Session["Edit_Name"].ToString();
                ddlAddMovieAgeRange.Text = Session["Edit_Age_Rating"].ToString();
                ddlAddMovieYear.Text = Session["Edit_Year"].ToString();
                txtAddMovieRuntime.Text = Session["Edit_Runtime"].ToString();
                ddlAddMovieGenre.Text = Session["Edit_Genre"].ToString();
                txtAddMovieBudget.Text = Session["Edit_Budget"].ToString();
                txtAddMovieIncome.Text = Session["Edit_Income"].ToString();
                txtAddMovieDescription.Text = Session["Edit_Description"].ToString();
                Session["AddMovie"] = null;
            }
            else if(Session["AddShow"] != null)
            {
                pnlAddMovie.Visible = false;
                pnlAddShow.Visible = true;
                pnlAddGame.Visible = false;

                Session["NewShowInfo"] = "EditShow";
                txtAddShowImage.Text = Session["Edit_Image"].ToString();
                txtAddShowName.Text = Session["Edit_Name"].ToString();
                ddlAddShowAgeRating.Text = Session["Edit_Age_Rating"].ToString();
                string startDate = Session["Edit_Year"].ToString().Substring(0,4);
                string endDate = Session["Edit_Year"].ToString().Substring(5);
                ddlAddShowYearsStart.Text = startDate;
                ddlAddShowYearsEnd.Text = endDate;
                txtAddShowRuntime.Text = Session["Edit_Runtime"].ToString();
                ddlAddShowGenre.Text = Session["Edit_Genre"].ToString();
                txtAddShowDescription.Text = Session["Edit_Description"].ToString();
                Session["AddShow"] = null;
            }
            else if(Session["AddGame"] != null)
            {
                pnlAddMovie.Visible = false;
                pnlAddShow.Visible = false;
                pnlAddGame.Visible = true;

                Session["NewGameInfo"] = "EditGame";
                txtAddGameImage.Text = Session["Edit_Image"].ToString();
                txtAddGameName.Text = Session["Edit_Name"].ToString();
                ddlAddGameAgeRating.Text = Session["Edit_Age_Rating"].ToString();
                ddlAddGameYear.Text = Session["Edit_Year"].ToString();
                ddlAddGameGenre.Text = Session["Edit_Genre"].ToString();
                txtAddGameCreator.Text = Session["Edit_Creator"].ToString();
                txtAddGameDescription.Text = Session["Edit_Description"].ToString();
                Session["AddGame"] = null;
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            if (Session["NewMovieInfo"] != null)
            {
                Movies movie = new Movies();

                movie.memberID = Convert.ToInt32(Session["MemberID"].ToString());
                movie.movieID = Convert.ToInt32(Session["Edit_ID"].ToString());
                movie.movieImage = txtAddMovieImage.Text;
                movie.movieName = txtAddMovieName.Text;
                movie.movieYear = Convert.ToInt32(ddlAddMovieYear.Text);
                movie.movieDescription = txtAddMovieDescription.Text;
                movie.movieRuntime = Convert.ToInt32(txtAddMovieRuntime.Text);
                movie.movieAgeRating = ddlAddMovieAgeRange.Text;
                movie.movieGenre = ddlAddMovieGenre.Text;
                movie.movieBudget = float.Parse(txtAddMovieBudget.Text);
                movie.movieIncome = float.Parse(txtAddMovieIncome.Text);

                JavaScriptSerializer js = new JavaScriptSerializer();

                String jsonMovie = js.Serialize(movie);

                try
                {
                    if (Session["NewMovieInfo"] != null)
                    {
                        WebRequest request = WebRequest.Create("https://localhost:44301/WebAPI/TermProject/UpdateMovie/");
                        request.Method = "PUT";
                        request.ContentLength = jsonMovie.Length;
                        request.ContentType = "application/json";

                        // Write the JSON data to the Web Request
                        StreamWriter writer = new StreamWriter(request.GetRequestStream());
                        writer.Write(jsonMovie);
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
                            lblDisplay.Text = "The movie was successfully edited.";
                        else
                            lblDisplay.Text = "Make sure you are only editting your own added listing!";
                    }
                    else
                    {
                        WebRequest request = WebRequest.Create("https://localhost:44301/WebAPI/TermProject/AddMovie/");
                        request.Method = "POST";
                        request.ContentLength = jsonMovie.Length;
                        request.ContentType = "application/json";

                        // Write the JSON data to the Web Request
                        StreamWriter writer = new StreamWriter(request.GetRequestStream());
                        writer.Write(jsonMovie);
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
                            lblDisplay.Text = "The movie was successfully saved to the database.";
                        else
                            lblDisplay.Text = "A problem occurred while adding the movie to the database. The data wasn't recorded.";
                    }
                }
                catch (Exception ex)
                {
                    lblDisplay.Text = "Error: " + ex.Message;
                }
            }
            else if(Session["NewShowInfo"] != null)
            {
                TVShows show = new TVShows();
                show.MemberID = Convert.ToInt32(Session["MemberID"].ToString());

                show.ShowID = Convert.ToInt32(Session["Edit_ID"].ToString());
                show.ShowImage = txtAddShowImage.Text;
                show.ShowName = txtAddShowName.Text;
                show.ShowYears = ddlAddShowYearsStart.Text + "-" + ddlAddShowYearsEnd.Text;
                show.ShowAgeRating = ddlAddShowAgeRating.Text;
                show.ShowRuntime = Convert.ToInt32(txtAddShowRuntime.Text);
                show.ShowGenre = ddlAddShowGenre.Text;
                show.ShowDescription = txtAddShowDescription.Text;

                JavaScriptSerializer js = new JavaScriptSerializer();

                String jsonShow = js.Serialize(show);

                try
                {
                    if (Session["NewShowInfo"] != null)
                    {
                        WebRequest request = WebRequest.Create("https://localhost:44301/WebAPI/TermProject/UpdateShow/");
                        request.Method = "PUT";
                        request.ContentLength = jsonShow.Length;
                        request.ContentType = "application/json";

                        // Write the JSON data to the Web Request
                        StreamWriter writer = new StreamWriter(request.GetRequestStream());
                        writer.Write(jsonShow);
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
                            lblDisplay.Text = "The Show was successfully edited.";
                        else
                            lblDisplay.Text = "Make sure you are only editting your own added listing!";
                    }
                    else
                    {
                        WebRequest request = WebRequest.Create("https://localhost:44301/WebAPI/TermProject/AddShow/");
                        request.Method = "POST";
                        request.ContentLength = jsonShow.Length;
                        request.ContentType = "application/json";

                        // Write the JSON data to the Web Request
                        StreamWriter writer = new StreamWriter(request.GetRequestStream());
                        writer.Write(jsonShow);
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
                            lblDisplay.Text = "The show was successfully saved to the database.";
                        else
                            lblDisplay.Text = "A problem occurred while adding the show to the database. The data wasn't recorded.";

                    }
                }
                catch (Exception ex)
                {
                    lblDisplay.Text = "Error: " + ex.Message;
                }
            }
            else if (Session["NewGameInfo"] != null)
            {
                VideoGames game = new VideoGames();
                game.MemberID = Convert.ToInt32(Session["MemberID"].ToString());

                game.GameID = Convert.ToInt32(Session["Edit_ID"].ToString());
                game.GameImage = txtAddGameImage.Text;
                game.GameName = txtAddGameName.Text;
                game.GameYear = Convert.ToInt32(ddlAddGameYear.Text);
                game.GameGenre = ddlAddGameGenre.Text;
                game.GameDescription = txtAddGameDescription.Text;
                game.GameCreator = txtAddGameCreator.Text;
                game.GameAgeRating = ddlAddGameAgeRating.Text;

                JavaScriptSerializer js = new JavaScriptSerializer();

                String jsonGame = js.Serialize(game);

                try
                {
                    if (Session["NewGameInfo"] != null)
                    {
                        WebRequest request = WebRequest.Create("https://localhost:44301/WebAPI/TermProject/UpdateGame/");
                        request.Method = "PUT";
                        request.ContentLength = jsonGame.Length;
                        request.ContentType = "application/json";

                        // Write the JSON data to the Web Request
                        StreamWriter writer = new StreamWriter(request.GetRequestStream());
                        writer.Write(jsonGame);
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
                            lblDisplay.Text = "The game was successfully edited.";
                        else
                            lblDisplay.Text = "Make sure you are only editting your own added listing!";
                    }
                    else
                    {
                        WebRequest request = WebRequest.Create("https://localhost:44301/WebAPI/TermProject/AddGame/");
                        request.Method = "POST";
                        request.ContentLength = jsonGame.Length;
                        request.ContentType = "application/json";

                        // Write the JSON data to the Web Request
                        StreamWriter writer = new StreamWriter(request.GetRequestStream());
                        writer.Write(jsonGame);
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
                            lblDisplay.Text = "The game was successfully saved to the database.";
                        else
                            lblDisplay.Text = "A problem occurred while adding the game to the database. The data wasn't recorded.";
                    }
                }

                catch (Exception ex)
                {
                    lblDisplay.Text = "Error: " + ex.Message;
                }
            }
        }

        private void bind_year_ddl()
        {
            int year = (System.DateTime.Now.Year);
            for (int intCount = year; intCount >= 1900; intCount--)
            {
                ddlAddMovieYear.Items.Add(intCount.ToString());
                ddlAddShowYearsStart.Items.Add(intCount.ToString());
                ddlAddShowYearsEnd.Items.Add(intCount.ToString());
                ddlAddGameYear.Items.Add(intCount.ToString());
            }
        }
    }
}