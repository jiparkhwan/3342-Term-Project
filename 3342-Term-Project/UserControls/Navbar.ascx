<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Navbar.ascx.cs" Inherits="_3342_Term_Project.UserControls.Navbar" %>


 <nav class="navbar navbar-expand-lg navbar-dark bg-dark">
  <a class="navbar-brand" href="HomePage.aspx">Lexpark</a>
  <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarNavDropdown" aria-controls="navbarNavDropdown" aria-expanded="false" aria-label="Toggle navigation">
    <span class="navbar-toggler-icon"></span>
  </button>
  <div class="collapse navbar-collapse" id="navbarNavDropdown">
    <ul class="navbar-nav">
      
      <li>
          <div class="form-inline my-2 my-lg-0">
              <div class="navSearch">
                      <div class="dropdown-search">
                          <asp:DropDownList ID="ColorList"
                              class="dropdown-search"
                              AutoPostBack="True"
                              runat="server">

                              <asp:ListItem Selected="True" Value="All"> All </asp:ListItem>
                              <asp:ListItem Value="Movies"> Movies </asp:ListItem>
                              <asp:ListItem Value="TV_Shows"> TV Shows </asp:ListItem>
                              <asp:ListItem Value="Video_Games"> Video Games </asp:ListItem>
                              <asp:ListItem Value="Actors"> Actors </asp:ListItem>
                          </asp:DropDownList>
                      </div>
                       <asp:TextBox id="txtSearch" class="form-control mr-sm-2" placeholder="Search Lexpark" runat="server" aria-label="Search" />
                       <asp:Button ID="btnSearch" runat="server" class="btn btn-outline-primary my-2 my-sm-0" type="submit" Text="Search" />
                  </div>
          </div>
       
      </li> 
      
      <li class="nav-item">
        <a class="nav-link" href="MyAccount.aspx">My Account</a>
      </li>
      <li class="nav-item">
         <a class="nav-link" href="Login.aspx">Log-In</a>
      </li>
    </ul>

    


   
  </div>
</nav>