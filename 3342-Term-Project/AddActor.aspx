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
        <div class="mainAddActor">
            <Center>
            <br />
            <br />
            <h1>Add An Actor</h1>
            <hr />
            <br />
            <h3>Found an upcoming actor that we're not aware of? Add them here!</h3>
            <br />
            <br />
            <asp:Label ID="lblAddImage" runat="server" Text="Image URL: " Font-Bold="True" Font-Size="Large"></asp:Label>
            <asp:TextBox ID="txtAddImage" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ControlToValidate="txtAddImage" ID="ImageValidator" runat="server" ErrorMessage="Name Required"></asp:RequiredFieldValidator>
            <br />
            <br />
            <asp:Label ID="lblAddName" runat="server" Text="Actor's Full Name: " Font-Bold="True" Font-Size="Large"></asp:Label>
            <asp:TextBox ID="txtAddName" runat="server"></asp:TextBox>
       <asp:RequiredFieldValidator ControlToValidate="txtAddName" ID="RequiredFieldValidator1" runat="server" ErrorMessage="Name Required"></asp:RequiredFieldValidator>

            <br />
            <br />
            <asp:Label ID="lblAddHeight" runat="server" Text="Actor's Height: " Font-Bold="True" Font-Size="Large"></asp:Label>
            <asp:TextBox ID="txtAddHeight" runat="server"></asp:TextBox>
             <asp:RequiredFieldValidator ControlToValidate="txtAddHeight" ID="heightValidator" runat="server" ErrorMessage="Height required"></asp:RequiredFieldValidator>
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
                <asp:ListItem Value="noneSelected">----</asp:ListItem>
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
                <asp:ListItem Value="noneSelected">----</asp:ListItem>
            </asp:DropDownList>
            <br />
            <br />
            <asp:Label ID="lblAddBirthCity" runat="server" Text="Actor's Birth City: " Font-Bold="True" Font-Size="Large"></asp:Label>
            <asp:TextBox ID="txtAddBirthCity" runat="server"></asp:TextBox>
      <asp:RequiredFieldValidator ControlToValidate="txtAddBirthCity" ID="RequiredFieldValidator4" runat="server" ErrorMessage="Please enter the city!"></asp:RequiredFieldValidator>

            <br />
            <br />
            <asp:Label ID="lblAddBirthState" runat="server" Text="Actor's Birth State: " Font-Bold="True" Font-Size="Large"></asp:Label>
            <asp:TextBox ID="txtAddBirthState" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ControlToValidate="txtAddBirthState" ID="RequiredFieldValidator3" runat="server" ErrorMessage="Please enter the state!"></asp:RequiredFieldValidator>

            <br />
            <br />
            <asp:Label ID="lblAddBirthCountry" runat="server" Text="Actor's Birth Country: " Font-Bold="True" Font-Size="Large"></asp:Label>
            <asp:TextBox ID="txtAddBirthCountry" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ControlToValidate="txtAddBirthCountry" ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please enter the country!"></asp:RequiredFieldValidator>

            <br />
            <br />
            <asp:Label ID="lblAddDescription" runat="server" Text="Tell Us About the Actor Below: " Font-Bold="True" Font-Size="Large"></asp:Label>
            <br />
            <asp:TextBox ID="txtAddDescription" runat="server" TextMode="multiline" Columns="60" Rows="6"></asp:TextBox>
          <asp:RequiredFieldValidator ControlToValidate="txtAddDescription" ID="ans1Validator" runat="server" ErrorMessage="Description needed!"></asp:RequiredFieldValidator>
            <br />
            <br />
             <asp:Label ID="lblDisplay" runat="server" Text="" ForeColor="red"></asp:Label>

            <asp:Button ID="btnSubmit" runat="server"  Text="Add Actor" Font-Bold="True" OnClick="btnSubmit_Click"/>
            <asp:Button ID="btnClear" runat="server"  Text="Clear Fields" Font-Bold="True" />
            <br />
            <br />
            <br />
        </div>
        </Center>
        <Footer:HomeFooter ID="FooterNav" runat="server" />
    </form>
</body>
</html>
