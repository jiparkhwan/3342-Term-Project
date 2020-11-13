<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MemberProfile.aspx.cs" Inherits="_3342_Term_Project.MemberProfile" %>
<%@ Register Src="~/UserControls/Navbar.ascx" TagPrefix="Navigation" TagName="MemberNav" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Member Account</title>
	<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.0/css/bootstrap.min.css" />
	<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
	<script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.0/js/bootstrap.min.js"></script>
	<style>
		.jumbotron.jumbotron-fluid {
			margin-bottom: 0;
		}
		#merchApiKeyForgot {
			
			margin-bottom: 30px;
		}
        .page-header{
            text-align:center;
            margin-top: 20px;
        }
        #rfvCurrentPassword, #rfvFirstName, #rfvLastName, #rfvBillingAddress, #rfvPhone, #rfvEmail, #rfvShippingAddress, #rfvState, #rfvZip{
            color:red;
            font-weight:bold;
        }
        #keyLbl, #lblOutput{
            font-weight: bold;
        }
	</style>
</head>
<body>
    <form id="form1" runat="server">
      
                <Navigation:MemberNav runat="server" ID="memberNav" />

        <div class="container">
            <div class="row panel panel-default" id="changePassword" runat="server">
                <div class="panel-body">
                    <h4 class="page-header">Change Password</h4>
                    <div class="row form-group">
                        <div class="col-md-3">
							<label>Current Password</label>
                            <asp:TextBox ID="txtCurrentPassword" runat="server" type="password" CssClass="form-control"></asp:TextBox>
							<asp:RequiredFieldValidator ID="rfvCurrentPassword" runat="server" ControlToValidate="txtCurrentPassword" ErrorMessage="Current password required" ValidationGroup="password"></asp:RequiredFieldValidator>
                        </div>
						<div class="col-md-3">
							<label>New Password</label>
							<asp:TextBox ID="txtNewPassword" runat="server" type="password" CssClass="form-control"></asp:TextBox>
							<asp:RequiredFieldValidator ID="rfvNewPassword" runat="server" ControlToValidate="txtNewPassword" ErrorMessage="New password required" ValidationGroup="password"></asp:RequiredFieldValidator>
						</div>
						<div class="col-md-3">
							<label>Confirm New Password</label>
							<asp:TextBox ID="txtNewPasswordConfirm" runat="server" type="password" CssClass="form-control"></asp:TextBox>
							<asp:RequiredFieldValidator ID="rfvNewPasswordConfirm" runat="server" ControlToValidate="txtNewPasswordConfirm" ErrorMessage="New password confirmation required" ValidationGroup="password"></asp:RequiredFieldValidator>
						</div>
                        <div class="col-md-3">
                            <asp:Button ID="btnChangePassword" runat="server" CssClass="btn btn-primary" Text="Change Password" ValidationGroup="password" OnClick="btnChangePassword_Click" />
                        </div>
                    </div>
                    <asp:Label ID="keyLbl" runat="server" Text=""></asp:Label>
                </div>
            </div>
            <div class="row panel panel-default" id="updateInfo" runat="server">
                <div class="panel-body">
                    <h4 class="page-header">Update Account Information</h4>
                    <div class="row form-group">
						 <div class="col-md-3"> 
                            <label>Email Address</label>  
                            <asp:TextBox ID="txtEmail" CssClass="form-control" runat="server" type="email"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmail" ErrorMessage="Email required" ValidationGroup="UpdateMember"></asp:RequiredFieldValidator>
                        </div>
                        <div class="col-md-3"> 
                            <label>First Name</label>  
                            <asp:TextBox ID="txtFirstName" CssClass="form-control" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvFirstName" runat="server" ControlToValidate="txtFirstName" ErrorMessage="First name required" ValidationGroup="UpdateMember"></asp:RequiredFieldValidator>
                        </div>
                        <div class="col-md-3">
                             <label>Last Name</label>
                            <asp:TextBox ID="txtLastName" CssClass="form-control" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvLastName" runat="server" ControlToValidate="txtLastName" ErrorMessage="Last name required" ValidationGroup="UpdateMember"></asp:RequiredFieldValidator>
                        </div>
						<div class="col-md-3">
                             <label>Date of Birth (mm/dd/yyyy)</label>
                            <asp:TextBox ID="txtDOB" CssClass="form-control" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="DOBValidator" runat="server" ControlToValidate="txtDOB" ErrorMessage="DOB required" ValidationGroup="UpdateMember"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                  
                    <asp:Button CssClass="btn btn-primary" ID="btnUpdate" runat="server" Text="Update Account" OnClick="btnUpdate_Click" ValidationGroup="UpdateMember" />
                    <br />
                    <asp:Label  ID="lblOutput" runat="server" Text=""></asp:Label>
                </div>
            </div>
			
    </form>
</body>
</html>