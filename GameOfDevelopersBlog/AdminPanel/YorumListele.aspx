<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanel/AdminMaster.Master" AutoEventWireup="true" CodeBehind="YorumListele.aspx.cs" Inherits="GameOfDevelopersBlog.AdminPanel.YorumListele" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <h3>Tüm Yorumlar</h3>
    <div>
        <asp:ListView ID="lv_yorumlar" runat="server">
            <LayoutTemplate>
                <table class="tablo" cellpaddind="0" cellspacing="0">
                    <thead>
                        <tr>
                            <th>ID</th>
                            <th>Makale</th>
                            <th>Uye</th>
                            <th>Yonetici</th>
                            <th>İçerik</th>
                            <th>Onay Durum</th>
                            <th>Seçenekler</th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:PlaceHolder ID="ItemPlaceHolder" runat="server"></asp:PlaceHolder>
                    </tbody>
                </table>
            </LayoutTemplate>
            <ItemTemplate>
                <tr>
                    <td><%# Eval("ID") %></td>
                    <td><%# Eval("Makale") %></td>
                    <td><%# Eval("Uye") %></td>
                    <td><%# Eval("Yonetici") %></td>
                    <td><%# Eval("Icerik") %></td>
                    <td><%# Eval("Onay") %></td>
                    <td>
                        <a href='MakaleDuzenle.aspx?mid=<%# Eval("ID") %>' class="duzenle">Onayla</a>
                        <asp:LinkButton ID="lbtn_sil" runat="server" CssClass="sil" CommandArgument='<%# Eval("ID") %>' CommandName="Reddet">Reddet</asp:LinkButton>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:ListView>
    </div>
</asp:Content>
