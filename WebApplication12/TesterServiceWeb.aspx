<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TesterServiceWeb.aspx.cs" Inherits="WebApplication12.TesterServiceWeb" %>

<%@ Register assembly="CrystalDecisions.Web, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>

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
        <p>
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        </p>
        <p>
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Tester Get Price By ID" />
        </p>
        <p>
            <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
        </p>
        <p>
            &nbsp;</p>
        <asp:Button ID="Button3" runat="server" Text="Button asp coté client" onClientClick="test()" OnClick="Button3_Click2"   />
        <input id="Button4" type="button" value="button input cote serveur " runat="server"  onserverclick="Button3_Click" /></p>
   </form>
    <p>
    <script>
        function test()
        {
            alert("ok");
        }

    </script>

</body>
</html>
