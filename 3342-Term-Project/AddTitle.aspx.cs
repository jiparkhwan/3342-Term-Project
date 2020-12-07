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

            if (!IsPostBack)
            {
                if (Session["AddNewMovie"] != null)
                {
                    pnlAddMovie.Visible = true;
                    pnlAddShow.Visible = false;
                    pnlAddGame.Visible = false;
                 
                }
                else if (Session["AddNewShow"] != null)
                {
                    pnlAddMovie.Visible = false;
                    pnlAddShow.Visible = true;
                    pnlAddGame.Visible = false;
                    editorImage.ImageUrl = "Images/editorpickShow_2.jpg";
                }
                else if (Session["AddNewGame"] != null)
                {
                    pnlAddMovie.Visible = false;
                    pnlAddShow.Visible = false;
                    pnlAddGame.Visible = true;
                    editorImage.ImageUrl = "Images/editorpickGame_2.jpg";
                }
            }
            if (Session["UpdateMovie"] != null)
            {
                pnlAddMovie.Visible = true;
                pnlAddShow.Visible = false;
                pnlAddGame.Visible = false;

                lblAddMovieLabel.Text = "Edit Movie";
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
                Session["UpdateMovie"] = null;
            }
            else if(Session["UpdateShow"] != null)
            {
                pnlAddMovie.Visible = false;
                pnlAddShow.Visible = true;
                pnlAddGame.Visible = false;

                lblAddShowLabel.Text = "Edit TV Show";
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
                Session["UpdateShow"] = null;
                editorImage.ImageUrl = "Images/editorpickShow_2.jpg";
            }
            else if(Session["UpdateGame"] != null)
            {
                pnlAddMovie.Visible = false;
                pnlAddShow.Visible = false;
                pnlAddGame.Visible = true;

                lblAddVideoGameLabel.Text = "Edit Video Game";
                Session["NewGameInfo"] = "EditGame";
                txtAddGameImage.Text = Session["Edit_Image"].ToString();
                txtAddGameName.Text = Session["Edit_Name"].ToString();
                ddlAddGameAgeRating.Text = Session["Edit_Age_Rating"].ToString();
                ddlAddGameYear.Text = Session["Edit_Year"].ToString();
                ddlAddGameGenre.Text = Session["Edit_Genre"].ToString();
                txtAddGameCreator.Text = Session["Edit_Creator"].ToString();
                txtAddGameDescription.Text = Session["Edit_Description"].ToString();
                Session["UpdateGame"] = null;
                editorImage.ImageUrl = "Images/editorpickGame_2.jpg";
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            if (Session["NewMovieInfo"] != null || Session["AddNewMovie"] != null)
            {
                if(ddlAddMovieAgeRange.SelectedValue == "noneSelected")
                {
                    lblDisplay.Text = "Select an Age Rating";
                }
                else
                {
                    if (ddlAddMovieGenre.SelectedValue == "noneSelected")
                    {
                        lblDisplay.Text = "Select a Genre";
                    }
                    else
                    {
                        if (ddlAddMovieYear.SelectedValue == "noneSelected")
                        {
                            lblDisplay.Text = "Select a Year";
                        }
                        else
                        {
                            Movies movie = new Movies();

                            movie.memberID = Convert.ToInt32(Session["MemberID"].ToString());
                            if (Session["Edit_ID"] != null)
                            {
                                movie.movieID = Convert.ToInt32(Session["Edit_ID"].ToString());
                            }
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
                                    WebRequest request = WebRequest.Create("https://localhost:44301/WebAPI/movies/UpdateMovie/");
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
                                    {
                                        lblDisplay.Text = "The movie was successfully edited.";

                                        Response.Write("<script>alert('Movie Updated successfully')</script>");
                                    }

                                    else
                                        lblDisplay.Text = "Make sure you are only editting your own added listing!";
                                }
                                else
                                {
                                    WebRequest request = WebRequest.Create("https://localhost:44301/WebAPI/movies/AddMovie/");
                                    request.Method = "POST";
                                    
                                    request.ContentType = "application/json";
                                    request.ContentLength = jsonMovie.Length;

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
                                    {
                                        lblDisplay.Text = "The movie was successfully saved to the database.";

                                        Response.Write("<script>alert('Movie inserted successfully')</script>");
                                    }
                                    else
                                        lblDisplay.Text = "A problem occurred while adding the movie to the database. The data wasn't recorded.";
                                }
                            }
                            catch (Exception ex)
                            {
                                lblDisplay.Text = "Error: " + ex.Message;
                            }
                        }
                    }
                }
                Session["NewMovieInfo"] = null;
            }
            else if (Session["NewShowInfo"] != null || Session["AddNewShow"] != null)
            {
                if(ddlAddShowAgeRating.SelectedValue == "noneSelected")
                {
                    lblDisplay2.Text = "Please Select an Age Rating";
                }
                else
                {
                    if (ddlAddShowGenre.SelectedValue == "noneSelected")
                    {
                        lblDisplay2.Text = "Please Select a Genre";
                    }
                    else
                    {
                        if (ddlAddShowYearsStart.SelectedValue == "noneSelected")
                        {
                            lblDisplay2.Text = "Please Select Run Years Value";
                        }
                        else
                        {
                            if (ddlAddShowYearsEnd.SelectedValue == "noneSelected")
                            {
                                lblDisplay2.Text = "Please Select Run Years Value";
                            }
                            else
                            {
                                TVShows show = new TVShows();
                                show.MemberID = Convert.ToInt32(Session["MemberID"].ToString());

                                if (Session["Edit_ID"] != null)
                                {
                                    show.ShowID = Convert.ToInt32(Session["Edit_ID"].ToString());
                                }
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
                                        WebRequest request = WebRequest.Create("https://localhost:44301/WebAPI/show/UpdateShow/");
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
                                        {
                                            Response.Write("<script>alert('Show updated successfully')</script>");

                                        }
                                        //  lblDisplay.Text = "The Show was successfully edited.";
                                        else
                                            lblDisplay2.Text = "Make sure you are only editting your own added listing!";
                                    }
                                    else
                                    {
                                        WebRequest request = WebRequest.Create("https://localhost:44301/WebAPI/show/AddShow/");
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
                                        {
                                            Response.Write("<script>alert('Show inserted successfully')</script>");
                                        }
                                        //lblDisplay.Text = "The show was successfully saved to the database.";
                                        else
                                            lblDisplay2.Text = "A problem occurred while adding the show to the database. The data wasn't recorded.";

                                    }
                                }
                                catch (Exception ex)
                                {
                                    lblDisplay2.Text = "Error: " + ex.Message;
                                }
                            }
                        }
                    }
                }
                Session["NewShowInfo"] = null;
            }
            else if (Session["NewGameInfo"] != null || Session["AddNewGame"] != null)
            {
                if(ddlAddGameAgeRating.SelectedValue == "noneSelected")
                {
                    lblDisplay3.Text = "Please Select Age Rating";
                }
                else
                {
                    if (ddlAddGameGenre.SelectedValue == "noneSelected")
                    {
                        lblDisplay3.Text = "Please Select Genre";
                    }
                    else
                    {
                        if (ddlAddGameYear.SelectedValue == "noneSelected")
                        {
                            lblDisplay3.Text = "Please Select Release Year";
                        }
                        else
                        {
                            VideoGames game = new VideoGames();
                            game.MemberID = Convert.ToInt32(Session["MemberID"].ToString());

                            if (Session["Edit_ID"] != null)
                            {
                                game.GameID = Convert.ToInt32(Session["Edit_ID"].ToString());
                            }
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
                                    WebRequest request = WebRequest.Create("https://localhost:44301/WebAPI/game/UpdateGame/");
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
                                    {
                                        Response.Write("<script>alert('Game updated successfully')</script>");
                                    }
                                    //lblDisplay.Text = "The game was successfully edited.";
                                    else
                                        lblDisplay3.Text = "Make sure you are only editting your own added listing!";
                                }
                                else
                                {
                                    WebRequest request = WebRequest.Create("https://localhost:44301/WebAPI/game/AddGame/");
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
                                    {
                                        Response.Write("<script>alert('Game added successfully')</script>");
                                    }
                                      //lblDisplay.Text = "The game was successfully saved to the database.";
                                    else
                                        lblDisplay3.Text = "A problem occurred while adding the game to the database. The data wasn't recorded.";
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
            Session["NewGameInfo"] = null;
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

        protected void btnClearMovie_Click(object sender, EventArgs e)
        {
            txtAddMovieImage.Text = "";
            txtAddMovieName.Text = "";
            txtAddMovieRuntime.Text = "";
            txtAddMovieIncome.Text = "";
            txtAddMovieBudget.Text = "";
            txtAddMovieDescription.Text = "";
            ddlAddMovieAgeRange.SelectedValue = "noneSelected";
            ddlAddMovieGenre.SelectedValue = "noneSelected";
            ddlAddMovieYear.SelectedValue = "noneSelected";
        }
        protected void editorTimer_Tick(object sender, EventArgs e)
        {
            Random random = new Random();

            int rnd = random.Next(1, 5);
            if (pnlAddGame.Visible) { editorImage.ImageUrl = "Images/editorpickGame_" + rnd + ".jpg"; }
            else if (pnlAddShow.Visible) { editorImage.ImageUrl = "Images/editorpickShow_" + rnd + ".jpg"; }
            else if (pnlAddMovie.Visible) { editorImage.ImageUrl = "Images/editorpick_" + rnd + ".jpg"; }
         
        }

    }

}