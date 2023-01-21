<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanel/AdminMaster.Master" AutoEventWireup="true" CodeBehind="KategoriEkle.aspx.cs" Inherits="GameOfDevelopersBlog.AdminPanel.KategoriEkle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="formContainer">
        <div class="formTitle">
            <h3>Kategori Ekle</h3>
        </div>
        <div class="formContent">
            <asp:Panel ID="pnl_basarili" runat="server" CssClass="basarili" Visible="false">
                Kategori Ekleme Başarılı
            </asp:Panel>
             <asp:Panel ID="pnl_basarisiz" runat="server" CssClass="basarisiz"  Visible="false">
                <asp:Label ID="lbl_mesaj" runat="server"></asp:Label>
            </asp:Panel>
            <div class="row">
                <label>Kategori Adı</label><br />
                <asp:TextBox ID="tb_isim" runat="server" CssClass="inputBox"></asp:TextBox>
            </div>
            <div class="row">
                <asp:LinkButton ID="lbtn_ekle" runat="server" Text="Kategori Ekle" CssClass="formbutton" OnClick="lbtn_ekle_Click"></asp:LinkButton>
            </div>
        </div>
    </div>
</asp:Content>
