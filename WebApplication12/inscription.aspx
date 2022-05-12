<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="inscription.aspx.cs" Inherits="WebApplication12.inscription" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
      <style>
        #cadre{
            border: solid 2px black;
            width:500px;
            height:500px;
            margin:auto;
            margin-top:200px;
            padding:20px;
        }
          .auto-style1 {
              height: 33px;
          }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div id="cadre">

            <table style="width:100%;">
                <tr>
                    <td>Email</td>
                    <td>&nbsp;</td>
                    <td>
                        <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                        <br />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtEmail" ErrorMessage="l'email est obligatoire" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                        <br />
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail" ErrorMessage="l'email semble incorrect" ForeColor="#FF3300" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td>Nom</td>
                    <td>&nbsp;</td>
                    <td>
                        <asp:TextBox ID="txtNom" runat="server"></asp:TextBox>
                        <br />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtNom" ErrorMessage="le nom est obligatoire" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>mot de passe</td>
                    <td>&nbsp;</td>
                    <td>
                        <asp:TextBox ID="txtPwd1" runat="server" TextMode="Password"></asp:TextBox>
                        <br />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtPwd1" ErrorMessage="le mot de passe est obligatoire" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>Valider mot de passe</td>
                    <td>&nbsp;</td>
                    <td>
                        <asp:TextBox ID="txtPwd2" runat="server" TextMode="Password"></asp:TextBox>
                        <br />
                        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtPwd1" ControlToValidate="txtPwd2" ErrorMessage="les deux mots de passe doivent être identiques" ForeColor="#FF3300"></asp:CompareValidator>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style1">
                        <asp:Button ID="btnInscription" runat="server" Text="Inscription" OnClick="btnInscription_Click" />
                    </td>
                    <td class="auto-style1"></td>
                    <td class="auto-style1"></td>
                </tr>
            </table>

            <asp:Label ID="lblErrExiste" runat="server" ForeColor="#FF3300" Text="Cet émail est déjà existant" Visible="False"></asp:Label>

        </div>
    </form>
</body>
</html>
