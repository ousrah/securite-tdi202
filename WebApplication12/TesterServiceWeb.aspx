<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TesterServiceWeb.aspx.cs" Inherits="WebApplication12.TesterServiceWeb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:RadioButton ID="RadioButton1" runat="server" Checked="True" GroupName="a" Text="en" />
            <br />
            <asp:RadioButton ID="RadioButton2" runat="server" GroupName="a" Text="ar" />
            <br />
            <asp:RadioButton ID="RadioButton3" runat="server" GroupName="a" Text="fr" />
            <br />
            <asp:RadioButton ID="RadioButton4" runat="server" GroupName="a" Text="es" />
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="tester hello world" />
            <br />
            <br />
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        </div>
    </form>
</body>
</html>
