<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="signup.aspx.cs" Inherits="BasicSignUp.signup" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            height: 507px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="auto-style1">
    
        <asp:Label ID="lblWelcome" runat="server" Text="Label"></asp:Label>
    
        <br />
        <br />
        <br />
        <asp:Label ID="lblFirstName" runat="server" Text="First Name"></asp:Label>
        <br />
        <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>
        <asp:Label ID="lblFirstNameRequire" runat="server" ForeColor="Red" Text="* This field is required" Visible="False"></asp:Label>
        <br />
        <br />
        <asp:Label ID="lblLastName" runat="server" Text="Last Name"></asp:Label>
        <br />
        <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
        <asp:Label ID="lblLastNameRequire" runat="server" ForeColor="Red" Text="* This field is required" Visible="False"></asp:Label>
        <br />
        <br />
        <asp:Label ID="Country" runat="server" Text="Country"></asp:Label>
        <br />
        <asp:TextBox ID="txtCountry" runat="server"></asp:TextBox>
        <asp:Label ID="lblCountryRequire" runat="server" ForeColor="Red" Text="* This field is required" Visible="False"></asp:Label>
        <br />
        <br />
        <asp:Label ID="lblPassword" runat="server" Text="Password"></asp:Label>
        <br />
        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
        <asp:Label ID="lblPasswordRequire" runat="server" ForeColor="Red" Text="* This field is required" Visible="False"></asp:Label>
        <br />
        <br />
        <asp:Label ID="lblPasswordConfirm" runat="server" Text="Repeat Password"></asp:Label>
        <br />
        <asp:TextBox ID="txtPwConfirmRequire" runat="server" TextMode="Password"></asp:TextBox>
        <asp:Label ID="lblPasswordConfirmRequire" runat="server" ForeColor="Red" Text="* Passwords must match" Visible="False"></asp:Label>
        <br />
        <br />
        <asp:Button ID="btnSubmitInfo" runat="server" OnClick="btnSubmitInfo_Click" Text="Submit" />
    
        <br />
        <br />
        <asp:TextBox ID="txtError" runat="server" Visible="False" Width="303px">Oh no!  Something went wrong!</asp:TextBox>
        <br />
        <br />
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:InternetProgrammingTestConnectionString %>" SelectCommand="SELECT * FROM [User]"></asp:SqlDataSource>
    
    </div>
    </form>
</body>
</html>
