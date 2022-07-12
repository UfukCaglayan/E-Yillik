<%@ Page Title="" Language="C#" MasterPageFile="~/Profil.Master" AutoEventWireup="true" CodeBehind="ozelmesajlar.aspx.cs" Inherits="Almanac.WebForm8" %>

<asp:Content ID="Content1" ContentPlaceHolderID="IsimSoyisim" runat="server">
    <asp:Label ID="lbAdSoyad" runat="server" Text="Label"></asp:Label>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Profilresmi" runat="server">
   <asp:Image ID="imgPR" runat="server" ImageUrl="~/images/yeni.png" Style="width: 200px;
        height: 230px;" />
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="kutular" runat="server">
<div style="height: 60px; width: 300px; margin-top: 15px; margin-left: 4px;">
        <div class="box msg effect kutular" onclick="location.href='bildirimler.aspx'" style="margin-right: 13px;
            width: 60px; height: 60px; cursor:pointer;">
            <img style="margin-top: 13px;" src="images/lightbulb32.png" /><span style="font-size: 12pt;
                position: absolute; color: #484848; margin-top: 2px;" id="spBldrm" runat="server">
                0</span>
            <div class="clr">
            </div>
        </div>
        <div class="box noti effect kutular" style="margin-right: 13px; cursor:pointer;" onclick="location.href='ozelmesajlar.aspx'">
            <img style="margin-top: 13px;" src="images/commentblack32.png" /><span style="font-size: 12pt;
                position: absolute; color: #484848; margin-top: 2px;" id="spMsg" runat="server">
                0</span>
            <div class="clr">
            </div>
        </div>
        <div class="littlebar" style="cursor:pointer;" onclick="location.href='Ayarlar.aspx'">
            <div class="box settings effect kutular">

                    <img style="margin-top: 12px;" src="images/gear32.png" /></div>
        
        </div>
    </div>
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="yaziyaz" runat="server">


<div style="margin-left:15px;
    width:588px;
    height:576px;
    border:1px solid #C5DADD; border-radius:3px;
    font-family:Calibri;">

    <div style="width:588px;border-bottom:1px solid #C5DADD;height:50px;">
       
       <asp:Label ID="lbBen" runat="server" CssClass="labelkkk" Text="Label"></asp:Label>
       <asp:Label ID="lbKarsidaki" runat="server" CssClass="labelkkl" Text="Label"></asp:Label>
       <span style="margin-top:15px;float:left; margin-left:10px;">Kişiler</span>
   </div>
   
  
   
   
   <div style="float:left;width:518px;">
   <div id="testDiv2">
   <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
   <div style="width:518px;height:454px;">
       <asp:Panel ID="pnlAlan" runat="server">
       </asp:Panel>
       </div>
            <asp:Timer ID="tmrYenile" runat="server" Interval="100" 
                ontick="tmrYenile_Tick">
            </asp:Timer>
       </ContentTemplate>
        </asp:UpdatePanel>

   </div>
   </div>

    <div style="float:left;width:70px;">
    <div id="testDiv3">
    <asp:Panel ID="pnlProfilResimleri" runat="server" Height="441px">
        </asp:Panel>
        </div>
   </div>
   

    <div style="float:left; width:588px;height:20px; border-top:1px solid #C5DADD;">
        <asp:TextBox CssClass="awd" ID="txtMesaj" runat="server" TextMode="MultiLine"></asp:TextBox>
        <asp:Button ID="btnGonder" runat="server" Text="Gönder" CssClass="button" 
            onclick="btnGonder_Click" />
    
    </div>
    </div>

<style>
.labelkkk
{
    margin-left:20px;
    margin-top:15px;
    float:left;
    
}
.labelkkl
{
    float:left;
    margin-left:310px;
    margin-top:10px;
    width:155px;
}
.awd
{
    width:495px;height:40px;margin-lefT:10px;margin-top:10px;float:left;
}
.button
{
    height:48px;margin-top:9px;float:left;width:59px;margin-left:9px;
}

.imagebutton
{
    margin-left:5px;margin-top:5px;width:60px;height:80px;
}
</style>

</asp:Content>

<asp:Content ID="Content6" ContentPlaceHolderID="panel" runat="server">
</asp:Content>

<asp:Content ID="Content7" ContentPlaceHolderID="galeri" runat="server">
   +
</asp:Content>

