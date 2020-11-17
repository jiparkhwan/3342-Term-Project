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
            //This gets the name of the title that was just selected and Sets it to be the page title in the tab
            Page.Title = String.Format("Title Name");
    


            imgTitleImage.ImageUrl = Session["MovieImage"].ToString();
            lblTitleDescription.Text = Session["MovieDescription"].ToString();
            lblTitleRunTime.Text = Session["MovieRunTime"].ToString();
            lblTitleGenre.Text = Session["MovieGenre"].ToString();
            lblTitleBudget.Text = Session["MovieBudget"].ToString();
            lblTitleIncome.Text = Session["MovieIncome"].ToString();
            lblTitleName.Text = Session["MovieName"].ToString();
            lblTitleYear.Text = Session["MovieYear"].ToString();
            lblTitleAgeRating.Text = Session["MovieAgeRating"].ToString();
        }
    }
}