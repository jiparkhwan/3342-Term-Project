<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MemberManagement.aspx.cs" Inherits="_3342_Term_Project.MemberManagement" %>
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
    <title>Member Managment</title>
</head>
<body>
    <form id="frmMemberManagement" runat="server">
        <Navigation:HomeNav ID="HomeNav" runat="server" />
        <div class="mainMemManagement">
            <Center>
            <br />
            <br />
            <h1><strong>Member Management Page</strong></h1>
            <br />
            <a href="AddActor.aspx">
                <asp:Panel ID="pnlAddActor" runat="server" BackColor="#CCCCCC" Height="150px" Width="90%" HorizontalAlign="Center">
                    <br />
                    <h2><asp:Label ID="lblAddActor" runat="server" Text="Add Actor"></asp:Label></h2>
                    <br />                   
                </asp:Panel>
            </a>
            <br />
            <a href="AddTitle.aspx">
                <asp:Panel ID="pnlAddMovie" runat="server" BackColor="#CCCCCC" Height="150px" Width="90%" HorizontalAlign="Center">
                    <br />
                    <h2><asp:Label ID="lblAddMovie" runat="server" Text="Add Movie"></asp:Label></h2>
                    <br />                   
                </asp:Panel>
            </a>
            <br />
            <a href="AddTitle.aspx">
                <asp:Panel ID="pnlAddShow" runat="server" BackColor="#CCCCCC" Height="150px" Width="90%" HorizontalAlign="Center">
                    <br />
                    <h2><asp:Label ID="lblAddShow" runat="server" Text="Add TV Show"></asp:Label></h2>
                    <br />                   
                </asp:Panel>
            </a>
            <br />
            <a href="AddTitle.aspx">
                <asp:Panel ID="pnlAddGame" runat="server" BackColor="#CCCCCC" Height="150px" Width="90%" HorizontalAlign="Center">
                    <br />
                    <h2><asp:Label ID="lblAddGame" runat="server" Text="Add Video Game"></asp:Label></h2>
                    <br />                   
                </asp:Panel>
            </a>
                <br />
                <br />
            </Center>
        </div>
        <Footer:HomeFooter ID="FooterNav" runat="server" />
    </form>
</body>
</html>
