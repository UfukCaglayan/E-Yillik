
<%@ Page Title="" Language="C#" MasterPageFile="~/Profil.Master" AutoEventWireup="true"
    CodeBehind="galeri.aspx.cs" Inherits="Almanac.WebForm6" %>

<asp:Content ID="Content1" ContentPlaceHolderID="IsimSoyisim" runat="server">
    <asp:Label ID="lbAdSoyad" runat="server" Text="Ad Soyad"></asp:Label>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Profilresmi" runat="server">
    <asp:Image ID="imgPR" Style="width: 200px; height: 230px;" runat="server" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="kutular" runat="server">
    <div style="height: 60px; width: 300px; margin-top: 15px; margin-left: 4px;">
        <div class="box msg effect kutular" onclick="location.href='bildirimler.aspx'" style="margin-right: 13px;
            width: 60px; height: 60px; cursor: pointer;">
            <img style="margin-top: 13px;" src="images/lightbulb32.png" /><span style="font-size: 12pt;
                position: absolute; color: #484848; margin-top: 2px;" id="spBldrm" runat="server">
                0</span>
            <div class="clr">
            </div>
        </div>
        <div class="box noti effect kutular" style="margin-right: 13px; cursor: pointer;"
            onclick="location.href='ozelmesajlar.aspx'">
            <img style="margin-top: 13px;" src="images/commentblack32.png" /><span style="font-size: 12pt;
                position: absolute; color: #484848; margin-top: 2px;" id="spMsg" runat="server">
                0</span>
            <div class="clr">
            </div>
        </div>
        <div class="littlebar" onclick="location.href='Ayarlar.aspx'" style="cursor: pointer;">
            <div class="box settings effect kutular">
                <img style="margin-top: 12px;" src="images/gear32.png" /></div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="yaziyaz" runat="server">

</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="panel" runat="server">
    <div class="galeridiv">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        
        <ContentTemplate>
        <asp:ImageButton ImageUrl="~/images/artı.png" CssClass="galeriresim" 
            ID="imgGlr1" runat="server" onclick="imgGlr1_Click" />
        <asp:ImageButton ImageUrl="~/images/artı.png" CssClass="galeriresim" ID="imgGlr2" runat="server" onclick="imgGlr1_Click" />
        <asp:ImageButton ImageUrl="~/images/artı.png" CssClass="galeriresimsag" ID="imgGlr3" runat="server" onclick="imgGlr1_Click" />
        <asp:ImageButton ImageUrl="~/images/artı.png" CssClass="galeriresim" ID="imgGlr4" runat="server" onclick="imgGlr1_Click"/>
        <asp:ImageButton ImageUrl="~/images/artı.png" CssClass="galeriresim" ID="imgGlr5" runat="server" onclick="imgGlr1_Click"/>
        <asp:ImageButton ImageUrl="~/images/artı.png" CssClass="galeriresimsag" ID="imgGlr6" runat="server" onclick="imgGlr1_Click"/>
        <asp:ImageButton ImageUrl="~/images/artı.png" CssClass="galeriresim" ID="imgGlr7" runat="server" onclick="imgGlr1_Click" />
        <asp:ImageButton ImageUrl="~/images/artı.png" CssClass="galeriresim" ID="imgGlr8" runat="server" onclick="imgGlr1_Click"/>
        <asp:ImageButton ImageUrl="~/images/artı.png" CssClass="galeriresimsag" ID="imgGlr9" runat="server" onclick="imgGlr1_Click"/>
        
        </ContentTemplate>

        </asp:UpdatePanel>
    </div>
    <asp:Button ID="btnTamam" runat="server" Text="Tamam" 
        onclick="btnTamam_Click" /> 
    <asp:Button ID="btnYenile" runat="server" Text="Yenile" Visible="false" 
        onclick="btnYenile_Click" />
        <asp:Panel ID="pnlFileUpload" runat="server">
    </asp:Panel>
    

</asp:Content>
