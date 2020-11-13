<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyAccount.aspx.cs" Inherits="_3342_Term_Project.MyAccount" %>
<%@ Register Src="~/UserControls/Navbar.ascx" TagName="HomeNav" TagPrefix="Navigation" %>
<%@ Register Src="~/UserControls/Footer.ascx" TagName="HomeFooter" TagPrefix="Footer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <!-- REFERENCES START-->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" />

    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <link href="https://fonts.googleapis.com/css?family=Roboto:100,100i,300,300i,400,400i,500,500i,700,700i,900,900i" rel="stylesheet" />
    <script src="//ajax.googleapis.com/ajax/libs/jquery/1.11.0/jquery.min.js"></script>
    <script src="//netdna.bootstrapcdn.com/bootstrap/3.1.1/js/bootstrap.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.0/js/bootstrap.min.js"></script>

    <!-- Load icon library -->
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css" />

    <link href="Styles.css" rel="stylesheet" />

    <!-- REFERENCES END-->
    <title>Manage Account</title>
</head>
<body>
    <form id="frmMyAccount" runat="server">
        <Navigation:HomeNav ID="HomeNav" runat="server" />
        <div class="mainAccount">
            <br />
            <br />
            <h1>Manage Account</h1>
            <asp:ImageButton ID="ibtnManageAcct" runat="server" ImageUrl="~/Images/bluePersonImage.png"/>
            <br />
            <br />
            <asp:Label ID="lblManageEmail" runat="server" Text="E-Mail Address: " Font-Bold="True" Font-Size="X-Large"></asp:Label>
            <asp:Label ID="lblUsersEmail" runat="server" Text="Email test" Font-Size="X-Large"></asp:Label>
            <br />
            <br />
            <asp:Label ID="lblManagePassword" runat="server" Text="Password: " Font-Bold="True" Font-Size="X-Large"></asp:Label>
            <asp:TextBox ID="txtManagePassword" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="lblManageFName" runat="server" Text="First Name: " Font-Bold="True" Font-Size="X-Large"></asp:Label>
            <asp:TextBox ID="txtManageName" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="lblManageLName" runat="server" Text="Last Name: " Font-Bold="True" Font-Size="X-Large"></asp:Label>
            <asp:TextBox ID="txtManageLName" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="lblManageDOB" runat="server" Text="Date of Birth: " Font-Bold="True" Font-Size="X-Large"></asp:Label>
            <asp:TextBox ID="txtDateOfBirth" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="lblManageSecQuestions" runat="server" Text="Update Security Questions: " Font-Bold="True" Font-Size="X-Large"></asp:Label>
            <asp:Button ID="btnManageSecQuestions" runat="server" Text="Update" OnClick="btnManageSecQuestions_Click" />
            <asp:Panel ID="pnlSecQuestions" runat="server" Visible="False">
                <br />
                <asp:Label ID="lblSecQuestion1" runat="server" Text="Security Question 1: " Font-Bold="True" Font-Size="X-Large"></asp:Label>
                <br />
                <asp:DropDownList ID="ddlSecQuestion1" runat="server">
                    <asp:ListItem Selected="True" Value="None_Selected"> None Selected... </asp:ListItem>
                    <asp:ListItem Value="Option1"> Option 1 </asp:ListItem>
                </asp:DropDownList>
                <asp:TextBox ID="txtSecQuestion1" runat="server"></asp:TextBox>
                <br />
                <br />
                <asp:Label ID="lblSecQuestion2" runat="server" Text="Security Question 2: " Font-Bold="True" Font-Size="X-Large"></asp:Label>
                <br />
                <asp:DropDownList ID="ddlSecQuestion2" runat="server">
                    <asp:ListItem Selected="True" Value="None_Selected"> None Selected... </asp:ListItem>
                    <asp:ListItem Value="Option1"> Option 1 </asp:ListItem>
                </asp:DropDownList>
                <asp:TextBox ID="txtSecQuestion2" runat="server"></asp:TextBox>
                <br />
                <br />
                <asp:Label ID="lblSecQuestion3" runat="server" Text="Security Question 3: " Font-Bold="True" Font-Size="X-Large"></asp:Label>
                <br />
                <asp:DropDownList ID="ddlSecQuestion3" runat="server">
                    <asp:ListItem Selected="True" Value="None_Selected"> None Selected... </asp:ListItem>
                    <asp:ListItem Value="Option1"> Option 1 </asp:ListItem>
                </asp:DropDownList>
                <asp:TextBox ID="txtSecQuestion3" runat="server"></asp:TextBox>
            </asp:Panel>
            <br />
            <br />
            <asp:Button ID="btnSubmit" runat="server" Text="Submit" Font-Bold="True" />
            <asp:Button ID="btnClear" runat="server" Text="Clear" Font-Bold="True" />
            <br />
            <br />
        </div>
        <Footer:HomeFooter ID="FooterNav" runat="server" />
    </form>
</body>
</html>
