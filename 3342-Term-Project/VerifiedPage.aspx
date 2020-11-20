<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VerifiedPage.aspx.cs" Inherits="_3342_Term_Project.VerifiedPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Verified</title>
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
    <form id="form1" runat="server">
        <div>

             <div class="login-card">
                 <asp:Label ID="lblResult" runat="server" Text=""></asp:Label>
                  <asp:LinkButton CssClass="link" ID="redirectToLogin" runat="server" PostBackUrl="~/Login.aspx" CausesValidation="false">Click me to be redirected to login page.</asp:LinkButton>

                    </div>
        </div>
    </form>


     <style>
        .login-card {
            max-width: 350px;
            padding: 40px 40px;
            background-color: #F7F7F7;
            margin: 0 auto 25px;
            margin-top: 50px;
            border-radius: 2px;
            box-shadow: 0px 2px 2px rgba(0, 0, 0, 0.3);
            text-align:center;
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
