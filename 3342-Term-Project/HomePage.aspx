<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="_3342_Term_Project.HomePage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <title>Term Project</title>


<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css"/>

    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <link href="https://fonts.googleapis.com/css?family=Roboto:100,100i,300,300i,400,400i,500,500i,700,700i,900,900i" rel="stylesheet"/>
    <script src="//ajax.googleapis.com/ajax/libs/jquery/1.11.0/jquery.min.js"></script>
<script src="//netdna.bootstrapcdn.com/bootstrap/3.1.1/js/bootstrap.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.0/js/bootstrap.min.js"></script>

    <link href="Styles.css" rel="stylesheet" />
</head>
<body>
      <form method="post" runat="server">
   <nav class="navbar navbar-expand-lg navbar-dark bg-dark">
  <a class="navbar-brand" href="#">Lexpark</a>
  <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarNavDropdown" aria-controls="navbarNavDropdown" aria-expanded="false" aria-label="Toggle navigation">
    <span class="navbar-toggler-icon"></span>
  </button>
  <div class="collapse navbar-collapse" id="navbarNavDropdown">
    <ul class="navbar-nav">
      <li class="nav-item active">
        <a class="nav-link" href="#">Home <span class="sr-only">(current)</span></a>
      </li>
      <li class="nav-item">
        <a class="nav-link" href="#">Account</a>
      </li>
      <li class="nav-item">
        <a class="nav-link" href="#">Settings</a>
      </li>
         <li class="nav-item dropdown">
             <div class="dropdown-search">
     <asp:DropDownList id="ColorList"
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
             </li>

    </ul>

    

 <div class="form-inline my-2 my-lg-0">
      <input class="form-control mr-sm-2" type="search" placeholder="Search Lexpark" aria-label="Search"/>
      <asp:Button ID="btnSearch" runat="server" class="btn btn-outline-primary my-2 my-sm-0" type="submit" Text="Search"/>
    </div>

   
  </div>
</nav>
          </form>
</body>
</html>