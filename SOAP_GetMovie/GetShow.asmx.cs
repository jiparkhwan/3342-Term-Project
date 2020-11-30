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
    /// Summary description for GetShow
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class GetShow : System.Web.Services.WebService
    {

        [WebMethod]
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
        }
    }
}
