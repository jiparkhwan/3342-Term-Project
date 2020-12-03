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
    [Route("WebAPI/actors")]
    public class ActorsController : Controller
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

        //BEGIN POST REQUESTS ->
        [HttpPost()]
        [HttpPost("AddActor")]
        public Boolean AddActor([FromBody]Actors actors)
        {
            if (actors != null)
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

    }
}
