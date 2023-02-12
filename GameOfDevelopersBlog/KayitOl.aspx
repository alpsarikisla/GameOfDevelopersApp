<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="KayitOl.aspx.cs" Inherits="GameOfDevelopersBlog.KayitOl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="assets/css/formtasarim.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="kayitForm">
        <div class="baslik">
            <h2>Kullanıcı Bilgileri</h2>
        </div>
        <div class="formicerik">
            <asp:Label ID="lbl_mesaj" runat="server"></asp:Label>
            <table cellspacing="0">
                <%--<tr>
                    <td rowspan="6">
                        <img src="assets/SayfaResimleri/2853458.jpg" width="200" />
                    </td>
                </tr>--%>
                <tr>
                    <td width="200">İsim</td>
                    <td>
                        <asp:TextBox ID="tb_isim" runat="server" CssClass="forminput"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Soyisim</td>
                    <td>
                        <asp:TextBox ID="tb_soyisim" runat="server" CssClass="forminput"></asp:TextBox>
                    </td>
                </tr>
                <tr >
                    <td>Kullanıcı Adı</td>
                    <td>
                        <asp:TextBox ID="tb_kullaniciAdi" runat="server" CssClass="forminput"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Mail</td>
                    <td>
                        <asp:TextBox ID="tb_mail" runat="server" CssClass="forminput" TextMode="Email"></asp:TextBox>
                    </td>
                </tr>
                <tr >
                    <td>Şifre</td>
                    <td>
                        <asp:TextBox ID="tb_sifre" runat="server" CssClass="forminput" TextMode="Password"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:LinkButton ID="lbtn_kayit" runat="server" CssClass="formbutton" OnClick="lbtn_kayit_Click">Kayıt Ol</asp:LinkButton>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
