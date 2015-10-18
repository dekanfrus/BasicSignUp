<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="BasicSignUp.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Basic Signup Page</title>
    <link rel="stylesheet" type="text/css" href="style.css" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="signup">
    
        <asp:Label ID="lblUserName" runat="server" Text="Username"></asp:Label>
        <br />
        <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
        <asp:Label ID="flagUserName" runat="server" ForeColor="Red" Text="* This field is required" Visible="False"></asp:Label>
        <br />
        <asp:Label ID="lblEmail" runat="server" Text="Email Address"></asp:Label>
    
    </div>
        <asp:TextBox ID="txtEmail" runat="server" TextMode="Email"></asp:TextBox>
        <asp:Label ID="flagEmail" runat="server" ForeColor="Red" Text="* This field is required" Visible="False"></asp:Label>
        <br />
        <br />
        <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Submit" />
        <br />
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:InternetProgrammingTestConnectionString %>" SelectCommand="SELECT * FROM [User]"></asp:SqlDataSource>
    </form>
</body>
</html>
