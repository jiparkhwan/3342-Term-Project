﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Title.aspx.cs" Inherits="_3342_Term_Project.Title" %>
<%@ Register Src="~/UserControls/Navbar.ascx"  TagName="HomeNav" TagPrefix="Navigation" %>
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
    <title>Title</title>
</head>
<body>
    <form id="frmTitle" runat="server">
        <Navigation:HomeNav ID="HomeNav" runat="server" />
       
        <div class="mainTitle">
            
            <br />       
            <div class="btnDiv" style="padding-left:66px; padding-right:66px;">
            <asp:Button runat="server" ID="btnBack" OnClick="btnBack_Click" Text="Back" CssClass="buttonReview"/>
            <asp:Button ID="btnEditTitle" runat="server" CssClass="buttonReview" Text="Edit" OnClick="btnEditTitle_Click" />
            </div>
            <h1><asp:Label ID="lblTitleName" runat="server" Text="The Simpsons Movie"></asp:Label></h1>
            <div class="topInfo">
                <asp:Label ID="lblTitleAgeRating" runat="server" Text="PG-13"></asp:Label>
                <asp:Label ID="lblBar" runat="server" Text=" | "></asp:Label>
                <asp:Label ID="lblTitleYear" runat="server" Text="2007"></asp:Label>
            </div>
            <hr />

            <asp:Image ID="imgTitleImage" runat="server" ImageUrl="https://m.media-amazon.com/images/M/MV5BMTgxMDczMTA5N15BMl5BanBnXkFtZTcwMzk1MzMzMw@@._V1_UX182_CR0,0,182,268_AL_.jpg" Height="320" Width="240" />
            <div class="titleInfo">
                <asp:Label ID="lblTitleDescriptionLabel" runat="server" Text="Description: " Font-Bold="True"></asp:Label>
                <br />
                <asp:Label ID="lblTitleDescription" runat="server" Text="Homer adopts a pig who's run away from Krusty Burger after Krusty tried to have him slaughtered, naming the pig &quot;Spider Pig.&quot; At the same time, the lake is protected after the audience sink the barge Green Day are on with garbage after they mention the environment. Meanwhile, Spider Pig's waste has filled up a silo in just 2 days, apparently with Homer's help. Homer can't get to the dump quickly so dumps the silo in the lake, polluting it. Russ Cargill, the villainous boss of the EPA, gives Arnold Schwarzenegger, president of the USA, 5 options and forces him to choose 4 (which is, unfortunately, to destroy Springfield) and putting a dome over Springfield to prevent evacuation. Homer, however, has escaped, along with his family."></asp:Label>    
                <br />
                <br />
                <asp:Label ID="lblTitleRunTimeLabel" runat="server" Text="Run Time: " Font-Bold="True"></asp:Label>
                <asp:Label ID="lblTitleRunTime" runat="server" Text="1 Hour, 27 Minutes"></asp:Label>
                <br />  <br />
                <asp:Label ID="lblTitleGenreLabel" runat="server" Text="Genre: " Font-Bold="True"></asp:Label>
                <asp:Label ID="lblTitleGenre" runat="server" Text="Comedy"></asp:Label>
                <br />  <br />
                <asp:Label ID="lblTitleBudgetLabel" runat="server" Text="Budget: $" Font-Bold="True"></asp:Label>
                <asp:Label ID="lblTitleBudget" runat="server" Text="42,000,000"></asp:Label>
                <asp:Label ID="lblTitleCreatorLabel" runat="server" Text="Creator: " Font-Bold="True"></asp:Label>
                <asp:Label ID="lblTitleCreator" runat="server" Text=""></asp:Label>
                <br />  <br />
                <asp:Label ID="lblTitleIncomeLabel" runat="server" Text="Income: $" Font-Bold="True"></asp:Label>
                <asp:Label ID="lblTitleIncome" runat="server" Text="95,000,000"></asp:Label>
           
                
            
               <div>
            <asp:Label ID="lblError" runat="server" Text="" ForeColor="Red"></asp:Label>
               <asp:Label ID="Label1" runat="server" Text="" ForeColor="Red"></asp:Label>
               <asp:Label ID="Label2" runat="server" Text="" ForeColor="Red"></asp:Label>
                </div>
            </div>

            <br />
    <br /><br />
            
         
            <asp:ScriptManager runat="server" ID="ScriptManagerTitlePage"></asp:ScriptManager>


            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <asp:Label ID="reviewOutput" runat="server" Text=""></asp:Label>
                    <div class="reviewContainer">
                        <asp:GridView ID="gvReviews" runat="server" CssClass="table table-responsive " AutoGenerateColumns="False"  GridLines="None"  RowStyle-BorderWidth="1" BackColor="#343233">
                            <Columns>
                                <asp:BoundField DataField="Review_ID" HeaderText=""/>
                                <asp:BoundField DataField="Reviewer_Email" HeaderText="Reviewer" />
                                <asp:BoundField DataField="Review_Description" HeaderText="Description" />
                                <asp:BoundField DataField="Review_Rating" HeaderText="Rating" />


                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:Button ID="btnEditReview" runat="server" Text="Edit" CssClass="buttonReview" OnClick="btnEditReview_Click" />
                                        <br />
                                        <asp:Button ID="btnDeleteReview" runat="server" Text="Delete" CssClass="buttonReview" OnClick="btnDeleteReview_Click" />
                                    </ItemTemplate>

                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                    <br />
                        <asp:LinkButton  ID="addReviewLink" runat="server" CssClass="links" Text="ADD NEW REVIEW" OnClick="addReviewLink_OnClick"></asp:LinkButton>


                    <div class="container">

                        <asp:Panel runat="server" ID="editReviewPanel">
                            <h4>New Rating:</h4>
                            <asp:DropDownList ID="ddlEditRating" runat="server" Height="50px" Width="70px">
                                <asp:ListItem>1</asp:ListItem>
                                <asp:ListItem>2</asp:ListItem>
                                <asp:ListItem>3</asp:ListItem>
                                <asp:ListItem>4</asp:ListItem>
                                <asp:ListItem>5</asp:ListItem>
                                <asp:ListItem>6</asp:ListItem>
                                <asp:ListItem>7</asp:ListItem>
                                <asp:ListItem>8</asp:ListItem>
                                <asp:ListItem>9</asp:ListItem>
                                <asp:ListItem>10</asp:ListItem>
                            </asp:DropDownList>
                            <h4>New Description:</h4>
                            <textarea id="editReviewDescription" cols="60" rows="7" runat="server"></textarea>
                            <br />
                            <asp:Button ID="btnEditReviewSubmit" runat="server" Text="Submit New Review" CssClass="button" OnClick="btnEditReviewSubmit_OnClick" />
                        </asp:Panel>

                    </div>

                    <div class="container">
                        <asp:Panel runat="server" ID="addReviewPanel">
                            <h4>Rating:</h4>
                            <asp:DropDownList ID="ddlAddRating" runat="server" Height="50px" Width="70px">
                                <asp:ListItem>1</asp:ListItem>
                                <asp:ListItem>2</asp:ListItem>
                                <asp:ListItem>3</asp:ListItem>
                                <asp:ListItem>4</asp:ListItem>
                                <asp:ListItem>5</asp:ListItem>
                                <asp:ListItem>6</asp:ListItem>
                                <asp:ListItem>7</asp:ListItem>
                                <asp:ListItem>8</asp:ListItem>
                                <asp:ListItem>9</asp:ListItem>
                                <asp:ListItem>10</asp:ListItem>
                            </asp:DropDownList>
                            <h4>Description:</h4>
                            <textarea id="textAreaAddReview" cols="60" rows="7" runat="server"></textarea>
                            <br />
                            <asp:Button ID="submitReview" runat="server" Text="Submit Review" CssClass="button" OnClick="submitReview_OnClick" />
                        </asp:Panel>
                    </div>
                    <asp:Label ID="lblSuccessReview" runat="server" Text=""></asp:Label>
                </ContentTemplate>
            </asp:UpdatePanel>






            <center style="background-color: #282627; color: ghostwhite;">
                <asp:Repeater ID="rptActorRoles" runat="server">
                    <HeaderTemplate>
                        <table style="width: 400px; height:40px;">
                            <tr style=" font-size: large; font-weight: bold;">
                                <td style="text-align:center;">
                                    <br />
                                    <h2>Cast: </h2>
                                </td>        
                            </tr>
                        </table>
              
                    </HeaderTemplate>

                    <ItemTemplate>     
                        <table style="width: 200px; height:200px;">
                            <tr>
                                <tr style="background-color: #343233; color:ghostwhite;">
                                    <td>
                                        <br />
                                        <table style="background-color: #343233; color:ghostwhite;  width: 300px; height:20px; text-align:center;">
                                            <asp:ImageButton ID="imgCastActor" Height="220" Width="170"  runat="server" ImageUrl='<%# Eval("actorImage") %>' OnCommand="Image_Click" CommandName="ImageClick" CommandArgument='<%# Eval("actorID") %>'></asp:ImageButton>
                                    </td>
                                </tr>
                        </table>
                            <td>
                                <table style="background-color: #343233;  color:ghostwhite; width: 600px; text-align:center;">
                                    <tr>
                                        <h1><asp:Label ID="lblActorName" runat="server" fontBold ="true" Text='<%#Eval("actorName") %>'/></h1>
                                        <br />
                                    </tr>
                                    <td style="width: 50%; font-size: 1.25em;"><strong>Role:</strong>
                                        <asp:Label ID="lblMovieRole" runat="server" Text='<%#Eval("Role") %>' />
                                    </td>      
                                </table>
                            </td>        
                            <br />        
                    </ItemTemplate>                       
                </asp:Repeater>
            </Center>
         </div>

                
    </form>
</body>
    
</html>
