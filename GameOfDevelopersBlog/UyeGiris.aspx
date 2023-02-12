<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="UyeGiris.aspx.cs" Inherits="GameOfDevelopersBlog.UyeGiris" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="assets/css/formtasarim.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="kayitForm">
        <div class="baslik">
            <h2>Hesabınıza Giriş Yapın</h2>
        </div>
        <div class="formicerik">
            <asp:Label ID="lbl_mesaj" runat="server"></asp:Label>
            <table cellspacing="0">
               
                <tr>
                    <td width="200">Kullanıcı Adı</td>
                    <td>
                        <asp:TextBox ID="tb_kullaniciAdi" runat="server" CssClass="forminput"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Şifre</td>
                    <td>
                        <asp:TextBox ID="tb_sifre" runat="server" CssClass="forminput" TextMode="Password"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:LinkButton ID="lbtn_Giris" runat="server" CssClass="formbutton" OnClick="lbtn_Giris_Click">Giriş Yap</asp:LinkButton>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
