using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using Utilities;

namespace SOAP_GetMovie
{
    /// <summary>
    /// Summary description for GetMovie
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class GetMovie : System.Web.Services.WebService
    {

        [WebMethod]
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
        }
    }
}
