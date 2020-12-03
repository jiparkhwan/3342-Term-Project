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
    [Route("WebAPI/[controller]")]
    public class TermProjectController : Controller
    {
        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpGet]
        [HttpGet("GetActors")] //Route: WebAPI/TermProject/GetActors/
        public List<Actors> GetActors()
        {
            DataSet myDS = new DataSet();
            StoredProcedures stoPros = new StoredProcedures();

            //string query = "SELECT * FROM TP_Actor";

            myDS = stoPros.getAllActors();

            DBConnect objDB = new DBConnect();
            //DataSet ds = objDB.GetDataSet(query);

            Actors actor = new Actors();
            List<Actors> dpts = new List<Actors>();

            foreach (DataRow dr in myDS.Tables[0].Rows)
            {
                actor = new Actors();
                actor.ActorID = int.Parse(dr["Actor_ID"].ToString());
                actor.ActorName = dr["Actor_Name"].ToString();
                actor.ActorBirthCity = dr["Actor_Birth_City"].ToString();
                actor.ActorBirthCountry = dr["Actor_Birth_Country"].ToString();
                actor.ActorBirthState = dr["Actor_Birth_State"].ToString();
                actor.ActorDOB = dr["Actor_DOB"].ToString();
                actor.ActorHeight = dr["Actor_Height"].ToString();
                actor.ActorImage = dr["Actor_Image"].ToString();
                actor.ActorDescription = dr["Actor_Description"].ToString();


                dpts.Add(actor);
            }
            return dpts;
        } //end of GetActors

        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpGet("GetActorByName/{actorName}/")] //Route: WebAPI/TermProject/GetActorByName/
        public List<Actors> GetActorByName(string actorName)
        {
            DataSet myDS = new DataSet();
            StoredProcedures stoPros = new StoredProcedures();

            //string query = "SELECT * FROM TP_Actor";

            myDS = stoPros.getActorByName(actorName);

            DBConnect objDB = new DBConnect();
            //DataSet ds = objDB.GetDataSet(query);

            Actors actor = new Actors();
            List<Actors> dpts = new List<Actors>();

            foreach (DataRow dr in myDS.Tables[0].Rows)
            {
                actor = new Actors();
                actor.ActorID = int.Parse(dr["Actor_ID"].ToString());
                actor.ActorName = dr["Actor_Name"].ToString();
                actor.ActorBirthCity = dr["Actor_Birth_City"].ToString();
                actor.ActorBirthCountry = dr["Actor_Birth_Country"].ToString();
                actor.ActorBirthState = dr["Actor_Birth_State"].ToString();
                actor.ActorDOB = dr["Actor_DOB"].ToString();
                actor.ActorHeight = dr["Actor_Height"].ToString();
                actor.ActorImage = dr["Actor_Image"].ToString();
                actor.ActorDescription = dr["Actor_Description"].ToString();


                dpts.Add(actor);
            }
            return dpts;
        } //end of GetActors

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

        //Retreives random movie from database and prints all information to browser
        /*[Produces("application/json")]
        [Consumes("application/json")]
        [HttpGet("GetRandomMovie")] //Route: WebAPI/TermProject/GetRandomMovie/
        public List<Movies> GetRandomMovie()
        {
            DataSet myDS = new DataSet();
            StoredProcedures stoPros = new StoredProcedures();

            myDS = stoPros.getRandMovie();

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
        }*/

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
        [HttpGet("GetAllActorsRoles/{actorID}/")] //Route: WebAPI/TermProject/
        public List<Roles> GetAllActorsRoles(int actorID)
        {
            DataSet myDS = new DataSet();
            StoredProcedures stoPros = new StoredProcedures();

            myDS = stoPros.getActorRolesByID(actorID);
            DBConnect objDB = new DBConnect();

            Roles role = new Roles();
            List<Roles> dpts = new List<Roles>();

            foreach (DataRow dr in myDS.Tables[0].Rows)
            {
                role = new Roles();
                role.role = dr["Role"].ToString();
                role.actorID = int.Parse(dr["Actor_ID"].ToString());
                if (dr["Movie_ID"].ToString() != "")
                {
                    role.movieID = int.Parse(dr["Movie_ID"].ToString());
                }
                if (dr["Movie_Name"].ToString() != "")
                {
                    role.movieName = dr["Movie_Name"].ToString();
                }
                if (dr["Movie_Image"].ToString() != "")
                {
                    role.titleImage = dr["Movie_Image"].ToString();
                }
                if (dr["Movie_Year"].ToString() != "")
                {
                    role.tvShowYears = dr["Movie_Year"].ToString();
                }
                if (dr["TV_Show_Image"].ToString() != "")
                {
                    role.titleImage = dr["TV_Show_Image"].ToString();
                }
                if (dr["TV_Show_ID"].ToString() != "")
                {
                    role.tvshowID = int.Parse(dr["TV_Show_ID"].ToString());
                }
                if (dr["TV_Show_Name"].ToString() != "")
                {
                    role.movieName = dr["TV_Show_Name"].ToString();
                }
                if (dr["TV_Show_Years"].ToString() != "")
                {
                    role.tvShowYears = dr["TV_Show_Years"].ToString();
                }
                if (dr["Video_Game_ID"].ToString() != "")
                {
                    role.videoGameID = int.Parse(dr["Video_Game_ID"].ToString());
                }
                if (dr["Video_Game_Name"].ToString() != "")
                {
                    role.movieName = dr["Video_Game_Name"].ToString();
                }
                if (dr["Video_Game_Image"].ToString() != "")
                {
                    role.titleImage = dr["Video_Game_Image"].ToString();
                }
                if (dr["Video_Game_Year"].ToString() != "")
                {
                    role.tvShowYears = dr["Video_Game_Year"].ToString();
                }

                dpts.Add(role);
            }
            return dpts;
        }


        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpGet("GetMovieCast/{movieID}/")] //Route: WebAPI/TermProject/
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


        [HttpGet("GetShows")] //Route: WebAPI/TermProject/GetShows/
        public List<TVShows> GetShows()
        {
            DataSet myDS = new DataSet();
            StoredProcedures stoPros = new StoredProcedures();

            myDS = stoPros.getAllShows();

            DBConnect objDB = new DBConnect();

            TVShows shows = new TVShows();
            List<TVShows> dpts = new List<TVShows>();

            foreach (DataRow dr in myDS.Tables[0].Rows)
            {
                shows = new TVShows();
                shows.ShowID = int.Parse(dr["TV_Show_ID"].ToString());
                shows.ShowImage = dr["TV_Show_Image"].ToString();
                shows.ShowName = dr["TV_Show_Name"].ToString();
                shows.ShowYears = dr["TV_Show_Years"].ToString();
                shows.ShowAgeRating = dr["TV_Show_Age_Rating"].ToString();
                shows.ShowRuntime = int.Parse(dr["TV_Show_Runtime"].ToString());
                shows.ShowGenre = dr["TV_Show_Genre"].ToString();
                shows.ShowDescription = dr["TV_Show_Description"].ToString();

                dpts.Add(shows);
            }
            return dpts;
        }

        //Retreives random TV Show from database and prints all information to browser
        /*[Produces("application/json")]
        [Consumes("application/json")]
        [HttpGet("GetRandomShow")] //Route: WebAPI/TermProject/GetRandomShow/
        public List<TVShows> GetRandomShow()
        {
            DataSet myDS = new DataSet();
            StoredProcedures stoPros = new StoredProcedures();

            myDS = stoPros.getRandShow();

            DBConnect objDB = new DBConnect();

            TVShows shows = new TVShows();
            List<TVShows> dpts = new List<TVShows>();

            foreach (DataRow dr in myDS.Tables[0].Rows)
            {
                shows = new TVShows();
                shows.ShowID = int.Parse(dr["TV_Show_ID"].ToString());
                shows.ShowImage = dr["TV_Show_Image"].ToString();
                shows.ShowName = dr["TV_Show_Name"].ToString();
                shows.ShowYears = dr["TV_Show_Years"].ToString();
                shows.ShowAgeRating = dr["TV_Show_Age_Rating"].ToString();
                shows.ShowRuntime = int.Parse(dr["TV_Show_Runtime"].ToString());
                shows.ShowGenre = dr["TV_Show_Genre"].ToString();
                shows.ShowDescription = dr["TV_Show_Description"].ToString();

                dpts.Add(shows);
            }
            return dpts;
        }*/

        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpGet("GetShowByName/{showName}/")] //Route: WebAPI/TermProject/GetShowByName/
        public List<TVShows> GetTVShowByName(string showName)
        {
            DataSet myDS = new DataSet();
            StoredProcedures stoPros = new StoredProcedures();

            //string query = "SELECT * FROM TP_Actor";

            myDS = stoPros.getShowByName(showName);

            DBConnect objDB = new DBConnect();
            //DataSet ds = objDB.GetDataSet(query);

            TVShows shows = new TVShows();
            List<TVShows> dpts = new List<TVShows>();

            foreach (DataRow dr in myDS.Tables[0].Rows)
            {
                shows = new TVShows();
                shows.ShowID = int.Parse(dr["TV_Show_ID"].ToString());
                shows.ShowImage = dr["TV_Show_Image"].ToString();
                shows.ShowName = dr["TV_Show_Name"].ToString();
                shows.ShowYears = dr["TV_Show_Years"].ToString();
                shows.ShowAgeRating = dr["TV_Show_Age_Rating"].ToString();
                shows.ShowRuntime = int.Parse(dr["TV_Show_Runtime"].ToString());
                shows.ShowGenre = dr["TV_Show_Genre"].ToString();
                shows.ShowDescription = dr["TV_Show_Description"].ToString();

                dpts.Add(shows);
            }
            return dpts;
        } //end of GetTVShows

        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpGet("GetGames")] //Route: WebAPI/TermProject/GetGames/
        public List<VideoGames> GetGames()
        {
            DataSet myDS = new DataSet();
            StoredProcedures stoPros = new StoredProcedures();

            myDS = stoPros.getAllGames();

            DBConnect objDB = new DBConnect();

            VideoGames videogames = new VideoGames();
            List<VideoGames> dpts = new List<VideoGames>();

            foreach (DataRow dr in myDS.Tables[0].Rows)
            {
                videogames = new VideoGames();
                videogames.GameID = int.Parse(dr["Video_Game_ID"].ToString());
                videogames.GameName = dr["Video_Game_Name"].ToString();
                videogames.GameYear = int.Parse(dr["Video_Game_Year"].ToString());
                videogames.GameDescription = dr["Video_Game_Description"].ToString();
                videogames.GameCreator = dr["Video_Game_Creator"].ToString();
                videogames.GameAgeRating = dr["Video_Game_Age_Rating"].ToString();
                videogames.GameGenre = dr["Video_Game_Genre"].ToString();
                videogames.GameImage = dr["Video_Game_Image"].ToString();
                dpts.Add(videogames);
            }
            return dpts;
        }

        //Retreives random video game from database and prints all information to browser
        /*[Produces("application/json")]
        [Consumes("application/json")]
        [HttpGet("GetRandomGame")] //Route: WebAPI/TermProject/GetRandomGame/
        public List<VideoGames> GetRandomGame()
        {
            DataSet myDS = new DataSet();
            StoredProcedures stoPros = new StoredProcedures();

            myDS = stoPros.getRandGame();

            DBConnect objDB = new DBConnect();

            VideoGames videogames = new VideoGames();
            List<VideoGames> dpts = new List<VideoGames>();

            foreach (DataRow dr in myDS.Tables[0].Rows)
            {
                videogames = new VideoGames();
                videogames.GameID = int.Parse(dr["Video_Game_ID"].ToString());
                videogames.GameName = dr["Video_Game_Name"].ToString();
                videogames.GameYear = int.Parse(dr["Video_Game_Year"].ToString());
                videogames.GameDescription = dr["Video_Game_Description"].ToString();
                videogames.GameCreator = dr["Video_Game_Creator"].ToString();
                videogames.GameAgeRating = dr["Video_Game_Age_Rating"].ToString();
                videogames.GameGenre = dr["Video_Game_Genre"].ToString();
                videogames.GameImage = dr["Video_Game_Image"].ToString();
                dpts.Add(videogames);
            }
            return dpts;
        }*/


        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpGet("GetGameByName/{gameName}/")] //Route: WebAPI/TermProject/GetGameByName/
        public List<VideoGames> GetGameByName(string gameName)
        {
            DataSet myDS = new DataSet();
            StoredProcedures stoPros = new StoredProcedures();

            //string query = "SELECT * FROM TP_Actor";

            myDS = stoPros.getGameByName(gameName);

            DBConnect objDB = new DBConnect();
            //DataSet ds = objDB.GetDataSet(query);

            VideoGames videogames = new VideoGames();
            List<VideoGames> dpts = new List<VideoGames>();

            foreach (DataRow dr in myDS.Tables[0].Rows)
            {
                videogames = new VideoGames();
                videogames.GameID = int.Parse(dr["Video_Game_ID"].ToString());
                videogames.GameName = dr["Video_Game_Name"].ToString();
                videogames.GameYear = int.Parse(dr["Video_Game_Year"].ToString());
                videogames.GameDescription = dr["Video_Game_Description"].ToString();
                videogames.GameCreator = dr["Video_Game_Creator"].ToString();
                videogames.GameAgeRating = dr["Video_Game_Age_Rating"].ToString();
                videogames.GameGenre = dr["Video_Game_Genre"].ToString();
                videogames.GameImage = dr["Video_Game_Image"].ToString();
                dpts.Add(videogames);
            }
            return dpts;
        } //end of GetTVShows



        /*[HttpPost]
        [HttpPost("SendValidationEmail/{userEmail}")]*/

        //searching movies START

        // GET api/Lexpark/FindMoviesByName
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
        public List<Movies> FindMovieByGenre( string movieGenre)
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



        //BEGIN POST REQUESTS ->
        [HttpPost()]
        [HttpPost("AddActor")]
        public Boolean AddActor([FromBody]Actors actors)
        {
            if(actors != null)
            {
                DBConnect objDB = new DBConnect();
                SqlCommand objCommand = new SqlCommand();

                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "TP_AddActor";
                objCommand.Parameters.AddWithValue("@Member_ID", actors.MemberID);

                objCommand.Parameters.AddWithValue("@Actor_Image", actors.ActorImage);
                objCommand.Parameters.AddWithValue("@Actor_Name", actors.ActorName);
                objCommand.Parameters.AddWithValue("@Actor_Description", actors.ActorDescription);
                objCommand.Parameters.AddWithValue("@Actor_Height", actors.ActorHeight);
                objCommand.Parameters.AddWithValue("@Actor_DOB", actors.ActorDOB);
                objCommand.Parameters.AddWithValue("@Actor_Birth_City", actors.ActorBirthCity);
                objCommand.Parameters.AddWithValue("@Actor_Birth_State", actors.ActorBirthState);
                objCommand.Parameters.AddWithValue("@Actor_Birth_Country", actors.ActorBirthCountry);

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

        [HttpPost("AddShow")]
        public Boolean AddShow([FromBody]TVShows show)
        {
            if (show != null)
            {
                DBConnect objDB = new DBConnect();
                SqlCommand objCommand = new SqlCommand();

                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "TP_AddShow";
                objCommand.Parameters.AddWithValue("@Member_ID", show.MemberID);

                objCommand.Parameters.AddWithValue("@Show_Image", show.ShowImage);
                objCommand.Parameters.AddWithValue("@Show_Name", show.ShowName);
                objCommand.Parameters.AddWithValue("@Show_Years", show.ShowYears);
                objCommand.Parameters.AddWithValue("@Show_Description", show.ShowDescription);
                objCommand.Parameters.AddWithValue("@Show_Runtime", show.ShowRuntime);
                objCommand.Parameters.AddWithValue("@Show_Age_Rating", show.ShowAgeRating);
                objCommand.Parameters.AddWithValue("@Show_Genre", show.ShowGenre);

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

        [HttpPost("AddGame")]
        public Boolean AddGame([FromBody]VideoGames game)
        {
            if (game != null)
            {
                DBConnect objDB = new DBConnect();
                SqlCommand objCommand = new SqlCommand();

                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "TP_AddGame";
                objCommand.Parameters.AddWithValue("@Member_ID", game.MemberID);

                objCommand.Parameters.AddWithValue("@Game_Image", game.GameImage);
                objCommand.Parameters.AddWithValue("@Game_Name", game.GameName);
                objCommand.Parameters.AddWithValue("@Game_Year", game.GameYear);
                objCommand.Parameters.AddWithValue("@Game_Genre", game.GameGenre);
                objCommand.Parameters.AddWithValue("@Game_Description", game.GameDescription);
                objCommand.Parameters.AddWithValue("@Game_Creator", game.GameCreator);
                objCommand.Parameters.AddWithValue("@Game_Age_Rating", game.GameAgeRating);

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

        //Route: WebAPI/TermProject/UpdateActor/
        [HttpPut("UpdateActor")]
        public Boolean UpdateActor([FromBody]Actors actors)
        {
            if (actors != null)
            {
                DBConnect objDB = new DBConnect();
                SqlCommand objCommand = new SqlCommand();

                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "TP_UpdateActor";
                objCommand.Parameters.AddWithValue("@Member_ID", actors.MemberID);

                objCommand.Parameters.AddWithValue("@Actor_ID", actors.ActorID);
                objCommand.Parameters.AddWithValue("@Actor_Image", actors.ActorImage);
                objCommand.Parameters.AddWithValue("@Actor_Name", actors.ActorName);
                objCommand.Parameters.AddWithValue("@Actor_Description", actors.ActorDescription);
                objCommand.Parameters.AddWithValue("@Actor_Height", actors.ActorHeight);
                objCommand.Parameters.AddWithValue("@Actor_DOB", actors.ActorDOB);
                objCommand.Parameters.AddWithValue("@Actor_Birth_City", actors.ActorBirthCity);
                objCommand.Parameters.AddWithValue("@Actor_Birth_State", actors.ActorBirthState);
                objCommand.Parameters.AddWithValue("@Actor_Birth_Country", actors.ActorBirthCountry);

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

        //Route: WebAPI/TermProject/UpdateShow/
        [HttpPut("UpdateShow")]
        public Boolean UpdateShow([FromBody]TVShows show)
        {
            if (show != null)
            {
                DBConnect objDB = new DBConnect();
                SqlCommand objCommand = new SqlCommand();

                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "TP_UpdateShow";
                objCommand.Parameters.AddWithValue("@Member_ID", show.MemberID);

                objCommand.Parameters.AddWithValue("@Show_ID", show.ShowID);
                objCommand.Parameters.AddWithValue("@Show_Image", show.ShowImage);
                objCommand.Parameters.AddWithValue("@Show_Name", show.ShowName);
                objCommand.Parameters.AddWithValue("@Show_Years", show.ShowYears);
                objCommand.Parameters.AddWithValue("@Show_Age_Rating", show.ShowAgeRating);
                objCommand.Parameters.AddWithValue("@Show_Runtime", show.ShowRuntime);
                objCommand.Parameters.AddWithValue("@Show_Genre", show.ShowGenre);
                objCommand.Parameters.AddWithValue("@Show_Description", show.ShowDescription);

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

        //Route: WebAPI/TermProject/UpdateGame/
        [HttpPut("UpdateGame")]
        public Boolean UpdateGame([FromBody]VideoGames game)
        {
            if (game != null)
            {
                DBConnect objDB = new DBConnect();
                SqlCommand objCommand = new SqlCommand();

                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "TP_UpdateGame";
                objCommand.Parameters.AddWithValue("@Member_ID", game.MemberID);

                objCommand.Parameters.AddWithValue("@Game_ID", game.GameID);
                objCommand.Parameters.AddWithValue("@Game_Image", game.GameImage);
                objCommand.Parameters.AddWithValue("@Game_Name", game.GameName);
                objCommand.Parameters.AddWithValue("@Game_Year", game.GameYear);
                objCommand.Parameters.AddWithValue("@Game_Genre", game.GameGenre);
                objCommand.Parameters.AddWithValue("@Game_Description", game.GameDescription);
                objCommand.Parameters.AddWithValue("@Game_Creator", game.GameCreator);
                objCommand.Parameters.AddWithValue("@Game_Age_Rating", game.GameAgeRating);

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


        //start deletes:
        [HttpDelete]
        [HttpDelete("DeleteActor/{id}")]  //Route: WebAPI/TermProject/DeleteActor/
        public Boolean DeleteActor(int id)
        {
            int retVal = StoredProcedures.DeleteActor(id);
            if (retVal > 0)
                return true;
            else
                return false;
        }


        [HttpDelete("DeleteReview/{id}")]  //Route: WebAPI/TermProject/DeleteReview/
        public Boolean DeleteReview(int id)
        {
            int retVal = StoredProcedures.DeleteReview(id);

            if (retVal > 0)
                return true;
            else
                return false;
        }

    } //end of class
} //end of namespace