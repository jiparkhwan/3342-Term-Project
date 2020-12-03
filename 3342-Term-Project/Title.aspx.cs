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
using System.Net;
using System.IO;

namespace _3342_Term_Project
{
    public partial class Title : System.Web.UI.Page
    {
        StoredProcedures SP = new StoredProcedures();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) { 
            addReviewLink.Visible = true;
            lblSuccessReview.Text = "";
            addReviewPanel.Visible = false;

            editReviewPanel.Visible = false;


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

            if (Session["TitleRunTime"] == null)
            {
                lblTitleRunTimeLabel.Visible = false;
                lblTitleRunTime.Visible = false;
            }
            else
            {
                lblTitleRunTime.Text = Session["TitleRunTime"].ToString();
            }

            if (Session["TitleBudget"] == null && Session["TitleIncome"] == null)
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



            bindGridview();
            //show delete and edit review buttons only for member's reviews
            hideNonMemberControls();
            }
        }

        protected void Image_Click(object sender, CommandEventArgs e)
        {

        }

        public void bindGridview()
        {
            //review functions here
            if (Convert.ToBoolean(Session["MovieReviews"]) == true)
            {
                int movieID = Convert.ToInt32(Session["MovieID"]);

                DataSet myDS = SP.getMovieReviewsByID(movieID);
                if (myDS.Tables[0].Rows.Count >= 1) //member record found
                {
                    try
                    {
                        gvReviews.DataSource = myDS;
                        gvReviews.DataBind();

                        gvReviews.Visible = true;

                        if (gvReviews.Visible == true)
                        {
                            lblSuccessReview.Text = "";
                            lblError.Text = "";
                        }
                    }
                    catch (Exception E)
                    {
                        lblError.Text = E.Message;
                    }


                }
                else
                {
                    lblError.Text = "No reviews exist for this movie yet! Be the first one: ";
                }
            }



            else if (Convert.ToBoolean(Session["ShowReviews"]) == true)
            {

                DataSet myDS = SP.getShowReviewsByID(Convert.ToInt32(Session["ShowID"]));
                //   myDS = SP.getShowReviewsByID(Convert.ToInt32(Session["ShowID"]));
                if (myDS.Tables[0].Rows.Count >= 1) //member record found
                {
                    gvReviews.DataSource = myDS;
                    gvReviews.DataBind();

                    gvReviews.Visible = true;
                    if (gvReviews.Visible == true)
                    {
                        lblSuccessReview.Text = "";
                        lblError.Text = "";
                    }
                }

                else
                {
                    lblError.Text = "No reviews exist for this show yet! Be the first one: ";
                }

            }
            else if (Convert.ToBoolean(Session["GameReviews"]) == true)
            {

                DataSet myDS = SP.getGameReviewsByID(Convert.ToInt32(Session["GameID"]));


                // myDS = SP.getGameReviewsByID(Convert.ToInt32(Session["GameID"]));
                if (myDS.Tables[0].Rows.Count >= 1) //member record found
                {
                    gvReviews.DataSource = myDS;
                    gvReviews.DataBind();

                    gvReviews.Visible = true;
                    if (gvReviews.Visible == true)
                    {
                        lblSuccessReview.Text = "";
                        lblError.Text = "";
                    }
                }
                else
                {
                    lblError.Text = "No reviews exist for this game yet! Be the first one: ";
                }

            }
        }
        public void hideNonMemberControls()
        {
            //show delete and edit review buttons only for member's reviews
            foreach (GridViewRow row in gvReviews.Rows)
            {
                for (int i = 0; i < gvReviews.Columns.Count; i++)
                {
                     if (row.Cells[1].Text != Session["MemberAccount"].ToString())
                    {
                        row.Cells[4].Controls.Clear();
                    }
                    else
                    {
                        addReviewLink.Visible = false; //dont allow member to add a review if they already wrote one
                    }
                }
            }

            //hide review IDs from user
            this.gvReviews.Columns[0].Visible = false;
        }
        protected void addReviewLink_OnClick(object sender, EventArgs e)
        {
            if (addReviewPanel.Visible == false)
            {
                addReviewPanel.Visible = true;
            }
        }
        protected void submitReview_OnClick(object sender, EventArgs e)
        {
            if (Convert.ToBoolean(Session["MovieReviews"]) == true)
            {
                int movieID= Convert.ToInt32(Session["MovieID"]);
                int success = StoredProcedures.addMovieReview(movieID, Convert.ToInt32(ddlAddRating.SelectedValue), textAreaAddReview.Value, Session["MemberAccount"].ToString());
                if(success >= 1)
                {
                    addReviewPanel.Visible = false;
                    lblSuccessReview.Text = "Thank you for your feedback!";
                    lblError.Text = "";
                    addReviewLink.Visible = false;
                    editReviewPanel.Visible = false;

                    bindGridview();
                    //show delete and edit review buttons only for member's reviews
                    hideNonMemberControls();
                }

            }
           else if (Convert.ToBoolean(Session["GameReviews"]) == true)
            {
                int gameID = Convert.ToInt32(Session["GameID"]);
                int success = StoredProcedures.addGameReview(gameID, Convert.ToInt32(ddlAddRating.SelectedValue), textAreaAddReview.Value, Session["MemberAccount"].ToString());
                if (success >= 1)
                {
                    addReviewPanel.Visible = false;
                    lblSuccessReview.Text = "Thank you for your feedback!";
                    lblError.Text = "";
                    addReviewLink.Visible = false;
                    editReviewPanel.Visible = false;

                    bindGridview();
                    //show delete and edit review buttons only for member's reviews
                    hideNonMemberControls();
                }
            }
          else if (Convert.ToBoolean(Session["ShowReviews"]) == true)
            {
                int ShowID = Convert.ToInt32(Session["ShowID"]);
                int success = StoredProcedures.addTVShowReview(ShowID, Convert.ToInt32(ddlAddRating.SelectedValue), textAreaAddReview.Value, Session["MemberAccount"].ToString());
                if (success >= 1)
                {
                    addReviewPanel.Visible = false;
                    lblSuccessReview.Text = "Thank you for your feedback!";
                    lblError.Text = "";
                    addReviewLink.Visible = false;
                    editReviewPanel.Visible = false;

                    bindGridview();
                    //show delete and edit review buttons only for member's reviews
                    hideNonMemberControls();
                }
            }

        }
        protected void btnEditReview_Click(object sender, EventArgs e)
        {
            //Get the button that raised the event
            Button btn = (Button)sender;

            //Get the row that contains this button
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;

            Session["ReviewID"] = gvr.Cells[0].Text;
            Session["ReviewerName"] = gvr.Cells[1].Text;

            editReviewPanel.Visible = true;
            addReviewPanel.Visible = false;
            bindGridview();
            //show delete and edit review buttons only for member's reviews
            hideNonMemberControls();



        }
       protected void btnEditReviewSubmit_OnClick(object sender, EventArgs e)
        {
            if (editReviewDescription.Value == null || editReviewDescription.Value == "" || editReviewDescription.Value == " ")
            {
                lblError.Text = "Please fill out the description";
            }
            int success = StoredProcedures.editReview(Convert.ToInt32(Session["ReviewID"].ToString()), Convert.ToInt32(ddlEditRating.SelectedValue), editReviewDescription.Value);
            if (success >= 1)
            {

                lblSuccessReview.Text = "Review edited successfully!";
                lblError.Text = "";
                addReviewLink.Visible = false;
                addReviewPanel.Visible = false;
                editReviewPanel.Visible = false;

                bindGridview();
            }
            hideNonMemberControls();

        }
        protected void btnDeleteReview_Click(object sender, EventArgs e)
        {
            //Get the button that raised the event
            Button btn = (Button)sender;

            //Get the row that contains this button
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;

            Session["ReviewID"] = gvr.Cells[0].Text;
            Session["ReviewerName"] = gvr.Cells[1].Text;

            editReviewPanel.Visible = false;
            addReviewPanel.Visible = false;
            try
            {
                // Create an HTTP Web Request and get the HTTP Web Response from the server.
                WebRequest request = WebRequest.Create("https://localhost:44301/WebAPI/TermProject/DeleteReview/" + Session["ReviewID"].ToString());
                request.Method = "DELETE";
                request.ContentLength = 0;

                WebResponse response = request.GetResponse();
                // Read the data from the Web Response, which requires working with streams.
                Stream theDataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(theDataStream);
                string data = reader.ReadToEnd();
                reader.Close();
                response.Close();

                lblError.Text = "Review has been successfully deleted";
                addReviewLink.Visible = false;
                editReviewPanel.Visible = false;
                addReviewPanel.Visible = false;
                bindGridview();
                addReviewLink.Visible = true;
                addReviewPanel.Visible = true;
            }

            catch (Exception E)
            {
                lblError.Text = E.Message;
            }

            hideNonMemberControls();
        }
        protected void btnBack_Click(object sender, EventArgs e)
        {

            Response.Redirect("HomePage.aspx");
        }

        protected void btnEditTitle_Click(object sender, EventArgs e)
        {
            Session["AddMovie"] = null;
            Session["AddShow"] = null;
            Session["AddGame"] = null;


            if (Session["MovieID"] != null)
            {
                Session["UpdateMovie"] = "Update Movie";
                Session["Edit_ID"] = Session["MovieID"].ToString();
                Session["Edit_Image"] = Session["TitleImage"].ToString();
                Session["Edit_Name"] = Session["TitleName"].ToString();
                Session["Edit_Description"] = Session["TitleDescription"].ToString();
                Session["Edit_Year"] = Session["TitleYear"].ToString();
                Session["Edit_Runtime"] = Session["TitleRuntime"].ToString();
                Session["Edit_Genre"] = Session["TitleGenre"].ToString();
                Session["Edit_Age_Rating"] = Session["TitleAgeRating"].ToString();
                Session["Edit_Budget"] = Session["TitleBudget"].ToString();
                Session["Edit_Income"] = Session["TitleIncome"].ToString();
            }
            else if(Session["ShowID"] != null)
            {
                Session["UpdateShow"] = "Update Show";
                Session["Edit_ID"] = Session["ShowID"].ToString();
                Session["Edit_Image"] = Session["TitleImage"].ToString();
                Session["Edit_Name"] = Session["TitleName"].ToString();
                Session["Edit_Description"] = Session["TitleDescription"].ToString();
                Session["Edit_Year"] = Session["TitleYear"].ToString();
                Session["Edit_Runtime"] = Session["TitleRuntime"].ToString();
                Session["Edit_Genre"] = Session["TitleGenre"].ToString();
                Session["Edit_Age_Rating"] = Session["TitleAgeRating"].ToString();
            }
            else if (Session["GameID"] != null)
            {
                Session["UpdateGame"] = "Update Game";
                Session["Edit_ID"] = Session["GameID"].ToString();
                Session["Edit_Image"] = Session["TitleImage"].ToString();
                Session["Edit_Name"] = Session["TitleName"].ToString();
                Session["Edit_Description"] = Session["TitleDescription"].ToString();
                Session["Edit_Year"] = Session["TitleYear"].ToString();
                Session["Edit_Genre"] = Session["TitleGenre"].ToString();
                Session["Edit_Age_Rating"] = Session["TitleAgeRating"].ToString();
                Session["Edit_Creator"] = Session["TitleCreator"].ToString();
            }
            Response.Redirect("AddTitle.aspx");
        }
    }
}