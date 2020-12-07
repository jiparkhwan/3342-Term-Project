<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MemberManagement.aspx.cs" Inherits="_3342_Term_Project.MemberManagement" %>
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
    <link rel="shortcut icon" type="image/png" href="Images/LexParkLogo.png" />
    <link href="Styles.css" rel="stylesheet" />
    <title>Member Managment</title>
</head>
<body>
    <form id="frmMemberManagement" runat="server">
        <Navigation:HomeNav ID="HomeNav" runat="server" />
        <div class="mainMemManagement">
                <div class="center">
           
                <h3>Add To Our Listing</h3>
            
               <asp:Button ID="btnAddActor" runat="server" CssClass="button" HorizontalAlign="Center" Text="Actor" OnClick="lnkBtnAddActor_Click"/>
       
               <asp:Button ID="btnAddMovie" runat="server" CssClass="button" HorizontalAlign="Center" Text="Movie" OnClick="lnkBtnAddMovie_Click"/>
       

               <asp:Button ID="btnShowClick" runat="server" CssClass="button" HorizontalAlign="Center" Text="TV Show" OnClick="lnkbtnShowClick_Click"/>
               <asp:Button ID="btnGameClick" runat="server" CssClass="button" HorizontalAlign="Center" Text="Game" OnClick="lnkbtnGameClick_Click"/>

             
           
        </div>
        </div>
        <Footer:HomeFooter ID="FooterNav" runat="server" />
    </form>
    <style>
        body {
            background-color:#343233;
            background-image: none;
        }
    </style>
</body>
</html>
