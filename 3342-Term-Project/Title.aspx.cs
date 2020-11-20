using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _3342_Term_Project
{
    public partial class Title : System.Web.UI.Page
    {
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
            
        }


        protected void btnBack_Click(object sender, EventArgs e)
        {

            Response.Redirect("HomePage.aspx");
        }

    }
}