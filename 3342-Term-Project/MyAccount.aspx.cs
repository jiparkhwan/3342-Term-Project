using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilities;
using ClassLibrary;

namespace _3342_Term_Project
{
    public partial class MyAccount : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["MemberAccount"] == null)
            {
                Server.Transfer("Login.aspx", false);
            }

            DBConnect objDB = new DBConnect();
                SqlCommand sqlComm = new SqlCommand();

                sqlComm.CommandType = CommandType.StoredProcedure;
                sqlComm.CommandText = "TP_RetrieverMemberAcc";

                SqlParameter account = new SqlParameter("@email", Session["MemberAccount"].ToString());
                account.Direction = ParameterDirection.Input;
                account.SqlDbType = SqlDbType.VarChar;
                sqlComm.Parameters.Add(account);

                DataSet ds = objDB.GetDataSetUsingCmdObj(sqlComm);

                if (ds.Tables[0].Rows.Count == 1)
                {
                    txtcurrentName.Text = ds.Tables[0].Rows[0]["Member_FName"].ToString() + " " + ds.Tables[0].Rows[0]["Member_LName"].ToString();
                    txtcurrentEmail.Text = ds.Tables[0].Rows[0]["Member_Email"].ToString();
                    txtcurrentDOB.Text = ds.Tables[0].Rows[0]["Member_DOB"].ToString();
                    txtcurrentPassword.Text = ds.Tables[0].Rows[0]["Member_Password"].ToString();

                //(DESERIALIZATION HERE)
                
                DBConnect db = new DBConnect();
                SqlCommand sql = new SqlCommand();

                sql.CommandType = CommandType.StoredProcedure;
                sql.CommandText = "TP_GetMemberFavorites";

                SqlParameter member = new SqlParameter("@email", Session["MemberAccount"].ToString());
                member.Direction = ParameterDirection.Input;
                member.SqlDbType = SqlDbType.VarChar;
                sql.Parameters.Add(member);

                DataSet dataset = db.GetDataSetUsingCmdObj(sql);


                Byte[] byteArray = (Byte[])db.GetField("Member_Favorites", 0);
                if (db.GetField("Member_Favorites", 0) != System.DBNull.Value)
                {
                    BinaryFormatter deSerializer = new BinaryFormatter();

                    MemoryStream memStream = new MemoryStream(byteArray);

                    MemberFavorites memberFavorites = (MemberFavorites)deSerializer.Deserialize(memStream);

                    favoritesLbl.Text = "Current Favorites: </br>" +

                                "Favorite Actor: " + memberFavorites.FavoriteActor + " </br>" +
                                "Favorite Movie: " + memberFavorites.FavoriteMovie + " </br>" +
                                "Favorite TVShow: " + memberFavorites.FavoriteTVShow + " </br>" +
                                "Favorite VideoGame: " + memberFavorites.FavoriteVideoGame + " </br>";

                    lblDisplay.Text = "";
                }  
            }
        }
        
        protected void btnSubmitChange_Click(object sender, EventArgs e)
        {

            // Serialize the MemberFavorites object
            MemberFavorites memberFavorites = new MemberFavorites();

            memberFavorites.FavoriteActor = txtfavoriteActor.Text;
            memberFavorites.FavoriteMovie = txtfavoriteMovie.Text;
            memberFavorites.FavoriteTVShow = txtfavoriteTVShow.Text;
            memberFavorites.FavoriteVideoGame = txtfavoriteVideoGame.Text;


            BinaryFormatter serializer = new BinaryFormatter();

            MemoryStream memStream = new MemoryStream();

            Byte[] byteArray;

            serializer.Serialize(memStream, memberFavorites);

            byteArray = memStream.ToArray();


            // Update the account to store the serialized object (binary data) in the database
            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_UpdateMemberFavorites";

            objCommand.Parameters.AddWithValue("@memberEmail", Session["MemberAccount"].ToString());
            objCommand.Parameters.AddWithValue("@MemberFavorites", byteArray);

            int retVal = objDB.DoUpdateUsingCmdObj(objCommand);


            // Check to see whether the update was successful

            if (retVal > 0)

                lblDisplay.Text = "Success in adding favorites";

            else

                lblDisplay.Text = "A problem occured in storing.";
        }
    }
}