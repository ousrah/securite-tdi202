<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestSession.aspx.cs" Inherits="WebApplication12.TestSession" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Test des variables session</h1>
            <br />
            <br />
            <br />
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            &nbsp;<asp:Button ID="btnEcrireSession" runat="server" OnClick="btnEcrireSession_Click" Text="Ecrire Session" />
            <br />
            <br />
            <br />
            <br />
            <br />
            <asp:Button ID="btnLireSession" runat="server" Text="lire session" OnClick="btnLireSession_Click" />
            &nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        </div>
    </form>
    <script>
        
    </script>
</body>
</html>
