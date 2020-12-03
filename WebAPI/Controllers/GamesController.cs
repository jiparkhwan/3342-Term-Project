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
    [Route("WebAPI/game")]
    public class GamesController : Controller
    {
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
        } //end of getgamesbyname

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
        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpGet("GetGameCast/{gameID}/")] //Route: WebAPI/TermProject/GetShowCast
        public List<Roles> GetGameCast(int gameID)
        {
            DataSet myDS = new DataSet();
            StoredProcedures stoPros = new StoredProcedures();

            myDS = stoPros.getCastByGameID(gameID);
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

    }
}
