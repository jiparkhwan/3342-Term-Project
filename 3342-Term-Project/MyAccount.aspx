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
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.0/css/bootstrap.min.css" />

 
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>

    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.0/js/bootstrap.min.js"></script>
    <!-- Load icon library -->
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css" />
    <link rel="shortcut icon" type="image/png" href="Images/LexParkLogo.png" />
    <link href="Styles.css" rel="stylesheet" />

    <!-- REFERENCES END-->
    <title>Manage Account Info</title>
</head>
<body>
    <form id="frmMyAccount" runat="server">
        <Navigation:HomeNav ID="HomeNav" runat="server" />

        <div class="mainAccount">

            <div class="container">
                <div class="editInfo">
                    <h2>Edit Account Info</h2>
                <div class="form-row">

                    <div class="form-group col-md-12">

                        <asp:Label ID="lblManageEmail" runat="server" Text="New Email: "></asp:Label>
                        <br />
                        <asp:TextBox ID="txtManageEmail" runat="server"></asp:TextBox>
                    </div>

                    <div class="form-group col-md-12">
                        <asp:Label ID="lblManagePassword" runat="server" Text="New Password: "></asp:Label>
                        <br />
                        <asp:TextBox ID="txtManagePassword" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="form-row">
                    <div class="form-group col-md-12">
                        <asp:Label ID="lblManagePasswordConfirm" runat="server" Text="Password Confirm: "></asp:Label>
                        <br />
                        <asp:TextBox ID="txtManagePasswordConfirm" runat="server"></asp:TextBox>
                    </div>
                    <div class="fotrm-group col-md-12">
                        <asp:Label ID="lblManageFName" runat="server" Text="New First Name: "></asp:Label>
                        <br />
                        <asp:TextBox ID="txtManageName" runat="server"></asp:TextBox>
                    </div>
                </div>

                <div class="form-row">
                    <div class="form-group col-md-12">
                        <asp:Label ID="lblManageLName" runat="server" Text="New Last Name: "></asp:Label>
                        <br />
                        <asp:TextBox ID="txtManageLName" runat="server"></asp:TextBox>
                    </div>
                    <div class="form-group col-md-12">
                        <asp:Label ID="lblManageDOB" runat="server" Text="New Date of Birth: " ></asp:Label>
                        <br />
                        <asp:TextBox ID="txtDateOfBirth" runat="server"></asp:TextBox>
                    </div>
                </div>
                </div>



                <div class="favorites">
                    <br />
                    <h3>Favorites</h3>
                    <small>Edit Or Submit Your Favorites</small>
                    <br />
                    <asp:Label runat="server" ID="favoritesLbl" Text=""></asp:Label>
                    <br />
                    <div class="form-row">
                        <div class="form-group col-md-12">
                            <asp:Label ID="favoriteActor" runat="server" Text="Favorite Actor: " Font-Bold="True" Font-Size="Medium"></asp:Label>
                            <br />
                            <asp:TextBox ID="txtfavoriteActor" runat="server"></asp:TextBox>
                        </div>
                        <div class="form-group col-md-12">
                            <asp:Label ID="favoriteMovie" runat="server" Text="Favorite Movie: " Font-Bold="True" Font-Size="Medium"></asp:Label>
                            <br />
                            <asp:TextBox ID="txtfavoriteMovie" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-row">
                        <div class="form-group col-md-12">
                            <asp:Label ID="favoriteTVShow" runat="server" Text="Favorite TV Show: " Font-Bold="True" Font-Size="Medium"></asp:Label>
                            <br />
                            <asp:TextBox ID="txtfavoriteTVShow" runat="server"></asp:TextBox>
                        </div>
                        <div class="form-group col-md-12">
                            <asp:Label ID="favoriteVideoGame" runat="server" Text="Favorite Video Game: " Font-Bold="True" Font-Size="Medium"></asp:Label>
                            <br />
                            <asp:TextBox ID="txtfavoriteVideoGame" runat="server"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <br />
                <br />  <br />
                <br />  <br />
                <br />  <br />
                <br />  <br />
                <br />  <br />
                <br />  <br />
                <br />  <br />
                <br />  <br />
                <br />  <br />
                <br />  <br />
                <br />  <br />
                <br />
                <asp:Label ID="lblDisplay" runat="server" Text="" Font-Bold="True" Font-Size="Medium" ForeColor="Red"></asp:Label>
                <br />
                <asp:Button ID="btnSubmit" runat="server" CssClass="button" Text="Submit" OnClick="btnSubmitChange_Click" />
                <asp:Button ID="btnClear" runat="server" CssClass="button" Text="Clear Fields" />
                <br />
                <br />
            </div>

            </div>
             <Footer:HomeFooter ID="FooterNav" runat="server" />
    </form>
   

</body>
</html>
