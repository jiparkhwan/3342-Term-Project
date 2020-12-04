using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

using Utilities;

namespace ClassLibrary
{
    public class StoredProcedures
    {
        DBConnect objDB = new DBConnect();
        SqlCommand objCommand = new SqlCommand();
        string strSQL;

        public DataSet getCastByShowID(int id)
        {
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_GetActorsInShows";

            SqlParameter inputParameter = new SqlParameter("@Show_ID", id);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.Int;

            objCommand.Parameters.Add(inputParameter);

            objDB = new DBConnect();
            DataSet myDS;
            myDS = objDB.GetDataSetUsingCmdObj(objCommand);

            return myDS;
        }

        public DataSet getCastByGameID(int id)
        {
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_GetActorsInGames";

            SqlParameter inputParameter = new SqlParameter("@Game_ID", id);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.Int;

            objCommand.Parameters.Add(inputParameter);

            objDB = new DBConnect();
            DataSet myDS;
            myDS = objDB.GetDataSetUsingCmdObj(objCommand);

            return myDS;
        }
        //Displays all actors in database
        public DataSet getAllActors()
        {
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_GetAllActors";

            DataSet myDS = objDB.GetDataSetUsingCmdObj(objCommand);

            return myDS;
        }
      
        public DataSet getAllMovies()
        {
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_GetAllMovies";

            DataSet myDS = objDB.GetDataSetUsingCmdObj(objCommand);

            return myDS;
        }

        public DataSet getAllShows()
        {
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_GetAllShows";

            DataSet myDS = objDB.GetDataSetUsingCmdObj(objCommand);

            return myDS;
        }

        public DataSet getAllGames()
        {
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_GetAllGames";

            DataSet myDS = objDB.GetDataSetUsingCmdObj(objCommand);

            return myDS;
        }

        public DataSet getRandMovie()
        {
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_GetRandomMovie";

            DataSet myDS = objDB.GetDataSetUsingCmdObj(objCommand);

            return myDS;
        }

        public DataSet getRandShow()
        {
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_GetRandomShow";

            DataSet myDS = objDB.GetDataSetUsingCmdObj(objCommand);

            return myDS;
        }

        public DataSet getRandGame()
        {
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_GetRandomGame";

            DataSet myDS = objDB.GetDataSetUsingCmdObj(objCommand);

            return myDS;
        }

        //Finds actors based on name typed in search bar. Uses like to find names that are similar as well.
        public DataSet getActorByName(string actorName)
        {
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_GetActorsByName";

            SqlParameter inputParameter = new SqlParameter("@Actor_Name", actorName);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.VarChar;

            objCommand.Parameters.Add(inputParameter);

            objDB = new DBConnect();
            DataSet myDS;
            myDS = objDB.GetDataSetUsingCmdObj(objCommand);

            return myDS;
        }

        //get reviews by id
        public DataSet getMovieReviewsByID(int id)
        {
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_GetMovieReviews";

            SqlParameter inputParameter = new SqlParameter("@movieID", id);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.Int;

            objCommand.Parameters.Add(inputParameter);

            objDB = new DBConnect();
            DataSet myDS;
            myDS = objDB.GetDataSetUsingCmdObj(objCommand);

            return myDS;
        }
        public DataSet getGameReviewsByID(int id)
        {
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_GetGameReviews";

            SqlParameter inputParameter = new SqlParameter("@gameID", id);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.Int;

            objCommand.Parameters.Add(inputParameter);

            objDB = new DBConnect();
            DataSet myDS;
            myDS = objDB.GetDataSetUsingCmdObj(objCommand);

            return myDS;
        }
        public DataSet getShowReviewsByID(int id)
        {
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_GetShowReviews";

            SqlParameter inputParameter = new SqlParameter("@showID", id);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.Int;

            objCommand.Parameters.Add(inputParameter);

            objDB = new DBConnect();
            DataSet myDS;
            myDS = objDB.GetDataSetUsingCmdObj(objCommand);

            return myDS;
        }

        public DataSet getActorRolesByID(int id)
        {
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_GetAllActorsMovies";

            SqlParameter inputParameter = new SqlParameter("@Actor_ID", id);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.Int;

            objCommand.Parameters.Add(inputParameter);

            objDB = new DBConnect();
            DataSet myDS;
            myDS = objDB.GetDataSetUsingCmdObj(objCommand);

            return myDS;
        }

        public DataSet getCastByMovieID(int id)
        {
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_GetActorsInMovies";

            SqlParameter inputParameter = new SqlParameter("@Movie_ID", id);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.Int;

            objCommand.Parameters.Add(inputParameter);

            objDB = new DBConnect();
            DataSet myDS;
            myDS = objDB.GetDataSetUsingCmdObj(objCommand);

            return myDS;
        }
        

        public static int addMovieReview(int id, int rating, string description, string reviewerEmail)
        {
            DBConnect objDB = new DBConnect();

            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_AddMovieReview";

            SqlParameter inputParameter = new SqlParameter("@movieID", id);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.Int;
            objCommand.Parameters.Add(inputParameter);

            inputParameter = new SqlParameter("@rating", rating);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.Int;
            objCommand.Parameters.Add(inputParameter);


            inputParameter = new SqlParameter("@description", description);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.VarChar;
            objCommand.Parameters.Add(inputParameter);

            inputParameter = new SqlParameter("@reviewerEmail", reviewerEmail);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.VarChar;
            objCommand.Parameters.Add(inputParameter);

            return objDB.DoUpdateUsingCmdObj(objCommand);


        }

        public static int addTVShowReview(int id, int rating, string description, string reviewerEmail)
        {
            DBConnect objDB = new DBConnect();

            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_AddShowReview";

            SqlParameter inputParameter = new SqlParameter("@showID", id);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.Int;
            objCommand.Parameters.Add(inputParameter);

            inputParameter = new SqlParameter("@rating", rating);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.Int;
            objCommand.Parameters.Add(inputParameter);


            inputParameter = new SqlParameter("@description", description);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.VarChar;
            objCommand.Parameters.Add(inputParameter);

            inputParameter = new SqlParameter("@reviewerEmail", reviewerEmail);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.VarChar;
            objCommand.Parameters.Add(inputParameter);

            return objDB.DoUpdateUsingCmdObj(objCommand);


        }
       
        public static int addGameReview(int id, int rating, string description, string reviewerEmail)
        {
            DBConnect objDB = new DBConnect();

            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_AddGameReview";

            SqlParameter inputParameter = new SqlParameter("@gameID", id);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.Int;
            objCommand.Parameters.Add(inputParameter);

            inputParameter = new SqlParameter("@rating", rating);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.Int;
            objCommand.Parameters.Add(inputParameter);


            inputParameter = new SqlParameter("@description", description);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.VarChar;
            objCommand.Parameters.Add(inputParameter);

            inputParameter = new SqlParameter("@reviewerEmail", reviewerEmail);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.VarChar;
            objCommand.Parameters.Add(inputParameter);

            return objDB.DoUpdateUsingCmdObj(objCommand);


        }
        //editing reviews:
        public static int editReview(int reviewID, int rating, string reviewDescription)
        {
            DBConnect objDB = new DBConnect();

            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_UpdateReview";

            SqlParameter inputParameter = new SqlParameter("@reviewID", reviewID);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.Int;
            objCommand.Parameters.Add(inputParameter);

            inputParameter = new SqlParameter("@rating", rating);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.Int;
            objCommand.Parameters.Add(inputParameter);

            inputParameter = new SqlParameter("@reviewDescription", reviewDescription);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.VarChar;
            objCommand.Parameters.Add(inputParameter);



            return objDB.DoUpdateUsingCmdObj(objCommand);
        }
     
        //editing reviews END


        //Delete Reviews:
        public static int DeleteReview(int reviewID)
        {
            DBConnect objDB = new DBConnect();

            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_DeleteReview";

            //set value for input parameter
            SqlParameter inputParam = new SqlParameter("@reviewID", reviewID);
            inputParam.Direction = ParameterDirection.Input;
            inputParam.SqlDbType = SqlDbType.Int;
            objCommand.Parameters.Add(inputParam);


            return objDB.DoUpdateUsingCmdObj(objCommand);
        }
        //delete reviews END
        public static int DeleteActor(int actorID)
        {
            DBConnect objDB = new DBConnect();

            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_DeleteActor";

            //set value for input parameter
            SqlParameter inputParam = new SqlParameter("@actorID", actorID);
            inputParam.Direction = ParameterDirection.Input;
            inputParam.SqlDbType = SqlDbType.Int;
            objCommand.Parameters.Add(inputParam);


            return objDB.DoUpdateUsingCmdObj(objCommand);
        }

        //Finds TV shows based on name typed in search bar. Uses like to find titles that are similar as well.
        public DataSet getShowByName(string showName)
        {
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_GetTVShowByName";

            SqlParameter inputParameter = new SqlParameter("@Show_Name", showName);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.VarChar;

            objCommand.Parameters.Add(inputParameter);

            objDB = new DBConnect();
            DataSet myDS;
            myDS = objDB.GetDataSetUsingCmdObj(objCommand);

            return myDS;
        }

        //Finds video games based on name typed in search bar. Uses like to find titles that are similar as well.
        public DataSet getGameByName(string gameName)
        {
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_GetVideoGameByName";

            SqlParameter inputParameter = new SqlParameter("@Game_Name", gameName);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.VarChar;

            objCommand.Parameters.Add(inputParameter);

            objDB = new DBConnect();
            DataSet myDS;
            myDS = objDB.GetDataSetUsingCmdObj(objCommand);

            return myDS;
        }

        //Finds movies based on name typed in search bar. Uses like to find titles that are similar as well.
        public DataSet getMovieByName(string movieName)
        {
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_GetMovieByName";

            SqlParameter inputParameter = new SqlParameter("@Movie_Name", movieName);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.VarChar;

            objCommand.Parameters.Add(inputParameter);

            objDB = new DBConnect();
            DataSet myDS;
            myDS = objDB.GetDataSetUsingCmdObj(objCommand);

            return myDS;
        } 
        public static int verifyMemberAccount(string email)
        {

            DBConnect objDB = new DBConnect();
            SqlCommand sqlComm = new SqlCommand();

            sqlComm.CommandType = CommandType.StoredProcedure;
            sqlComm.CommandText = "TP_VerifyMemberAccount";

            SqlParameter cust = new SqlParameter("@email", email);
            cust.Direction = ParameterDirection.Input;
            cust.SqlDbType = SqlDbType.VarChar;
            sqlComm.Parameters.Add(cust);

            return objDB.DoUpdateUsingCmdObj(sqlComm);
        }
        public static int addMemberAccountRegister(string email, string firstname, string lastname, string password, string dob, string sq1, string sq2, string sq3, string sa1, string sa2, string sa3)
        {
            DBConnect objDB = new DBConnect();
            SqlCommand sqlComm = new SqlCommand();

            sqlComm.CommandType = CommandType.StoredProcedure;
            sqlComm.CommandText = "TP_MemberRegister";

            SqlParameter cust = new SqlParameter("@email", email);
            cust.Direction = ParameterDirection.Input;
            cust.SqlDbType = SqlDbType.VarChar;
            sqlComm.Parameters.Add(cust);

            cust = new SqlParameter("@firstName", firstname);
            cust.Direction = ParameterDirection.Input;
            cust.SqlDbType = SqlDbType.VarChar;
            sqlComm.Parameters.Add(cust);

            cust = new SqlParameter("@lastName", lastname);
            cust.Direction = ParameterDirection.Input;
            cust.SqlDbType = SqlDbType.VarChar;
            sqlComm.Parameters.Add(cust);

            cust = new SqlParameter("@password", password);
            cust.Direction = ParameterDirection.Input;
            cust.SqlDbType = SqlDbType.VarChar;
            sqlComm.Parameters.Add(cust);
            cust = new SqlParameter("@DOB", dob);
            cust.Direction = ParameterDirection.Input;
            cust.SqlDbType = SqlDbType.VarChar;
            sqlComm.Parameters.Add(cust);


            cust = new SqlParameter("@securityQ1", sq1);
            cust.Direction = ParameterDirection.Input;
            cust.SqlDbType = SqlDbType.VarChar;
            sqlComm.Parameters.Add(cust);

            cust = new SqlParameter("@securityA1", sq2);
            cust.Direction = ParameterDirection.Input;
            cust.SqlDbType = SqlDbType.VarChar;
            sqlComm.Parameters.Add(cust);

            cust = new SqlParameter("@securityQ2", sq3);
            cust.Direction = ParameterDirection.Input;
            cust.SqlDbType = SqlDbType.VarChar;
            sqlComm.Parameters.Add(cust);

            cust = new SqlParameter("@securityA2", sa1);
            cust.Direction = ParameterDirection.Input;
            cust.SqlDbType = SqlDbType.VarChar;
            sqlComm.Parameters.Add(cust);

            cust = new SqlParameter("@securityQ3", sa2);
            cust.Direction = ParameterDirection.Input;
            cust.SqlDbType = SqlDbType.VarChar;
            sqlComm.Parameters.Add(cust);

            cust = new SqlParameter("@securityA3", sa3);
            cust.Direction = ParameterDirection.Input;
            cust.SqlDbType = SqlDbType.VarChar;
            sqlComm.Parameters.Add(cust);

            return objDB.DoUpdateUsingCmdObj(sqlComm);
        }
    }
}