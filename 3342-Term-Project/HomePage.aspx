<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="_3342_Term_Project.HomePage" %>
<%@ Register Src="~/UserControls/Navbar.ascx" TagName="HomeNav" TagPrefix="Navigation" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <title>Term Project</title>

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
</head>
<body>
    
      <form method="post" runat="server">
            <Navigation:HomeNav ID="HomeNav" runat="server" />




          <div class="form-inline my-2 my-lg-0">
              <div class="nav-item dropdown">
                  <div class="dropdown-search">
                      <asp:DropDownList ID="ColorList"
                          class="dropdown-search"
                          AutoPostBack="True"
                          OnSelectedIndexChanged="ddlSearch_SelectedIndexChanged"
                          runat="server">

                          <asp:ListItem Selected="True" Value="All"> All </asp:ListItem>
                          <asp:ListItem Value="Movies"> Movies </asp:ListItem>
                          <asp:ListItem Value="Shows"> Shows </asp:ListItem>
                          <asp:ListItem Value="Commercials"> Commercials </asp:ListItem>

                      </asp:DropDownList>
                  </div>
              </div>
              <asp:TextBox class="form-control mr-sm-2" placeholder="Search Lexpark" runat="server" aria-label="Search" />
              <asp:Button ID="btnSearch" runat="server" class="btn btn-outline-primary my-2 my-sm-0" type="submit" Text="Search" OnClick="btnSearchClick" />
          </div>

      </form>
</body>
</html>
