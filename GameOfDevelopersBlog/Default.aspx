<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="GameOfDevelopersBlog.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Repeater ID="rp_makaleler" runat="server">
        <ItemTemplate>
            <div class="makale">
                <div class="baslik">
                    <%--imdat--%>
                    <h2><%# Eval("Baslik") %></h2>
                </div>
                <div class="bilgi">
                    Yazar : <%# Eval("Yonetici") %> | Kategori : <%# Eval("Kategori") %> | Görüntüleme : <%# Eval("GoruntulemeSayisi") %>
                </div>
                <div>
                    <div class="resim">
                        <a href='MakaleResimleri/<%# Eval("Resim") %>' target="_blank">
                            <img src='MakaleResimleri/<%# Eval("Resim") %>' /></a>
                    </div>
                    <div class="ozet">
                        <%# Eval("Ozet") %>
                        <br />
                        <a href='MakaleOku.aspx?mid=<%# Eval("ID") %>'>Devamı...</a>
                    </div>
                </div>
            </div>
            <div style="clear: both"></div>
        </ItemTemplate>
    </asp:Repeater>
</asp:Content>
