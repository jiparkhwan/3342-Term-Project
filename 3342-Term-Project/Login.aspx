<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="_3342_Term_Project.Login" %>
<%@ Register Src="~/UserControls/Navbar.ascx" TagName="HomeNav" TagPrefix="Navigation" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Member Login</title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" />

    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <link href="https://fonts.googleapis.com/css?family=Roboto:100,100i,300,300i,400,400i,500,500i,700,700i,900,900i" rel="stylesheet" />
    <script src="//ajax.googleapis.com/ajax/libs/jquery/1.11.0/jquery.min.js"></script>
    <script src="//netdna.bootstrapcdn.com/bootstrap/3.1.1/js/bootstrap.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.0/js/bootstrap.min.js"></script>

    <!-- Load icon library -->
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css" />

</head>
<body>
    <form class="form-signin" runat="server">
    <div class="login-card">
        <h3>Member Account Login</h3>
        <br />
      
           <div class="row">
			    <asp:TextBox ID="txtMemberEmail" runat="server" class="form-control" placeholder="Member Email"></asp:TextBox>
                <asp:RequiredFieldValidator ID="memberEmailValidator" controltovalidate="txtMemberEmail" runat="server" ErrorMessage="Email required"></asp:RequiredFieldValidator>
           </div>
           <div class="row">
			   <asp:TextBox ID="txtPassword" runat="server" class="form-control" type="password" Placeholder="password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="memberPasswordValidator" controltovalidate="txtPassword" runat="server" ErrorMessage="password required"></asp:RequiredFieldValidator>
            </div>
            <div class="row">
                <asp:Label runat="server"><asp:CheckBox ID="cboxRemeberMe" runat="server" />&nbsp Remember me</asp:Label>
            </div>
            <asp:Button CssClass="btn btn-primary btn-block btn-lg btn-signin" typ="submit" ID="signInBtn" runat="server" Text="Sign In" OnClick="signInBtn_Click"/>
             <asp:Label Style="color: red; font-weight: bold;" ID="Error" runat="server" Text=""></asp:Label>
             <br />
             <br />
            <asp:LinkButton ID="newMemberLink" runat="server" PostBackUrl="/Register.aspx" CssClass="link" CausesValidation="false">Register New Account</asp:LinkButton>
            <br />
            <asp:LinkButton CssClass="link" ID="forgotPwdLink" runat="server" PostBackUrl="~/AccountRecovery.aspx" CausesValidation="false">Forgot your info?</asp:LinkButton>
			<br />
           </div>
        </form>
 

      <style>
        .login-card {
            max-width: 350px;
            padding: 40px 40px;
            background-color: #282627;
            margin: 0 auto 25px;
            margin-top: 50px;
            border-radius: 2px;
            box-shadow: 0px 2px 2px rgba(0, 0, 0, 0.3);
            color:#d8e2f1;
            text-decoration: none;
        }
        .login-card h3 {
            text-align: center;
        }
        .login-card .profile-name-card {
            font-size: 16px;
            font-weight: bold;
            text-align: center;
            margin: 10px 0 0;
            min-height: 1em;
        }
        .login-card .form-signin input[type=email], .login-card .form-signin input[type=password], .login-card .form-signin input[type=text], .login-card .form-signin button {
            height: 44px;
            font-size: 16px;
            font-family: Roboto;
            z-index: 1;
            color: white;
            position: relative;
             letter-spacing: 2px;
    font-weight: 800;
    text-transform: uppercase;
            box-sizing: border-box;
            background: #778aab;
            outline: none;
            border: none;
            margin: 18px 0;
            padding: 20px 38px;
        }
        .login-card .form-signin .form-control:focus {
            border-color: rgb(104, 145, 162);
            outline: 0;
            -webkit-box-shadow: inset 0 1px 1px rgba(0,0,0,.075),0 0 8px rgb(104, 145, 162);
            box-shadow: inset 0 1px 1px rgba(0,0,0,.075),0 0 8px rgb(104, 145, 162);
        }
        .login-card .btn.btn-signin {
          
            height: 36px;
            line-height: 36px;
            font-size: 14px;
            border-radius: 3px;
            border: none;
            transition: all 0.218s;
            padding: 0;
            margin-top: 10px;
              color: white;
                 background: #778aab;
    font-family: Roboto;
    letter-spacing: 2px;
    font-weight: 800;
    text-transform: uppercase;
        }
         .login-card .btn.btn-signin:hover {
                outline: none;
                 height: 36px;
            line-height: 36px;
            font-size: 14px;
        border: none;
    
        background: #343233;
        border: 2px solid #778aab;
        font-family: Roboto;
        color: #778aab;
        letter-spacing: 2px;
        font-weight: 800;
        text-transform: uppercase;
        transition: 0.1s;
        cursor: pointer;
         }
        .login-card .link {
            text-align: center;
            color: #778aab;
            text-decoration: none;
        }
        .login-card .link:hover, .login-card .link:active, .login-card .link:focus {
            color: white;
        }
        body {
            background-color:#343233;
        }
    </style>
</body>

</html>