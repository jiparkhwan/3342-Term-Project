using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;

using Utilities;
using System.Data.SqlClient;
using ClassLibrary;

namespace SOAP_AddActor
{
    /// <summary>
    /// Summary description for AddActor
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class SOAP_AddActor : System.Web.Services.WebService
    {

        [WebMethod]
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
        }
    }
}
