<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Actor.aspx.cs" Inherits="_3342_Term_Project.Actor" %>
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
    <title>Actor</title>
</head>
<body>
    <form id="frmActor" runat="server">
        
        <Navigation:HomeNav ID="HomeNav" runat="server" />
        <div class="mainTitle">
            <div class="container">
                <asp:Panel ID="editDeletePanel" runat="server">
           <asp:Button ID="btnEditActor" runat="server" Text="Edit Actor" OnClick="btnEditActor_Click" />
            <asp:Button ID="btnDeleteActor" runat="server" class="btn-outline-danger" Text="Delete Actor" OnClick="btnDeleteActor_Click" />
           </asp:Panel>
          </div>
                <br />


            <asp:Panel ID="actorInfoPanel" runat="server">
            <h1><asp:Label ID="lblActorName" runat="server" Text="Ryan Reynolds"></asp:Label></h1>
            <hr />

            <asp:Image ID="imgActorImage" runat="server" ImageUrl="https://resizing.flixster.com/VS2iCmn7Rsk7IQHAT1KBCwZ2oIE=/506x652/v2/https://flxt.tmsimg.com/v9/AllPhotos/57282/57282_v9_bb.jpg" Height="320" Width="240" BorderStyle="Solid" />
            <div class="titleInfo">
                <asp:Label ID="lblActorDescriptionLabel" runat="server" Text="Description: " Font-Bold="True"></asp:Label>
                <asp:Label ID="lblActorDescription" runat="server" Text="Ryan Rodney Reynolds was born on October 23, 1976, in Vancouver, Canada. The youngest of four boys, Reynolds was a really nervous kid, he told GQ magazine. I was extremely sensitive ... I was so aware of everything around me. He found sanctuary in school productions where his vulnerability could be an asset rather than a problem. At the age of 12, Reynolds landed his first professional acting job. He was cast in a Canadian teen drama first called Hillside and later renamed Fifteen when it aired in the United States. The show ran from 1991 to 1993. After Fifteen, Reynolds struggled to get his career off the ground. He was cast in a few small roles, including a guest spot on The X-Files. Still Reynolds needed to take odd jobs to make ends meet after completing high school."></asp:Label>    
                <br />
                <br />
                <asp:Label ID="lblActorDOBLabel" runat="server" Text="Date of Birth: " Font-Bold="True"></asp:Label>
                <asp:Label ID="lblActorDOB" runat="server" Text="Oct. 23, 1979"></asp:Label>
                <br />
                <asp:Label ID="lblActorBirthLocLabel" runat="server" Text="Birth Location: " Font-Bold="True"></asp:Label>
                <asp:Label ID="lblActorBirthCity" runat="server" Text="Vancouver"></asp:Label>
                <asp:Label ID="lblComma1" runat="server" Text=","></asp:Label>
                <asp:Label ID="lblActorBirthState" runat="server" Text="BC"></asp:Label>
                <asp:Label ID="lblComma2" runat="server" Text=","></asp:Label>
                <asp:Label ID="lblActorBirthCountry" runat="server" Text="Canada"></asp:Label>
                <br />
                <asp:Label ID="lblActorHeightLabel" runat="server" Text="Height" Font-Bold="True"></asp:Label>
                <asp:Label ID="lblActorHeight" runat="server" Text="6' 2"></asp:Label>
            </div>
            <hr />
            <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>           
          <Center>
                <asp:Repeater ID="rptActorRoles" runat="server">
                    <HeaderTemplate>
                        <table style="width: 400px; height:40px;">
                            <tr style=" font-size: large; font-weight: bold;">
                                <td style="text-align:center;">
                                    <br />
                                    <h2>Roles: </h2>
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
                                            <asp:ImageButton ID="imgRole" Height="220" Width="170" BorderStyle="Solid" runat="server" ImageUrl='<%# Eval("titleImage") %>' OnCommand="Image_Click" CommandName="ImageClick" CommandArgument='<%# Eval("movieID") + "," + Eval("tvshowID") + "," + Eval("videoGameID") %>'></asp:ImageButton>
                                    </td>
                                </tr>
                        </table>
                            <td>
                                <table style="background-color: #e6e6e6; width: 600px; text-align:center;">
                                    <tr>
                                        <h1><asp:Label ID="lblName" runat="server" fontBold ="true" Text='<%#Eval("movieName")+ "" + Eval("tvShowName") + "" + Eval("videoGameName") %>'/></h1>
                                        <br />
                                    </tr>
                                    <td style="width: 50%; font-size: 1.25em;"><strong>Year:</strong> 
                                        <asp:Label ID="lblYear" runat="server" Text='<%#Eval("movieYear")+ "," + Eval("tvShowYears") + "," + Eval("videoGameYear") %>' />
                                    </td>
                                    <td style="width: 50%; font-size: 1.25em;"><strong>Role:</strong>
                                        <asp:Label ID="lblRole" runat="server" Text='<%#Eval("Role") %>' />
                                    </td>      
                                </table>
                            </td>        
                            <br />        
                    </ItemTemplate>
                </asp:Repeater>
            </Center>
            </asp:Panel>
        </div>
    </form>
</body>
</html>
