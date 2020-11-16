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
      <div class="section-hero">
      <form id="frmHomePage" method="post" runat="server">
             <Navigation:HomeNav ID="HomeNav" runat="server" />
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



                    <asp:Label ID="lblError" runat="server"></asp:Label>
                 
              
          

     
          </div>
         
 
    <div class="repeater-container">
        <asp:Panel ID="RepeaterPanel" runat="server" Width="1200px" HoroziontalAlign="Center">
        <asp:Repeater ID="repeaterResults" runat="server">
            <HeaderTemplate>
                <table style="width: 200px; height:200px;">
                    <tr style=" color: white; font-size: large; font-weight: bold;">
                        <td style="text-align:center;">
                            <h2>Results</h2>
                        </td>
                    </tr>
            </HeaderTemplate>

            <ItemTemplate>
                <tr style="background-color: #EBEFF0">
                    <td>
                        <table style="background-color: #EBEFF0;  width: 400px; height:200px; text-align:center;">
                            <td>
                                <asp:Image ID="Image1" Height="220" Width="170" runat="server" ImageUrl='<%# Eval("Movie_Image") %>' />
                            </td>
                            <tr>
                                <td><strong></strong>
                                      <h3><asp:Label ID="lblName" runat="server" fontBold ="true" Text='<%#Eval("Movie_Name") %>'/></h3>
                                    

                                </td>
                                
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr style="background-color: #EBEFF0; text-align:center;">
                    <td><strong>Description:</strong> <br /><asp:Label ID="lblDescription" runat="server" Text='<%#Eval("Movie_Description") %>' />
                    </td>
                </tr>
                <tr>
                    <td>
                        <table style="background-color: #EBEFF0; width: 400px; text-align:center;">
                            <tr>
                                <td><strong>Year:</strong> 
                                    <asp:Label ID="lblUser" runat="server" Text='<%#Eval("Movie_Year") %>' />

                                </td>
                                <td style=" width: 50%">
                                    <strong>Runtime:</strong>
                                  <asp:Label ID="lblDate" runat="server"  Text='<%#Eval("Movie_RunTime") %>' />

                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr >
                    <td>
                        <table  style="background-color: #EBEFF0;  width: 400px ; text-align:center;">
                            <tr >
                                <td><strong>Rating:</strong>
                                    <asp:Label ID="Label1" runat="server" Text='<%#Eval("Movie_Age_Rating") %>' />

                                </td>
                                <td style=" width: 50%"><strong>Genre:</strong>
                        <asp:Label ID="Label2" runat="server" Text='<%#Eval("Movie_Genre") %>' />

                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
               <tr >
                    <td>
                        <table  style="background-color: #EBEFF0; width: 400px; margin-bottom: 40px; ; text-align:center;">
                            <tr >
                                <td><strong>Budget:</strong>
                                    <asp:Label ID="Label5" runat="server"  Text='<%#Eval("Movie_Budget") %>' />

                                </td>
                                <td style=" width: 50%"><strong>Box Office:</strong>
                        <asp:Label ID="Label7" runat="server" Text='<%#Eval("Movie_Income") %>' />

                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
           
            </ItemTemplate>
            <FooterTemplate>
            
                </table>  
            </FooterTemplate>
        </asp:Repeater>
            </asp:Panel>

         </form>
    </div>

          

 


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

