<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="_3342_Term_Project.HomePage" %>
<%@ Register Src="~/UserControls/Navbar.ascx" TagName="HomeNav" TagPrefix="Navigation" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <title>Home Page</title>
    <!-- Latest compiled and minified CSS -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
    <!-- jQuery library -->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <!-- Latest compiled JavaScript -->
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
    <link href="Styles.css" rel="stylesheet" />

</head>



<body>
    <form id="frmHomePage" method="post" runat="server">
        <Navigation:HomeNav ID="HomeNav" runat="server" />
            <div class="mainHome">
                <div class="section-hero">

                    <!--Panel that allows user to search for items via the textbox-->
                    <br />
                    <asp:Panel ID="pnlSearchMedia" runat="server" Visible="false">
                        <asp:DropDownList ID="ddlSelectMedia" runat="server">
                            <asp:ListItem Value="movies">Movies</asp:ListItem>
                            <asp:ListItem Value="shows">TV Shows</asp:ListItem>
                            <asp:ListItem Value="videoGames">Video Games</asp:ListItem>
                            <asp:ListItem Value="actors">Actors</asp:ListItem>
                        </asp:DropDownList>
                        <asp:TextBox ID="txtFindByName" runat="server"></asp:TextBox>
                        <asp:Button ID="btnFindByName"  Text="Search" runat="server" OnClick="btnFindByName_Click" CssClass="btn btn-primary" />
                        <asp:Button ID="btnRandMovie" runat="server" Text="Random Movie" OnClick="btnRandMovie_Click" />
                        <asp:Label ID="lblError" runat="server"></asp:Label>
                    </asp:Panel>
                    <asp:ScriptManager runat="server"></asp:ScriptManager>

                </div>
                <asp:Label ID="ErrorText" Text="" runat="server"></asp:Label>
                    <asp:Panel ID="RepeaterPanel" runat="server" HoroziontalAlign="Center">
                        <Center>
                            <asp:Repeater ID="rptHomeSearchRes" runat="server">
                                <HeaderTemplate>
                                    <table style="width: 400px; height:40px;">
                                        <tr style=" font-size: large; font-weight: bold;">
                                            <td style="text-align:center;">
                                                <h2>Results</h2>
                                            </td>
                                        </tr>
                                    </table>
                                </HeaderTemplate>

                                <ItemTemplate>     
                                    <table style="width: 200px; height:200px;">
                                        <tr>
                                        <tr style="background-color: #e6e6e6">
                                            <td>
                                                <br />
                                                <table style="background-color: #e6e6e6;  width: 300px; height:20px; text-align:center;">
                                                    <asp:ImageButton ID="imgResultImage" Height="220" Width="170" BorderStyle="Solid" runat="server" ImageUrl='<%# Eval("movieImage") %>' OnCommand="Image_Click" CommandName="ImageClick" CommandArgument='<%# Eval("movieID") %>'/>

                                            </td>
                                        </tr>
                                    </table>
                                    <td>
                                        <table style="background-color: #e6e6e6; width: 600px; text-align:center;">
                                            <tr>
                                                <h1><asp:Label ID="lblName" runat="server" fontBold ="true" Text='<%#Eval("movieName") %>'/></h1>
                                                <br />
                                            </tr>
                                                <td style="width: 50%; font-size: 1.25em;"><strong>Year:</strong> 
                                                    <asp:Label ID="lblUser" runat="server" Text='<%#Eval("movieYear") %>' />
                                                </td>
                                                <td style="width: 50%; font-size: 1.25em;"><strong>Rating:</strong>
                                                    <asp:Label ID="Label1" runat="server" Text='<%#Eval("movieAgeRating") %>' />
                                                </td>
                                            </tr>                                 
                                        </table>
                                    </td>
                                    <br />        
                                </ItemTemplate>
                                
        </asp:Repeater>
                                </Center>
            </asp:Panel>
                </div>
            </div>

      </form>


<%--

                    <asp:Panel ID="pnlFindMovieByAgeRate" runat="server" Visible="false">
                        <asp:Label ID="lblRating" Text="Rating: " runat="server"></asp:Label>
                        <asp:DropDownList ID="ddlRating" runat="server">
                            <asp:ListItem Value="G">G</asp:ListItem>
                            <asp:ListItem Value="PG">PG</asp:ListItem>
                            <asp:ListItem Value="PG-13">PG-13</asp:ListItem>
                            <asp:ListItem Value="R">R</asp:ListItem>
                           
                        </asp:DropDownList>
                        <asp:Button ID="btnFindMoviesRating" Text="Search" runat="server" OnClick="btnFindMoviesRating_Click" CssClass="btn btn-primary" />
                    </asp:Panel>

                    <asp:Panel ID="pnlFindMoviesByGenre" runat="server" Visible="false">
                     <asp:Label ID="lblGenere" Text="Genre: " runat="server"></asp:Label>

                        <asp:DropDownList ID="ddlGenre" runat="server">
                            <asp:ListItem Value="Superhero">Superhero</asp:ListItem>
                            <asp:ListItem Value="Comedy">Comedy</asp:ListItem>
                            <asp:ListItem Value="Action">Action</asp:ListItem>
                            <asp:ListItem Value="Adventure">Adventure</asp:ListItem>
                             <asp:ListItem Value="Drama">Drama</asp:ListItem>
                             <asp:ListItem Value="Family">Family</asp:ListItem>

                             <asp:ListItem Value="Biography">Biography</asp:ListItem>
                             
                        </asp:DropDownList>
                        <asp:Button ID="btnFindMoviesGenre" Text="Search" runat="server" OnClick="btnFindMoviesGenre_Click" CssClass="btn btn-primary" />
                    </asp:Panel>


                    
          </div>
         
 
    
       

         --%>
    <style>
        .repeater-container {
                 max-width: 1200px;
      text-align: center;
      margin: 0 auto;
      padding: 0 3rem;
        }
        .section-hero {
                 max-width: 1200px;
      text-align: center;
      margin: 0 auto;
      padding: 0 3rem;
        }
        #repeaterResults {
            text-align:center;
        }
    </style>
</body>
</html>

