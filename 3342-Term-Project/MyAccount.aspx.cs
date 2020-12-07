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
                string password = ds.Tables[0].Rows[0]["Member_Password"].ToString();
                int passwordLength = ds.Tables[0].Rows[0]["Member_Password"].ToString().Length;

                string email = ds.Tables[0].Rows[0]["Member_Email"].ToString();
                string firstname = ds.Tables[0].Rows[0]["Member_FName"].ToString();
                string lastname = ds.Tables[0].Rows[0]["Member_LName"].ToString();
                string birth = ds.Tables[0].Rows[0]["Member_DOB"].ToString();




             


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
                    try { 
                    BinaryFormatter deSerializer = new BinaryFormatter();

                    MemoryStream memStream = new MemoryStream(byteArray);

                    MemberFavorites memberFavorites = (MemberFavorites)deSerializer.Deserialize(memStream);

                        txtfavoriteActor.Text = memberFavorites.FavoriteActor;
                        txtfavoriteMovie.Text = memberFavorites.FavoriteMovie;
                        txtfavoriteTVShow.Text = memberFavorites.FavoriteTVShow;
                        txtfavoriteVideoGame.Text = memberFavorites.FavoriteVideoGame;


                    }
                    catch(Exception E)
                    {
                        favoritesLbl.Text = "You do not have favorites yet. Add new ones below!";
                    }
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
            {



                Response.Write("<script>alert('Favorites Updated!')</script>");

                //  Response.Redirect("HomePage.aspx");
            }


            else
            {

                lblDisplay.Text = "A problem occured in storing.";
            }





            int id = Convert.ToInt32(Session["MemberID"]);

            int success = StoredProcedures.editMember(id, txtManageEmail.Text, txtManagePassword.Text, txtManageName.Text, txtManageLName.Text, txtDateOfBirth.Text);

            if (success > 0)
            {
                Response.Write("<script>alert('Account Updated Successfully')</script>");
                


            }


        }

        protected void btnClearFields_Click(Object sender,EventArgs e)
        {
            txtfavoriteActor.Text = "";
            txtfavoriteMovie.Text = "";
            txtfavoriteTVShow.Text = "";
            txtfavoriteVideoGame.Text = "";
            txtManageEmail.Text = "";
            txtManageName.Text = "";
            txtManageLName.Text = "";
            txtManagePassword.Text = "";
            txtManagePasswordConfirm.Text = "";
         
        }
    }
}