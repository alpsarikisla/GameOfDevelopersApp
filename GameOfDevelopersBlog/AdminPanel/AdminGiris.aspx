<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminGiris.aspx.cs" Inherits="GameOfDevelopersBlog.AdminPanel.AdminGiris" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>GOD Panel Giriş</title>
    <link href="Assets/css/GirisCss.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server" style="height:100%">
       
        <div class="container">
            <div class="loginBox">
                <div style="margin-top:15px;">
                    <asp:TextBox ID="tb_mail" runat="server" CssClass="inputBox" placeholder="Mail Adresiniz"></asp:TextBox>
                </div>
                <div style="margin-top:15px;">
                    <asp:TextBox ID="tb_sifre" runat="server" CssClass="inputBox" placeholder="Şifreniz" TextMode="Password"></asp:TextBox>
                </div>
                <div style="margin-top:15px;">
                    <asp:LinkButton ID="lbtn_giris" runat="server" Text="Giriş Yap" CssClass="loginButton" OnClick="lbtn_giris_Click"> </asp:LinkButton>
                </div>
            </div>
        </div>

    </form>
</body>
</html>
