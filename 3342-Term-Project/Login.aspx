<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="_3342_Term_Project.Login" %>
<%@ Register Src="~/UserControls/Navbar.ascx" TagName="HomeNav" TagPrefix="Navigation" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
      <title>Member Login</title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.0/css/bootstrap.min.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.0/js/bootstrap.min.js"></script>
        <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>

  
</head>
<body>
              <Navigation:HomeNav ID="HomeNav" runat="server" />

    <div class="login-card">
        <h3>Member Account Login</h3>
        <br />
        <form class="form-signin" runat="server">
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
                        <asp:LinkButton ID="newMemberLink" runat="server" PostBackUrl="~/Register.aspx" CausesValidation="false">Register New Account</asp:LinkButton>
            <br />
            <asp:LinkButton CssClass="link" ID="forgotPwdLink" runat="server" PostBackUrl="~/AccountRecovery.aspx" CausesValidation="false">Forgot your password?</asp:LinkButton>
			<br />
        </form>
    </div>

      <style>
        .login-card {
            max-width: 350px;
            padding: 40px 40px;
            background-color: #F7F7F7;
            margin: 0 auto 25px;
            margin-top: 50px;
            border-radius: 2px;
            box-shadow: 0px 2px 2px rgba(0, 0, 0, 0.3);
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
            width: 100%;
            z-index: 1;
            position: relative;
            box-sizing: border-box;
        }
        .login-card .form-signin .form-control:focus {
            border-color: rgb(104, 145, 162);
            outline: 0;
            -webkit-box-shadow: inset 0 1px 1px rgba(0,0,0,.075),0 0 8px rgb(104, 145, 162);
            box-shadow: inset 0 1px 1px rgba(0,0,0,.075),0 0 8px rgb(104, 145, 162);
        }
        .login-card .btn.btn-signin {
            font-weight: 700;
            height: 36px;
            line-height: 36px;
            font-size: 14px;
            border-radius: 3px;
            border: none;
            transition: all 0.218s;
            padding: 0;
            margin-top: 10px;
        }
        .login-card .link {
            color: rgb(104, 145, 162);
        }
        .login-card .link:hover, .login-card .link:active, .login-card .link:focus {
            color: rgb(12, 97, 33);
        }
    </style>
</body>

</html>