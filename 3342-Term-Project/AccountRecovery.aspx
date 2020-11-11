<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AccountRecovery.aspx.cs" Inherits="_3342_Term_Project.AccountRecovery" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
 <title>Retrieve Account</title>
	<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.0/css/bootstrap.min.css" />
	<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
	<script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.0/js/bootstrap.min.js"></script>
    <style>
        .card {
            max-width: 900px;
            padding: 40px 40px;
            background-color: #F7F7F7;
            margin: 0 auto 25px;
            margin-top: 50px;
            border-radius: 2px;
            box-shadow: 0px 2px 2px rgba(0, 0, 0, 0.3);
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h3>Login Credential Recovery</h3>
			<asp:LinkButton ID="lbLogin" runat="server" CausesValidation="false" PostBackUrl="~/Login.aspx">Return to Login</asp:LinkButton>
			<br />
			<br/>

            <asp:Button ID="btnCustomer" CausesValidation="false"  runat="server" CssClass="btn btn-primary" Text="I am a Member" OnClick="btnCustomer_Click" />
            <asp:Button ID="btnBack"  CausesValidation="false" runat="server" CssClass="btn btn-primary" Text="Back" OnClick="Back_Click"/>

            <div id="customer" class="card" runat="server">
                <div class="row form-group">
                    <div class="col-md-2">
                        <label >I forgot my: </label>
                    </div>
                    <div class="col-md-5">
                        <asp:DropDownList CssClass="form-control"  AutoPostBack="true" ID="custForgotDL" runat="server"  OnSelectedIndexChanged="custForgotDL_SelectedIndexChanged">
                            <asp:ListItem >---</asp:ListItem>
                            <asp:ListItem >Email</asp:ListItem>
                            <asp:ListItem>Password</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>


                <div class="row" id="custEmailForgot" runat="server">
                    
                    <label>First Name</label>
                    <asp:TextBox ID="FnameTxt" runat="server" class="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ControlToValidate="FnameTxt" ID="custFnameValidator" runat="server" ErrorMessage="First Name Required"></asp:RequiredFieldValidator>

                    <br />    

                    <label>Last Name</label>
                    <asp:TextBox ID="LnameTxt" runat="server" class="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ControlToValidate="LnameTxt" ID="custLnameValidator" runat="server" ErrorMessage="Last Name Required"></asp:RequiredFieldValidator>

                    <br />

                    <label>Date of Birth</label>
                    <asp:TextBox ID="dobTxt" runat="server" class="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ControlToValidate="dobTxt" ID="dobValidator" runat="server" ErrorMessage="DOB Required"></asp:RequiredFieldValidator>
    
                    <br />
                        
                    <asp:Button ID="emailForgotSubmitBtn" runat="server" CssClass="btn btn-primary" Text="Submit" Onclick="emailForgotSubmitBtn_Click" />

                       
                </div>

                
                <div class="row" id="custPwdForgot" runat="server">

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
                     <asp:Button ID="custSubmitBtn" runat="server" CssClass="btn btn-primary" Text="Submit" Onclick="custPwdSubmitBtn_Click" />

                </div>
             


            </div>

            <asp:Label Style="font-weight: bold; font-size: 1.5em;" ID="Output" runat="server" Text=""></asp:Label>

        </div>
    </form>
</body>
</html>