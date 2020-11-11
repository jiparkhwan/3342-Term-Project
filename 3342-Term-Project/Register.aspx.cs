using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _3342_Term_Project
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Submit_Click(object sender, EventArgs e)
        {
            try
            {
                Models.Members member = new Models.Members();
                member.Fname1 = txtFirstName.Text;
                member.Lname1 = txtLastName.Text;
                member.DOB1 = txtDOB.Text;
                member.Password = txtMemberPassword.Text;
                member.Email = txtEmail.Text;

                //serialize seller contact object into json
                JavaScriptSerializer js = new JavaScriptSerializer();
                string jsonedMember = js.Serialize(member);

                WebRequest request = WebRequest.Create("RegisterSite/" + siteID + "/description/" + txtMemberUsername.Text + "/" +txtEmail.Text);
                request.Method = "POST";
                request.ContentType = "application/json";

                // Write the JSON data to the Web Request
                StreamWriter writer = new StreamWriter(request.GetRequestStream());
                writer.Write(jsonedMember);
                writer.Flush();
                writer.Close();

                // Read the data from the Web Response, which requires working with streams.
                WebResponse response = request.GetResponse();
                Stream theDataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(theDataStream);
                string data = reader.ReadToEnd();
                reader.Close();
                response.Close();
            }
} }