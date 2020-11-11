using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using ClassLibrary;
using Utilities;
using System.Data.SqlClient;

namespace WebAPI.Controllers
{
    [Route("api/service/Lexpark")]
    public class TermProjectController : Controller
    {
 

        // GET: api/service/Actors
        [HttpGet("GetActors")]
        public List<Actors> GetActors()
        {
            string query = "SELECT * FROM TP_Actor";

            DBConnect objDB = new DBConnect();
            DataSet ds = objDB.GetDataSet(query);

            Actors actor = new Actors();
            List<Actors> dpts = new List<Actors>();

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                actor = new Actors();
                actor.ActorID = int.Parse(dr["Actor_ID"].ToString());
                actor.FName1 = dr["Actor_FName"].ToString();
                actor.LName1 = dr["Actor_LName"].ToString();
                actor.BirthCity = dr["Actor_Birth_City"].ToString();
                actor.BirthCountry = dr["Actor_Birth_Country"].ToString();
                actor.BirthState = dr["Actor_Birth_State"].ToString();
                actor.DOB1 = dr["Actor_DOB"].ToString();
                actor.Height = dr["Actor_Height"].ToString();
                actor.Image = dr["Actor_Image"].ToString();
                actor.Description = dr["Actor_Description"].ToString();
                

                dpts.Add(actor);
            }
            return dpts;
        } //end of GetActors

        [HttpGet("GetMovies")]
        public List<Movies> GetMovies()
        {
            string query = "SELECT * FROM TP_Movies";

            DBConnect objDB = new DBConnect();
            DataSet ds = objDB.GetDataSet(query);

            Movies movies = new Movies();
            List<Movies> dpts = new List<Movies>();

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                movies = new Movies();
                movies.MovieID = int.Parse(dr["Movie_ID"].ToString());
                movies.Name = dr["Movie_Name"].ToString();
                movies.Year = int.Parse(dr["Movie_Year"].ToString());
                movies.Description = dr["Movie_Description"].ToString();
                movies.Runtime = int.Parse(dr["Movie_RunTime"].ToString());
                movies.AgeRating = dr["Movie_Age_Rating"].ToString();
                movies.Genre1 = dr["Movie_Genre"].ToString();
                movies.Budget1 = float.Parse(dr["Movie_Budget"].ToString());
                movies.Income = float.Parse(dr["Movie_Income"].ToString());
                movies.Image = dr["Movie_Image"].ToString();
                dpts.Add(movies);
            }
            return dpts;
        } //end of GetMovies



        [HttpGet("GetTVShows")]
        public List<TVShows> GetTVShows()
        {
            string query = "SELECT * FROM TP_Movies";

            DBConnect objDB = new DBConnect();
            DataSet ds = objDB.GetDataSet(query);

            TVShows shows = new TVShows();
            List<TVShows> dpts = new List<TVShows>();

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                shows = new TVShows();
                shows.ID1 = int.Parse(dr["TV_Show_ID"].ToString());
                shows.Image = dr["TV_Show_Image"].ToString();
                shows.Name1 = dr["TV_Show_Name"].ToString();
                shows.Years = dr["TV_Show_Years"].ToString();
                shows.AgeRating = dr["TV_Show_Age_Rating"].ToString();
                shows.Runtime = int.Parse(dr["TV_Show_Runtime"].ToString());
                shows.Genre = dr["TV_Show_Genre"].ToString();
                shows.Description =dr["TV_Show_Description"].ToString();
                
                dpts.Add(shows);
            }
            return dpts;
        } //end of GetTVSHOWS


        [HttpGet("GetVideoGames")]
        public List<VideoGames> GetVideoGames()
        {
            string query = "SELECT * FROM TP_Movies";

            DBConnect objDB = new DBConnect();
            DataSet ds = objDB.GetDataSet(query);

            VideoGames videogames = new VideoGames();
            List<VideoGames> dpts = new List<VideoGames>();

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                videogames = new VideoGames();
                videogames.VideoGameID = int.Parse(dr["Video_Game_ID"].ToString());
                videogames.Name = dr["Video_Game_Name"].ToString();
                videogames.Year = int.Parse(dr["Video_Game_Year"].ToString());
                videogames.Description = dr["Video_Game_Description"].ToString();
                videogames.Creator = dr["Video_Game_Creator"].ToString();
                videogames.AgeRating = dr["Video_Game_Age_Rating"].ToString();
                videogames.Genre = dr["Video_Game_Genre"].ToString();
                videogames.Image1 = dr["Video_Game_Image"].ToString();
                dpts.Add(videogames);
            }
            return dpts;
        } //end of GetVIDEOGAMES




        //BEGIN POSTS

        
    } //end of class
} //end of namespace

