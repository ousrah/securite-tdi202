<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="testCookies.aspx.cs" Inherits="WebApplication12.testCookies" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
    <h1>Test des cookies</h1>
    <br />
    <br />
    <br />
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            &nbsp;<asp:Button ID="btnEcrireCookie" runat="server" Text="Ecrire cookie" OnClick="btnEcrireCookie_Click"  />
            <br />
            <br />
            <asp:Button ID="btnSupprimerCookie" runat="server" Text="supprimer Cookie" OnClick="btnSupprimerCookie_Click" />
            <br />
            <br />
            <br />
            <asp:Button ID="btnLireCookie" runat="server" Text="lire cookie" OnClick="btnLireCookie_Click" />
            &nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        </div>
    </form>
</body>
</html>
