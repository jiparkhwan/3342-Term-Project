<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Navbar.ascx.cs" Inherits="_3342_Term_Project.UserControls.Navbar" %>



<nav class="navbar navbar-expand-lg navbar-dark "style="background:#282627;">
  <a class="navbar-brand" href="HomePage.aspx">LEXPARK</a>
  <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarNav" aria-controls="navbarNav" aria-expanded="false" aria-label="Toggle navigation">
    <span class="navbar-toggler-icon"></span>
  </button>
  <div class="collapse navbar-collapse" id="navbarNav">
    <ul class="navbar-nav">
      <li class="nav-item">
        <a class="nav-link" runat="server" ID="HomeBtn" onclick="homeClick" href="HomePage.aspx">Home <span class="sr-only">(current)</span></a>
      </li>
      <li class="nav-item">
        <a class="nav-link" href="MemberManagement.aspx">Management</a>
      </li>
      <li class="nav-item">
        <a class="nav-link" href="MyAccount.aspx">Account</a>
      </li>
      <li class="nav-item">
        <a class="nav-link" href="Login.aspx">Log Out</a>
      </li>
    </ul>
  </div>
</nav>