<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddActor.aspx.cs" Inherits="_3342_Term_Project.AddActor" %>
<%@ Register Src="~/UserControls/Navbar.ascx" TagName="HomeNav" TagPrefix="Navigation" %>
<%@ Register Src="~/UserControls/Footer.ascx" TagName="HomeFooter" TagPrefix="Footer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" />

    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <link href="https://fonts.googleapis.com/css?family=Roboto:100,100i,300,300i,400,400i,500,500i,700,700i,900,900i" rel="stylesheet" />
    <script src="//ajax.googleapis.com/ajax/libs/jquery/1.11.0/jquery.min.js"></script>
    <script src="//netdna.bootstrapcdn.com/bootstrap/3.1.1/js/bootstrap.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.0/js/bootstrap.min.js"></script>

    <!-- Load icon library -->
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css" />

    <link href="Styles.css" rel="stylesheet" />
    <title>Add Actor</title>
</head>
<body>
    <form id="frmAddActor" runat="server">
        <Navigation:HomeNav ID="HomeNav" runat="server" />
        <div class="addTitle">
            
           <div class="row">
                <div class="column">
            <h2 style="color:#778aab;">Add An Actor</h2>
      
            <br />
            <small>Found an upcoming actor that we're not aware of? Add them here!</small>
            <asp:Label ID="lblDisplay" runat="server" Text="" ForeColor="red"></asp:Label>
            <br />
            <br />
            <asp:Label ID="lblAddImage" runat="server" Text="Image URL: " Font-Bold="True" Font-Size="Large"></asp:Label>
            <asp:TextBox ID="txtAddImage" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ControlToValidate="txtAddImage" ID="ImageValidator" runat="server" ErrorMessage="Name Required" Display="Dynamic"></asp:RequiredFieldValidator>
            <br />
            <br />
            <asp:Label ID="lblAddName" runat="server" Text="Actor's Full Name: " Font-Bold="True" Font-Size="Large"></asp:Label>
            <asp:TextBox ID="txtAddName" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ControlToValidate="txtAddName" ID="RequiredFieldValidator1" runat="server" ErrorMessage="Name Required" Display="Dynamic"></asp:RequiredFieldValidator>

            <br />
            <br />
            <asp:Label ID="lblAddHeight" runat="server" Text="Actor's Height: " Font-Bold="True" Font-Size="Large"></asp:Label>
            <asp:TextBox ID="txtAddHeight" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ControlToValidate="txtAddHeight" ID="heightValidator" runat="server" ErrorMessage="Height required" Display="Dynamic"></asp:RequiredFieldValidator>
            <br />
            <br />
            <asp:Label ID="lblAddDOB" runat="server" Text="Actor's Date of Birth: " Font-Bold="True" Font-Size="Large"></asp:Label>
            <asp:DropDownList ID="ddlAddDOBMonth" runat="server">
                <asp:ListItem Value="noneSelected">-------</asp:ListItem>
                <asp:ListItem Value="01">January</asp:ListItem>
                <asp:ListItem Value="02">Febuary</asp:ListItem>
                <asp:ListItem Value="03">March</asp:ListItem>
                <asp:ListItem Value="04">April</asp:ListItem>
                <asp:ListItem Value="05">May</asp:ListItem>
                <asp:ListItem Value="06">June</asp:ListItem>
                <asp:ListItem Value="07">July</asp:ListItem>
                <asp:ListItem Value="08">August</asp:ListItem>
                <asp:ListItem Value="09">September</asp:ListItem>
                <asp:ListItem Value="10">October</asp:ListItem>
                <asp:ListItem Value="11">November</asp:ListItem>
                <asp:ListItem Value="12">December</asp:ListItem>
            </asp:DropDownList>

            <asp:Label ID="lblDash" runat="server" Text=" - "></asp:Label>
            <asp:DropDownList ID="ddlAddDOBDay" runat="server">
                <asp:ListItem Value="noneSelected">-----</asp:ListItem>
                <asp:ListItem Value="01">1</asp:ListItem>
                <asp:ListItem Value="02">2</asp:ListItem>
                <asp:ListItem Value="03">3</asp:ListItem>
                <asp:ListItem Value="04">4</asp:ListItem>
                <asp:ListItem Value="05">5</asp:ListItem>
                <asp:ListItem Value="06">6</asp:ListItem>
                <asp:ListItem Value="07">7</asp:ListItem>
                <asp:ListItem Value="08">8</asp:ListItem>
                <asp:ListItem Value="09">9</asp:ListItem>
                <asp:ListItem Value="10">10</asp:ListItem>
                <asp:ListItem Value="11">11</asp:ListItem>
                <asp:ListItem Value="12">12</asp:ListItem>
                <asp:ListItem Value="13">13</asp:ListItem>
                <asp:ListItem Value="14">14</asp:ListItem>
                <asp:ListItem Value="15">15</asp:ListItem>
                <asp:ListItem Value="16">16</asp:ListItem>
                <asp:ListItem Value="17">17</asp:ListItem>
                <asp:ListItem Value="18">18</asp:ListItem>
                <asp:ListItem Value="19">19</asp:ListItem>
                <asp:ListItem Value="20">20</asp:ListItem>
                <asp:ListItem Value="21">21</asp:ListItem>
                <asp:ListItem Value="22">22</asp:ListItem>
                <asp:ListItem Value="23">23</asp:ListItem>
                <asp:ListItem Value="24">24</asp:ListItem>
                <asp:ListItem Value="25">25</asp:ListItem>
                <asp:ListItem Value="26">26</asp:ListItem>
                <asp:ListItem Value="27">27</asp:ListItem>
                <asp:ListItem Value="28">28</asp:ListItem>
                <asp:ListItem Value="29">29</asp:ListItem>
                <asp:ListItem Value="30">30</asp:ListItem>
                <asp:ListItem Value="31">31</asp:ListItem>
            </asp:DropDownList>
            <asp:Label ID="lblDash2" runat="server" Text=" - "></asp:Label>
            <asp:DropDownList ID="ddlAddDOBYear" runat="server" OnSelectedIndexChanged="ddlAddBOBYear_SelectedIndexChanged">
                <asp:ListItem Value="noneSelected">-----</asp:ListItem>
            </asp:DropDownList>
            <br />
            <br />
            <asp:Label ID="lblAddBirthCity" runat="server" Text="Actor's Birth City: " Font-Bold="True" Font-Size="Large"></asp:Label>
            <asp:TextBox ID="txtAddBirthCity" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ControlToValidate="txtAddBirthCity" ID="RequiredFieldValidator4" runat="server" ErrorMessage="Please enter the city!" Display="Dynamic"></asp:RequiredFieldValidator>

            <br />
            <br />
            <asp:Label ID="lblAddBirthState" runat="server" Text="Actor's Birth State: " Font-Bold="True" Font-Size="Large"></asp:Label>
            <asp:DropDownList ID="ddlAddBirthState" runat="server">
                <asp:ListItem Value="noneSelected">-----</asp:ListItem>
                <asp:ListItem Value="AL">Alabama</asp:ListItem>
	            <asp:ListItem Value="AK">Alaska</asp:ListItem>
	            <asp:ListItem Value="AZ">Arizona</asp:ListItem>
	            <asp:ListItem Value="AR">Arkansas</asp:ListItem>
	            <asp:ListItem Value="CA">California</asp:ListItem>
	            <asp:ListItem Value="CO">Colorado</asp:ListItem>
	            <asp:ListItem Value="CT">Connecticut</asp:ListItem>
	            <asp:ListItem Value="DC">District of Columbia</asp:ListItem>
	            <asp:ListItem Value="DE">Delaware</asp:ListItem>
	            <asp:ListItem Value="FL">Florida</asp:ListItem>
	            <asp:ListItem Value="GA">Georgia</asp:ListItem>
	            <asp:ListItem Value="HI">Hawaii</asp:ListItem>
	            <asp:ListItem Value="ID">Idaho</asp:ListItem>
	            <asp:ListItem Value="IL">Illinois</asp:ListItem>
	            <asp:ListItem Value="IN">Indiana</asp:ListItem>
	            <asp:ListItem Value="IA">Iowa</asp:ListItem>
	            <asp:ListItem Value="KS">Kansas</asp:ListItem>
	            <asp:ListItem Value="KY">Kentucky</asp:ListItem>
	            <asp:ListItem Value="LA">Louisiana</asp:ListItem>
	            <asp:ListItem Value="ME">Maine</asp:ListItem>
	            <asp:ListItem Value="MD">Maryland</asp:ListItem>
	            <asp:ListItem Value="MA">Massachusetts</asp:ListItem>
	            <asp:ListItem Value="MI">Michigan</asp:ListItem>
	            <asp:ListItem Value="MN">Minnesota</asp:ListItem>
	            <asp:ListItem Value="MS">Mississippi</asp:ListItem>
	            <asp:ListItem Value="MO">Missouri</asp:ListItem>
	            <asp:ListItem Value="MT">Montana</asp:ListItem>
	            <asp:ListItem Value="NE">Nebraska</asp:ListItem>
	            <asp:ListItem Value="NV">Nevada</asp:ListItem>
	            <asp:ListItem Value="NH">New Hampshire</asp:ListItem>
	            <asp:ListItem Value="NJ">New Jersey</asp:ListItem>
	            <asp:ListItem Value="NM">New Mexico</asp:ListItem>
	            <asp:ListItem Value="NY">New York</asp:ListItem>
	            <asp:ListItem Value="NC">North Carolina</asp:ListItem>
	            <asp:ListItem Value="ND">North Dakota</asp:ListItem>
	            <asp:ListItem Value="OH">Ohio</asp:ListItem>
	            <asp:ListItem Value="OK">Oklahoma</asp:ListItem>
	            <asp:ListItem Value="OR">Oregon</asp:ListItem>
	            <asp:ListItem Value="PA">Pennsylvania</asp:ListItem>
	            <asp:ListItem Value="RI">Rhode Island</asp:ListItem>
	            <asp:ListItem Value="SC">South Carolina</asp:ListItem>
	            <asp:ListItem Value="SD">South Dakota</asp:ListItem>
	            <asp:ListItem Value="TN">Tennessee</asp:ListItem>
	            <asp:ListItem Value="TX">Texas</asp:ListItem>
	            <asp:ListItem Value="UT">Utah</asp:ListItem>
	            <asp:ListItem Value="VT">Vermont</asp:ListItem>
	            <asp:ListItem Value="VA">Virginia</asp:ListItem>
	            <asp:ListItem Value="WA">Washington</asp:ListItem>
	            <asp:ListItem Value="WV">West Virginia</asp:ListItem>
	            <asp:ListItem Value="WI">Wisconsin</asp:ListItem>
	            <asp:ListItem Value="WY">Wyoming</asp:ListItem>
            </asp:DropDownList>

            <br />
            <br />
            <asp:Label ID="lblAddBirthCountry" runat="server" Text="Actor's Birth Country: " Font-Bold="True" Font-Size="Large"></asp:Label>
            <asp:DropDownList ID="ddlAddBirthCountry" runat="server">
                <asp:ListItem Value="noneSelected">-----</asp:ListItem>
                    <asp:ListItem>United States</asp:ListItem>
                    <asp:ListItem>Afghanistan</asp:ListItem>
                    <asp:ListItem>Albania</asp:ListItem>
                    <asp:ListItem>Algeria</asp:ListItem>
                    <asp:ListItem>American Samoa</asp:ListItem>
                    <asp:ListItem>Andorra</asp:ListItem>
                    <asp:ListItem>Angola</asp:ListItem>
                    <asp:ListItem>Anguilla</asp:ListItem>
                    <asp:ListItem>Antarctica</asp:ListItem>
                    <asp:ListItem>Antigua And Barbuda</asp:ListItem>
                    <asp:ListItem>Argentina</asp:ListItem>
                    <asp:ListItem>Armenia</asp:ListItem>
                    <asp:ListItem>Aruba</asp:ListItem>
                    <asp:ListItem>Australia</asp:ListItem>
                    <asp:ListItem>Austria</asp:ListItem>
                    <asp:ListItem>Azerbaijan</asp:ListItem>
                    <asp:ListItem>Bahamas</asp:ListItem>
                    <asp:ListItem>Bahrain</asp:ListItem>
                    <asp:ListItem>Bangladesh</asp:ListItem>
                    <asp:ListItem>Barbados</asp:ListItem>
                    <asp:ListItem>Belarus</asp:ListItem>
                    <asp:ListItem>Belgium</asp:ListItem>
                    <asp:ListItem>Belize</asp:ListItem>
                    <asp:ListItem>Benin</asp:ListItem>
                    <asp:ListItem>Bermuda</asp:ListItem>
                    <asp:ListItem>Bhutan</asp:ListItem>
                    <asp:ListItem>Bolivia</asp:ListItem>
                    <asp:ListItem>Bosnia And Herzegowina</asp:ListItem>
                    <asp:ListItem>Botswana</asp:ListItem>
                    <asp:ListItem>Bouvet Island</asp:ListItem>
                    <asp:ListItem>Brazil</asp:ListItem>
                    <asp:ListItem>British Indian Ocean Territory</asp:ListItem>
                    <asp:ListItem>Brunei Darussalam</asp:ListItem>
                    <asp:ListItem>Bulgaria</asp:ListItem>
                    <asp:ListItem>Burkina Faso</asp:ListItem>
                    <asp:ListItem>Burundi</asp:ListItem>
                    <asp:ListItem>Cambodia</asp:ListItem>
                    <asp:ListItem>Cameroon</asp:ListItem>
                    <asp:ListItem>Canada</asp:ListItem>
                    <asp:ListItem>Cape Verde</asp:ListItem>
                    <asp:ListItem>Cayman Islands</asp:ListItem>
                    <asp:ListItem>Central African Republic</asp:ListItem>
                    <asp:ListItem>Chad</asp:ListItem>
                    <asp:ListItem>Chile</asp:ListItem>
                    <asp:ListItem>China</asp:ListItem>
                    <asp:ListItem>Christmas Island</asp:ListItem>
                    <asp:ListItem>Cocos (Keeling) Islands</asp:ListItem>
                    <asp:ListItem>Colombia</asp:ListItem>
                    <asp:ListItem>Comoros</asp:ListItem>
                    <asp:ListItem>Congo</asp:ListItem>
                    <asp:ListItem>Cook Islands</asp:ListItem>
                    <asp:ListItem>Costa Rica</asp:ListItem>
                    <asp:ListItem>Cote D'Ivoire</asp:ListItem>
                    <asp:ListItem>Croatia (Local Name: Hrvatska)</asp:ListItem>
                    <asp:ListItem>Cuba</asp:ListItem>
                    <asp:ListItem>Cyprus</asp:ListItem>
                    <asp:ListItem>Czech Republic</asp:ListItem>
                    <asp:ListItem>Denmark</asp:ListItem>
                    <asp:ListItem>Djibouti</asp:ListItem>
                    <asp:ListItem>Dominica</asp:ListItem>
                    <asp:ListItem>Dominican Republic</asp:ListItem>
                    <asp:ListItem>East Timor</asp:ListItem>
                    <asp:ListItem>Ecuador</asp:ListItem>
                    <asp:ListItem>Egypt</asp:ListItem>
                    <asp:ListItem>El Salvador</asp:ListItem>
                    <asp:ListItem>Equatorial Guinea</asp:ListItem>
                    <asp:ListItem>Eritrea</asp:ListItem>
                    <asp:ListItem>Estonia</asp:ListItem>
                    <asp:ListItem>Ethiopia</asp:ListItem>
                    <asp:ListItem>Falkland Islands (Malvinas)</asp:ListItem>
                    <asp:ListItem>Faroe Islands</asp:ListItem>
                    <asp:ListItem>Fiji</asp:ListItem>
                    <asp:ListItem>Finland</asp:ListItem>
                    <asp:ListItem>France</asp:ListItem>
                    <asp:ListItem>French Guiana</asp:ListItem>
                    <asp:ListItem>French Polynesia</asp:ListItem>
                    <asp:ListItem>French Southern Territories</asp:ListItem>
                    <asp:ListItem>Gabon</asp:ListItem>
                    <asp:ListItem>Gambia</asp:ListItem>
                    <asp:ListItem>Georgia</asp:ListItem>
                    <asp:ListItem>Germany</asp:ListItem>
                    <asp:ListItem>Ghana</asp:ListItem>
                    <asp:ListItem>Gibraltar</asp:ListItem>
                    <asp:ListItem>Greece</asp:ListItem>
                    <asp:ListItem>Greenland</asp:ListItem>
                    <asp:ListItem>Grenada</asp:ListItem>
                    <asp:ListItem>Guadeloupe</asp:ListItem>
                    <asp:ListItem>Guam</asp:ListItem>
                    <asp:ListItem>Guatemala</asp:ListItem>
                    <asp:ListItem>Guinea</asp:ListItem>
                    <asp:ListItem>Guinea-Bissau</asp:ListItem>
                    <asp:ListItem>Guyana</asp:ListItem>
                    <asp:ListItem>Haiti</asp:ListItem>
                    <asp:ListItem>Honduras</asp:ListItem>
                    <asp:ListItem>Hong Kong</asp:ListItem>
                    <asp:ListItem>Hungary</asp:ListItem>
                    <asp:ListItem>Icel And</asp:ListItem>
                    <asp:ListItem>India</asp:ListItem>
                    <asp:ListItem>Indonesia</asp:ListItem>
                    <asp:ListItem>Iran (Islamic Republic Of)</asp:ListItem>
                    <asp:ListItem>Iraq</asp:ListItem>
                    <asp:ListItem>Ireland</asp:ListItem>
                    <asp:ListItem>Israel</asp:ListItem>
                    <asp:ListItem>Italy</asp:ListItem>
                    <asp:ListItem>Jamaica</asp:ListItem>
                    <asp:ListItem>Japan</asp:ListItem>
                    <asp:ListItem>Jordan</asp:ListItem>
                    <asp:ListItem>Kazakhstan</asp:ListItem>
                    <asp:ListItem>Kenya</asp:ListItem>
                    <asp:ListItem>Kiribati</asp:ListItem>
                    <asp:ListItem>Korea</asp:ListItem>
                    <asp:ListItem>Kuwait</asp:ListItem>
                    <asp:ListItem>Kyrgyzstan</asp:ListItem>
                    <asp:ListItem>Lao People'S Dem Republic</asp:ListItem>
                    <asp:ListItem>Latvia</asp:ListItem>
                    <asp:ListItem>Lebanon</asp:ListItem>
                    <asp:ListItem>Lesotho</asp:ListItem>
                    <asp:ListItem>Liberia</asp:ListItem>
                    <asp:ListItem>Libyan Arab Jamahiriya</asp:ListItem>
                    <asp:ListItem>Liechtenstein</asp:ListItem>
                    <asp:ListItem>Lithuania</asp:ListItem>
                    <asp:ListItem>Luxembourg</asp:ListItem>
                    <asp:ListItem>Macau</asp:ListItem>
                    <asp:ListItem>Macedonia</asp:ListItem>
                    <asp:ListItem>Madagascar</asp:ListItem>
                    <asp:ListItem>Malawi</asp:ListItem>
                    <asp:ListItem>Malaysia</asp:ListItem>
                    <asp:ListItem>Maldives</asp:ListItem>
                    <asp:ListItem>Mali</asp:ListItem>
                    <asp:ListItem>Malta</asp:ListItem>
                    <asp:ListItem>Marshall Islands</asp:ListItem>
                    <asp:ListItem>Martinique</asp:ListItem>
                    <asp:ListItem>Mauritania</asp:ListItem>
                    <asp:ListItem>Mauritius</asp:ListItem>
                    <asp:ListItem>Mayotte</asp:ListItem>
                    <asp:ListItem>Mexico</asp:ListItem>
                    <asp:ListItem>Micronesia, Federated States</asp:ListItem>
                    <asp:ListItem>Moldova, Republic Of</asp:ListItem>
                    <asp:ListItem>Monaco</asp:ListItem>
                    <asp:ListItem>Mongolia</asp:ListItem>
                    <asp:ListItem>Montserrat</asp:ListItem>
                    <asp:ListItem>Morocco</asp:ListItem>
                    <asp:ListItem>Mozambique</asp:ListItem>
                    <asp:ListItem>Myanmar</asp:ListItem>
                    <asp:ListItem>Namibia</asp:ListItem>
                    <asp:ListItem>Nauru</asp:ListItem>
                    <asp:ListItem>Nepal</asp:ListItem>
                    <asp:ListItem>Netherlands</asp:ListItem>
                    <asp:ListItem>Netherlands Ant Illes</asp:ListItem>
                    <asp:ListItem>New Caledonia</asp:ListItem>
                    <asp:ListItem>New Zealand</asp:ListItem>
                    <asp:ListItem>Nicaragua</asp:ListItem>
                    <asp:ListItem>Niger</asp:ListItem>
                    <asp:ListItem>Nigeria</asp:ListItem>
                    <asp:ListItem>Niue</asp:ListItem>
                    <asp:ListItem>Norfolk Island</asp:ListItem>
                    <asp:ListItem>Northern Mariana Islands</asp:ListItem>
                    <asp:ListItem>Norway</asp:ListItem>
                    <asp:ListItem>Oman</asp:ListItem>
                    <asp:ListItem>Pakistan</asp:ListItem>
                    <asp:ListItem>Palau</asp:ListItem>
                    <asp:ListItem>Panama</asp:ListItem>
                    <asp:ListItem>Papua New Guinea</asp:ListItem>
                    <asp:ListItem>Paraguay</asp:ListItem>
                    <asp:ListItem>Peru</asp:ListItem>
                    <asp:ListItem>Philippines</asp:ListItem>
                    <asp:ListItem>Pitcairn</asp:ListItem>
                    <asp:ListItem>Poland</asp:ListItem>
                    <asp:ListItem>Portugal</asp:ListItem>
                    <asp:ListItem>Puerto Rico</asp:ListItem>
                    <asp:ListItem>Qatar</asp:ListItem>
                    <asp:ListItem>Reunion</asp:ListItem>
                    <asp:ListItem>Romania</asp:ListItem>
                    <asp:ListItem>Russian Federation</asp:ListItem>
                    <asp:ListItem>Rwanda</asp:ListItem>
                    <asp:ListItem>Saint K Itts And Nevis</asp:ListItem>
                    <asp:ListItem>Saint Lucia</asp:ListItem>
                    <asp:ListItem>Saint Vincent, The Grenadines</asp:ListItem>
                    <asp:ListItem>Samoa</asp:ListItem>
                    <asp:ListItem>San Marino</asp:ListItem>
                    <asp:ListItem>Sao Tome And Principe</asp:ListItem>
                    <asp:ListItem>Saudi Arabia</asp:ListItem>
                    <asp:ListItem>Senegal</asp:ListItem>
                    <asp:ListItem>Seychelles</asp:ListItem>
                    <asp:ListItem>Sierra Leone</asp:ListItem>
                    <asp:ListItem>Singapore</asp:ListItem>
                    <asp:ListItem>Slovakia (Slovak Republic)</asp:ListItem>
                    <asp:ListItem>Slovenia</asp:ListItem>
                    <asp:ListItem>Solomon Islands</asp:ListItem>
                    <asp:ListItem>Somalia</asp:ListItem>
                    <asp:ListItem>South Africa</asp:ListItem>
                    <asp:ListItem>South Georgia , S Sandwich Is.</asp:ListItem>
                    <asp:ListItem>Spain</asp:ListItem>
                    <asp:ListItem>Sri Lanka</asp:ListItem>
                    <asp:ListItem>St. Helena</asp:ListItem>
                    <asp:ListItem>St. Pierre And Miquelon</asp:ListItem>
                    <asp:ListItem>Sudan</asp:ListItem>
                    <asp:ListItem>Suriname</asp:ListItem>
                    <asp:ListItem>Svalbard, Jan Mayen Islands</asp:ListItem>
                    <asp:ListItem>Sw Aziland</asp:ListItem>
                    <asp:ListItem>Sweden</asp:ListItem>
                    <asp:ListItem>Switzerland</asp:ListItem>
                    <asp:ListItem>Syrian Arab Republic</asp:ListItem>
                    <asp:ListItem>Taiwan</asp:ListItem>
                    <asp:ListItem>Tajikistan</asp:ListItem>
                    <asp:ListItem>Tanzania, United Republic Of</asp:ListItem>
                    <asp:ListItem>Thailand</asp:ListItem>
                    <asp:ListItem>Togo</asp:ListItem>
                    <asp:ListItem>Tokelau</asp:ListItem>
                    <asp:ListItem>Tonga</asp:ListItem>
                    <asp:ListItem>Trinidad And Tobago</asp:ListItem>
                    <asp:ListItem>Tunisia</asp:ListItem>
                    <asp:ListItem>Turkey</asp:ListItem>
                    <asp:ListItem>Turkmenistan</asp:ListItem>
                    <asp:ListItem>Turks And Caicos Islands</asp:ListItem>
                    <asp:ListItem>Tuvalu</asp:ListItem>
                    <asp:ListItem>Uganda</asp:ListItem>
                    <asp:ListItem>Ukraine</asp:ListItem>
                    <asp:ListItem>United Arab Emirates</asp:ListItem>
                    <asp:ListItem>United Kingdom</asp:ListItem>
                    <asp:ListItem>United States</asp:ListItem>
                    <asp:ListItem>United States Minor Is.</asp:ListItem>
                    <asp:ListItem>Uruguay</asp:ListItem>
                    <asp:ListItem>Uzbekistan</asp:ListItem>
                    <asp:ListItem>Vanuatu</asp:ListItem>
                    <asp:ListItem>Venezuela</asp:ListItem>
                    <asp:ListItem>Viet Nam</asp:ListItem>
                    <asp:ListItem>Virgin Islands (British)</asp:ListItem>
                    <asp:ListItem>Virgin Islands (U.S.)</asp:ListItem>
                    <asp:ListItem>Wallis And Futuna Islands</asp:ListItem>
                    <asp:ListItem>Western Sahara</asp:ListItem>
                    <asp:ListItem>Yemen</asp:ListItem>
                    <asp:ListItem>Yugoslavia</asp:ListItem>
                    <asp:ListItem>Zaire</asp:ListItem>
                    <asp:ListItem>Zambia</asp:ListItem>
                    <asp:ListItem>Zimbabwe</asp:ListItem> 
            </asp:DropDownList>


          <br /><br />
            <asp:Label ID="lblAddDescription" runat="server" Text="Tell Us About the Actor Below: " Font-Bold="True" Font-Size="Large"></asp:Label>
            <br />
            <asp:TextBox ID="txtAddDescription" runat="server" TextMode="multiline" Columns="60" Rows="6"></asp:TextBox>
            <asp:RequiredFieldValidator ControlToValidate="txtAddDescription" ID="ans1Validator" runat="server" ErrorMessage="Description needed!" Display="Dynamic"></asp:RequiredFieldValidator>
          
            
            <br />
            <asp:Button ID="btnSubmit" runat="server"  Text="Submit" CssClass="button" OnClick="btnSubmit_Click"/>
            <asp:Button ID="btnClear" runat="server"  Text="Clear Fields" CssClass="button" OnClick="btnClear_Click" />
         </div>
       

            <div class="column"> 
                <br /> <br /> <br /> <br /> <br />
                <img src="Images/cast.jpg" style="width: 670px; height: 430px;" class="editorImage"/>
                <small>Cast of Fast and Furious</small>
            </div>
             </div>
            </div>
     
        <Footer:HomeFooter ID="FooterNav" runat="server" />
    </form>
</body>
</html>
