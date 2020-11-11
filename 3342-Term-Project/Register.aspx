<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="_3342_Term_Project.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <title>Register Member Account</title>
	<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.0/css/bootstrap.min.css" />
	<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
	<script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.0/js/bootstrap.min.js"></script>
</head>
<body>
	<div class="container">
		<form id="addMember" runat="server">
			<div class="form-row">
				<div style="margin-bottom: 25px;">
					<h3>Register A New Member</h3>
					<small>All fields are required</small>
					<asp:Label Style="color: red; font-weight: bold;" ID="Error" runat="server" Text=""></asp:Label>
				</div>
			</div>
            <asp:LinkButton ID="lbLogin" runat="server" CausesValidation="false" PostBackUrl="~/Login.aspx">Return to Login</asp:LinkButton>
            <br />
            <br />
			<div class="row">
				<div class="form-group col-md-3">
					<label id="lblMemberUsername" runat="server">Username</label>
					<asp:TextBox ID="txtMemberUsername" runat="server" class="form-control"></asp:TextBox>
					<asp:RequiredFieldValidator ID="MemberUsernameValidator" ControlToValidate="txtMemberID" runat="server" ErrorMessage="Member username required"></asp:RequiredFieldValidator>
				</div>
				<div class="form-group col-md-9">

					<label id="lblMemberPassword" runat="server">Password</label>
					<asp:TextBox ID="txtMemberPassword" runat="server" class="form-control"></asp:TextBox>
					<asp:RequiredFieldValidator ID="txtMemberPasswordValidator" ControlToValidate="txtMemberPassword" runat="server" ErrorMessage="password required"></asp:RequiredFieldValidator>
				</div>				
			</div>
			<div class="row">
				<div class="form-group col-md-3">
					<label id="lblFirstName" runat="server">First Name</label>
					<asp:TextBox ID="txtFirstName" runat="server" class="form-control"></asp:TextBox>
					<asp:RequiredFieldValidator ID="firstNameValidator" runat="server" ControlToValidate="txtFirstName" ErrorMessage="First name required"></asp:RequiredFieldValidator>
				</div>
				<div class="form-group col-md-3">
					<label id="lblLastName" runat="server">Last Name</label>
					<asp:TextBox ID="txtLastName" runat="server" class="form-control"></asp:TextBox>
					<asp:RequiredFieldValidator ID="lastNameValidator" runat="server" ControlToValidate="txtLastName" ErrorMessage="Last name required"></asp:RequiredFieldValidator>
				</div>

				<div class="form-group col-md-3">
					<label id="lblEmail" runat="server">Email</label>
					<asp:TextBox ID="txtEmail" runat="server" class="form-control" type="email"></asp:TextBox>
					<asp:RequiredFieldValidator ID="emailValidator" ControlToValidate="txtEmail" runat="server" ErrorMessage="Email required"></asp:RequiredFieldValidator>
				</div>

				<div class="form-group col-md-3">
					<label id="lblDOB" runat="server">Date of Birth (mm/dd/yyyy)</label>
					<asp:TextBox ID="txtDOB" runat="server" class="form-control"></asp:TextBox>
					<asp:RequiredFieldValidator ID="DOBValidator" runat="server" ControlToValidate="txtDOB" ErrorMessage="Date of Birth required"></asp:RequiredFieldValidator>
				</div>
			</div>
		
			<div class="row">
				<div class="col-md-12">
					<asp:Button ID="Submit" CssClass="btn btn-primary" runat="server" Text="Register" OnClick="btnSubmit_Click" />
				</div>
			</div>
			<br />
			<asp:Label Style="font-weight: bold; font-size: 1.5em;" ID="Output" runat="server" Text=""></asp:Label>
		</form>
	</div>
</body>
</html>