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
    <link rel="stylesheet" href="path/to/bootstrap/css/bootstrap.min.css"/>
<link rel="stylesheet" href="path/to/font-awesome/css/font-awesome.min.css"/>
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
                    <asp:DropDownList ID="ddlSelectMedia" runat="server"  CssClass="ddl"> 
                        <asp:ListItem Value="movies">Movies</asp:ListItem>
                        <asp:ListItem Value="shows">TV Shows</asp:ListItem>
                        <asp:ListItem Value="videoGames">Video Games</asp:ListItem>
                        <asp:ListItem Value="actors">Actors</asp:ListItem>
                    </asp:DropDownList>
                    <asp:TextBox ID="txtFindByName" runat="server" CssClass="searchTextbox" PlaceHolder="Search Here"></asp:TextBox>
                    <br />
                    <asp:Button ID="btnFindByName" Text="Search" runat="server" OnClick="btnFindByName_Click" CssClass="button" />
                    <br />
                    <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
                </asp:Panel>

                <asp:ScriptManager runat="server"></asp:ScriptManager>

            </div>



            <asp:Panel ID="pnlHome" CssClass="pnlHome" runat="server">
                <div class="pnlHome">
                        <asp:Panel ID="pnlEditorsPicks" runat="server" >
                            <br />
                            <h3><asp:Label ID="lblEditorsPicksLabel" runat="server" Text="Editor's Picks:"></asp:Label></h3>
                           
                            <div id="menu-outer">
                                <div class="table">
                                    <ul id="horizontal-list">
                                        <li id="">
                                            <asp:ImageButton runat="server" CssClass="editorImage" OnClick="imgDeadpool_Click" src="https://m.media-amazon.com/images/I/91tuQ9AVNxL.jpg" /></li>
                                        <li id="">
                                            <asp:ImageButton runat="server" CssClass="editorImage" OnClick="imgSimpsons_Click" src="https://m.media-amazon.com/images/M/MV5BYjFkMTlkYWUtZWFhNy00M2FmLThiOTYtYTRiYjVlZWYxNmJkXkEyXkFqcGdeQXVyNTAyODkwOQ@@._V1_.jpg" alt="The Simpsons"></asp:ImageButton></li>
                                        <li id="">
                                            <asp:ImageButton runat="server" CssClass="editorImage" OnClick="imgSkyrim_Click" src="https://i.pinimg.com/originals/33/6a/b4/336ab45601650b6a503620a8431f19a6.jpg" alt="Skyrim"></asp:ImageButton></li>
                                        <li id="">
                                            <asp:ImageButton runat="server" CssClass="editorImage" OnClick="imgGoodPlace_Click" src="https://upload.wikimedia.org/wikipedia/en/1/12/The_Good_Place_Season_3.jpg" alt="The Good Place"></asp:ImageButton></li>
                                    </ul>

                                </div>
                            </div>
                        </asp:Panel>
                        <br />

                        <asp:Panel ID="pnlFindRandomTitle" runat="server">
                            <div class="randomFinds">
                            <br />
                            <h3><asp:Label ID="lblRandomPicksLabel" runat="server" Text="Can't Choose? Let Us help!"></asp:Label></h3>
                                <small>Select A Category:</small>
                            <br /> 
                             <div id="menu-outers">
                                <div class="table">
                                    <ul id="horizontal-lists">
                                        <li id="">
                                            <button runat="server" id="btnRun" class="button" title="Movie" onserverclick="btnRandMovie_Click">
                                            <i class="fa fa-film"></i> Movie
                                             </button>

                                           
                                        <li id="">
                                             <button runat="server" id="btnShows" class="button" title="Shows" onserverclick="btnRandShow_Click">
                                             <i class="fa fa-tv"></i> TV Show
                                             </button>
                                        </li>
                                        <li id="">
                                             <button runat="server" id="Button1" class="button" title="Shows" onserverclick="btnRandGame_Click">
                                             <i class="fa fa-gamepad"></i> Game
                                             </button>
                                     
                                    </ul>
                                </div>
                            </div>
                          </div>
                        </asp:Panel>
                        <br />
                   
                        <asp:Panel ID="pnlUserPicks" runat="server" >
                             <div class="recentFavoritesDiv">
                            <h3><asp:Label ID="lblUserPicks" runat="server" Text="User Favorites:"></asp:Label></h3>
                            <br />
                           
                                <asp:Timer runat="server" ID="editorTimer" Interval="2500" OnTick="editorTimer_Tick" Enabled="False"></asp:Timer>
                                <asp:UpdatePanel runat="server" ID="picksUpdatePanel">
                                    <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="editorTimer" />
                                    </Triggers>
                                    <ContentTemplate>
                                        <asp:Image runat="server" ID="editorImage" style="width: 240px; height: 350px;" ImageUrl="Images/editorpick_1.jpg" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </asp:Panel>
                
                </div>
            </asp:Panel>

            <asp:Panel ID="pnlMovieRepeater" runat="server" HoroziontalAlign="Center" Visible="False">

                <asp:Label Text="" runat="server" ID="ErrorText"></asp:Label>

                <center style="background-color: #282627; color:#778aab; min-height: 500px; padding-bottom: 90px;">
                            <asp:Repeater ID="rptMovieSearchRes" runat="server">
                                <HeaderTemplate>
                                    <table style="width: 400px; height:40px; background-color: #282627; color:ghostwhite; ">
                                        <tr style=" font-size: large; font-weight: bold; background-color: #282627; color:ghostwhite; ">
                                            <td style="text-align:center;">
                                                <br />
                                                <h2>Results:</h2>
                                            </td>
                                            
                                        </tr>
                                    </table>
                            
                                </HeaderTemplate>

                                <ItemTemplate>     
                                    <table style="width: 200px; height:200px;">
                                        <tr>
                                        <tr style="background-color: #343233; color:ghostwhite; " >
                                            <td>
                                                <br />
                                                <table style="background-color: #343233; color:ghostwhite;  width: 300px; height:20px; text-align:center;">

                                                    <asp:ImageButton ID="imgMovieResult" Height="220" Width="170" BorderStyle="Solid" runat="server" ImageUrl='<%# Eval("movieImage") %>'  OnCommand="Image_Click" CommandName="ImageClick" CommandArgument='<%# Eval("movieID") %>'></asp:ImageButton>
                                            </td>
                                        </tr>
                                    </table>
                                    <td>
                                        <table style="background-color: #343233; color:ghostwhite; width: 600px; text-align:center;">
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
                        </center>
            </asp:Panel>
   
            <%--This Panel shows the results for TV Shows--%>
            <asp:Panel ID="pnlShowRepeater" runat="server" HoroziontalAlign="Center" Visible="False">
                <center style="background-color: #282627; color:#778aab; min-height: 500px; padding-bottom: 90px;">
                            <asp:Repeater ID="rptShowSearchRes" runat="server">
                                <HeaderTemplate>
                                    <table style="width: 400px; height:40px;  background-color: #282627; color:ghostwhite; ">
                                        <tr style=" font-size: large; font-weight: bold; background-color: #282627; color:ghostwhite; ">
                                            <td style="text-align:center;">
                                                <br />
                                                <h2>Results:</h2>
                                            </td>
                                            
                                        </tr>
                                    </table>
                                 
                                </HeaderTemplate>

                                <ItemTemplate>     
                                    <table style="width: 200px; height:200px;">
                                        <tr>
                                        <tr style="background-color: #343233; color:ghostwhite; ">
                                            <td>
                                                <br />
                                                <table style="background-color: #343233; color:ghostwhite; width: 300px; height:20px; text-align:center;">
                                                    <asp:ImageButton ID="imgShowResult" Height="220" Width="170" runat="server" ImageUrl='<%# Eval("showImage") %>'  OnCommand="Image_Click" CommandName="ImageClick" CommandArgument='<%# Eval("showID") %>'></asp:ImageButton>
                                            </td>
                                        </tr>
                                    </table>
                                    <td>
                                        <table style="background-color: #343233; color:ghostwhite; width: 600px; text-align:center;">
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
                        </center>
            </asp:Panel>


            <asp:Panel ID="pnlGameRepeater" runat="server" HoroziontalAlign="Center" Visible="False">
                <center style="background-color: #282627; color:#778aab; min-height: 500px; padding-bottom: 90px;">
                            <asp:Repeater ID="rptGameSearchRes" runat="server">
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
                                        <tr style="background-color: #343233; color:ghostwhite; ">
                                            <td>
                                                <br />
                                                <table style="background-color: #343233;  width: 300px; height:20px; text-align:center;">
                                                    <asp:ImageButton ID="imgGameResult" Height="220" Width="170" BorderStyle="Solid" runat="server" ImageUrl='<%# Eval("GameImage") %>'  OnCommand="Image_Click" CommandName="ImageClick" CommandArgument='<%# Eval("GameID") %>'></asp:ImageButton>
                                            </td>
                                        </tr>
                                    </table>
                                    <td>
                                        <table style="background-color: #343233; color:ghostwhite; width: 600px; text-align:center;">
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
                        </center>
            </asp:Panel>


            <asp:Panel ID="pnlActorRepeater" runat="server" HoroziontalAlign="Center" Visible="False">
                <center style="background-color: #282627; color:ghostwhite; min-height: 500px; padding-bottom: 90px;">
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
                                
                                </HeaderTemplate>

                                <ItemTemplate>     
                                    <table style="width: 200px; height:200px;">
                                        <tr>
                                        <tr style="background-color: #343233; color:ghostwhite;" >
                                            <td>
                                                <br />
                                                <table style="background-color: #343233;color:ghostwhite;  width: 300px; height:20px; text-align:center;">
                                                    <asp:ImageButton ID="imgActorResult" Height="220" Width="170" BorderStyle="Solid" runat="server" ImageUrl='<%# Eval("actorImage") %>'  OnCommand="Image_Click" CommandName="ImageClick" CommandArgument='<%# Eval("actorID") %>'></asp:ImageButton>
                                            </td>
                                        </tr>
                                    </table>
                                    <td>
                                        <table style="background-color: #343233; color:ghostwhite; width: 600px; text-align:center;">
                                            <tr>
                                                <h1><asp:Label ID="lblActorName" runat="server"  Text='<%#Eval("actorName") %>'/></h1>
                                                <br />
                                            </tr>
                                                <td style="width: 50%; font-size: 1.25em;">Birth Date:
                                                    <asp:Label ID="lblActorBirthday" runat="server" Text='<%#Eval("actorDOB") %>' />
                                                </td>
                                            </tr>                                 
                                        </table>
                                    </td>
                                    
                                    <br />        
                                </ItemTemplate>                       
                            </asp:Repeater>
                        </center>
            </asp:Panel>

            <br />
        </div>

        <Footer:HomeFooter ID="FooterNav" runat="server" />
       
    </form>



   



  
         
       
    
     
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
            text-align: center;
        }

        .recentFavoritesDiv {
            text-align: center;
        }
    </style>

</body>

</html>

