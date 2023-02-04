<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanel/AdminMaster.Master" AutoEventWireup="true" CodeBehind="MakaleEkle.aspx.cs" Inherits="GameOfDevelopersBlog.AdminPanel.MakaleEkle" ValidateRequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="formContainer">
        <div class="formTitle">
            <h3>Makale Ekle</h3>
        </div>
        <div class="formContent">
            <asp:Panel ID="pnl_basarili" runat="server" CssClass="basarili" Visible="false">
                Makale Ekleme Başarılı
            </asp:Panel>
            <asp:Panel ID="pnl_basarisiz" runat="server" CssClass="basarisiz" Visible="false">
                <asp:Label ID="lbl_mesaj" runat="server"></asp:Label>
            </asp:Panel>
            <div style="float: left; width: 50%">
                <div class="row">
                    <label>Kategori</label><br />
                    <asp:DropDownList ID="ddl_kategoriler" runat="server" CssClass="inputBox" AppendDataBoundItems="true" Style="width: 415px">
                        <asp:ListItem Text="Seçiniz" Value="0"></asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="row">
                    <label>Makale Başlığı</label><br />
                    <asp:TextBox ID="tb_baslik" runat="server" CssClass="inputBox"></asp:TextBox>
                </div>
                <div class="row">
                    <label>Makale Resim</label><br />
                    <asp:FileUpload ID="fu_resim" runat="server"></asp:FileUpload>
                </div>
                <div class="row">
                    <label>Yayın Durumu</label><br />
                    <asp:CheckBox ID="cb_yayinda" runat="server" Text="  Yayında"></asp:CheckBox>
                </div>
            </div>
            <div style="float: right; width: 50%">
                <div class="row">
                    <label>Makale Özet</label><br />
                    <asp:TextBox ID="tb_ozet" TextMode="MultiLine" runat="server" CssClass="inputBox"></asp:TextBox>
                </div>
                <div class="row">
                    <label>Makale İçerik</label><br />
                    <asp:TextBox ID="tb_icerik" TextMode="MultiLine" runat="server" CssClass="inputBox"></asp:TextBox>
                </div>
                <div class="row">
                    <asp:LinkButton ID="lbtn_ekle" runat="server" Text="Makale Ekle" CssClass="formbutton" OnClick="lbtn_ekle_Click"></asp:LinkButton>
                </div>
            </div>
            <div style="clear: both"></div>


        </div>
    </div>
</asp:Content>
