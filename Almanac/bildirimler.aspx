<%@ Page Title="" Language="C#" MasterPageFile="~/Profil.Master" AutoEventWireup="true" CodeBehind="bildirimler.aspx.cs" Inherits="Almanac.WebForm5" %>
<asp:Content ID="Content1" ContentPlaceHolderID="IsimSoyisim" runat="server">
    <asp:Label ID="lbAdSoyad" runat="server" Text="Ad Soyad"></asp:Label>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Profilresmi" runat="server">
    <asp:Image ID="imgPR" runat="server" ImageUrl="~/images/yeni.png" style="width:200px;height:230px;" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="kutular" runat="server">
<div style="height: 60px; width: 300px; margin-top: 15px; margin-left: 4px;">
        <div class="box msg effect kutular" onclick="location.href='bildirimler.aspx'" style="margin-right: 13px;
            width: 60px; height: 60px;cursor:pointer;">
            <img style="margin-top: 13px;" src="images/lightbulb32.png" /><span style="font-size: 12pt;
                position: absolute; color: #484848; margin-top: 2px;" id="spBldrm" runat="server">
                0</span>
            <div class="clr">
            </div>
        </div>
        <div class="box noti effect kutular" style="margin-right: 13px;cursor:pointer;" onclick="location.href='ozelmesajlar.aspx'">
            <img style="margin-top: 13px;" src="images/commentblack32.png" /><span style="font-size: 12pt;
                position: absolute; color: #484848; margin-top: 2px;" id="spMsg" runat="server">
                0</span>
            <div class="clr">
            </div>
        </div>
        <div class="littlebar" onclick="location.href='Ayarlar.aspx'" style="cursor:pointer;">
            <div class="box settings effect kutular" >

                    <img style="margin-top: 12px;" src="images/gear32.png" /></div>
        
        </div>
    </div>
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="yaziyaz" runat="server">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="panel" runat="server">
    <asp:Panel ID="pnlAlan" runat="server">
    </asp:Panel>
</asp:Content>

<asp:Content ID="Content7" ContentPlaceHolderID="galeri" runat="server">
    +
</asp:Content>
