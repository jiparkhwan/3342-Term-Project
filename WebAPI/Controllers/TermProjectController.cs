﻿using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Data;

using Utilities;
using System.Data.SqlClient;
using ClassLibrary;

namespace WebAPI.Controllers
{
    [Route("WebAPI/[controller]")]
    public class TermProjectController : Controller
    {

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
                movies.movieID = int.Parse(dr["Movie_ID"].ToString());
                movies.name = dr["Movie_Name"].ToString();
                movies.image = dr["Movie_Image"].ToString();
                movies.year = int.Parse(dr["Movie_Year"].ToString());
                movies.description = dr["Movie_Description"].ToString();
                movies.runtime = int.Parse(dr["Movie_RunTime"].ToString());
                movies.ageRating = dr["Movie_Age_Rating"].ToString();
                movies.Genre = dr["Movie_Genre"].ToString();
                movies.Budget = float.Parse(dr["Movie_Budget"].ToString());
                movies.income = float.Parse(dr["Movie_Income"].ToString());
                dpts.Add(movies);
            }
            return dpts;
        } //end of GetMovies



        [HttpGet("GetTVShows")]
        public List<TVShows> GetTVShows()
        {
            string query = "SELECT * FROM TP_TVShows";

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
            string query = "SELECT * FROM TP_VideoGames";

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
        /*[HttpPost]
        [HttpPost("SendValidationEmail/{userEmail}")]*/

        //searching movies START
    
    // GET api/Lexpark/FindMoviesByName
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
                movies.name = record["Movie_Name"].ToString();
                movies.image = record["Movie_Image"].ToString();
                movies.year = int.Parse(record["Movie_Year"].ToString());
                movies.description = record["Movie_Description"].ToString();
                movies.runtime = int.Parse(record["Movie_RunTime"].ToString());
                movies.ageRating = record["Movie_Age_Rating"].ToString();
                movies.Genre = record["Movie_Genre"].ToString();
                movies.Budget = float.Parse(record["Movie_Budget"].ToString());
                movies.income = float.Parse(record["Movie_Income"].ToString());

                list.Add(movies);
            }
            return list;
        }
    // GET api/Lexpark/FindMovieByGenre
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
                movies.name = record["Movie_Name"].ToString();
                movies.image = record["Movie_Image"].ToString();
                movies.year = int.Parse(record["Movie_Year"].ToString());
                movies.description = record["Movie_Description"].ToString();
                movies.runtime = int.Parse(record["Movie_RunTime"].ToString());
                movies.ageRating = record["Movie_Age_Rating"].ToString();
                movies.Genre = record["Movie_Genre"].ToString();
                movies.Budget = float.Parse(record["Movie_Budget"].ToString());
                movies.income = float.Parse(record["Movie_Income"].ToString());

                list.Add(movies);
            }
            return list;
        }
        // GET api/Lexpark/FindMovieByAgeRating
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
                movies.name = record["Movie_Name"].ToString();

                movies.movieID = int.Parse(record["Movie_ID"].ToString());
                movies.name = record["Movie_Name"].ToString();
                movies.image = record["Movie_Image"].ToString();
                movies.year = int.Parse(record["Movie_Year"].ToString());
                movies.description = record["Movie_Description"].ToString();
                movies.runtime = int.Parse(record["Movie_RunTime"].ToString());
                movies.ageRating = record["Movie_Age_Rating"].ToString();
                movies.Genre = record["Movie_Genre"].ToString();
                movies.Budget = float.Parse(record["Movie_Budget"].ToString());
                movies.income = float.Parse(record["Movie_Income"].ToString());

                list.Add(movies);
            }
            return list;
        }
        //searching movies END



        //BEGIN POST REQUESTS ->


    } //end of class
} //end of namespace

