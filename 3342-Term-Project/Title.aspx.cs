using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilities;
using ClassLibrary;
namespace _3342_Term_Project
{
    public partial class Title : System.Web.UI.Page
    {
        StoredProcedures SP = new StoredProcedures();
        protected void Page_Load(object sender, EventArgs e)
        {            
            imgTitleImage.ImageUrl = Session["TitleImage"].ToString();
            lblTitleDescription.Text = Session["TitleDescription"].ToString();
            
            lblTitleGenre.Text = Session["TitleGenre"].ToString();
            lblTitleName.Text = Session["TitleName"].ToString();
            lblTitleYear.Text = Session["TitleYear"].ToString();
            lblTitleAgeRating.Text = Session["TitleAgeRating"].ToString();

            Page.Title = String.Format(lblTitleName.Text);
            if (Session["TitleCreator"] == null)
            {
                lblTitleCreatorLabel.Visible = false;
                lblTitleCreator.Visible = false;
            }
            else
            {
                lblTitleCreator.Text = Session["TitleCreator"].ToString();
            }

            if(Session["TitleRunTime"] == null)
            {
                lblTitleRunTimeLabel.Visible = false;
                lblTitleRunTime.Visible = false;
            }
            else
            {
                lblTitleRunTime.Text = Session["TitleRunTime"].ToString();
            }

            if(Session["TitleBudget"] == null && Session["TitleIncome"] == null)
            {
                lblTitleIncomeLabel.Visible = false;
                lblTitleIncome.Visible = false;
                lblTitleBudgetLabel.Visible = false;
                lblTitleBudget.Visible = false;
                lblBar2.Visible = false;
            }
            else
            {
                lblTitleBudget.Text = Session["TitleBudget"].ToString();
                lblTitleIncome.Text = Session["TitleIncome"].ToString();
            }

       
             //review functions here
            if (Convert.ToBoolean(Session["MovieReviews"]) == true)
            {
                try
                {
                    DataSet myDS = SP.getMovieReviewsByID(Convert.ToInt32(Session["MovieID"]));
                    //myDS =  SP.getMovieReviewsByID(Convert.ToInt32(Session["MovieID"]));
                    lblReviewer.Text = myDS.Tables[0].Rows[0]["Reviewer_Email"].ToString();
                    lblReviewRating.Text = myDS.Tables[0].Rows[0]["Review_Avg_Rating"].ToString();
                    lblReviewDescription.Text = myDS.Tables[0].Rows[0]["Review_Description"].ToString();
                }
                catch(Exception E)
                {
                    lblError.Text = E.Message;
                }
            }

            else if (Convert.ToBoolean(Session["ShowReviews"]) == true)
            {
                try
                {
                    DataSet myDS = SP.getShowReviewsByID(Convert.ToInt32(Session["ShowID"]));
             //   myDS = SP.getShowReviewsByID(Convert.ToInt32(Session["ShowID"]));
                lblReviewer.Text = myDS.Tables[0].Rows[0]["Reviewer_Email"].ToString();
                lblReviewRating.Text = myDS.Tables[0].Rows[0]["Review_Avg_Rating"].ToString();
                lblReviewDescription.Text = myDS.Tables[0].Rows[0]["Review_Description"].ToString();
            }
                catch (Exception E)
            {
                lblError.Text = E.Message;
            }

        }
           else if (Convert.ToBoolean(Session["GameReviews"]) == true)
            {
                try
                {
                    DataSet myDS = SP.getGameReviewsByID(Convert.ToInt32(Session["GameID"]));


               // myDS = SP.getGameReviewsByID(Convert.ToInt32(Session["GameID"]));

                lblReviewer.Text = myDS.Tables[0].Rows[0]["Reviewer_Email"].ToString();
                lblReviewRating.Text = myDS.Tables[0].Rows[0]["Review_Avg_Rating"].ToString();
                lblReviewDescription.Text = myDS.Tables[0].Rows[0]["Review_Description"].ToString();
            }
                catch (Exception E)
            {
                lblError.Text = E.Message;
            }

        }



        }


        protected void btnBack_Click(object sender, EventArgs e)
        {

            Response.Redirect("HomePage.aspx");
        }

    }
}