<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanel/AdminMaster.Master" AutoEventWireup="true" CodeBehind="KategoriDuzenle.aspx.cs" Inherits="GameOfDevelopersBlog.AdminPanel.KategoriDuzenle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="formContainer">
        <div class="formTitle">
            <h3>Kategori Düzenle</h3>
        </div>
        <div class="formContent">
            <asp:Panel ID="pnl_basarili" runat="server" CssClass="basarili" Visible="false">
                Kategori Düzenleme Başarılı
            </asp:Panel>
             <asp:Panel ID="pnl_basarisiz" runat="server" CssClass="basarisiz"  Visible="false">
                <asp:Label ID="lbl_mesaj" runat="server"></asp:Label>
            </asp:Panel>
            <div class="row">
                <label>Kategori Adı</label><br />
                <asp:TextBox ID="tb_isim" runat="server" CssClass="inputBox"></asp:TextBox>
            </div>
            <div class="row">
                <asp:LinkButton ID="lbtn_duzenle" runat="server" Text="Kategori Düzenle" CssClass="formbutton" OnClick="lbtn_duzenle_Click"></asp:LinkButton>
            </div>
        </div>
    </div>
</asp:Content>
