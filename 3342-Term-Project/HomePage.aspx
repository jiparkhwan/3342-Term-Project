<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="_3342_Term_Project.HomePage" %>
<%@ Register Src="~/UserControls/Navbar.ascx" TagName="HomeNav" TagPrefix="Navigation" %>
<%@ Register Src="~/UserControls/Footer.ascx" TagName="HomeFooter" TagPrefix="Footer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <title>Home Page</title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" />

    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <link href="https://fonts.googleapis.com/css?family=Roboto:100,100i,300,300i,400,400i,500,500i,700,700i,900,900i" rel="stylesheet" />
    <script src="//ajax.googleapis.com/ajax/libs/jquery/1.11.0/jquery.min.js"></script>
    <script src="//netdna.bootstrapcdn.com/bootstrap/3.1.1/js/bootstrap.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.0/js/bootstrap.min.js"></script>

    <!-- Load icon library -->
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css" />

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
                        <br />
                        <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
                    </asp:Panel>

                    <asp:ScriptManager runat="server"></asp:ScriptManager>

                </div>
                
               

                <asp:Panel ID="pnlHome" runat="server">
                    <Center>
                        
                        <br />
                        <br />
                        <asp:Panel ID="pnlEditorsPicks" runat="server" BackColor="#e6e6e6" Height="480px" Width="90%" HorizontalAlign="Left">
                            <h2><asp:Label ID="lblEditorsPicksLabel" runat="server" Text="Editor's Picks:"></asp:Label></h2>
                            <br />
                            <div class="card card1" style="width: 200px; height: 350px;">
                                <asp:ImageButton  runat="server" CssClass="card-img-top card-img-top1" src="https://images-na.ssl-images-amazon.com/images/I/51OCRfitHdL._AC_.jpg" alt="Iron Man" Width="194" />
                                <div class="card-body">
                                <h5 class="card-title">Iron Man</h5>
                                </div>
                            </div>
                          
                            <div class="card card2" style="width: 200px; height: 350px;">
                               <asp:ImageButton runat="server" CssClass="card-img-top card-img-top1" OnClick="imgSimpsons_Click" src="https://m.media-amazon.com/images/M/MV5BYjFkMTlkYWUtZWFhNy00M2FmLThiOTYtYTRiYjVlZWYxNmJkXkEyXkFqcGdeQXVyNTAyODkwOQ@@._V1_.jpg" alt="The Simpsons" >
                                </asp:ImageButton>
                                <div class="card-body">
                                <h5 class="card-title">The Simpsons</h5>
                                </div>
                            </div>

                            <div class="card card3" style="width: 200px; height: 350px;">
                                <asp:ImageButton  runat="server" CssClass="card-img-top card-img-top1" src="https://media.gamestop.com/i/gamestop/10097815/The-Elder-Scrolls-V-Skyrim?$pdp$&bg=rgb(0,0,0)" alt="Skyrim" ></asp:ImageButton>
                                <div class="card-body">
                                <h5 class="card-title">Skyrim</h5>
                                </div>
                            </div>                        

                            <div class="card card4" style="width: 200px; height: 350px;">
                                <asp:ImageButton  runat="server" CssClass="card-img-top card-img-top1" src="https://upload.wikimedia.org/wikipedia/en/1/12/The_Good_Place_Season_3.jpg" alt="The Good Place" ></asp:ImageButton>
                                <div class="card-body">
                                <h5 class="card-title">The Good Place</h5>
                                </div>
                            </div> 
                        </asp:Panel>
                        <br />

                        <asp:Panel ID="pnlFindRandomTitle" runat="server" BackColor="#e6e6e6" Height="380px" Width="90%" HorizontalAlign="Left">
                            <br />
                            <h4><asp:Label ID="lblRandomPicksLabel" runat="server" Text="Let us help you decide what to watch or play tonight!"></asp:Label></h4>
                            <br />   
                            <asp:ImageButton ID="imgRandomMovie" Height="220" Width="170" BorderStyle="Solid" src="Images/Movie.png" runat="server" BackColor="Black" OnClick="btnRandMovie_Click"></asp:ImageButton>
                            <asp:ImageButton ID="imgRandomShow" Height="220" Width="170" BorderStyle="Solid" src="Images/TV.png" runat="server" BackColor="Black" OnClick="btnRandShow_Click"></asp:ImageButton>
                            <asp:ImageButton ID="imgRandomGame" Height="220" Width="170" BorderStyle="Solid" src="Images/ef1713664570291e8ebe09c7a2d790dc.png" runat="server" BackColor="Black" OnClick="btnRandGame_Click"></asp:ImageButton>
                        </asp:Panel>
                        <br />

                        <asp:Panel ID="pnlUserPicks" runat="server" BackColor="#e6e6e6" Height="480px" Width="90%" HorizontalAlign="Left">
                            <h2><asp:Label ID="lblUserPicks" runat="server" Text="User Favorites:"></asp:Label></h2>
                            <br />
                            <div class="recentFavoritesDiv">
                                <asp:Timer runat="server" ID="editorTimer" Interval="4000" OnTick="editorTimer_Tick" Enabled="False"></asp:Timer>
                                <asp:UpdatePanel runat="server" ID="picksUpdatePanel">
                                    <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="editorTimer" />
                                    </Triggers>
                                    <ContentTemplate>
                                        <asp:Image runat="server" ID="editorImage" style="width: 240px; height: 350px;" ImageUrl="Images/editorpick_1.jpg" BorderStyle="Solid" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </asp:Panel>
                    </Center>
                </asp:Panel>
      
                <asp:Panel ID="pnlMovieRepeater" runat="server" HoroziontalAlign="Center" Visible="False">

                    <asp:Label Text="" runat="server" ID="ErrorText"></asp:Label>

                        <Center>
                            <asp:Repeater ID="rptMovieSearchRes" runat="server">
                                <HeaderTemplate>
                                    <table style="width: 400px; height:40px;">
                                        <tr style=" font-size: large; font-weight: bold;">
                                            <td style="text-align:center;">
                                                <br />
                                                <h2>Results</h2>
                                            </td>
                                            
                                        </tr>
                                    </table>
                                    <hr />
                                </HeaderTemplate>

                                <ItemTemplate>     
                                    <table style="width: 200px; height:200px;">
                                        <tr>
                                        <tr style="background-color: #e6e6e6">
                                            <td>
                                                <br />
                                                <table style="background-color: #e6e6e6;  width: 300px; height:20px; text-align:center;">

                                                    <asp:ImageButton ID="imgMovieResult" Height="220" Width="170" BorderStyle="Solid" runat="server" ImageUrl='<%# Eval("movieImage") %>'  OnCommand="Image_Click" CommandName="ImageClick" CommandArgument='<%# Eval("movieID") %>'></asp:ImageButton>
                                            </td>
                                        </tr>
                                    </table>
                                    <td>
                                        <table style="background-color: #e6e6e6; width: 600px; text-align:center;">
                                            <tr>
                                                <h1><asp:Label ID="lblMovieName" runat="server" fontBold ="true" Text='<%#Eval("movieName") %>'/></h1>
                                                <br />
                                            </tr>
                                                <td style="width: 50%; font-size: 1.25em;"><strong>Year:</strong> 
                                                    <asp:Label ID="lblMovieYear" runat="server" Text='<%#Eval("movieYear") %>' />
                                                </td>
                                                <td style="width: 50%; font-size: 1.25em;"><strong>Rating:</strong>
                                                    <asp:Label ID="lblMovieAgeRating" runat="server" Text='<%#Eval("movieAgeRating") %>' />
                                                </td>
                                          
                                        </table>
                                    </td>
                                    
                                    <br />        
                                </ItemTemplate>                       
                            </asp:Repeater>
                        </Center>
                    </asp:Panel>
<%--
                 <asp:ImageButton ID="imgResultImage" Height="220" Width="170" BorderStyle="Solid" runat="server" ImageUrl='<%# Eval("movieImage") %>' OnCommand="Image_Click" CommandName="ImageClick" CommandArgument='<%# Eval("movieID") %>' />

--%>
                    <%--This Panel shows the results for TV Shows--%>
                    <asp:Panel ID="pnlShowRepeater" runat="server" HoroziontalAlign="Center" Visible="False">
                        <Center>
                            <asp:Repeater ID="rptShowSearchRes" runat="server">
                                <HeaderTemplate>
                                    <table style="width: 400px; height:40px;">
                                        <tr style=" font-size: large; font-weight: bold;">
                                            <td style="text-align:center;">
                                                <br />
                                                <h2>Search Results</h2>
                                            </td>
                                            
                                        </tr>
                                    </table>
                                    <hr />
                                </HeaderTemplate>

                                <ItemTemplate>     
                                    <table style="width: 200px; height:200px;">
                                        <tr>
                                        <tr style="background-color: #e6e6e6">
                                            <td>
                                                <br />
                                                <table style="background-color: #e6e6e6;  width: 300px; height:20px; text-align:center;">
                                                    <asp:ImageButton ID="imgShowResult" Height="220" Width="170" BorderStyle="Solid" runat="server" ImageUrl='<%# Eval("showImage") %>'  OnCommand="Image_Click" CommandName="ImageClick" CommandArgument='<%# Eval("showID") %>'></asp:ImageButton>
                                            </td>
                                        </tr>
                                    </table>
                                    <td>
                                        <table style="background-color: #e6e6e6; width: 600px; text-align:center;">
                                            <tr>
                                                <h1><asp:Label ID="lblShowName" runat="server" fontBold ="true" Text='<%#Eval("showName") %>'/></h1>
                                                <br />
                                            </tr>
                                                <td style="width: 50%; font-size: 1.25em;"><strong>Year:</strong> 
                                                    <asp:Label ID="lblShowYears" runat="server" Text='<%#Eval("showYears") %>' />
                                                </td>
                                                <td style="width: 50%; font-size: 1.25em;"><strong>Rating:</strong>
                                                    <asp:Label ID="lblShowAgeRating" runat="server" Text='<%#Eval("showAgeRating") %>' />
                                                </td>

                                        </table>
                                    </td>
                                    
                                    <br />        
                                </ItemTemplate>                       
                            </asp:Repeater>
                        </Center>
                    </asp:Panel>
                    

                    <asp:Panel ID="pnlGameRepeater" runat="server" HoroziontalAlign="Center" Visible="False">
                        <Center>
                            <asp:Repeater ID="rptGameSearchRes" runat="server">
                                <HeaderTemplate>
                                    <table style="width: 400px; height:40px;">
                                        <tr style=" font-size: large; font-weight: bold;">
                                            <td style="text-align:center;">
                                                <br />
                                                <h2>Search Results</h2>
                                            </td>
                                            
                                        </tr>
                                    </table>
                                    <hr />
                                </HeaderTemplate>

                                <ItemTemplate>     
                                    <table style="width: 200px; height:200px;">
                                        <tr>
                                        <tr style="background-color: #e6e6e6">
                                            <td>
                                                <br />
                                                <table style="background-color: #e6e6e6;  width: 300px; height:20px; text-align:center;">
                                                    <asp:ImageButton ID="imgGameResult" Height="220" Width="170" BorderStyle="Solid" runat="server" ImageUrl='<%# Eval("GameImage") %>'  OnCommand="Image_Click" CommandName="ImageClick" CommandArgument='<%# Eval("GameID") %>'></asp:ImageButton>
                                            </td>
                                        </tr>
                                    </table>
                                    <td>
                                        <table style="background-color: #e6e6e6; width: 600px; text-align:center;">
                                            <tr>
                                                <h1><asp:Label ID="lblGameName" runat="server" fontBold ="true" Text='<%#Eval("gameName") %>'/></h1>
                                                <br />
                                            </tr>
                                                <td style="width: 50%; font-size: 1.25em;"><strong>Year:</strong> 
                                                    <asp:Label ID="lblGameYear" runat="server" Text='<%#Eval("GameYear") %>' />
                                                </td>
                                                <td style="width: 50%; font-size: 1.25em;"><strong>Rating:</strong>
                                                    <asp:Label ID="lblGameAgeRating" runat="server" Text='<%#Eval("GameAgeRating") %>' />
                                                </td>
                                       
                                        </table>
                                    </td>
                                    
                                    <br />        
                                </ItemTemplate>                       
                            </asp:Repeater>
                        </Center>
                    </asp:Panel>

                    
                    <asp:Panel ID="pnlActorRepeater" runat="server" HoroziontalAlign="Center" Visible="False">
                        <Center>
                            <asp:Repeater ID="rptActorSearchRes" runat="server">
                                <HeaderTemplate>
                                    <table style="width: 400px; height:40px;">
                                        <tr style=" font-size: large; font-weight: bold;">
                                            <td style="text-align:center;">
                                                <br />
                                                <h2>Search Results</h2>
                                            </td>
                                            
                                        </tr>
                                    </table>
                                    <hr />
                                </HeaderTemplate>

                                <ItemTemplate>     
                                    <table style="width: 200px; height:200px;">
                                        <tr>
                                        <tr style="background-color: #e6e6e6">
                                            <td>
                                                <br />
                                                <table style="background-color: #e6e6e6;  width: 300px; height:20px; text-align:center;">
                                                    <asp:ImageButton ID="imgActorResult" Height="220" Width="170" BorderStyle="Solid" runat="server" ImageUrl='<%# Eval("actorImage") %>'  OnCommand="Image_Click" CommandName="ImageClick" CommandArgument='<%# Eval("actorID") %>'></asp:ImageButton>
                                            </td>
                                        </tr>
                                    </table>
                                    <td>
                                        <table style="background-color: #e6e6e6; width: 600px; text-align:center;">
                                            <tr>
                                                <h1><asp:Label ID="lblActorName" runat="server" fontBold ="true" Text='<%#Eval("actorName") %>'/></h1>
                                                <br />
                                            </tr>
                                                <td style="width: 50%; font-size: 1.25em;"><strong>Year:</strong> 
                                                    <asp:Label ID="lblActorBirthday" runat="server" Text='<%#Eval("actorDOB") %>' />
                                                </td>
                                            </tr>                                 
                                        </table>
                                    </td>
                                    
                                    <br />        
                                </ItemTemplate>                       
                            </asp:Repeater>
                        </Center>
                    </asp:Panel>

                     <br />   
                </div>
                
                <Footer:HomeFooter ID="FooterNav" runat="server" />
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

        .recentFavoritesDiv {
            text-align: center;
            
        }
    </style>

</body>
    
</html>

