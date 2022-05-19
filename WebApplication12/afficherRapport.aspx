<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="afficherRapport.aspx.cs" Inherits="WebApplication12.afficherRapport" %>

<%@ Register assembly="CrystalDecisions.Web, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Etat des ouvrages" />
&nbsp;
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Etat des editeurs" />
        <br />
        <br />
        <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="True" GroupTreeImagesFolderUrl="" Height="1202px" ToolbarImagesFolderUrl="" ToolPanelView="None" ToolPanelWidth="200px" Width="1104px" />
        <div>
        </div>
    </form>
</body>
</html>
