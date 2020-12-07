<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="_3342_Term_Project.Register" %>
<%@ Register Src="~/UserControls/Navbar.ascx" TagName="HomeNav" TagPrefix="Navigation" %>
<%@ Register Src="~/UserControls/Footer.ascx" TagName="HomeFooter" TagPrefix="Footer" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <title>Register Member Account</title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" />

    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <link href="https://fonts.googleapis.com/css?family=Roboto:100,100i,300,300i,400,400i,500,500i,700,700i,900,900i" rel="stylesheet" />
    <script src="//ajax.googleapis.com/ajax/libs/jquery/1.11.0/jquery.min.js"></script>
    <script src="//netdna.bootstrapcdn.com/bootstrap/3.1.1/js/bootstrap.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.0/js/bootstrap.min.js"></script>

    <!-- Load icon library -->
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css" />
    <link href="Styles.css" rel="stylesheet" />
    <link rel="shortcut icon" type="image/png" href="Images/LexParkLogo.png" />
</head>
<body>

		<form id="addmember" runat="server">

                      <Navigation:HomeNav ID="HomeNav" runat="server" />
            <br />
            <div class="registerPage">
            <div class="container">
			<div class="form-row">
				<div style="margin-bottom: 25px;">
					<h3>Register A New User</h3>
					<small>All fields are required</small>
				</div>
                <br />
                <br />
			</div>
			<div class="row">
               	<div class="form-group col-md-4">
					<label id="lblFirstName" runat="server">First Name</label>
					<asp:TextBox ID="txtFirstName" runat="server" class="form-control"></asp:TextBox>
					<asp:RequiredFieldValidator CssClass="validators" ID="firstNameValidator" runat="server" ControlToValidate="txtFirstName" ErrorMessage="First name required"></asp:RequiredFieldValidator>
				</div>
				<div class="form-group col-md-4">
					<label id="lblLastName" runat="server">Last Name</label>
					<asp:TextBox ID="txtLastName" runat="server" class="form-control"></asp:TextBox>
					<asp:RequiredFieldValidator CssClass="validators" ID="lastNameValidator" runat="server" ControlToValidate="txtLastName" ErrorMessage="Last name required"></asp:RequiredFieldValidator>
				</div>
				<div class="form-group col-md-4">
					<label id="lblEmail" runat="server">Email</label>
					<asp:TextBox ID="txtEmail" runat="server" class="form-control" type="email"></asp:TextBox>
					<asp:RequiredFieldValidator CssClass="validators" ID="emailValidator" ControlToValidate="txtEmail" runat="server" ErrorMessage="Email required"></asp:RequiredFieldValidator>
				</div>
			
			</div>
			<div class="row">
				<div class="form-group col-md-4">
					<label id="lblPassword" runat="server">Password</label>
					<asp:TextBox ID="txtPassword" runat="server" class="form-control" type="password"></asp:TextBox>
					<asp:RequiredFieldValidator CssClass="validators" ID="pwdValidator" ControlToValidate="txtPassword" runat="server" ErrorMessage="Password required"></asp:RequiredFieldValidator>
				</div>
				<div class="form-group col-md-4">
					<label id="lblConfirmPassword" runat="server">Confirm Password</label>
					<asp:TextBox ID="txtConfirmPassword" runat="server" class="form-control" type="password"></asp:TextBox>
					<asp:RequiredFieldValidator CssClass="validators" ID="confirmPasswordValidator" runat="server" ControlToValidate="txtConfirmPassword" ErrorMessage="Password confirmation required"></asp:RequiredFieldValidator>
				</div>
				<div class="form-group col-md-4">
					<label id="lblDOB" runat="server">Date of Birth <small>(mm/dd/yyyy)</small></label>
					<asp:TextBox ID="txtDOB" runat="server" class="form-control"></asp:TextBox>
					<asp:RequiredFieldValidator CssClass="validators" ID="DOBValidator" runat="server" ControlToValidate="txtDOB" ErrorMessage="Date of Birth required"></asp:RequiredFieldValidator>
				</div>
			</div>

		
			<br />
			<br />

			<h4>Security Questions</h4>
			<div class="row">
				<div class="form-group col-md-6">
					<label id="lblSecurityQuestion1" runat="server">Security Question 1</label>
					<br />
					<asp:DropDownList CssClass="form-control" ID="ddlSecurityQuestion1" runat="server">
						<asp:ListItem Value="What is your mother's maiden name?">What is your mother&#39;s maiden name?</asp:ListItem>
						<asp:ListItem Value="What city were you born in?">What city were you born in?</asp:ListItem>
						<asp:ListItem Value="What was the make of your first car?">What was the make of your first car?</asp:ListItem>
					</asp:DropDownList>
				</div>
				<div class="form-group col-md-6">
					<label id="lblSecurityAnswer1" runat="server">Answer to Security Question 1</label>
					<asp:TextBox ID="txtSecurityAnswer1" runat="server" class="form-control"></asp:TextBox>
					<asp:RequiredFieldValidator CssClass="validators" ID="securityAnswer1Validator" runat="server" ControlToValidate="txtSecurityAnswer1" ErrorMessage="Answer required"></asp:RequiredFieldValidator>
				</div>
			</div>
			<div class="row">
				<div class="form-group col-md-6">
					<label id="lblSecurityQuestion2" runat="server">Security Question 2</label>
					<br />
					<asp:DropDownList CssClass="form-control" ID="ddlSecurityQuestion2" runat="server">
						<asp:ListItem Value="What is the title of your favorite movie?">What is the title of your favorite movie?</asp:ListItem>
						<asp:ListItem Value="What was the name of your first pet?">What was the name of your first pet?</asp:ListItem>
						<asp:ListItem Value="What was the name of your fifth grade teacher?">What was the name of your fifth grade teacher?</asp:ListItem>
					</asp:DropDownList>
				</div>
				<div class="form-group col-md-6">
					<label id="lblSecurityAnswer2" runat="server">Answer to Security Question 2</label>
					<asp:TextBox ID="txtSecurityAnswer2" runat="server" class="form-control"></asp:TextBox>
					<asp:RequiredFieldValidator CssClass="validators" ID="securityAnswer2Validator" runat="server" ControlToValidate="txtSecurityAnswer2" ErrorMessage="Answer required"></asp:RequiredFieldValidator>
				</div>
			</div>
			<div class="row">
				<div class="form-group col-md-6">
					<label id="lblSecurityQuestion3" runat="server">Security Question 3</label>
					<br />
					<asp:DropDownList CssClass="form-control" ID="ddlSecurityQuestion3" runat="server">
						<asp:ListItem Value="What was your high school's mascot?">What was your high school's mascot?</asp:ListItem>
						<asp:ListItem Value="Who is the author of your favorite book?">Who is the author of your favorite book?</asp:ListItem>
						<asp:ListItem Value="What is the name of your childhood best friend?">What is the name of your childhood best friend?</asp:ListItem>
					</asp:DropDownList>
				</div>
				<div class="form-group col-md-6">
					<label id="lblSecurityAnswer3" runat="server">Answer to Security Question 3</label>
					<asp:TextBox ID="txtSecurityAnswer3" runat="server" class="form-control"></asp:TextBox>
					<asp:RequiredFieldValidator CssClass="validators" ID ="securityAnswer3Validator" runat="server" ControlToValidate="txtSecurityAnswer3" ErrorMessage="Answer required"></asp:RequiredFieldValidator>
				</div>
			</div>
			<div class="row">
				<div class="col-md-12">
					<asp:Button ID="Submit" CssClass="button" runat="server" Text="Submit" CausesValidation="true" OnClick="Submit_Click" />
			              
                    <asp:Button ID="backToLogin" runat="server" CausesValidation="false" CssClass="button" OnClick="BackToLoginBtn_Click" Text="Back to Login"/>

                    <asp:Label Style="color: red; font-weight: bold;" ID="Error" runat="server" Text=""></asp:Label>

                </div>
			</div>
            </div>
                </div>
               <Footer:HomeFooter ID="FooterNav" runat="server" />
		</form>
	
</body>
</html>