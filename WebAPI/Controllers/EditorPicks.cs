using ClassLibrary;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Utilities;
using WebAPI.Models;

namespace WebAPI.Controllers
{

    [Route("WebAPI/[controller]")]
    public class EditorPicks
    {


        [Produces("application/json")]
        [HttpGet]
        [HttpGet("GetEditorPicks")] //Route: WebAPI/TermProject/GetEditorPicks/
        public List<ClassLibrary.Movies> GetEditorPicks()
        {
            DataSet myDS = new DataSet();
            StoredProcedures stoPros = new StoredProcedures();

            myDS = stoPros.getRandMovie();

            DBConnect objDB = new DBConnect();

            ClassLibrary.Movies movies = new ClassLibrary.Movies();
            List<ClassLibrary.Movies> dpts = new List<ClassLibrary.Movies>();

            foreach (DataRow dr in myDS.Tables[0].Rows)
            {
                movies = new ClassLibrary.Movies();
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

    }
}
