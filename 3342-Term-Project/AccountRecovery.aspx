<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AccountRecovery.aspx.cs" Inherits="_3342_Term_Project.AccountRecovery" %>
<%@ Register Src="~/UserControls/Navbar.ascx" TagName="HomeNav" TagPrefix="Navigation" %>
<%@ Register Src="~/UserControls/Footer.ascx" TagName="HomeFooter" TagPrefix="Footer" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
 <title>Retrieve Account</title>
	 <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" />

    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <link href="https://fonts.googleapis.com/css?family=Roboto:100,100i,300,300i,400,400i,500,500i,700,700i,900,900i" rel="stylesheet" />
    <script src="//ajax.googleapis.com/ajax/libs/jquery/1.11.0/jquery.min.js"></script>
    <script src="//netdna.bootstrapcdn.com/bootstrap/3.1.1/js/bootstrap.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.0/js/bootstrap.min.js"></script>

    <!-- Load icon library -->
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css" />

    <link href="Styles.css" rel="stylesheet" />
    <style>
        .card {
            max-width: 900px;
            padding: 40px 40px;
            background-color: #282627;
            margin: 0 auto 25px;
            margin-top: 50px;
            border-radius: 2px;
            box-shadow: 0px 2px 2px rgba(0, 0, 0, 0.3);
            text-align:center;

              font-family: Roboto;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
         <Navigation:HomeNav ID="HomeNav" runat="server" />
        <div class="mainAccount">
        <div class="container">
            <h2>Login Credential Recovery</h2>
			<br />
			<br/>

            <asp:Button ID="btnMember" CausesValidation="false"  runat="server" CssClass="buttonReview" Text="Begin Recovery" OnClick="btnMember_Click" />
            <asp:Button ID="btnBack"  CausesValidation="false" runat="server" CssClass="buttonReview" Text="Restart" OnClick="Back_Click"/>

            <div id="member" class="card" runat="server">
                <div class="row form-group">
                    <div class="col-md-2">
                        <h6 >I forgot my: </h6>
                    </div>
                    <div class="col-md-5">
                        <asp:DropDownList CssClass="form-control"  AutoPostBack="true" ID="memberForgotDL" runat="server"  OnSelectedIndexChanged="memberForgotDL_SelectedIndexChanged">
                            <asp:ListItem >---</asp:ListItem>
                            <asp:ListItem >Email</asp:ListItem>
                            <asp:ListItem>Password</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>

               
                <div class="mainAccount" ID="memberEmailForgot" runat="server">
                    <br />
                    <h6>First Name</h6>
                    <asp:TextBox ID="FnameTxt" runat="server" class="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ControlToValidate="FnameTxt" ID="memberFnameValidator" runat="server" ErrorMessage="First Name Required"></asp:RequiredFieldValidator>

                   
                    <h6>Last Name</h6>
                    <asp:TextBox ID="LnameTxt" runat="server" class="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ControlToValidate="LnameTxt" ID="memberLnameValidator" runat="server" ErrorMessage="Last Name Required"></asp:RequiredFieldValidator>

                    
                    <h6>Date of Birth <small>(mm/dd/yyyy)</small></h6>
                    <asp:TextBox ID="dobTxt" runat="server" class="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ControlToValidate="dobTxt" ID="dobValidator" runat="server" ErrorMessage="DOB Required"></asp:RequiredFieldValidator>
    
                 
                     <br />   
                    <asp:Button ID="emailForgotSubmitBtn" runat="server" CssClass="buttonReview" Text="Submit" Onclick="emailForgotSubmitBtn_Click" />

                       
                </div>
               
                
                <div class="row" id="memberPwdForgot" runat="server">

                    <label>Email Address</label>
                    <asp:TextBox ID="emailTxt"  runat="server" type="email" class="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ControlToValidate="emailTxt" ID="emailValidator" runat="server" ErrorMessage="Enter your email"></asp:RequiredFieldValidator>
                    <br />

                    <div id="securityQs" runat="server">
                        <h4 style="text-align:center;">Security Questions</h4>
                        
                        <asp:Label ID="q1" runat="server" Text=""></asp:Label>
                        <asp:TextBox ID="ans1" runat="server" class="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ControlToValidate="ans1" ID="ans1Validator" runat="server" ErrorMessage="Security Answer Required"></asp:RequiredFieldValidator>

                        <br />

                        <asp:Label ID="q2" runat="server" Text=""></asp:Label>
                        <asp:TextBox ID="ans2" runat="server" class="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ControlToValidate="ans2" ID="ans2Validator" runat="server" ErrorMessage="Security Answer Required"></asp:RequiredFieldValidator>

                        <br />

                        <asp:Label ID="q3" runat="server" Text=""></asp:Label>
                        <asp:TextBox ID="ans3" runat="server" class="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ControlToValidate="ans3" ID="ans3Validator" runat="server" ErrorMessage="Security Answer Required"></asp:RequiredFieldValidator>

                    </div>

                    <br />
                    <div class="btncontainer">
                     <asp:Button ID="memberSubmitBtn" runat="server" CssClass="button" Text="Submit" Onclick="memberPwdSubmitBtn_Click"/>
                    </div>
                              

                </div>
             


            </div>

            <asp:Label Style="font-weight: bold; font-size: 1.5em;" ID="Output" runat="server" Text=""></asp:Label>
              <asp:Button ID="lblLogin" runat="server" CausesValidation="false" PostBackUrl="~/Login.aspx" Text="Return to Login" CssClass="buttonReview"/>
        </div>
            </div>
    </form>
</body>
</html>