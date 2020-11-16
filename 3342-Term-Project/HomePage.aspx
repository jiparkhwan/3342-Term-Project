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
        <Navigation:HomeNav ID="HomeNav1" runat="server" />
          <div class="homeMainContent">
            <asp:Panel ID="pnlFindMoviesName" runat="server" Visible="false">
                        <asp:Label ID="Label6" Text="Movie Name: " runat="server"></asp:Label>
                        <asp:TextBox ID="txtMovieName" runat="server"></asp:TextBox>
                     
                        <asp:Button ID="btnFindMovieName"  Text="Search" runat="server" OnClick="btnFindMovieName_Click" CssClass="btn btn-primary" />
                    </asp:Panel>
                  <asp:ScriptManager runat="server"></asp:ScriptManager>

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



                    <asp:Label ID="lblFindFriendsErrorMessage" runat="server"></asp:Label>
                    <%--
                    <asp:GridView runat="server" ID="gvResults" AutoGenerateColumns="False" DataKeyNames="Email" OnRowCommand="gvResults_RowCommand">
                        <Columns>
                            <asp:ImageField DataImageUrlField="ProfilePhotoUrl" ControlStyle-Width="50px" ControlStyle-Height="50px">
                                <ControlStyle Height="50px" Width="50px"></ControlStyle>
                            </asp:ImageField>
                            <asp:BoundField DataField="FirstName" />
                            <asp:BoundField DataField="LastName" />
                            <asp:BoundField DataField="State" />
                            <asp:BoundField DataField="City" />
                            <asp:BoundField DataField="Organization" />
                            <asp:ButtonField CommandName="viewProfile" Text="View Profile"/>
                            <asp:ButtonField CommandName="sendRequest" Text="Add Friend"/>
                        </Columns>
                    </asp:GridView>
                                --%>
                </div>
            </div>
          

      </form>

            <div class="col-md-1"></div>
        </div>

        <asp:Repeater ID="repeaterResults" runat="server" OnItemCommand="repeaterResults_ItemCommand">
            <HeaderTemplate>
                <table style="border: 1px solid #0000FF; width: 500px" cellpadding="0">
                    <tr style="background-color: navy; color: white; font-size: large; font-weight: bold;">
                        <td colspan="2">
                            <b>Movies</b>
                        </td>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr style="background-color: #EBEFF0">
                    <td>
                        <table style="background-color: #EBEFF0; border-top: 1px dotted #df5015; width: 500px">
                         <td >
                       <asp:Image ID="Image1" height="120" width="100" runat="server" ImageUrl='<%# Eval("movieImage") %>' />
                         </td>
                            <tr>
                                <td>Name:  
                                <asp:Label ID="lblSubject" runat="server" Text='<%#Eval("movieName") %>' Font-Bold="true" />
                                <!--<asp:Label ID="Label5" runat="server" Text='<%#Eval("movieID") %>' Font-Bold="true" />-->

                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        Description:<asp:Label ID="lblComment" runat="server" Text='<%#Eval("movieDescription") %>' />
                    </td>
                </tr>
                <tr>
                    <td>
                        <table style="background-color: #EBEFF0; border-top: 1px dotted #df5015; border-bottom: 1px solid #df5015; width: 500px">
                            <tr>
                                <td>Year:
                                    <asp:Label ID="lblUser" runat="server" Font-Bold="true" Text='<%#Eval("movieYear") %>' /></td>
                                <td>Run Time:<asp:Label ID="lblDate" runat="server" Font-Bold="true" Text='<%#Eval("movieRuntime") %>' /></td>
                            </tr>
                        </table>
                    </td>
                </tr>
                 <tr>
                    <td>
                        <table>
                            <tr>
                                <td>Rating: 
                                    <asp:Label ID="Label1" runat="server" Font-Bold="true" Text='<%#Eval("movieAgeRating") %>' /></td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                   
                    <td>Genre: <asp:Label ID="Label2" runat="server" Font-Bold="true" Text='<%#Eval("movieGenre") %>' /></td>

                    <td colspan="2"></td>
                </tr>
                <tr>
                  <td>Budget: <asp:Label ID="Label3" runat="server" Font-Bold="true" Text='<%#Eval("movieBudget") %>' /></td>

                </tr>
                <tr>
                  <td>Box Office: <asp:Label ID="Label4" runat="server" Font-Bold="true" Text='<%#Eval("movieIncome") %>' /></td>

                </tr>
            </ItemTemplate>
            <FooterTemplate>
                <br>
                </br> 
                <br> </br> 
                <br> </br> 
                <br> </br>
                </table>  
            </FooterTemplate>
        </asp:Repeater>  



        </div>
    </form>
</body>
</html>

