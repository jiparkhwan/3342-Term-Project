using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Data;

using Utilities;
using System.Data.SqlClient;
using ClassLibrary;
using System.Web;

using WebAPI.Models;
using Movies = WebAPI.Models.Movies;
using Actors = WebAPI.Models.Actors;
using TVShows = WebAPI.Models.TVShows;
using VideoGames = WebAPI.Models.VideoGames;
namespace WebAPI.Controllers
{
    [Route("WebAPI/movies")]
    public class MoviesControllercs : Controller
    {

        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpGet("GetMovies")] //Route: WebAPI/TermProject/GetMovies/
        public List<Movies> GetMovies()
        {
            DataSet myDS = new DataSet();
            StoredProcedures stoPros = new StoredProcedures();

            myDS = stoPros.getAllMovies();

            DBConnect objDB = new DBConnect();

            Movies movies = new Movies();
            List<Movies> dpts = new List<Movies>();

            foreach (DataRow dr in myDS.Tables[0].Rows)
            {
                movies = new Movies();
                movies.movieID = int.Parse(dr["Movie_ID"].ToString());
                movies.movieName = dr["Movie_Name"].ToString();
                movies.movieImage = dr["Movie_Image"].ToString();
                movies.movieYear = int.Parse(dr["Movie_Year"].ToString());
                movies.movieDescription = dr["Movie_Description"].ToString();
                movies.movieRuntime = int.Parse(dr["Movie_RunTime"].ToString());
                movies.movieAgeRating = dr["Movie_Age_Rating"].ToString();
                movies.movieGenre = dr["Movie_Genre"].ToString();
                movies.movieBudget = float.Parse(dr["Movie_Budget"].ToString());
                movies.movieIncome = float.Parse(dr["Movie_Income"].ToString());

                dpts.Add(movies);
            }
            return dpts;
        }
        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpGet("GetMovieByName/{movieName}/")] //Route: WebAPI/TermProject/GetMovieByName/
        public List<Movies> GetMovieByName(string movieName)
        {
            DataSet myDS = new DataSet();
            StoredProcedures stoPros = new StoredProcedures();

            myDS = stoPros.getMovieByName(movieName);

            DBConnect objDB = new DBConnect();

            Movies movies = new Movies();
            List<Movies> dpts = new List<Movies>();

            foreach (DataRow dr in myDS.Tables[0].Rows)
            {
                movies = new Movies();
                movies.movieID = int.Parse(dr["Movie_ID"].ToString());
                movies.movieName = dr["Movie_Name"].ToString();
                movies.movieImage = dr["Movie_Image"].ToString();
                movies.movieYear = int.Parse(dr["Movie_Year"].ToString());
                movies.movieDescription = dr["Movie_Description"].ToString();
                movies.movieRuntime = int.Parse(dr["Movie_RunTime"].ToString());
                movies.movieAgeRating = dr["Movie_Age_Rating"].ToString();
                movies.movieGenre = dr["Movie_Genre"].ToString();
                movies.movieBudget = float.Parse(dr["Movie_Budget"].ToString());
                movies.movieIncome = float.Parse(dr["Movie_Income"].ToString());
                dpts.Add(movies);
            }
            return dpts;
        } //end of GetMovies

        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpGet("GetMovieCast/{movieID}")] //Route: WebAPI/TermProject/
        public List<Roles> GetMovieCast(int movieID)
        {
            DataSet myDS = new DataSet();
            StoredProcedures stoPros = new StoredProcedures();

            myDS = stoPros.getCastByMovieID(movieID);
            DBConnect objDB = new DBConnect();

            Roles role = new Roles();
            List<Roles> dpts = new List<Roles>();

            foreach (DataRow dr in myDS.Tables[0].Rows)
            {
                role = new Roles();
                role.role = dr["Role"].ToString();
                role.actorImage = dr["Actor_Image"].ToString();
                role.actorName = dr["Actor_Name"].ToString();
                role.actorID = int.Parse(dr["Actor_ID"].ToString());

                dpts.Add(role);
            }
            return dpts;
        }
        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpGet("FindMoviesByName/{movieName}")]
        public List<Movies> FindMoviesByName(string movieName)
        {
            // serviceHomepage .getbtnfindmoviename()
            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_FindMovieByName ";

            objCommand.Parameters.AddWithValue("@movieName", movieName);
            DataSet ds = objDB.GetDataSetUsingCmdObj(objCommand);
            List<Movies> list = new List<Movies>();
            Movies movies;
            foreach (DataRow record in ds.Tables[0].Rows)
            {
                movies = new Movies();
                movies.movieID = int.Parse(record["Movie_ID"].ToString());
                movies.movieName = record["Movie_Name"].ToString();
                movies.movieImage = record["Movie_Image"].ToString();
                movies.movieYear = int.Parse(record["Movie_Year"].ToString());
                movies.movieDescription = record["Movie_Description"].ToString();
                movies.movieRuntime = int.Parse(record["Movie_RunTime"].ToString());
                movies.movieAgeRating = record["Movie_Age_Rating"].ToString();
                movies.movieGenre = record["Movie_Genre"].ToString();
                movies.movieBudget = float.Parse(record["Movie_Budget"].ToString());
                movies.movieIncome = float.Parse(record["Movie_Income"].ToString());

                list.Add(movies);
            }
            return list;
        }

        // GET api/Lexpark/FindMovieByGenre
        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpGet("FindMoviesByGenre/{movieGenre}")]
        public List<Movies> FindMovieByGenre(string movieGenre)
        {
            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_FindMovieByGenre ";

            objCommand.Parameters.AddWithValue("@genre", movieGenre);
            DataSet ds = objDB.GetDataSetUsingCmdObj(objCommand);
            List<Movies> list = new List<Movies>();
            Movies movies;
            foreach (DataRow record in ds.Tables[0].Rows)
            {
                movies = new Movies();
                movies.movieID = int.Parse(record["Movie_ID"].ToString());
                movies.movieName = record["Movie_Name"].ToString();
                movies.movieImage = record["Movie_Image"].ToString();
                movies.movieYear = int.Parse(record["Movie_Year"].ToString());
                movies.movieDescription = record["Movie_Description"].ToString();
                movies.movieRuntime = int.Parse(record["Movie_RunTime"].ToString());
                movies.movieAgeRating = record["Movie_Age_Rating"].ToString();
                movies.movieGenre = record["Movie_Genre"].ToString();
                movies.movieBudget = float.Parse(record["Movie_Budget"].ToString());
                movies.movieIncome = float.Parse(record["Movie_Income"].ToString());

                list.Add(movies);
            }
            return list;
        }

        // GET api/Lexpark/FindMovieByAgeRating
        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpGet("FindUserByAgeRating/{ageRating}")]
        public List<Movies> FindMovieByAgeRating(string ID, string ageRating)
        {
            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_FindMovieByAgeRating ";

            objCommand.Parameters.AddWithValue("@AgeRating", ageRating);
            DataSet ds = objDB.GetDataSetUsingCmdObj(objCommand);
            List<Movies> list = new List<Movies>();
            Movies movies;
            foreach (DataRow record in ds.Tables[0].Rows)
            {
                movies = new Movies();
                movies.movieID = int.Parse(record["Movie_ID"].ToString());
                movies.movieName = record["Movie_Name"].ToString();
                movies.movieImage = record["Movie_Image"].ToString();
                movies.movieYear = int.Parse(record["Movie_Year"].ToString());
                movies.movieDescription = record["Movie_Description"].ToString();
                movies.movieRuntime = int.Parse(record["Movie_RunTime"].ToString());
                movies.movieAgeRating = record["Movie_Age_Rating"].ToString();
                movies.movieGenre = record["Movie_Genre"].ToString();
                movies.movieBudget = float.Parse(record["Movie_Budget"].ToString());
                movies.movieIncome = float.Parse(record["Movie_Income"].ToString());


                list.Add(movies);
            }
            return list;
        }
        //searching movies END
        [HttpPost("AddMovie")]
        public Boolean AddMovie([FromBody]Movies movie)
        {
            if (movie != null)
            {
                DBConnect objDB = new DBConnect();
                SqlCommand objCommand = new SqlCommand();

                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "TP_AddMovie";

                objCommand.Parameters.AddWithValue("@Member_ID", movie.memberID);
                objCommand.Parameters.AddWithValue("@Movie_Image", movie.movieImage);
                objCommand.Parameters.AddWithValue("@Movie_Name", movie.movieName);
                objCommand.Parameters.AddWithValue("@Movie_Year", movie.movieYear);
                objCommand.Parameters.AddWithValue("@Movie_Description", movie.movieDescription);
                objCommand.Parameters.AddWithValue("@Movie_Runtime", movie.movieRuntime);
                objCommand.Parameters.AddWithValue("@Movie_Age_Rating", movie.movieAgeRating);
                objCommand.Parameters.AddWithValue("@Movie_Genre", movie.movieGenre);
                objCommand.Parameters.AddWithValue("@Movie_Budget", movie.movieBudget);
                objCommand.Parameters.AddWithValue("@Movie_Income", movie.movieIncome);

                int retVal = objDB.DoUpdateUsingCmdObj(objCommand);

                if (retVal > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        //Route: WebAPI/TermProject/UpdateMovie/
        [HttpPut("UpdateMovie")]
        public Boolean UpdateMovie([FromBody]Movies movie)
        {
            if (movie != null)
            {
                DBConnect objDB = new DBConnect();
                SqlCommand objCommand = new SqlCommand();

                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "TP_UpdateMovie";
                objCommand.Parameters.AddWithValue("@Member_ID", movie.memberID);

                objCommand.Parameters.AddWithValue("@Movie_ID", movie.movieID);
                objCommand.Parameters.AddWithValue("@Movie_Image", movie.movieImage);
                objCommand.Parameters.AddWithValue("@Movie_Name", movie.movieName);
                objCommand.Parameters.AddWithValue("@Movie_Year", movie.movieYear);
                objCommand.Parameters.AddWithValue("@Movie_Description", movie.movieDescription);
                objCommand.Parameters.AddWithValue("@Movie_Runtime", movie.movieRuntime);
                objCommand.Parameters.AddWithValue("@Movie_Age_Rating", movie.movieAgeRating);
                objCommand.Parameters.AddWithValue("@Movie_Genre", movie.movieGenre);
                objCommand.Parameters.AddWithValue("@Movie_Budget", movie.movieBudget);
                objCommand.Parameters.AddWithValue("@Movie_Income", movie.movieIncome);

                int retVal = objDB.DoUpdateUsingCmdObj(objCommand);

                if (retVal > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
