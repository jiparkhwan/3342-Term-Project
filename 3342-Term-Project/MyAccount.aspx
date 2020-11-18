<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyAccount.aspx.cs" Inherits="_3342_Term_Project.MyAccount" %>
<%@ Register Src="~/UserControls/Navbar.ascx" TagName="HomeNav" TagPrefix="Navigation" %>
<%@ Register Src="~/UserControls/Footer.ascx" TagName="HomeFooter" TagPrefix="Footer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <!-- REFERENCES START-->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" />

    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <link href="https://fonts.googleapis.com/css?family=Roboto:100,100i,300,300i,400,400i,500,500i,700,700i,900,900i" rel="stylesheet" />
    <script src="//ajax.googleapis.com/ajax/libs/jquery/1.11.0/jquery.min.js"></script>
    <script src="//netdna.bootstrapcdn.com/bootstrap/3.1.1/js/bootstrap.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.0/js/bootstrap.min.js"></script>

    <!-- Load icon library -->
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css" />

    <link href="Styles.css" rel="stylesheet" />

    <!-- REFERENCES END-->
    <title>Manage Account Info</title>
</head>
<body>
    <form id="frmMyAccount" runat="server">
        <Navigation:HomeNav ID="HomeNav" runat="server" />
        <div class="mainAccount">
            <br />
            <br />
            <h1>Manage Account Information</h1>
            <br />
           <asp:Label ID="Label1" runat="server" Text="Current Info: " Font-Bold="True" Font-Size="Large"></asp:Label>
            <br />
                       <asp:Label ID="currentEmail" runat="server" Text="Email: " Font-Bold="True" Font-Size="Medium"></asp:Label>
                        <asp:Label ID="txtcurrentEmail" runat="server" Text="" Font-Bold="True" Font-Size="Medium"></asp:Label>

            <br />
                       <asp:Label ID="currentPassword" runat="server" Text="Password: " Font-Bold="True" Font-Size="Medium"></asp:Label>
                        <asp:Label ID="txtcurrentPassword" runat="server" Text="" Font-Bold="True" Font-Size="Medium"></asp:Label>

            <br />          
            <asp:Label ID="currentDOB" runat="server" Text="Date of Birth: " Font-Bold="True" Font-Size="Medium"></asp:Label>
           <asp:Label ID="txtcurrentDOB" runat="server" Text="" Font-Bold="True" Font-Size="Medium"></asp:Label>

            <br />          
            <asp:Label ID="currentName" runat="server" Text="Name: " Font-Bold="True" Font-Size="Medium"></asp:Label>
            <asp:Label ID="txtcurrentName" runat="server" Text="" Font-Bold="True" Font-Size="Medium"></asp:Label>

            <br />
            <br />
            <br />
            <asp:Label ID="lblManageEmail" runat="server" Text="New Email: " Font-Bold="True" Font-Size="Large"></asp:Label>
            <asp:TextBox ID="txtManageEmail" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="lblManagePassword" runat="server" Text="New Password: " Font-Bold="True" Font-Size="Large"></asp:Label>
            <asp:TextBox ID="txtManagePassword" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="lblManagePasswordConfirm" runat="server" Text="Password Confirm: " Font-Bold="True" Font-Size="Large"></asp:Label>
            <asp:TextBox ID="txtManagePasswordConfirm" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="lblManageFName" runat="server" Text="New First Name: " Font-Bold="True" Font-Size="Large"></asp:Label>
            <asp:TextBox ID="txtManageName" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="lblManageLName" runat="server" Text="New Last Name: " Font-Bold="True" Font-Size="Large"></asp:Label>
            <asp:TextBox ID="txtManageLName" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="lblManageDOB" runat="server" Text="New Date of Birth: " Font-Bold="True" Font-Size="Large"></asp:Label>
            <asp:TextBox ID="txtDateOfBirth" runat="server"></asp:TextBox>
            <br />
            <br />
           
            <br />
                        <asp:Label ID="Favoriteslbl" runat="server" Text="Favorites" Font-Bold="True" Font-Size="X-Large"></asp:Label>
            <br />
            <asp:Label ID="favoriteActor" runat="server" Text="Favorite Actor: " Font-Bold="True" Font-Size="Medium"></asp:Label>
            <asp:TextBox ID="txtfavoriteActor" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="favoriteMovie" runat="server" Text="Favorite Movie: " Font-Bold="True" Font-Size="Medium"></asp:Label>
            <asp:TextBox ID="txtfavoriteMovie" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="favoriteTVShow" runat="server" Text="Favorite TV Show: " Font-Bold="True" Font-Size="Medium"></asp:Label>
            <asp:TextBox ID="txtfavoriteTVShow" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="favoriteVideoGame" runat="server" Text="Favorite Video Game: " Font-Bold="True" Font-Size="Medium"></asp:Label>
            <asp:TextBox ID="txtfavoriteVideoGame" runat="server"></asp:TextBox>
            <br /><br />
                        <asp:Label ID="lblDisplay" runat="server" Text="" Font-Bold="True" Font-Size="Medium" ForeColor ="Red"></asp:Label>

            <asp:Button ID="btnSubmit" runat="server" Text="Submit Changes" Font-Bold="True" OnClick="btnSubmitChange_Click"/>
            <asp:Button ID="btnClear" runat="server" Text="Clear All Fields" Font-Bold="True" />
            <br />
            <br />
        </div>
        <Footer:HomeFooter ID="FooterNav" runat="server" />
    </form>
</body>
</html>
