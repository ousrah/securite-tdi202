<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="testApplication.aspx.cs" Inherits="WebApplication12.testApplication" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <h1>Test des variables Application</h1>
    <br />
    <br />
    <br />
    <form id="form1" runat="server">
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            &nbsp;<asp:Button ID="btnEcrireApplication" runat="server" Text="Ecrire Application" OnClick="btnEcrireApplication_Click" />
            <br />
            <br />
            <br />
            <br />
            <br />
            <asp:Button ID="btnLireApplication" runat="server" Text="lire application" OnClick="btnLireApplication_Click" />
            &nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        <div>
        </div>
    </form>
</body>
</html>
