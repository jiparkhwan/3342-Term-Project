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
    [Route("WebAPI/show")]
    public class TVShowsController : Controller
    {
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

             [Produces("application/json")]
        [Consumes("application/json")]
        [HttpGet("GetShowCast/{showID}/")] //Route: WebAPI/TermProject/GetShowCast
        public List<Roles> GetShowCast(int showID)
        {
            DataSet myDS = new DataSet();
            StoredProcedures stoPros = new StoredProcedures();

            myDS = stoPros.getCastByShowID(showID);
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

