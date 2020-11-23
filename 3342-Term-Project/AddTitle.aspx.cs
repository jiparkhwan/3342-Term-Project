using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _3342_Term_Project
{
    public partial class AddTitle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            bind_year_ddl();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

        }

        private void bind_year_ddl()
        {
            int year = (System.DateTime.Now.Year);
            for (int intCount = year; intCount >= 1900; intCount--)
            {
                ddlAddMovieYear.Items.Add(intCount.ToString());
            }
        }

        protected void ddlAddMovieYear_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}