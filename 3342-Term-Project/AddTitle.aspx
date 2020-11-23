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

    <link href="Styles.css" rel="stylesheet" />
    <title>Add Title</title>
</head>
<body>
    <form id="frmAddTitle" runat="server">
        <Navigation:HomeNav ID="HomeNav" runat="server" />
        <div class="mainAddTitle">
            <Center>
            <asp:Panel ID="pnlAddMovie" runat="server">
                <br />
                <br />
                <h1>Add A Movie</h1>
                <hr />
                <br />
                <h5>Contribute a new movie entry to our site. Add it below!</h5>
                <br />
                <asp:Label ID="lblDisplay" runat="server" Text=""></asp:Label>
                <br />
                <asp:Label ID="lblAddMovieImage" runat="server" Text="Image URL: " Font-Bold="True" Font-Size="Large"></asp:Label>
                <asp:TextBox ID="txtAddMovieImage" runat="server"></asp:TextBox>
                <br />
                <br />
                <asp:Label ID="lblAddMovieName" runat="server" Text="Movie's Name: " Font-Bold="True" Font-Size="Large"></asp:Label>
                <asp:TextBox ID="txtAddMovieName" runat="server"></asp:TextBox>
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
                <asp:Label ID="lblAddMovieYear" runat="server" Text="Release Year: "></asp:Label>
                <asp:DropDownList ID="ddlAddMovieYear" runat="server" OnSelectedIndexChanged="ddlAddMovieYear_SelectedIndexChanged">
                    <asp:ListItem Value="noneSelected">----</asp:ListItem>
                </asp:DropDownList>
                <br />
                <br />
                <asp:Label ID="lblAddMovieRuntime" runat="server" Text="Runtime: " Font-Bold="True" Font-Size="Large"></asp:Label>
                <asp:TextBox ID="txtAddMovieRuntime" runat="server"></asp:TextBox>
                <br />
                <br />
                <asp:Label ID="lblAddMovieGenre" runat="server" Text="Genre: " Font-Bold="True" Font-Size="Large"></asp:Label>
                <asp:DropDownList ID="ddlAddMovieGenre" runat="server">
                    <asp:ListItem Value="noneSelected">-------</asp:ListItem>
                    <asp:ListItem Value="Action">Action</asp:ListItem>
                    <asp:ListItem Value="Animated">Animated</asp:ListItem>
                    <asp:ListItem Value="Childrens">Children's</asp:ListItem>
                    <asp:ListItem Value="Comedy">Comedy</asp:ListItem>
                    <asp:ListItem Value="Documentary">Documentary</asp:ListItem>
                    <asp:ListItem Value="Drama">Drama</asp:ListItem>
                    <asp:ListItem Value="Romance">Romance</asp:ListItem>
                </asp:DropDownList>
                <br />
                <br />
                <asp:Label ID="lblAddMovieBudget" runat="server" Text="Movie Budget: $" Font-Bold="True" Font-Size="Large"></asp:Label>
                <asp:TextBox ID="txtAddMovieBudget" runat="server"></asp:TextBox>
                <br />
                <br />
                <asp:Label ID="lblAddMovieIncome" runat="server" Text="Movie Income: $" Font-Bold="True" Font-Size="Large"></asp:Label>
                <asp:TextBox ID="txtAddMovieIncome" runat="server"></asp:TextBox>
                <br />
                <br />
                <asp:Label ID="lblAddMovieDescription" runat="server" Text="Tell Us About the Movie Below: " Font-Bold="True" Font-Size="Large"></asp:Label>
                <br />
                <asp:TextBox ID="txtAddMovieDescription" runat="server" Width="50%" Height="120px" Rows="10"></asp:TextBox>
                <br />
                <br />
                <asp:Button class="btnSubmit" runat="server" Text="Add Movie" Font-Bold="True" OnClick="btnSubmit_Click"/>
                <asp:Button class="btnClear" runat="server" Text="Clear All Fields" Font-Bold="True" />
                <br />
                <br />
                <br />
            </asp:Panel>


            <asp:Panel ID="pnlAddShow" runat="server" Visible="False">
                <br />
                <br />
                <h1>Add A Show</h1>
                <hr />
                <br />
                <h5>Contribute a new TV show entry to our site. Add it below!</h5>
                <br />
                <asp:Label ID="lblDisplay2" runat="server" Text=""></asp:Label>
                <br />
                <asp:Label ID="lblAddShowImage" runat="server" Text="Image URL: " Font-Bold="True" Font-Size="Large"></asp:Label>
                <asp:TextBox ID="txtAddShowImage" runat="server"></asp:TextBox>
                <br />
                <br />
                <asp:Label ID="lblAddShowName" runat="server" Text="TV Show Name: " Font-Bold="True" Font-Size="Large"></asp:Label>
                <asp:TextBox ID="txtAddShowName" runat="server"></asp:TextBox>
                <br />
                <br />
                <asp:Label ID="lblAddShowAgeRating" runat="server" Text="Age Rating: " Font-Bold="True" Font-Size="Large"></asp:Label>
                <asp:DropDownList ID="DropDownList1" runat="server">
                    <asp:ListItem Value="noneSelected">-------</asp:ListItem>
                    <asp:ListItem Value="TVG">TV-G</asp:ListItem>
                    <asp:ListItem Value="TVPG">TV-PG</asp:ListItem>
                    <asp:ListItem Value="TVPG-13">TV-14</asp:ListItem>
                    <asp:ListItem Value="TVR">TV-MA</asp:ListItem>
                    <asp:ListItem Value="Unrated">Unrated</asp:ListItem>
                </asp:DropDownList>
                <br />
                <br />
                <asp:Label ID="lblAddShowYears" runat="server" Text="Run Years: " Font-Bold="True"></asp:Label>
                <asp:DropDownList ID="ddlAddShowYearsStart" runat="server" OnSelectedIndexChanged="ddlAddShowYearsStart_SelectedIndexChanged">
                    <asp:ListItem Value="noneSelected">----</asp:ListItem>
                </asp:DropDownList>
                <asp:Label ID="lblDash" runat="server" Text="-"></asp:Label>
                <asp:DropDownList ID="ddlAddShowYearsEnd" runat="server">
                    <asp:ListItem Value="noneSelected">----</asp:ListItem>
                </asp:DropDownList>
                <br />
                <br />
                <asp:Label ID="lblAddShowRuntime" runat="server" Text="Runtime: " Font-Bold="True" Font-Size="Large"></asp:Label>
                <asp:TextBox ID="txtAddShowRuntime" runat="server"></asp:TextBox>
                <br />
                <br />
                <asp:Label ID="lblAddShowGenre" runat="server" Text="Genre: " Font-Bold="True" Font-Size="Large"></asp:Label>
                <asp:DropDownList ID="ddlAddShowGenre" runat="server">
                    <asp:ListItem Value="noneSelected">-------</asp:ListItem>
                    <asp:ListItem Value="Action">Action</asp:ListItem>
                    <asp:ListItem Value="Animated">Animated</asp:ListItem>
                    <asp:ListItem Value="Childrens">Children's</asp:ListItem>
                    <asp:ListItem Value="Comedy">Comedy</asp:ListItem>
                    <asp:ListItem Value="Documentary">Documentary</asp:ListItem>
                    <asp:ListItem Value="Drama">Drama</asp:ListItem>
                    <asp:ListItem Value="Romance">Romance</asp:ListItem>
                </asp:DropDownList>
                <br />
                <br />
                <asp:Label ID="lblAddShowDescription" runat="server" Text="Tell Us About the TV Show Below: " Font-Bold="True" Font-Size="Large"></asp:Label>
                <br />
                <asp:TextBox ID="txtAddShowDescription" runat="server" Width="50%" Height="120px" Rows="10"></asp:TextBox>
                <br />
                <br />
                <asp:Button class="btnSubmit" runat="server" Text="Add TV Show" Font-Bold="True" OnClick="btnSubmit_Click"/>
                <asp:Button class="btnClear" runat="server" Text="Clear All Fields" Font-Bold="True" />
                <br />
                <br />
                <br />
            </asp:Panel>


            <asp:Panel ID="pnlAddGame" runat="server" Visible="False">
                <br />
                <br />
                <h1>Add A Video Game</h1>
                <hr />
                <br />
                <h5>Contribute a new video game entry to our site. Add it below!</h5>
                <br />
                <asp:Label ID="lblDisplay3" runat="server" Text=""></asp:Label>
                <br />
                <asp:Label ID="lblAddGameImage" runat="server" Text="Image URL: " Font-Bold="True" Font-Size="Large"></asp:Label>
                <asp:TextBox ID="txtAddGameImage" runat="server"></asp:TextBox>
                <br />
                <br />
                <asp:Label ID="lblAddGameName" runat="server" Text="Video Game Name: " Font-Bold="True" Font-Size="Large"></asp:Label>
                <asp:TextBox ID="txtAddGameName" runat="server"></asp:TextBox>
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
                <br />
                <br />
                <asp:Label ID="lblAddGameDescription" runat="server" Text="Tell Us About the Video Game Below: " Font-Bold="True" Font-Size="Large"></asp:Label>
                <br />
                <asp:TextBox ID="txtAddGameDescription" runat="server" Width="50%" Height="120px" Rows="10"></asp:TextBox>
                <br />
                <br />
                <asp:Button class="btnSubmit" runat="server" Text="Add TV Show" Font-Bold="True" OnClick="btnSubmit_Click"/>
                <asp:Button class="btnClear" runat="server" Text="Clear All Fields" Font-Bold="True" />
                <br />
                <br />
                <br />
            </asp:Panel>

            </Center>
        </div>
        <Footer:HomeFooter ID="FooterNav" runat="server" />
    </form>
</body>
</html>
