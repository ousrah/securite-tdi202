<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="WebApplication12.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style>
        #cadre{
            border: solid 2px black;
            width:300px;
            height:300px;
            margin:auto;
            margin-top:200px;
            padding:20px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" ValidationGroup="a" />
        <br />
         <div id="cadre">

            <table style="width:100%;">
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>Email :</td>
                    <td>&nbsp;</td>
                    <td>
                        <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtEmail" ErrorMessage="Veuillez saisir votre Email" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                        <br />
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail" ErrorMessage="L'email semble incorrect" ForeColor="#FF3300" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td>Mot de passe :</td>
                    <td>&nbsp;</td>
                    <td>
                        <asp:TextBox ID="txtPwd" runat="server" TextMode="Password"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPwd" ErrorMessage="Veuillez saisir votre mot de passe" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/inscription.aspx">S&#39;inscrire</asp:HyperLink>
                    </td>
                    <td>&nbsp;</td>
                    <td>
                        <asp:Button ID="btnConnection" runat="server" OnClick="btnConnection_Click" Text="Connexion" />
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        <asp:CheckBox ID="chksession" runat="server" Text="Garder ma session ouverte" />
                    </td>
                </tr>
            </table>
            <asp:Label ID="lblErrConnection" runat="server" ForeColor="#FF3300" Text="Login ou mot de passe incorrect" Visible="False"></asp:Label>

        </div>
        <p>
            &nbsp;</p>
        <br />
    </form>
</body>
</html>
