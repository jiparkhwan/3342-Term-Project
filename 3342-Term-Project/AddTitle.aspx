<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddTitle.aspx.cs" Inherits="_3342_Term_Project.AddTitle" %>
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
    <title>Add Title</title>
</head>
<body>
    <form id="frmAddTitle" runat="server">
        <Navigation:HomeNav ID="HomeNav" runat="server" />
        <div class="addTitle">
            
            <div class="row">
                <div class="column">
            <asp:Panel ID="pnlAddMovie" runat="server">
                <br />
                <br />
                <h2 style="color:#778aab;"><asp:Label ID="lblAddMovieLabel" runat="server" Text="Add A Movie"></asp:Label></h2>
                <small>Contribute a new movie entry to our site. Add it below!</small>
                <br />
                <asp:Label ID="lblDisplay" runat="server" ForeColor="Red"></asp:Label>
                <br />
                <br />
                <asp:Label ID="lblAddMovieImage" runat="server" Text="Image URL: " Font-Bold="True" Font-Size="Large"></asp:Label>
                <asp:TextBox ID="txtAddMovieImage" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ControlToValidate="txtAddMovieImage" ID="ans1Validator" runat="server" ErrorMessage="Image Required" Display="Dynamic"></asp:RequiredFieldValidator>
                <br />
                <br />
                <asp:Label ID="lblAddMovieName" runat="server" Text="Movie's Name: " Font-Bold="True" Font-Size="Large"></asp:Label>
                <asp:TextBox ID="txtAddMovieName" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ControlToValidate="txtAddMovieName" ID="RequiredFieldValidator1" runat="server" ErrorMessage="Name Required!" Display="Dynamic"></asp:RequiredFieldValidator>
                <br />
                <br />
                <asp:Label ID="lblAddMovieAgeRange" runat="server" Text="Age Rating: " Font-Bold="True" Font-Size="Large"></asp:Label>
                <asp:DropDownList ID="ddlAddMovieAgeRange" runat="server">
                    <asp:ListItem Value="noneSelected">-------</asp:ListItem>
                    <asp:ListItem Value="G">G</asp:ListItem>
                    <asp:ListItem Value="PG">PG</asp:ListItem>
                    <asp:ListItem Value="PG-13">PG-13</asp:ListItem>
                    <asp:ListItem Value="R">R</asp:ListItem>
                    <asp:ListItem Value="NC-17">NC-17</asp:ListItem>
                    <asp:ListItem Value="Unrated">Unrated</asp:ListItem>
                </asp:DropDownList>
                <br />
                <br />
                <asp:Label ID="lblAddMovieYear" runat="server" Text="Release Year: " Font-Bold="True"></asp:Label>
                <asp:DropDownList ID="ddlAddMovieYear" runat="server">
                    <asp:ListItem Value="noneSelected">----</asp:ListItem>
                </asp:DropDownList>
                <br />
                <br />
                <asp:Label ID="lblAddMovieRuntime" runat="server" Text="Runtime: " Font-Bold="True" Font-Size="Large"></asp:Label>
                <asp:TextBox ID="txtAddMovieRuntime" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ControlToValidate="txtAddMovieRuntime" ID="RequiredFieldValidator2" runat="server" ErrorMessage="Runtime is needed!" Display="Dynamic"></asp:RequiredFieldValidator>
                <br />
                <br />
                <asp:Label ID="lblAddMovieGenre" runat="server" Text="Genre: " Font-Bold="True" Font-Size="Large"></asp:Label>
                <asp:DropDownList ID="ddlAddMovieGenre" runat="server">
                    <asp:ListItem Value="noneSelected">-------</asp:ListItem>
                    <asp:ListItem Value="Action">Action</asp:ListItem>
                    <asp:ListItem Value="Animated">Animated</asp:ListItem>
                    <asp:ListItem Value="Childrens">Children's</asp:ListItem>
                    <asp:ListItem Value="Comedy">Comedy</asp:ListItem>
                    <asp:ListItem Value="Crime">Crime</asp:ListItem>
                    <asp:ListItem Value="Documentary">Documentary</asp:ListItem>
                    <asp:ListItem Value="Drama">Drama</asp:ListItem>
                    <asp:ListItem Value="Horror">Horror</asp:ListItem>
                    <asp:ListItem Value="Musical">Musical</asp:ListItem>
                    <asp:ListItem Value="Romance">Romance</asp:ListItem>
                    <asp:ListItem Value="Sci-Fi">Sci-Fi</asp:ListItem>
                    <asp:ListItem Value="Superhero">Superhero</asp:ListItem>
                    <asp:ListItem Value="Western">Western</asp:ListItem>
                </asp:DropDownList>
                <br />
                <br />
                <asp:Label ID="lblAddMovieBudget" runat="server" Text="Movie Budget: $" Font-Bold="True" Font-Size="Large"></asp:Label>
                <asp:TextBox ID="txtAddMovieBudget" runat="server"></asp:TextBox>
                 <asp:RequiredFieldValidator ControlToValidate="txtAddMovieBudget" ID="RequiredFieldValidator3" runat="server" ErrorMessage="Budget required!" Display="Dynamic"></asp:RequiredFieldValidator>
                <br />
                <br />
                <asp:Label ID="lblAddMovieIncome" runat="server" Text="Movie Income: $" Font-Bold="True" Font-Size="Large"></asp:Label>
                <asp:TextBox ID="txtAddMovieIncome" runat="server"></asp:TextBox>
                 <asp:RequiredFieldValidator ControlToValidate="txtAddMovieIncome" ID="RequiredFieldValidator4" runat="server" ErrorMessage="Income Required" Display="Dynamic"></asp:RequiredFieldValidator>
                <br />
                <br />
                <asp:Label ID="lblAddMovieDescription" runat="server" Text="Description: " Font-Bold="True" Font-Size="Large"></asp:Label>
                <br />
                <asp:TextBox ID="txtAddMovieDescription" runat="server" Width="70%" Height="120px" Rows="10" TextMode="MultiLine"></asp:TextBox>
                <asp:RequiredFieldValidator ControlToValidate="txtAddMovieDescription" ID="RequiredFieldValidator5" runat="server" ErrorMessage="Description Required" Display="Dynamic"></asp:RequiredFieldValidator>
                <br />
                <br />
                <asp:Button class="btnSubmit" runat="server" CssClass="button" Text="Submit" Font-Bold="True" OnClick="btnSubmit_Click"/>
                <asp:Button class="btnClearMovie" runat="server" CssClass="button" Text="Clear All Fields" Font-Bold="True" OnClick="btnClearMovie_Click"  />
                <div class="recentFavoritesAdding">

       </div>
                <br />
                <br />
                <br />
            </asp:Panel>





            <%--Start of TV Show Panel--%>
            <asp:Panel ID="pnlAddShow" runat="server" Visible="False">
                <br />
                <br />
                <h2 style="color:#778aab;"><asp:Label ID="lblAddShowLabel" runat="server" Text="Add A TV Show"></asp:Label></h2>
                <small>Contribute a new movie entry to our site. Add it below!</small>
                <br />
                <asp:Label ID="lblDisplay2" runat="server" Text="" ForeColor="Red"></asp:Label>
                <br />
                <asp:Label ID="lblAddShowImage" runat="server" Text="Image URL: " Font-Bold="True" Font-Size="Large"></asp:Label>
                <asp:TextBox ID="txtAddShowImage" runat="server"></asp:TextBox>
                 <asp:RequiredFieldValidator ControlToValidate="txtAddShowImage" ID="RequiredFieldValidator6" runat="server" ErrorMessage="Image Required" Display="Dynamic"></asp:RequiredFieldValidator>
                <br />
                <br />
                <asp:Label ID="lblAddShowName" runat="server" Text="TV Show Name: " Font-Bold="True" Font-Size="Large"></asp:Label>
                <asp:TextBox ID="txtAddShowName" runat="server"></asp:TextBox>
                 <asp:RequiredFieldValidator ControlToValidate="txtAddShowName" ID="RequiredFieldValidator7" runat="server" ErrorMessage="Name Required" Display="Dynamic"></asp:RequiredFieldValidator>
                <br />
                <br />
                <asp:Label ID="lblAddShowAgeRating" runat="server" Text="Age Rating: " Font-Bold="True" Font-Size="Large"></asp:Label>
                <asp:DropDownList ID="ddlAddShowAgeRating" runat="server">
                    <asp:ListItem Value="noneSelected">-------</asp:ListItem>
                    <asp:ListItem Value="TV-G">TV-G</asp:ListItem>
                    <asp:ListItem Value="TV-PG">TV-PG</asp:ListItem>
                    <asp:ListItem Value="TV-14">TV-14</asp:ListItem>
                    <asp:ListItem Value="TV-MA">TV-MA</asp:ListItem>
                    <asp:ListItem Value="Unrated">Unrated</asp:ListItem>
                </asp:DropDownList>
                <br />
                <br />
                <asp:Label ID="lblAddShowYears" runat="server" Text="Run Years: " Font-Bold="True"></asp:Label>
                <asp:DropDownList ID="ddlAddShowYearsStart" runat="server">
                    <asp:ListItem Value="noneSelected">----</asp:ListItem>
                </asp:DropDownList>
                <asp:Label ID="lblDash" runat="server" Text="-"></asp:Label>
                <asp:DropDownList ID="ddlAddShowYearsEnd" runat="server">
                    <asp:ListItem Value="noneSelected">----</asp:ListItem>
                    <asp:ListItem Value="Current">Current</asp:ListItem>
                </asp:DropDownList>
                <br />
                <br />
                <asp:Label ID="lblAddShowRuntime" runat="server" Text="Episode Runtime: " Font-Bold="True" Font-Size="Large"></asp:Label>
                <asp:TextBox ID="txtAddShowRuntime" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ControlToValidate="txtAddShowRuntime" ID="RequiredFieldValidator8" runat="server" ErrorMessage="RunTime Required!" Display="Dynamic"></asp:RequiredFieldValidator>
                <br />
                <br />
                <asp:Label ID="lblAddShowGenre" runat="server" Text="Genre: " Font-Bold="True" Font-Size="Large"></asp:Label>
                <asp:DropDownList ID="ddlAddShowGenre" runat="server">
                    <asp:ListItem Value="noneSelected">-------</asp:ListItem>
                    <asp:ListItem Value="Action">Action</asp:ListItem>
                    <asp:ListItem Value="Animated">Animated</asp:ListItem>
                    <asp:ListItem Value="Anime">Anime</asp:ListItem>
                    <asp:ListItem Value="Childrens">Children's</asp:ListItem>
                    <asp:ListItem Value="Comedy">Comedy</asp:ListItem>
                    <asp:ListItem Value="Documentary">Documentary</asp:ListItem>
                    <asp:ListItem Value="Drama">Drama</asp:ListItem>
                    <asp:ListItem Value="Game Show">Game Show</asp:ListItem>
                    <asp:ListItem Value="News">News</asp:ListItem>
                    <asp:ListItem Value="Reality">Reality</asp:ListItem>
                    <asp:ListItem Value="Romance">Romance</asp:ListItem>
                    <asp:ListItem Value="Sports">Sports</asp:ListItem>
                </asp:DropDownList>
                <br />
                <br />
                <asp:Label ID="lblAddShowDescription" runat="server" Text="Description: " Font-Bold="True" Font-Size="Large"></asp:Label>
                <br />
                <asp:TextBox ID="txtAddShowDescription" runat="server" Width="70%" Height="120px" Rows="10" TextMode="MultiLine"></asp:TextBox>
                <asp:RequiredFieldValidator ControlToValidate="txtAddShowDescription" ID="RequiredFieldValidator9" runat="server" ErrorMessage="Description Needed!" Display="Dynamic"></asp:RequiredFieldValidator>
                <br />
                <br />
                <asp:Button class="btnSubmit" CssClass="button" runat="server" Text="Submit" Font-Bold="True" OnClick="btnSubmit_Click"/>
                <asp:Button class="btnClear" CssClass="button"  runat="server" Text="Clear All Fields" Font-Bold="True" />
              
                 <div class="recentFavoritesAdding">

                </div>
                <br />
                <br />
                <br />
            </asp:Panel>



        <%--Start of Video Game Panel--%>
            <asp:Panel ID="pnlAddGame" runat="server" Visible="False">
                <br />
                <br />
                <h2 style="color:#778aab;"><asp:Label ID="lblAddVideoGameLabel" runat="server" Text="Add A Video Game"></asp:Label></h2>
             
                <small>Contribute a new movie entry to our site. Add it below!</small>
                <br />
                <asp:Label ID="lblDisplay3" runat="server" Text="" ForeColor="Red"></asp:Label>
                <br />
                <asp:Label ID="lblAddGameImage" runat="server" Text="Image URL: " Font-Bold="True" Font-Size="Large"></asp:Label>
                <asp:TextBox ID="txtAddGameImage" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ControlToValidate="txtAddGameImage" ID="RequiredFieldValidator10" runat="server" ErrorMessage="Image Required" Display="Dynamic"></asp:RequiredFieldValidator>
                <br />
                <br />
                <asp:Label ID="lblAddGameName" runat="server" Text="Video Game Name: " Font-Bold="True" Font-Size="Large"></asp:Label>
                <asp:TextBox ID="txtAddGameName" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ControlToValidate="txtAddGameName" ID="RequiredFieldValidator11" runat="server" ErrorMessage="Name Required" Display="Dynamic"></asp:RequiredFieldValidator>
                <br />
                <br />
                <asp:Label ID="lblAddGameYear" runat="server" Text="Release Year: " Font-Bold="True"></asp:Label>
                <asp:DropDownList ID="ddlAddGameYear" runat="server">
                    <asp:ListItem Value="noneSelected">----</asp:ListItem>
                </asp:DropDownList>
                <br />
                <br />
                <asp:Label ID="lblAddGameAgeRating" runat="server" Text="Age Rating: " Font-Bold="True" Font-Size="Large"></asp:Label>
                <asp:DropDownList ID="ddlAddGameAgeRating" runat="server">
                    <asp:ListItem Value="noneSelected">-------</asp:ListItem>
                    <asp:ListItem Value="E">E-Everyone</asp:ListItem>
                    <asp:ListItem Value="T">T-Teen</asp:ListItem>
                    <asp:ListItem Value="M">M-Mature</asp:ListItem>
                    <asp:ListItem Value="Unrated">Unrated</asp:ListItem>
                </asp:DropDownList>
                <br />
                <br />
                <asp:Label ID="lblAddGameGenre" runat="server" Text="Genre: " Font-Bold="True" Font-Size="Large"></asp:Label>
                <asp:DropDownList ID="ddlAddGameGenre" runat="server">
                    <asp:ListItem Value="noneSelected">-------</asp:ListItem>
                    <asp:ListItem Value="Action">Action</asp:ListItem>
                    <asp:ListItem Value="Adventure">Adventure</asp:ListItem>
                    <asp:ListItem Value="Fantasy">Fantasy</asp:ListItem>
                    <asp:ListItem Value="Horror">Horror</asp:ListItem>
                    <asp:ListItem Value="Music">Music</asp:ListItem>
                    <asp:ListItem Value="RPG">RPG</asp:ListItem>
                    <asp:ListItem Value="Shooter">Shooter</asp:ListItem>
                    <asp:ListItem Value="Sports">Sports</asp:ListItem>
                </asp:DropDownList>
                <br />
                <br />
                <asp:Label ID="lblAddGameCreator" runat="server" Text="Developer: " Font-Bold="True" Font-Size="Large"></asp:Label>
                <asp:TextBox ID="txtAddGameCreator" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ControlToValidate="txtAddGameCreator" ID="RequiredFieldValidator12" runat="server" ErrorMessage="Game Creator Required" Display="Dynamic"></asp:RequiredFieldValidator>
                <br />
                <br />
                <asp:Label ID="lblAddGameDescription" runat="server" Text="Description: " Font-Bold="True" Font-Size="Large"></asp:Label>
                <br />
                <asp:TextBox ID="txtAddGameDescription" runat="server" TextMode="multiline" Columns="60" Rows="6" Width="70%" Height="120px"></asp:TextBox>
                <asp:RequiredFieldValidator ControlToValidate="txtAddGameDescription" ID="RequiredFieldValidator13" runat="server" ErrorMessage="Description Required" Display="Dynamic"></asp:RequiredFieldValidator>
                <br />
                <br />
                <asp:Button class="btnSubmit" runat="server" CssClass="button" Text="Submit" Font-Bold="True" OnClick="btnSubmit_Click" />
                <asp:Button class="btnClear" runat="server" CssClass="button" Text="Clear All Fields" Font-Bold="True" />
                <br />
                <br />
                <br />

            </asp:Panel>
                </div>
                <asp:ScriptManager runat="server"></asp:ScriptManager>
                <div class="column">
                   <br />  <br />   <br />
                    
                             <div class="recentFavoritesDiv">
                            <br />
                           
                                <asp:Timer runat="server" ID="editorTimer" Interval="2500" OnTick="editorTimer_Tick" Enabled="true"></asp:Timer>
                                <asp:UpdatePanel runat="server" ID="picksUpdatePanel">
                                    <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="editorTimer" />
                                    </Triggers>
                                    <ContentTemplate>
                                        <asp:Image runat="server" ID="editorImage" style="width: 430px; height: 670px;" ImageUrl="Images/editorpick_1.jpg" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                       

                </div>

            </div>
        </div>
        <Footer:HomeFooter ID="FooterNav" runat="server" />
    </form>
</body>
</html>
