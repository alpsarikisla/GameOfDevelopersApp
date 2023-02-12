<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="MakaleOku.aspx.cs" Inherits="GameOfDevelopersBlog.MakaleOku" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="assets/css/formtasarim.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="makaleDetay" style="height:100%">
        <asp:Image ID="img_resim" runat="server" />
        <div class="baslik">
            <%-- Literal Etiket üretmeden içeriğin alınmasını sağlar--%>
            <h2>
                <asp:Literal ID="ltrl_baslik" runat="server"></asp:Literal></h2>
        </div>
        <div class="bilgi">
            Yazar :
            <asp:Literal ID="ltrl_yazar" runat="server"></asp:Literal>
            | Kategori :
            <asp:Literal ID="ltrl_kategori" runat="server"></asp:Literal>
            | Görüntüleme :
            <asp:Literal ID="ltrl_goruntuleme" runat="server"></asp:Literal>
        </div>
        <div class="icerik">
             <asp:Literal ID="ltrl_icerik" runat="server"></asp:Literal>
             <div style="height:20px;"></div>
        </div>
      <hr />
    </div>
    <div class="yorumPanel">
        <div class="yorumpanelBaslik">
            <h3>Yorumlar</h3>
        </div>
        <asp:Panel ID="pnl_girisvar" runat="server" CssClass="girisvar" >
            <asp:TextBox ID="tb_yorum" runat="server" TextMode="MultiLine" CssClass="forminput"></asp:TextBox>
            <br /><br />
            <asp:LinkButton ID="lbtn_yorumYap" runat="server" CssClass="formbutton">Yorum Yap</asp:LinkButton>
        </asp:Panel>
         <asp:Panel ID="pnl_girisyok" runat="server" CssClass="girisyok">
            Yorum Yapabilmek İçin Lütfen öncelikle <asp:LinkButton ID="lbtn_girisyonlendir" runat="server" OnClick="lbtn_girisyonlendir_Click">Üye Girişi</asp:LinkButton> yapınız.
        </asp:Panel>
        <div class="yorumpanelBaslik">
             <asp:Repeater ID="rp_yorumlar" runat="server">
                 <ItemTemplate>
                     <div class="yorum">
                        Üye  = <label class="Yorumuye"> <%# Eval("Uye") %> </label>
                         <br />
                         <%# Eval("Icerik") %>
                     </div>
                 </ItemTemplate>
             </asp:Repeater>
        </div>
       
    </div>
</asp:Content>
