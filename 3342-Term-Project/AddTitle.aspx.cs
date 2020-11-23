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
            }
            else if(Session["AddShow"] != null)
            {
                pnlAddMovie.Visible = false;
                pnlAddShow.Visible = true;
                pnlAddGame.Visible = false;
            }
            else if(Session["AddGame"] != null)
            {
                pnlAddMovie.Visible = false;
                pnlAddShow.Visible = false;
                pnlAddGame.Visible = true;
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (Session["AddMovie"] != null)
            {
                Movies movie = new Movies();

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
            }
        }

        protected void ddlAddMovieYear_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlAddShowYearsStart_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}