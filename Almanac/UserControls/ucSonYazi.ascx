<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucSonYazi.ascx.cs" Inherits="Almanac.ucSonYazi" %>
<asp:Image ID="imgPR" Style="border: 1px solid #C5DADD; border-radius: 3px; margin-top:10px; width: 42px;
            height: 49px; float:left;" ImageUrl="~/images/yeni.png" runat="server"></asp:Image>
            <div style="float: left; border-radius: 3px; border: 1px solid #C5DADD; margin-top:10px; margin-left:5px; width: 430px;
        height: 121px;">
        <div style="height: 15px;">
        <asp:Label ID="lbGonderilen" runat="server" Text="Gönderilen Kişi:" Style="float: left; 
                font-size: 10pt; color: #8891A4; font-family: Calibri;"></asp:Label>
            <asp:Label ID="lbTarih" runat="server" Text="23.12.2013 23.23" Style="float: right;
                font-size: 10pt; color: #8891A4; font-family: Calibri;"></asp:Label></div>
        <asp:Label ID="lbMesaj" runat="server" Text="Label" Style="font-size: 12pt; float:left; color: #8891A4;
            font-family: Calibri; margin-left:5px;"></asp:Label>
             <a href="#" runat="server" id="hrfSil">
               <div style="float:right; margin-right:1px; margin-top:60px;">
            <img alt="Yazıyı İptal Et" src="~/images/cancel.png" width="24" height="24" 
             border="0" runat="server" id="imgIptal" /></a></div></div>
             